﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore_Backend.Configurations;
using NetCore_Backend.Data;
using NetCore_Backend.Models;
using NetCore_Backend.Models.DTOs;
using NuGet.Common;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                // check user
                var user_exsit = await _userManager.FindByEmailAsync(requestDto.Email);

                if (user_exsit != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email đã tồn tại"
                        }
                    });
                }

                if(!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
                }

                // tạo user
                var new_user = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.UserName
                };

                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
                await _userManager.AddToRoleAsync(new_user, UserRoles.User);

                if (is_created.Succeeded)
                {
                    return Ok(new AuthResult()
                    {
                        Result = true
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegistrationRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                // check user
                var user_exsit = await _userManager.FindByEmailAsync(requestDto.Email);

                if (user_exsit != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email đã tồn tại"
                        }
                    });
                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
                }

                // tạo user
                var new_user = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.UserName
                };

                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
                await _userManager.AddToRoleAsync(new_user, UserRoles.Admin);

                if (is_created.Succeeded)
                {
                    return Ok(new AuthResult()
                    {
                        Result = true
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateRoleSeller")]
        public async Task<IActionResult> UpdateRoleSeller([FromBody] string email = "test@gmail.com")
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));

            if (ModelState.IsValid)
            {
                // check user
                var user_exsit = await _userManager.FindByEmailAsync(email);

                if (await _roleManager.RoleExistsAsync(UserRoles.Seller))
                {
                    await _userManager.AddToRoleAsync(user_exsit, UserRoles.Seller);
                    
                    return Ok(new AuthResult()
                    {
                        Result = true
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateRoleAdmin")]
        public async Task<IActionResult> UpdateRoleAdmin([FromBody] string email)
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (ModelState.IsValid)
            {
                // check user
                var user_exsit = await _userManager.FindByEmailAsync(email);

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user_exsit, UserRoles.Admin);

                    return Ok(new AuthResult()
                    {
                        Result = true
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateRoleUser")]
        public async Task<IActionResult> UpdateRoleUser([FromBody] string email)
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (ModelState.IsValid)
            {
                // check user
                var user_exsit = await _userManager.FindByEmailAsync(email);

                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _userManager.AddToRoleAsync(user_exsit, UserRoles.User);

                    return Ok(new AuthResult()
                    {
                        Result = true
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequestDto)
        {
            if (ModelState.IsValid)
            {
                var exsiting_user = await _userManager.FindByNameAsync(loginRequestDto.UserName);

                if (exsiting_user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Invalid payload",
                        }
                    });
                }  

                var isCorrect = await _userManager.CheckPasswordAsync(exsiting_user, loginRequestDto.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        }
                    });
                }

                var userRoles = await _userManager.GetRolesAsync(exsiting_user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, exsiting_user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var jwtToken = GenerateJwtToken(exsiting_user, authClaims);

                return Ok(new AuthResult()
                {
                    Token = jwtToken.ToString(),
                    Result = true
                });
            }
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        private string GenerateJwtToken(IdentityUser user, List<Claim> authClaims)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value));

            var token = new JwtSecurityToken(
              _configuration.GetSection("JwtConfig:ValidIssuer").Value,
              _configuration.GetSection("JwtConfig:ValidAudience").Value,
              expires: DateTime.Now.AddMinutes(20),
              claims: authClaims,
              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
          );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

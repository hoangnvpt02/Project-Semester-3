using Microsoft.EntityFrameworkCore;
using NetCore_Backend.Data;
using NetCore_Backend.Services;
using NetCore_Backend.Services.Impl;

namespace NetCore_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("MyDb"));
            });
            services.AddScoped<ICountryRepository, CountryRepositoryImpl>();
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<IRoleRepository, RoleRepositoryImpl>();
            services.AddScoped<IGalaryRepository, GalaryRepositoryImpl>();
            services.AddScoped<IUserRoleRepository, UserRoleRepositoryImpl>();
            services.AddScoped<IDossierRepository, DossierRepositoryImpl>();
            services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<IProductRepository, ProductRepositoryImpl>();
            services.AddScoped<IProductCateRepository, ProductCateRepositoryImpl>();
            services.AddScoped<IProductGalaryRepository, ProductGalaryRepositoryImpl>();
            services.AddScoped<IWatchListRepository, WatchListRepositoryImpl>();
            services.AddScoped<IWatchListProductRepository, WatchListProductRepositoryImpl>();
            services.AddScoped<ICommentRepository, CommentRepositoryImpl>();
            services.AddScoped<IOrderRepository, OrderRepositoryImpl>();
            services.AddScoped<IBidRepository, BidRepositoryImpl>();
            services.AddScoped<IFileService, FileService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

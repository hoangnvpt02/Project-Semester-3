namespace NetCore_Backend.Models
{
    public class AuthResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}

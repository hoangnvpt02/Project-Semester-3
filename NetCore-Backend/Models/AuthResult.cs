namespace NetCore_Backend.Models
{
    public class AuthResult
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}

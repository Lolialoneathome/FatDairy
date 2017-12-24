namespace WebApi.DTOs
{
    public class AuthUserDTO
    {
        public string email;
        public string password;
        public Role Role;
    }

    public enum Role
    {
        Fatty,
        Trainer,
        Admin
    }
}

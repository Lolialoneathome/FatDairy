namespace WebApi.Auth
{
    public interface IAppUser
    {
        int Id { get; set; }
        string Email { get; set; }
    }
}

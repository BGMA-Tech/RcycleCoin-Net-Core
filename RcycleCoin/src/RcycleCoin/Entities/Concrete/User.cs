namespace Entities.Concrete
{
    public class User:Entity
    {
        public string UserId { get; set; }
        public string PersonelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public User()
        {

        }

        public User(int id,string userId, string personelId ,string firstName, string lastName, string email, string password, string rol):this()
        {
            Id= id;
            UserId= userId;
            PersonelId= personelId;
            FirstName= firstName;
            LastName= lastName;
            Email= email;
            Password= password;
            Rol= rol;
        }
    }
}

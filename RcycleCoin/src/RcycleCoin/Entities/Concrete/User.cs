namespace Entities.Concrete
{
    public class User:Entity
    {
        public string UserId { get; set; }
        public string PersonelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public User()
        {

        }

        public User(string userId, string personelId ,string firstName, string lastName, string email, string rol):this()
        {
            UserId= userId;
            PersonelId= personelId;
            FirstName= firstName;
            LastName= lastName;
            Email= email;
            Rol= rol;
        }
    }
}

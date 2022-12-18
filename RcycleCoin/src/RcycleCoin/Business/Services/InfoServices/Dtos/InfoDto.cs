using MongoDB.Bson;

namespace Business.Services.InfoServices.Dtos
{
    public class InfoDto
    {
        public string _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }

    }
}

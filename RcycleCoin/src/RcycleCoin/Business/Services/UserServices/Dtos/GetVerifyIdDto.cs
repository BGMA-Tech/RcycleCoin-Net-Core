using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserServices.Dtos
{
    public class GetVerifyIdDto
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthdayYear { get; set; }
    }

}

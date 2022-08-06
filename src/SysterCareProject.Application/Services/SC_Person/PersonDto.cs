using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Authorization.Users;

namespace SysterCareProject.Services.SC_Person
{
    public class PersonDto: EntityDto<Guid>
    {
        public string UserName { get; set; }

        public  string Name { get; set; }

        public  string Surname { get; set; }

        public  DateTime DOB { get; set; }



        public  string PhoneNumber { get; set; }

        public  string EmailAddress { get; set; }

        public  string AddressLine1 { get; set; }
        public  string AddressLine2 { get; set; }
        public  string AddressLine3 { get; set; }


        public  string Password { get; set; }

        public User User { get; set; }

        public  string[] RoleNames { get; set; }
    }
}

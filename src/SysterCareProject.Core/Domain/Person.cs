using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Authorization.Users;
using static SysterCareProject.Domain.RefList.Gender_RefList;

namespace SysterCareProject.Domain
{
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string UserName { get; set; }
        
        public virtual string Name { get; set; }
       
        public virtual string Surname { get; set; }
       
        public virtual DateTime DOB { get; set; }
      
    
       
        public virtual string PhoneNumber { get; set; }
       
        public virtual string EmailAddress { get; set; }
        
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string AddressLine3 { get; set; }


        public virtual string Password { get; set; }
        
        public User User { get; set; }

        [NotMapped]
        public virtual string[] RoleNames { get; set; }
    }
}

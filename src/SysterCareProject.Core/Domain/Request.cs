using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain.RefList;

namespace SysterCareProject.Domain
{
    public class Request: AuditedEntity<Guid>
    {
        public  virtual Requestor Requestor { get; set; }
        public virtual RequestRef_List Type { get; set; }
        public virtual DateTime RequestDate { get; set; }
    }
}

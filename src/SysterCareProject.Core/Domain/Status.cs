using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain.RefList;

namespace SysterCareProject.Domain
{
    public class Status:AuditedEntity<Guid>
    {
        public virtual Request Request { get; set; }
        public virtual StatusRef_List StatusType { get; set; }
    }
}

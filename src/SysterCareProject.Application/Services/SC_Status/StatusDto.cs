using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain.RefList;

namespace SysterCareProject.Services.SC_Status
{
    public class StatusDto:EntityDto<Guid>
    {
        public Guid RequestId { get; set; }
        public StatusRef_List StatusType { get; set; }
    }
}

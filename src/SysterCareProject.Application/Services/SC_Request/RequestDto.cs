using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain.RefList;

namespace SysterCareProject.Services.SC_Request
{
    public class RequestDto:EntityDto<Guid>
    {
        public  Guid RequestorId { get; set; }
        public  RequestRef_List Type { get; set; }
        public  DateTime RequestDate { get; set; }
    }
}

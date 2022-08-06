using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SysterCareProject.Domain.RefList.Gender_RefList;

namespace SysterCareProject.Services.SC_Donation
{
    public class DonationDto:EntityDto<Guid>
    {
        public  Ref_List DonationType { get; set; }
    }
}

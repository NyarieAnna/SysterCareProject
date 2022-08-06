using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Donation
{
    public class DonationMappingProfile:Profile
    {
        public DonationMappingProfile()
        {
            CreateMap<Donation, DonationDto>();

            CreateMap<DonationDto, Donation>();
        }
    }
}

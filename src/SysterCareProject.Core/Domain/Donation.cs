using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SysterCareProject.Domain.RefList.Gender_RefList;

namespace SysterCareProject.Domain
{
    public class Donation : Person
    {
        public virtual Ref_List DonationType { get; set; }

       

    }
}

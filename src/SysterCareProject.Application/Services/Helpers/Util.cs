using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SysterCareProject.Domain.RefList.Gender_RefList;

namespace SysterCareProject.Services.Helpers
{
    internal class Util
    {
        public static string MapSex(Ref_List refListGender)
        {
            string DType;
            if (refListGender == Ref_List.Cash)
                DType = "Cash";
            else
                DType = "Pads";
            return DType;

        }
    }
}

using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain;
using static SysterCareProject.Domain.RefList.Gender_RefList;

namespace SysterCareProject.Services.Helpers
{
    public class Util
    {

        public static string GenerateRequestorNum()
        {
            var uow = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            var student = IocManager.Instance.Resolve<IRepository<Requestor, Guid>>();
            using (uow.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var list = student.GetAll();
                var current = list.Count();
                var year = DateTime.UtcNow.Year;

                return $"{year}{current + 10000}";
            }

        }
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

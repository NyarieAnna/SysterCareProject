using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain.Attributes;

namespace SysterCareProject.Domain
{
    [DiscriminatorValue("Std.Requestor")]
    public class Requestor : Person
    {
        public virtual string RequestorNumber { get; set; }
    


    }
}
 
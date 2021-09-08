using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class City
    {
        public Guid UserDataId { get; set; }
        public Guid CityId { get; set; }
        public string city { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Email
    {
        public Guid UserDataId { get; set; }
        public Guid EmailId { get; set; }
        public string email { get; set; }
    }
}

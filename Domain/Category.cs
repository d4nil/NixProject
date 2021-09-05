using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Common
{
    public class SortableAttribute : Attribute
    {
        public string OrderBy { get; set; }
    }
}

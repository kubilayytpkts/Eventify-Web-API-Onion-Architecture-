using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.RequestParameters
{
    public class Pagination
    {
        public int PageCount { get; set; } = 0;
        public int ItemCount { get; set; } = 5;
    }
}

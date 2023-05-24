using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record Residence (int number, string street, string city, string prov, string postal)
    {
        public override string ToString()
        {
            return $"{number},{street},{city},{prov},{postal}";
        }
    }
}

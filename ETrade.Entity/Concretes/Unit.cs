using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class Unit : BaseDescreption
    {
        public ICollection<Products> Products { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }
    }
}

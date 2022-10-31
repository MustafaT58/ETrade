using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class Counties : BaseDescreption
    {
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public Cities Cities { get; set; }
    }
}

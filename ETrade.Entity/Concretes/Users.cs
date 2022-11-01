﻿using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class Users:BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<BasketMaster> BasketMasters { get; set; }
        [ForeignKey("CountyId")]
        public Counties Counties { get; set; }
    }
}

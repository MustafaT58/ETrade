using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class BaseDescreption : IBaseDescreption, IBaseTable
    {
        public string Descreption { get ; set ; }
        public int Id { get ; set ; }
    }
}

using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concretes
{
    public class CitiesRep<T> : BaseRepository<Cities>, ICitiesRep where T : class
    {
        public CitiesRep(TradeContext db) : base(db)
        {
        }
    }
}

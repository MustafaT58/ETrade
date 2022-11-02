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
    public class CountiesRep<T> : BaseRepository<Counties>, ICountiesRep where T : class
    {
        public CountiesRep(TradeContext db) : base(db)
        {
        }
    }
}

using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concretes
{
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {
        public BasketDetailRep(TradeContext db) : base(db)
        {
        }
        public List<BasketDetailDTO> GetBasketDetailDTOs(int MasterId)
        {
            return Set().Where(x => x.OrderId == MasterId).Select( x=>new BasketDetailDTO
            {
            ProductName=x.Products.ProductName,
            UnitName=x.Unit.Descreption,
            Id=x.OrderId,
            Amount=x.Amount,
            UnitPrice=x.UnitPrice,
            Vat=x.Ratio,
            ProductId=x.ProductId,
            Total=(x.UnitPrice*x.Amount)*(1 +(x.Ratio/100))
            }).ToList();
        }
    }
}

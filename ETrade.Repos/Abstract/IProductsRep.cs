using ETrade.Core;
using ETrade.DTO;
using ETrade.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstract
{
    public interface IProductsRep : IBaseRepository<Products>
    {
        List<ProductDTO> GetProductsSelect();
    }
}

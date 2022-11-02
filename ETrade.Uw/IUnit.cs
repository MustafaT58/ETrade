using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uw
{
    public interface IUnit
    {
        IBasketDetailRep _basketDetailRep { get;}
        IBasketMasterRep _basketMasterRep { get;}
        ICategoriesRep _categoriesRep { get;}
        ICitiesRep _citiesRep { get;}
        ICountiesRep _countiesRep { get;}
        IProductsRep _productsRep { get;}
        ISuppliersRep _suppliersRep { get;}
        IUnitRep _unitRep { get;}
        IUsersRep _usersRep { get;}
        IVatRep _vatRep { get;}
        void Commit();
    }
}

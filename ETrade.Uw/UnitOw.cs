using ETrade.Dal;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uw
{
    public class UnitOw : IUnit
    {
        TradeContext _db;
        public IBasketDetailRep _basketDetailRep { get; }

        public IBasketMasterRep _basketMasterRep { get; }

        public ICategoriesRep _categoriesRep { get; }

        public ICitiesRep _citiesRep { get; }

        public ICountiesRep _countiesRep { get; }

        public IProductsRep _productsRep { get; }

        public ISuppliersRep _suppliersRep { get; }
        public IUnitRep _unitRep { get; }
        public IUsersRep _usersRep { get; }

        public IVatRep _vatRep { get; }

        public void Commit()
        {
            _db.SaveChanges();
        }
        public UnitOw(TradeContext db, IBasketDetailRep basketDetailRep, IBasketMasterRep basketMasterRep, ICategoriesRep categoriesRep,
            ICitiesRep citiesRep, ICountiesRep countiesRep, IProductsRep productsRep, ISuppliersRep suppliersRep, IVatRep vatRep, IUsersRep usersRep, IUnitRep unitRep)
        {
            _db = db;
            _basketDetailRep = basketDetailRep;
            _basketMasterRep = basketMasterRep;
            _categoriesRep = categoriesRep;
            _citiesRep = citiesRep;
            _countiesRep = countiesRep;
            _productsRep = productsRep;
            _suppliersRep = suppliersRep;
            _vatRep = vatRep;
            _usersRep = usersRep;
            _unitRep = unitRep;

        }
    }
}

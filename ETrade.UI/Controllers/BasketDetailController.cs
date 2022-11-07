using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetail _basketDetail;
        IUnit _unit;
        BasketDetailModel _basketDetailModel;
        public BasketDetailController(BasketDetail basketDetail, IUnit unit,BasketDetailModel basketDetailModel)
        {
            _basketDetailModel = basketDetailModel;
            _basketDetail = basketDetail;
            _unit = unit;
        }

        public IActionResult Add(int Id)
        {
            _basketDetailModel.ProductsDTO = _unit._productsRep.GetProductsSelect();
            return View(_basketDetailModel);
        }
    }
}

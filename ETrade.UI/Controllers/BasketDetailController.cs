using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class BasketDetailController : Controller
    {
        IUnit _unit;
        BasketDetailModel _basketDetailModel;
        BasketDetail _basketDetail;
        public BasketDetailController(IUnit unit, BasketDetailModel basketDetailModel, BasketDetail basketDetail)
        {
            _basketDetailModel = basketDetailModel;
            _unit = unit;
            _basketDetail = basketDetail;
        }

        public IActionResult Add(int Id)
        {
            _basketDetailModel.ProductsDTO = _unit._productsRep.GetProductsSelect();
            _basketDetailModel.BasketDetailDTO = _unit._basketDetailRep.GetBasketDetailDTOs(Id);
            return View(_basketDetailModel);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel model, int Id)
        {
            Products products = _unit._productsRep.FindWithVat(model.ProductId); // select kısmında rageloading çalışır.
            _basketDetail.Amount = model.Amount;
            _basketDetail.ProductId = model.ProductId;
            _basketDetail.OrderId = Id;
            _basketDetail.UnitId = products.UnitId;
            _basketDetail.UnitPrice = products.UnitPrice;
            _basketDetail.Ratio = products.Vat.Ratio;
            _unit._basketDetailRep.Add(_basketDetail);
            _unit.Commit();

            return RedirectToAction("Add", new {Id});
        }
        public IActionResult Delete(int Id,int productId)
        {
            _unit._basketDetailRep.Delete(Id, productId);
            _unit.Commit();
            return RedirectToAction("Add", new {Id});
        }
    }
}

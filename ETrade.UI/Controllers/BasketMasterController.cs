using ETrade.DTO;
using ETrade.Entity.Concretes;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class BasketMasterController : Controller
    {
        IUnit _uow;
        BasketMaster _basketmaster;
        public BasketMasterController(IUnit uow, BasketMaster basketmaster)
        {
            _uow = uow;
            _basketmaster = basketmaster;
        }

        public IActionResult Create()
        {
            var user = JsonConvert.DeserializeObject<UsersDTO>(HttpContext.Session.GetString("User"));
            var selectedMaster = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false&&x.EntityId==user.Id);
            if (selectedMaster != null)
            {
                return RedirectToAction("Add", "BasketDetail", new { Id = selectedMaster.Id });
            }
            else
            {
                _basketmaster.OrderDate = DateTime.Now;
                _basketmaster.EntityId = user.Id;
                _uow._basketMasterRep.Add(_basketmaster);
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new { Id = _basketmaster.Id });
            }
        }
    }
}

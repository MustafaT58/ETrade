using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class UnitController : Controller
    {
        IUnit _uow;
        UnitModel _model;
        public UnitController(IUnit uow, UnitModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._unitRep.List();
            return View(clist);
        }

        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.Unit = new Unit();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(UnitModel m)
        {

            _uow._unitRep.Add(m.Unit);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.Unit = _uow._unitRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(UnitModel model)
        {

            _uow._unitRep.Delete(model.Unit.Id);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.Unit = _uow._unitRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(UnitModel c)
        {
            _uow._unitRep.Update(c.Unit);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}

using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class CityController : Controller
    {
        IUnit _uow;
        CityModel _model;
        public CityController(IUnit uow, CityModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist =_uow._citiesRep.List();
            return View(clist);
        }

        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.Cities = new Cities();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(CityModel m)
        {

            _uow._citiesRep.Add(m.Cities);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.Cities = _uow._citiesRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CityModel model)
        {

            _uow._citiesRep.Delete(model.Cities.Id);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.Cities = _uow._citiesRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(CityModel c)
        {
            _uow._citiesRep.Update(c.Cities);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}


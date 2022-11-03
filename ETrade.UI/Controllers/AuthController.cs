using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class AuthController : Controller
    {
        UsersModel _model;
        IUnit _uow;
        public AuthController(IUnit uow, UsersModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult Register()
        {
            _model.User = new Users();
            _model.Counties = _uow._countiesRep.List();
            return View(_model);
        }
        [HttpPost]
        public IActionResult Register(UsersModel usersModel)
        {
            usersModel.User = _uow._usersRep.CreateUser(usersModel.User);
            if (usersModel.User.Error==false)
            {
                _uow._usersRep.Add(usersModel.User);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //string msg = ("Böyle Bir Kullanıcı Mevcut");
                return RedirectToAction("Error", "Home", new {msg=$"{usersModel.User.Name} Kullanıcı Adı Zaten Var!!!"});
            }

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}

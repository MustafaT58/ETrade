using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            if (usersModel.User.Error == false)
            {
                usersModel.User.Role = "User";
                _uow._usersRep.Add(usersModel.User);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                usersModel.Counties = _uow._countiesRep.List();
                usersModel.Error = $"{usersModel.User.Email} Kullanıcı Mevcut!!!";
                return View(usersModel);
                // return RedirectToAction("Error", "Home", new {msg=$"{usersModel.User.Name} Kullanıcı Adı Zaten Var!!!"});
            }

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string eMail, string password)
        {
            var usr = _uow._usersRep.Login(eMail, password);
            if (usr.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(usr)); //Kayıt Oluşturur.
                if (usr.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                      return RedirectToAction("Index", "Home");
                 
                }

            }
            else
            {
                return View();
            }

        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}

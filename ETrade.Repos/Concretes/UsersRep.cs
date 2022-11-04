using ETrade.Core;
using ETrade.Dal;
using BCrypt;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace ETrade.Repos.Concretes
{
    public class UsersRep<T> : BaseRepository<Users>, IUsersRep where T : class
    {
        TradeContext _db;
        public UsersRep(TradeContext db) : base(db)
        {
            _db = db;
        }
        public Users CreateUser(Users users)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Email == users.Email);
            if (selectedUser == null)
            {
                users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.Error=false;
            }
            else
                users.Error=true ;
            return users;  
        }

        public UsersDTO Login(string userName, string password)
        {
            UsersDTO user = new UsersDTO();
            Users selectedUser=_db.Set<Users>().FirstOrDefault(x => x.Email == userName);
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            if (selectedUser!=null)
            {
                bool verifield = BCrypt.Net.BCrypt.Verify(password, selectedUser.Password);
                if (verifield==true)
                { 
                    user.Id = selectedUser.Id;
                    user.Email =selectedUser.Email;
                    user.Role = selectedUser.Role;
                    user.Error=false ;
                }
                else
                {
                    user.Error = true;
                    
                }
            }
            else
            {
                user.Error = true;
            }
            return user;
        }
    }
}

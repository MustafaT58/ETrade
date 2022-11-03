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
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Name == users.Name);
            if (selectedUser == null)
            {
                users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.Error=false;
            }
            else
                users.Error=true ;
            return users;
             
        }
    }
}

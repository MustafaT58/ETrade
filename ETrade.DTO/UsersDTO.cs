using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool Error { get; set; }
    }
}

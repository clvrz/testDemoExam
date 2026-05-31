using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using test1.Data_;

namespace test1.Material_.Models
{
    public static class AuthService
    {
        public static bool Auth(string login, string password)
        {
            using (var db = new TestCarDbEntities())
            {
                return db.Users.Any(u => u.Login == login && u.Password == password);
            }
        }
    }
}

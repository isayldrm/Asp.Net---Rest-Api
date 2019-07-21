using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing.Dal
{
    public class UsersDal:BaseDal
    {
        public User GetUserByApiKey(string apiKey)
        {
            return dbEntities.Users.FirstOrDefault(x=> x.UserKey.ToString()==apiKey);
        }
    }
}

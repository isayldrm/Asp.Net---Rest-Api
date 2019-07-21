using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing.Dal
{
    public class BaseDal
    {
        protected ProgrammingDbEntities dbEntities;
        public BaseDal()
        {
            dbEntities = new ProgrammingDbEntities();
        }
    }
}

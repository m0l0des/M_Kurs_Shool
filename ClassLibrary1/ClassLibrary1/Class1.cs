using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Analytics
    {

        public Boolean CheckRole(int ContactTypeId)
        {
            if (ContactTypeId <= 1)
            {
                return false;
            }
            else
                return true;
        }


        public string RoleNotNull(int price)
        {
            if (price <= 0)
            {
                return "Роль не может быть меньше или равна нулю!!!";
            }
            else
                return "Всё правильно";
        }
    }
}
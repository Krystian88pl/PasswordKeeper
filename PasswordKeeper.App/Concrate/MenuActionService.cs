using PasswordKeeper.App.Common;
using PasswordKeeper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.App.Concrate
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Passwords)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddPassword(new MenuAction(1, "Add password", "Main"));
            AddPassword(new MenuAction(2, "Remove password", "Main"));
            AddPassword(new MenuAction(3, "Show detail", "Main"));

            AddPassword(new MenuAction(1, "WebService", "AddNewPasswordMenu"));
            AddPassword(new MenuAction(2, "BankAccount", "AddNewPasswordMenu"));
            AddPassword(new MenuAction(3, "Other", "AddNewPasswordMenu"));
        }
    }

}

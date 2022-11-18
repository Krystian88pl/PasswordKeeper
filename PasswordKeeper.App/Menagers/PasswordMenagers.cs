using PasswordKeeper.App.Abstract;
using PasswordKeeper.App.Concrate;
using PasswordKeeper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordKeeper.App.Menagers
{
    public class PasswordMenagers
    {
        private readonly MenuActionService _actionService;
        private IService<Password> _passwordService;
        public PasswordMenagers(MenuActionService actionService, IService<Password> passwordService)
        {
            _passwordService = passwordService;
            _actionService = actionService;
        }
        public int AddNewPassword()
        {
            var addPasswordMenu = _actionService.GetMenuActionsByMenuName("AddNewPasswordMenu");
            Console.WriteLine();
            Console.WriteLine("Please select category:");
            for (int i = 0; i < addPasswordMenu.Count; i++)
            {
                Console.WriteLine($"{addPasswordMenu[i].Id}. {addPasswordMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            int typeId;
            int.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine();
            Console.WriteLine("Please insert login:");
            var login = Console.ReadLine();
            Console.WriteLine("Please insert password");
            var password = Console.ReadLine();
            var lastId = _passwordService.GetLastId();
            Password password1 = new Password(lastId + 1, login, password, typeId);
            _passwordService.AddPassword(password1);
            _passwordService.XmlSave();
            
            return password1.Id;

        }
        public void PasswordShow()
        {
            _passwordService.XmlRead();

            if (_passwordService.Passwords.Any())
            {
                foreach (var password in _passwordService.Passwords)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id:{password.Id}");
                    Console.WriteLine($"Login: {password.Login}");
                    Console.WriteLine($"Password: {password.Passwords}");
                }
            }
        }

        public Password PasswordShowById(int id)
        {
            var password = _passwordService.GetPasswordById(id);
            return password;
        }

        public void Remove()
        {
            Console.WriteLine();
            Console.WriteLine("Please insert id you want remove");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            var passwordToRemove = _passwordService.Passwords.Find(x => x.Id == id);
            _passwordService.Remove(passwordToRemove);

        }
        public void Remove(Password password)
        {
            _passwordService.RemoveItem(password);
        }

    }
}

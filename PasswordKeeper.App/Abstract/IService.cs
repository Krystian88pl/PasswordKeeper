using PasswordKeeper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.App.Abstract
{
    public interface IService<T>
    {
        List<T> Passwords { get; set; }

        List<T> GetAllPasswords();
        int GetLastId();
        T GetPasswordById(int id);
        int AddPassword(T password);
        int UpdatePassword(T password);
        void RemoveItem(T password);
        void Remove(Password password);
        void XmlSave();
        void XmlRead();
    }
}

using PasswordKeeper.App.Abstract;
using PasswordKeeper.App.Concrate;
using PasswordKeeper.Domain.Common;
using PasswordKeeper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordKeeper.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Passwords { get; set; }
        public BaseService()
        {
            Passwords = new List<T>();
        }

        public int AddPassword(T password)
        {
            Passwords.Add(password);
            return password.Id;
            

        }

        public List<T> GetAllPasswords()
        {
            return Passwords;
        }

        public int GetLastId()
        {
            int lastId;
            if (Passwords.Any())
            {
                lastId = Passwords.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public T GetPasswordById(int id)
        {
            var entity = Passwords.FirstOrDefault(p => p.Id == id);
            return entity;
        }

        public int UpdatePassword(T password)
        {
            var entity = Passwords.Find(p => p.Id == password.Id);
            if(entity != null)
            {
                entity = password;
            }
            return entity.Id;
        }

        public void RemoveItem(T password)
        {
            Passwords.Remove(password);
        }


        public void Remove(Password password)
        {
           Passwords.Remove(GetPasswordById(password.Id));
        }

        public void XmlSave()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Passwords";
            root.IsNullable = true;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Password>), root);

            using StreamWriter sw = new StreamWriter(@"C:\Users\Krystian\PasswordKeeperFiles\Password.xml");
            xmlSerializer.Serialize(sw, Passwords);
        }

        public void XmlRead()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Passwords";
            root.IsNullable = true;
            string xml = File.ReadAllText(@"C:\Users\Krystian\PasswordKeeperFiles\Password.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Password>), root);
            StringReader sr = new StringReader(xml);
            var xmlPasswords = (List<Password>)xmlSerializer.Deserialize(sr);
        }
    }
}

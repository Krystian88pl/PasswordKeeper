using PasswordKeeper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordKeeper.Domain.Entity
{
    public class Password : BaseEntity
    {
        [XmlElement("Login")]
        public string Login { get; set; }
        [XmlElement ("Password")]  
        public string Passwords { get; set; }
        [XmlElement("Type")]
        public int TypeId { get; set; }

        int passwordLength { get; set; }

        public Password()
        {

        }
        public Password(int id, string login, string passwords, int typeId)
        {
            Login = login;
            Passwords = passwords;
            TypeId = typeId;
            Id = id;
        }

        public Password(int id, string login, int typeId)
        {
            Id = id;
            Login = login;
            TypeId = typeId;
        }
    }
}

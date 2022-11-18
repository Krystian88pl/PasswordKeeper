using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordKeeper.Domain.Common
{
    public class BaseEntity : AuditTableModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}

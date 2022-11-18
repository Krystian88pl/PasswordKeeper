﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordKeeper.Domain.Common
{
    public class AuditTableModel
    {
        [XmlIgnore]
        public int CreatedById { get; set; }
        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }
        [XmlIgnore]
        public int? ModifedById { get; set; }
        [XmlIgnore]
        public DateTime ModifedDateTime { get; set; }
    }
}
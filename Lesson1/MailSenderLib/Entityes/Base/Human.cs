using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Entityes.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        public string Name { get; set; }
    }
    public class Human : NamedEntity
    {      
        public string Email { get; set; }
    }
}

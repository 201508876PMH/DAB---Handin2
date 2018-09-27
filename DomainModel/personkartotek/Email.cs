using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    public class Email
    {
        public Email(int personID, int emailID)
        {
            this.personID = personID;
            this.emailID = emailID;
        }

        public int personID { get; set; }
        public int emailID { get; set; }
        
    }
}

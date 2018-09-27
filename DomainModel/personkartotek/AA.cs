using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    public class AA
    {
        public AA(int aAID, int personID)
        {
            AAID = aAID;
            this.personID = personID;
        }

        public int AAID { get; set; }
        public int personID { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    public class Telefonnummer
    {
        public Telefonnummer(int telefonnummerID, int personID, int teleselskabID, string type)
        {
            this.telefonnummerID = telefonnummerID;
            this.personID = personID;
            this.teleselskabID = teleselskabID;
            this.type = type;
        }

        public int telefonnummerID { get; set; }
        public int personID { get; set; }
        public int teleselskabID { get; set; }
        public string type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    class Teleselskab
    {
        public Teleselskab(int teleselskabID, int regning)
        {
            this.teleselskabID = teleselskabID;
            this.regning = regning;
            telefonnummerList = new List<Telefonnummer>();
        }

        public ICollection<Telefonnummer> telefonnummerList { get; set; }
        public int teleselskabID { get; set; }
        public int regning { get; set; }

    }
}

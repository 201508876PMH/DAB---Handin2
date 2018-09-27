using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    class Town
    {
        public Town(int townID, string postNummer, string townNavn)
        {
            this.townID = townID;
            this.postNummer = postNummer;
            this.townNavn = townNavn;
            adresseList = new List<Adresse>();
        }

        public ICollection<Adresse> adresseList { get; set; }
        public int townID { get; set; }
        public string postNummer { get; set; }
        public string townNavn { get; set; }

    }
}

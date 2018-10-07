using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    public class Town
    {
        public Town(string postNummer, string townNavn)
        {
            this.postNummer = postNummer;
            this.townNavn = townNavn;
            adresseList = new List<Adresse>();
        }

        public Town() { }
        public ICollection<Adresse> adresseList { get; set; }
        public int townID { get; set; }
        public string postNummer { get; set; }
        public string townNavn { get; set; }

        public override string ToString()
        {
            return string.Format("ID: " + townID + ", post nummer: " + postNummer + ", town navn: " + townNavn);
        }
    }
}

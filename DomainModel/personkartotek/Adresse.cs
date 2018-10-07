using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.personkartotek;

namespace DomainModel.personkartotek
{
    public class Adresse
    {
        public Adresse(string vejNavn, string vejNummer, int townID)
        {
            this.vejNavn = vejNavn;
            this.vejNummer = vejNummer;
            this.townID = townID;
            personList = new List<Person>();
            alternativadresseList = new List<AA>();
        }

        public Adresse() { }
        public ICollection<Person> personList { get; set; }
        public ICollection<AA> alternativadresseList { get; set; }

        public long adresseID { get; set; }
        public string vejNavn { get; set; }
        public string vejNummer { get; set; }
        public int townID { get; set; }

        public override string ToString()
        {
            return string.Format("ID: " + adresseID + ", vej navn: " + vejNavn + ", vej nummer " + vejNummer + ", townID " + townID);
        }


    }
}

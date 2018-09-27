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
        public Adresse(long adresseID, string vejNavn, int vejNummer, int townID)
        {
            this.adresseID = adresseID;
            this.vejNavn = vejNavn;
            this.vejNummer = vejNummer;
            this.townID = townID;
            personList = new List<Person>();
            alternativadresseList = new List<AA>();
        }

        public ICollection<Person> personList { get; set; }
        public ICollection<AA> alternativadresseList { get; set; }

        public long adresseID { get; set; }
        public string vejNavn { get; set; }
        public int vejNummer { get; set; }
        public int townID { get; set; }




    }
}

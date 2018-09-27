using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DomainModel.personkartotek
{
    public class Person
    {
        public Person(int personID, long adresseID, string firstName, string middleName, string lastName, string context, string gender)
        {
            this.personID = personID;
            this.adresseID = adresseID;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.context = context;
            this.gender = gender;
            emailList = new List<Email>();
            noteList = new List<Note>();
            telefonnummerList = new List<Telefonnummer>();
            alternativadresseList = new List<AA>();

        }

        public Person()
        {

        }
    
        public ICollection<Email> emailList { get; set; }
        public ICollection<Note> noteList { get; set; }
        public ICollection<Telefonnummer> telefonnummerList { get; set; }
        public ICollection<AA> alternativadresseList { get; set; }

        public int personID { get; set; }
        public long adresseID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string context { get; set; }
        public string gender { get; set; }

    }
}

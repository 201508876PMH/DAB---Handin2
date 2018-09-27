using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.personkartotek;
using Infrastructure.personkartotekDBADONET;

namespace ApplicationLogic
{
    public class PersonkartotekApp
    {
        public void theApp()
        {
            PersonkartotekDBUtil utilObject = new PersonkartotekDBUtil();
            Person nyPerson = new Person(2, 2, "Anton", "Rørbæk", "Sihm", "skole", "mand");
            utilObject.addPersonTilDB(ref nyPerson);

            Person personToSearchFor = new Person() {firstName = "Anton", lastName = "Sihm"};
            utilObject.getPersonByName(ref personToSearchFor);
            utilObject.getPersonByID(ref personToSearchFor);

            Email email1 = new Email(nyPerson.personID, 100);
            utilObject.addEmailToDB(ref email1);

        }
    }
}

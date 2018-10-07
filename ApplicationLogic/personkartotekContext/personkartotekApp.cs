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
            List<Person> personList;

            Town newTown = new Town("8210", "Aarhus");
            utilObject.addTownDB(ref newTown);

            Adresse nyAdresse = new Adresse("kærvænget", "9", newTown.townID);
            utilObject.addAdresseDB(ref nyAdresse);
            
            

            Person nyPerson = new Person(nyAdresse.adresseID, "Anton", "Rørbæk", "Sihm", "skole", "mand");
            //utilObject.addPersonTilDB(ref nyPerson);

            //utilObject.getAllePersonDB();


            //utilObject.updatePersonDB();

            //Person nyPerson2 = new Person(nyAdresse.adresseID, "Anton", "Rørbæk", "test", "skole", "mand");
            //utilObject.addPersonTilDB(ref nyPerson2);

            //Person HjælpeObjPerson = new Person(, ¨dsbsdbds, aarus);

            //utilObject.deletePersonDB("Anton", "sihm", aarus);
            //utilObject.deletePersonDB(ref HjælpeObjPerson);


            //Telefonnummer nytTelefonnummer = new Telefonnummer(50696065, 2, 100, "arbejde");
            //utilObject.addTelefonnummerDB(ref nytTelefonnummer);

            //Note note1 = new Note(20, 1002, "This is a note");
            //utilObject.addNoteDB(ref note1);



        }
    }
}

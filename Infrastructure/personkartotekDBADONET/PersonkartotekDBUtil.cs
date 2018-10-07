 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
 using System.Security.AccessControl;
 using System.Text;
using System.Threading.Tasks;
using DomainModel;
 using DomainModel.personkartotek;

namespace Infrastructure.personkartotekDBADONET
{
    public class PersonkartotekDBUtil
    {
        private Person currentPerson;

        public PersonkartotekDBUtil()
        {
            
        }

        private SqlConnection openConnection
        {
            get
            {
                var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=handIn2;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                con.Open();
                return con;
            }
        }

        /* PERSON (Opret, ændre og slet en kontaktperson) */
        public void addPersonTilDB(ref Person person)
        {
            string checker = "SELECT COUNT(*) FROM Person WHERE (firstName = @firstName) AND (lastName = @lastName)";

            using (SqlCommand cmd0 = new SqlCommand(checker, openConnection))
            {
                cmd0.Parameters.AddWithValue("firstName", person.firstName);
                cmd0.Parameters.AddWithValue("lastName", person.lastName);

                int personExists = (int) cmd0.ExecuteScalar();

                if (personExists > 0)
                {
                    Console.WriteLine("Person exists");
                    return;
                }
                else
                {
                    string insertStringParam =
                        @"INSERT INTO [Person] (adresseID, firstName, middleName, lastName, context, gender)
                                        OUTPUT INSERTED.personID
                                        VALUES (@adresseID, @firstName, @middleName, @lastName, @context, @gender)";

                    using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
                    {
                        //cmd.Parameters.AddWithValue("@personID", person.personID);
                        cmd.Parameters.AddWithValue("@adresseID", person.adresseID);
                        cmd.Parameters.AddWithValue("@firstName", person.firstName);
                        cmd.Parameters.AddWithValue("@middleName", person.middleName);
                        cmd.Parameters.AddWithValue("@lastName", person.lastName);
                        cmd.Parameters.AddWithValue("@context", person.context);
                        cmd.Parameters.AddWithValue("@gender", person.gender);

                        person.personID = (int)cmd.ExecuteScalar();
                    }
                }
            }
          
        }
        public void getPersonByName(ref Person person)
        {
            string sqlcommand = @"SELECT TOP 1 * FROM Person WHERE (firstName = @fname) AND (lastName = @lname)";
            using (var cmd = new SqlCommand(sqlcommand, openConnection))
            {
                cmd.Parameters.AddWithValue("@fname", person.firstName);
                cmd.Parameters.AddWithValue("@lname", person.lastName);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    currentPerson.personID = (int) rdr["personID"];
                    currentPerson.adresseID = (long)rdr["adresseID"];
                    currentPerson.firstName = (string)rdr["firstName"];
                    currentPerson.middleName = (string)rdr["middleName"];
                    currentPerson.lastName = (string)rdr["lastName"];
                    currentPerson.context = (string)rdr["context"];
                    currentPerson.gender = (string)rdr["gender"];
                    person = currentPerson;
                }
            }
        }
        public void getPersonByID(ref Person person)
        {
            string sqlcommand = @"SELECT [adresseID],[firstName],[middleName],[lastName],[context],[gender] FROM Person WHERE ([personID] = @personID)";
            using (var cmd = new SqlCommand(sqlcommand, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", person.personID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    currentPerson.personID = person.personID;
                    currentPerson.adresseID = (long) rdr["adresseID"];
                    currentPerson.firstName = (string)rdr["firstName"];
                    currentPerson.middleName = (string)rdr["middleName"];
                    currentPerson.lastName = (string)rdr["lastName"];
                    currentPerson.context = (string)rdr["context"];
                    currentPerson.gender = (string)rdr["gender"];
                    person = currentPerson;
         
                }
              

            }
        }
        public void updatePersonDB(ref Person person)
        {
            string updateString =
                @"UPDATE Person SET adresseID = @adresseID, firstName = @firstName,
                                    middleName = @middleName, lastName = @lastName, context = @context, gender = @gender
                                    WHERE personID = @personID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@adresseID", person.adresseID);
                cmd.Parameters.AddWithValue("@firstName", person.firstName);
                cmd.Parameters.AddWithValue("@middleName", person.middleName);
                cmd.Parameters.AddWithValue("@lastName", person.lastName);
                cmd.Parameters.AddWithValue("@context", person.context);
                cmd.Parameters.AddWithValue("@gender", person.gender);
                cmd.Parameters.AddWithValue("@personID", person.personID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void deletePersonDB(ref Person person)
        {
            string deleteString = @"DELETE FROM Person WHERE (personID = @personID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", person.personID);

                var id = (int) cmd.ExecuteNonQuery();
                person = null;
            }
        }

        public int findPersonIDByName(string firstName, string lastName)
        {
            string sqlCommand = @"SELECT TOP 1 * FROM [Person] WHERE(firstName = @firstName AND lastName = @lastName)";
            int id;

            using (var cmd = new SqlCommand(sqlCommand, openConnection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    id = (int) rdr["personID"];
                    return id;
                }
                else
                {
                    return 0;
                }
            }

        }
        public List<Person> getAllePersonDB()
        {
            string sqlcmd = @"SELECT * FROM Person";

            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<Person> hver = new List<Person>();
                Person person = null;

                while (rdr.Read())
                {
                    person = new Person();
                    person.personID = (int) rdr["personID"];
                    person.adresseID = (long) rdr["adresseID"];
                    person.firstName = (string) rdr["firstName"];
                    person.middleName = (string) rdr["middleName"];
                    person.lastName = (string) rdr["lastName"];
                    person.context = (string) rdr["context"];
                    person.gender = (string) rdr["gender"];
                    hver.Add(person);
                }

                return hver;
            }   
        }
        /* PERSON */


        /* ADRESSE (Tilføje, Ændre kontaktadresse) */
        public void updateAdresseDB(ref Adresse adresse)
        {
            string updateString = @"UPDATE adresse SET vejNavn = @vejNavn, vejNummer = @vejNummer, townID = @townID
                                    WHERE adresseID = @adresseID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@vejNavn", adresse.vejNavn);
                cmd.Parameters.AddWithValue("@vejNummer", adresse.vejNummer);
                cmd.Parameters.AddWithValue("@townID", adresse.townID);
                cmd.Parameters.AddWithValue("@adresseID", adresse.townID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void addAdresseDB(ref Adresse adresse)
        {
            string insertStringParam = @"INSERT INTO [Adresse] (vejNavn, vejNummer, townID)
                                                     OUTPUT INSERTED.adresseID
                                                     VALUES (@vejNavn, @vejNummer, @townID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@vejNavn", adresse.vejNavn);
                cmd.Parameters.AddWithValue("@vejNummer", adresse.vejNummer);
                cmd.Parameters.AddWithValue("@townID", adresse.townID);

                adresse.adresseID = (long) cmd.ExecuteScalar();
            }
        }
        public List<Adresse> getAllAdresseDB()
        {
            string sqlcmd = @"SELECT * FROM Adresse";

            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<Adresse> hverAdresses = new List<Adresse>();
                Adresse adresse = null;

                while (rdr.Read())
                {
                    adresse = new Adresse();
                    adresse.adresseID = (long)rdr["adresseID"];
                    adresse.vejNavn = (string)rdr["vejNavn"];
                    adresse.vejNummer = (string)rdr["vejNummer"];
                    adresse.townID = (int)rdr["townID"];

                    hverAdresses.Add(adresse);
                }

                return hverAdresses;
            }
        }
        /* ADRESSE */


        /* TOWN (Tilføje, Ændre kontaktadresse) */
        public void updateTownDB(ref Town town) { }
        public void addTownDB(ref Town town)
        {
            string insertStringParam = @"INSERT INTO [Town] (postNummer, townNavn)
                                                       OUTPUT INSERTED.townID
                                                        VALUES (@postNummer, @townNavn)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@postNummer", town.postNummer);
                cmd.Parameters.AddWithValue("@townNavn", town.townNavn);

                town.townID = (int) cmd.ExecuteScalar();
            }
        }
        public List<Town> getAlleTownDB()
        {
            string sqlcmd = @"SELECT * FROM Town";

            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<Town> hverTown = new List<Town>();
                Town town = null;

                while (rdr.Read())
                {
                    town = new Town();
                    town.townID = (int)rdr["townID"];
                    town.postNummer = (string)rdr["postNummer"];
                    town.townNavn = (string)rdr["townNavn"];
                    hverTown.Add(town);
                }

                return hverTown;
            }
        }
        public void deleteTown(ref Town town)
        {
            string deleteString = @"DELETE FROM Town WHERE (townID = @townID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@townID", town.townID);

                var id = (int) cmd.ExecuteNonQuery();
                town = null;
            }
        }
        /* TOWN */



        /* AA (Tilføje, ændre og slette en alternativ adresse) */
        public void addAADB(ref AA aa_)
        {
            string insertStringParam = @"INSERT INTO [AA] (personID) OUTPUT INSERTED.AAID
                                                                     VALUES (@personID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", aa_.personID);
                cmd.Parameters.AddWithValue("@AAID", aa_.AAID);

                aa_.AAID = (int) cmd.ExecuteScalar();
            }
        }
        public void updateAADB(ref AA aa_)
        {
            string updateString = @"UPDATE AA SET personID = @personID WHERE AAID = @AAID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", aa_.personID);
                cmd.Parameters.AddWithValue("@AAID", aa_.AAID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void deleteAADB(ref AA aa_)
        {
            string deleteString = @"DELETE FROM AA WHERE (AAID = @AAID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@AAID", aa_.AAID);

                var id = (int) cmd.ExecuteNonQuery();
                aa_ = null;
            }

           
        }
        /* AA */



        /* EMAIL (Tilføje, ændre og slette en e-mail) */
        public void addEmailDB(ref Email email)
        {
            string insertParam = @"INSERT INTO [Email] (personID) OUTPUT INSERTED.EmailID
                                                                  VALUES (@personID)";

            using (SqlCommand cmd = new SqlCommand(insertParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", email.personID);
                cmd.Parameters.AddWithValue("@emailID", email.emailID);

                email.emailID = (int) cmd.ExecuteScalar();
            }
        }
        public void updateEmailDB(ref Email email)
        {
            string updateString = @"UPDATE Email SET personID = @personID WHERE EmailID = @EmailID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", email.personID);
                cmd.Parameters.AddWithValue("@emailID", email.emailID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void deleteEmailDB(ref Email email)
        {
            string deleteString = @"DELETE FROM Email WHERE (EmailID = @EmailID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@EmailID", email.emailID);

                var id = (int) cmd.ExecuteNonQuery();
                email = null;
            }
        }
        /* EMAIL */

           

        /* TELEFONOPLYSNING (Tilføje, ændre og slette en telefonoplysning) */
        public void addTelefonnummerDB(ref Telefonnummer telefonnummer_)
        {
            string insertParam =
                @"INSERT INTO [Telefonummer] (personID, teleselskabID, type) OUTPUT INSERTED.telefonnummerID
                                                                                                VALUES (@personID, @teleselskabID, @type)";

            using (SqlCommand cmd = new SqlCommand(insertParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", telefonnummer_.personID);
                cmd.Parameters.AddWithValue("@teleselskabID", telefonnummer_.teleselskabID);
                cmd.Parameters.AddWithValue("@type", telefonnummer_.type);
                cmd.Parameters.AddWithValue("@telefonnummerID", telefonnummer_.telefonnummerID);

                telefonnummer_.telefonnummerID = (int) cmd.ExecuteScalar();
            }
        }
        public void updateTelefonnummerDB(ref Telefonnummer telefonnummer)
        {
            string updateString =
                "@UPDATE Telefonnummer SET personID = @personID, teleselskabID = @telesekslabID, type = @type WHERE telefonnummerID = @telefonnummerID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", telefonnummer.personID);
                cmd.Parameters.AddWithValue("@teleselskabID", telefonnummer.teleselskabID);
                cmd.Parameters.AddWithValue("@type", telefonnummer.type);
                cmd.Parameters.AddWithValue("@telefonnummerID", telefonnummer.telefonnummerID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void deleteTelefonnummerDB(ref Telefonnummer telefonnummer)
        {
            string deleteString = @"DELETE FROM Telefonnummer WHERE (telefonnummerID = @telefonnummerID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@telefonnummerID", telefonnummer.telefonnummerID);

                var id = (int) cmd.ExecuteNonQuery();
                telefonnummer = null;
            }
        }
        /* TELEFONOPLYSNING*/



        /* NOTE (Tilføje, ændre og slette en note) */
        public void addNoteDB(ref Note note)
        {


            string insertParam = @"INSERT INTO [Note] (noteData, personID) OUTPUT INSERTED.NoteID
                                                                            VALUES (@noteData, @personID)";

            using (SqlCommand cmd = new SqlCommand(insertParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", note.personID);
                cmd.Parameters.AddWithValue("@noteData", note.noteData);
               

                note.noteID = (int) cmd.ExecuteScalar();
            }
        }
        public void updateNoteDB(ref Note note)
        {
            string updateString = @"UPDATE Note SET personID = @personID, noteData = @noteData WHERE noteID = @noteID";

            using (SqlCommand cmd = new SqlCommand(updateString, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", note.personID);
                cmd.Parameters.AddWithValue("@noteData", note.noteData);
                cmd.Parameters.AddWithValue("@noteID", note.noteID);

                var id = (int) cmd.ExecuteNonQuery();
            }
        }
        public void deleteNoteDB(ref Note note)
        {
            string deleteString = @"DELETE FROM Note WHERE (noteID = @noteID)";

            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@noteID", note.noteID);

                var id = (int) cmd.ExecuteNonQuery();
                note = null;
            }
        }
        /* NOTE */

        /* Vise en oversigt over kontakter. */
    }
}


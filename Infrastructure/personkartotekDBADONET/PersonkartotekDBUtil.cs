 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            currentPerson = new Person(12,1,"Peter", "Marcus", "Hoveling", "arbejde", "mand");
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

        public void addPersonTilDB(ref Person person)
        {
            // personID er måske ikke nødvendigt at give med
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

                //person.personID = (int) cmd.ExecuteScalar();??
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
            string sqlcommand = @"SELECT [adresseID], [firstName], [middleName], [lastName], [context], [gender] FROM 
                                  Person WHERE ([personID] = @personID)";
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

        public void addEmailToDB(ref Email email)
        {
            string insertStringParam = @"INSERT INTO [Email] (personID, emailID)
                                        OUTPUT INSERTED.emailID
                                        VALUES (@personID, @emailID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@personID", email.personID);
                cmd.Parameters.AddWithValue("@emailID", email.emailID);
                email.emailID = (int) cmd.ExecuteScalar();
            }
        }
       
    }
}


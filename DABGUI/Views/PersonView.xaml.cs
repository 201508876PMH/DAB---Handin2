using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DomainModel.personkartotek;
using Infrastructure.personkartotekDBADONET;

namespace DABGUI.Views
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private PersonkartotekDBUtil personkartotek_;
        //private Person p1;
        char[] separators0 = { ':',',', ' ' };
        string[] tokens;

        public void getDataInList()
        {
            List<Person> personListfromDB = personkartotek_.getAllePersonDB();
            ListBox_.Items.Clear();

            foreach (Person p in personListfromDB)
            {
                ListBox_.Items.Add(p);
            }
        }

        public void clearFields()
        {
            adresseIDTxtBox.Text = "";
            firstNameTxtBox.Text = "";
            middleNameTxtBox.Text = "";
            lastNameTxtBox.Text = "";
            contextTxtBox.Text = "";
            genderTxtBox.Text = "";
            personIDtxtBlock.Text = "";

        }

        public PersonView()
        {
            InitializeComponent();
            personkartotek_ = new PersonkartotekDBUtil();


           
        }


        //get data
        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            getDataInList();
        }

        //Delete
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = new Person();
                person.personID = int.Parse(personIDtxtBlock.Text);

                personkartotek_.deletePersonDB(ref person);
                MessageBox.Show("Person was deleted");
                getDataInList();
                clearFields();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Person cant be deleted");
            }
           
        }


        //add
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count = ListBox_.Items.Count;
            try
            {
                Person person = new Person(long.Parse(adresseIDTxtBox.Text), firstNameTxtBox.Text, middleNameTxtBox.Text,
                lastNameTxtBox.Text, contextTxtBox.Text, genderTxtBox.Text);
                personkartotek_.addPersonTilDB(ref person);
                getDataInList();

                if (ListBox_.Items.Count > count)
                {
                    MessageBox.Show("Person added.");
                    getDataInList();
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Cannot add the same person");
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("The person needs to be assigned a city");
               
            }
            
        }

        //selected items
        private void tryMethod(object sender, SelectionChangedEventArgs e)
        {
           if (ListBox_.SelectedValue == null)
            {

            }
            else
            {
                tokens = ListBox_.SelectedItem.ToString().Split(separators0, StringSplitOptions.RemoveEmptyEntries);
                //string ordering = tokens[1] + tab + tokens[3] + tab + tokens[5] + tab + tokens[7] + tab + tokens[9] + tab + tokens[11];

                adresseIDTxtBox.Text = tokens[1];
                firstNameTxtBox.Text = tokens[3];
                middleNameTxtBox.Text = tokens[5];
                lastNameTxtBox.Text = tokens[7];
                contextTxtBox.Text = tokens[9];
                genderTxtBox.Text = tokens[11];

               

                personIDtxtBlock.Text = personkartotek_.findPersonIDByName(firstNameTxtBox.Text, lastNameTxtBox.Text).ToString();
            }
          
        }

        //update
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Person personU = new Person();
            personU.personID = int.Parse(personIDtxtBlock.Text);
           

            personU.adresseID = int.Parse(adresseIDTxtBox.Text);
            personU.firstName = firstNameTxtBox.Text;
            personU.middleName = middleNameTxtBox.Text;
            personU.lastName = lastNameTxtBox.Text;
            personU.context = contextTxtBox.Text;
            personU.gender = genderTxtBox.Text;

            personkartotek_.updatePersonDB(ref personU);
            MessageBox.Show("Person was updated");
            getDataInList();
        }
    }
}

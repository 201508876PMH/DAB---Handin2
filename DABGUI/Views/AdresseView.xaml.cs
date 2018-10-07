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
    /// Interaction logic for AdresseView.xaml
    /// </summary>
    public partial class AdresseView : UserControl
    {
        private PersonkartotekDBUtil personkartotek_;
        public AdresseView()
        {
            InitializeComponent();
            personkartotek_ = new PersonkartotekDBUtil();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Adresse> personListfromDB = personkartotek_.getAllAdresseDB();
            ListBox_.Items.Clear();

            foreach (Adresse adresse in personListfromDB)
            {
                ListBox_.Items.Add(adresse);
            }
        }
    }
}

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
    /// Interaction logic for TownView.xaml
    /// </summary>
    public partial class TownView : UserControl
    {
        private PersonkartotekDBUtil personkartotek_;
        public TownView()
        {
            InitializeComponent();
            personkartotek_ = new PersonkartotekDBUtil();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Town> townListDB = personkartotek_.getAlleTownDB();
            ListBox_.Items.Clear();

            foreach (Town t in townListDB)
            {
                ListBox_.Items.Add(t);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Town town = new Town(postNummerTxtBox.Text, townNametxtBox.Text);
                personkartotek_.addTownDB(ref town);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Town allready exist");

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Town town = new Town();
            personkartotek_.deleteTown(ref town);
        }
    }
}

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
using DABGUI.ViewModels;

namespace DABGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PersonViewModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new AdresseViewModel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataContext = new NoteViewModel();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataContext = new EmailViewModel();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataContext = new TelefonnummerViewModel();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DataContext = new TeleselskabViewModel();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DataContext = new TownViewModel();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DataContext = new AAViewModel();
        }
    }
}

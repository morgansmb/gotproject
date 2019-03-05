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

namespace WPFGoT
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OuvreSaisiePerso(object sender, RoutedEventArgs e)
        {
            Characters fenetre = new Characters();
            fenetre.Show();
            this.Close();
        }

        private void OuvreSaisieMaison(object sender, RoutedEventArgs e)
        {
            House fenetre = new House();
            fenetre.Show();
            this.Close();
        }
    }
}

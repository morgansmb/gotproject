using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPFGoT.ViewModels;

namespace WPFGoT
{
    /// <summary>
    /// Logique d'interaction pour House.xaml
    /// </summary>
    public partial class Houses : Window
    {
        public Houses()
        {
            InitializeComponent();
            this.DataContext = new HouseViewModel();
            Loaded += Houses_Loaded;
        }

        private void Houses_Loaded(object sender, RoutedEventArgs e)
        {
            ((HouseViewModel)this.DataContext).Load();
            System.Console.WriteLine("Chargement");
        }

        private void EnregistrementMaison(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Debut");
            ((HouseViewModel)this.DataContext).Save();
        }

        private void SetNom(object sender, KeyboardFocusChangedEventArgs e)
        {
        }

        private void SetNbUnite(object sender, KeyboardFocusChangedEventArgs e)
        {
        }

        private void ExporterMaison(object sender, RoutedEventArgs e)
        {
       
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            this.Close();
        }
    }
}

using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPFGoT.Models;
using WPFGoT.ViewModels;


namespace WPFGoT
{
    /// <summary>
    /// Logique d'interaction pour House.xaml
    /// </summary>
    public partial class House : Window
    {
        public House()
        {
            InitializeComponent();
            this.DataContext = new HouseViewModel();
            Loaded += Houses_Loaded;
        }

        private void Houses_Loaded(object sender, RoutedEventArgs e)
        {
            ((HouseViewModel)this.DataContext).Load();
        }

        private void EnregistrementMaison(object sender, RoutedEventArgs e)
        {
            ((HouseViewModel)DataContext).Save();

        }

        private void ExporterMaison(object sender, RoutedEventArgs e)
        {
            ((HouseViewModel)DataContext).ExportFile();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            this.Close();
        }

        private void SupprimerMaison(object sender, RoutedEventArgs e)
        {
            int idSuppr = ((HouseWPFModel)MaisonsExistantes.SelectedItem).ID;
            ((HouseViewModel)this.DataContext).Delete(idSuppr);
        }

        private void ModificationMaison(object sender, RoutedEventArgs e)
        {
            int idModif = ((HouseWPFModel)MaisonsExistantes.SelectedItem).ID;
            ((HouseViewModel)this.DataContext).Put(idModif);
        }
    }
}

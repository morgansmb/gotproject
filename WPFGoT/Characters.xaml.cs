using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFGoT.ViewModels;

namespace WPFGoT
{
    /// <summary>
    /// Logique d'interaction pour Characters.xaml
    /// </summary>
    public partial class Characters : Window
    {
        public Characters()
        {
            InitializeComponent();
            this.DataContext = new CharacterWPFViewModel();
            Loaded += Houses_Loaded;
            Loaded += Characters_Loaded;
        }

        private void Characters_Loaded(object sender, RoutedEventArgs e)
        {
            ((CharacterWPFViewModel)this.DataContext).LoadCharacters();
        }

        private void Houses_Loaded(object sender, RoutedEventArgs e)
        {
            ((CharacterWPFViewModel)this.DataContext).LoadHouses();
        }

        private void EnregistrementPerso(object sender, RoutedEventArgs e)
        {
            ((CharacterWPFViewModel)this.DataContext).SavePerso();
        }

        private void PersoPresents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void getHouse(object sender, RoutedEventArgs e)
        {
            ((CharacterWPFViewModel)this.DataContext).ChangeHouse(HousesBox.SelectedIndex);
        }

        private void Home(object sender, RoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            this.Close();
        }
    }
}

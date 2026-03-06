using BedrijvenBL.Beheerders;
using BedrijvenBL.Domein;
using BedrijvenBL.DTOs;
using BedrijvenUtil;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BedrijvenWPFAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        string databaseType;
        BedrijfsBeheerder bedrijfsBeheerder;
        public MainWindow()
        {
            InitializeComponent();
            LeesConfig();
            bedrijfsBeheerder = new BedrijfsBeheerder(RepositoryFactory.GeefRepository(databaseType,connectionString));
            DataGridBedrijven.ItemsSource = bedrijfsBeheerder.GeefBedrijfDTOs();
        }

        private void LeesConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();
            connectionString = config.GetConnectionString("SQLServerConnection");           
            databaseType = config.GetSection("AppSettings")["databaseType"];
        }

        private void DataGridBedrijven_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridPersoneel.ItemsSource = bedrijfsBeheerder.GeefPersoneelBedrijf(((BedrijfDTO)DataGridBedrijven.SelectedItem).Naam);
        }

        private void VerwijderPersoneel_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPersoneel.SelectedItem != null)
            {
                bedrijfsBeheerder.VerwijderPersoneel((Personeel)DataGridPersoneel.SelectedItem);
            }
            else
            {
                MessageBox.Show("Verwijder","Niemand Geselecteerd",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
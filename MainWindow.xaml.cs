using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

//USE THIS TO SHOW THE RESULT OF OBJECT IN A LIST VIEW
using System.Collections.ObjectModel;

//USE THIS IMPORT TO SHOW OPEN FILE DIALOG FOR UPLOAD
using Microsoft.Win32;
using System.IO;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DECLARE COMPANY CLASS PARA MAGAMIT SA BUONG CLASS
        private List<Company> companies;

        public MainWindow()
        {
            InitializeComponent();

            List<string> dropdown = new List<string>();
            dropdown.Add("Company Name");
            dropdown.Add("SEC #");
            DropBox.ItemsSource = dropdown;

            //CREATE A LIST OF COMPANIES
            companies = new List<Company>
            {
            //  new Company("Microsoft", "123456789", "01/01/2000", "123456"),
            //  new Company("Google", "987654321", "02/02/2001", "987654"),
            //  new Company("Apple", "456789123", "03/03/2002", "456789"),
            //  new Company("Amazon", "321654987", "04/04/2003", "321654"),
            //  new Company("SSCGI", "329354987", "02/04/2013", "321754"),
            //  new Company("SSS", "311354987", "04/08/2010", "331654"),
            //  new Company("PagIbig", "321554987", "12/21/2015", "921654")

                new Company( "Microsoft", "123456789","123456", "01/01/2000", "Satya Nadella", "None" ),
                new Company( "Google", "987654321", "987654", "02/02/2001", "Sundar Pichai", "None" ),
                new Company( "Apple", "456789123", "456789", "03/03/2002", "Tim Cook", "None" ),
                new Company( "Amazon", "321654987", "321654", "04/04/2003", "Jeff Bezos", "None" ),
                new Company( "SSCGI", "329354987", "321754", "02/04/2013", "Joey Mamaril", "None" ),
                new Company( "SSS", "311354987", "331654", "04/08/2010", "Joey Mamaril", "None" ),
                new Company( "PagIbig", "321554987", "921654", "12/21/2015", "Joey Mamaril", "None" )
            };
        }

        //SEARCH HANDLER
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchType = DropBox.SelectedItem.ToString();
            string searchText = SearchBox.Text;

            //UPDATE VALUE OF SEARCH BASED ON HEADER
            CompanyHeader.Text = "SEARCH: " + searchText;

            //INSTANTIATE THE SEARCH CLASS
            Search search = new Search(searchType, searchText);

            //CALL THE SEARCHCOMPANIES METHOD IN THE SEARCH CLASS
            List<Company> searchResults = search.SearchCompanies(companies);

            //DEBUGGING STATEMENTS

            foreach (var company in searchResults)
            {
                Console.WriteLine($"Company Name: {company.CompanyName}");
                Console.WriteLine($"SEC #: {company.SecNum}");
                Console.WriteLine($"Date Registered: {company.DateRegistered}");
                Console.WriteLine($"License Number: {company.LicenseNumber}");
            }

            //DISPLAY THE SEARCH RESULTS
            SearchResultsListBox.ItemsSource = searchResults;
            //foreach (var company in searchResults)
            //{
            //    Console.WriteLine($"Company Name: {company.CompanyName}");
            //    Console.WriteLine($"SEC #: {company.SecNum}");
            //    Console.WriteLine($"Date Registered: {company.DateRegistered}");
            //    Console.WriteLine($"License Number: {company.LicenseNumber}");
            //}
        }

        //PLACEHOLDER IF CLICK
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Search...")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; // Change text color to normal
            }
        }

        //PLACEHOLDER IF LOSE FOCUS
        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search...";
                textBox.Foreground = Brushes.Gray; // Change text color to placeholder
            }
        }

        //UPLOAD HANDLER
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Excel Files (*.xls, *.xlsx, *.xlsm, *.xlsb, *.xltx)|*.xls;*.xlsx;*.xlsm;*.xlsb;*.xltx";

            if (dialog.ShowDialog() == true)
            {
                string selectedFile = dialog.FileName;
            }
        }
    }
}
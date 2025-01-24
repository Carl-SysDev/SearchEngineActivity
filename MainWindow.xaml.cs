using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

//USE THIS TO SHOW THE RESULT OF OBJECT IN A LIST VIEW
using System.Collections.ObjectModel;

//USE THIS IMPORT TO SHOW OPEN FILE DIALOG FOR UPLOAD
using Microsoft.Win32;
using System.IO;
using OfficeOpenXml;

namespace SearchEngine
{
    public partial class MainWindow : Window
    {
        //PROPERT FOR SEARCH RESULT COUNT
        public string SearchResultCount { get; set; }

        //DECLARE COMPANY CLASS PARA MAGAMIT SA BUONG CLASS
        private List<Company> companies;

        public MainWindow()
        {
            InitializeComponent();

            List<string> dropdown = new List<string>();
            dropdown.Add("Company Name");
            dropdown.Add("SEC #");

            DropBox.ItemsSource = dropdown;

            //GET THE PATH OF UPLODED FILES
            string uploadDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //GET THE EXCEL FILES
            string[] excelFiles = System.IO.Directory.GetFiles(uploadDirectory, "*.xlsx", System.IO.SearchOption.TopDirectoryOnly);

            //SHOWING THE ALL UPLOADED EXCEL FILES IN FILEUPLOADSLISTBOX
            foreach (string file in excelFiles)
            {
                FileUploads.Items.Add(System.IO.Path.GetFileName(file));
            }

            //CREATE A LIST OF COMPANIES
            //companies = new List<Company>
            //{
            //    new Company( "Microsoft", "123456789","123456", "01/01/2000", "Satya Nadella", "None" ),
            //    new Company( "Google", "987654321", "987654", "02/02/2001", "Sundar Pichai", "None" ),
            //    new Company( "Apple", "456789123", "456789", "03/03/2002", "Tim Cook", "None" ),
            //    new Company( "Amazon", "321654987", "321654", "04/04/2003", "Jeff Bezos", "None" ),
            //    new Company( "SSCGI", "329354987", "321754", "02/04/2013", "Joey Mamaril", "None" ),
            //    new Company( "SSS", "311354987", "331654", "04/08/2010", "Ash Ketchum", "None" ),
            //    new Company( "PagIbig", "321554987", "921654", "12/21/2015", "Carl Madriaga", "None" )
            //};
        }

        //SEARCH HANDLER
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchType = DropBox.SelectedItem.ToString();
            string searchText = SearchBox.Text;

            if (companies == null || companies.Count == 0)
            {
                MessageBox.Show("Please upload data set first.", "No Data Uploaded", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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

            //GET HOW MANT SEARCH FOUND AND CONVERT IT TO StrING
            SearchResultCount = searchResults.Count.ToString();

            ResultFound.Text = "RESULTS: " + SearchResultCount;

            //DISPLAY THE SEARCH RESULTS
            SearchResultsListBox.ItemsSource = searchResults;

            //CHECK IF NO RESULT FOUND SHOW TEXTBOX N0 RESULT FOUND
            if (SearchResultsListBox.Items.Count == 0)
            {
                MessageBox.Show("No results found for your search.", "No Results Found", MessageBoxButton.OK, MessageBoxImage.Information);
                //IF NO RESUT FOUND STILL SHOW ALL AVAILABLE COMPANIES
                SearchResultsListBox.ItemsSource = companies;
            }
        }

        //PLACEHOLDER IF CLICK
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Search...")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; //CHANGE TEXT COLOR TO BLACK WHEN USER TYPE
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
            // Set the license context para to sa na install na package
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Excel Files (*.xls, *.xlsx, *.xlsm, *.xlsb, *.xltx)|*.xls;*.xlsx;*.xlsm;*.xlsb;*.xltx";
            dialog.Multiselect = true; //MAKE YOU UPLOAD MORE THAN 1 FILE

            if (dialog.ShowDialog() == true)
            {
                string[] selectedFiles = dialog.FileNames;

                // Get the directory path where the files are uploaded
                string uploadDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                // Read the Excel files and extract data
                foreach (string file in selectedFiles)
                {
                    //COPY THE FILE OR UPLOAD THE FILE IN MY DIRECTORY
                    string fileName = System.IO.Path.GetFileName(file);
                    string destinationPath = System.IO.Path.Combine(uploadDirectory, fileName);
                    System.IO.File.Copy(file, destinationPath, true); // overwrite if file already exists

                    using (var package = new ExcelPackage(destinationPath))
                    {
                        var workbook = package.Workbook;
                        var worksheet = workbook.Worksheets["Sheet1"]; // Replace with the actual sheet name

                        //EXTRACT DATA FROM EXCEL
                        var companies = new List<Company>();
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++) //START FROM ROW 2, ASSUMING ROW 1 IS THE HEADER
                        {
                            var companyName = worksheet.Cells[row, 1].Value.ToString();
                            var secNum = worksheet.Cells[row, 2].Value.ToString();
                            var licenseNumber = worksheet.Cells[row, 3].Value.ToString();
                            var dateRegistered = worksheet.Cells[row, 4].Value.ToString();
                            var taxpayerName = worksheet.Cells[row, 5].Value.ToString();
                            var violation = worksheet.Cells[row, 6].Value.ToString();

                            companies.Add(new Company(companyName, secNum, licenseNumber, dateRegistered, taxpayerName, violation));
                        }

                        //PASS THE EXTRACTED DATA TO THE GLOBAL COMPANIES LIST
                        this.companies = companies;

                        //DISPLAY ALL COMPANY NAMES IN SEARCH LISTBOX
                        SearchResultsListBox.ItemsSource = companies;
                    }

                    //SHOW ALL UPLOADED FILES IN UPLOADS LISTBOX
                    FileUploads.Items.Add(fileName);
                }
            }
        }

        //DISPLAY THE SELECTED FILE'S DATA IN SEARCHRESULTSLISTBOX
        private void FileUploads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FileUploads.SelectedItem != null)
            {
                string selectedFile = FileUploads.SelectedItem.ToString();

                // Get the directory path where the files are uploaded
                string uploadDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                // Construct the full path of the selected file
                string filePath = System.IO.Path.Combine(uploadDirectory, selectedFile);

                // Read the Excel file and extract data
                using (var package = new ExcelPackage(filePath))
                {
                    // Set the license context para to sa na install na package
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets["Sheet1"]; // Replace with the actual sheet name

                    //EXTRACT DATA FROM EXCEL
                    var companies = new List<Company>();
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) //START FROM ROW 2, ASSUMING ROW 1 IS THE HEADER
                    {
                        var companyName = worksheet.Cells[row, 1].Value.ToString();
                        var secNum = worksheet.Cells[row, 2].Value.ToString();
                        var licenseNumber = worksheet.Cells[row, 3].Value.ToString();
                        var dateRegistered = worksheet.Cells[row, 4].Value.ToString();
                        var taxpayerName = worksheet.Cells[row, 5].Value.ToString();
                        var violation = worksheet.Cells[row, 6].Value.ToString();

                        companies.Add(new Company(companyName, secNum, licenseNumber, dateRegistered, taxpayerName, violation));
                    }
                    this.companies = companies;
                    //DISPLAY THE EXTRACTED DATA IN SEARCHRESULTSLISTBOX
                    SearchResultsListBox.ItemsSource = companies;
                }
            }
        }

        //private void UploadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Set the license context para to sa na install na package
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    var dialog = new Microsoft.Win32.OpenFileDialog();
        //    dialog.Filter = "Excel Files (*.xls, *.xlsx, *.xlsm, *.xlsb, *.xltx)|*.xls;*.xlsx;*.xlsm;*.xlsb;*.xltx";

        //    if (dialog.ShowDialog() == true)
        //    {
        //        string selectedFile = dialog.FileName;

        //        // Read the Excel file
        //        using (var package = new ExcelPackage(selectedFile))
        //        {
        //            var workbook = package.Workbook;
        //            var worksheet = workbook.Worksheets["Sheet1"]; // Replace with the actual sheet name

        //            // Extract data from the worksheet
        //            var companies = new List<Company>();
        //            for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2, assuming row 1 is the header
        //            {
        //                var companyName = worksheet.Cells[row, 1].Value.ToString();
        //                var secNum = worksheet.Cells[row, 2].Value.ToString();
        //                var licenseNumber = worksheet.Cells[row, 3].Value.ToString();
        //                var dateRegistered = worksheet.Cells[row, 4].Value.ToString();
        //                var taxpayerName = worksheet.Cells[row, 5].Value.ToString();
        //                var violation = worksheet.Cells[row, 6].Value.ToString();

        //                companies.Add(new Company(companyName, secNum, licenseNumber, dateRegistered, taxpayerName, violation));
        //            }

        //            // Use the extracted data as needed
        //            this.companies = companies;

        //            // Display all companies in the SearchResultsListBox
        //            SearchResultsListBox.ItemsSource = companies;
        //            //SearchResultsListBox.DisplayMemberPath = "CompanyName"; // Optional: display company name as the text
        //        }
        //    }
        //}

        //DISPLAY THE SELECTED COMPANY ON RESULTS AND SHOW INDIVIDUAL INFO
        private void SearchResultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchResultsListBox.SelectedItem != null)
            {
                Company selectedCompany = (Company)SearchResultsListBox.SelectedItem;

                CompanyName.Text = selectedCompany.CompanyName;
                SecNum.Text = selectedCompany.SecNum;
                LicenseNumber.Text = selectedCompany.LicenseNumber;
                DateRegistered.Text = selectedCompany.DateRegistered;
                TaxPayerName.Text = selectedCompany.TaxpayerName;
                Violations.Text = selectedCompany.Violation;

                // Make the textboxes read-only
                CompanyName.IsReadOnly = true;
                SecNum.IsReadOnly = true;
                LicenseNumber.IsReadOnly = true;
                DateRegistered.IsReadOnly = true;
                TaxPayerName.IsReadOnly = true;
                Violations.IsReadOnly = true;
            }
        }
    }
}
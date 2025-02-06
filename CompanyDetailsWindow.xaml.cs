using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for CompanyDetailsWindow.xaml
    /// </summary>
    public partial class CompanyDetailsWindow : Window
    {
        public CompanyDetailsWindow(Company company)
        {
            InitializeComponent();
            DataContext = company;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the company details from the data context
            Company company = (Company)DataContext;

            if (company != null)
            {
                // OPEN DIALOG TO LET USER CHOOSE FOLDER TO SAVE PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Generated Report - {company.CompanyName}.pdf";
                saveFileDialog.DefaultExt = ".pdf";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string pdfFileName = saveFileDialog.FileName;

                    // USE iText7 TO CREATE THE PDF
                    using (PdfWriter writer = new PdfWriter(pdfFileName))
                    {
                        PdfDocument pdfDoc = new PdfDocument(writer);
                        Document doc = new Document(pdfDoc);

                        //CUSTOM COLORS
                        Color myColor = WebColors.GetRGBColor("BLACK");
                        Color myColor2 = WebColors.GetRGBColor("#f2f0ef");

                        // ADD THE CURRENT DATE AND TIME
                        Paragraph dateTime = new Paragraph($"Report generated on: {DateTime.Now}")
                            .SetFontSize(10)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);

                        doc.Add(dateTime);

                        // CREATE A HEADER WITH BORDER AND DESIGN
                        Paragraph header = new Paragraph("COMPANY INFORMATION REPORT")
                            .SetFontSize(25)
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                        doc.Add(header);

                        // ADD A LINE TO SEPARATE THE HEADER FROM THE CONTENT
                        doc.Add(new LineSeparator(new SolidLine())
                            .SetMarginTop(5)
                            .SetMarginBottom(10));

                        ;

                        // PRINT THE INFOS IN THE PDF WITH DESIGN
                        //doc.Add(new Paragraph($"   COMPANY NAME").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(1).SetMargin(0));
                        doc.Add(new Paragraph($"   Company Name: {company.CompanyName}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // doc.Add(new Paragraph($"   SEC NUMBER").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(1).SetMargin(0));
                        doc.Add(new Paragraph($"   Sec Number: {company.SecNum}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // doc.Add(new Paragraph($"   LICENSE NUMBER").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(1).SetMargin(0));
                        doc.Add(new Paragraph($"   License Number: {company.LicenseNumber}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // doc.Add(new Paragraph($"   DATE REGISTERED").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(1).SetMargin(0));
                        doc.Add(new Paragraph($"   Date Registered: {company.DateRegistered}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // doc.Add(new Paragraph($"   TAX PAYER'S NAME").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(1).SetMargin(0));
                        doc.Add(new Paragraph($"   Tax Payer's Name: {company.TaxpayerName}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // doc.Add(new Paragraph($"   VIOLATIONS").SetFontSize(15).SetFontColor(ColorConstants.BLACK).SetBold().SetPadding(5).SetMargin(0));
                        doc.Add(new Paragraph($"   Violations: {company.Violation}").SetFontSize(12).SetPadding(1).SetMargin(0));
                        // ADD A LINE TO SEPARATE THE HEADER FROM THE CONTENT
                        doc.Add(new LineSeparator(new SolidLine())
                            .SetMarginTop(10)
                            .SetMarginBottom(5));

                        doc.Close();
                    }

                    MessageBox.Show("Report generated successfully!", "Generate Report", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
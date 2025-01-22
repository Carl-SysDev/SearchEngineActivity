using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string SecNum { get; set; }
        public string DateRegistered { get; set; }
        public string LicenseNumber { get; set; }
        //public string TaxpayerName { get; set; }
        //public string? Vioalion { get; set; }

        public Company(string companyName, string secNum, string dateRegistered, string licenseNumber)
        {
            CompanyName = companyName;
            SecNum = secNum;
            DateRegistered = dateRegistered;
            LicenseNumber = licenseNumber;
            //TaxpayerName = taxpayerName;
            //Vioalion = vioalion;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    internal class Search
    {
        public string SearchType { get; set; }
        public string SearchText { get; set; }

        public Search(string searchType, string searchText)
        {
            SearchType = searchType;
            SearchText = searchText;
        }

        public List<Company> SearchCompanies(List<Company> companies)
        {
            List<Company> searchResults = new List<Company>();

            switch (SearchType)
            {
                case "Company Name":
                    searchResults = companies.Where(c => c.CompanyName.Contains(SearchText)).ToList();
                    break;

                case "SEC #":
                    searchResults = companies.Where(c => c.SecNum.Contains(SearchText)).ToList();
                    break;

                default:
                    break;
            }

            return searchResults;
        }
    }
}
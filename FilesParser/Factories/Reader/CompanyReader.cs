using FilesParser.Data;
using Newtonsoft.Json;

namespace FilesParser.Factories.Reader
{
    public class CompanyReader
    {
        private readonly ICompanyParser _parser;

        public CompanyReader(ICompanyParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<Dictionary<string, string>> Read(string filePath, IList<string> fieldNames)
        {
            List<Dictionary<string, string>> companies = new();
            using (StreamReader reader = new(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Dictionary<string, string> company = _parser.Parse(line, fieldNames);
                    companies.Add(company);
                }
                   
            }
            return companies;
        }
                    
    }
    }

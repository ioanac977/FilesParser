using FilesParser.Data;
using FilesParser.Factories.Creation;
using System.IO.Abstractions;

namespace FilesParser.Factories.Reader
{
    public class CompanyReader : ICompanyReader
    {
        private readonly ICompanyParserFactory _companyParserFactory;
        private readonly IFileSystem _fileSystem;
        private ICompanyParser _companyParser;

        public CompanyReader(ICompanyParserFactory companyParserFactory, IFileSystem fileSystem)
        {
            _companyParserFactory = companyParserFactory;
            _fileSystem = fileSystem;
        }

        public CompanyReader WithDelimiter(char delimiter)
        {
            _companyParser = _companyParserFactory.CreateParser(delimiter);
            return this;

        }

        public IEnumerable<Dictionary<string, string>> Read(string filePath, IList<string> fieldNames)
        {

            List<Dictionary<string, string>> companies = new();
            if (_fileSystem.File.Exists(filePath))
            {
                using StreamReader reader = new(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Dictionary<string, string> company = _companyParser.Parse(line, fieldNames);
                    companies.Add(company);
                }
            }
            return companies;
        }
    }
}

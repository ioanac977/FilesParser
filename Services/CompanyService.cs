using FilesParser.Demo;
using FilesParser.Factories.Reader;

namespace FilesParser.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyReader _companyReader;

        public CompanyService(ICompanyReader companyReader)
        {
            _companyReader = companyReader;
        }

        public List<Dictionary<string, string>> ReadCompaniesFromFiles()
        {
            List<Dictionary<string, string>> companies = new();

            var commaCompanies = _companyReader.WithDelimiter(',').Read(DemoConstants.commaDelimitedFilePath, DemoConstants.columnsForCommaDelimiter);
            var hashCompanies = _companyReader.WithDelimiter('#').Read(DemoConstants.hashDelimitedFilePath, DemoConstants.columnsForHashDelimiter);
            var hyphenCompanies = _companyReader.WithDelimiter('-').Read(DemoConstants.hyphenDelimitedFilePath, DemoConstants.columnsForHyphenDelimiter);

            companies.AddRange(commaCompanies);
            companies.AddRange(hashCompanies);
            companies.AddRange(hyphenCompanies);

            return companies;
        }
    }
}

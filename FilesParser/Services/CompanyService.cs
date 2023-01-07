using FilesParser.Data;
using FilesParser.Factories.Creation;
using FilesParser.Factories.Reader;

namespace FilesParser.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyParserFactory  _parserFactory;

        public CompanyService(ICompanyParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public List<Dictionary<string, string>> ReadCompaniesFromFiles()
        {
            List<Dictionary<string, string>> companies = new();

            var commaCompanies = new CompanyReader(_parserFactory.CreateParser(',')).Read("comma.txt", Config.columnsForFilesWithCommaDelimiter);
            var hashCompanies = new CompanyReader(_parserFactory.CreateParser('#')).Read("hash.txt", Config.columnsForFilesWithHashDelimiter);
            var hyphenCompanies = new CompanyReader(_parserFactory.CreateParser('-')).Read("hyphen.txt", Config.columnsForFilesWithHyphenDelimiter);

            companies.AddRange(commaCompanies);
            companies.AddRange(hashCompanies);
            companies.AddRange(hyphenCompanies);

            return companies;
        }
    }
}

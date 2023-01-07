using FilesParser.Data;

namespace FilesParser.Factories.Creation
{
    public class CompanyParserFactory : ICompanyParserFactory
    {
        public ICompanyParser CreateParser(char delimiter)
        {
            return delimiter switch
            {
                ',' => new CommaCompanyParser(),
                '#' => new HashCompanyParser(),
                '-' => new HyphenCompanyParser(),
                _ => throw new ArgumentException("Invalid delimiter specified."),
            };
        }

    }
}
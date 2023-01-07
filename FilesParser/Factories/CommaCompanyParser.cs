using FilesParser.Data;
using FilesParser.Factories.Reader;

namespace FilesParser.Factories
{
    public class CommaCompanyParser : DelimitedCompanyParser
    {
        protected override char GetDelimiter() => ',';
    
    }
}
using FilesParser.Data;
using FilesParser.Factories.Reader;

namespace FilesParser.Factories
{
    public class CommaCompanyParser : BaseCompanyParser
    {
        public CommaCompanyParser(char delimiter)
        {
            Delimiter = delimiter;
        }
    }
}
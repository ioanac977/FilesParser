using FilesParser.Data;

namespace FilesParser.Factories.Creation
{
    public interface ICompanyParserFactory
    {
        ICompanyParser CreateParser(char delimiter);
    }
}

using FilesParser.Data;

namespace FilesParser.Services
{
    public interface ICompanyService
    {
        List<Dictionary<string, string>> ReadCompaniesFromFiles();
    }

}

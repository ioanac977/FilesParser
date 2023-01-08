using FilesParser.Data;
using FilesParser.Factories.Reader;
using System;

namespace FilesParser.Factories
{
    public class HashCompanyParser : BaseCompanyParser
    {
        public HashCompanyParser(char delimiter)
        {
            Delimiter = delimiter;
        }
    }
}
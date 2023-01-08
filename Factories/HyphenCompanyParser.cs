using FilesParser.Data;
using FilesParser.Factories.Reader;
using System;

namespace FilesParser.Factories
{
    public class HyphenCompanyParser : BaseCompanyParser
    {
        public HyphenCompanyParser(char delimiter)
        {
            Delimiter = delimiter;
        }
    }
}
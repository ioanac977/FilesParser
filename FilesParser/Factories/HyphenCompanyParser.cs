using FilesParser.Data;
using FilesParser.Factories.Reader;
using System;

namespace FilesParser.Factories
{
    public class HyphenCompanyParser : DelimitedCompanyParser
    {
        protected override char GetDelimiter()
        {
            return '-';
        }
    }
}
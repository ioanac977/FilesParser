namespace FilesParser.Demo
{
    public static class DemoConstants
    {
        public static readonly IList<string> columnsForCommaDelimiter = new List<string>
        {
            "Company Name",
            "Contact Name",
            "Contact Phone Number",
            "Years in Business",
            "Contact Email"
        };
        public static readonly IList<string> columnsForHashDelimiter = new List<string>
        {
            "Company Name",
            "Year Founded",
            "Contact Name",
            "Contact Phone Number"
        };
        public static readonly IList<string> columnsForHyphenDelimiter = new List<string>
        {
            "Company Name",
            "Year Founded",
            "Contact Phone Number",
            "Contact Email",
            "Contact First Name",
            "Contact Last Name"
        };

        public static readonly string commaDelimitedFilePath = "./Demo/Files/comma.txt";
        public static readonly string hashDelimitedFilePath = "./Demo/Files/hash.txt";
        public static readonly string hyphenDelimitedFilePath = "./Demo/Files/hyphen.txt";
    }
}

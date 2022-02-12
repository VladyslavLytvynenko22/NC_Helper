namespace ConsoleApp1
{
    public static class DBClasToCSharpClass
    {
        private static string editText = string.Empty;

        public static string ConvertDBClasToCSharpClass(string edtText)
        {
            editText = edtText;

            var temp = editText.Split("\r\n");

            foreach (var item in temp)
            {
                ReplaceText(item);
            }

            return editText;
        }

        private static void ReplaceText(string text)
        {

            var d = text.Trim().Replace("[", "").Replace("]", "").Split(new[] { ' ' });

            string type = GetType(d);
            string name = d[0];

            var origin = text.Contains("NOT NULL") ? "[Required]\r\n" : string.Empty;
            origin += $"public {type} {name}" + " { get; set; }";

            editText = editText.Replace(text, origin);
        }

        private static string GetType(string[] text)
        {
            string type;
            var tempType = text[1];
            int indexOfBr = tempType.IndexOf('(');

            if (indexOfBr > 0)
            {
                tempType = tempType.Substring(0, tempType.IndexOf('('));
            }

            if (text.Length == 3)//null type
            {
                type = ReplaceType(tempType, "?");
            }
            else
            {
                type = ReplaceType(tempType);
            }

            return type;
        }

        private static string ReplaceType(string type, string additionalSymbol = null)
        {
            switch (type)
            {
                case "bigint":
                    return "long" + additionalSymbol;
                case "binary":
                    return "byte[]" + additionalSymbol;
                case "bit":
                    return "bool" + additionalSymbol;
                case "char": return "string";
                case "date": return "DateTime" + additionalSymbol;
                case "datetime": return "DateTime" + additionalSymbol;
                case "datetime2": return "DateTime" + additionalSymbol;
                case "datetimeoffset": return "DateTimeOffset" + additionalSymbol;
                case "decimal": return "decimal" + additionalSymbol;
                case "float": return "float" + additionalSymbol;
                case "image": return "byte[]" + additionalSymbol;
                case "int": return "int" + additionalSymbol;
                case "money": return "decimal" + additionalSymbol;
                case "nchar": return "string";
                case "ntext": return "string";
                case "numeric": return "decimal" + additionalSymbol;
                case "nvarchar": return "string";
                case "real": return "double" + additionalSymbol;
                case "smalldatetime": return "DateTime" + additionalSymbol;
                case "smallint": return "short" + additionalSymbol;
                case "smallmoney": return "decimal" + additionalSymbol;
                case "text": return "string";
                case "time": return "TimeSpan" + additionalSymbol;
                case "timestamp": return "timestamp" + additionalSymbol;
                case "rowversion": return "byte[]" + additionalSymbol;
                case "tinyint": return "byte" + additionalSymbol;
                case "uniqueidentifier": return "Guid" + additionalSymbol;
                case "varbinary": return "byte[]" + additionalSymbol;
                case "varchar": return "string";
                default:
                    break;
            }

            return null;
        }
    }
}

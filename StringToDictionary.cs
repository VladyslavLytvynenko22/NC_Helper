using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class StringToDictionary
    {
        private static string editText = string.Empty;

        public static string ConvertStringToDictionary(string edText)
        {
            editText = edText;

            var res = Convert();

            WriteDictionaryToTextFileProperty(res);

            return editText;
        }

        private static Dictionary<string, string> Convert()
        {
            Dictionary<string, string> result = null;

            if (!string.IsNullOrWhiteSpace(editText))
            {
                result = new Dictionary<string, string>();

                var splitedText = editText
                    .Replace(" ", string.Empty)
                    .Replace("{", string.Empty)
                    .Replace("}", string.Empty)
                    .Replace("'", string.Empty)
                    .Replace("\"", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("\t", string.Empty)
                    .Split(',', System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in splitedText)
                {
                    var keyValue = item.Split(':');

                    try
                    {
                        result.Add(keyValue[0], keyValue[1]);
                    }
                    catch (System.Exception)
                    {
                        result.Remove(keyValue[0]);

                        result.Add(keyValue[0], keyValue[1]);
                    }

                }
            }

            return result;

        }

        private static void WriteDictionaryToTextFileProperty(Dictionary<string, string> res)
        {
            editText = "new Dictionary<string, string>()\r\n{\r\n" + string.Join(",\r\n", res.Select(x => "{\"" + x.Key + "\", \"" + x.Value + "\"}")) + "\r\n}";
        }
    }
}

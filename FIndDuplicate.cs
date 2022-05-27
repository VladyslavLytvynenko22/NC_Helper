using System;
using System.Text.RegularExpressions;

namespace NC_Helper
{
    public static class FIndDuplicate
    {
        private static string secretKey = "TopSecretPassword!!!!!!!!..........!!!!! !!!.....";

        public static string Find(string edtText)
        {
            var splitedByRows = edtText.Split("\r\n");

            //var secretKeyRegexEscape = Regex.Escape(secretKey);

            foreach (var row in splitedByRows)
            {
                if (row.Contains("IronPdfHelper.SetObjectToFieldValue(_formDocument.Form, AcordFormFields."))
                {
                    var rex = new Regex(Regex.Escape(row));

                    edtText = rex.Replace(edtText, secretKey, 1);

                    edtText = rex.Replace(edtText, "");

                    rex = new Regex(secretKey);

                    edtText = rex.Replace(edtText, row, 1);
                }
            }

            return edtText;
        }

        public static void FingWithConsole()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter text and Ctrl+z or type exit: ");

                var val = Console.In.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(val))
                {
                    if (val == "exit")
                    {
                        break;
                    }

                    var resString = Find(val);

                    Console.WriteLine(resString);

                    TextCopy.ClipboardService.SetText(resString);
                }
            }
        }
    }
}

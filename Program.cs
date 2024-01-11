using NC_Helper;
using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        private const string EDIT_FILE = "EditFile.txt";
        private const string EDITED_FILE = "EditedFile.txt";
        private static string editText = string.Empty;

        private enum HelperTypes
        {
            replace_string_to_constants_by_console_typing,
            replace_string_to_constants,
            replace_old_code_to_new_code,
            Convert_DB_Class_To_CSharp_Class,
            Convert_string_to_dictionary,
            Replace_string_to_string,
            Find_duplicate,
            Find_duplicate_by_console,
            Add_Description_To_The_Class_Fields,
            RazorConversor,
        }

        static void Main(string[] args)
        {
            var s = HelperTypes.Convert_DB_Class_To_CSharp_Class;

            switch (s)
            {
                case HelperTypes.replace_string_to_constants_by_console_typing:
                    // replace string to constants by console typing
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter text: ");

                        var val = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(val))
                        {
                            if (val == "exit")
                            {
                                break;
                            }

                            var name = ReplaceStringToConstants.CreatePropertyName(val);

                            name = char.ToUpper(name[0]) + name.Substring(1);

                            var result = $"public const string {name} = \"{val}\";";

                            Console.WriteLine(result);

                            TextCopy.ClipboardService.SetText(result);
                        }
                    }
                    break;
                case HelperTypes.replace_string_to_constants:
                    // replace string to constants
                    ReadEditFile();

                    editText = ReplaceStringToConstants.EditText(editText);

                    WriteEditFile();
                    break;
                case HelperTypes.replace_old_code_to_new_code:
                    //replace old code to new code
                    ReadEditFile();

                    editText = Replace_code.EditText_Code(editText);

                    WriteEditFile();
                    break;
                case HelperTypes.Convert_DB_Class_To_CSharp_Class:
                    // Convert DB Class To CSharp Class
                    DBClasToCSharpClass.ConvertDBClasToCSharpClass();

                    break;
                case HelperTypes.Convert_string_to_dictionary:
                    // Convert string to dictionary
                    ReadEditFile();

                    editText = StringToDictionary.ConvertStringToDictionary(editText);

                    WriteEditFile();
                    break;
                case HelperTypes.Replace_string_to_string:
                    // Replace string to string
                    ReplaceStringToString.Replace(");");
                    break;
                case HelperTypes.Find_duplicate:
                    // Find duplicate
                    ReadEditFile();

                    editText = FindDuplicate.Find(editText);

                    WriteEditFile();
                    break;
                case HelperTypes.Find_duplicate_by_console:
                    // Find duplicate by console
                    FindDuplicate.FingWithConsole();
                    break;
                case HelperTypes.Add_Description_To_The_Class_Fields:
                    // Find duplicate by console
                    AddDescriptionToTheClassFields.SetDescription();
                    break;
                case HelperTypes.RazorConversor:
                    // Find duplicate by console
                    RazorConversor.ConvertAll("C:\\Projects\\nowcerts-web-app\\NowCerts.Sandbox\\bin\\Helpers\\IronPDFViews");
                    break;
                default:
                    break;
            }

        }

        private static void ReadEditFile()
        {
            if (File.Exists(EDIT_FILE))
            {
                using (StreamReader sr = File.OpenText(EDIT_FILE))
                {
                    editText = sr.ReadToEnd();
                }
            }
        }

        private static void WriteEditFile()
        {
            using (FileStream fs = File.Create(EDITED_FILE))
            {
                byte[] textByte = new UTF8Encoding(true).GetBytes(editText);

                fs.Write(textByte, 0, textByte.Length);
            }
        }
    }
}

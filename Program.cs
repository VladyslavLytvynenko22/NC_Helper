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

        static void Main(string[] args)
        {
            var sw = 2;

            switch (sw)
            {
                case 1:
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
                case 2:
                    // replace string to constants
                    ReadEditFile();

                    editText = ReplaceStringToConstants.EditText(editText);

                    WriteEditFile();
                    break;
                case 3:
                    //replace old code to new code
                    ReadEditFile();

                    editText = Replace_code.EditText_Code(editText);

                    WriteEditFile();
                    break;
                case 4:
                    // Convert DB Class To CSharp Class
                    ReadEditFile();

                    editText = DBClasToCSharpClass.ConvertDBClasToCSharpClass(editText);

                    WriteEditFile();
                    break;
                case 5:
                    // Convert string to dictionary
                    ReadEditFile();

                    editText = StringToDictionary.ConvertStringToDictionary(editText);

                    WriteEditFile();
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

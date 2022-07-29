using NowCerts.Domain.Constants.AcordFormFields;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class ReplaceStringToConstants
    {
        //private  string editText = string.Empty;
        private const string CONSTANTS_FILE = "ConstantsFile.txt";
        private static readonly Dictionary<string, string> newProperties = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> properties = new Dictionary<string, string>();
        private const string AcordFormFieldsConst = "AcordFormFields.";

        private static string secretKey = "TopSecretPassword!!!!!!!!..........!!!!! !!!.....";
        public static string EditText(string edText)
        {
            GetConstants();

            var reg = new Regex[]
            {
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P1\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\.P[0-9]+_0__\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[0-9]+_\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\.P[0-9]+_[0-9]+_\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]_Page[0-9]+\\[[0-9]+]_F_[0-9]+_\\\\\\\\_P[0-9]+_[0-9]+_\\\\\\\\_([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]_Page[0-9]+\\[[0-9]+]_F_[0-9]+_\\\\\\\\\\\\\\\\_P[0-9]+_[0-9]+_\\\\\\\\\\\\\\\\_([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.FIELD[0-9]+\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)_\\{[0-9]+\\}\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),
                new Regex("\"F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)_\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_\"", RegexOptions.IgnoreCase),
                new Regex("\"topmostSubform\\[[0-9]+]\\.[a-zA-Z]+[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]\"", RegexOptions.IgnoreCase),
                new Regex("\\{\"(?:[^\"]|\"\")*\",", RegexOptions.IgnoreCase),
                new Regex("AcordFormFieldDto\\(\"(?:[^\"]|\"\")*\",", RegexOptions.IgnoreCase),

                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P1\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\.P[0-9]+_0__\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[0-9]+_\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\.P[0-9]+_[0-9]+_\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]_Page[0-9]+\\[[0-9]+]_F_[0-9]+_\\\\\\\\_P[0-9]+_[0-9]+_\\\\\\\\_([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]_Page[0-9]+\\[[0-9]+]_F_[0-9]+_\\\\\\\\\\\\\\\\_P[0-9]+_[0-9]+_\\\\\\\\\\\\\\\\_([a-zA-Z]+(_[a-zA-Z]+)+)\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.FIELD[0-9]+\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)_\\{[0-9]+\\}", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.[a-zA-Z]+_[a-zA-Z]+_", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),
                new Regex("F\\[[0-9]+]\\.P[0-9]+\\[[0-9]+]\\.([a-zA-Z]+(_[a-zA-Z]+)+)_\"", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.Page[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_", RegexOptions.IgnoreCase),
                new Regex("topmostSubform\\[[0-9]+]\\.[a-zA-Z]+[0-9]+\\[[0-9]+]\\.F_[0-9]+_\\\\\\\\\\.P[0-9]+_[0-9]+_\\\\\\\\\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\[[0-9]+]", RegexOptions.IgnoreCase),
                new Regex("\"[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),
                new Regex("\"[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),
                new Regex("\"F_0_P[0-9]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)_\"", RegexOptions.IgnoreCase),
                new Regex("\"F_0_P[0-9]+_0_[a-zA-Z]+__[a-zA-Z]+_[a-zA-Z]+_\"", RegexOptions.IgnoreCase),

                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z],", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.F_0_P[0-9]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.F_0_P[0-9]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)+,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.F_0_P[0-9]+_0_[a-zA-Z]+__[a-zA-Z]+_[a-zA-Z]+_,", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_\\s\\+", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_\\s\\+", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.F_0_P[0-9]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)_\\s\\+", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.F_0_P[0-9]+_0_[a-zA-Z]+__[a-zA-Z]+_[a-zA-Z]+_\\s\\+", RegexOptions.IgnoreCase),

            };

            edText = Checking(reg, edText);

            var rex = new Regex(secretKey);

            edText = rex.Replace(edText, AcordFormFieldsConst);

            WriteConstants();

            return edText;
        }

        public static string Checking(Regex[] reg, string edText)
        {
            foreach (var item in reg)
            {
                edText = CheckRegex(item, edText);
            }

            return edText;
        }

        private static string CheckRegex(Regex regex, string editText)
        {
            if (regex.IsMatch(editText))
            {
                do
                {
                    var grp = regex.Match(editText)?.Groups;

                    if (grp != null && grp.Count > 0 && !string.IsNullOrWhiteSpace(grp[0].Value))
                    {
                        var text = grp[0].Value;

                        text = text
                            .Replace("{", "")
                            .Replace(",", "")
                            .Replace(" +", "")
                            .Replace("AcordFormFieldDto(", "");

                        var constValue = text
                            .Replace("\"", "")
                            .Replace(AcordFormFieldsConst, "")
                            .Replace(" +", "")
                            .Replace(",", "");

                        if (constValue.StartsWith("F_0_P"))
                        {
                            constValue = $"F[0].P{constValue[5]}[{constValue[7]}]." + constValue.Substring(9);
                        }

                        editText = ReplaceText(text, constValue, editText);
                    }

                } while (regex.IsMatch(editText));
            }

            return editText;
        }

        private static string ReplaceText(string replaceText, string constValue, string editText)
        {
            var propertyName = GetPropertyName(constValue);

            return editText.Replace(replaceText, secretKey + propertyName);
        }

        private static string GetPropertyName(string replaceTexts)
        {
            if (!properties.ContainsKey(replaceTexts))
            {
                var propName = CreatePropertyName(replaceTexts);
                properties.Add(replaceTexts, propName);
                newProperties.Add(replaceTexts, propName);
            }

            if (properties.TryGetValue(replaceTexts, out string propertyName))
            {
                return propertyName;
            }

            return null;
        }

        private static void GetConstants()
        {
            foreach (FieldInfo field in typeof(AcordFormFields).GetFields())
            {
                var name = field.Name;
                var value = field.GetValue(null).ToString();

                properties.Add(value, name);
            }
        }

        private static void WriteConstantsFile(string constants)
        {
            using (FileStream fs = File.Create(CONSTANTS_FILE))
            {
                byte[] textByte = new UTF8Encoding(true).GetBytes(constants);

                fs.Write(textByte, 0, textByte.Length);
            }
        }

        private static void WriteConstants()
        {
            var constantsStrinmg = string.Join("\n", newProperties.Select(x => $"public const string {x.Value} = \"{x.Key}\";"));

            WriteConstantsFile(constantsStrinmg);
        }


        public static string CreatePropertyName(string propertyValue)
        {
            if (!string.IsNullOrWhiteSpace(propertyValue))
            {
                var name = propertyValue

                    .Replace("_\\\\_", "_")
                    .Replace("_\\\\.", "_")
                    .Replace("\\\\_", "_")
                    .Replace("\\\\.", "_")
                    .Replace("\\\\", "_")
                    .Replace("_\\\\_", "_")
                    .Replace("_\\.", "_")
                    .Replace("\\_", "_")
                    .Replace("\\.", "_")
                    .Replace("\\", "_")
                    .Replace("].", "_")
                    .Replace("]", "_")
                    .Replace("[", "_")
                    .Replace("{0}", "_")
                    .Replace("{1}", "_")
                    .Replace("{2}", "_")
                    .Replace(".", "_")
                    ;

                name = char.ToUpper(name[0]) + name[1..];

                return name;
            }
            else
            {
                return null;
            }
        }
    }
}

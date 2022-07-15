using System;
using System.Text.RegularExpressions;

namespace NC_Helper
{
    public static class AddDescriptionToTheClassFields
    {
        private const string DESCRIPTION = "[Description(\"{0}\")]";

        public static void SetDescription()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter text and Ctrl+z or type exit: ");
                // field format should be -> 
                // public const string residentialStructure_PlumbingCondition_KnownLeaksCode = null;
                // it takes name and put it to the [Description("Residential Structure Plumbing Condition Known Leaks Code")]

                var val = Console.In.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(val))
                {
                    if (val == "exit")
                    {
                        break;
                    }

                    var resString = SetDesc(val);

                    Console.WriteLine(resString);

                    TextCopy.ClipboardService.SetText(resString);
                }
            }
        }

        private static string SetDesc(string text)
        {
            var textRows = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in textRows)
            {
                var textWords = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var fieldName = textWords[3];

                fieldName = CleenString(fieldName);

                var splitedByWords = string.Join(" ", Regex.Split(fieldName, @"(?<!^)(?=[A-Z]| )"));

                var descript = string.Format(DESCRIPTION, splitedByWords);

                text = text.Replace(item, descript + Environment.NewLine + item);
            }

            return text;
        }

        private static string CleenString(string str)
        {

            str = str
                .Replace("F_s_b_0_e_b__dot_P2_s_b_0_e_b__dot_", string.Empty)
                .Replace("F_s_b_0_e_b__dot_P1_s_b_0_e_b__dot_", string.Empty)
                .Replace("Fsb_0_eb_dt_P1sb_0_eb_dt_", string.Empty)
                .Replace("Fsb_0_eb_dt_P2sb_0_eb_dt_", string.Empty)
                .Replace("_Asb_0_eb", string.Empty)
                .Replace("_Bsb_0_eb", string.Empty)
                .Replace("_Csb_0_eb", string.Empty)
                .Replace("_Dsb_0_eb", string.Empty)
                .Replace("_Esb_0_eb", string.Empty)
                .Replace("_Bsb_0_eb", string.Empty)
                .Replace("_A_s_b_0_e_b_", string.Empty)
                .Replace("_B_s_b_0_e_b_", string.Empty)
                .Replace("_C_s_b_0_e_b_", string.Empty)
                .Replace("_D_s_b_0_e_b_", string.Empty)
                .Replace("_E_s_b_0_e_b_", string.Empty)
                .Replace("_F_s_b_0_e_b_", string.Empty)
                .Replace("_", string.Empty)
                ;

            return str;
        }
    }
}

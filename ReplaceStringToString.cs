using System;
using System.Text.RegularExpressions;

namespace NC_Helper
{
    public static class ReplaceStringToString
    {
        private static string secretKey = $@"J_!Z^1+]=$vV?D .$=julo?f]QL+p=32D||Ks2 =, @Z'=gT5yMMGO0+tFGJ~-O41[Yv?<cZ*ua^QKuz0M%   9ZhW&*%r@2s/8vQBI|Rhe(Gc$YbC&&sHs<YM6X[-7xv *|XbR]UfyMd-d?12O'^oq3:.f1=E4=SRn1@<&^`n@G5fLYQK  N8t;`X=[MdaSL39-$>_,!@s8u&Sm't*%Ev,\hKF ZKEo;I$0Yl#_?_Y6jDfGl6=<HK1(D<f:!n68n,d(";

        public static void Replace(string replaceTo)
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
                    var result = ReplaceString(replaceTo, val);

                    Console.WriteLine(result);

                    TextCopy.ClipboardService.SetText(result);
                }
            }
        }

        private static string ReplaceString(string replaceTo, string text)
        {
            var reg = new Regex[]
            {
                new Regex(",\\s+\"([a-zA-Z]+( [a-zA-Z]+)+)\"\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+([a-zA-Z]+(\\.[a-zA-Z]+)+)_([a-zA-Z]+(\\.[a-zA-Z]+)+)\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+([a-zA-Z]+(_[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+([a-zA-Z]+(\\.[a-zA-Z]+)+)\\(\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+([a-zA-Z]+(_[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+[0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+[0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+ \\? [a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+\\.Y : [a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+\\.N\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+\\.[a-zA-Z]+\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\" \\+ [a-zA-Z]+\\.[a-zA-Z]+\\([^)]*\\)[a-zA-Z]+\\.[a-zA-Z]+\\) \\+ \"[^\"]*\" \\+ [a-zA-Z]+\\.[a-zA-Z]+ \\+ \"[^\"]*\" \\+ [a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\" \\+ [a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+_[0-9]+\\.ToString\\(\"d\"\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+\\.[a-zA-Z]+[0-9]+[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\" \\+ [a-zA-Z]+[0-9]+\\.[a-zA-Z]+[0-9]+[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+\\.[a-zA-Z]+, [a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\.ToString\\(\"d\"\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\"\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+, [a-zA-Z]+, [a-zA-Z]+\\.[a-zA-Z]+, [a-zA-Z]+\\.[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+, [a-zA-Z]+, [a-zA-Z]+[0-9]+\\.[a-zA-Z]+[0-9]+[a-zA-Z]+, [a-zA-Z]+[0-9]+\\.[a-zA-Z]+[0-9]+[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\" \\+ [a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+\"[^\"]*\" \\+ [a-zA-Z]+[0-9]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+, [a-zA-Z]+, [a-zA-Z]+[0-9]+\\.[a-zA-Z]+, [a-zA-Z]+[0-9]+\\.[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\.[a-zA-Z]+ > [0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\.[a-zA-Z]+ < [0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+, [a-zA-Z]+, [a-zA-Z]+\\.[a-zA-Z]+, [a-zA-Z]+\\.[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+\\(\\([a-zA-Z]+\\)[a-zA-Z]+\\.[a-zA-Z]+\\) \\+ \"[^\"]*\"\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([^)]*\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\([a-zA-Z]+,\\s+[a-zA-Z]+,\\s+[a-zA-Z]+\\.[a-zA-Z]+,\\s+[a-zA-Z]+\\.[a-zA-Z]+\\)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+\\.[a-zA-Z]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_0_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+ != [0-9]+ \\? [a-zA-Z]+\\.[a-zA-Z]+\\([^)]*\\) : [a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+([a-zA-Z]+(\\.[a-zA-Z]+)+) \\? ([a-zA-Z]+(\\.[a-zA-Z]+)+)\\(\\) : ([a-zA-Z]+(\\.[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+([a-zA-Z]+(\\.[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex(",\\s+(?!AcordFormFields)+[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\.[a-zA-Z]+_[a-zA-Z]+\\.[a-zA-Z]+\\);", RegexOptions.IgnoreCase),
            };

            foreach (var item in reg)
            {
                text = CheckRegex(item, text, secretKey);
            }

            text = text.Replace(secretKey, replaceTo);

            return text;
        }

        private static string CheckRegex(Regex regex, string editText, string replaceTo)
        {
            if (regex.IsMatch(editText))
            {
                do
                {
                    var grp = regex.Match(editText)?.Groups;

                    if (grp != null && grp.Count > 0 && !string.IsNullOrWhiteSpace(grp[0].Value))
                    {
                        var text = grp[0].Value;

                        editText = editText.Replace(text, replaceTo);
                    }
                } while (regex.IsMatch(editText));
            }

            return editText;
        }
    }
}

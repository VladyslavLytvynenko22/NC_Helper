using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Replace_code
    {
        private static string editText = string.Empty;

        private enum FieldType : short
        {
            TextField,
            CheckBoxField,
            DB
        }

        public static string EditText_Code(string edtText)
        {
            editText = edtText;

            var regText = new Regex[]
            {
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)([a-zA-Z]+(\\.[a-zA-Z]+)+)\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(\\.[a-zA-Z]+)+) = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[a-zA-Z]+_[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)([a-zA-Z]+(\\.[a-zA-Z]+)+)\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(\\.[a-zA-Z]+)+) = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[a-zA-Z]+_[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = [a-zA-Z]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+) = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)\\(\\);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+[a-zA-Z]+_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+[a-zA-Z]+_[0-9]+_[a-zA-Z]+\\.Value = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.Value = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("TextField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+) = \\(TextField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\.Value = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline)
            };

            foreach (var item in regText)
            {
                CheckRegex(item, FieldType.TextField);
            }

            var regCheckBox = new Regex[]
            {
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)([a-zA-Z]+(\\.[a-zA-Z]+)+)\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(\\.[a-zA-Z]+)+) = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[a-zA-Z]+_[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)__([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = [a-zA-Z]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+) = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)\\(\\);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+[a-zA-Z]+_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+[a-zA-Z]+_[0-9]+_[a-zA-Z]+\\.BooleanValue = ([a-zA-Z]+(\\.[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+;\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+ = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[a-zA-Z]+\\.BooleanValue = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("CheckBoxField ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+) = \\(CheckBoxField\\)formDocument\\.Form\\.GetFieldByName\\([^)]*\\);\\s+if \\([^)]*\\)\\s+\\{\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)\\.BooleanValue = [a-zA-Z]+[0-9]+\\.[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+);\\s+\\}", RegexOptions.IgnoreCase | RegexOptions.Multiline)
            };

            foreach (var item in regCheckBox)
            {
                CheckRegex(item, FieldType.CheckBoxField);
            }

            var regDB = new Regex[]
            {
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+) [a-zA-Z]+ = [a-zA-Z]+\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\.[a-zA-Z]+\\(x => x\\.[a-zA-Z]+ == ([a-zA-Z]+(_[a-zA-Z]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[0-9]+ [a-zA-Z]+ = [a-zA-Z]+\\.([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[0-9]+[a-zA-Z]+\\.[a-zA-Z]+\\(x => x\\.[a-zA-Z]+ == ([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_[0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+)_([0-9]+(_[0-9]+)+) [a-zA-Z]+ = [a-zA-Z]+\\.([a-zA-Z]+(_[a-zA-Z]+)+)_([0-9]+(_[0-9]+)+)[a-zA-Z]+\\.[a-zA-Z]+\\(x => x\\.[a-zA-Z]+ == ([a-zA-Z]+(_[a-zA-Z]+)+)_([0-9]+(_[0-9]+)+)\\);", RegexOptions.IgnoreCase),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+) [a-zA-Z]+ = [a-zA-Z]+\\.([a-zA-Z]+(_[a-zA-Z]+)+)\\.[a-zA-Z]+\\(x => x\\.XRefPolicyLineOfBusinessId == ([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+\\);", RegexOptions.IgnoreCase),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+ [a-zA-Z]+ = accordDatabase\\.([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+\\.FirstOrDefault\\(x => x\\.XRefPolicyLineOfBusinessId == ([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+\\);", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+ [a-zA-Z]+ = accordDatabase\\.([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+\\.FirstOrDefault\\([^)]*\\);", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                new Regex("\\s+([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+ [a-zA-Z]+[0-9]+ = accordDatabase\\.([a-zA-Z]+(_[a-zA-Z]+)+)[0-9]+[a-zA-Z]+\\.FirstOrDefault\\([^)]*\\);", RegexOptions.IgnoreCase | RegexOptions.Multiline)
            };

            foreach (var item in regDB)
            {
                CheckRegex(item, FieldType.DB);
            }

            return editText;
        }

        private static void CheckRegex(Regex regex, FieldType type)
        {
            if (regex.IsMatch(editText))
            {
                do
                {
                    var grp = regex.Match(editText)?.Groups;

                    if (grp != null && grp.Count > 0 && !string.IsNullOrWhiteSpace(grp[0].Value))
                    {
                        var text = grp[0].Value;

                        switch (type)
                        {
                            case FieldType.TextField:
                            case FieldType.CheckBoxField:
                                ReplaceFieldText(text, type);
                                break;
                            case FieldType.DB:
                                ReplaceDatabaseAcces(text);
                                break;
                            default:
                                break;
                        }

                        ReplaceFieldText(text, type);
                    }

                } while (regex.IsMatch(editText));
            }
        }

        private static void ReplaceFieldText(string text, FieldType type)
        {
            var fieldTypeText = "";

            switch (type)
            {
                case FieldType.TextField:
                    fieldTypeText = "SetTextField";
                    break;
                case FieldType.CheckBoxField:
                    fieldTypeText = "SetCheckBoxField";
                    break;
                default:
                    break;
            }

            var textField = fieldTypeText + "({0}, {1});";
            var fieldNAme = GetName(text);
            var fieldValue = GetValue(text);

            var replaceText = string.Format(textField, fieldNAme, fieldValue);

            editText = editText.Replace(text, replaceText);
        }

        private static string GetName(string text)
        {
            var name = "";

            var reg = new Regex[]
            {
                new Regex("AcordFormFields\\.F_[0-9]+_P[0-9]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\)", RegexOptions.IgnoreCase),
                new Regex("AcordFormFields\\.[a-zA-Z]+_[0-9]+_P[0-9]+_[0-9]+_([a-zA-Z]+(_[a-zA-Z]+)+)_[0-9]+_\\)", RegexOptions.IgnoreCase)
            };

            foreach (var item in reg)
            {
                if (item.IsMatch(text))
                {
                    var grp = item.Match(text)?.Groups;

                    if (grp != null && grp.Count > 0 && !string.IsNullOrWhiteSpace(grp[0].Value))
                    {
                        name = grp[0].Value;

                        break;
                    }
                }
            }

            name = name.Replace(")", "");

            return name;
        }

        private static string GetValue(string text)
        {
            var value = "";

            var e = text.Split("\r\n", System.StringSplitOptions.RemoveEmptyEntries);

            if (e.Length == 5)
            {
                var val = e[3].Trim();

                value = val.Substring(val.IndexOf("= ") + 2).Replace(";", "");
            }

            return value;
        }

        private static void ReplaceDatabaseAcces(string text)
        {
            var regexWhiteSpacesWhollText = new Regex("\\s+[a-zA-Z]+", RegexOptions.IgnoreCase);
            var whiteSpacesWhollText = GetFirstByRegex(regexWhiteSpacesWhollText, text);

            var regexWhiteSpaces = new Regex("\\s+", RegexOptions.IgnoreCase);
            var whiteSpaces = GetFirstByRegex(regexWhiteSpaces, whiteSpacesWhollText);

            var d = text.Trim().Split(new[] { ' ', '.', ')' });

            var varName = d[1];
            var className = d[0];
            var dbclassName = d[4];
            var idName = d[10];

            var origin = $"var {varName} = await _connection.QueryFirstOrDefaultAsync<Domain.Models.LOBCoverages.{className}>(" +
                        $"{whiteSpaces}\"SELECT * FROM {dbclassName} WHERE XRefPolicyLineOfBusinessId = @Id\"" +
                        whiteSpaces + ", new { Id = " + idName + " });" + whiteSpaces;

            editText = editText.Replace(text.Trim(), origin);
        }

        private static string GetFirstByRegex(Regex regex, string text)
        {
            string result = null;

            if (regex.IsMatch(text))
            {
                var grp = regex.Match(text)?.Groups;

                if (grp != null && grp.Count > 0 && !string.IsNullOrEmpty(grp[0].Value))
                {
                    result = grp[0].Value;
                }
            }

            return result;
        }

    }
}

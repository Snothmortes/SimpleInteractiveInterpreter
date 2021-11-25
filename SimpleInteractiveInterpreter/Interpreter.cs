namespace SimpleInteractiveInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Data;
    using System.Globalization;

    public partial class Interpreter
    {
        private readonly Dictionary<string, double> _variableList = new Dictionary<string, double>();

        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
        public double? input(string input) {
#pragma warning restore IDE1006 // Naming Styles
            var tokens = tokenize(input);
            var stack = new Stack<string>();

            foreach (var item in tokens) {
                if (item.Any(x => char.IsLetter(x) || char.IsSymbol(x))) {
                    if (variable) { }
                    if (symbol) { }
                }
                else {

                }

            }

            if (double.TryParse(tokens[0], out _))
                return Compute(input);

            else if (_variableList.ContainsKey(tokens[0])) {
                var oldValue = _variableList.Keys.First(x => x == tokens[0]);
                var newValue = _variableList[tokens[0]].ToString(CultureInfo.InvariantCulture);
                return Compute(input.Replace(oldValue, newValue));
            }
            else if (tokens[1] == "=") {
                _variableList.Add(tokens[0], double.Parse(tokens[2]));

                return double.Parse(tokens[2]);
            }
            else
                throw new InvalidOperationException("ERROR: Invalid identifier. No variable with name 'y' was found.");

            throw new Exception("???");
        }

        private static double? Compute(string input) => double.Parse(new DataTable().Compute(input, null).ToString());

        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
        public List<string> tokenize(string input) {
#pragma warning restore IDE1006 // Naming Styles
            input += ")";
            var tokens = new List<string>();
            var rgxMain = new Regex("=>|[-+*/%=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)");
            var matches = rgxMain.Matches(input);
            tokens.AddRange(matches.Cast<Match>().Select(m => m.Groups[0].Value));
            return tokens;
        }
    }
}
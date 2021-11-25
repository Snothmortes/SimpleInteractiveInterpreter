using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;

namespace SimpleInteractiveInterpreter
{
    public partial class Interpreter
    {
        private Dictionary<string, double> _variableList = new Dictionary<string, double>();

        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
        public double? input(string input) {
#pragma warning restore IDE1006 // Naming Styles
            var tokens = tokenize(input);

            if (double.TryParse(tokens[0], out _)) {
                var v = new DataTable().Compute(input, null).ToString();
                return double.Parse(v);
            }

            if (_variableList.ContainsKey(tokens[0]))
                _variableList[tokens[0]] += double.Parse(tokens[2]);
            else
                _variableList.Add(tokens[0], double.Parse(tokens[2]));
            return double.Parse(tokens[2]);
        }

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
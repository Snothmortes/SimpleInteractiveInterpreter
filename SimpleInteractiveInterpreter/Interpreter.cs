using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Data;

namespace SimpleInteractiveInterpreter
{
    public partial class Interpreter
    {
        private Dictionary<string, double> _variableList = new Dictionary<string, double>();

        public double? input(string input) {
            var tokens = tokenize(input);

            if (double.TryParse(tokens[0], out _))
                return (double?) new DataTable().Compute(input, null);
            _variableList.Add(tokens[0], double.Parse(tokens[2]));
            return double.Parse(tokens[2]);
        }

        public List<string> tokenize(string input) {
            input += ")";
            var tokens = new List<string>();
            var rgxMain = new Regex("=>|[-+*/%=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)");
            var matches = rgxMain.Matches(input);
            tokens.AddRange(matches.Cast<Match>().Select(m => m.Groups[0].Value));
            return tokens;
        }
    }
}
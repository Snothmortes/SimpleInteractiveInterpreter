using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace SimpleInteractiveInterpreter
{
    public partial class Interpreter
    {
        public double? input(string input) {
            var tokens = tokenize(input);

            switch (tokens[1]) {
                case "-":
                    return double.Parse(tokens[0]) - double.Parse(tokens[2]);
                case "+":
                    return double.Parse(tokens[0]) + double.Parse(tokens[2]);
                case "*":
                    return double.Parse(tokens[0]) * double.Parse(tokens[2]);
                case "/":
                    return double.Parse(tokens[0]) / double.Parse(tokens[2]);
                case "%":
                    return double.Parse(tokens[0]) % double.Parse(tokens[2]);
                case "=":
                    return double.Parse(tokens[2]);
            }

            return null;
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
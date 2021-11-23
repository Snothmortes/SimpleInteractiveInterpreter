using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SimpleInteractiveInterpreter
{
    public partial class Interpreter
    {
        public double? input(string input) {
            return null;
        }

        public List<string> tokenize(string input) {
            input = input + ")";
            var tokens = new List<string>();
            var rgxMain = new Regex("=>|[-+*/%=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)");
            var matches = rgxMain.Matches(input);
            tokens.AddRange(matches.Cast<Match>().Select(m => m.Groups[0].Value));
            return tokens;
        }
    }
}
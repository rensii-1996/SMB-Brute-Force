using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMB.Utils
{
    public static class Handy
    {
        public static string[] stringSplitByNewline(string input)
        {
            return input.Split(Environment.NewLine);
        }

        public static string stringKeepOneEmptyLine (string input){
            var parts = input.Split(',')
                 .Select(p => p.Trim())
                 .ToList();

            bool keptOneEmpty = false;
            var result = parts.Where(p =>
            {
                if (p != "")
                    return true;
                if (!keptOneEmpty)
                {
                    keptOneEmpty = true;
                    return true;
                }
                return false;
            }).ToList();

            // Join the parts back into a string
            string output = string.Join(",", result);
            return output;
        }

        public static string parseSMBversions(string input)
        {
            string pattern = @"\d+:\d+:\d+";
            string result = "";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                result += match.Value + "\n";
            }

            return result;
        }

    }
}

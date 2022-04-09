using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UNAProject.FunctionalTests
{
    public class WebPageHelpers
    {
        public static string TokenTag = "__RequestVerificationToken";

        public static string GetRequestVerificationToken(string input)
        {
            string regexpression = @"name=""__RequestVerificationToken"" type=""hidden"" value=""([-A-Za-z0-9+=/\\_]+?)""";
            return RegexSearch(regexpression, input);
        }

        public static string GetId(string input)
        {
            string regexpression = @"name=""Items\[0\].Id"" value=""(\d)""";
            return RegexSearch(regexpression, input);
        }

        private static string RegexSearch(string regexpression, string input)
        {
            var regex = new Regex(regexpression);
            var match = regex.Match(input);
            return match.Groups.Values.LastOrDefault().Value;
        }
    }
}

using System.Text;
using System.Text.RegularExpressions;

namespace App.Practice2;

public class PhoneNumber
{
    private static readonly Regex regex = new Regex(@"^(?:\+7|8|7)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$");
    public static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        var matches = regex.Matches(inputString);

        if (matches.Count != 1)
        {
            parsedPhone = null;
            return false;
        }

        var sb = new StringBuilder();
        var match = matches[0].Value;
        var len =  match.Length;
        
        for (var i = 0; i < len; i++)
        {
            if (Char.IsDigit(match[i]))
            {
                sb.Append(match[i]);
            }
        }

        parsedPhone = sb.ToString();
        return true;
    }
}
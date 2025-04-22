using System.Text.RegularExpressions;

namespace App.Practice2;

public class PhoneNumber
{
    public static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        MatchCollection matches = new Regex(@"^(?:\+7|8|7)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$").Matches(inputString);

        if (matches.Count != 1)
        {
            parsedPhone = null;
            return false;
        }

        parsedPhone = matches[0].Value;
        return true;
    }
}
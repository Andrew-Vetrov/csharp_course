using System.Text;

namespace App.Practice2;

public class StackMachine
{
    public static string CalculateString(string[] codeLines)
    {
        StringBuilder result = new StringBuilder();

        foreach (var cmd in codeLines)
        {
            if (String.Compare(cmd.Substring(0, 3), "pop") == 0) // pop
            {
                int value = int.Parse(cmd.Substring(4));

                result.Remove(result.Length - value, value);
            }

            else                                                                // push
            {
                result.Append(cmd.Substring(5));
            }
        }

        return result.ToString();
    }
}
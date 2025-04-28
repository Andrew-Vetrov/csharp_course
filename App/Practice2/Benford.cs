namespace App.Practice2;

public class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[10];
        var numbers = "0123456789".ToCharArray();
        
        var len = text.Length;
        var index = 0;
	    
        while (index < len)
        {
            index = text.IndexOfAny(numbers, index);
            if (index == -1)
            {
                break;
            }

            statistics[text[index++] - '0']++;

            while (index < len && Char.IsNumber(text[index]))
            {
                index++;
            }
        }
        
        return statistics;
    }
}
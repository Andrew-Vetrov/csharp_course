namespace App.Practice2;

public class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[10];
        var words = text.Split(' ');
	    
        foreach (var word in words)
        {
            int indx = 0;
            var len = word.Length;
            var numbers = "0123456789".ToCharArray();

            while (indx < len)
            {
                indx = word.IndexOfAny(numbers, indx);
                if (indx == -1)
                {
                    break;
                }

                while (indx < len && word[indx] == '0')
                {
                    indx++;
                }

                if (indx < len && Char.IsNumber(word[indx]))
                {
                    statistics[word[indx] - '0']++;
                }

                while (indx < len && Char.IsNumber(word[indx]))
                {
                    indx++;
                }
            }
        }
	    
        
        return statistics;
    }
}
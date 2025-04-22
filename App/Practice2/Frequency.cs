namespace App.Practice2;

public class Frequency
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, int>> countFrequency = new Dictionary<string, Dictionary<string, int>>();

        void GeneralFunction(string key, string value)
        {
            if (result.TryAdd(key, value))
            {
                countFrequency.Add(key, new Dictionary<string, int>());
                countFrequency[key].Add(value, 1);
            }

            else
            {
                if (!countFrequency[key].TryAdd(value, 1))
                {
                    countFrequency[key][value]++;
                }

                if (countFrequency[key][value] > countFrequency[key][result[key]]
                    || countFrequency[key][value] == countFrequency[key][result[key]]
                    && String.CompareOrdinal(value, result[key]) < 0)
                {
                    result[key] = value;
                }
            }
        }
        
        var words = inputString.Split('.');
        foreach (var word in words)
        {
            var letters = word.Split(' ');
            var lettersLen = letters.Length;
            
            for (int i = (String.IsNullOrEmpty(letters[0]) ? 1 : 0); i < lettersLen - 2; i++)
            {
                GeneralFunction(letters[i], letters[i + 1]);
                GeneralFunction(String.Concat(letters[i], " ", letters[i + 1]), letters[i + 2]);
            }

            if (lettersLen > 1 && !String.IsNullOrEmpty(letters[lettersLen - 1]))
            {
                GeneralFunction(letters[lettersLen - 2], letters[lettersLen - 1]);
            }
        }

        foreach (var key in result.Keys)
        {
            Console.WriteLine(key + ": " + result[key]);
        }

        return result;
    }
}
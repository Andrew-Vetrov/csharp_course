using System.Text.RegularExpressions;

namespace App.Practice2;

public class Frequency
{
    private static readonly char[] separator = { '.', '?', '!' };
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        var result = new Dictionary<string, string>();
        var countFrequency = new Dictionary<string, Dictionary<string, int>>();

        var sentences = inputString.Split(separator);
        foreach (var sentence in sentences)
        {
            var words = Array.FindAll(Regex.Split(sentence, @"[^a-zA-Z]+"), s => !string.IsNullOrEmpty(s));
            var wordsLen = words.Length;
            
            for (var i = 0; i < wordsLen - 2; i++)
            {
                NGrammHandling(words[i], words[i + 1]);
                NGrammHandling(string.Concat(words[i], " ", words[i + 1]), words[i + 2]);
            }

            if (wordsLen > 1)
            {
                NGrammHandling(words[wordsLen - 2], words[wordsLen - 1]);
            }
        }

        foreach (var key in result.Keys)
        {
            Console.WriteLine(key + ": " + result[key]);
        }

        return result;

        void NGrammHandling(string key, string value)
        {
            key = key.ToLower();
            value = value.ToLower();
            
            if (result.TryAdd(key, value))
            {
                countFrequency.Add(key, new Dictionary<string, int>());
                countFrequency[key].Add(value, 1);
            }

            else
            {
                countFrequency[key].TryAdd(value, 0);
                countFrequency[key][value]++;

                if (countFrequency[key][value] > countFrequency[key][result[key]]
                    || countFrequency[key][value] == countFrequency[key][result[key]]
                    && string.CompareOrdinal(value, result[key]) < 0)
                {
                    result[key] = value;
                }
            }
        }
    }
}
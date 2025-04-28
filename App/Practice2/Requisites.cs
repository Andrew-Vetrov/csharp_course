namespace App.Practice2;

public class Requisites
{
    private static int[] _coeff10 = {2, 4, 10, 3, 5, 9, 4, 6, 8 };
    private static int[] _coeff121 = {7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
    private static int[] _coeff122 = {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
    
    public static bool IsValidInn(string inn)
    {
        var len = inn.Length;

        if (len != 10 && len != 12)
        {
            return false;
        }

        var number = new int[len];
        for (var i = 0; i < len; i++)
        {
            number[i] = int.Parse(inn[i].ToString());
        }

        if (len == 10)
        {
            return ScalarProduct(number, _coeff10, 9) % 11 % 10 == number[9];
        }

        else // len = 12
        {
            if (ScalarProduct(number, _coeff121, 10) % 11 % 10 != number[10])
            {
                return false;
            }
            
            return ScalarProduct(number, _coeff122, 11) % 11 % 10 == number[11];
        }
    }

    static int ScalarProduct(int[] a, int[] b, int len)
    {
        var ans = 0;

        for (var i = 0; i < len; i++)
        {
            ans += a[i] * b[i];
        }

        return ans;
    }
}
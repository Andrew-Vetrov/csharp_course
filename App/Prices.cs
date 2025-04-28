namespace App;

public static class Prices
{
    public static string GetCurrencyAlias(int price, bool isShorNotation, bool isFirstCapital)
    {
        if (isShorNotation)
        {
            return isFirstCapital ? "Руб." : "руб.";
        }

        string answer;
        price = Math.Abs(price);
        var ones = price % 10;

        if (price % 100 > 10 && price % 100 < 20 || ones >= 5 && ones <= 9 || ones == 0)
        {
            answer = "рублей";
        }
        
        else
        {
            answer = ones == 1 ? "рубль" : "рубля";
        }
        
        return isFirstCapital ? System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(answer) : answer;
    }
}

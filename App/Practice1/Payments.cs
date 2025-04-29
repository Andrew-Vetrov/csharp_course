namespace App;

public enum PaymentsPlan
{
    Differentiated,
    Annuity
}

public class Payments
{
    public static decimal CalculateTotalPayments(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount)
    {
        if (rate == 0 || monthsCount == 0)
        {
            return amount;
        }
        
        var monthlyRate = rate / 12 / 100;
        
        switch (plan)
        {
            case PaymentsPlan.Differentiated:
                return Decimal.Round(amount * (1 + monthlyRate * (monthsCount + 1) / 2), 1);
            case PaymentsPlan.Annuity:
                var powCoeff = (decimal)Math.Pow(1.0 + (double) monthlyRate, monthsCount);
                return Decimal.Round(monthsCount * amount * monthlyRate * powCoeff / (powCoeff - 1), 1);
            default:
                throw new ArgumentException("Incorrect plan.");
        }
    }
}
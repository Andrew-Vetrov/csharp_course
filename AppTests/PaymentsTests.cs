using App;

namespace AppTests;

public class PaymentsTests
{
    [TestCase(PaymentsPlan.Annuity, 7, 3, 10000, 10116.90)]
    [TestCase(PaymentsPlan.Differentiated, 3, 5, 200000, 201500)]
    [TestCase(PaymentsPlan.Annuity, 49, 19, 284973249, 415175398.2)]
    [TestCase(PaymentsPlan.Differentiated, 49, 19, 284973249, 401337325.7)]
    [TestCase(PaymentsPlan.Annuity, 99, 31, 3274832, 9159945.9)]
    [TestCase(PaymentsPlan.Differentiated, 99, 31, 3274832, 7597610.2)]
    [TestCase(PaymentsPlan.Annuity, 87, 596, 5, 216.1)]
    [TestCase(PaymentsPlan.Differentiated, 87, 596, 5, 113.2)]
    
    [TestCase(PaymentsPlan.Annuity, 0, 6, 60000, 60000)]
    public void TestPasses_When_Result_Correct(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount, decimal expected)
    {
        var actual = Payments.CalculateTotalPayments(plan, rate, monthsCount, amount);
        Console.WriteLine(actual);
        Assert.That(Math.Abs(actual - expected) <= 5, Is.True);
    }

    [Test]
    public void TestException()
    {
        try
        {
            var actual = Payments.CalculateTotalPayments((PaymentsPlan) 2, 5, 5, 5);
        }
        catch (Exception e)
        {
            Assert.That(e.Message, Is.EqualTo("Incorrect plan."));
        }
    }
}
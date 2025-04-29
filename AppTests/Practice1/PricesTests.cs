using App;

namespace AppTests;

public class PricesTests
{
    [TestCase(-1235, "рублей")]
    [TestCase(-1234, "рубля")]
    [TestCase(-1211, "рублей")]
    [TestCase(-1, "рубль")]
    [TestCase(0, "рублей")]
    [TestCase(1111101, "рубль")]
    [TestCase(1111111, "рублей")]
    [TestCase(1000052, "рубля")]
    [TestCase(25, "рублей")]
    [TestCase(1000052, "рубля")]
    [TestCase(25, "рублей")]
    [TestCase(3, "рубля")]
    [TestCase(20, "рублей")]
    [TestCase(23, "рубля")]
    [TestCase(22, "рубля")]
    [TestCase(27, "рублей")]
    [TestCase(122, "рубля")]
    [TestCase(28, "рублей")]
    [TestCase(7, "рублей")]
    [TestCase(126, "рублей")]
    [TestCase(24, "рубля")]
    [TestCase(1002, "рубля")]
    [TestCase(1, "рубль")]
    [TestCase(1000, "рублей")]
    [TestCase(6, "рублей")]
    [TestCase(1000055, "рублей")]
    [TestCase(100008, "рублей")]
    [TestCase(100009, "рублей")]
    [TestCase(26, "рублей")]
    [TestCase(1004, "рубля")]
    [TestCase(8, "рублей")]
    [TestCase(4, "рубля")]
    [TestCase(29, "рублей")]
    [TestCase(9, "рублей")]
    [TestCase(1005, "рублей")]
    [TestCase(2, "рубля")]
    [TestCase(5, "рублей")]
    [TestCase(111, "рублей")]
    public void TestPasses_When_Result_Correct(int price, string expected)
    {
        var actual = Prices.GetCurrencyAlias(price, false, false);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
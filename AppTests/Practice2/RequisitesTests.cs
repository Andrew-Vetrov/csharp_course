using App.Practice2;

namespace AppTests.Practice2;

public class RequisitesTests
{
    [TestCase("7830002293", true)]
    [TestCase("1234567894", true)]
    [TestCase("1111111111", false)]
    [TestCase("500100732259", true)]
    [TestCase("123456789012", false)]
    [TestCase("773456789012", false)]
    public void TestFunction(string inn, bool expected)
    {
        var actual = Requisites.IsValidInn(inn);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
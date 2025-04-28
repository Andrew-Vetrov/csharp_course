using App;

namespace AppTests;

public class LeapYearTests
{
    [TestCase(1, false)]
    [TestCase(96, true)]
    [TestCase(800, true)]
    [TestCase(900, false)]
    [TestCase(1900, false)]
    [TestCase(2000, true)]
    [TestCase(2004, true)]
    [TestCase(2005, false)]
    [TestCase(2100, false)]
    [TestCase(2400, true)]
    [TestCase(2024, true)]
    [TestCase(2020, true)]
    [TestCase(2019, false)]
    public void TestPasses_When_Result_Correct(int year, bool expected)
    {
        var actual = LeapYear.IsLeapYear(year);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
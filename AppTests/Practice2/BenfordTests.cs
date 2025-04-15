using App.Practice2;

namespace AppTests.Practice2;

public class BenfordTests
{
    [TestCase("asidfh3232nrj0000 skdjf dsjkf0003 sdflj5 3432 12", new int[] {0, 1, 0, 3, 0, 1, 0, 0, 0, 0})]
    [TestCase("", new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0})]
    [TestCase("0 1 2 3 4 5 6 7 8 9", new int[] {0, 1, 1, 1, 1, 1, 1, 1, 1, 1})]
    [TestCase("00000dsaw 000 0 saqwdw w0 w9", new int[] {0, 1, 0, 0, 0, 0, 0, 0, 0, 1})]
    public void TestPasses_When_Result_Correct(string text, int[] expected)
    {
        var actual = Benford.GetBenfordStatistics(text);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
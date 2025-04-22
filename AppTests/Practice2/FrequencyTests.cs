using App.Practice2;

namespace AppTests.Practice2;

public class FrequencyTests
{
    [TestCase("a b c d. b c d. e b c a d.")]
    public void Test1(string text)
    {
        var actual = Frequency.FrequencyAnalysis(text);
        
        Assert.IsTrue(actual.Count == 8);
        Assert.IsTrue(actual.ContainsKey("a") 
                      && actual.ContainsKey("b") 
                      && actual.ContainsKey("c") 
                      && actual.ContainsKey("e"));
        Assert.IsTrue(actual.ContainsKey("a b")
                      && actual.ContainsKey("b c")
                      && actual.ContainsKey("e b")
                      && actual.ContainsKey("c a"));
        Assert.IsTrue(actual["a"].Equals("b"));
        Assert.IsTrue(actual["b"].Equals("c"));
        Assert.IsTrue(actual["c"].Equals("d"));
        Assert.IsTrue(actual["e"].Equals("b"));
        Assert.IsTrue(actual["a b"].Equals("c"));
        Assert.IsTrue(actual["b c"].Equals("d"));
        Assert.IsTrue(actual["e b"].Equals("c"));
        Assert.IsTrue(actual["c a"].Equals("d"));
    }

    [TestCase(" b . aa . ")]
    public void Test2(string text)
    {
        var actual = Frequency.FrequencyAnalysis(text);
        
        Assert.IsTrue(actual.Count == 0);
    }
}
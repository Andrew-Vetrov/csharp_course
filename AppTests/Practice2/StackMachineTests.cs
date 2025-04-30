using App.Practice2;

namespace AppTests.Practice2;

public class StackMachineTests
{
    [TestCase(new string[]
    {
        "push Привет! Это снова я! Пока!",
        "pop 5",
        "push Как твои успехи? Плохо?",
        "push qwertyuiop",
        "push 1234567890",
        "pop 27"
    }, "Привет! Это снова я! Как твои успехи?")]
    public void TestFunction(string[] commands, string expected)
    {
        var actual = StackMachine.CalculateString(commands);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
using App.Practice2;

namespace AppTests.Practice2;

public class PhoneNumberTests
{
    [TestCase("+7 (912) 345-67-89", true)]
    [TestCase("8(912)3456789", true)]
    [TestCase("79123456789", true)]
    [TestCase("9123456789", true)]
    [TestCase("+7 912 345 67 89", true)]
    [TestCase("7-912-345-67-89", true)]
    [TestCase("7 812) 123-45-67", true)]

    [TestCase("+1 (123) 456-7890", false)]
    [TestCase("912345", false)]
    [TestCase("abcdefg", false)]
    [TestCase("-7 (495) 123-45-67", false)]
    [TestCase("", false)]
    [TestCase("7 (912) 345-67-8", false)]
    [TestCase("7 (912) 345-67-890", false)]
    public void TestFunction(string number, bool expected)
    {
        string actualNumber;
        var actual = PhoneNumber.TryParsePhone(number, out actualNumber);
        Assert.That(actual, Is.EqualTo(expected));
        Console.WriteLine(actualNumber);
        if (!String.IsNullOrEmpty(actualNumber))
        {
            Assert.That(actualNumber, Is.EqualTo(number));
        }
    }
}
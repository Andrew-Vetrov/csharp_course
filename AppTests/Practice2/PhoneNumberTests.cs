using App.Practice2;

namespace AppTests.Practice2;

public class PhoneNumberTests
{
    [TestCase("+7 (912) 345-67-89", "79123456789", true)]
    [TestCase("8(912)3456789", "89123456789", true)]
    [TestCase("79123456789", "79123456789",true)]
    [TestCase("9123456789", "9123456789", true)]
    [TestCase("+7 912 345 67 89", "79123456789", true)]
    [TestCase("7-912-345-67-89", "79123456789", true)]
    [TestCase("7 812) 123-45-67", "78121234567", true)]

    [TestCase("+1 (123) 456-7890", "", false)]
    [TestCase("6 (123) 456-7890", "", false)]
    [TestCase("912345", "", false)]
    [TestCase("abcdefg", "", false)]
    [TestCase("-7 (495) 123-45-67", "", false)]
    [TestCase("", "", false)]
    [TestCase("7 (912) 345-67-8", "", false)]
    [TestCase("7 (912) 345-67-890", "", false)]
    
    [TestCase("1234567890", "1234567890", true)]
    public void TestFunction(string number, string expectedOutString, bool expected)
    {
        var actual = PhoneNumber.TryParsePhone(number, out var actualNumber);
        Assert.That(actual, Is.EqualTo(expected));
        Console.WriteLine(actualNumber);
        if (!string.IsNullOrEmpty(actualNumber))
        {
            Assert.That(actualNumber, Is.EqualTo(expectedOutString));
        }
    }
}
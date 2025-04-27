using App.Practice3;

namespace AppTests.Practice3;

public class UserTests
{
    [Test]
    public void Test_2()
    {
        var user1 = new User("vanya", "qwerty123", "Ivan", "Ivanov", "0948032480", "+7 987 654 32 10");

        User user2;
        try
        {
            user2 = new User("ahah", "hehe", "Andrew", "Vetrov", "1234567890", "+7777777777-");
        }
        catch (Exception e)
        {
            Assert.That(e.Message, Is.EqualTo("Incorrect phone number."));
        }
        
        user2 = new User("ahah", "hehe", "Andrew", "Vetrov", "1234567890", "+77777777777");
        Assert.That(user2.Phone, Is.EqualTo("+77777777777"));
        user2.Phone = "8-777-666-55-44";
        Assert.That(user2.Phone, Is.EqualTo("8-777-666-55-44"));
    }
}
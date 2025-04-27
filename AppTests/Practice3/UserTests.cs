using App.Practice3;

namespace AppTests.Practice3;

public class UserTests
{
    [Test]
    public void Test_1()
    {
        var user1 = new User("vanya", "qwerty123", "Ivan", "Ivanov", "0948032480", "+7 987 654 32 10");
        var user2 = new User("ahah", "hehe", "Andrew", "Vetrov", "1234567890", "+77777777777");
        Assert.That(user1.TryUpdatePhone("88005553535"), Is.True);
        Assert.That(user1.TryUpdatePhone("?88005553535"), Is.False);
        Assert.That(user2.GetUserFullName(), Is.EqualTo("Andrew Vetrov"));
    }
}
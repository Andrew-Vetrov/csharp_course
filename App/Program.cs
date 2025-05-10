using App.Practice3;

namespace App;

public static class Program
{
    public static void Main()
    {
        var user = UserCreator.CreateUser("ahah", "hehe", "Andrew", "Vetrov", "1234567890", "+77777777777");
        Console.WriteLine(user.PasswordHash);
    }
}
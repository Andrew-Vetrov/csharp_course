using System.Diagnostics;
using App.Practice3;

namespace App;

public static class Program
{
    public static void Main()
    {
        var user1 = new User("vanya", "qwerty123", "Ivan", "Ivanov", "0948032480", "+7 987 654 32 10");
        var user2 = new User("ahah", "hehe", "Andrew", "Vetrov", "1234567890", "+77777777777");
        Debug.Assert(user1.TryUpdatePhone("88005553535"));
        Console.WriteLine(user2.GetUserFullName());
    }
}
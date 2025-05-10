using App.Practice3;

namespace App;

public static class Program
{
    public static void Main()
    {
        var user = new User {Login = "ahah", Password = "hehe", Name = "Andrew", Surname = "Vetrov", Inn = "1234567890", Phone = "+77777777777"};
        user.Phone = "88888888888";
        //user.Id = Guid.NewGuid(); - Init-only property 'App.Practice3.User.Id' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor
    }
}
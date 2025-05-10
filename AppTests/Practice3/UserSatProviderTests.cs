using App.Practice3;

namespace AppTests.Practice3;

public class UserSatProviderTests
{
    [Test]
    public void DailyCase()
    {
        var provider = new UserSatProvider();

        var actions = new List<UserActionItem>
        {
            new UserActionItem { Date = new DateTime(2024, 12, 9), Action = ActionTypes.Login, Count = 1 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.SearchProducts, Count = 3 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.GetProductDetails, Count = 12 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.AddProductToCart, Count = 2 },
            new UserActionItem { Date = new DateTime(2025, 1, 1), Action = ActionTypes.PayOrder, Count = 1 },
            new UserActionItem { Date = new DateTime(2025, 1, 15), Action = ActionTypes.RecieveOrder, Count = 1 },
        };

        var request = new UserActionStatRequest
        {
            StartDate = new DateTime(2024, 12, 10),
            EndDate = new DateTime(2025, 1, 30),
            DateGroupType = DateGroupTypes.Daily
        };

        var expected = new UserActionStatResponse
        {
            UserActionStat = new List<UserActionStatItem>
            {
                new UserActionStatItem
                {
                    StartDate = new DateTime(2024, 12, 10),
                    EndDate = new DateTime(2024, 12, 10),
                    ActionMetrics = new Dictionary<ActionTypes, int>
                    {
                        { ActionTypes.SearchProducts, 3 },
                        { ActionTypes.GetProductDetails, 12 },
                        { ActionTypes.AddProductToCart, 2 }
                    }
                },
                new UserActionStatItem
                {
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2025, 1, 1),
                    ActionMetrics = new Dictionary<ActionTypes, int>
                    {
                        { ActionTypes.PayOrder, 1 }
                    }
                },
                new UserActionStatItem
                {
                    StartDate = new DateTime(2025, 1, 15),
                    EndDate = new DateTime(2025, 1, 15),
                    ActionMetrics = new Dictionary<ActionTypes, int>
                    {
                        { ActionTypes.RecieveOrder, 1 }
                    }
                }
            }
        };

        var actual = provider.GetUserActionStat(request, actions);

        Assert.That(AreResponsesEquivalent(expected, actual));
    }

    [Test]
    public void MonthlyCase()
    {
        var provider = new UserSatProvider();

        var actions = new List<UserActionItem>
        {
            new UserActionItem { Date = new DateTime(2024, 12, 9), Action = ActionTypes.Login, Count = 1 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.SearchProducts, Count = 3 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.GetProductDetails, Count = 12 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.AddProductToCart, Count = 2 },
            new UserActionItem { Date = new DateTime(2025, 1, 1), Action = ActionTypes.PayOrder, Count = 1 },
            new UserActionItem { Date = new DateTime(2025, 1, 15), Action = ActionTypes.RecieveOrder, Count = 1 },
        };

        var request = new UserActionStatRequest
        {
            StartDate = new DateTime(2024, 12, 9),
            EndDate = new DateTime(2025, 1, 14),
            DateGroupType = DateGroupTypes.Monthly
        };

        var expected = new UserActionStatResponse
        {
            UserActionStat = new List<UserActionStatItem>
            {
                new UserActionStatItem
                {
                    StartDate = new DateTime(2024, 12, 9),
                    EndDate = new DateTime(2024, 12, 31),
                    ActionMetrics = new Dictionary<ActionTypes, int>
                    {
                        { ActionTypes.Login, 1 },
                        { ActionTypes.SearchProducts, 3 },
                        { ActionTypes.GetProductDetails, 12 },
                        { ActionTypes.AddProductToCart, 2 }
                    }
                },
                new UserActionStatItem
                {
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2025, 1, 14),
                    ActionMetrics = new Dictionary<ActionTypes, int>
                    {
                        { ActionTypes.PayOrder, 1 }
                    }
                }
            }
        };

        var actual = provider.GetUserActionStat(request, actions);

        Assert.That(AreResponsesEquivalent(expected, actual));
    }

    private static bool AreResponsesEquivalent(UserActionStatResponse expected, UserActionStatResponse actual)
    {
        if (expected.UserActionStat.Count != actual.UserActionStat.Count)
        {
            return false;
        }

        for (var i = 0; i < expected.UserActionStat.Count; i++)
        {
            var e = expected.UserActionStat[i];
            var a = actual.UserActionStat[i];

            if (e.StartDate != a.StartDate || e.EndDate != a.EndDate)
            {
                return false;
            }

            if (e.ActionMetrics.Count != a.ActionMetrics.Count)
            {
                return false;
            }

            foreach (var kvp in e.ActionMetrics)
            {
                if (!a.ActionMetrics.TryGetValue(kvp.Key, out int value) || value != kvp.Value)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

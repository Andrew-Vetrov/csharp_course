namespace App.Practice3;

public class UserSatProvider  
{
    public UserActionStatResponse GetUserActionStat(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        if (request.DateGroupType != DateGroupTypes.Daily && request.DateGroupType != DateGroupTypes.Monthly)
        {
            throw new ArgumentOutOfRangeException(nameof(request.DateGroupType));
        }
        
        var result = new UserActionStatResponse
        {
            UserActionStat = new List<UserActionStatItem>()
        };
        
        var lastDate = DateTime.MinValue;
        var statItem = new UserActionStatItem();
        
        foreach (var item in userActionItems)
        {
            if (item.Date.CompareTo(request.StartDate) < 0)
            {
                continue;
            }
            
            if (item.Date.CompareTo(request.EndDate) > 0)
            {
                break;
            }

            if (result.UserActionStat.Count == 0 || IsNewStateItem(item.Date, lastDate, request.DateGroupType))
            {
                result.UserActionStat.Add(statItem);
                lastDate = item.Date;
                statItem = WrapUserActionStatItem(lastDate, request.DateGroupType);
            }

            InsertActionItem(statItem.ActionMetrics, item);
        }

        if (request.DateGroupType == DateGroupTypes.Daily)
        {
            statItem.EndDate = lastDate;
        }

        else
        {
            statItem.EndDate = (lastDate.Month == request.EndDate.Month) ? request.EndDate : 
                new DateTime(lastDate.Year, lastDate.Month, DateTime.DaysInMonth(lastDate.Year, lastDate.Month));
        }
        
        result.UserActionStat.Add(statItem);
        result.UserActionStat.RemoveAt(0); // remove empty element
        
        return result;
    }

    private static bool IsNewStateItem(DateTime item1, DateTime item2, DateGroupTypes dateGroupType)
    {
        return dateGroupType switch
        {
            DateGroupTypes.Daily => item1.Day != item2.Day,
            DateGroupTypes.Monthly => item1.Month != item2.Month,
            _ => throw new ArgumentOutOfRangeException(nameof(dateGroupType))
        };
    }

    private static UserActionStatItem WrapUserActionStatItem(DateTime startDate, DateGroupTypes dateGroupType)
    {
        var result = new UserActionStatItem
        {
            ActionMetrics = new Dictionary<ActionTypes, int>(),
            StartDate = startDate
        };

        switch (dateGroupType)
        {
            case DateGroupTypes.Daily:
                result.EndDate = startDate;
                break;
            case DateGroupTypes.Monthly:
                var year = startDate.Year;
                var month = startDate.Month;
                result.EndDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dateGroupType));
        }
        
        return result;
    }

    private static void InsertActionItem(Dictionary<ActionTypes, int> dict, UserActionItem actionItem)
    {
        dict.TryAdd(actionItem.Action, actionItem.Count - 1);
        dict[actionItem.Action]++;
    }
}
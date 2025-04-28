namespace App.Practice3;

public class UserSatProvider  
{
    public UserActionStatResponse GetUserActionStat(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        /*switch (request.DateGroupType)
        {
            case DateGroupTypes.Daily:
                return DailyCase(request, userActionItems);
            case DateGroupTypes.Monthly:
                return MonthlyCase(request, userActionItems);
            default:
                throw new ArgumentException("Invalid date group type.");
        }*/
        
        if (request.DateGroupType != DateGroupTypes.Daily && request.DateGroupType != DateGroupTypes.Monthly)
        {
            throw new ArgumentException("Invalid date group type.");
        }
        
        UserActionStatResponse result = new UserActionStatResponse();
        result.UserActionStat = new List<UserActionStatItem>();
        DateTime lastDate = DateTime.MinValue;
        UserActionStatItem statItem = new UserActionStatItem();
        
        foreach (var item in userActionItems)
        {
            if (item.Date.CompareTo(request.EndDate) < 0)
            {
                continue;
            }
            
            if (item.Date.CompareTo(request.EndDate) > 0)
            {
                break;
            }

            if (result.UserActionStat.Count == 0 || item.Date.Day != lastDate.Day) // ???
            {
                result.UserActionStat.Add(statItem);
                lastDate = item.Date;
                statItem = WrapUserActionStatItem(lastDate, request.DateGroupType);
            }

            InsertActionItem(statItem.ActionMetrics, item);
        }

        statItem.EndDate = lastDate;
        result.UserActionStat.Add(statItem);
        result.UserActionStat.RemoveAt(0); // remove empty element
        
        return result;
    }

    /*private UserActionStatResponse DailyCase(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        
    }
    
    private UserActionStatResponse MonthlyCase(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        
    }*/

    private UserActionStatItem WrapUserActionStatItem(DateTime startDate, DateGroupTypes dateGroupType)
    {
        UserActionStatItem result = new UserActionStatItem();
        result.ActionMetrics = new Dictionary<ActionTypes, int>();
        result.StartDate = startDate;

        switch (dateGroupType)
        {
            case DateGroupTypes.Daily:
                result.EndDate = startDate;
                break;
            case DateGroupTypes.Monthly:
                var year = startDate.Year;
                var month = startDate.Month;
                result.EndDate = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59, 999);
                break;
        }
        
        return result;
    }

    private void InsertActionItem(Dictionary<ActionTypes, int> dict, UserActionItem actionItem)
    {
        dict.TryAdd(actionItem.Action, 0);
        dict[actionItem.Action]++;
    }
}
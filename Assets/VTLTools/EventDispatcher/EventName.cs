using System.Collections.Generic;

public enum EventName
{
    NONE,
    OnBeforeGameStateChange,
    OnAfterGameStateChange,
}

public class EventTypeComparer : IEqualityComparer<EventName>
{
    public bool Equals(EventName x, EventName y)
    {
        return x == y;
    }

    public int GetHashCode(EventName t)
    {
        return (int)t;
    }
}

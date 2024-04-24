using System;
using System.Collections.Generic;

namespace Zoo;

public class Hours
{
    private readonly Dictionary<DayOfWeek, TimeRange> _hours;

    public Hours()
    {
        _hours = new System.Collections.Generic.Dictionary<DayOfWeek, TimeRange>();
        for (var day = 0; day < 7; day++)
            _hours.Add((DayOfWeek)day, default);
    }


    public TimeRange this[DayOfWeek d]
    {
        get => _hours[d];
        set => _hours[d] = value;

    }

    public Hours Set(DayOfWeek d, TimeRange time)
    {
        _hours[d] = time;
        return this;
    }

}

public readonly struct TimeRange
{
    private readonly TimeOnly _from;
    private readonly TimeOnly _to;

    public TimeRange(TimeOnly from, TimeOnly to)
    {
        _from = from;
        _to = to;
    }

    public TimeOnly From => _from;
    public TimeOnly To => _to;

    public override string ToString()
    {
        return $"{From} - {To}";
    }
}
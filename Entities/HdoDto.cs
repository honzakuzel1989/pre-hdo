namespace prehdo.Entities
{
    public class HdoDto
    {
        public HdoDto(string command, Day[] days, Date from, Date to)
        {
            Command = command;
            Days = days;
            From = from;
            To = to;
        }

        public string Command { get; }
        public Day[] Days { get; }
        public Date From { get; }
        public Date To { get; }
    }

    public class Day
    {
        public Day(string caption, TimeRange[] times)
        {
            Caption = caption;
            Times = times;
        }

        public string Caption { get; }
        public TimeRange[] Times { get; }
    }

    public class TimeRange
    {
        public TimeRange(Time start, Time end, Tarif tarif)
        {
            Start = start;
            End = end;
            Tarif = tarif;
        }

        public Time Start { get; }
        public Time End { get; }
        public Tarif Tarif { get; }

        public override string ToString()
        {
            return Tarif == Tarif.NT ? $"[{Start} - {End}]" : $"{Start} - {End}";
        }
    }

    public enum Tarif { UNDEFINED, NT, VT }

    public class Time
    {
        public Time(Hours hours, Minutes minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public Hours Hours { get; }
        public Minutes Minutes { get; }

        public override string ToString()
        {
            return $"{Hours}:{Minutes}";
        }
    }

    public class Hours
    {
        public Hours(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString("00");
        }
    }

    public class Minutes
    {
        public Minutes(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString("00");
        }
    }

    public class Date
    {
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public override string ToString()
        {
            return $"{Day.ToString("00")}.{Month.ToString("00")}.{Year}";
        }
    }
}

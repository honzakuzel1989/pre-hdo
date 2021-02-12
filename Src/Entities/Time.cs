namespace prehdo.Entities
{
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
}

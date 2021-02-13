namespace prehdo.Console.Entities
{
    public class Time
    {
        public Time(Hour hours, Minute minutes)
        {
            Hour = hours;
            Minute = minutes;
        }

        public Hour Hour { get; }
        public Minute Minute { get; }

        public override string ToString()
        {
            return $"{Hour}:{Minute}";
        }
    }
}

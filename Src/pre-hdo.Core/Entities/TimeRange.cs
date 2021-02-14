namespace prehdo.Console.Entities
{
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
            return $"{Start} - {End}";
        }
    }
}

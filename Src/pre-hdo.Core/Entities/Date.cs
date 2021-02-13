namespace prehdo.Console.Entities
{
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

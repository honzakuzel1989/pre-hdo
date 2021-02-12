namespace prehdo.Entities
{
    public class Hdo
    {
        public Hdo(string command, Day[] days, Date from, Date to)
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
}

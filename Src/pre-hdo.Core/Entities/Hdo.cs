using pre_hdo.Core.Entities;

namespace prehdo.Console.Entities
{
    public class Hdo
    {
        public Hdo(Command command, Day[] days, Date from, Date to)
        {
            Command = command;
            Days = days;
            From = from;
            To = to;
        }

        public Command Command { get; }
        public Day[] Days { get; }
        public Date From { get; }
        public Date To { get; }

        public override string ToString()
        {
            return $"{Command.Number} - {Command.Name}";
        }
    }
}

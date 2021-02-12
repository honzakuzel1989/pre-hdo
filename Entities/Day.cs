namespace prehdo.Entities
{
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
}

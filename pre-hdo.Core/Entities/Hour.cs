namespace prehdo.Console.Entities
{
    public class Hour
    {
        public Hour(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString("00");
        }

        public static implicit operator int(Hour h)
        {
            return h.Value;
        }
    }
}

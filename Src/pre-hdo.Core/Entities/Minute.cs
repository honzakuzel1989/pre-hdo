namespace prehdo.Console.Entities
{
    public class Minute
    {
        public Minute(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString("00");
        }

        public static implicit operator int(Minute m)
        {
            return m.Value;
        }
    }
}

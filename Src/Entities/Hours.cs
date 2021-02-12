namespace prehdo.Console.Entities
{
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
}

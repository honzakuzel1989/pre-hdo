namespace prehdo.Entities
{
    public class Minutes
    {
        public Minutes(int value)
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

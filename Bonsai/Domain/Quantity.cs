namespace Bonsai.Domain
{
    public class Quantity
    {
        public float Amount { get; set; }
        public string Unit { get; set; }

        //public static MeasurementUnit ParseMeasurementUnit(string unit)
        //{
        //    return Enum.TryParse(unit, out MeasurementUnit result) ? result : MeasurementUnit.UNIT;
        //}

        public override string ToString()
        {
            return $"{Amount}{Unit}";
        }
    }
}

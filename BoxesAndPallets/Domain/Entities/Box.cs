namespace BoxesAndPallets.Domain.Entities
{
    public class Box : BaseUnit
    {
        public Box(double width, double height, double depth, double weight, DateOnly dateOfManufacture) : base (width,height,depth)
        {
            Weight = weight > 0 ? weight : throw new ArgumentException(nameof(Weight) + " must be greater than 0");
            DateOfManufacture = dateOfManufacture;
        }
        
        public DateOnly? DateOfManufacture { get; protected set; } = null;
        public override DateOnly ExpirationDate { get => DateOfManufacture.Value.AddDays(100); }
        public override double Volume => Height * Width * Depth;
    }
}

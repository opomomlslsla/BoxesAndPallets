namespace BoxesAndPallets.Domain.Entities
{
    public abstract class BaseUnit
    {
        public BaseUnit(double width, double height, double depth)
        {
            Width = width > 0 ? width : throw new ArgumentException(nameof(Width) + " must be greater than 0");
            Height = height > 0 ? height : throw new ArgumentException(nameof(Height) + " must be greater than 0");
            Depth = depth > 0 ? depth : throw new ArgumentException(nameof(Depth) + " must be greater than 0");
        }
        abstract public DateOnly ExpirationDate { get; }
        public Guid Id { get; set; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }
        public double Depth { get; protected set; }
        public virtual double Weight { get; protected set; }
        abstract public double Volume { get; }
    }
}

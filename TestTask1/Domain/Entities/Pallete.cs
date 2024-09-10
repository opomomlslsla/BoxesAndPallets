using System.Text;

namespace BoxesAndPallets.Domain.Entities
{
    public class Pallete(double width, double height, double depth) : BaseUnit(width,height,depth)
    {
        public List<Box> Boxes { get; set; } = new List<Box>();
        public override DateOnly ExpirationDate => Boxes.Min(x => x.ExpirationDate);
        public override double Weight => Boxes.Sum(x => x.Weight) + 30;
        public override double Volume => Boxes.Sum(x => x.Volume) + Height * Depth * Width;
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Идентификатор: {Id}")
              .AppendLine($"Ширина: {Width}")
              .AppendLine($"Высота: {Height}")
              .AppendLine($"Глубина: {Depth}")
              .AppendLine($"Вес: {Weight}")
              .AppendLine($"Объём: {Volume}")
              .AppendLine($"Срок годности: {ExpirationDate}")
              .AppendLine($"Количество коробок внутри: {Boxes.Count}");
            return sb.ToString();
        }
    }
}

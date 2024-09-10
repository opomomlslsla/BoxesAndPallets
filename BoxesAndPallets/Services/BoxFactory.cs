using BoxesAndPallest.Extensions;
using BoxesAndPallets.Domain.Entities;
using BoxesAndPallets.Domain.Interfaces;

namespace BoxesAndPallets.Services
{
    public class BoxFactory : IBoxFactory
    {
        public Box GetOneBox()
        {
            bool addCreationDate = Random.Shared.Next(0, 1) == 0;
            var datetime = DateTime.Now;
            var creationDate = new DateOnly(datetime.Year,datetime.Month,datetime.Day).AddDays(-(Random.Shared.Next(1, 100)));
            var box = new Box(
                Random.Shared.GetRandomValue(1, 100),
                Random.Shared.GetRandomValue(1, 100),
                Random.Shared.GetRandomValue(1, 100),
                Random.Shared.GetRandomValue(1, 100),
                creationDate)
            { Id = Guid.NewGuid() };
            return box;
        }
    }
}

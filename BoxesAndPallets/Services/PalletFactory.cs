using Serilog;
using BoxesAndPallets.Domain.Entities;
using BoxesAndPallets.Domain.Interfaces;
using BoxesAndPallest.Extensions;

namespace BoxesAndPallets.Services
{
    public class PalletFactory(IBoxFactory boxFactory): IPalletFactory
    {

        public List<Pallete> GetPalletes(int count)
        {
            var pallets = new List<Pallete>();
            for (int i = 0; i < count; i++)
            {
                pallets.Add(CreateOnePallete());
            }
            return pallets;
        }

        public Pallete CreateOnePallete()
        {
            var boxes = new List<Box>();
            var n = Random.Shared.Next(1, 10);
            int failCount = 0;
            var pallete = new Pallete(
                Random.Shared.GetRandomValue(1, 100),
                Random.Shared.GetRandomValue(1, 100),
                Random.Shared.GetRandomValue(1, 100)) { Id = Guid.NewGuid() };

            while (boxes.Count < n)
            {
                var box = boxFactory.GetOneBox();
                if (box.Width < pallete.Width && box.Depth < pallete.Width)
                {
                    boxes.Add(box);
                }
                else
                {
                    failCount+=1;
                }
            }
            Log.Information($" проваленных попыток генерации - {failCount}");
            pallete.Boxes = boxes;
            return pallete;

        }

    }
}

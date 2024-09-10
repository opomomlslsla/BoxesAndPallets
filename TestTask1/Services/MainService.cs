using BoxesAndPallets.Domain.Entities;
using BoxesAndPallets.Domain.Interfaces;

namespace BoxesAndPallets.Services
{
    public class MainService(IPalletFactory palletService)
    {
        IPalletFactory _palletService = palletService;

        List<Pallete> pallets = new List<Pallete>();
        private bool IsValidNumber = false;
        private int numberOfPallets;

        public void Run () 
        {
            Console.WriteLine("Введите кол-во паллетов которые нужно сгенерировать: ");

            string s;
            while (!IsValidNumber) 
            {
                Console.WriteLine("Введите число: ");
                s = Console.ReadLine();
                IsValidNumber = int.TryParse(s, out numberOfPallets);
                if (IsValidNumber && numberOfPallets < 100000)
                {
                    pallets = _palletService.GetPalletes(numberOfPallets);
                    IsValidNumber = true;
                    ShowPallets(pallets);
                }
                else
                {
                    Console.WriteLine("Введенное число невалидно");
                }
            }
        }

        private void ShowPallets(List<Pallete> palletes)
        {
            var groups = palletes.GroupBy(x => x.ExpirationDate).ToList();
            var groupNumber = 1;
            foreach(var group in groups) 
            {
                var res = group.OrderBy(x => x.ExpirationDate).ThenBy(x => x.Weight).ToList();
                Console.WriteLine($"group {groupNumber}");
                foreach(Pallete p in res)
                {
                    Console.WriteLine(p.ToString());
                }
                groupNumber += 1;
            }

            Console.WriteLine(" 3 палеты с наибольшим сроком годности");
            var threePallets = palletes.OrderBy(x => x.ExpirationDate).ToList();
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine(threePallets[j].ToString());
            }
        }

    }
}

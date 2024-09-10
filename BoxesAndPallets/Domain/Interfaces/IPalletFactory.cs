using BoxesAndPallets.Domain.Entities;

namespace BoxesAndPallets.Domain.Interfaces
{
    public interface IPalletFactory
    {
        Pallete CreateOnePallete();
        List<Pallete> GetPalletes(int count);
    }
}
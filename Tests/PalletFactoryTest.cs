using BoxesAndPallets.Services;

namespace Tests
{
    public class PalletFactoryTest
    {
        PalletFactory PalletFactory = new PalletFactory(new BoxFactory());

        [Fact]
        public void CreateOnePalletTest()
        {
            var pallet = PalletFactory.CreateOnePallete();

            Assert.True(pallet != null);

            Assert.True(pallet.Depth > 0);

            Assert.True(pallet.Height > 0);

            Assert.True(pallet.Width > 0);

            Assert.True(pallet.Depth > 0);
        }
    }
}
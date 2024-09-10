using BoxesAndPallets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BoxFactoryTest
    {
        BoxFactory BoxFactory = new BoxFactory();

        [Fact]
        public void GetOneBoxTest()
        {
            var box = BoxFactory.GetOneBox();

            Assert.True(box != null);

            Assert.True(box.Depth > 0);

            Assert.True(box.Height > 0);

            Assert.True(box.Width > 0);

            Assert.True(box.Depth > 0);
        }
    }
}

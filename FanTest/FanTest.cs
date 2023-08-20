using Fan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FanTest
{
    [TestClass]
    public class FanTest 
    {
        private readonly ILogger<FanController> _logger;

        [TestMethod]
        public void Index()
        {
            var fanController = new FanController(_logger);
            var result = fanController.Index();
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Direction);

            Assert.IsNotNull(result.Speed);
        }


        [TestMethod]
        public void SpeedUp()
        {
            var fanController = new FanController(_logger);

            var result = fanController.SpeedUp();

            Assert.IsNotNull(result);

            var cspeed = result.Speed;

            for (var i = 0; i < 6; i++)
            {
                result = fanController.SpeedUp();

                Assert.IsNotNull(result);

                if (cspeed < 3)
                {
                    Assert.AreEqual(cspeed + 1, result.Speed);
                }
                else
                {
                    Assert.AreEqual(0, result.Speed);
                }
                cspeed = result.Speed;
            }
        }

        [TestMethod]
        public void Direction()
        {
            var fanController = new FanController(_logger);

            var result = fanController.Index();

            Assert.IsNotNull(result);

            var cdirection = result.Direction;

            for (var i = 0; i < 2; i++)
            {
                result = fanController.Reverse();

                Assert.IsNotNull(result);

                Assert.AreNotEqual(cdirection, result.Direction);
                cdirection = result.Direction;
            }
        }
    }
}
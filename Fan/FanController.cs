using Microsoft.AspNetCore.Mvc;

namespace Fan
{
    [Route("[controller]")]
    [ApiController]
    public class FanController : ControllerBase
    {
        private static int _speed = 0;
        private static bool _direction = true;
        private readonly ILogger<FanController> _logger;

        public FanController(ILogger<FanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public FanModel Index()
        {
            var model = new FanModel();
            model.Direction = _direction;
            model.Speed = _speed;

            return model;
        }

        [HttpGet]
        [Route("SpeedUp")]
        public FanModel SpeedUp()
        {
            _speed = _speed > 2 ? 0 : ++_speed;

            var model = new FanModel();
            model.Direction = _direction;
            model.Speed = _speed;

            return model;
        }

        [HttpGet]
        [Route("Reverse")]
        public FanModel Reverse()
        {
            _direction = !_direction;

            var model = new FanModel();
            model.Direction = _direction;
            model.Speed = _speed;

            return model;
        }
    }
}

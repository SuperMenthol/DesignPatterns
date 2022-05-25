namespace Mediator.Model
{
    public class Aircraft
    {
        private int _id { get; set; }
        private LaneController _controller { get; set; }
        private Lane? _occupiedLane { get; set; }

        private Random _random;

        public Aircraft(int id, LaneController controller)
        {
            _id = id;
            _controller = controller;

            _random = new Random();
        }

        public async Task Begin()
        {
            var laneId = _random.Next(0, _controller.LanesCount);
            await AskForLanding(laneId);
            await Task.Delay(_random.Next(3000, 6000));
        }

        public async Task AskForLanding(int laneId)
        {
            Console.WriteLine($"Tower, aircraft {_id} speaking. Can we land on lane {laneId}");
            _occupiedLane = _controller.IsLaneVacant(laneId);
            if (_occupiedLane != null)
            {
                Console.WriteLine($"Aircraft {_id}, landing on lane {laneId}. Over and out.");
                Land();

                await Task.Delay(_random.Next(3000,6000));
                Takeoff();
                await Task.Delay(_random.Next(3000, 6000));
                await AskForLanding(_random.Next(0, _controller.LanesCount));
            }

            Console.WriteLine($"Aircraft {_id}, landing impossible. Over.");

            await Task.Delay(3000);

            await AskForLanding(_random.Next(0, _controller.LanesCount));
        }

        private void Land()
        {
            _occupiedLane.AircraftParked = this;
        }

        private void Takeoff()
        {
            Console.WriteLine($"Tower, this is aircraft {_id}, taking off from lane {_occupiedLane.Id}. Over and out.");
            _occupiedLane.AircraftParked = null;
            _occupiedLane = null;
        }
    }
}
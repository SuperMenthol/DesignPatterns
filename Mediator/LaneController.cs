using Mediator.Model;

namespace Mediator
{
    public class LaneController
    {
        private List<Lane> _lanes = new List<Lane>();
        public int LanesCount => _lanes.Count;

        public LaneController()
        {
            InitializeLanes();
        }

        public Lane? IsLaneVacant(int laneId)
        {
            return _lanes[laneId].AircraftParked is null ? _lanes[laneId] : null;
        }

        private void InitializeLanes()
        {
            for (int i = 0; i < 5; i++)
            {
                _lanes.Add(new Lane()
                {
                    Id = i,
                    AircraftParked = null
                });
            }
        }
    }
}

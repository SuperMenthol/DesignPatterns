using Mediator.Model;

namespace Mediator
{
    public static class Program
    {
        static List<Aircraft> _aircrafts = new List<Aircraft>();

        public static async Task Main(string[] args)
        {
            var laneCtrl = new LaneController();

            for (int i = 0; i < 7; i++)
            {
                _aircrafts.Add(new Aircraft(i, laneCtrl));
            }

            await Task.WhenAll(_aircrafts.Select(x => x.Begin()));
        }
    }
}
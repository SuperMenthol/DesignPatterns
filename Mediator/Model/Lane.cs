namespace Mediator.Model
{
    public class Lane
    {
        public int Id { get; set; }
        public Aircraft? AircraftParked { get; set; } = null;
    }
}
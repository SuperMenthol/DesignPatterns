namespace Flyweight.ValueObjects
{
    public class PhysicalInfo
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string ModelName { get; set; }
        public string VersionInformation { get; set; }
        public float MaxRunningVelocity { get; set; }
        public float MaxSwimmingVelocity { get; set; }
        public bool CanSwim { get; set; }
    }
}
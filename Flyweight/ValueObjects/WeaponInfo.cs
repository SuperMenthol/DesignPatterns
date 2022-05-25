using Flyweight.Enum;

namespace Flyweight.ValueObjects
{
    public class WeaponInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
    }
}
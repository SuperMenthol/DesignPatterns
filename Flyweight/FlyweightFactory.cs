using Flyweight.Model;
using Flyweight.ValueObjects;

namespace Flyweight
{
    public static class FlyweightFactory
    {
        private static PhysicalInfo _autobotPhysicalInfo = new PhysicalInfo()
        {
            Height = 180,
            Width = 100,
            CanSwim = true,
            MaxRunningVelocity = 30,
            MaxSwimmingVelocity = 20,
            ModelName = "Autobot Mk3",
            VersionInformation = "v1.0.0.12"
        };

        private static WeaponInfo _mainWeapon = new WeaponInfo()
        {
            Name = "Main carbine",
            Version = "v1.0.13",
            Damage = 15,
            Range = 30,
            WeaponType = Enum.WeaponType.Ballistic
        };

        private static WeaponInfo _secondaryWeapon = new WeaponInfo()
        {
            Name = "Secondary pistol",
            Version = "v0.9.0",
            Damage = 7,
            Range = 18,
            WeaponType = Enum.WeaponType.Ballistic
        };

        private static WeaponInfo _meleeWeapon = new WeaponInfo()
        {
            Name = "Hammer",
            Version = "v11.3.9",
            Damage = 3,
            Range = 2,
            WeaponType = Enum.WeaponType.Melee
        };

        private static WeaponInfo _grenade = new WeaponInfo()
        {
            Name = "Hand grenade",
            Version = "v1",
            Damage = 25,
            Range = 5,
            WeaponType = Enum.WeaponType.Projectile
        };

        private static List<WeaponInfo> _weapons = new List<WeaponInfo>()
        {
            _mainWeapon, _secondaryWeapon, _meleeWeapon, _grenade
        };

        public static Autobot Generate(int height, int width, string modelName, string versionInfo, 
            float maxRun, float maxSwim, bool canSwim, string color, string name, 
            WeaponInfo mainWeapon, WeaponInfo secondaryWeapon, WeaponInfo melee, WeaponInfo grenade)
        {
            var wepList = new List<WeaponInfo>() { mainWeapon, secondaryWeapon, melee, grenade };
            return new Autobot(height, width, modelName, versionInfo, maxRun, maxSwim, canSwim, color, name, wepList);
        }

        public static Autobot_fw Generate(string color, string name)
        {
            return new Autobot_fw(_autobotPhysicalInfo, color, name, _weapons);
        }
    }
}

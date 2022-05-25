using Flyweight;
using Flyweight.Enum;
using Flyweight.Model;
using Flyweight.ValueObjects;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var a = GetMillionAutobots();
            var a = GetMillionLightweightAutobots();

            foreach (var bot in a)
            {
                bot.Grow(191);
            }
        }

        private static List<Autobot> GetMillionAutobots()
        {
            var result = new List<Autobot>();

            for (int i = 0; i < 1000000; i++)
            {
                WeaponInfo _mainWeapon = new WeaponInfo()
                {
                    Name = "Main carbine",
                    Version = "v1.0.13",
                    Damage = 15,
                    Range = 30,
                    WeaponType = WeaponType.Ballistic
                };

                WeaponInfo _secondaryWeapon = new WeaponInfo()
                {
                    Name = "Secondary pistol",
                    Version = "v0.9.0",
                    Damage = 7,
                    Range = 18,
                    WeaponType = WeaponType.Ballistic
                };

                WeaponInfo _meleeWeapon = new WeaponInfo()
                {
                    Name = "Hammer",
                    Version = "v11.3.9",
                    Damage = 3,
                    Range = 2,
                    WeaponType = WeaponType.Melee
                };

                WeaponInfo _grenade = new WeaponInfo()
                {
                    Name = "Hand grenade",
                    Version = "v1",
                    Damage = 25,
                    Range = 5,
                    WeaponType = WeaponType.Projectile
                };

                if (i % 500 == 0)
                {
                    Console.WriteLine($"{i} heavy autobots have been created");
                }
                result.Add(FlyweightFactory.Generate(180, 100, "Autobot Mk3", "v1.0.0.12", 
                    30, 20, true, "red", $"Heavy autobot no {i}", 
                    _mainWeapon, _secondaryWeapon, _meleeWeapon, _grenade));
            }

            return result;
        }

        private static List<Autobot_fw> GetMillionLightweightAutobots()
        {
            var result = new List<Autobot_fw>();

            for (int i = 0; i < 1000000; i++)
            {
                if (i % 500 == 0)
                {
                    Console.WriteLine($"{i} lightweight autobots have been created");
                }
                result.Add(FlyweightFactory.Generate("blue", $"Lightweight autobot no {i}"));
            }

            return result;
        }
    }
}
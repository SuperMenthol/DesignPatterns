using Flyweight.Abstracts;
using Flyweight.ValueObjects;

namespace Flyweight.Model
{
    public class Autobot : Bot
    {
        private int Height;
        private int Width;
        private string ModelName;
        private string VersionInformation;
        private float MaxRunningVelocity;
        private float MaxSwimmingVelocity;
        private bool CanSwim;
        private string Color;
        private string Name;

        private List<WeaponInfo> Weapons;

        public Autobot(int height, int width, string modelName, string versionInfo, float maxRun, float maxSwim, bool canSwim, string color, string name, List<WeaponInfo> weaponList)
        {
            Height = height;
            Width = width;
            ModelName = modelName;
            VersionInformation = versionInfo;
            MaxRunningVelocity = maxRun;
            MaxSwimmingVelocity = maxSwim;
            CanSwim = canSwim;
            Color = color;
            Name = name;

            Weapons = weaponList;
        }

        public override void Grow(int targetHeight)
        {
            if (Height != targetHeight)
            {
                Height = targetHeight;
            }
        }
    }
}
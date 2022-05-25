using Flyweight.Abstracts;
using Flyweight.ValueObjects;

namespace Flyweight.Model
{
    public class Autobot_fw : Bot
    {
        private PhysicalInfo _physicalInfo;
        private string _name;

        private List<WeaponInfo> Weapons;

        public Autobot_fw(PhysicalInfo physicalInfo, string color, string name, List<WeaponInfo> weapons)
        {
            _physicalInfo = physicalInfo;
            _color = color;
            _name = name;

            Weapons = weapons;
        }

        public override void Grow(int targetHeight)
        {
            if (_physicalInfo.Height != targetHeight)
            {
                _physicalInfo.Height = targetHeight;
            }
        }
    }
}
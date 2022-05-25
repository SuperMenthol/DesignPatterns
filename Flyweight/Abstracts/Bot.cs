namespace Flyweight.Abstracts
{
    public abstract class Bot
    {
        private int location;
        protected string _color;
        public virtual void Move(int steps)
        {
            location += steps;
        }

        public abstract void Grow(int cm);

        public void ChangeColor(string color)
        {
            _color = color;
        }
    }
}
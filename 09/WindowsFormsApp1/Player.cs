using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Player
    {
        private Vector2 _screenSize;
        public float X { get; private set; }
        public float Y { get; private set; }
        public Color Color { get; private set; }
        public Vector2 Size { get; private set; }
        public float Speed { get; private set; }
        public bool Human { get; private set; }
        public Player(float x, float y, Vector2 size, Color color, bool human, Vector2 screenSize)
        {
            X = x;
            Y = y;
            Size = size;
            Color = color;
            Human = human;
            _screenSize = screenSize;
            Speed = 3;
        }
        public void Update(bool left, bool right)
        {
            if (left && !right)
                if (X - Speed > 0) X -= Speed;
            if (!left && right)
                if (X + Speed + Size.X < _screenSize.X) X += Speed;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Size.X, Size.Y);
        }
    }
}

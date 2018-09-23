using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Ball
    {
        private Vector2 _screenSize;
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }
        public Vector2 Speed { get; private set; }
        public Vector2 Size { get; private set; }
        public Ball(Vector2 screenSize, Vector2 size, Vector2 speed)
        {
            X = (screenSize.X - size.X) / 2;
            Y = (screenSize.Y - size.Y) / 2;
            _screenSize = screenSize;
            Size = size;
            Speed = speed;
            Color = Color.Green;
        }
        public void Update()
        {
            if (X + Speed.X < 0 || X + Speed.X + Size.X > _screenSize.X) Speed.X *= -1;
            if (Y + Speed.Y < 0 || Y + Speed.Y + Size.Y > _screenSize.Y) Speed.Y *= -1;
            X += Speed.X;
            Y += Speed.Y;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, X, Y, Size.X, Size.Y);
        }
    }
}

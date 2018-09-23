using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Player player1;
        Player player2;
        Ball ball;
        bool _left1;
        bool _right1;
        bool _left2;
        bool _right2;
        int _menu;
        private Vector2 _playerSize;
        private Vector2 _ballSize;
        private Vector2 _screenSize;
        System.Threading.Timer _timer1;
        System.Threading.Timer _timer2;
        public Form1()
        {
            InitializeComponent();
            _screenSize = new Vector2(pictureBox1.Width, pictureBox1.Height);
            _playerSize = new Vector2(80, 10);
            _ballSize = new Vector2(50, 50);
        }
        public void Update(object sender)
        {
            if (ball.Y + ball.Size.Y > player1.Y)
            {
                if (ball.X > player1.X + player1.Size.X ||
                ball.X + ball.Size.X < player1.X)
                {
                    if (ball.Y + ball.Size.Y + ball.Speed.Y >= _screenSize.Y) goal();
                }
                else
                {
                    ball.Y -= 3;
                    ball.Speed.Y *= -1;
                    ball.Color = player2.Color;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("bounce.wav");
                    player.Play();
                }
            }
            if (ball.Y < player2.Y + player2.Size.Y)
            {
                if (ball.X > player2.X + player2.Size.X ||
                ball.X + ball.Size.X < player2.X)
                {
                    if (ball.Y + ball.Speed.Y <= 0) goal();
                }
                else
                {
                    ball.Y += 3;
                    ball.Speed.Y *= -1;
                    ball.Color = player1.Color;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("bounce.wav");
                    player.Play();
                }
            }

            if (ball.Y + ball.Size.Y / 2 >= player1.Y &&
                (ball.X <= player1.X + player1.Size.X && ball.X + ball.Size.X > player1.X + player1.Size.X ||
                ball.X + ball.Size.X >= player1.X && ball.X < player1.X))
            {
                ball.Speed.X *= -1;
                ball.Speed.Y *= -1;
                ball.Color = player1.Color;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("bounce.wav");
                player.Play();
            }
            if (ball.Y + ball.Size.Y / 2 <= player2.Y + player2.Size.Y &&
                (ball.X <= player2.X + player2.Size.X && ball.X + ball.Size.X > player2.X + player2.Size.X ||
                ball.X + ball.Size.X >= player2.X && ball.X < player2.X))
            {
                ball.Speed.X *= -1;
                ball.Speed.Y *= -1;
                ball.Color = player2.Color;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("bounce.wav");
                player.Play();
            }

            if (_menu == 1)
            {
                player1.Update(_left1, _right1);
                player2.Update(_left2, _right2);
            }
            else if (_menu == 2)
            {
                player1.Update(_left1, _right1);
                if (ball.X + ball.Size.X < player2.X + player2.Size.X / 3)
                    player2.Update(true, false);
                else if (ball.X > player2.X + player2.Size.X / 3 * 2) player2.Update(false, true);
            }
            else
            {
                if (ball.X + ball.Size.X < player1.X + player1.Size.X / 5)
                    player1.Update(true, false);
                else if (ball.X > player1.X + player2.Size.X / 5 * 4) player1.Update(false, true);
                if (ball.X + ball.Size.X < player2.X + player2.Size.X / 5)
                    player2.Update(true, false);
                else if (ball.X > player2.X + player2.Size.X / 5 * 4) player2.Update(false, true);
            }
            ball.Update();
        }
        public void goal()
        {
            ball.X = (_screenSize.X - ball.Size.X) / 2;
            ball.Y = (_screenSize.Y - ball.Size.Y) / 2;
            ball.Color = Color.Green;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("goal.wav");
            player.Play();
        }

        private void Draw(object sender)
        {
            Bitmap bmp = new Bitmap((int)_screenSize.X, (int)_screenSize.Y);
            Graphics g = Graphics.FromImage(bmp);
            player1.Draw(g);
            player2.Draw(g);
            ball.Draw(g);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Image = bmp;
                });
            }
            catch (Exception) { }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_menu == 1)
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _left1 = true;
                        break;
                    case Keys.Right:
                        _right1 = true;
                        break;
                    case Keys.A:
                        _left2 = true;
                        break;
                    case Keys.D:
                        _right2 = true;
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _left1 = true;
                        break;
                    case Keys.Right:
                        _right1 = true;
                        break;
                }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (_menu == 1)
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _left1 = false;
                        break;
                    case Keys.Right:
                        _right1 = false;
                        break;
                    case Keys.A:
                        _left2 = false;
                        break;
                    case Keys.D:
                        _right2 = false;
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _left1 = false;
                        break;
                    case Keys.Right:
                        _right1 = false;
                        break;
                }
        }

        private void PvP_Click(object sender, EventArgs e)
        {
            _menu = 1;
            GameStart();
        }

        private void PvE_Click(object sender, EventArgs e)
        {
            _menu = 2;
            GameStart();
        }
        private void EvE_Click_1(object sender, EventArgs e)
        {
            _menu = 3;
            GameStart();
        }
        private void GameStart()
        {
            Random random = new Random();
            PvE.Dispose();
            PvP.Dispose();
            panel1.Dispose();
            ball = new Ball(_screenSize, _ballSize, new Vector2());
            while (ball.Speed.X == 0)
                ball.Speed.X = random.Next(-3, 3);
            while (ball.Speed.Y == 0)
                ball.Speed.Y = random.Next(-3, 3);
            if (_menu == 1)
            {
                player1 = new Player((_screenSize.X - _playerSize.X) / 2, _screenSize.Y - _playerSize.Y, _playerSize, Color.Blue, true, _screenSize);
                player2 = new Player((_screenSize.X - _playerSize.X) / 2, 0, _playerSize, Color.Red, true, _screenSize);
            }
            else if (_menu == 2)
            {
                player1 = new Player((_screenSize.X - _playerSize.X) / 2, _screenSize.Y - _playerSize.Y, _playerSize, Color.Blue, true, _screenSize);
                player2 = new Player((_screenSize.X - _playerSize.X) / 2, 0, _playerSize, Color.Red, false, _screenSize);
            }
            else
            {
                player1 = new Player((_screenSize.X - _playerSize.X) / 2, _screenSize.Y - _playerSize.Y, _playerSize, Color.Blue, false, _screenSize);
                player2 = new Player((_screenSize.X - _playerSize.X) / 2, 0, _playerSize, Color.Red, false, _screenSize);
            }
            _timer1 = new System.Threading.Timer(Update, null, 0, 1);
            _timer2 = new System.Threading.Timer(Draw, null, 0, 1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _timer1.Dispose();
                _timer2.Dispose();
            }
            catch (Exception) { }
        }

    }
    public class Vector2
    { 
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2()
        {
            X = 0;
            Y = 0;
        }
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}

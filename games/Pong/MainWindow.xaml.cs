using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pong
{
    public partial class MainWindow : Window
    {
        Random random = new Random();

        bool multiplayer = false;

        int scoreLeft = 0;
        int scoreRight = 0;

        double startVel = 3;
        double velocityLeft = 0;
        double velocityRight = 0;

        double speed = 2;

        int magicNumber = 39; // No, I do NOT have an answer for this
        int magicNumberSide = 15; // IG if it works, there is no reason to change it.

        Vector velocityBall;

        public MainWindow()
        {
            InitializeComponent();
            lbl_score.Content = $"{scoreLeft} : {scoreRight}";
            int number = random.Next(2);
            velocityBall = new Vector(number*2-1, (random.NextDouble()-0.5)*5);
            velocityBall.Normalize();
            velocityBall = velocityBall * speed;

            paddleLeft.Margin = new Thickness(20, (Height-paddleLeft.Height)/2, 0, 0);
            paddleRight.Margin = new Thickness(0, (Height - paddleRight.Height) / 2, 20, 0);
            ball.Margin = new Thickness((Width - ball.Width) / 2, (Height - magicNumber - ball.Width) / 2, 0, 0);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Thickness m;

            velocityBall.Normalize();
            velocityBall = velocityBall * speed;

            // Paddle move
            
            if (!multiplayer)
            {
                if (ball.Margin.Top + ball.Height < paddleRight.Margin.Top)
                {
                    velocityRight = -startVel * 0.6;
                }
                else if (ball.Margin.Top > paddleRight.Margin.Top + paddleRight.Height)
                {
                    velocityRight = startVel * 0.6;
                }
                else
                {
                    velocityRight = 0;
                }
            }

            m = paddleLeft.Margin;
            m.Top = Math.Clamp(m.Top + velocityLeft, 0, Height - paddleLeft.Height - magicNumber);
            paddleLeft.Margin = m;

            m = paddleRight.Margin;
            m.Top = Math.Clamp(m.Top + velocityRight, 0, Height - paddleRight.Height - magicNumber);
            paddleRight.Margin = m;

            m = ball.Margin;
            m.Top += velocityBall.Y;
            m.Left += velocityBall.X;
            ball.Margin = m;

            // Score
            
            if (ball.Margin.Left < 0)
            {
                ball.Margin = new Thickness((Width-ball.Width)/2, (Height-magicNumber-ball.Width)/2, 0, 0);
                scoreRight++;
                speed += 0.5;
                velocityBall = new Vector(1, (random.NextDouble() - 0.5) * 5);
                velocityBall.Normalize();
                velocityBall = velocityBall * speed;
            }
            if (ball.Margin.Left > Width - ball.Width - magicNumberSide)
            {
                ball.Margin = new Thickness((Width - ball.Width) / 2, (Height - magicNumber - ball.Width) / 2, 0, 0);
                scoreLeft++;
                speed += 0.5;
                velocityBall = new Vector(-1, (random.NextDouble() - 0.5) * 5);
                velocityBall.Normalize();
                velocityBall = velocityBall * speed;
            }
            lbl_score.Content = $"{scoreLeft} : {scoreRight}";

            // Bounce
            if (ball.Margin.Left < 20 + paddleLeft.Width && ball.Margin.Left - ball.Width > 20 && ball.Margin.Top > paddleLeft.Margin.Top - ball.Height && ball.Margin.Top < paddleLeft.Margin.Top + paddleLeft.Height)
            {
                velocityBall.X = Math.Abs(velocityBall.X);
                speed += 0.1;
            }
            if (ball.Margin.Left > Width - ball.Width - paddleRight.Width - 20 - magicNumberSide && ball.Margin.Left < Width - magicNumberSide - 20 && ball.Margin.Top > paddleRight.Margin.Top - ball.Height && ball.Margin.Top < paddleRight.Margin.Top + paddleRight.Height)
            {
                velocityBall.X = -Math.Abs(velocityBall.X);
                speed += 0.1;
            }

            if (ball.Margin.Top < 0)
            {
                velocityBall.Y = Math.Abs(velocityBall.Y);
            }
            if (ball.Margin.Top > Height - ball.Height - magicNumber)
            {
                velocityBall.Y = -Math.Abs(velocityBall.Y);
            }

            // Color ball
            if (velocityBall.X > 0)
            {
                ball.Fill = Brushes.Blue;
            }
            else
            {
                ball.Fill = Brushes.Red;
            }
        }

        private void MultiplayerToggled(object sender, RoutedEventArgs e)
        {
            multiplayer = cb_multiplayer.IsChecked ?? false;
            velocityRight = 0;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.S)
            {
                if (e.Key == Key.W)
                {
                    velocityLeft = -startVel;
                }
                if (e.Key == Key.S)
                {
                    velocityLeft = startVel;
                }
            }

            if (multiplayer)
            {
                if (e.Key == Key.Up || e.Key == Key.Down)
                {
                    if (e.Key == Key.Up)
                    {
                        velocityRight = -startVel;
                    }
                    if (e.Key == Key.Down)
                    {
                        velocityRight = startVel;
                    }
                }
            }
        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.S)
            {
                velocityLeft = 0;
            }

            if (multiplayer)
            {
                if (e.Key == Key.Up || e.Key == Key.Down)
                {
                    velocityRight = 0;
                }
            }
            
        }
    }
}

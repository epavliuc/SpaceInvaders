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
using System.Drawing;

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimes = new DispatcherTimer();
        Enemies ene;
        Bullet bul;
        List<Enemies> allenemy = new List<Enemies>();
        List<Bullet> allbullets = new List<Bullet>();

        //main
        public MainWindow()
        {
            InitializeComponent();
            Timer();
            RepeatSpawn();

        }

        //Timer to run specified methods
        public void Timer()
        {
            gameTimes.Interval = new TimeSpan(0, 0, 0, 0, 10);
            gameTimes.Tick += AnimationTick;
            gameTimes.Start();

        }

        //Method used by timer.
        private void AnimationTick(object sender, EventArgs e)
        {
            Animation(allenemy);
            AnimateBulet(allbullets);
            CollisionDetection(allenemy, allbullets);
        }

        public void CollisionDetection(List<Enemies> allenemy, List<Bullet> allbullets)
        {
            foreach (Enemies e in allenemy)
            {
                Ellipse enemy = e.Enemy;
                double top = Canvas.GetTop(enemy);
                double left = Canvas.GetLeft(enemy);
                ASDF:;
                try
                {
                    foreach (Bullet b in allbullets)
                    {
                        Ellipse bullet = b.Bullets;
                        double topB = Canvas.GetTop(bullet);
                        double leftB = Canvas.GetLeft(bullet);
                        try
                        {
                            if ((topB == top) && (leftB >= (left) && leftB <= (left + 30)))
                            {
                                e.Hp = e.Hp - b.Dmg;
                                square.Children.Remove(bullet);
                                allbullets.Remove(b);
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    goto ASDF;
                }

                }
            }
        



        public List<Bullet> SpawnBullet(Bullet bul)
        {
            Canvas.SetLeft(bul.Bullets, (Canvas.GetLeft(player) + 22.5));
            Canvas.SetTop(bul.Bullets, (Canvas.GetTop(player)));
            square.Children.Add(bul.Bullets);
            allbullets.Add(bul);

            return allbullets;
        }
        public void AnimateBulet(List<Bullet> bullList)
        {
            foreach (Bullet b in bullList)
            {
                double currentTop = Canvas.GetTop(b.Bullets);

                Ellipse bulletShape = b.Bullets;

                if (b.Hit == false)
                {
                    Canvas.SetTop(bulletShape, currentTop -= 10);
                }

            }
        }



        //Spawn enemies and add them to a list.
        public void SpawnEnemy(Enemies ene, int lft, int top)
        {

            Canvas.SetLeft(ene.Enemy, lft);
            Canvas.SetTop(ene.Enemy, top);
            square.Children.Add(ene.Enemy);
            allenemy.Add(ene);
        }

        Random rnd = new Random();
        //Control how many enemies spawn.
        public void RepeatSpawn()
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            for (int i = 0; i <= 1000; i += 35)
            {
                ene = new Enemies();

                int rndNr = rnd.Next(0, 100);
                int topValue;
                if (rndNr >= 66)
                {
                    topValue = 100;

                }
                else if (rndNr >= 33)
                {
                    topValue = 50;
                    ene.Direction = false;
                }
                else
                {
                    topValue = 0;
                }
                int leftValue = i;
                mainWindow.SpawnEnemy(ene, leftValue, topValue);
            }
        }

        //Animation for each enemy from the list.
        public void Animation(List<Enemies> enemyList)
        {
            foreach (Enemies oj in enemyList)
            {

                Ellipse enyShape = oj.Enemy;
                double currentLeft = Canvas.GetLeft(enyShape);
                double currentTop = Canvas.GetTop(enyShape);

                if (oj.Hp > 0)
                {
                    if (oj.Direction == true)
                    {
                        Canvas.SetLeft(enyShape, currentLeft += 1);
                    }
                    else
                    {
                        Canvas.SetLeft(enyShape, currentLeft -= 1);
                    }

                    if (currentLeft >= square.ActualWidth | currentLeft == -50)
                    {
                        Canvas.SetTop(enyShape, currentTop += 50);
                        oj.Direction = !oj.Direction;
                    }
                }
                else
                {
                    square.Children.Remove(enyShape);
                }

                if (oj.Hp == 50)
                {
                    enyShape.Fill = Brushes.Yellow;
                }
               
            }
        }
        public bool keypress = false;
        //Player Control, left to right. + boundaries
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double x = Canvas.GetLeft(player);
            //move player from side to side
            if (x > 0 & x < 600)
            {
                if (e.Key == Key.Left)
                {
                    Canvas.SetLeft(player, x -= 10);
                }
                else if (e.Key == Key.Right)
                {
                    Canvas.SetLeft(player, x += 10);
                }
            }
            else if (x <= 0)
            {
                Canvas.SetLeft(player, x + 10);
            }
            else if (x >= 600)
            {
                Canvas.SetLeft(player, x - 10);
            }

            //spawn bullet on spacebar press.
            if(keypress == false)
            {
                if (e.Key == Key.Space)
                {
                    bul = new Bullet();
                    AnimateBulet(SpawnBullet(bul));
                    keypress = true;
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                keypress = false;
            }
        }
    }

    public class Enemies
    {
        public Ellipse enemy;
        public int hp;
        public bool direction;

        public Enemies()
        {
            this.enemy = new Ellipse();
            this.hp = 100;
            enemy.Width = 30;
            enemy.Height = 30;
            enemy.Fill = Brushes.Red;
            direction = true;
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public Ellipse Enemy
        {
            get { return enemy; }
        }

        public bool Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }

    public class Bullet
    {
        Ellipse bullet;
        int dmg;
        bool hit;

        public Bullet()
        {
            bullet = new Ellipse();
            dmg = 50;
            bullet.Width = 5;
            bullet.Height = 15;
            bullet.Fill = Brushes.Black;
            hit = false;
        }

        public Ellipse Bullets
        {
            get { return bullet; }
            //set { bullet = value; }
        }

        public int Dmg
        {
            get { return dmg; }
            //set { bullet = value; }
        }

        public bool Hit
        {
            get { return hit; }
            set { hit = value; }
        }

    }
}

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

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimes = new DispatcherTimer();
        Enemies ene;
        List<Enemies> allenemy = new List<Enemies>();
        public MainWindow()
        {
            InitializeComponent();
            Timer();
            RepeatSpawn();
        }

        public void Timer()
        {
            gameTimes.Interval = new TimeSpan(0, 0, 0, 0,10);
            gameTimes.Tick += AnimationTick;
            gameTimes.Start();
        }

        private void AnimationTick(object sender, EventArgs e)
        {
            Animation(allenemy);
        }

        public void RepeatSpawn()
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            for (int i = 0; i <= 600; i+=35)
            {
                ene = new Enemies();
                mainWindow.SpawnEnemy(ene,i);
            }
        }
        public void SpawnEnemy(Enemies ene,int lft)
        {
            
                Canvas.SetLeft(ene.Enemy, lft);
                Canvas.SetTop(ene.Enemy, 0);
                square.Children.Add(ene.Enemy);
                allenemy.Add(ene);
        }
        public void Animation(List<Enemies> enemyList)
        {
            
            foreach(Enemies oj in enemyList)
            {
                Ellipse enyShape = oj.Enemy;
                double currentLeft = Canvas.GetLeft(enyShape);
                double currentTop = Canvas.GetTop(enyShape);

                if (oj.Direction == true)
                {
                    Canvas.SetLeft(enyShape, currentLeft += 1);
                }
                else
                {
                    Canvas.SetLeft(enyShape, currentLeft -= 1);
                }
                
                if(currentLeft == square.ActualWidth | currentLeft == -50)
                {
                    Canvas.SetTop(enyShape, currentTop += 50);
                    oj.Direction = !oj.Direction;
                }

            }
        }

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
            }else if (x <= 0)
            {
                Canvas.SetLeft(player, x + 10);
            }
            else if (x >= 600)
            {
                Canvas.SetLeft(player, x - 10);
            }

            //spawn bullet on spacebar press
            if(e.Key == Key.Space)
            {
                Console.Beep();
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
            //mainWindow.SpawnEnemy(enemy);
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
        Ellipse bullet = new Ellipse();
        int speed = 100;
        int dmg = 50;

        

        public Ellipse Bullets
        {
            get { return bullet; }
            //set { bullet = value; }
        }

    }
}

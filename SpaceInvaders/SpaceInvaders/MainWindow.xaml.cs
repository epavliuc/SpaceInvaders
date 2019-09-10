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
        List<Ellipse> allenemy = new List<Ellipse>();
        public MainWindow()
        {
            InitializeComponent();
            Timer();
            RepeatSpawn();
        }

        public void Timer()
        {
            gameTimes.Interval = new TimeSpan(0, 0, 0, 0,700);
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
            for (int i = 0; i <= 500; i+=50)
            {
                ene = new Enemies();
                mainWindow.SpawnEnemy(ene.Enemy,i);
            }
        }
        public void SpawnEnemy(Ellipse ene,int lft)
        {
            
                Canvas.SetLeft(ene, lft);
                Canvas.SetTop(ene, 0);
                square.Children.Add(ene);
                allenemy.Add(ene);
        }
        public void Animation(List<Ellipse> enemyList)
        {
            foreach(Ellipse oj in enemyList)
            {
                double currentLeft = Canvas.GetLeft(oj);
                Canvas.SetLeft(oj, currentLeft += 10);
            }
        }

        //Player Control, left to right. + boundaries
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {          
            double x = Canvas.GetLeft(player);
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
        }

    }

    public class Enemies
    {
        public Ellipse enemy;
        public int hp;

        
        public Enemies()
        {
            this.enemy = new Ellipse();
            this.hp = 100;
            enemy.Width = 35;
            enemy.Height = 35;
            enemy.Fill = Brushes.Red;
            //mainWindow.SpawnEnemy(enemy);
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public Ellipse Enemy
        {
            get { return this.enemy; }
        }

    }
}

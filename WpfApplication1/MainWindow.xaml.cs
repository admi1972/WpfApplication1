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

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double vx = 1;
        double vy = 1;
        double x;
        double y;
        int HitIndex;

        int a = 43;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.IsEnabled = true;
            timer.Tick += animate;
           
        }

        void animate(object sender, EventArgs e)
        {
           
            x = Canvas.GetLeft(Ball);
            y = Canvas.GetTop(Ball);
            if(x == 0.0 || x >= myCanvas.ActualWidth - Ball.Width)
            {
                vx = -vx;
            }
            


           if(y == 0.0 || y >= myCanvas.ActualHeight - Ball.Width)
            {
                vy = -vy;
            }

            //(Canvas.GetTop(RSchläger) <= Canvas.GetTop(Ball)) && (Canvas.GetTop(RSchläger) + RSchläger.ActualHeight >= Canvas.GetTop(Ball)) && 
            if (((myCanvas.ActualWidth - x-20) == 10)) //&& (Canvas.GetTop(RSchläger) <= Canvas.GetTop(Ball)))// && (Canvas.GetTop(RSchläger) + RSchläger.ActualHeight >= Canvas.GetTop(Ball)))
            {
                vx = -vx;
                HitIndex++;
            }

            x += vx * timer.Interval.TotalMilliseconds;
            y += vy * timer.Interval.TotalMilliseconds;
            Canvas.SetLeft(Ball, x);
            Canvas.SetTop(Ball, y);


        }

        void Window_Mousemove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            Canvas.SetRight(RSchläger, 10);
            Canvas.SetTop(RSchläger, p.Y);
            Title = HitIndex.ToString();
        }


    }

}

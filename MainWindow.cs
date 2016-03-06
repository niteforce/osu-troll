using System;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace osu_troll
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        public int Counter { get; set; }

        private int WinCount { get; set; } = 20;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Counter++;
            if (Counter == WinCount)
            {
                timer.Stop();
                Counter = 0;
            }
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            SoundPlayer sp;

            if (checkBox.IsChecked == true)
            {
                sp = new SoundPlayer(assembly.GetManifestResourceStream("osu_troll.troll_dt.wav"));
            }
            else
            {
                sp = new SoundPlayer(assembly.GetManifestResourceStream("osu_troll.troll.wav"));
                WinCount = 50;
            }

            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();


            sp.Play();
        }

        public void timer_tick(object sender, EventArgs e)
        {
            var win2 = new Window1();
            WindowCounter.Novel();

            if (checkBox.IsChecked == false)
            {
                win2.gif1.Visibility = Visibility.Hidden;

                win2.image2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/1.png"));
                win2.image2.Visibility = Visibility.Visible;
            }


            win2.Show();
            dispatcherTimer_Tick(this, null);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Foreground = Brushes.Red;
            button1.FontSize = 24;
            button1.Content = "Account Deleted";
        }
    }
}
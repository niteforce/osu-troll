using System;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace osu_troll
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DispatcherTimer timer2;

        public Window1()
        {
            InitializeComponent();
            var random = new Random();

            Left = random.Next(0, (int) SystemParameters.PrimaryScreenWidth);
            Top = random.Next(0, (int) SystemParameters.PrimaryScreenHeight);

            timer2 = new DispatcherTimer();
            timer2.Tick += timer_tick;
            timer2.Interval = new TimeSpan(0, 0, 0, 0, 7000);
            timer2.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sp = new SoundPlayer(assembly.GetManifestResourceStream("osu_troll.hitsound.wav"));
            sp.Play();


            Close();
            WindowCounter.Csokkent();
            timer2.Stop();
            timer2 = null;
        }
    }
}
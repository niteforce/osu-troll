using System.Media;
using System.Reflection;
using System.Windows;

namespace osu_troll
{
    internal static class WindowCounter
    {
        public static int Count { get; set; }

        public static void Novel() => Count++;

        public static void Csokkent()
        {
            Count--;
            if (Count == 0)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var sp = new SoundPlayer(assembly.GetManifestResourceStream("osu_troll.erro.wav"));
                sp.Play();

                var win3 = new Fatal();

                win3.Height = (int) SystemParameters.PrimaryScreenHeight;
                win3.Width = (int) SystemParameters.PrimaryScreenWidth;

                win3.Show();
            }
        }
    }
}
using System.ComponentModel;
using System.Windows;

namespace osu_troll
{
    /// <summary>
    ///     Interaction logic for Fatal.xaml
    /// </summary>
    public partial class Fatal : Window
    {
        public Fatal()
        {
            InitializeComponent();
            Closing += OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) => Application.Current.MainWindow.Close();
    }
}
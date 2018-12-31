using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Ecran_de_veille_Pendule_SNCF
{
    public partial class Blackout : Window
    {
        public Blackout()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}

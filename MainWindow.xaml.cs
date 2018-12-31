using System;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Ecran_de_veille_Pendule_SNCF
{

    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(ref NativePoint pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct NativePoint
        {
            public int X;
            public int Y;
        };

        public static Point GetCurrentMousePosition()
        {
            NativePoint nativePoint = new NativePoint();
            GetCursorPos(ref nativePoint);
            return new Point(nativePoint.X, nativePoint.Y);
        }

        private Dispatcher dispatcher;

        Timer timer = new Timer(100);

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Point current = GetCurrentMousePosition();
            this.CurrentPosition = current;
        }

        public Point CurrentPosition
        {
            get { return (Point)GetValue(CurrentPositionProperty); }

            set
            {
                dispatcher.Invoke((Action)(() =>
                  SetValue(CurrentPositionProperty, value)));
            }
        }

        public static readonly DependencyProperty CurrentPositionProperty
          = DependencyProperty.Register(
            "CurrentPosition", typeof(Point), typeof(MainWindow));

        private double actualX, actualY = 0;
        public static readonly DependencyProperty cadranURLProperty =
         DependencyProperty.Register("CadranURL", typeof(string),
         typeof(MainWindow), new FrameworkPropertyMetadata(@"Resources\cadran430.png"));

        public string CadranURL
        {
            get { return (string)GetValue(cadranURLProperty); }
            set { SetValue(cadranURLProperty, value); }
        }
        public static readonly DependencyProperty aighURLProperty =
         DependencyProperty.Register("AighURL", typeof(string),
         typeof(MainWindow), new FrameworkPropertyMetadata(@"Resources\aigh430.png"));

        public string AighURL
        {
            get { return (string)GetValue(aighURLProperty); }
            set { SetValue(aighURLProperty, value); }
        }
        public static readonly DependencyProperty aigmURLProperty =
         DependencyProperty.Register("AigmURL", typeof(string),
         typeof(MainWindow), new FrameworkPropertyMetadata(@"Resources\aigm430.png"));

        public string AigmURL
        {
            get { return (string)GetValue(aigmURLProperty); }
            set { SetValue(aigmURLProperty, value); }
        }
        public static readonly DependencyProperty aigsURLProperty =
         DependencyProperty.Register("AigsURL", typeof(string),
         typeof(MainWindow), new FrameworkPropertyMetadata(@"Resources\aigs430.png"));

        public string AigsURL
        {
            get { return (string)GetValue(aigsURLProperty); }
            set { SetValue(aigsURLProperty, value); }
        }
        public static readonly DependencyProperty cadranWProperty =
         DependencyProperty.Register("CadranW", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(430));

        public int CadranW
        {
            get { return (int)GetValue(cadranWProperty); }
            set { SetValue(cadranWProperty, value); }
        }
        public static readonly DependencyProperty cadranHProperty =
         DependencyProperty.Register("CadranH", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(429));

        public int CadranH
        {
            get { return (int)GetValue(cadranHProperty); }
            set { SetValue(cadranHProperty, value); }
        }
        public static readonly DependencyProperty aighWProperty =
         DependencyProperty.Register("AighW", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(29));

        public int AighW
        {
            get { return (int)GetValue(aighWProperty); }
            set { SetValue(aighWProperty, value); }
        }
        public static readonly DependencyProperty aighHProperty =
         DependencyProperty.Register("AighH", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(192));

        public int AighH
        {
            get { return (int)GetValue(aighHProperty); }
            set { SetValue(aighHProperty, value); }
        }
        public static readonly DependencyProperty aighDProperty =
         DependencyProperty.Register("AighD", typeof(float),
         typeof(MainWindow), new FrameworkPropertyMetadata(-34.76f));

        public float AighD
        {
            get { return (float)GetValue(aighDProperty); }
            set { SetValue(aighDProperty, value); }
        }
        public static readonly DependencyProperty aigmWProperty =
         DependencyProperty.Register("AigmW", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(21));

        public int AigmW
        {
            get { return (int)GetValue(aigmWProperty); }
            set { SetValue(aigmWProperty, value); }
        }
        public static readonly DependencyProperty aigmHProperty =
         DependencyProperty.Register("AigmH", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(200));

        public int AigmH
        {
            get { return (int)GetValue(aigmHProperty); }
            set { SetValue(aigmHProperty, value); }
        }
        public static readonly DependencyProperty aigmDProperty =
         DependencyProperty.Register("AigmD", typeof(float),
         typeof(MainWindow), new FrameworkPropertyMetadata(-56.76f));

        public float AigmD
        {
            get { return (float)GetValue(aigmDProperty); }
            set { SetValue(aigmDProperty, value); }
        }
        public static readonly DependencyProperty aigsWProperty =
         DependencyProperty.Register("AigsW", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(29));

        public int AigsW
        {
            get { return (int)GetValue(aigsWProperty); }
            set { SetValue(aigsWProperty, value); }
        }
        public static readonly DependencyProperty aigsHProperty =
         DependencyProperty.Register("AigsH", typeof(int),
         typeof(MainWindow), new FrameworkPropertyMetadata(209));

        public int AigsH
        {
            get { return (int)GetValue(aigsHProperty); }
            set { SetValue(aigsHProperty, value); }
        }
        public static readonly DependencyProperty aigsDProperty =
         DependencyProperty.Register("AigsD", typeof(float),
         typeof(MainWindow), new FrameworkPropertyMetadata(-58.52f));

        public float AigsD
        {
            get { return (float)GetValue(aigsDProperty); }
            set { SetValue(aigsDProperty, value); }
        }

        public static readonly DependencyProperty aighFromProperty =
         DependencyProperty.Register("AighFrom", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AighFrom
        {
            get { return (double)GetValue(aighFromProperty); }
            set { SetValue(aighFromProperty, value); }
        }
        public static readonly DependencyProperty aighToProperty =
         DependencyProperty.Register("AighTo", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AighTo
        {
            get { return (double)GetValue(aighToProperty); }
            set { SetValue(aighToProperty, value); }
        }
        public static readonly DependencyProperty aigmFromProperty =
         DependencyProperty.Register("AigmFrom", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AigmFrom
        {
            get { return (double)GetValue(aigmFromProperty); }
            set { SetValue(aigmFromProperty, value); }
        }
        public static readonly DependencyProperty aigmToProperty =
         DependencyProperty.Register("AigmTo", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AigmTo
        {
            get { return (double)GetValue(aigmToProperty); }
            set { SetValue(aigmToProperty, value); }
        }
        public static readonly DependencyProperty aigsFromProperty =
         DependencyProperty.Register("AigsFrom", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AigsFrom
        {
            get { return (double)GetValue(aigsFromProperty); }
            set { SetValue(aigsFromProperty, value); }
        }
        public static readonly DependencyProperty aigsToProperty =
         DependencyProperty.Register("AigsTo", typeof(double),
         typeof(MainWindow), new FrameworkPropertyMetadata(0.0));

        public double AigsTo
        {
            get { return (double)GetValue(aigsToProperty); }
            set { SetValue(aigsToProperty, value); }
        }
        public double ewidth, eheight;
        public bool preview = false;
        
        public MainWindow()
        {
            if (preview == false)
            {
                ewidth = this.RenderSize.Width;
                eheight = this.RenderSize.Height;
            }
            float ratio = 0.0f;
            if (ewidth > 1920.0f)
            {
                ratio = 4.0f;
            }
            else if (ewidth > 1600.0f)
            {
                ratio = 2.0f;
            }
            else
            {
                ratio = 1.3f;
            }
            if (ratio < 1.1f)
            {
                CadranURL = @"Resources\cadran430.png";
                AighURL = @"Resources\aigh430.png";
                AigmURL = @"Resources\aigm430.png";
                AigsURL = @"Resources\aigs430.png";
            }
            else
            {
                if (ratio < 2.0f)
                {
                    CadranURL = @"Resources\cadran1000.png";
                    AighURL = @"Resources\aigh1000.png";
                    AigmURL = @"Resources\aigm1000.png";
                    AigsURL = @"Resources\aigs1000.png";
                }
                else
                {
                    if (ratio >= 2.0f)
                    {
                        CadranURL = @"Resources\cadran1600.png";
                        AighURL = @"Resources\aigh1600.png";
                        AigmURL = @"Resources\aigm1600.png";
                        AigsURL = @"Resources\aigs1600.png";
                    }
                }
            }
            CadranH = (int)(ratio * 429);
            CadranW = (int)(ratio * 430);
            AighH = (int)(ratio * 192);
            AighW = (int)(ratio * 29);
            AighD = (float)(-ratio * 34.76);
            AigmH = (int)(ratio * 200);
            AigmW = (int)(ratio * 21);
            AigmD = (float)(-ratio * 56.76);
            AigsH = (int)(ratio * 209);
            AigsW = (int)(ratio * 29);
            AigsD = (float)(-ratio * 58.52);
            DateTime dt = DateTime.Now;
            if (dt.Hour < 12)
            {
                AighFrom = (double)(360.0f / 43200.0f) * ((dt.Hour * 3600.0f) + (dt.Minute * 60.0f) + dt.Second);
            }
            else
            {
                AighFrom = (double)(360.0f / 43200.0f) * (((dt.Hour - 12.0f) * 3600.0f) + (dt.Minute * 60.0f) + dt.Second);

            }
            AighTo = (double)360 + AighFrom;
            AigmFrom = (double)0.1f * ((dt.Minute * 60) + dt.Second + (float)(dt.Millisecond / 1000.0f));
            AigmTo = (double)360 + AigmFrom;
            AigsFrom = (double)6 * ((float)dt.Second + (float)(dt.Millisecond / 1000.0f));
            AigsTo = (double)360 + AigsFrom;
            dispatcher = Dispatcher;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            InitializeComponent();
        }

        Random r = new Random();
        double precX, precY;
        private void MouvementPendule()
        {
            if (preview == false)
            {
                ewidth = this.RenderSize.Width;
                eheight = this.RenderSize.Height;
            }
            double newX = r.Next(0, (int)(ewidth / 2 - CadranW / 2));
            double newY = r.Next(0, (int)(eheight / 2 - CadranH / 2));
            double limitehaute = -(eheight / 2 - CadranH / 2);
            double limitebasse = (eheight / 2 - CadranH / 2);
            double limitedroite = (ewidth / 2 - CadranW / 2);
            double limitegauche = -(ewidth / 2 - CadranW / 2);
            if (actualX == limitedroite)
            {
                if (actualY == limitehaute | actualY == limitebasse)
                {
                    newX = -actualX;
                }
                else if (actualY < precY)
                {
                    newY = limitehaute;
                }
                else
                {
                    newY = limitebasse;
                }
            }
            else if (actualX == limitegauche)
            {
                if (actualY == limitehaute | actualY == limitebasse)
                {
                    newX = -actualX;
                }
                else if (actualY < precY)
                {
                    newY = limitehaute;
                }
                else
                {
                    newY = limitebasse;
                }
            }
            else if (actualY == limitebasse)
            {
                if (actualX == limitedroite | actualX == limitegauche)
                {
                    newY = -actualY;
                }
                else if (actualX < precX)
                {
                    newX = limitegauche;
                }
                else
                {
                    newX = limitedroite;
                }
            }
            else if (actualY == limitehaute)
            {
                if (actualX == limitedroite | actualX == limitegauche)
                {
                    newY = -actualY;
                }
                else if (actualX < precX)
                {
                    newX = limitegauche;
                }
                else
                {
                    newX = limitedroite;
                }
            }
            else
            {
                newX = limitedroite;
            }
            precX = actualX;
            precY = actualY;
            /*
            if (switching)
            {
                newX = ewidth / 2 - CadranW/2;
                if (actualX != 0 & actualY != 0)
                {
                    newY = -actualY;
                }
                switching = false;
            }
            else
            {
                newY = eheight / 2 - CadranH/ 2;
                if (actualX != 0 & actualY != 0)
                {
                    newX = -actualX;
                }
                switching = true;
            }
            /*
            if (actualX == 0 & actualY == 0)
            {
                if (actualX > 0)
                {
                    //newX = r.Next(0, (int)(eheight - CadranH) / 2);
                    while ((newX > actualX - (ewidth / 6)) & (newX < actualX + (ewidth / 6)))
                    {
                        newX = r.Next(0, (int)(ewidth / 2 - CadranW / 2));
                    }
                    newX = (double)(-newX);
                }
                else
                {
                    newX = r.Next(0, (int)(ewidth / 2 - CadranW / 2));
                    while ((newX > -actualX - (ewidth / 6)) & (newX < -actualX + (ewidth / 6)))
                    {
                        newX = r.Next(0, (int)(ewidth / 2 - CadranW / 2));
                    }
                    //newX = (double)(newX);
                }
                if (actualY > 0)
                {
                    //newY = r.Next(0, (int)(ewidth - CadranW) / 2);
                    newY = r.Next(0, (int)(eheight / 2 + CadranH / 4));
                    while ((newY > actualY - (eheight / 6)) & (newY < actualY + (eheight / 6)))
                    {
                        newY = r.Next(0, (int)(eheight / 2 + CadranH / 2));
                    }
                    newY = (double)(-newY);
                }
                else
                {
                    while ((newY > -actualY - (eheight / 6)) & (newY < -actualY + (eheight / 6)))
                    {
                        newY = r.Next(0, (int)(eheight - CadranH / 2));
                    }
                    /*
                    if (newY-eheight > CadranH/4)
                    {
                        newY = newY - CadranH / 2;
                    }
                    //newY = (double)(newY);
                }
            } else
            {

                if (actualX > 0 & actualX > ewidth+CadranW) {
                    newX = -actualX;
                } else if (actualX < 0 & actualX < - ewidth - CadranW)
                {
                    newX = -actualX;
                } else if (actualY > 0 & actualY > eheight + CadranH)
                {
                    newX = -actualX;
                } else if (actualY < 0 & actualY < - eheight - CadranH)
                {
                    newY = -actualY;
                }
            } */
            double temps = Math.Abs(Math.Sqrt(Math.Pow((actualX-newX),2) + Math.Pow((actualY - newY), 2)))/8*100;
            Storyboard sb = new Storyboard();
            DoubleAnimation slideX = new DoubleAnimation
            {
                To = newX,
                From = actualX,
                Duration = new Duration(TimeSpan.FromMilliseconds(temps))
            };
            Storyboard.SetTarget(slideX, MainGrid);
            Storyboard.SetTargetProperty(slideX, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            sb.Children.Add(slideX);
            DoubleAnimation slideY = new DoubleAnimation
            {
                To = newY,
                From = actualY,
                Duration = new Duration(TimeSpan.FromMilliseconds(temps))
            };
            Storyboard.SetTarget(slideY, MainGrid);
            Storyboard.SetTargetProperty(slideY, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            sb.Children.Add(slideY);
            actualX = newX;
            actualY = newY;
             sb.Completed += new EventHandler((s, e) =>
            {
                MouvementPendule();
            });
            sb.Begin();
        }

        Point memoire = new Point(0, 0);
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            Mouse.OverrideCursor = Cursors.None;
            MouvementPendule();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (memoire == new Point(0, 0))
            {
                memoire = CurrentPosition;
            }
            else
            {
                if (memoire != CurrentPosition)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

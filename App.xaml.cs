using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using Application = System.Windows.Application;

namespace Ecran_de_veille_Pendule_SNCF
{
    public partial class App : Application
    {
        private HwndSource winWPFContent;

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (s != Screen.PrimaryScreen)
                    {
                        Blackout window = new Blackout();
                        window.Left = s.WorkingArea.Left;
                        window.Top = s.WorkingArea.Top;
                        window.Width = s.WorkingArea.Width;
                        window.Height = s.WorkingArea.Height;
                        window.Show();
                    }
                    else
                    {
                        MainWindow window = new MainWindow();
                        window.Left = s.WorkingArea.Left;
                        window.Top = s.WorkingArea.Top;
                        window.Width = s.WorkingArea.Width;
                        window.Height = s.WorkingArea.Height;
                        window.Show();
                    }
                }
            }
            else if (e.Args[0].ToLower().StartsWith("/p"))
            {
                MainWindow window = new MainWindow();
                Int32 previewHandle = Convert.ToInt32(e.Args[1]);
                IntPtr pPreviewHnd = new IntPtr(previewHandle);
                RECT lpRect = new RECT();
                bool bGetRect = Win32API.GetClientRect(pPreviewHnd, ref lpRect);
                window.preview = true;
                HwndSourceParameters sourceParams = new HwndSourceParameters("sourceParams")
                {
                    PositionX = 0,
                    PositionY = 0,
                    Height = lpRect.Bottom - lpRect.Top,
                    Width = lpRect.Right - lpRect.Left
                };
                window.ewidth = sourceParams.Width;
                window.eheight = sourceParams.Height;
                sourceParams.ParentWindow = pPreviewHnd;
                sourceParams.WindowStyle = (int)(WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN);

                winWPFContent = new HwndSource(sourceParams);
                winWPFContent.Disposed += (o, args) => window.Close();
                winWPFContent.RootVisual = window.MainGrid;

            }
            else if (e.Args[0].ToLower().StartsWith("/c"))
            {
                System.Windows.MessageBox.Show("Pendule SNCF par LAMIRI Samy");
            }
        }
    }
    public class Win32API
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);
    }

    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public abstract class WindowStyles
    {
        public const uint WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x08000000;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_CAPTION = 0x00C00000;
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_GROUP = 0x00020000;
        public const uint WS_TABSTOP = 0x00010000;

        public const uint WS_MINIMIZEBOX = 0x00020000;
        public const uint WS_MAXIMIZEBOX = 0x00010000;

        public const uint WS_TILED = WS_OVERLAPPED;
        public const uint WS_ICONIC = WS_MINIMIZE;
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        public const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;
        

        public const uint WS_OVERLAPPEDWINDOW =
            (WS_OVERLAPPED |
              WS_CAPTION |
              WS_SYSMENU |
              WS_THICKFRAME |
              WS_MINIMIZEBOX |
              WS_MAXIMIZEBOX);

        public const uint WS_POPUPWINDOW =
            (WS_POPUP |
              WS_BORDER |
              WS_SYSMENU);

        public const uint WS_CHILDWINDOW = WS_CHILD;

        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        public const uint WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_ACCEPTFILES = 0x00000010;
        public const uint WS_EX_TRANSPARENT = 0x00000020;
        
        public const uint WS_EX_MDICHILD = 0x00000040;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        public const uint WS_EX_CLIENTEDGE = 0x00000200;
        public const uint WS_EX_CONTEXTHELP = 0x00000400;

        public const uint WS_EX_RIGHT = 0x00001000;
        public const uint WS_EX_LEFT = 0x00000000;
        public const uint WS_EX_RTLREADING = 0x00002000;
        public const uint WS_EX_LTRREADING = 0x00000000;
        public const uint WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const uint WS_EX_RIGHTSCROLLBAR = 0x00000000;

        public const uint WS_EX_CONTROLPARENT = 0x00010000;
        public const uint WS_EX_STATICEDGE = 0x00020000;
        public const uint WS_EX_APPWINDOW = 0x00040000;

        public const uint WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        public const uint WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        public const uint WS_EX_LAYERED = 0x00080000;
        public const uint WS_EX_NOINHERITLAYOUT = 0x00100000;
        public const uint WS_EX_LAYOUTRTL = 0x00400000;
        public const uint WS_EX_COMPOSITED = 0x02000000;
        public const uint WS_EX_NOACTIVATE = 0x08000000;
    }
}

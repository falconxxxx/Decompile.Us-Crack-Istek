using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    internal class Tarama
    {
        public void TaramaYap(string dosyayolu)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "pid.exe";
            processStartInfo.Arguments = "-scan " + dosyayolu;
            var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            Thread.Sleep(millisecondsTimeout: 2000);
            Bitmap bitmap = EkranGörüntüsü(process.MainWindowHandle, IsClientWnd: false, nCmdShow: Win32API.WindowShowStyle.Restore);
            try
            {
                string filepath = Application.StartupPath + @"\taramasonucu.jpg";
                bitmap.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                MessageBox.Show("Hata oluştu. Lütfen forumdan iletişime geçin. Ek bilgi Tarama Hatası", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            process.Kill();
        }

        private static Bitmap EkranGörüntüsü(IntPtr AppWndHandle, bool IsClientWnd, Win32API.WindowShowStyle nCmdShow)
        {
            if (AppWndHandle == IntPtr.Zero || !Win32API.IsWindow(AppWndHandle) || !Win32API.IsWindowVisible(AppWndHandle))
                return null;
            if (Win32API.IsIconic(AppWndHandle))
                Win32API.ShowWindow(AppWndHandle, nCmdShow);
            if (!Win32API.SetForegroundWindow(AppWndHandle))
                return null;
            System.Threading.Thread.Sleep(1000);
            RECT appRect;
            bool res = IsClientWnd ? Win32API.GetClientRect(AppWndHandle, out appRect) : Win32API.GetWindowRect(AppWndHandle, out appRect);
            if (!res || appRect.Height == 0 || appRect.Width == 0)
            {
                return null;
            }
            if (IsClientWnd)
            {
                Point lt = new Point(appRect.Left, appRect.Top);
                Point rb = new Point(appRect.Right, appRect.Bottom);
                Win32API.ClientToScreen(AppWndHandle, ref lt);
                Win32API.ClientToScreen(AppWndHandle, ref rb);
                appRect.Left = lt.X;
                appRect.Top = lt.Y;
                appRect.Right = rb.X;
                appRect.Bottom = rb.Y;
            }
            IntPtr DesktopHandle = Win32API.GetDesktopWindow();
            RECT desktopRect;
            Win32API.GetWindowRect(DesktopHandle, out desktopRect);
            RECT visibleRect;
            if (!Win32API.IntersectRect(out visibleRect, ref desktopRect, ref appRect))
            {
                visibleRect = appRect;
            }
            if (Win32API.IsRectEmpty(ref visibleRect))
                return null;

            int Width = visibleRect.Width;
            int Height = visibleRect.Height;
            IntPtr hdcTo = IntPtr.Zero;
            IntPtr hdcFrom = IntPtr.Zero;
            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                Bitmap clsRet = null;

                hdcFrom = IsClientWnd ? Win32API.GetDC(AppWndHandle) : Win32API.GetWindowDC(AppWndHandle);

                hdcTo = Win32API.CreateCompatibleDC(hdcFrom);
                hBitmap = Win32API.CreateCompatibleBitmap(hdcFrom, Width, Height);

                if (hBitmap != IntPtr.Zero)
                {
                    int x = appRect.Left < 0 ? -appRect.Left : 0;
                    int y = appRect.Top < 0 ? -appRect.Top : 0;
                    IntPtr hLocalBitmap = Win32API.SelectObject(hdcTo, hBitmap);
                    Win32API.BitBlt(hdcTo, 0, 0, Width, Height, hdcFrom, x, y, Win32API.SRCCOPY);
                    Win32API.SelectObject(hdcTo, hLocalBitmap);
                    clsRet = Image.FromHbitmap(hBitmap);
                }
                return clsRet;
            }
            finally
            {
                if (hdcFrom != IntPtr.Zero)
                    Win32API.ReleaseDC(AppWndHandle, hdcFrom);
                if (hdcTo != IntPtr.Zero)
                    Win32API.DeleteDC(hdcTo);
                if (hBitmap != IntPtr.Zero)
                    Win32API.DeleteObject(hBitmap);
            }
        }
    }
}
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Antivirus
{
    public static class WinApi
    {
        public static int SendQuitMessage(int hWnd)
        {
            return SendMessage(hWnd, 0x0010, 0, 0);
        }

        public static int FindWindowByWindowName(string windowName)
        {
            return FindWindow(null, windowName).ToInt32(); 
        }

        public static string GetWindowClassName(int hWnd)
        {
            StringBuilder windowClassName = new StringBuilder(256);

            GetClassName((IntPtr)hWnd, windowClassName, windowClassName.Capacity);

            return windowClassName.ToString();
        }
        
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);        
     
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName,int nMaxCount);
    }
}
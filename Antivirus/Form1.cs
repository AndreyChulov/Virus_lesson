using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DefenderCloser_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int count = 0; count < 5; count++)
            {
                string caption = $"DefenderForm{count}";
                var hWnd = WinApi.FindWindowByWindowName(caption);
                //var windowClassName = WinApi.GetWindowClassName(hWnd);
                
                if (hWnd != 0) WinApi.SendQuitMessage(hWnd);
            }
        }
    }
}
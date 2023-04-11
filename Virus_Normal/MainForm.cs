using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Virus_Normal
{
    public partial class Form1 : Form
    {
        private const int DEFENDERS_COUNT = 5;
        private Thread[] _threads;
        private Timer _checkDefenseTimer = new Timer();

        private static Thread[] InitialiseDefense()
        {
            Thread[] threads = new Thread[DEFENDERS_COUNT];
            
            for (int count = 0; count < DEFENDERS_COUNT; count++)
            {
                threads[count] = InitialiseDefenderThread(count);
            }

            return threads;
        }

        private static Thread InitialiseDefenderThread(int count)
        {
            Thread defenderThread = new Thread(InitialiseDefender);
            
            defenderThread.Priority = ThreadPriority.AboveNormal;
            defenderThread.Start(count);
            
            return defenderThread;
        }

        private static void InitialiseDefender(object? countObj)
        {
            int threadIndex = (int) (countObj ?? 0);

            try
            {
                Application.Run(new DefenderForm(threadIndex));
            }
            catch (Exception) { }
        }

        public Form1()
        {
            InitializeComponent();

            _threads = InitialiseDefense();

            InitialiseDefenseCheckTimer();
        }

        private void InitialiseDefenseCheckTimer()
        {
            _checkDefenseTimer.Interval = 1;
            _checkDefenseTimer.AutoReset = true;
            _checkDefenseTimer.Elapsed += CheckDefenseTimerOnElapsed;
            _checkDefenseTimer.Start();
        }

        private void CheckDefenseTimerOnElapsed(object? sender, ElapsedEventArgs e)
        {
            int defenderThreadsInitialised = 0;

            for (int count = 0; count < DEFENDERS_COUNT; count++)
            {
                if (!_threads[count].IsAlive)
                {
                    //MessageBox.Show("Closed defender found. Reopening.", "Action detected.");
                    
                    _threads[count] = InitialiseDefenderThread(count);
                    defenderThreadsInitialised++;
                }
            }

            if (defenderThreadsInitialised == DEFENDERS_COUNT)
            {
                _checkDefenseTimer.Enabled = false;
            }
        }

    }
}
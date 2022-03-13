using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;

namespace test
{
    public partial class Form1 : Form
    {
        Camera camera;
        public Panel panel;
        DrowInScreen screen = null;
        public Form1()
        {
            InitializeComponent();
            Label label = FPSlabel;
            label.Visible = false;
            setup_timer();
            this.panel = panel1;   
            screen = new DrowInScreen(this);
            camera = new Camera(this, screen);
        }

        private void draw_window()
        {
        https://www.cyberforum.ru/windows-forms/thread2399546.html
            Graphics panelGraphics;
            var g =  panel.CreateGraphics();
            g.Clear(System.Drawing.Color.OldLace);
            screen.DrowLine(1, 1, 100, 100);
            panel.Render();
        }


        DispatcherTimer timer;

        public int frames_count_in_sec = 0;
        private void setup_timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 90);
            timer.Tick += OnTimer;
            timer.Start();
            FpsGame();
        }

        public void FpsGame()
        {
            DispatcherTimer fpsTimer = new DispatcherTimer();
            fpsTimer.Interval = TimeSpan.FromSeconds(1);
            fpsTimer.Tick += (s, a) =>
            {
                FPSlabel.Text = string.Format("FPS:{0}", frames_count_in_sec);
                frames_count_in_sec = 0;
            };
            fpsTimer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            ++frames_count_in_sec;
            draw_window();
        }


        public (int W, int H) get_WH()
        {
            return (this.Width, this.Height);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            camera.MouseUp();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            camera.MouseDown();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            camera.MouseMove();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
                if (camera != null) { 
                camera.set_screen(this.Width, this.Height);
                camera.screen_resize();
            }
        }

   

        private void FPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPSlabel.Visible = !FPSlabel.Visible;
        }
    }


}


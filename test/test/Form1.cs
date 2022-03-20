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
        DrawInScreen screen = null;
        WorkSpace workSpace = null;
        bool Creator = false;

        public Form1()
        {
            InitializeComponent();
            Label label = FPSlabel;
            label.Visible = false;
            label_x_mouse_down.Visible = false;
            label_x_mouse_move.Visible = false;
            label_y_mouse_down.Visible = false;
            label_y_mouse_move.Visible = false;

            setup_timer();
            screen = new DrawInScreen(this, panel1);
            camera = new Camera(this, screen,panel1);
            workSpace = new WorkSpace(screen, camera);
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
            workSpace.updateWindow();
            ++frames_count_in_sec;
            var out_data = camera.get_positions();
            label_x_mouse_down.Text = out_data.x1;
            label_y_mouse_down.Text = out_data.y1;  
            label_x_mouse_move.Text = out_data.x2;
            label_y_mouse_move.Text = out_data.y2;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                camera.MouseUp();
            if (Creator)
                if (e.Button == MouseButtons.Left)
                {
                    workSpace.AddTwoPoint(e.X,
                        e.Y);
                }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
                camera.MouseDown();
            if (Creator)
                if (e.Button == MouseButtons.Left)
                {

                    workSpace.AddOnePoint(
                        e.X,
                        e.Y);

                }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                camera.MouseMove();
            if (Creator)
                if (e.Button == MouseButtons.Left)
                {
                    workSpace.AddLine(e.X,
                        e.Y);
                }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (camera != null) 
            { 
                camera.screen_resize(this.Width, this.Height);
            }
        }

        private void FPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPSlabel.Visible = !FPSlabel.Visible;
        }

        private void координатыМышиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_x_mouse_down.Visible = !label_x_mouse_down.Visible;   
            label_x_mouse_move.Visible = !label_x_mouse_move.Visible;   
            label_y_mouse_down.Visible = !label_y_mouse_down.Visible;
            label_y_mouse_move.Visible = !label_y_mouse_move.Visible;
            label_x_mouse_down.Text = "None";
            label_x_mouse_move.Text = "None";
            label_y_mouse_down.Text = "None";
            label_y_mouse_move.Text = "None";
        }

        private void редакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator = true;
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator = false;
        }
    }


}


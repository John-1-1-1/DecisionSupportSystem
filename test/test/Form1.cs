using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string name_app = "My App";
        DispatcherTimer timer;
        public int frames_count_in_sec = 0;
        public Form1()
        {
            InitializeComponent();
            Label label = FPSlabel;
            label.Visible = false;
            label_x_mouse_down.Visible = false;
            label_x_mouse_move.Visible = false;
            label_y_mouse_down.Visible = false;
            label_y_mouse_move.Visible = false;
            menu.Visible = false;
            addName();
            setup_timer();
            screen = new DrawInScreen(panel1);
            camera = new Camera(screen,panel1, listView1);
            workSpace = new WorkSpace(screen, camera, menu);
        }
        private void addName()
        {
            if (Creator)
                this.Text = name_app + " (Редактирование)";
            else
                this.Text = name_app + " (Просмотр)";
        }
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
                    workSpace.AddTwoPoint(e.X,
                        e.Y);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
                camera.MouseDown();
            if (Creator)
                if (e.Button == MouseButtons.Left)
                    workSpace.AddOnePoint(
                        e.X,
                        e.Y);
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
                camera.screen_resize(this.Width, this.Height, Creator);
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
            listView1.Visible = false;
            addName();
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator = false;
            listView1.Visible = true;
            addName();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            workSpace.del_point();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            var name = saveFileDialog1.FileName;
            if (name != "")
                workSpace.Save(name);
            else
                MessageBox.Show("Вы ввели Имя! Данные не сохранены!");

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            var name = openFileDialog.FileName;
            if (name != "")
                workSpace.Load(name);
            else
                MessageBox.Show("Вы ввели Имя! Данные не сохранены!");
        }

    }


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Camera
    {


        int pos_in_screen_x = 0;
        int pos_in_screen_y = 0;
        Pos beginner_pos_scren = new Pos(0,0);
        private (Pos up_left, Pos bot_right) indentation = 
            (new Pos(12,30), new Pos(30, 59));
        protected bool mouse_is_down = false;
        public (int x, int y) pos = (0, 0);
        Form1 form;
        DrowInScreen screen = null;

        public Camera(Form1 form, DrowInScreen scr)
        {
            this.form = form;
            this.screen = scr;
        }

        public void set_screen(int screen_x, int screen_y)
        {

        }

        public (int x, int y) get_fix_coord(int x, int y)
        {
            return (pos_in_screen_x + x, pos_in_screen_y + y);
        }

        public void screen_resize()
        {
            int screen_x_now = this.form.Width;
            int screen_y_now = this.form.Height;
            this.form.panel.Height = screen_y_now -
                indentation.up_left.y -
                indentation.bot_right.y;

            this.form.panel.Width = screen_x_now -
                indentation.up_left.x -
                indentation.bot_right.x;

        }

        public void MouseUp()
        {
            mouse_is_down = false;
            beginner_pos_scren.x = this.form.Width;
            beginner_pos_scren.y = this.form.Height;
        }

        public void MouseDown()
        {
            mouse_is_down = true;
        }

        public void MouseMove()
        {
            if (mouse_is_down == true)
            {
                int rex = this.form.Width;
                int rey = this.form.Height;
                pos_in_screen_x-=1;
                pos_in_screen_y-=1;

                screen.RefreshOffset(pos_in_screen_x, pos_in_screen_y);
            }
        }
    }
}

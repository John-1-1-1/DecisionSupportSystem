using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    internal class Camera
    {
        int pos_freeze_x = 0;
        int pos_freeze_y = 0;
        int pos_in_screen_x = 0;
        int pos_in_screen_y = 0;
        Pos beginner_pos_screen = new Pos(0,0);
        private (Pos up_left, Pos bot_right) indentation = 
            (new Pos(12,30), new Pos(22, 40));
        protected bool mouse_is_down = false;
        public (int x, int y) pos = (0, 0);
        Form1 form;
        DrowInScreen screen = null;
        Panel panel1 = null;
        
        public Camera(Form1 form, DrowInScreen scr, Panel panel1)
        {
            this.form = form;
            this.screen = scr;
            this.panel1 = panel1;
        }

        public void set_screen(int screen_x, int screen_y)
        {

        }

        public (int x, int y) get_fix_coord(int x, int y)
        {
            return (pos_in_screen_x + x, pos_in_screen_y + y);
        }

        public void screen_resize(int x, int y)
        {
            panel1.Height = y -
                indentation.up_left.y -
                indentation.bot_right.y;

            panel1.Width = x -
                indentation.up_left.x -
                indentation.bot_right.x;

        }

        public void MouseUp()
        {
            mouse_is_down = false;
            pos_freeze_x +=
                    beginner_pos_screen.x -
                    Cursor.Position.X;
            pos_freeze_y +=
                    beginner_pos_screen.y -
                    Cursor.Position.Y;
        }

        public void MouseDown()
        {
            mouse_is_down = true;
            beginner_pos_screen.x = Cursor.Position.X;
            beginner_pos_screen.y = Cursor.Position.Y;

        }

        public (string x1, string y1, string x2, string y2) get_positions()
        {
            if (mouse_is_down)
            {
                return (beginner_pos_screen.x.ToString(),
                     beginner_pos_screen.y.ToString(),
                     Cursor.Position.X.ToString(),
                     Cursor.Position.Y.ToString());
            }
            else
            {
                return ("None", "None",
                     Cursor.Position.X.ToString(),
                     Cursor.Position.Y.ToString());
            }
        }

        public void MouseMove()
        {
            if (mouse_is_down == true)
            {
                pos_in_screen_x= pos_freeze_x+
                    beginner_pos_screen.x-
                    Cursor.Position.X;
                pos_in_screen_y = pos_freeze_y +
                     beginner_pos_screen.y -
                     Cursor.Position.Y;
                screen.RefreshOffset(pos_in_screen_x, pos_in_screen_y);
            }
        }
    }
}

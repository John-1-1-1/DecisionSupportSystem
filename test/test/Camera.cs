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
        Point beginner_pos_screen = new Point(0,0);
        public (Point up_left, Point bot_right) indentation = 
            (new Point(12,30), new Point(22, 40));
        protected bool mouse_is_down = false;
        public (int x, int y) pos = (0, 0);
        DrawInScreen screen = null;
        Panel panel1 = null;

        
        public Camera(DrawInScreen scr, Panel panel1)
        {
            this.screen = scr;
            this.panel1 = panel1;
        }

        public void screen_resize(int x, int y)
        {
            panel1.Height = y -
                indentation.up_left.Y-
                indentation.bot_right.Y;
            panel1.Width = x -
                indentation.up_left.X -
                indentation.bot_right.X;
            screen.new_buffer();
        }

        public void MouseUp()
        {
            mouse_is_down = false;
            pos_freeze_x +=
                    beginner_pos_screen.X -
                    Cursor.Position.X;
            pos_freeze_y +=
                    beginner_pos_screen.Y -
                    Cursor.Position.Y;
        }

        public void MouseDown()
        {
            mouse_is_down = true;
            beginner_pos_screen.X = Cursor.Position.X;
            beginner_pos_screen.Y = Cursor.Position.Y;

        }

        public (string x1, string y1, string x2, string y2) get_positions()
        {
            if (mouse_is_down)
            {
                return (beginner_pos_screen.X.ToString(),
                     beginner_pos_screen.Y.ToString(),
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
        /// <summary>
        /// Обработка движения мыши.
        /// </summary>
        public void MouseMove()
        {
            if (mouse_is_down == true)
            {
                pos_in_screen_x= pos_freeze_x+
                    beginner_pos_screen.X-
                    Cursor.Position.X;
                pos_in_screen_y = pos_freeze_y +
                     beginner_pos_screen.Y -
                     Cursor.Position.Y;
                screen.RefreshOffset(pos_in_screen_x, pos_in_screen_y);
            }
        }
    }
}

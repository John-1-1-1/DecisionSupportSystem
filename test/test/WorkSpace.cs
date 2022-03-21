using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    internal class WorkSpace
    {
        DrawInScreen screen = null;
        Camera camera = null;
        MassVect massVect = null;
        Panel menu = null;
        public WorkSpace(DrawInScreen screen, Camera camera, Panel menu)
        {
            this.screen = screen; 
            this.camera = camera;
            this.massVect = new MassVect(screen);
            this.menu = menu;
        }

        Pos point1 = new Pos(null, null);
        Pos point2 = new Pos(null, null);
        public void AddOnePoint(int x, int y)
        {
            point1 = massVect.CheckPoint(new Pos(x + screen.offset.x, y + screen.offset.y),
                screen.radius);

            reset_points();
        }

        public void reset_points()
        {
            Pos point1 = new Pos(null, null);
            Pos point2 = new Pos(null, null);
        }

        public void AddTwoPoint(int x, int y)
        {
            if (menu.Visible) 
                menu.Visible = false;
            else if (!point2.isNull() && !point2.comparer(point1))
            {
                massVect.add_vect(point1.X, point1.Y);
                massVect.add_vect(point2, point1);
            }
            else
            {
                var pos = massVect.CheckPointNull(point1, screen.radius);
                if (!pos.isNull())
                {
                    menu.Visible = true;
                    menu.Location = new Point(point1.X, point1.Y);
                }
            }
            reset_points();
        }

        public void AddLine(int x, int y)
        {
            point2 = massVect.CheckPoint(new Pos(x + screen.offset.x, y + screen.offset.y),
                screen.radius);
        }

        public void updateWindow()
        {
            screen.Clear_Window();
            if (!point1.isNull() && !point2.isNull() && !point1.comparer(point2))
            {
                screen.DrawMyPoint(point1.X, point1.X);
                screen.DrawMyLine(point1.X, point1.Y, point2.X, point2.Y);
            }
            massVect.DrawE();
            massVect.DrawG();
            screen.RenderWindow();
        }

        internal void del_point()
        {
            menu.Visible = false;
            var point = massVect.CheckPoint(new Pos(menu.Location.X, menu.Location.Y),
                screen.radius);
            var G = massVect.getGraph(point);
            massVect.del(G);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class WorkSpace
    {
        DrawInScreen screen = null;
        Camera camera = null;
        
        public WorkSpace(DrawInScreen screen, Camera camera)
        {
            this.screen = screen; 
            this.camera = camera;
        }

        Pos point1 = new Pos(-1, -1);
        Pos point2 = new Pos(-1, -1);
        public void AddOnePoint(int x, int y)
        {
            point1.y = y + screen.offset.y;
            point1.x = x + screen.offset.x;
        }

        public void AddTwoPoint(int x, int y)
        {
            point1 = new Pos(-1, -1);
            point2 = new Pos(-1, -1);
        }

        public void AddLine(int x, int y)
        {
            point2 = new Pos(x + screen.offset.x,
                y + screen.offset.y);
        }

        public void updateWindow()
        {

            screen.Clear_Window();
            if (point1.y != -1)
            {
                screen.DrawMyPoint(point1.x, point1.y);
                if (point2.y != -1)
                    screen.DrawMyLine(point1.x, point1.y, point2.x, point2.y);
                
            }
            

            screen.RenderWindow();
        }
    }
}

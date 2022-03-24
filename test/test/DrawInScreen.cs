using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    internal class DrawInScreen
    {

        public int radius = 10;
        public float thick = 8;

        private Panel panel1;
        public (int x, int y) offset = (0,0);
        BufferedGraphicsContext panelContext;
        BufferedGraphics panelBuffer;
        Graphics panelGraphics;
        public DrawInScreen(Panel panel1)
        {
            this.panel1 = panel1;
            panelContext = BufferedGraphicsManager.Current;
            panelGraphics = panel1.CreateGraphics();
            panelBuffer = panelContext.Allocate(panelGraphics, panel1.ClientRectangle);

        }

        public void new_buffer()
        {
            panelContext = BufferedGraphicsManager.Current;
            panelGraphics = panel1.CreateGraphics();
            panelBuffer = panelContext.Allocate(panelGraphics, panel1.ClientRectangle);
        }

        public void RefreshOffset(int x, int y) 
        {
            offset.x = x;   
            offset.y = y;
        }

        public void DrawMyPoint(int x, int y)
        {
            Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
            skyBluePen.Width = thick;
            panelBuffer.Graphics.DrawArc(skyBluePen, x - offset.x - radius / 2,
                y - offset.y - radius/2, radius, radius, 0, 360);
        }

        public void DrawMyLine(int x1,int y1,int x2,int y2)
        {
            Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
            skyBluePen.Width = thick;
            panelBuffer.Graphics.
                DrawLine(skyBluePen, x1 - offset.x, y1 - offset.y,
                x2 - offset.x, y2 - offset.y);
        }

        public void Clear_Window()
        {
            panelBuffer.Graphics.Clear(System.Drawing.Color.White);
        }

        public void RenderWindow()
        {
            panelBuffer.Render();
        }
    }
}

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
        private Form1 form;
        private Panel panel1;
        public (int x, int y) offset = (0,0);
        BufferedGraphicsContext panelContext;
        BufferedGraphics panelBuffer;
        Graphics panelGraphics;
        public DrawInScreen(Form1 form, Panel panel1)
        {
            this.form = form;
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

            skyBluePen.Width = 8.0F;
            panelBuffer.Graphics.DrawArc(skyBluePen, x - offset.x -5,
                y - offset.y-5, 10, 10, 0, 360);
           
        }

        public void DrawMyLine(int x1,int y1,int x2,int y2)
        {
            Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);

            // Set the pen's width.
            skyBluePen.Width = 8.0F;
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

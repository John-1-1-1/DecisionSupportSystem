using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class DrowInScreen
    {
        private Form1 form;
        private (int x, int y) offset = (0,0);
        public DrowInScreen(Form1 form)
        {
            this.form = form;
        }

        public void RefreshOffset(int x, int y) 
        {
            offset = (x, y);
        }

        public void DrowLine(int x1,int y1,int x2,int y2)
        {
            Graphics e = form.panel.CreateGraphics();
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);


            // Draw line to screen.
            e.DrawLine(blackPen,x1- offset.x, y1- offset.y,
                x2 - offset.x, y2 - offset.y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        Graph Graph = null;
        Panel menu = null; 
        Point point1 = new Point();
        Point point2 = new Point();
        Point point1r = new Point();
        Point point2r = new Point();
        Node NodeIsClick = new Node();
        PanelParams panelParams = null;
        public WorkSpace(DrawInScreen screen, Camera camera,
            Panel menu, Panel creatorPanel, ListView listView1)
        {
            this.screen = screen;
            this.camera = camera;
            this.Graph = new Graph(screen, creatorPanel);
            this.menu = menu;
            panelParams = new PanelParams(listView1);
        }
        /// <summary>
        /// Нажатие на кнопку/ добавление первой точки.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddOnePoint(int x, int y)
        {
                point1 = Graph.CheckPoint(new Point(x, y).Plus(screen),
                    screen.radius);
                NodeIsClick.IsClick = false;

        }
        /// <summary>
        /// Сброс значений с точек для отметки вершин.
        /// </summary>
        public void reset_points()
        {
            point1 = new Point();
            point2 = new Point();
        }
        /// <summary>
        /// Отпускание клавиши мыши/ добавление второй точки.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddTwoPoint(int x, int y)
        {
            point2 = Graph.CheckPoint(new Point(x, y).Plus(screen),
                screen.radius);
            if (Graph.IsAdd)
            {
                // Если меню видимо, убрать его
                if (menu.Visible)
                    menu.Visible = false;
                // Если оче точки заданы и точки не равны друг другу, добавить вершины.
                else
                {
                    if (!point2.isNull && !point1.isNull && !point2.comparer(point1))
                        Graph.add_Node(point2, point1);
                }

                    // В противном случае отобразить меню
                    //else
                    //{
                    //    var pos = Graph.CheckPointNull(point1, screen.radius);
                    //    if (!pos.isNull() && point2.isNull())
                    //    {
                    //        menu.Visible = true;
                    //        menu.Location = new System.Drawing.Point(point1.X, point1.Y);
                    //    }
                    //}
                    // Обнулить точки.
                    reset_points();
            }
        }

        internal void LeftButCheck(int x, int y)
        {
            NodeIsClick.IsClick= false;
            panelParams.clear_list();
            var pointt = Graph.CheckPoint(new Point(x, y).Plus(screen),
                screen.radius);
            if (!Graph.CheckPointNull(pointt, screen.radius).isNull)
            {
                var g = Graph.getGraph(pointt);
                if (g != null)
                {
                    NodeIsClick = g;
                    NodeIsClick.IsClick = true;

                }
            }
        }

        /// <summary>
        /// Движение курсора/добавление линии.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param> 
        public void AddLine(int x, int y)
        {
            if (!point1.isNull)
                point2 = Graph.CheckPoint(new Point(x, y).Plus(screen),
                        screen.radius);
        }

        internal void RightButUp(int x, int y)
        {
            NodeIsClick.IsClick = false;
            point2r = new Point(x, y).Plus(screen);
            if (point1r.comparer(point2r) && 
                !Graph.CheckPointNull(point2r, screen.radius).isNull)
            {
                menu.Location = new System.Drawing.Point(x, y);
                menu.Visible = true;
            }
            // В противном случае отобразить меню
        }

        /// <summary>
        /// ffffssssssssssssssssssssssssssssssssssssssssssssssssssssss
        /// </summary>
        int kk = 0;
        /// <summary>
        /// Обновление окна.
        /// </summary>
        public void updateWindow()
        {
            screen.Clear_Window();
            if (!point1.isNull && !point2.isNull && !point1.comparer(point2))
            {
                if (Graph.IsAdd)
                {
                    screen.DrawMyPoint(point1.X, point1.Y, false);
                    screen.DrawMyLine(point1.X, point1.Y, point2.X, point2.Y);
                }
            }
            Graph.DrawE();
            Graph.DrawG();
            screen.RenderWindow();
            if (NodeIsClick.IsClick)
            {
                kk += 1;
                if (kk > 10)
                {
                    kk = 0;
                    panelParams.add_data(NodeIsClick);
                }

            }
            else
                panelParams.clear_list();


        }

        internal void RightButDown(int x, int y)
        {
            point1r = new Point(x, y).Plus(screen);
        }

        /// <summary>
        /// Удаление точки (меню).
        /// </summary>
        internal void del_point()
        {
            menu.Visible = false;
            var point = Graph.CheckPoint(new Point(menu.Location.X, 
                menu.Location.Y).Plus(screen),
                screen.radius);
            var G = Graph.getGraph(point);
            Graph.del(G);
        }
        /// <summary>
        /// Сохранение карты в XML.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        internal void Save(string fileName)
        {
            Graph.Save(fileName);
        }
        /// <summary>
        /// Загрузка карты из файла XML.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        internal void Load(string fileName)
        {
            Graph.Load(fileName);
        }

        internal void SaveInfo(string name, string id )
        {
            reset_points();
            Graph.saveInfo(name, id);
        }
    }
}

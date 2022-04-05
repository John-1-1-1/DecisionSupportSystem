using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace test
{
    /// <summary>
    /// Класс графа.
    /// </summary>
    internal class Graph
	{
		public List<Node> G  = new List<Node>();
		DrawInScreen screen = null;
		Panel panel_creator;
		public bool IsAdd = true;
		Node workerNode = null;
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="screen">Модуль взаимодействия с окном.</param>
		public Graph(DrawInScreen screen, Panel panel_creator)
        {
			this.screen = screen;
			this.panel_creator = panel_creator;
		}
		/// <summary>
		/// Проверить позицию. 
		/// </summary>
		/// <param name="point">Точка центра вершины.</param>
		/// <param name="radius">Радиус окружности. </param>
		/// <returns>Возврат либо исходной точки, либо найденной.</returns>
		public Point CheckPoint(Point point, int radius)
		{
			foreach (Node g in G)
				if (PointsMath.LenSegment(g, point) <= radius)
					return new Point(g.x, g.y);
			return point;
		}
		/// <summary>
		/// Проверить позицию. 
		/// </summary>
		/// <param name="point">Точка центра вершины.</param>
		/// <param name="radius">Радиус окружности. </param>
		/// <returns>Если в радиусе от позиции есть точка, то вернуть позицию точки, 
		/// в противном случае пустую точку.</returns>
		public Point CheckPointNull(Point point, int radius)
		{
			foreach (Node g in G)
				if (PointsMath.LenSegment(g,point) <= radius)
					return new Point(g.x, g.y);
			return new Point();
		}
		/// <summary>
		/// Проверить существует ли вершина с такими кординатами.
		/// </summary>
		/// <param name="point"></param>
		/// <returns>
		/// Либо найденую вершину, либо Null.
		/// </returns>
		public Node getGraph(Point point)
		{
			foreach (Node g in G)
				if (g.x == point.X && g.y == point.Y)
					return g;
			return null;
		}
		/// <summary>
		/// Отрисовка вершин графа.
		/// </summary>
		public void DrawG()
		{
			foreach (Node g in G)
				screen.DrawMyPoint(g.x, g.y, g.IsClick);
		}

        internal void Load(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///	Добавление новой вершины/рёбер.
        /// </summary>
        /// <param name="point1">Первая точка.</param>
        /// <param name="point2">Вторая точка.</param>
        public async Task add_Node(Point point1, Point point2)
		{
			List<int> index = find_min_count();
			var fingGraph0 = getGraph(point1);
			var fingGraph1 = getGraph(point2);

			Node g0;
			if (fingGraph0 != null)
				g0 = fingGraph0;
			else
				g0 = new Node(point1.X, point1.Y, index[0]);
			Node g;
			if (fingGraph1 != null)
				g = fingGraph1;
			else
				g = new Node(point2.X, point2.Y, index[1]);
			g0.V_id.Add(g);
			g.V_id.Add(g0);
			if (fingGraph0 == null && g0 != null)
			{
				G.Add(g0);
				IsAdd = false;
			}

			//string jsonString = System.Text.Json.JsonSerializer.Serialize(g0);
			if (fingGraph1 == null && g != null)
			{
				G.Add(g);
				IsAdd = false;
			}

			if (fingGraph0 == null && g0 != null)
			{

				workerNode = g0;
				waiter(g0.x, g0.y, false, g0);
			}

			await Task.Run(() => waiterr());
			//string jsonString = System.Text.Json.JsonSerializer.Serialize(g0);
			if (fingGraph1 == null && g != null)
			{
				workerNode = g;
				waiter(g.x, g.y, true, g);
			}
		}

		public void waiterr()
        {// блок добавление точек
			while (panel_creator.Visible);
		}

		public void waiter(int x, int y, bool wait, Node gg)
		{
			panel_creator.Location = new System.Drawing.Point(x - screen.offset.x, 
				y - screen.offset.y);
			panel_creator.Visible = true;
			IsAdd = true;
		}
		/// <summary>
		/// Добавление информации к точкам. ОСНОВНОЙ
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="id">Object id</param>
		internal void saveInfo(string name, string id)
        {

			workerNode.name = name;
			workerNode.ip = id;
			panel_creator.Visible = false;
		}

		/// <summary>
		/// Поиск свободных индексов с минимальным значением.
		/// </summary>
		/// <returns>Лист свободных индексов. ГАРАНТИРОВАНО ВЕРНЁТ МИНИМУМ 2.</returns>
		public List<int> find_min_count()
        {
			List<int> index = new List<int>();
			var arr = G.Select(x => x.id).ToArray();
			for (int i =0; i<arr.Length+2; i++)
				if (Array.IndexOf(arr, i)==-1)
					index.Add(i);
			return index;
		}
		/// <summary>
		/// Отрисовка всех рёбер.
		/// </summary>
        internal void DrawE()
        {
            foreach (Node g in G)
				foreach (Node i in g.V_id)
					if (i.id < g.id)
						screen.DrawMyLine(g.x, g.y, i.x,i.y);
        }
		/// <summary>
		/// Удаление узла.
		/// </summary>
		/// <param name="g">Удаляемый узел. </param>
        public void del(Node g)
        {
            G.Remove(g);
			foreach (Node g1 in G)
				g1.V_id.Remove(g);
		}
		/// <summary>
		/// Сохранение всего графа.
		/// </summary>
		/// <param name="name">Имя Сохранения</param>
		public void Save(string name)
        {
			var xSave = new XElement("save");
			foreach (Node g in G)
				xSave.Add(g.Save());
			File.WriteAllText(name + ".xml", xSave.ToString());
		}

		/// <summary>
		/// Поиск графа по Id.
		/// </summary>
		/// <param name="id">Идентификатор искомого графа.</param>
		/// <returns>Найденый граф или пустой.</returns>
		public Node addNodeAlongId(int id)
        {
			foreach (Node g in G)
				if (g.id == id)
					return g;
			return new Node();
        }
    }
}

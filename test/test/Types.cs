using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using System.Linq;

namespace test
{
	/// <summary>
	/// Класс Точки
	/// </summary>
	public class Point
	{
		//Точки могут быть не определены = Null
		private int? x, y;
		/// <summary>
		/// Конструктор. принимает лишь координаты.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Point(int? x, int? y)	
		{
			this.x = x;
			this.y = y;
		}
		/// <summary>
		/// Пустой конструктор.
		/// </summary>
		public Point()
        {
			this.x = null;	
			this.y = null;
        }
		/// <summary>
		/// Проверка на пустоту.
		/// </summary>
		/// <returns>Пустая ли точка.</returns>
		public bool isNull()
        {
			return x == null || y == null;
        }
		/// <summary>
		/// Сравнение двух точек друг с другом.
		/// </summary>
		/// <param name="pos">Точка для сравнения.</param>
		/// <returns>Одна ли точка.</returns>
		public bool comparer(Point pos)
        {
			return x == pos.x && y == pos.y;
        }
		
		public int X
		{
			get
			{
				return (int)x;    
			}
			set
			{
				x = value;   
			}
		}
		public int Y
		{
			get
			{
				return (int)y;   
			}
			set
			{
				y = value;  
			}
		}
	}

	/// <summary>
	/// Класс графа.
	/// </summary>
	internal class Graph
	{
		public List<Node> G  = new List<Node>();
		DrawInScreen screen = null;
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="screen">Модуль взаимодействия с окном.</param>
		public Graph(DrawInScreen screen)
        {
			this.screen = screen;
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
				if (Math.Sqrt(Math.Pow(g.x - point.X, 2) + Math.Pow(g.y - point.Y, 2)) <= radius)
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
				if (Math.Sqrt(Math.Pow(g.x - point.X, 2) + Math.Pow(g.y - point.Y, 2)) <= radius)
					return new Point(g.x, g.y);

			return new Point ();
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
				screen.DrawMyPoint(g.x, g.y);
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
        public void add_Node(Point point1, Point point2)
		{
			List<int> index = find_min_count();
			var fingGraph0 = getGraph(point1);
			var fingGraph1 = getGraph(point2);
			Node g0 = fingGraph0!=null? fingGraph0: new Node(point1.X, point1.Y, index[0]);
			Node g = fingGraph1 != null ? fingGraph1 : new Node(point2.X, point2.Y, index[1]);
			g0.V_id.Add(g);
			g.V_id.Add(g0);
			if (fingGraph0 == null)
				G.Add(g0);
			if (fingGraph1 == null)
				G.Add(g);
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
	/// <summary>
	/// Класс Вершины.
	/// </summary>
	public class Node
    {
		public int x, y;
		public int id;
		/// <summary>
		/// Идентификаторы графов имеющих общее ребро.
		/// </summary>
		public List<Node> V_id = new List<Node>();
		public string[] list;
		int[] nodesList;
		/// <summary>
		/// Пустой конструктор.
		/// Граф считается пустым если его Id = -1.
		/// </summary>
		public Node()
		{
			id = -1;
		}
		/// <summary>
		/// Конструктор графа.
		/// </summary>
		/// <param name="x"> X Коорданата графа.</param>
		/// <param name="y"> Y Коорданата графа.</param>
		/// <param name="id">Идентификатор уникальный</param>
		public Node(int x, int y, int id)
        {
			this.x = x;
			this.y = y;
			this.id = id;
        }
		/// <summary>
		/// Конструктор графа. ДЛЯ СОХРАНЁННОГО.
		/// </summary>
		/// <param name="x"> X Коорданата графа.</param>
		/// <param name="y"> Y Коорданата графа.</param>
		/// <param name="id">Идентификатор уникальный</param>
		/// <param name="s">Строка идентификаторов. АКТУАЛЬНА ДЛЯ СОВРАНЁННОГО. </param>
		public Node(int x, int y, int id, string s)
		{
			this.x = x;
			this.y = y;
			this.id = id;
			nodesList = s.Split(' ').Select(i => int.Parse(i)).ToArray();
		}

		/// <summary>
		/// Сохранение графа в XML формате.
		/// </summary>
		/// <returns>XML элемент.</returns>
		public XElement Save()
        {
			var obj = new XElement("Graph");
			obj.Add(new XAttribute("x", x));
			obj.Add(new XAttribute("y", y));
			obj.Add(new XAttribute("id", id));
			String V_id_str = "";
			foreach (var v in V_id)
				V_id_str += v.id.ToString() + " ";
			int x1 = V_id_str.Length - 1;
			obj.Add(new XAttribute("V_id_str", V_id_str.Substring(0, x1)));
			return obj;
		}
		/// <summary>
		/// Загрузка графа из XML. Принимает XML элемент.
		/// </summary>
		/// <param name="obj">XML элемент</param>
		/// <returns>Возвращает вершину графа.</returns>
		public static Node FromXml(XElement obj)
		{
			string pack_list = (string)obj.Attribute("V_id_str");
			var ret = new Node(
				(int)obj.Attribute("x"),
				(int)obj.Attribute("y"),
				(int)obj.Attribute("id"),
				pack_list);
			return ret;
		}
	}
}

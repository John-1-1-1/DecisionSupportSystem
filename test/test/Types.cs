using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace test
{
	public class Pos
	{
		private int? x, y;
		public Pos(int? x, int? y)	
		{
			this.x = x;
			this.y = y;
		}

		public bool isNull()
        {
			return x == null || y == null;
        }

		public bool comparer(Pos pos)
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

	internal class MassVect
	{
		public List<Graph> G  = new List<Graph>();

		DrawInScreen screen = null;
		public MassVect(DrawInScreen screen)
        {
			this.screen = screen;

		}

		public Pos CheckPoint(Pos point, int radius)
		{
			foreach (Graph g in G)
				if (Math.Sqrt(Math.Pow(g.x - point.X, 2) + Math.Pow(g.y - point.Y, 2)) <= radius)
					return new Pos(g.x, g.y);
			return point;
		}

		public Pos CheckPointNull(Pos point, int radius)
		{
			foreach (Graph g in G)
				if (Math.Sqrt(Math.Pow(g.x - point.X, 2) + Math.Pow(g.y - point.Y, 2)) <= radius)
				{
					return new Pos(g.x, g.y);
				}
			return new Pos (null, null);
		}

		public Graph getGraph(Pos point)
		{
			foreach (Graph g in G)
				if (g.x == point.X && g.y == point.Y)
					return g;
			return null;
		}

		public void DrawG()
		{
			foreach (Graph g in G)
				screen.DrawMyPoint(g.x, g.y);
		}

		public void add_vect(Pos point0, Pos point)
		{

			int id = G.Count;
			var fingGraph0 = getGraph(point0);
			var fingGraph1 = getGraph(point);
			Graph g0 = fingGraph0!=null? fingGraph0: new Graph(point0.X, point0.Y, id);
			Graph g = fingGraph1 != null ? fingGraph1 : new Graph(point.X, point.Y, id+1);
			if (CheckPointNull(point0, screen.radius).isNull())
				
				g0.V_id.Add(g);
				g.V_id.Add(g0);
				if (fingGraph0 == null)
					G.Add(g0);
				if (fingGraph1 == null)
					G.Add(g);

		}

        internal void DrawE()
        {
            foreach (Graph g in G)
				foreach (Graph i in g.V_id)
					if (i.id < g.id)
						screen.DrawMyLine(g.x, g.y, i.x,i.y);
        }

        public void del(Graph g)
        {
            G.Remove(g);
			foreach (Graph g1 in G)
				g1.V_id.Remove(g);
		}


		public void Save(string name)
        {

			var xSave = new XElement("save");
			foreach (Graph g in G)
				xSave.Add(g.Save());
			File.WriteAllText(name + ".xml", xSave.ToString());
		}
    }

	public class Graph
    {
		public int x, y;
		public int id;
		public List<Graph> V_id = new List<Graph>();
		string[] list;
		public Graph(int x, int y, int id)
        {
			this.x = x;
			this.y = y;
			this.id = id;
        }

		public Graph(int x, int y, int id, string s)
		{
			this.x = x;
			this.y = y;
			this.id = id;
			list = s.Split(' ');
		}

		public void del()
        {

        }
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

		public static Graph FromXml(XElement obj)
		{

			string pack_list = (string)obj.Attribute("V_id_str");
			var ret = new Graph(
				(int)obj.Attribute("x"),
				(int)obj.Attribute("y"),
				(int)obj.Attribute("id"),
				pack_list);
			return ret;
		}
	}
}

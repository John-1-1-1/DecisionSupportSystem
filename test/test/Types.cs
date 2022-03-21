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

		public void add_vect(int x, int y)
        {
			int id = G.Count;
			var g = CheckPointNull(new Pos(x, y),10);
			if (g.isNull())
				G.Add(new Graph(x, y, id));
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
			Graph g0 = new Graph(point0.X, point0.Y, id);
			Graph g = getGraph(point);
			if (CheckPointNull(point0, screen.radius).isNull())
				//условия
				g0.V_id.Add(g);
				g.V_id.Add(g0);
				G.Add(g0);
			
		}

        internal void DrawE()
        {
            foreach (Graph g in G)
				foreach (Graph i in g.V_id)
					if (i.id < g.id)
                    {
						screen.DrawMyLine(g.x, g.y, i.x,i.y);
                    }
        }

        public void del(Graph g)
        {
            G.Remove(g);
			foreach (Graph g1 in G)
				g1.V_id.Remove(g);
		}
    }

	public class Graph
    {
		public int x, y;
		public int id;
		public List<Graph> V_id = new List<Graph>();

		public Graph(int x, int y, int id)
        {
			this.x = x;
			this.y = y;
			this.id = id;
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
			for (int i = 0; i < V_id.Count; i++)
				V_id_str += V_id[i].ToString() + " ";
			int x1 = V_id_str.Length - 1;
			obj.Add(new XAttribute("V_id_str", V_id_str.Substring(0, x1)));
			return obj;
		}

		public static Graph FromXml(XElement obj)
		{
			var ret = new Graph(
				(int)obj.Attribute("x"),
				(int)obj.Attribute("y"),
				(int)obj.Attribute("id"));

			string pack_list = (string)obj.Attribute("V_id_str");
			List<int> ret_list = new List<int>();
			foreach(string s in  pack_list.Split(' '))
				ret_list.Add(int.Parse(s));
			//ret.V_id = ret_list;
			return ret;
		}
	}
}

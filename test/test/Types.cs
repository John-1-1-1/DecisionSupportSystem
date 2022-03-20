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
		public int x, y;
		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public class MassVect
	{
		public List<Graph> Vectors  = new List<Graph>();

		public void add_vect(int x, int y)
        {
			int id = Vectors.Count;
			Vectors.Add(new Graph(x, y, id));
        }

		
	}

	public class Graph
    {
		public int x, y;
		public int id;
		public List<int> V_id;

		public Graph(int x, int y, int id)
        {
			this.x = x;
			this.y = y;
			this.id = id;
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
			ret.V_id = ret_list;
			return ret;
		}
	}
}

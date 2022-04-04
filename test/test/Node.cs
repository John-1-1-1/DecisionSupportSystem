using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test
{
	/// <summary>
	/// Класс Вершины.
	/// </summary>
	public class Node
	{
		public bool IsClick = false;
		public int x { get; set; }
		public int y { get; set; }
		public int id { get; set; }
		public string ip { get; set; }
		public string name { get; set; }
		/// <summary>
		/// Идентификаторы графов имеющих общее ребро.
		/// </summary>
		public List<Node> V_id = new List<Node>();

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
			//ДОДЕЛАТЬ
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

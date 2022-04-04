using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		/// Прибавить смещение
		/// </summary>
		/// <param name="screen"></param>
		/// <returns></returns>
		public Point Plus(DrawInScreen screen)
        {
			x += screen.offset.x;
			y += screen.offset.y;
			return this;
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
		public bool isNull
		{
			get
            {
				return x == null || y == null;
			}
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
}

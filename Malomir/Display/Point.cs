using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malomir.Display {

	public class Point {

		public static Point Zero { get; } = new Point();

		public int X { get; set; } = 0;
		public int Y { get; set; } = 0;

		public Point() {

		}

		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		public Point Move(int deltaX, int deltaY) {
			return new Point(X + deltaX, Y + deltaY);

		}

	}
}

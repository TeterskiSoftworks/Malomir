using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malomir.Display {

	/// <summary>
	/// A class representing a point in 2D space.
	/// </summary>
	public class Point {

		/// <summary>
		/// Gets a point with the coordinates (0, 0).
		/// </summary>
		public static Point Zero { get; } = new Point();

		/// <summary>
		/// Gets or sets the <see cref="X"/> coordinate.
		/// </summary>
		public int X { get; set; } = 0;
		/// <summary>
		/// Gets or sets the <see cref="XY"/> coordinate.
		/// </summary>
		public int Y { get; set; } = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="Point"/> class.
		/// </summary>
		public Point() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Point"/> class.
		/// </summary>
		/// <param name="x">The <see cref="X"/> coordinate.</param>
		/// <param name="y">The <see cref="Y"/> coordinate.</param>
		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		/// <summary>
		/// Creates a new point with the specified differences in <see cref="X"/> and <see cref="Y"/> from the original.
		/// </summary>
		/// <param name="deltaX">Change in <see cref="X"/>.</param>
		/// <param name="deltaY">Change in <see cref="Y"/>.</param>
		/// <returns>A new point with the translated coordinates.</returns>
		public Point Move(int deltaX, int deltaY) {
			return new Point(X + deltaX, Y + deltaY);

		}

	}
}

using Microsoft.Xna.Framework;

namespace Malomir.Display {
	public abstract class Element {

		/// <summary>
		/// Gets or sets the position <see cref="Point"/>.
		/// </summary>
		public Point Pos { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// Gets or sets the size in <seealso cref="Symbol"/>s.
		/// </summary> <value> The height. </value>
		public Point Size { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// A point that contains the minimum X and Y values that are visible.
		/// </summary>
		public Point Min { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// A point that contains the maximum X and Y values that are visible.
		/// </summary>
		public Point Max { get; set; } = new Point { X = 0, Y = 0 };

		/// <summary>
		/// The foreground color of the <see cref="Window"/>.
		/// </summary>
		public Color FGColor { get; set; } = Color.White;
		/// <summary>
		/// The background color of the <see cref="Window"/>.
		/// </summary>
		public Color BGColor { get; set; } = Color.Black;

		/// <summary>
		/// Gets or sets the foreground <see cref="Symbol.ASCII"/> to be displayed from the tileset.
		/// </summary>
		public Rectangle Foreground { get; set; } = Symbol.ASCII.Nul;
		/// <summary>
		/// Gets or sets the background <see cref="Symbol.ASCII"/> to be displayed from the tileset.
		/// </summary>
		public Rectangle Background { get; set; } = Symbol.ASCII.FullBlock;

		/// <summary>
		/// The look of the <see cref="Border"/>.
		/// </summary>
		public Border Border { get; set; }

		/// <summary>
		/// Gets or sets the title of the <see cref="Element"/>.
		/// </summary>
		public SymbolString Title { get; set; }

		/// <summary>
		/// Sets the <see cref="Border"/>.
		/// </summary>
		/// <param name="border">The <see cref="Border"/> to be set.</param>
		public void SetBorder(Border border) {
			Border = border;
			Title.FGColor = Border.BGColor;
			Title.BGColor = Border.FGColor;
		}

		/// <summary>
		/// Adds the <see cref="Element"/>'s visual information to the <see cref="Screen"/>.
		/// It does not draw the <see cref="Element"/>.
		/// </summary>
		public abstract void Show();

	}
}

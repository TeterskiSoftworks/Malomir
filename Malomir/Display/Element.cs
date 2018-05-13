using Microsoft.Xna.Framework;

namespace Malomir.Display {
	public abstract class Element : IShowable {

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

			Border.Top = border.Top;
			Border.Left = border.Left;
			Border.Right = border.Right;
			Border.Bottom = border.Bottom;

			Border.TopLeft = border.TopLeft;
			Border.TopRight = border.TopRight;
			Border.BottomLeft = border.BottomLeft;
			Border.BottomRight = border.BottomRight;
			
			Border.Title.FGColor = Border.FGColor;
			Border.Title.BGColor = Border.BGColor;
		}

		/// <summary>
		/// Adds the <see cref="Element"/>'s visual information to the <see cref="Screen"/>.
		/// It does not draw the <see cref="Element"/>.
		/// </summary>
		public abstract void Show();

		/// <summary>
		/// Adds the <see cref="Elements"/>'s background visual information to the <see cref="Screen"/>.
		/// </summary>
		public void ShowBackground() {
			for (int y = (Pos.Y > Min.Y ? Pos.Y : Min.Y); (y <= Pos.Y + Size.Y) && (y <= Max.Y); y++) {

				for (int x = (Pos.X > Min.X ? Pos.X : Min.X); (x <= Pos.X + Size.X) && (x <= Max.X); x++) {
					if (GetType() == typeof(Button)) {
						int a = 2;
					}
					Screen.SymbolAt(x, y).BGColor = BGColor;
					Screen.SymbolAt(x, y).FGColor = FGColor;
					Screen.SymbolAt(x, y).Foreground = Foreground;
					Screen.SymbolAt(x, y).Background = Background;
				}
			}
		}


	}
}

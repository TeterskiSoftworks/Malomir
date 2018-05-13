using Microsoft.Xna.Framework;

namespace Malomir.Display {

	/// <summary>
	/// A struct representing a <see cref="Border"/>.
	/// </summary>
	public struct Border {

		/// <summary>
		/// Gets the default <see cref="Window"/> <see cref="Border"/>.
		/// </summary>
		/// <value>
		/// The default <see cref="Window"/> <see cref="Border"/>.
		/// </value>
		public static Border DefaultWindowBorder { get; } = new Border {
			Enabled = true,
			FGColor = Color.White,
			BGColor = Color.Blue,
			Top = Symbol.ASCII.HorizontalDouble,
			Left = Symbol.ASCII.VerticalSingle,
			Right = Symbol.ASCII.VerticalSingle,
			Bottom = Symbol.ASCII.HorizontalSingle,
			TopLeft = Symbol.ASCII.DownSingleRightDouble,
			TopRight = Symbol.ASCII.DownSingleLeftDouble,
			BottomLeft = Symbol.ASCII.UpSingleRightSingle,
			BottomRight = Symbol.ASCII.UpSingleLeftSingle

		};

		public static Border DefaultSubWindowBorder { get; } = new Border {
			Enabled = true,
			FGColor = Color.Yellow,
			BGColor = Color.Black,
			Top = Symbol.ASCII.HorizontalDouble,
			Left = Symbol.ASCII.VerticalSingle,
			Right = Symbol.ASCII.VerticalSingle,
			Bottom = Symbol.ASCII.HorizontalSingle,
			TopLeft = Symbol.ASCII.DownSingleRightDouble,
			TopRight = Symbol.ASCII.DownSingleLeftDouble,
			BottomLeft = Symbol.ASCII.UpSingleRightSingle,
			BottomRight = Symbol.ASCII.UpSingleLeftSingle

		};

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Border"/> is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		public bool Enabled { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the top <see cref="Border"/>.
		/// </summary>
		public Rectangle Top { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the left <see cref="Border"/>.
		/// </summary>
		public Rectangle Left { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the right <see cref="Border"/>.
		/// </summary>
		public Rectangle Right { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the bottom <see cref="Border"/>.
		/// </summary>
		public Rectangle Bottom { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the <see cref="Border"/>'s top left corner.
		/// </summary>
		public Rectangle TopLeft { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the <see cref="Border"/>'s top right corner.
		/// </summary>
		public Rectangle TopRight { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the <see cref="Border"/>'s bottom left corner.
		/// </summary>
		public Rectangle BottomLeft { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Symbol.ASCII"/> of the <see cref="Border"/>'s bottom right corner.
		/// </summary>
		public Rectangle BottomRight { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Border"/>'s foreground color.
		/// </summary>
		public Color FGColor { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Border"/>'s background color.
		/// </summary>
		public Color BGColor { get; set; }

	}
}

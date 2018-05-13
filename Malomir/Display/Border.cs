using Microsoft.Xna.Framework;

namespace Malomir.Display {

	public struct Border {

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

		public bool Enabled { get; set; }

		public Rectangle Top { get; set; }
		public Rectangle Left { get; set; }
		public Rectangle Right { get; set; }
		public Rectangle Bottom { get; set; }
		public Rectangle TopLeft { get; set; }
		public Rectangle TopRight { get; set; }
		public Rectangle BottomLeft { get; set; }
		public Rectangle BottomRight { get; set; }

		public Color FGColor { get; set; }
		public Color BGColor { get; set; }

	}
}

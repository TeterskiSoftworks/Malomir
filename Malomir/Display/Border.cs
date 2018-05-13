using Microsoft.Xna.Framework;

namespace Malomir.Display {

	/// <summary>
	/// A struct representing a <see cref="Border"/>.
	/// </summary>
	public class Border : Element {

		/// <summary>
		/// Gets the default <see cref="Window"/> <see cref="Border"/>.
		/// </summary>
		/// <value>
		/// The default <see cref="Window"/> <see cref="Border"/>.
		/// </value>
		public static Border DefaultWindowBorder { get; } = new Border {
			Enabled = true,
			FGColor = Color.Gray,
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
		/// Gets the default <see cref="Button"/> <see cref="Border"/>.
		/// </summary>
		/// <value>
		/// The default <see cref="Button"/> <see cref="Border"/>.
		/// </value>
		public static Border DefaultButtonBorder { get; } = new Border {
			Enabled = true,
			FGColor = Color.Gray,
			BGColor = Color.Black,
			Top = Symbol.ASCII.HorizontalDouble,
			Left = Symbol.ASCII.VerticalDouble,
			Right = Symbol.ASCII.VerticalDouble,
			Bottom = Symbol.ASCII.HorizontalDouble,
			TopLeft = Symbol.ASCII.DownDoubleRightDouble,
			TopRight = Symbol.ASCII.DownDoubleLeftDouble,
			BottomLeft = Symbol.ASCII.UpDoubleRightDouble,
			BottomRight = Symbol.ASCII.UpDoubleLeftDouble

		};

		public static Border DefaultSubWindowBorder { get; } = new Border {
			Enabled = true,
			FGColor = Color.White,
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

		public Border() {}


		public Border(Point pos, Point size, Point min, Point max) {
			Pos = pos;
			Size = size;
			Min = min;
			Max = max;
		}


		/// <summary>
		/// Adds the <see cref="Border"/>'s visual information to the <see cref="Screen"/>.
		/// </summary>
		public override void Show() {

			if (Enabled) return;

			//top and bottom
			for (int i = (Pos.X + 1 > Min.X ? Pos.X + 1 : Min.X); (i < Pos.X + Size.X) && (i < Max.X); i++) {

				if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= Min.Y) {
					Screen.SymbolAt(i, Pos.Y + Size.Y).Foreground = Bottom;
					Screen.SymbolAt(i, Pos.Y + Size.Y).FGColor = FGColor;
					Screen.SymbolAt(i, Pos.Y + Size.Y).BGColor = BGColor;
				}

				if (Pos.Y < Min.Y) continue;
				if (Pos.Y >= Max.Y) continue;
				//if (i < Pos.X + Title.Length + 1) continue;
				Screen.SymbolAt(i, Pos.Y).Foreground = Top;
				Screen.SymbolAt(i, Pos.Y).FGColor = FGColor;
				Screen.SymbolAt(i, Pos.Y).BGColor = BGColor;
			}


			//left and right
			for (int i = (Pos.Y + 1 > Min.Y ? Pos.Y + 1 : Min.Y); (i < Pos.Y + Size.Y) && (i < Max.Y); i++) {

				if (Pos.X + Size.X <= Max.X && Pos.X + Size.X >= Min.X) {
					Screen.SymbolAt(Pos.X + Size.X, i).Foreground = Right;
					Screen.SymbolAt(Pos.X + Size.X, i).FGColor = FGColor;
					Screen.SymbolAt(Pos.X + Size.X, i).BGColor = BGColor;
				}

				if (Pos.X < Min.X) continue;
				if (Pos.X >= Max.X) continue;
				Screen.SymbolAt(Pos.X, i).Foreground = Left;
				Screen.SymbolAt(Pos.X, i).FGColor = FGColor;
				Screen.SymbolAt(Pos.X, i).BGColor = BGColor;


			}

			#region Corners
			if (Pos.X <= Max.X) {

				if (Pos.X >= Min.X) {
					if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
						Screen.SymbolAt(Pos.X, Pos.Y).Foreground = TopLeft;
						Screen.SymbolAt(Pos.X, Pos.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X, Pos.Y).BGColor = BGColor;
					}

					if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= 0) {
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).Foreground = BottomLeft;
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).BGColor = BGColor;
					}
				}
			}

			if (Pos.X + Size.X <= Max.X) {

				if (Pos.X + Size.X >= Min.X) {

					if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).Foreground = TopRight;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).BGColor = BGColor;
					}

					if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= Min.Y) {
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).Foreground = BottomRight;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).BGColor = BGColor;
					}
				}
			}
			#endregion

			Title.Show();
		}

		/// <summary>
		/// Copies the look of the given <see cref="Border"/>.
		/// </summary>
		/// <param name="border">The <see cref="Border"/> whos look will be copied.</param>
		public void SetStyle(Border border) {
			Border.Top = border.Top;
			Border.Left = border.Left;
			Border.Right = border.Right;
			Border.Bottom = border.Bottom;


			Title.FGColor = Border.FGColor;
			Title.BGColor = Border.BGColor;
		}
	}
}

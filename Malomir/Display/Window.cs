using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Malomir.Display {


	public class Window {

		/// <summary>
		/// Gets or sets the position <see cref="Point"/>.
		/// </summary>
		public Point Pos { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// Gets or sets the size in <seealso cref="Symbol"/>s.
		/// </summary> <value> The height. </value>
		public Point Size { get; set; } = new Point { X = 0, Y = 0};
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
		public Color BGColor { get; set; } = Color.Red;

		/// <summary>
		/// Gets or sets the foreground <see cref="Symbol.ASCII"/> to be displayed from the tileset.
		/// </summary>
		public Rectangle Foreground { get; set; } = Symbol.ASCII.Nul;
		/// <summary>
		/// Gets or sets the background <see cref="Symbol.ASCII"/> to be displayed from the tileset.
		/// </summary>
		public Rectangle Background { get; set; } = Symbol.ASCII.FullBlock;

		/// <summary>
		/// Gets or sets the name of the <see cref="Window"/>.
		/// </summary>
		public SymbolString Name { get; set; }

		/// <summary>
		/// The look of the <see cref="Border"/>.
		/// </summary>
		private Border Border = Border.DefaultWindowBorder;
		/// <summary>
		/// A list of other <see cref="Window"/>s contained inside this <see cref="Window"/>.
		/// </summary>
		private List<Window> windows = new List<Window>(0);

		/// <summary>
		/// Initializes a new instance of the <see cref="Window"/> class.
		/// </summary>
		public Window() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Window"/> class.
		/// </summary>
		/// <param name="pos">The position of the <see cref="Window"/>.</param>
		/// <param name="size">The size of the <see cref="Window"/>.</param>
		/// <param name="min">The minimum X and Y values that are visible.</param>
		/// <param name="max">The maximum X and Y values that are visible.</param>
		/// <param name="name">The name of the <see cref="Window"/>.</param>
		public Window(Point pos, Point size, Point min, Point max, String name) {

			Pos = pos;
			Size = size;
			Min = min;
			Max = max;

			Name = new SymbolString(Pos.Move(1, 0), Min, Max, Size.X - 2, name) {
				BGColor = Border.FGColor,
				FGColor = Border.BGColor
			};

			ReDraw();
		}


		public void ReDraw() {

			ReDrawBackground();

			foreach (Window w in windows) {
				w.ReDraw();
			}
		}

		private void ReDrawBackground() {

			for(int y = (Pos.Y > Min.Y ? Pos.Y : Min.Y); (y < Pos.Y + Size.Y) && (y < Max.Y); y++) {

				for (int x = (Pos.X > Min.X ? Pos.X : Min.X);  (x < Pos.X + Size.X) && (x < Max.X); x++) {
					Screen.SymbolAt(x, y).BGColor = BGColor;
					Screen.SymbolAt(x, y).FGColor = FGColor;
					Screen.SymbolAt(x, y).Foreground = Foreground;
					Screen.SymbolAt(x, y).Background = Background;
				}
			}

			ReDrawBorder();
		}

		private void ReDrawBorder() {

			if (!Border.Enabled) return;

			Name.Draw();

			//top and bottom
			for (int i = (Pos.X + 1 > Min.X ? Pos.X + 1: Min.X); (i < Pos.X + Size.X) && (i < Max.X); i++) {

				if (Pos.Y + Size.Y < Max.Y && Pos.Y + Size.Y >= Min.Y) {
					Screen.SymbolAt(i, Pos.Y + Size.Y).Foreground = Border.Bottom;
					Screen.SymbolAt(i, Pos.Y + Size.Y).FGColor = Border.FGColor;
					Screen.SymbolAt(i, Pos.Y + Size.Y).BGColor = Border.BGColor;
				}

				if (Pos.Y < Min.Y) continue;
				if (Pos.Y >= Max.Y) continue;
				if (i < Pos.X + Name.Length + 1) continue;
				Screen.SymbolAt(i, Pos.Y).Foreground = Border.Top;
				Screen.SymbolAt(i, Pos.Y).FGColor = Border.FGColor;
				Screen.SymbolAt(i, Pos.Y).BGColor = Border.BGColor;
			}
			

			//left and right
			for (int i = (Pos.Y + 1 > Min.Y ? Pos.Y + 1 : Min.Y); (i < Pos.Y + Size.Y) && (i < Max.Y); i++) {

				if (Pos.X + Size.X < Max.X && Pos.X + Size.X >= Min.X) {
					Screen.SymbolAt(Pos.X + Size.X, i).Foreground = Border.Right;
					Screen.SymbolAt(Pos.X + Size.X, i).FGColor = Border.FGColor;
					Screen.SymbolAt(Pos.X + Size.X, i).BGColor = Border.BGColor;
				}

				if (Pos.X < Min.X) continue;
				if (Pos.X >= Max.X) continue;
				Screen.SymbolAt(Pos.X, i).Foreground = Border.Left;
				Screen.SymbolAt(Pos.X, i).FGColor = Border.FGColor;
				Screen.SymbolAt(Pos.X, i).BGColor = Border.BGColor;


			}

			#region Corners
			if (Pos.X <= Max.X) {

				if (Pos.X >= Min.X) {
					if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
						Screen.SymbolAt(Pos.X, Pos.Y).Foreground = Border.TopLeft;
						Screen.SymbolAt(Pos.X, Pos.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Pos.X, Pos.Y).BGColor = Border.BGColor;
					}

					if (Pos.Y + Size.Y < Max.Y && Pos.Y + Size.Y >= 0) {
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).Foreground = Border.BottomLeft;
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Pos.X, Pos.Y + Size.Y).BGColor = Border.BGColor;
					}
				}
			}

			if (Pos.X + Size.X <= Max.X) {

				if (Pos.X + Size.X >= Min.X) {

					if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).Foreground = Border.TopRight;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y).BGColor = Border.BGColor;
					}

					if (Pos.Y + Size.Y < Max.Y && Pos.Y + Size.Y >= Min.Y) {
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).Foreground = Border.BottomRight;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Pos.X + Size.X, Pos.Y + Size.Y).BGColor = Border.BGColor;
					}
				}
			}
			#endregion
		}

	}

}

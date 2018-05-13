using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Malomir.Display {


	public class Window {


		public Point Origin { get; set; } = new Point { X = 0, Y = 0 };
		public Point Size { get; set; } = new Point { X = 0, Y = 0};
		public Point Min { get; set; } = new Point { X = 0, Y = 0 };
		public Point Max { get; set; } = new Point { X = 0, Y = 0 };

		public Color FGColor { get; set; } = Color.White;
		public Color BGColor { get; set; } = Color.Red;

		public Rectangle Foreground { get; set; } = Symbol.ASCII.Nul;
		public Rectangle Background { get; set; } = Symbol.ASCII.FullBlock;

		public SymbolString Name { get; set; }

		private Border Border = Border.DefaultWindowBorder;
		private List<Window> windows = new List<Window>(0);

		public Window() {
		}

		public Window(Point origin, Point size, Point min, Point max, String name) {

			Origin = origin;
			Size = size;
			Min = min;
			Max = max;

			Name = new SymbolString(Origin.Move(1, 0), Min, Max, Size.X - 2, name) {
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

			for(int y = (Origin.Y > Min.Y ? Origin.Y : Min.Y); (y < Origin.Y + Size.Y) && (y < Max.Y); y++) {

				for (int x = (Origin.X > Min.X ? Origin.X : Min.X);  (x < Origin.X + Size.X) && (x < Max.X); x++) {
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
			for (int i = (Origin.X + 1 > Min.X ? Origin.X + 1: Min.X); (i < Origin.X + Size.X) && (i < Max.X); i++) {

				if (Origin.Y + Size.Y < Max.Y && Origin.Y + Size.Y >= Min.Y) {
					Screen.SymbolAt(i, Origin.Y + Size.Y).Foreground = Border.Bottom;
					Screen.SymbolAt(i, Origin.Y + Size.Y).FGColor = Border.FGColor;
					Screen.SymbolAt(i, Origin.Y + Size.Y).BGColor = Border.BGColor;
				}

				if (Origin.Y < Min.Y) continue;
				if (Origin.Y >= Max.Y) continue;
				if (i < Origin.X + Name.Length + 1) continue;
				Screen.SymbolAt(i, Origin.Y).Foreground = Border.Top;
				Screen.SymbolAt(i, Origin.Y).FGColor = Border.FGColor;
				Screen.SymbolAt(i, Origin.Y).BGColor = Border.BGColor;
			}
			

			//left and right
			for (int i = (Origin.Y + 1 > Min.Y ? Origin.Y + 1 : Min.Y); (i < Origin.Y + Size.Y) && (i < Max.Y); i++) {

				if (Origin.X + Size.X < Max.X && Origin.X + Size.X >= Min.X) {
					Screen.SymbolAt(Origin.X + Size.X, i).Foreground = Border.Right;
					Screen.SymbolAt(Origin.X + Size.X, i).FGColor = Border.FGColor;
					Screen.SymbolAt(Origin.X + Size.X, i).BGColor = Border.BGColor;
				}

				if (Origin.X < Min.X) continue;
				if (Origin.X >= Max.X) continue;
				Screen.SymbolAt(Origin.X, i).Foreground = Border.Left;
				Screen.SymbolAt(Origin.X, i).FGColor = Border.FGColor;
				Screen.SymbolAt(Origin.X, i).BGColor = Border.BGColor;


			}

			#region Corners
			if (Origin.X <= Max.X) {

				if (Origin.X >= Min.X) {
					if (Origin.Y >= Min.Y && Origin.Y < Max.Y) {
						Screen.SymbolAt(Origin.X, Origin.Y).Foreground = Border.TopLeft;
						Screen.SymbolAt(Origin.X, Origin.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Origin.X, Origin.Y).BGColor = Border.BGColor;
					}

					if (Origin.Y + Size.Y < Max.Y && Origin.Y + Size.Y >= 0) {
						Screen.SymbolAt(Origin.X, Origin.Y + Size.Y).Foreground = Border.BottomLeft;
						Screen.SymbolAt(Origin.X, Origin.Y + Size.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Origin.X, Origin.Y + Size.Y).BGColor = Border.BGColor;
					}
				}
			}

			if (Origin.X + Size.X <= Max.X) {

				if (Origin.X + Size.X >= Min.X) {

					if (Origin.Y >= Min.Y && Origin.Y < Max.Y) {
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y).Foreground = Border.TopRight;
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y).BGColor = Border.BGColor;
					}

					if (Origin.Y + Size.Y < Max.Y && Origin.Y + Size.Y >= Min.Y) {
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y + Size.Y).Foreground = Border.BottomRight;
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y + Size.Y).FGColor = Border.FGColor;
						Screen.SymbolAt(Origin.X + Size.X, Origin.Y + Size.Y).BGColor = Border.BGColor;
					}
				}
			}
			#endregion
		}

	}

}

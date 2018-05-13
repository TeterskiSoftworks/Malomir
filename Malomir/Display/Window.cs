using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Malomir.Display {


	public class Window {

		public int X { get; set; } = 0;
		public int Y { get; set; } = 0;
		public int Width { get; private set; } = 4;
		public int Height { get; private set; } = 4;

		public Color FGColor { get; set; } = Color.White;
		public Color BGColor { get; set; } = Color.Red;

		public Rectangle Foreground { get; set; } = Symbol.ASCII.Nul;
		public Rectangle Background { get; set; } = Symbol.ASCII.FullBlock;

		public SymbolString Name { get; set; }

		private Border Border = Border.DefaultWindowBorder;
		private List<Window> windows = new List<Window>(0);

		public Window() {
		}


		public Window(int x, int y, int width, int height) {
			X = x;
			Y = y;
			Width = width - 1;
			Height = height - 1;
		}

		public Window(int x, int y, int width, int height, String name) {
			X = x;
			Y = y;
			Width = width - 1;
			Height = height - 1;
			Name = new SymbolString(x + 1, y, Width - 2, name) {
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

			for(int y = (Y > 0 ? Y : 0); (y < Y + Height) && (y < Screen.Height); y++) {
				for(int x = (X > 0 ? X : 0);  (x < X + Width) && (x < Screen.Width); x++) {
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

			//top and bottom
			for (int i = ( X + 1 > 0 ? X + 1: 0); (i < X + Width) && (i < Screen.Width); i++) {

				if (Y + Height < Screen.Height && Y + Height >= 0) {
					Screen.SymbolAt(i, Y + Height).Foreground = Border.Bottom;
					Screen.SymbolAt(i, Y + Height).FGColor = Border.FGColor;
					Screen.SymbolAt(i, Y + Height).BGColor = Border.BGColor;
				}

				if (Y < 0) continue;
				if (Y >= Screen.Height) continue;
				if (i < X + Name.Length + 1) continue;
				Screen.SymbolAt(i, Y).Foreground = Border.Top;
				Screen.SymbolAt(i, Y).FGColor = Border.FGColor;
				Screen.SymbolAt(i, Y).BGColor = Border.BGColor;
			}
			Name.Draw();

			//left and right
			for (int i = (Y + 1 > 0 ? Y + 1 : 0); (i < Y + Height) && (i < Screen.Height); i++) {

				if (X + Width < Screen.Width && X + Width >= 0) {
					Screen.SymbolAt(X + Width, i).Foreground = Border.Right;
					Screen.SymbolAt(X + Width, i).FGColor = Border.FGColor;
					Screen.SymbolAt(X + Width, i).BGColor = Border.BGColor;
				}

				if (X < 0) continue;
				if (X >= Screen.Width) continue;
				Screen.SymbolAt(X, i).Foreground = Border.Left;
				Screen.SymbolAt(X, i).FGColor = Border.FGColor;
				Screen.SymbolAt(X, i).BGColor = Border.BGColor;


			}

			#region Corners
			if (X <= Screen.Width) {

				if (X >= 0) {
					if (Y >= 0 && Y < Screen.Height) {
						Screen.SymbolAt(X, Y).Foreground = Border.TopLeft;
						Screen.SymbolAt(X, Y).FGColor = Border.FGColor;
						Screen.SymbolAt(X, Y).BGColor = Border.BGColor;
					}

					if (Y + Height < Screen.Height && Y + Height >= 0) {
						Screen.SymbolAt(X, Y + Height).Foreground = Border.BottomLeft;
						Screen.SymbolAt(X, Y + Height).FGColor = Border.FGColor;
						Screen.SymbolAt(X, Y + Height).BGColor = Border.BGColor;
					}
				}
			}

			if (X + Width <= Screen.Width) {

				if (X + Width >= 0) {

					if (Y >= 0 && Y < Screen.Height) {
						Screen.SymbolAt(X + Width, Y).Foreground = Border.TopRight;
						Screen.SymbolAt(X + Width, Y).FGColor = Border.FGColor;
						Screen.SymbolAt(X + Width, Y).BGColor = Border.BGColor;
					}

					if (Y + Height < Screen.Height && Y + Height >= 0) {
						Screen.SymbolAt(X + Width, Y + Height).Foreground = Border.BottomRight;
						Screen.SymbolAt(X + Width, Y + Height).FGColor = Border.FGColor;
						Screen.SymbolAt(X + Width, Y + Height).BGColor = Border.BGColor;
					}
				}
			}
			#endregion
		}

	}

}

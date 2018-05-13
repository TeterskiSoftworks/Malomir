using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Malomir.Display {


	public class Window : Element {
		

		/// <summary>
		/// A list of other <see cref="Window"/>s contained inside this <see cref="Window"/>.
		/// </summary>
		private List<Element> Elements { get; } = new List<Element>(0);

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

			Title = new SymbolString(Pos.Move(1, 0), Min, Max, Size.X - 2, name);

			SetBorder(Border.DefaultWindowBorder);
		}


		/// <summary>
		/// Adds a <see cref="Element"/> inside this <see cref="Window"/>.
		/// </summary>
		/// <param name="element">The <see cref="Element"/> to be added.</param>
		public void AddElement(Element element) {
			Elements.Add(element);
			element.Max = Max.Move(-1,-1);
			element.Min = Min.Move(1, 1);
		}

		/// <summary>
		/// Adds the <see cref="Window"/>'s visual information to the <see cref="Screen"/>.
		/// It does not draw the <see cref="Window"/>.
		/// </summary>
		public override void Show() {

			ShowBackground();

			foreach (Window w in Elements) {
				w.Show();
			}

			ShowBorder();
		}

		/// <summary>
		/// Adds the <see cref="Window"/>'s background visual information to the <see cref="Screen"/>.
		/// </summary>
		private void ShowBackground() {

			for(int y = (Pos.Y > Min.Y ? Pos.Y : Min.Y); (y <= Pos.Y + Size.Y) && (y <= Max.Y); y++) {

				for (int x = (Pos.X > Min.X ? Pos.X : Min.X);  (x <= Pos.X + Size.X) && (x <= Max.X); x++) {
					Screen.SymbolAt(x, y).BGColor = BGColor;
					Screen.SymbolAt(x, y).FGColor = FGColor;
					Screen.SymbolAt(x, y).Foreground = Foreground;
					Screen.SymbolAt(x, y).Background = Background;
				}
			}
		}

		/// <summary>
		/// Adds the <see cref="Border"/>'s visual information to the <see cref="Screen"/>.
		/// </summary>
		private void ShowBorder() {

			if (!Border.Enabled) return;

			Title.Show();

			//top and bottom
			for (int i = (Pos.X + 1 > Min.X ? Pos.X + 1: Min.X); (i < Pos.X + Size.X) && (i < Max.X); i++) {

				if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= Min.Y) {
					Screen.SymbolAt(i, Pos.Y + Size.Y).Foreground = Border.Bottom;
					Screen.SymbolAt(i, Pos.Y + Size.Y).FGColor = Border.FGColor;
					Screen.SymbolAt(i, Pos.Y + Size.Y).BGColor = Border.BGColor;
				}

				if (Pos.Y < Min.Y) continue;
				if (Pos.Y >= Max.Y) continue;
				if (i < Pos.X + Title.Length + 1) continue;
				Screen.SymbolAt(i, Pos.Y).Foreground = Border.Top;
				Screen.SymbolAt(i, Pos.Y).FGColor = Border.FGColor;
				Screen.SymbolAt(i, Pos.Y).BGColor = Border.BGColor;
			}
			

			//left and right
			for (int i = (Pos.Y + 1 > Min.Y ? Pos.Y + 1 : Min.Y); (i < Pos.Y + Size.Y) && (i < Max.Y); i++) {

				if (Pos.X + Size.X <= Max.X && Pos.X + Size.X >= Min.X) {
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

					if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= 0) {
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

					if (Pos.Y + Size.Y <= Max.Y && Pos.Y + Size.Y >= Min.Y) {
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

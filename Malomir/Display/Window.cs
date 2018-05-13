using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Malomir.Display {

	/// <summary>
	/// A class representing a Window object.
	/// </summary>
	/// <seealso cref="Element" />
	/// <seealso cref="Screen"/>
	public class Window : Element {

		public new SymbolString Title { get => Border.Title; set => Border.Title = value; }

		/// <summary>
		/// A list of other <see cref="Window"/>s contained inside this <see cref="Window"/>.
		/// </summary>
		private List<Element> Elements { get; } = new List<Element>(0);

		/// <summary>
		/// Initializes a new instance of the <see cref="Window"/> class.
		/// </summary>
		public Window() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Window"/> class.
		/// </summary>
		/// <param name="pos">The position of the <see cref="Window"/>.</param>
		/// <param name="size">The size of the <see cref="Window"/>.</param>
		/// <param name="min">The minimum X and Y values that are visible.</param>
		/// <param name="max">The maximum X and Y values that are visible.</param>
		/// <param name="title">The name of the <see cref="Window"/>.</param>
		public Window(Point pos, Point size, Point min, Point max, String title) {

			Pos = pos;
			Size = size;
			Min = min;
			Max = max;

			Border = new Border(Pos, Size, Min, Max);
			Title = new SymbolString(Pos.Move(1, 0), Min, Max, Size.X - 2, title);

			SetBorder(Border.DefaultWindowBorder);
		}


		/// <summary>
		/// Adds a <see cref="Element"/> inside this <see cref="Window"/>.
		/// </summary>
		/// <param name="element">The <see cref="Element"/> to be added.</param>
		public void AddElement(Element element) {
			Elements.Add(element);
			element.Max = Pos.Move(Size.X,Size.Y);
			element.Min = Pos.Move(1, 1);
			element.Border.Max = element.Max;
			element.Border.Min = element.Min;
		}

		/// <summary>
		/// Adds the <see cref="Window"/>'s visual information to the <see cref="Screen"/>.
		/// It does not draw the <see cref="Window"/>.
		/// </summary>
		public override void Show() {

			ShowBackground();

			foreach (Element e in Elements) {
				e.Show();
			}

			Border.Show();
		}


	}

}

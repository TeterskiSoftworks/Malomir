using System;

namespace Malomir.Display {

	public class Button : Element{

		public new SymbolString Title { get => Border.Title; set => Border.Title = value; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Button"/> class.
		/// </summary>
		/// <param name="pos">The position of the <see cref="Button"/>.</param>
		/// <param name="size">The size of the <see cref="Button"/>.</param>
		/// <param name="min">The minimum X and Y values that are visible.</param>
		/// <param name="max">The maximum X and Y values that are visible.</param>
		/// <param name="name">The name of the <see cref="Button"/>.</param>
		public Button(Point pos, Point size, Point min, Point max, String title) {

			Pos = pos;
			Size = size;
			Min = min;
			Max = max;

			Border = new Border(Pos, Size, Min, Max);
			Title = new SymbolString(Pos.Move(1, 1), Min, Max, Size.X-2, title);

			SetBorder(Border.DefaultButtonBorder);
		}

		public override void Show() {
			ShowBackground();
			Border.Show();
		}


	}
}

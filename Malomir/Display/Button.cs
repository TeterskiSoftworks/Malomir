using System;

namespace Malomir.Display {

	public class Button : Element{

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

			Title = new SymbolString(Pos.Move(1, 0), Min, Max, Size.X, title);

			SetBorder(Border.DefaultButtonBorder);
		}

		public override void Show() {
			throw new NotImplementedException();
		}
	}
}

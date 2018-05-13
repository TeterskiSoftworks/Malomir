using Microsoft.Xna.Framework;
using System;

namespace Malomir.Display {

	/// <summary>
	/// Represents a string of <see cref="Symbol"/>'s.
	/// </summary>
	/// <seealso cref="IShowable" />
	public class SymbolString : IShowable{

		/// <summary>
		/// Gets or sets the text of the string.
		/// </summary>
		public String Text { get; set; }

		/// <summary>
		/// Gets the full length of the string.
		/// </summary>
		public int Length { get => (Text.Length < AllowedLength) ? Text.Length : AllowedLength; }

		/// <summary>
		/// Gets or sets how long the string is allowed to be.
		/// </summary>
		public int AllowedLength { get; set; }

		/// <summary>
		/// Gets or sets the position <see cref="Point"/>.
		/// </summary>
		public Point Pos { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// A point that contains the minimum X and Y values that are visible.
		/// </summary>
		public Point Min { get; set; } = new Point { X = 0, Y = 0 };
		/// <summary>
		/// A point that contains the maximum X and Y values that are visible.
		/// </summary>
		public Point Max { get; set; } = new Point { X = 0, Y = 0 };

		/// <summary>
		/// The position of the "cursor". It dictates which element is about to be drawn next.
		/// </summary>
		private int cursorPosition = 0;
		/// <summary>
		/// The <see cref="Symbol.ASCII"/> representation of the character at the <see cref="cursorPosition"/>.
		/// </summary>
		private Rectangle currentSymbol;

		/// <summary>
		/// The background color of the <see cref="Symbol"/>.
		/// </summary>
		public Color BGColor { get; set; }

		/// <summary>
		/// The foreground color of the <see cref="Symbol"/>.
		/// </summary>
		public Color FGColor { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SymbolString"/> class.
		/// </summary>
		/// <param name="origin">The origin.</param>
		/// <param name="min">The minimum X and Y values that are visible.</param>
		/// <param name="max">The maximum X and Y values that are visible.</param>
		/// <param name="allowedLength">The allowed length of the string..</param>
		/// <param name="text">The text.</param>
		public SymbolString(Point position, Point min, Point max, int allowedLength, String text) {

			Pos = position;
			Min = min;
			Max = max;

			Text = text;
			AllowedLength = allowedLength;
		}

		/// <summary>
		/// Adds the <see cref="SymbolString"/>'s visual information to the <see cref="Screen"/>.
		/// It does not draw the <see cref="SymbolString"/>.
		/// </summary>
		public void Show() {
			if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
				foreach (Char c in Text) {
					if (Pos.X + cursorPosition >= Min.X && Pos.X + cursorPosition < Max.X) {
						currentSymbol = Symbol.ASCII.Convert(c);

						Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).BGColor = BGColor;
						if (cursorPosition > AllowedLength) {
							Screen.SymbolAt(Pos.X + cursorPosition - 1, Pos.Y).Foreground = Symbol.ASCII.Underscore;
							break;
						} else Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).Foreground = currentSymbol;
					}
					cursorPosition++;

				}
				cursorPosition = 0;
			}
		}

	}

}


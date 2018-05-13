using Microsoft.Xna.Framework;
using System;

namespace Malomir.Display {

	/// <summary>
	/// Represents a string of <see cref="Symbol"/>'s.
	/// </summary>
	public class SymbolString {

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
		public Color BGColor { private get; set; }

		/// <summary>
		/// The foreground color of the <see cref="Symbol"/>.
		/// </summary>
		public Color FGColor { private get; set; }

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
		/// Draws this instance.
		/// </summary>
		public void Draw() {
			if (Pos.Y >= Min.Y && Pos.Y < Max.Y) {
				foreach (Char c in Text) {
					if (Pos.X + cursorPosition >= Min.X && Pos.X + cursorPosition < Max.X) {
						switch (c) {

							case ' ': currentSymbol = Symbol.ASCII.Space; break;
							case '.': currentSymbol = Symbol.ASCII.Period; break;
							case '_': currentSymbol = Symbol.ASCII.Underscore; break;
							case '!': currentSymbol = Symbol.ASCII.Exclamation; break;
							case '@': currentSymbol = Symbol.ASCII.AtSign; break;
							case '#': currentSymbol = Symbol.ASCII.Hash; break;
							case '$': currentSymbol = Symbol.ASCII.Dollar; break;
							case '%': currentSymbol = Symbol.ASCII.Percent; break;
							case '^': currentSymbol = Symbol.ASCII.Circumflex; break;
							case '&': currentSymbol = Symbol.ASCII.Ampersand; break;
							case '*': currentSymbol = Symbol.ASCII.Asterisk; break;
							case '(': currentSymbol = Symbol.ASCII.LeftParenthesis; break;
							case ')': currentSymbol = Symbol.ASCII.RightParenthesis; break;
							case '[': currentSymbol = Symbol.ASCII.LeftBracket; break;
							case ']': currentSymbol = Symbol.ASCII.RightBracket; break;
							case '{': currentSymbol = Symbol.ASCII.LeftBrace; break;
							case '}': currentSymbol = Symbol.ASCII.RightBrace; break;
							case '<': currentSymbol = Symbol.ASCII.LeftAngleBracket; break;
							case '>': currentSymbol = Symbol.ASCII.RightAngleBracket; break;

							#region Numbers
							case '0': currentSymbol = Symbol.ASCII.Zero; break;
							case '1': currentSymbol = Symbol.ASCII.One; break;
							case '2': currentSymbol = Symbol.ASCII.Two; break;
							case '3': currentSymbol = Symbol.ASCII.Three; break;
							case '4': currentSymbol = Symbol.ASCII.Four; break;
							case '5': currentSymbol = Symbol.ASCII.Five; break;
							case '6': currentSymbol = Symbol.ASCII.Six; break;
							case '7': currentSymbol = Symbol.ASCII.Seven; break;
							case '8': currentSymbol = Symbol.ASCII.Eight; break;
							case '9': currentSymbol = Symbol.ASCII.Nine; break;
							#endregion

							#region Uppercase
							case 'A': currentSymbol = Symbol.ASCII.UppercaseA; break;
							case 'B': currentSymbol = Symbol.ASCII.UppercaseB; break;
							case 'C': currentSymbol = Symbol.ASCII.UppercaseC; break;
							case 'D': currentSymbol = Symbol.ASCII.UppercaseD; break;
							case 'E': currentSymbol = Symbol.ASCII.UppercaseE; break;
							case 'F': currentSymbol = Symbol.ASCII.UppercaseF; break;
							case 'G': currentSymbol = Symbol.ASCII.UppercaseG; break;
							case 'H': currentSymbol = Symbol.ASCII.UppercaseH; break;
							case 'I': currentSymbol = Symbol.ASCII.UppercaseI; break;
							case 'J': currentSymbol = Symbol.ASCII.UppercaseJ; break;
							case 'K': currentSymbol = Symbol.ASCII.UppercaseK; break;
							case 'L': currentSymbol = Symbol.ASCII.UppercaseL; break;
							case 'M': currentSymbol = Symbol.ASCII.UppercaseM; break;
							case 'N': currentSymbol = Symbol.ASCII.UppercaseN; break;
							case 'O': currentSymbol = Symbol.ASCII.UppercaseO; break;
							case 'P': currentSymbol = Symbol.ASCII.UppercaseP; break;
							case 'Q': currentSymbol = Symbol.ASCII.UppercaseQ; break;
							case 'R': currentSymbol = Symbol.ASCII.UppercaseR; break;
							case 'S': currentSymbol = Symbol.ASCII.UppercaseS; break;
							case 'T': currentSymbol = Symbol.ASCII.UppercaseT; break;
							case 'U': currentSymbol = Symbol.ASCII.UppercaseU; break;
							case 'V': currentSymbol = Symbol.ASCII.UppercaseV; break;
							case 'W': currentSymbol = Symbol.ASCII.UppercaseW; break;
							case 'X': currentSymbol = Symbol.ASCII.UppercaseX; break;
							case 'Y': currentSymbol = Symbol.ASCII.UppercaseY; break;
							case 'Z': currentSymbol = Symbol.ASCII.UppercaseZ; break;
							#endregion

							#region Lowercase
							case 'a': currentSymbol = Symbol.ASCII.LowercaseA; break;
							case 'b': currentSymbol = Symbol.ASCII.LowercaseB; break;
							case 'c': currentSymbol = Symbol.ASCII.LowercaseC; break;
							case 'd': currentSymbol = Symbol.ASCII.LowercaseD; break;
							case 'e': currentSymbol = Symbol.ASCII.LowercaseE; break;
							case 'f': currentSymbol = Symbol.ASCII.LowercaseF; break;
							case 'g': currentSymbol = Symbol.ASCII.LowercaseG; break;
							case 'h': currentSymbol = Symbol.ASCII.LowercaseH; break;
							case 'i': currentSymbol = Symbol.ASCII.LowercaseI; break;
							case 'j': currentSymbol = Symbol.ASCII.LowercaseJ; break;
							case 'k': currentSymbol = Symbol.ASCII.LowercaseK; break;
							case 'l': currentSymbol = Symbol.ASCII.LowercaseL; break;
							case 'm': currentSymbol = Symbol.ASCII.LowercaseM; break;
							case 'n': currentSymbol = Symbol.ASCII.LowercaseN; break;
							case 'o': currentSymbol = Symbol.ASCII.LowercaseO; break;
							case 'p': currentSymbol = Symbol.ASCII.LowercaseP; break;
							case 'q': currentSymbol = Symbol.ASCII.LowercaseQ; break;
							case 'r': currentSymbol = Symbol.ASCII.LowercaseR; break;
							case 's': currentSymbol = Symbol.ASCII.LowercaseS; break;
							case 't': currentSymbol = Symbol.ASCII.LowercaseT; break;
							case 'u': currentSymbol = Symbol.ASCII.LowercaseU; break;
							case 'v': currentSymbol = Symbol.ASCII.LowercaseV; break;
							case 'w': currentSymbol = Symbol.ASCII.LowercaseW; break;
							case 'x': currentSymbol = Symbol.ASCII.LowercaseX; break;
							case 'y': currentSymbol = Symbol.ASCII.LowercaseY; break;
							case 'z': currentSymbol = Symbol.ASCII.LowercaseZ; break;
							#endregion

							default: currentSymbol = Symbol.ASCII.QuestionMark; break;
						}

						Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).FGColor = FGColor;
						Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).BGColor = BGColor;
						if (cursorPosition >= AllowedLength) {
							Screen.SymbolAt(Pos.X + cursorPosition, Pos.Y).Foreground = Symbol.ASCII.Underscore;
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


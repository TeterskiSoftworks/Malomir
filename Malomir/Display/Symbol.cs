using Microsoft.Xna.Framework;

namespace Malomir.Display {

	/// <summary>
	/// The smallest element that can be displayed on <see cref="Screen"/>.
	/// Think of it as a character on a terminal.
	/// </summary>
	public class Symbol {

		#region Declorations

		public static int width = 32, height = 32;

		/// <summary>
		/// The pixel size of each symbol of the tileset.
		/// </summary>
		public static int tilesetWidth = 16, tilesetHeight = 16;

		///<summary>
		///Determines the pixel position and pixel size of the symbol.
		///</summary>
		private Rectangle destination;

		/// <summary>
		/// Determines the background image to be displayed from the tileset.
		/// </summary>
		private Rectangle background;

		/// <summary>
		/// Determines the foreground image to be displayed from the tileset.
		/// </summary>
		private Rectangle foreground;

		/// <summary>
		/// The background color of the <see cref="Symbol"/>.
		/// </summary>
		public Color BGColor { private get; set; }

		/// <summary>
		/// The foreground color of the <see cref="Symbol"/>.
		/// </summary>
		public Color FGColor { private get; set; }

		#endregion

		/// <summary> Creates an instance of the Symbol class. </summary>
		/// <param name="x">The symbols X position in the <see cref="Screen"/>. </param>
		/// <param name="y">The symbols Y position in the <see cref="Screen"/>. </param>
		public Symbol(int x, int y) {

			BGColor = Color.Gray;
			FGColor = Color.White;

			destination = new Rectangle(x * Width, y * Height, Width, Height);
			foreground = new Rectangle(x * tilesetWidth, y * tilesetHeight, tilesetWidth, tilesetHeight);
			background = new Rectangle(11 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
		}


		/// <summary>
		/// Draws the symbol on the <see cref="Screen"/>.
		/// </summary>
		public void Draw() {
			Main.SpriteBatch.Draw(Screen.Tileset, destination, background, BGColor);
			Main.SpriteBatch.Draw(Screen.Tileset, destination, foreground, FGColor);
		}

		/// <summary>
		/// The pixel width of each symbol.
		/// </summary>
		public static int Width {
			get => width;
		}

		/// <summary>
		/// The pixel height of each symbol.
		/// </summary>
		public static int Height {
			get => height;
		}

		/// <summary>
		/// The X position of the symbol in the <see cref="Screen"/>.
		/// </summary>
		public int X {
			get => destination.X;
		}

		/// <summary>
		/// The Y position of the symbol in the <see cref="Screen"/>.
		/// </summary>
		public int Y {
			get => destination.Y;
		}

	}
}

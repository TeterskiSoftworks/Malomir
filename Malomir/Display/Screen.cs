using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Malomir.Display {

	/// <summary>
	/// A class that handles how information is displayed on the screen.
	/// It divides the screen into a 2D array of <seealso cref="Symbol"/>s. Think of it as a terminal.
	/// </summary>
	public static class Screen {

		#region Declorations

		/// <summary> Gets or sets the width in <seealso cref="Symbol"/>s. </summary> <value> The width. </value>
		private static int Width  { get; set; }
		/// <summary> Gets or sets the height in <seealso cref="Symbol"/>s. </summary> <value> The height. </value>
		private static int Height { get; set; }

		/// <summary> Gets the tileset used. </summary> <value> The tileset. </value>
		public static Texture2D Tileset { get; private set; }

		/// <summary>
		/// A 2D array of <seealso cref="Symbol"/>s used to represent a terminal like <seealso cref="Screen"/>.
		/// </summary>
		private static Symbol[,] symbols;
		#endregion

		/// <summary> Initializes the <see cref="Screen"/> to default settings. </summary>
		/// <param name="graphics"> The <see cref="GraphicsDeviceManager"/> used in <see cref="Main"/>. </param>
		/// <remarks> The default width and height are 16 <see cref="Symbol"/>s. </remarks>
		public static void Init(GraphicsDeviceManager graphics) {
			Init(16, 16, graphics);
		}

		/// <summary> Initializes the <seealso cref="Screen"/> with the specified settings. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="graphics"> The <see cref="GraphicsDeviceManager"/> used in <see cref="Main"/>. </param>
		public static void Init(int width, int height, GraphicsDeviceManager graphics) {
			Width = width;
			Height = height;
			
			symbols = new Symbol[Height, Width];

			graphics.PreferredBackBufferHeight = Height * Symbol.Height;
			graphics.PreferredBackBufferWidth = Width * Symbol.Width;
			graphics.ApplyChanges();

			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					symbols[y, x] = new Symbol(y, x);
				}
			}

		}

		/// <summary> Loads the tileset. </summary>
		/// <param name="tileset"> The tileset. </param>
		public static void LoadTileset(Texture2D tileset) {
			Tileset = tileset;
		}

		/// <summary>
		/// Draws all the <see cref="Symbol"/>s of the <see cref="Screen"/>.
		/// </summary>
		public static void Draw() {
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					symbols[y, x].Draw();
				}
			}
		}


		/// <summary> Gets the <see cref="Symbol"/> at the specified <see cref="Screen"/> position. </summary>
		/// <param name="x"> The x poisition of the <see cref="Symbol"/> on <see cref="Screen"/>. </param>
		/// <param name="y"> The y poisition of the <see cref="Symbol"/> on <see cref="Screen"/>. </param>
		/// <returns> The <see cref="Symbol"/> at thhe given <see cref="Screen"/> position. </returns>
		public static Symbol SymbolAt(int x, int y) {
			return symbols[y, x];
		}



	}
}

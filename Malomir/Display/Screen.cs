using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Malomir.Display {

	/// <summary>
	/// A class that handles how information is displayed on the screen.
	/// It divides the screen into a 2D array of <seealso cref="Symbol"/>s. Think of it as a terminal.
	/// </summary>
	public static class Screen {

		#region Declorations

		/// <summary>
		/// Gets or sets the size in <seealso cref="Symbol"/>s.
		/// </summary> <value> The height. </value>
		public static Point Size { get; private set; } = new Point{X = 50, Y = 50};

		/// <summary>
		/// A point that contains the minimum X and Y values that are visible.
		/// </summary>
		public static Point Min { get => Point.Zero; }

		/// <summary>
		/// A point that contains the maximum X and Y values that are visible.
		/// </summary>
		public static Point Max { get => Size; }

		/// <summary>
		/// Gets the tileset used.
		/// </summary>
		/// <value> The tileset. </value>
		public static Texture2D Tileset { get; private set; }

		/// <summary>
		/// A 2D array of <seealso cref="Symbol"/>s used to represent a terminal like <seealso cref="Screen"/>.
		/// </summary>
		private static Symbol[,] symbols;

		/// <summary>
		/// The main window of the screen. All other windows are contained within it.
		/// </summary>
		private static Window window;


		private static Window window2;

		#endregion
		

		/// <summary> Initializes the <see cref="Screen"/> to default settings. </summary>
		/// <param name="graphics"> The <see cref="GraphicsDeviceManager"/> used in <see cref="Main"/>. </param>
		/// <remarks> The default width and height are 16 <see cref="Symbol"/>s. </remarks>
		public static void Init(GraphicsDeviceManager graphics) {
			Init(Size, graphics);
		}

		/// <summary> Initializes the <seealso cref="Screen"/> with the specified settings. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="graphics"> The <see cref="GraphicsDeviceManager"/> used in <see cref="Main"/>. </param>
		public static void Init(Point size, GraphicsDeviceManager graphics) {
			Size = size;
			
			symbols = new Symbol[Size.Y, Size.X];
			
			graphics.PreferredBackBufferHeight = Size.Y * Symbol.Size.Y;
			graphics.PreferredBackBufferWidth = Size.X * Symbol.Size.X;
			graphics.ApplyChanges();

			for (int y = 0; y < Size.Y; y++) {
				for (int x = 0; x < Size.X; x++) {
					symbols[y, x] = new Symbol(x, y, Symbol.ASCII.Nul);
				}
			}

			window = new Window(Point.Zero, Size.Move(-1, -1), Min, Max, "Hello World!") {
				BGColor = Color.Red
			};

			window2 = new Window(Point.Zero.Move(4, 4), Size, window.Min, window.Max, "Test") {
				BGColor = Color.Green,
			};
			window2.SetBorder(Border.DefaultSubWindowBorder);

			window.AddWindow(window2);

			window.Show();
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

			for (int y = 0; y < Size.Y; y++) {
				for (int x = 0; x < Size.X; x++) {
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

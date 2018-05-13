using Microsoft.Xna.Framework;

namespace Malomir.Display {

	/// <summary>
	/// The smallest element that can be displayed on <see cref="Screen"/>.
	/// Think of it as a character on a terminal.
	/// </summary>
	public class Symbol{

		#region Declorations

		/// <summary>
		/// The pixel width of each symbol.
		/// </summary>
		public static int Width { get; private set; } = 16;

		/// <summary>
		/// The pixel height of each symbol.
		/// </summary>
		public static int Height { get; private set; } = 16;

		/// <summary>
		/// The X position of the symbol in the <see cref="Screen"/>.
		/// </summary>
		public int X { get => destination.X; }

		/// <summary>
		/// The Y position of the symbol in the <see cref="Screen"/>.
		/// </summary>
		public int Y { get => destination.Y; }
		
		/// <summary>
		/// The pixel size of each symbol of the tileset.
		/// </summary>
		public static int tilesetWidth = 16, tilesetHeight = 16;

		///<summary>
		///Determines the pixel position and pixel size of the symbol.
		///</summary>
		private Rectangle destination;

		/// <summary>
		/// Gets or sets the foreground image to be displayed from the tileset.
		/// </summary>
		public Rectangle Foreground { get; set; }

		/// <summary>
		/// Gets or sets the foreground image to be displayed from the tileset.
		/// </summary>
		public Rectangle Background { get; set; } = ASCII.FullBlock;

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
		/// <param name="x"> The symbol's X position in the <see cref="Screen"/>. </param>
		/// <param name="y"> The symbol's Y position in the <see cref="Screen"/>. </param>
		public Symbol(int x, int y) {

			BGColor = Color.Black;
			FGColor = Color.White;

			destination = new Rectangle(x * Width, y * Height, Width, Height);
			Foreground = ASCII.Nul;
			//foreground = new Rectangle(x * tilesetWidth, y * tilesetHeight, tilesetWidth, tilesetHeight);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Symbol"/> class.
		/// </summary>
		/// <param name="x"> The symbol's X position in the <see cref="Screen"/>.</param>
		/// <param name="y"> The symbol's Y position in the <see cref="Screen"/>.</param>
		/// <param name="foreground"> The foreground symbol to be displayd. </param>
		/// <seealso cref="ASCII"/>
		public Symbol(int x, int y, Rectangle foreground) {
			BGColor = Color.Black;
			FGColor = Color.White;

			destination = new Rectangle(x * Width, y * Height, Width, Height);
			Foreground = foreground;


		}

		/// <summary>
		/// Draws the symbol on the <see cref="Screen"/>.
		/// </summary>
		public void Draw() {
			Main.SpriteBatch.Draw(Screen.Tileset, destination, Background, BGColor);
			Main.SpriteBatch.Draw(Screen.Tileset, destination, Foreground, FGColor);
		}

		/// <summary>
		/// Contains the locations (as <see cref="Microsoft.Xna.Framework.Rectangle"/>s) of each tileset symbol.
		/// </summary>
		public struct ASCII {

			#region Row 0			
			/// <summary> Nul character.</summary>
			public static Rectangle Nul { get; } = new Rectangle(0 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			///<summary>☺</summary>
			public static Rectangle SmileBlank { get; } = new Rectangle(1 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			///<summary>☻</summary>
			public static Rectangle SmileFull { get; } = new Rectangle(2 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♥</summary>
			public static Rectangle Heart { get; } = new Rectangle(3 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♦</summary>
			public static Rectangle Diamond { get; } = new Rectangle(4 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♣</summary>
			public static Rectangle Club { get; } = new Rectangle(5 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♠</summary>
			public static Rectangle Spade { get; } = new Rectangle(6 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>•</summary>
			public static Rectangle Circle { get; } = new Rectangle(7 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>◘</summary>
			public static Rectangle Hole { get; } = new Rectangle(8 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>○</summary>
			public static Rectangle Ring { get; } = new Rectangle(9 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>◙</summary>
			public static Rectangle RingFull { get; } = new Rectangle(10 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♂</summary>
			public static Rectangle Male { get; } = new Rectangle(11 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♀</summary>
			public static Rectangle Female { get; } = new Rectangle(12 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♪</summary>
			public static Rectangle Note { get; } = new Rectangle(13 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>♫</summary>
			public static Rectangle Music { get; } = new Rectangle(14 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>☼</summary>
			public static Rectangle Sun { get; } = new Rectangle(15 * tilesetWidth, 0 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 1
			/// <summary>►</summary>
			public static Rectangle TriangleRight { get; } = new Rectangle(0 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);

			/// <summary>◄</summary>
			public static Rectangle TriangleLeft { get; } = new Rectangle(1 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>↕</summary>
			public static Rectangle ArrowUpDown { get; } = new Rectangle(2 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>‼</summary>
			public static Rectangle DoubleEx { get; } = new Rectangle(3 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¶</summary>
			public static Rectangle Pilcrow { get; } = new Rectangle(4 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>§</summary>
			public static Rectangle Section { get; } = new Rectangle(5 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▬</summary>
			public static Rectangle Rectangle { get; } = new Rectangle(6 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>↨</summary>
			public static Rectangle ArrowUpDownBase { get; } = new Rectangle(7 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>↑</summary>
			public static Rectangle ArrowUp { get; } = new Rectangle(8 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>↓</summary>
			public static Rectangle ArrowDown { get; } = new Rectangle(9 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>→</summary>
			public static Rectangle ArrowRight { get; } = new Rectangle(10 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>←</summary>
			public static Rectangle ArrowLeft { get; } = new Rectangle(11 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>∟</summary>
			public static Rectangle RightAngle { get; } = new Rectangle(12 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>↔</summary>
			public static Rectangle ArrowLeftRight { get; } = new Rectangle(13 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▲</summary>
			public static Rectangle TriangleUp { get; } = new Rectangle(14 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▼</summary>
			public static Rectangle TrianlgeDown { get; } = new Rectangle(15 * tilesetWidth, 1 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 2
			/// <summary>Space</summary>
			public static Rectangle Space { get; } = new Rectangle(0 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>!</summary>
			public static Rectangle Exclamation { get; } = new Rectangle(1 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>"</summary>
			public static Rectangle Quotation { get; } = new Rectangle(2 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>#</summary>
			public static Rectangle Hash { get; } = new Rectangle(3 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>$</summary>
			public static Rectangle Dollar { get; } = new Rectangle(4 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>%</summary>
			public static Rectangle Percent { get; } = new Rectangle(5 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>&</summary>
			public static Rectangle Ampersand { get; } = new Rectangle(6 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>'</summary>
			public static Rectangle Apostrophe { get; } = new Rectangle(7 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>(</summary>
			public static Rectangle LeftParenthesis { get; } = new Rectangle(8 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>)</summary>
			public static Rectangle RightParenthesis { get; } = new Rectangle(9 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>*</summary>
			public static Rectangle Asterisk { get; } = new Rectangle(10 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>+</summary>
			public static Rectangle Plus { get; } = new Rectangle(11 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>,</summary>
			public static Rectangle Comma { get; } = new Rectangle(12 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>-</summary>
			public static Rectangle Minus { get; } = new Rectangle(13 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>.</summary>
			public static Rectangle Period { get; } = new Rectangle(14 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>/</summary>
			public static Rectangle Slash { get; } = new Rectangle(15 * tilesetWidth, 2 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 3
			/// <summary>0</summary>
			public static Rectangle Zero { get; } = new Rectangle(0 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>1</summary>
			public static Rectangle One { get; } = new Rectangle(1 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>2</summary>
			public static Rectangle Two { get; } = new Rectangle(2 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>3</summary>
			public static Rectangle Three { get; } = new Rectangle(3 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>4</summary>
			public static Rectangle Four { get; } = new Rectangle(4 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>5</summary>
			public static Rectangle Five { get; } = new Rectangle(5 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>6</summary>
			public static Rectangle Six { get; } = new Rectangle(6 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>7</summary>
			public static Rectangle Seven { get; } = new Rectangle(7 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>8</summary>
			public static Rectangle Eight { get; } = new Rectangle(8 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>9</summary>
			public static Rectangle Nine { get; } = new Rectangle(9 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>:</summary>
			public static Rectangle Colon { get; } = new Rectangle(10 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>;</summary>
			public static Rectangle Semicolon { get; } = new Rectangle(11 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary><</summary>
			public static Rectangle LeftAngleBracket { get; } = new Rectangle(12 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>=</summary>
			public static Rectangle EqualsSign { get; } = new Rectangle(13 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>></summary>
			public static Rectangle RightAngleBracket { get; } = new Rectangle(14 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>?</summary>
			public static Rectangle QuestionMark { get; } = new Rectangle(15 * tilesetWidth, 3 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 4
			/// <summary>@</summary>
			public static Rectangle AtSign { get; } = new Rectangle(0 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>A</summary>
			public static Rectangle UppercaseA { get; } = new Rectangle(1 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>B</summary>
			public static Rectangle UppercaseB { get; } = new Rectangle(2 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>C</summary>
			public static Rectangle UppercaseC { get; } = new Rectangle(3 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>D</summary>
			public static Rectangle UppercaseD { get; } = new Rectangle(4 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>E</summary>
			public static Rectangle UppercaseE { get; } = new Rectangle(5 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>F</summary>
			public static Rectangle UppercaseF { get; } = new Rectangle(6 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>G</summary>
			public static Rectangle UppercaseG { get; } = new Rectangle(7 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>H</summary>
			public static Rectangle UppercaseH { get; } = new Rectangle(8 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>I</summary>
			public static Rectangle UppercaseI { get; } = new Rectangle(9 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>J</summary>
			public static Rectangle UppercaseJ { get; } = new Rectangle(10 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>K</summary>
			public static Rectangle UppercaseK { get; } = new Rectangle(11 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>L</summary>
			public static Rectangle UppercaseL { get; } = new Rectangle(12 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>M</summary>
			public static Rectangle UppercaseM { get; } = new Rectangle(13 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>N</summary>
			public static Rectangle UppercaseN { get; } = new Rectangle(14 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>O</summary>
			public static Rectangle UppercaseO { get; } = new Rectangle(15 * tilesetWidth, 4 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 5
			/// <summary>P</summary>
			public static Rectangle UppercaseP { get; } = new Rectangle(0 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Q</summary>
			public static Rectangle UppercaseQ { get; } = new Rectangle(1 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>R</summary>
			public static Rectangle UppercaseR { get; } = new Rectangle(2 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>S</summary>
			public static Rectangle UppercaseS { get; } = new Rectangle(3 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>T</summary>
			public static Rectangle UppercaseT { get; } = new Rectangle(4 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>U</summary>
			public static Rectangle UppercaseU { get; } = new Rectangle(5 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>V</summary>
			public static Rectangle UppercaseV { get; } = new Rectangle(6 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>W</summary>
			public static Rectangle UppercaseW { get; } = new Rectangle(7 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>X</summary>
			public static Rectangle UppercaseX { get; } = new Rectangle(8 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Y</summary>
			public static Rectangle UppercaseY { get; } = new Rectangle(9 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Z</summary>
			public static Rectangle UppercaseZ { get; } = new Rectangle(10 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>[</summary>
			public static Rectangle LeftBracket { get; } = new Rectangle(11 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>\</summary>
			public static Rectangle Backslash { get; } = new Rectangle(12 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>]</summary>
			public static Rectangle RightBracket { get; } = new Rectangle(13 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>^</summary>
			public static Rectangle Circumflex { get; } = new Rectangle(14 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>_</summary>
			public static Rectangle Underscore { get; } = new Rectangle(15 * tilesetWidth, 5 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 6
			/// <summary>`</summary>
			public static Rectangle GraveAccent { get; } = new Rectangle(0 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>a</summary>
			public static Rectangle LowercaseA { get; } = new Rectangle(1 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>b</summary>
			public static Rectangle LowercaseB { get; } = new Rectangle(2 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>c</summary>
			public static Rectangle LowercaseC { get; } = new Rectangle(3 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>d</summary>
			public static Rectangle LowercaseD { get; } = new Rectangle(4 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>e</summary>
			public static Rectangle LowercaseE { get; } = new Rectangle(5 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>f</summary>
			public static Rectangle LowercaseF { get; } = new Rectangle(6 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>g</summary>
			public static Rectangle LowercaseG { get; } = new Rectangle(7 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>h</summary>
			public static Rectangle LowercaseH { get; } = new Rectangle(8 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>i</summary>
			public static Rectangle LowercaseI { get; } = new Rectangle(9 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>j</summary>
			public static Rectangle LowercaseJ { get; } = new Rectangle(10 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>k</summary>
			public static Rectangle LowercaseK { get; } = new Rectangle(11 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>l</summary>
			public static Rectangle LowercaseL { get; } = new Rectangle(12 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>m</summary>
			public static Rectangle LowercaseM { get; } = new Rectangle(13 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>n</summary>
			public static Rectangle LowercaseN { get; } = new Rectangle(14 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>o</summary>
			public static Rectangle LowercaseO { get; } = new Rectangle(15 * tilesetWidth, 6 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 7
			/// <summary>p</summary>
			public static Rectangle LowercaseP { get; } = new Rectangle(0 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>q</summary>
			public static Rectangle LowercaseQ { get; } = new Rectangle(1 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>r</summary>
			public static Rectangle LowercaseR { get; } = new Rectangle(2 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>s</summary>
			public static Rectangle LowercaseS { get; } = new Rectangle(3 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>t</summary>
			public static Rectangle LowercaseT { get; } = new Rectangle(4 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>u</summary>
			public static Rectangle LowercaseU { get; } = new Rectangle(5 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>v</summary>
			public static Rectangle LowercaseV { get; } = new Rectangle(6 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>w</summary>
			public static Rectangle LowercaseW { get; } = new Rectangle(7 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>x</summary>
			public static Rectangle LowercaseX { get; } = new Rectangle(8 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>y</summary>
			public static Rectangle LowercaseY { get; } = new Rectangle(9 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>z</summary>
			public static Rectangle LowercaseZ { get; } = new Rectangle(10 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>{</summary>
			public static Rectangle LeftBrace { get; } = new Rectangle(11 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>|</summary>
			public static Rectangle VerticalBar { get; } = new Rectangle(12 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>}</summary>
			public static Rectangle RightBrace { get; } = new Rectangle(13 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>~</summary>
			public static Rectangle Tilde { get; } = new Rectangle(14 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>⌂</summary>
			public static Rectangle House { get; } = new Rectangle(15 * tilesetWidth, 7 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 8
			/// <summary>Ç</summary>
			public static Rectangle UppercaseCCedilla { get; } = new Rectangle(0 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ü</summary>
			public static Rectangle LowercaseUUmlaut { get; } = new Rectangle(1 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>é</summary>
			public static Rectangle LowercaseEAcute { get; } = new Rectangle(2 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>â</summary>
			public static Rectangle LowercaseACircumflex { get; } = new Rectangle(3 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ä</summary>
			public static Rectangle LowercaseAUmlaut { get; } = new Rectangle(4 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>à</summary>
			public static Rectangle LowercaseAGrave { get; } = new Rectangle(5 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>å</summary>
			public static Rectangle LowercaseAngstrom { get; } = new Rectangle(6 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ç</summary>
			public static Rectangle LowercaseCCedilla { get; } = new Rectangle(7 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ê</summary>
			public static Rectangle LowercaseECircumflex { get; } = new Rectangle(8 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ë</summary>
			public static Rectangle LowercaseEUmlaut { get; } = new Rectangle(9 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>è</summary>
			public static Rectangle LowercaseEGrave { get; } = new Rectangle(10 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ï</summary>
			public static Rectangle LowercaseIUmlaut { get; } = new Rectangle(11 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>î</summary>
			public static Rectangle LowercaseICircumflex { get; } = new Rectangle(12 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ì</summary>
			public static Rectangle LowercaseIGrave { get; } = new Rectangle(13 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Ä</summary>
			public static Rectangle UppercaseAUmlaut { get; } = new Rectangle(14 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Å</summary>
			public static Rectangle UppercaseAngstrom { get; } = new Rectangle(15 * tilesetWidth, 8 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 9
			/// <summary>É</summary>
			public static Rectangle UppercaseEAcute { get; } = new Rectangle(0 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>æ</summary>
			public static Rectangle LowercaseAE { get; } = new Rectangle(1 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Æ</summary>
			public static Rectangle UppercaseAE { get; } = new Rectangle(2 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ô</summary>
			public static Rectangle LowercaseOCircumflex { get; } = new Rectangle(3 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ö</summary>
			public static Rectangle LowercaseOUmlaut { get; } = new Rectangle(4 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ò</summary>
			public static Rectangle LowercaseOGrave { get; } = new Rectangle(5 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>û</summary>
			public static Rectangle LowercaseUCircumflex { get; } = new Rectangle(6 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ù</summary>
			public static Rectangle LowercaseUGrave { get; } = new Rectangle(7 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ÿ</summary>
			public static Rectangle LowercaseYUmlaut { get; } = new Rectangle(8 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Ö</summary>
			public static Rectangle UppercaseOUmlaut { get; } = new Rectangle(9 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Ü</summary>
			public static Rectangle UppercaseUUmlaut { get; } = new Rectangle(10 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¢</summary>
			public static Rectangle Cent { get; } = new Rectangle(11 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>£</summary>
			public static Rectangle Pound { get; } = new Rectangle(12 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¥</summary>
			public static Rectangle Yen { get; } = new Rectangle(13 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>₧</summary>
			public static Rectangle Peseta { get; } = new Rectangle(14 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ƒ</summary>
			public static Rectangle Florin { get; } = new Rectangle(15 * tilesetWidth, 9 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 10
			/// <summary>á</summary>
			public static Rectangle LowercaseAAcute { get; } = new Rectangle(0 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>í</summary>
			public static Rectangle LowercaseIAcute { get; } = new Rectangle(1 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ó</summary>
			public static Rectangle LowercaseOAcute { get; } = new Rectangle(2 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ú</summary>
			public static Rectangle LowercaseUAcute { get; } = new Rectangle(3 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ñ</summary>
			public static Rectangle LowercaseEne { get; } = new Rectangle(4 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Ñ</summary>
			public static Rectangle UppercaseEne { get; } = new Rectangle(5 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ª</summary>
			public static Rectangle OrdinalA { get; } = new Rectangle(6 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>º</summary>
			public static Rectangle OrdinalO { get; } = new Rectangle(7 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¿</summary>
			public static Rectangle QuestionMarkInverted { get; } = new Rectangle(8 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>⌐</summary>
			public static Rectangle NotSignReversed { get; } = new Rectangle(9 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¬</summary>
			public static Rectangle NotSign { get; } = new Rectangle(10 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>½</summary>
			public static Rectangle Half { get; } = new Rectangle(11 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¼</summary>
			public static Rectangle Quarter { get; } = new Rectangle(12 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>¡</summary>
			public static Rectangle ExclamationInverted { get; } = new Rectangle(13 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>«</summary>
			public static Rectangle LeftGuillemet { get; } = new Rectangle(14 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>»</summary>
			public static Rectangle RightGuillemet { get; } = new Rectangle(15 * tilesetWidth, 10 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 11
			/// <summary>░</summary>
			public static Rectangle LightShade { get; } = new Rectangle(0 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▒</summary>
			public static Rectangle MediumShade { get; } = new Rectangle(1 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▓</summary>
			public static Rectangle DarkShade { get; } = new Rectangle(2 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>│</summary>
			public static Rectangle VerticalSingle { get; } = new Rectangle(3 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┤</summary>
			public static Rectangle VerticalSingleLeftSingle { get; } = new Rectangle(4 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╡</summary>
			public static Rectangle VerticalSingleLeftDouble { get; } = new Rectangle(5 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╢</summary>
			public static Rectangle VerticalDoubleLeftSingle { get; } = new Rectangle(6 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╖</summary>
			public static Rectangle DownDoubleLeftSingle { get; } = new Rectangle(7 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╕</summary>
			public static Rectangle DownSingleLeftDouble { get; } = new Rectangle(8 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╣</summary>
			public static Rectangle VerticalDoubleLeftDouble { get; } = new Rectangle(9 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>║</summary>
			public static Rectangle VerticalDouble { get; } = new Rectangle(10 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╗</summary>
			public static Rectangle DownDoubleLeftDouble { get; } = new Rectangle(11 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╝</summary>
			public static Rectangle UpDoubleLeftDouble { get; } = new Rectangle(12 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╜</summary>
			public static Rectangle UpDoubleLeftSingle { get; } = new Rectangle(13 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╛</summary>
			public static Rectangle UpSingleLeftSouble { get; } = new Rectangle(14 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┐</summary>
			public static Rectangle DownSingleLeftSingle { get; } = new Rectangle(15 * tilesetWidth, 11 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 12
			/// <summary>└</summary>
			public static Rectangle UpSingleRightSingle { get; } = new Rectangle(0 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┴</summary>
			public static Rectangle UpSingleHorizontalSingle { get; } = new Rectangle(1 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┬</summary>
			public static Rectangle DownSingleHorizontalSingle { get; } = new Rectangle(2 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>├</summary>
			public static Rectangle VerticalSingleRightSingle { get; } = new Rectangle(3 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>─</summary>
			public static Rectangle HorizontalSingle { get; } = new Rectangle(4 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┼</summary>
			public static Rectangle HorizontalSingleVerticalSingle { get; } = new Rectangle(5 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╞</summary>
			public static Rectangle HorizontalSingleRightDouble { get; } = new Rectangle(6 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╟</summary>
			public static Rectangle HorizontalDoubleRightSingle { get; } = new Rectangle(7 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╚</summary>
			public static Rectangle UpDoubleRightDouble { get; } = new Rectangle(8 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╔</summary>
			public static Rectangle DownDoubleRightDouble { get; } = new Rectangle(9 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╩</summary>
			public static Rectangle UpDoubleHorizontalDouble { get; } = new Rectangle(10 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╦</summary>
			public static Rectangle DownDoubleHorizontalDouble { get; } = new Rectangle(11 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╠</summary>
			public static Rectangle HorizontalDoubleRightDouble { get; } = new Rectangle(12 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>═</summary>
			public static Rectangle HorizontalDouble { get; } = new Rectangle(13 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╬</summary>
			public static Rectangle HorizontalDoubleVerticalDouble { get; } = new Rectangle(14 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╧</summary>
			public static Rectangle UpSingleHorizontalDouble { get; } = new Rectangle(15 * tilesetWidth, 12 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 13
			/// <summary>╨</summary>
			public static Rectangle UpDoubleHorizontalSingle { get; } = new Rectangle(0 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╤</summary>
			public static Rectangle DownSingleHorizontalDouble { get; } = new Rectangle(1 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╥</summary>
			public static Rectangle DownDoubleHorizontalSingle { get; } = new Rectangle(2 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╙</summary>
			public static Rectangle UpDoubleRightSingle { get; } = new Rectangle(3 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╘</summary>
			public static Rectangle UpSingleRightDouble { get; } = new Rectangle(4 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╒</summary>
			public static Rectangle DownSingleRightDouble { get; } = new Rectangle(5 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╓</summary>
			public static Rectangle DownDoubleRightSingle { get; } = new Rectangle(6 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╫</summary>
			public static Rectangle HorizontalDoubleVerticalSingle { get; } = new Rectangle(7 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>╪</summary>
			public static Rectangle HorizontalSingleVerticalDouble { get; } = new Rectangle(8 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┘</summary>
			public static Rectangle UpSingleLeftSingle { get; } = new Rectangle(9 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>┌</summary>
			public static Rectangle DownSingleRightSingle { get; } = new Rectangle(10 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>█</summary>
			public static Rectangle FullBlock { get; } = new Rectangle(11 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▄</summary>
			public static Rectangle LowerHalfBlock { get; } = new Rectangle(12 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>"▌ "</summary>
			public static Rectangle LeftHalfBlock { get; } = new Rectangle(13 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>"▐"</summary>
			public static Rectangle RightHalfBlock { get; } = new Rectangle(14 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>▀</summary>
			public static Rectangle UpperHalfBlock { get; } = new Rectangle(15 * tilesetWidth, 13 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 14
			/// <summary>α</summary>
			public static Rectangle Alpha { get; } = new Rectangle(0 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ß</summary>
			public static Rectangle Beta { get; } = new Rectangle(1 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Γ</summary>
			public static Rectangle Gamma { get; } = new Rectangle(2 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>π</summary>
			public static Rectangle Pi { get; } = new Rectangle(3 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Σ</summary>
			public static Rectangle UppercaseSigma { get; } = new Rectangle(4 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>σ</summary>
			public static Rectangle LowercaseSigma { get; } = new Rectangle(5 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>µ</summary>
			public static Rectangle Mu { get; } = new Rectangle(6 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>τ</summary>
			public static Rectangle Tau { get; } = new Rectangle(7 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Φ</summary>
			public static Rectangle UppercasePhi { get; } = new Rectangle(8 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Θ</summary>
			public static Rectangle Theta { get; } = new Rectangle(9 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>Ω</summary>
			public static Rectangle Omega { get; } = new Rectangle(10 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>δ</summary>
			public static Rectangle Delta { get; } = new Rectangle(11 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>∞</summary>
			public static Rectangle Infinity { get; } = new Rectangle(12 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>φ</summary>
			public static Rectangle LowercasePhi { get; } = new Rectangle(13 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ε</summary>
			public static Rectangle Epsilon { get; } = new Rectangle(14 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>∩</summary>
			public static Rectangle Intersection { get; } = new Rectangle(15 * tilesetWidth, 14 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion

			#region Row 15
			/// <summary>≡</summary>
			public static Rectangle EquivalenceSign { get; } = new Rectangle(0 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>±</summary>
			public static Rectangle PlusMinus { get; } = new Rectangle(1 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>≥</summary>
			public static Rectangle GreaterThanEqual { get; } = new Rectangle(2 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>≤</summary>
			public static Rectangle LessThanEqual { get; } = new Rectangle(3 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>⌠</summary>
			public static Rectangle UpperIntegral { get; } = new Rectangle(4 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>⌡</summary>
			public static Rectangle LowerIntegral { get; } = new Rectangle(5 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>÷</summary>
			public static Rectangle Division { get; } = new Rectangle(6 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>≈</summary>
			public static Rectangle Approximation { get; } = new Rectangle(7 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>°</summary>
			public static Rectangle Degree { get; } = new Rectangle(8 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>∙</summary>
			public static Rectangle Bullet { get; } = new Rectangle(9 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>·</summary>
			public static Rectangle MiddleDot { get; } = new Rectangle(10 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>√</summary>
			public static Rectangle SquareRoot { get; } = new Rectangle(11 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>ⁿ</summary>
			public static Rectangle SuperscriptN { get; } = new Rectangle(12 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>²</summary>
			public static Rectangle Superscript2 { get; } = new Rectangle(13 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>■</summary>
			public static Rectangle Square { get; } = new Rectangle(14 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			/// <summary>No-break sapce</summary>
			public static Rectangle NoBreakSpace { get; } = new Rectangle(15 * tilesetWidth, 15 * tilesetHeight, tilesetWidth, tilesetHeight);
			#endregion
		}
	}
}


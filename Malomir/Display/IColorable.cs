using Microsoft.Xna.Framework;

namespace Malomir.Display {
	public interface IColorable {

		/// <summary>
		/// The foreground color of the <see cref="Window"/>.
		/// </summary>
		Color FGColor { get; set; }
		/// <summary>
		/// The background color of the <see cref="Window"/>.
		/// </summary>
		Color BGColor { get; set; }

	}
}

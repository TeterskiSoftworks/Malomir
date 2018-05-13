namespace Malomir.Display {

	public interface IShowable : IColorable {

		/// <summary>
		/// Adds visual information to the <see cref="Screen"/>.
		/// It does not draw.
		/// </summary>
		void Show();

	}
}

using System.Drawing;

namespace devDept.Eyeshot.Control;

public interface IUserInterfaceElement : IUserInterfaceElementBase
{
	bool Disposed { get; }

	Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor);

	Rectangle GetBounds(Viewport viewport);

	void Update(IUserInterfaceElement another);
}

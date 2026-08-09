using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IMouseController
{
	bool IgnoreVisualFormLeftButtonDown { get; }

	void MouseEnter(Control c);

	void MouseMove(Control c, Point pt);

	bool MouseDown(Control c, Point pt, MouseButtons button);

	void MouseUp(Control c, Point pt, MouseButtons button);

	void MouseLeave(Control c, ViewBase next);

	void DoubleClick(Point pt);
}

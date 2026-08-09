using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IKeyController
{
	void KeyDown(Control c, KeyEventArgs e);

	void KeyPress(Control c, KeyPressEventArgs e);

	bool KeyUp(Control c, KeyEventArgs e);
}

using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface ISourceController
{
	void GotFocus(Control c);

	void LostFocus(Control c);
}

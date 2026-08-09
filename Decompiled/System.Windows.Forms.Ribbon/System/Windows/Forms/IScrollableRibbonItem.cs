using System.Drawing;

namespace System.Windows.Forms;

public interface IScrollableRibbonItem
{
	Rectangle ContentBounds { get; }

	void ScrollUp();

	void ScrollDown();
}

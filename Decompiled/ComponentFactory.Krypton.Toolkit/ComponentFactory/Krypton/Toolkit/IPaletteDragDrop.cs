using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteDragDrop
{
	Color GetDragDropSolidBack();

	Color GetDragDropSolidBorder();

	float GetDragDropSolidOpacity();

	Color GetDragDropDockBack();

	Color GetDragDropDockBorder();

	Color GetDragDropDockActive();

	Color GetDragDropDockInactive();
}

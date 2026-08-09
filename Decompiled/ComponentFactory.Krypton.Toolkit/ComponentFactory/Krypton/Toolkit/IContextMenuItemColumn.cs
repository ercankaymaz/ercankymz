using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IContextMenuItemColumn
{
	int ColumnIndex { get; }

	Size LastPreferredSize { get; }

	int OverridePreferredWidth { set; }
}

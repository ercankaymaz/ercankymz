using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms;

public interface IContainsSelectableRibbonItems
{
	IEnumerable<RibbonItem> GetItems();

	Rectangle GetContentBounds();
}

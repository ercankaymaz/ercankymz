using System.Collections;
using DevAge.Drawing;

namespace SourceGrid.Cells.Models;

public struct SortStatus(HeaderSortStyle p_Style)
{
	public HeaderSortStyle Style = p_Style;

	public IComparer Comparer = null;

	public SortStatus(HeaderSortStyle p_Style, IComparer p_Comparer)
		: this(p_Style)
	{
		Comparer = p_Comparer;
	}
}

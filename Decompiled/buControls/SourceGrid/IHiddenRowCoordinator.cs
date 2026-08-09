using System.Collections.Generic;

namespace SourceGrid;

public interface IHiddenRowCoordinator
{
	IEnumerable<int> LoopVisibleRows(int rowIndex, int numberOfRowsToProduce);

	int ConvertScrollbarValueToRowIndex(int scrollBarValue);

	int GetTotalHiddenRows();
}

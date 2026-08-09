using System.Runtime.CompilerServices;

namespace SourceGrid;

public class RowInfoCollectoinHiddenRowCoordinator : StandardHiddenRowCoordinator
{
	[CompilerGenerated]
	private sealed class Class66
	{
		public RowInfoCollection rowInfoCollection_0;

		public RowInfoCollectoinHiddenRowCoordinator rowInfoCollectoinHiddenRowCoordinator_0;

		internal void method_0(object sender, IndexRangeEventArgs e)
		{
			for (int i = 0; i < e.Count; i++)
			{
				int row = i + e.StartIndex;
				if (!rowInfoCollection_0.IsRowVisible(row))
				{
					rowInfoCollectoinHiddenRowCoordinator_0.m_totalHiddenRows--;
				}
			}
			Range rangeToRemove = new Range(e.StartIndex, 0, e.StartIndex + e.Count, 1);
			rowInfoCollectoinHiddenRowCoordinator_0.m_rowMerger.RemoveRange(rangeToRemove);
		}
	}

	public RowInfoCollectoinHiddenRowCoordinator(RowInfoCollection rows)
		: base(rows)
	{
		RowInfoCollectoinHiddenRowCoordinator rowInfoCollectoinHiddenRowCoordinator_0 = this;
		rows.RowsRemoving += delegate(object sender, IndexRangeEventArgs e)
		{
			for (int i = 0; i < e.Count; i++)
			{
				int row = i + e.StartIndex;
				if (!rows.IsRowVisible(row))
				{
					rowInfoCollectoinHiddenRowCoordinator_0.m_totalHiddenRows--;
				}
			}
			Range rangeToRemove = new Range(e.StartIndex, 0, e.StartIndex + e.Count, 1);
			rowInfoCollectoinHiddenRowCoordinator_0.m_rowMerger.RemoveRange(rangeToRemove);
		};
	}
}

using System.Collections;
using SourceGrid.Cells;

namespace SourceGrid;

public class MultiColumnsComparer : IComparer
{
	private IComparer icomparer_0 = new ValueCellComparer();

	private int[] secondarySortColumns;

	public MultiColumnsComparer(params int[] secondarySortColumns)
	{
		this.secondarySortColumns = secondarySortColumns;
	}

	public virtual int Compare(object x, object y)
	{
		int num = icomparer_0.Compare(x, y);
		if (num != 0)
		{
			return num;
		}
		Grid grid = ((ICell)x).Grid;
		int row = ((ICell)x).Range.Start.Row;
		int row2 = ((ICell)y).Range.Start.Row;
		for (int i = 0; i < secondarySortColumns.Length; i++)
		{
			ICellVirtual cell = grid.GetCell(row, secondarySortColumns[i]);
			ICellVirtual cell2 = grid.GetCell(row2, secondarySortColumns[i]);
			int num2 = icomparer_0.Compare(cell, cell2);
			if (num2 != 0)
			{
				return num2;
			}
		}
		return 0;
	}
}

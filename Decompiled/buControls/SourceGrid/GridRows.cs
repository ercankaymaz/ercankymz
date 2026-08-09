using ns27;

namespace SourceGrid;

public class GridRows : RowInfoCollection
{
	public new Grid Grid => base.Grid as Grid;

	public new GridRow this[int index] => (GridRow)base[index];

	public GridRows(Grid grid)
		: base(grid)
	{
	}

	public override void Swap(int p_RowIndex1, int p_RowIndex2)
	{
		base.Swap(p_RowIndex1, p_RowIndex2);
		Grid.SpannedCellReferences.Swap(p_RowIndex1, p_RowIndex2);
	}

	public void Insert(int p_Index)
	{
		InsertRange(p_Index, 1);
	}

	public void InsertRange(int startIndex, int count)
	{
		RowInfo[] array = new RowInfo[count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = CreateRow();
		}
		InsertRange(startIndex, array);
		Class76.smethod_359(Grid);
		Grid.SpannedCellReferences.MoveDownSpannedRanges(startIndex, count);
		Grid.SpannedCellReferences.ExpandSpannedRows(startIndex, count);
	}

	public override void RemoveRange(int startIndex, int count)
	{
		Grid.SpannedCellReferences.RemoveSpannedCellReferencesInRows(startIndex, count);
		base.RemoveRange(startIndex, count);
		Grid.SpannedCellReferences.ShrinkOrRemoveSpannedRows(startIndex, count);
		Grid.SpannedCellReferences.MoveUpSpannedRanges(startIndex, count);
	}

	protected GridRow CreateRow()
	{
		return new GridRow(Grid);
	}

	public void SetCount(int value)
	{
		Class76.smethod_359(Grid);
		if (Count >= value)
		{
			if (Count > value)
			{
				RemoveRange(value, Count - value);
			}
		}
		else
		{
			InsertRange(Count, value - Count);
		}
	}
}

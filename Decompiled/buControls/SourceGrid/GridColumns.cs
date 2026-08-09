using ns27;

namespace SourceGrid;

public class GridColumns : ColumnInfoCollection
{
	public new Grid Grid => base.Grid as Grid;

	public GridColumns(Grid grid)
		: base(grid)
	{
	}

	public void Insert(int p_Index)
	{
		InsertRange(p_Index, 1);
	}

	public void InsertRange(int startIndex, int count)
	{
		GridColumn[] array = new GridColumn[count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = CreateColumn();
		}
		ColumnInfo[] columns = array;
		InsertRange(startIndex, columns);
		Grid.SpannedCellReferences.MoveRightSpannedRanges(startIndex, count);
		Grid.SpannedCellReferences.ExpandSpannedColumns(startIndex, count);
	}

	public override void RemoveRange(int startIndex, int count)
	{
		Grid.SpannedCellReferences.RemoveSpannedCellReferencesInColumns(startIndex, count);
		base.RemoveRange(startIndex, count);
		Grid.SpannedCellReferences.ShrinkOrRemoveSpannedColumns(startIndex, count);
		Grid.SpannedCellReferences.MoveLeftSpannedRanges(startIndex, count);
	}

	protected GridColumn CreateColumn()
	{
		return new GridColumn(Grid);
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

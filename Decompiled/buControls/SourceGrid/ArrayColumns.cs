namespace SourceGrid;

public class ArrayColumns : ColumnInfoCollection
{
	public new ArrayGrid Grid => (ArrayGrid)base.Grid;

	public ArrayColumns(ArrayGrid grid)
		: base(grid)
	{
	}
}

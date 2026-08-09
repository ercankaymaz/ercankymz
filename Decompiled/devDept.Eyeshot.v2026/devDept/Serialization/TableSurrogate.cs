using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class TableSurrogate : PlanarEntitySurrogate
{
	internal class CellRangeSurrogate : Surrogate<Table.CellRange>
	{
		public int MinRow;

		public int MaxRow;

		public int MinColumn;

		public int MaxColumn;

		public CellRangeSurrogate(Table.CellRange cell)
			: base(cell)
		{
		}

		protected override Table.CellRange ConvertToObject()
		{
			return new Table.CellRange(MinRow, MinColumn, MaxRow, MaxColumn);
		}

		protected override void CopyDataToObject(Table.CellRange entity)
		{
		}

		protected override void CopyDataFromObject(Table.CellRange cellRange)
		{
			MinRow = cellRange._0023_003DzOhnJ5sVkuMJp();
			MaxRow = cellRange._0023_003DzdIEC8nhYbOLX();
			MinColumn = cellRange._0023_003Dzuoqcx_Pl_iTG();
			MaxColumn = cellRange._0023_003DzIQKzEF3iEvEG();
		}

		public static implicit operator Table.CellRange(CellRangeSurrogate surrogate)
		{
			return surrogate?.ConvertToObject();
		}

		public static implicit operator CellRangeSurrogate(Table.CellRange source)
		{
			return source?._0023_003Dz_0024xHo97pGU7zE();
		}
	}

	internal class CellSurrogate : MultilineTextSurrogate
	{
		public Point3D[] Corners;

		public bool IsFirst;

		public bool IsMerged;

		public Table.CellRange MergeRange;

		public CellSurrogate(Table.Cell cell)
			: base(cell)
		{
		}

		protected override Entity ConvertToObject()
		{
			Table.Cell cell = new Table.Cell(this);
			CopyDataToObject(cell);
			return cell;
		}

		protected override void CopyDataToObject(Entity entity)
		{
			Table.Cell obj = entity as Table.Cell;
			obj._0023_003DzH5ErvWC1OAsG(IsFirst);
			obj._0023_003Dz0_00243eMyFvKd4i(IsMerged);
			obj._0023_003DzL6_00248z_0024m2KgCWo_0024VSbg_003D_003D(Corners);
			obj._0023_003DzkkRJVPID18Hg(MergeRange);
			base.CopyDataToObject(entity);
		}

		protected override void CopyDataFromObject(Entity entity)
		{
			Table.Cell cell = entity as Table.Cell;
			IsFirst = cell._0023_003DznlWCcYBgPxFJ();
			IsMerged = cell._0023_003DzC8Y1qQ5FpzJd();
			Corners = cell._0023_003DzX28tBzOYu835xbgMXQ_003D_003D();
			MergeRange = cell._0023_003DzbXJI0GPjxGEH();
			base.CopyDataFromObject(entity);
		}
	}

	public int RowsNum;

	public int ColumnsNum;

	public double[] RowsHeights;

	public double[] ColumnsWidths;

	public Table.flowDirection Direction;

	public double HorzCellMargin;

	public double VertCellMargin;

	internal ProtoArray<Table.Cell> Cells;

	public TableSurrogate(Table table)
		: base(table)
	{
	}

	protected override Entity ConvertToObject()
	{
		Table table = new Table(this);
		CopyDataToObject(table);
		return table;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Table table = (Table)entity;
		table.HorCellMargin = HorzCellMargin;
		table.VerCellMargin = VertCellMargin;
		table.cells = Cells.ToArray() as Table.Cell[,];
		if (base.Version <= 8)
		{
			for (int i = 0; i < RowsNum; i++)
			{
				for (int j = 0; j < ColumnsNum; j++)
				{
					Table.Cell cell = table.cells[i, j];
					if (!cell._0023_003DzC8Y1qQ5FpzJd())
					{
						cell._0023_003DzkkRJVPID18Hg(new Table.CellRange(i, j, i, j));
					}
				}
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Table table = (Table)entity;
		RowsNum = table.RowsNum;
		ColumnsNum = table.ColumnsNum;
		RowsHeights = table.RowsHeights;
		ColumnsWidths = table.ColumnsWidths;
		Direction = table.Direction;
		HorzCellMargin = table.HorCellMargin;
		VertCellMargin = table.VerCellMargin;
		Cells = table.cells.ToProtoArray<Table.Cell>();
		base.CopyDataFromObject(entity);
	}
}

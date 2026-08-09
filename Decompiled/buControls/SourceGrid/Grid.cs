using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid.Cells;
using ns27;

namespace SourceGrid;

[ToolboxItem(true)]
public class Grid : GridVirtual
{
	public class GridAccessibleObject : ControlAccessibleObject
	{
		private Grid owner;

		public override AccessibleRole Role => AccessibleRole.Table;

		public override string Name => owner.Name;

		public GridAccessibleObject(Grid owner)
			: base(owner)
		{
			this.owner = owner;
		}

		public override AccessibleObject GetChild(int index)
		{
			return new GridRowAccessibleObject(owner.Rows[index], this);
		}

		public override int GetChildCount()
		{
			return owner.RowsCount;
		}
	}

	public class GridRowAccessibleObject : AccessibleObject
	{
		private GridRow gridRow;

		private GridAccessibleObject parent;

		public override Rectangle Bounds
		{
			get
			{
				if (gridRow.Visible)
				{
					int num = 0;
					if (gridRow.Grid.VerticalScroll.Enabled)
					{
						num = gridRow.Grid.VScrollBar.Value;
					}
					if (gridRow.Index >= num)
					{
						int height = gridRow.Height;
						int num2 = 0;
						if (gridRow.Grid.HorizontalScroll.Enabled)
						{
							num2 = gridRow.Grid.HScrollBar.Value;
						}
						int num3 = 0;
						for (int i = num2; i < gridRow.Grid.Columns.Count; i++)
						{
							GridColumns gridColumns = (GridColumns)gridRow.Grid.Columns;
							num3 += gridColumns[i].Width;
						}
						int x = parent.Bounds.X;
						int num4 = parent.Bounds.Top;
						for (int j = num; j < gridRow.Index; j++)
						{
							GridRows gridRows = (GridRows)gridRow.Grid.Rows;
							num4 += gridRows[j].Height;
						}
						Rectangle rectangle = new Rectangle(x, num4, num3, height);
						if (!parent.Bounds.IntersectsWith(rectangle))
						{
							return Rectangle.Empty;
						}
						return rectangle;
					}
					return Rectangle.Empty;
				}
				return Rectangle.Empty;
			}
		}

		public override string Name => "Row " + gridRow.Index;

		public override AccessibleRole Role => AccessibleRole.Row;

		public override AccessibleObject Parent => parent;

		public GridRowAccessibleObject(GridRow gridRow, GridAccessibleObject parent)
		{
			this.gridRow = gridRow;
			this.parent = parent;
		}

		public override AccessibleObject GetChild(int index)
		{
			ICellVirtual[] cellsAtRow = gridRow.Grid.GetCellsAtRow(gridRow.Index);
			if (index >= cellsAtRow.Length)
			{
				Cell cell = (Cell)cellsAtRow[cellsAtRow.Length - 1];
				return new GridRowCellAccessibleObject(cell, this);
			}
			Cell cell2 = (Cell)cellsAtRow[index];
			if (cell2 != null)
			{
				return new GridRowCellAccessibleObject(cell2, this);
			}
			return null;
		}

		public override int GetChildCount()
		{
			return gridRow.Grid.GetCellsAtRow(gridRow.Index).Length;
		}
	}

	public class GridRowCellAccessibleObject : AccessibleObject
	{
		private Cell cell;

		private GridRowAccessibleObject parent;

		public override Rectangle Bounds
		{
			get
			{
				if (!(parent.Bounds == Rectangle.Empty))
				{
					int num = 0;
					if (cell.Grid.HorizontalScroll.Enabled)
					{
						num = cell.Grid.HScrollBar.Value;
					}
					if (cell.Column.Index >= num)
					{
						int width = cell.Column.Width;
						int height = cell.Row.Height;
						int num2 = parent.Bounds.X;
						for (int i = num; i < cell.Column.Index; i++)
						{
							GridColumns columns = cell.Grid.Columns;
							num2 += columns[i].Width;
						}
						int y = parent.Bounds.Y;
						Rectangle rectangle = new Rectangle(num2, y, width, height);
						if (!parent.Bounds.IntersectsWith(rectangle))
						{
							return Rectangle.Empty;
						}
						return rectangle;
					}
					return Rectangle.Empty;
				}
				return Rectangle.Empty;
			}
		}

		public override AccessibleRole Role => AccessibleRole.Cell;

		public override string Name
		{
			get
			{
				if (cell.DisplayText == null)
				{
					return "Column " + cell.Column.Index;
				}
				return cell.DisplayText;
			}
		}

		public override string Value
		{
			get
			{
				return cell.DisplayText;
			}
			set
			{
				cell.Value = value;
			}
		}

		public override AccessibleObject Parent => parent;

		public GridRowCellAccessibleObject(Cell cell, GridRowAccessibleObject parent)
		{
			this.cell = cell;
			this.parent = parent;
		}
	}

	[CompilerGenerated]
	private bool bool_7;

	internal ISpannedCellRangesController ispannedCellRangesController_0 = null;

	private CellOptimizeMode cellOptimizeMode_0 = CellOptimizeMode.ForRows;

	private bool bool_8 = false;

	[Obsolete]
	private static int int_11 = 100;

	private RangeCollection rangeCollection_0 = new RangeCollection();

	private bool bool_9 = false;

	public override bool EnableSort
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public ISpannedCellRangesController SpannedCellReferences => ispannedCellRangesController_0;

	[DefaultValue(0)]
	public int ColumnsCount
	{
		get
		{
			return Columns.Count;
		}
		set
		{
			Columns.SetCount(value);
		}
	}

	[DefaultValue(0)]
	public int RowsCount
	{
		get
		{
			return Rows.Count;
		}
		set
		{
			Rows.SetCount(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new GridRows Rows => (GridRows)base.Rows;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new GridColumns Columns => (GridColumns)base.Columns;

	public CellOptimizeMode OptimizeMode
	{
		get
		{
			return cellOptimizeMode_0;
		}
		set
		{
			cellOptimizeMode_0 = value;
		}
	}

	[DefaultValue(false)]
	public bool AllowOverlappingCells
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public ICell this[Position position]
	{
		get
		{
			ICell cell = Class76.smethod_834(this, position);
			if (cell == null)
			{
				return Class76.smethod_34(this, position);
			}
			return cell;
		}
		set
		{
			int row = position.Row;
			int column = position.Column;
			Class76.smethod_477(value, column, row, this);
		}
	}

	public ICell this[int row, int col]
	{
		get
		{
			return this[new Position(row, col)];
		}
		set
		{
			this[new Position(row, col)] = value;
		}
	}

	[Obsolete("This property is not needed anymore. It has completely no effect")]
	public static int MaxSpan
	{
		get
		{
			return int_11;
		}
		set
		{
			int_11 = value;
		}
	}

	[DefaultValue(false)]
	public bool CustomSort
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return new GridAccessibleObject(this);
	}

	public Grid()
	{
		SuspendLayout();
		base.Name = "Grid";
		ispannedCellRangesController_0 = new SpannedCellRangesController(this, new QuadTreeRangesList(Range.From(new Position(0, 0), 4, 4)));
		ResumeLayout(performLayout: false);
	}

	protected override RowsBase CreateRowsObject()
	{
		return new GridRows(this);
	}

	protected override ColumnsBase CreateColumnsObject()
	{
		return new GridColumns(this);
	}

	public virtual void SetCell(int p_iRow, int p_iCol, ICellVirtual p_Cell)
	{
		if (!(p_Cell is ICell))
		{
			if (p_Cell != null)
			{
				throw new SourceGridException("Expected ICell class");
			}
			Class76.smethod_477((ICell)null, p_iCol, p_iRow, this);
		}
		else
		{
			Class76.smethod_477((ICell)p_Cell, p_iCol, p_iRow, this);
		}
	}

	public void SetCell(Position p_Position, ICellVirtual p_Cell)
	{
		SetCell(p_Position.Row, p_Position.Column, p_Cell);
	}

	public override ICellVirtual GetCell(int p_iRow, int p_iCol)
	{
		return this[p_iRow, p_iCol];
	}

	internal void method_1(int int_12, int int_13, ICell icell_0)
	{
		Range range = new Range(int_12, int_13, int_12 + icell_0.RowSpan - 1, int_13 + icell_0.ColumnSpan - 1);
		List<Range> ranges = ispannedCellRangesController_0.SpannedRangesCollection.GetRanges(range);
		if (ranges.Count == 0)
		{
			return;
		}
		Position position = new Position(int_12, int_13);
		foreach (Range item in ranges)
		{
			if (!position.Equals(item.Start))
			{
				ICell cell = this[item.Start];
				if (cell != null)
				{
					throw new OverlappingCellException($"Given cell at position ({int_12}, {int_13}), intersects with another cell at position ({cell.Row.Index}, {cell.Column.Index}) '{cell.DisplayText}'");
				}
				throw new ArgumentException("internal error. please report this bug to developers");
			}
		}
	}

	public void OccupySpannedArea(int row, int col, ICell p_cell)
	{
		if (p_cell == null)
		{
			throw new ArgumentNullException();
		}
		Class76.smethod_128(this, row, col, p_cell);
		ispannedCellRangesController_0.UpdateOrAdd(p_cell.Range);
	}

	public void UpdateSpannedArea(int row, int col, ICell p_cell)
	{
		if (p_cell != null)
		{
			if (p_cell.RowSpan == 1 && p_cell.ColumnSpan == 1)
			{
				throw new ArgumentException("Cell is not spanned! Can not update it!. You should delete it manually, and ensure that foreach statement will not be broken");
			}
			Class76.smethod_128(this, row, col, p_cell);
			ispannedCellRangesController_0.Update(p_cell.Range);
			return;
		}
		throw new ArgumentNullException();
	}

	public void Redim(int p_Rows, int p_Cols)
	{
		SuspendLayout();
		RowsCount = p_Rows;
		ColumnsCount = p_Cols;
		ResumeLayout();
		Class76.smethod_359(this);
	}

	public override Range RangeToCellRange(Range range)
	{
		int column = range.Start.Column;
		int column2 = range.End.Column;
		int row = range.Start.Row;
		int row2 = range.End.Row;
		for (int i = range.Start.Column; i <= range.End.Column; i++)
		{
			for (int j = range.Start.Row; j <= range.End.Row; j++)
			{
				Position position = new Position(j, i);
				Range range2 = PositionToCellRange(position);
				if (range2.IsEmpty())
				{
					range2 = new Range(position, position);
				}
				if (range2.Start.Column < column)
				{
					column = range2.Start.Column;
				}
				if (range2.End.Column > column2)
				{
					column2 = range2.End.Column;
				}
				if (range2.Start.Row < row)
				{
					row = range2.Start.Row;
				}
				if (range2.End.Row > row2)
				{
					row2 = range2.End.Row;
				}
			}
		}
		return new Range(row, column, row2, column2);
	}

	public override Range PositionToCellRange(Position pPosition)
	{
		if (!pPosition.IsEmpty())
		{
			return this[pPosition.Row, pPosition.Column]?.Range ?? Range.Empty;
		}
		return Range.Empty;
	}

	public virtual void InvalidateCell(ICell p_Cell)
	{
		if (p_Cell != null)
		{
			InvalidateRange(p_Cell.Range);
		}
	}

	public override void InvalidateCell(Position p_Position)
	{
		ICell cell = this[p_Position.Row, p_Position.Column];
		if (cell != null && (cell.Range.ColumnsCount != 1 || cell.Range.RowsCount != 1))
		{
			InvalidateRange(cell.Range);
		}
		else
		{
			base.InvalidateCell(p_Position);
		}
	}

	protected override void OnRangePaint(RangePaintEventArgs e)
	{
		rangeCollection_0.Clear();
		base.OnRangePaint(e);
	}

	protected override void PaintCell(GraphicsCache graphics, CellContext cellContext, RectangleF drawRectangle)
	{
		Range range = PositionToCellRange(cellContext.Position);
		if (range.ColumnsCount != 1 || range.RowsCount != 1)
		{
			if (!rangeCollection_0.Contains(range))
			{
				Rectangle rectangle = RangeToRectangle(range);
				base.PaintCell(graphics, cellContext, rectangle);
				rangeCollection_0.Add(range);
			}
		}
		else
		{
			base.PaintCell(graphics, cellContext, drawRectangle);
		}
	}

	protected override void OnSortingRangeRows(SortRangeRowsEventArgs e)
	{
		base.OnSortingRangeRows(e);
		if (CustomSort)
		{
			return;
		}
		if (e.KeyColumn <= e.Range.End.Column || e.KeyColumn >= e.Range.Start.Column)
		{
			IComparer comparer = e.CellComparer;
			if (comparer == null)
			{
				comparer = new ValueCellComparer();
			}
			if (e.Range.ColumnsCount != ColumnsCount)
			{
				ICell[][] array = new ICell[e.Range.End.Row - e.Range.Start.Row + 1][];
				ICell[] array2 = new ICell[e.Range.End.Row - e.Range.Start.Row + 1];
				int num = 0;
				for (int i = e.Range.Start.Row; i <= e.Range.End.Row; i++)
				{
					array2[num] = this[i, e.KeyColumn];
					int num2 = 0;
					array[num] = new ICell[e.Range.End.Column - e.Range.Start.Column + 1];
					for (int j = e.Range.Start.Column; j <= e.Range.End.Column; j++)
					{
						array[num][num2] = this[i, j];
						num2++;
					}
					num++;
				}
				Array.Sort(array2, array, 0, array2.Length, comparer);
				num = 0;
				if (!e.Ascending)
				{
					for (int num3 = e.Range.End.Row; num3 >= e.Range.Start.Row; num3--)
					{
						int num4 = 0;
						for (int k = e.Range.Start.Column; k <= e.Range.End.Column; k++)
						{
							Class76.smethod_256(num3, this, k);
							ICell cell = array[num][num4];
							if (cell != null && cell.Grid != null && cell.Range.Start.Row >= 0 && cell.Range.Start.Column >= 0)
							{
								Position start = cell.Range.Start;
								Grid grid_ = this;
								int row = start.Row;
								start = cell.Range.Start;
								int num5 = row;
								int column = start.Column;
								Class76.smethod_256(num5, grid_, column);
							}
							this[num3, k] = cell;
							num4++;
						}
						num++;
					}
					return;
				}
				for (int l = e.Range.Start.Row; l <= e.Range.End.Row; l++)
				{
					int num6 = 0;
					for (int m = e.Range.Start.Column; m <= e.Range.End.Column; m++)
					{
						Class76.smethod_256(l, this, m);
						ICell cell2 = array[num][num6];
						if (cell2 != null && cell2.Grid != null && cell2.Range.Start.Row >= 0 && cell2.Range.Start.Column >= 0)
						{
							Position start = cell2.Range.Start;
							Grid grid_ = this;
							int row2 = start.Row;
							start = cell2.Range.Start;
							int num5 = row2;
							int column = start.Column;
							Class76.smethod_256(num5, grid_, column);
						}
						this[l, m] = cell2;
						num6++;
					}
					num++;
				}
				return;
			}
			RowInfo[] array3 = new RowInfo[e.Range.End.Row - e.Range.Start.Row + 1];
			ICell[] array4 = new ICell[e.Range.End.Row - e.Range.Start.Row + 1];
			int num7 = 0;
			for (int n = e.Range.Start.Row; n <= e.Range.End.Row; n++)
			{
				array4[num7] = this[n, e.KeyColumn];
				array3[num7] = Rows[n];
				num7++;
			}
			Array.Sort(array4, array3, 0, array4.Length, comparer);
			if (!e.Ascending)
			{
				for (num7 = array3.Length - 1; num7 >= 0; num7--)
				{
					Rows.Swap(array3[num7].Index, e.Range.End.Row - num7);
				}
			}
			else
			{
				for (num7 = 0; num7 < array3.Length; num7++)
				{
					Rows.Swap(array3[num7].Index, e.Range.Start.Row + num7);
				}
			}
			return;
		}
		throw new ArgumentException("Invalid range", "e.KeyColumn");
	}
}

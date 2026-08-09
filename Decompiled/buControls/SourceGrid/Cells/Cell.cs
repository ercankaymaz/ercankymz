using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells;

public class Cell : CellVirtual, ICellVirtual, ICell
{
	private Grid grid_0;

	private GridColumn gridColumn_0;

	private GridRow gridRow_0;

	private object object_0 = null;

	private int int_0 = 1;

	private int int_1 = 1;

	public Grid Grid => grid_0;

	public GridColumn Column => gridColumn_0;

	public GridRow Row => gridRow_0;

	public Range Range
	{
		get
		{
			if (Grid != null)
			{
				int index = Column.Index;
				int index2 = Row.Index;
				return new Range(index2, index, index2 + RowSpan - 1, index + ColumnSpan - 1);
			}
			return Range.Empty;
		}
	}

	public virtual string DisplayText => GetContext().DisplayText;

	public virtual object Value
	{
		get
		{
			return base.Model.ValueModel.GetValue(GetContext());
		}
		set
		{
			base.Model.ValueModel.SetValue(GetContext(), value);
		}
	}

	public virtual object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public int ColumnSpan
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException("ColumnSpan");
			}
			SetSpan(RowSpan, value);
		}
	}

	public int RowSpan
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException("RowSpan");
			}
			SetSpan(value, ColumnSpan);
		}
	}

	public string ToolTipText
	{
		get
		{
			return method_0().ToolTipText;
		}
		set
		{
			method_0().ToolTipText = value;
		}
	}

	public System.Drawing.Image Image
	{
		get
		{
			return method_1().ImageValue;
		}
		set
		{
			method_1().ImageValue = value;
		}
	}

	public Cell()
		: this(null)
	{
	}

	public Cell(object cellValue)
	{
		base.Model = new ModelContainer();
		base.Model.ValueModel = new ValueModel();
		base.Model.AddModel(new ToolTip());
		base.Model.AddModel(new SourceGrid.Cells.Models.Image());
		Value = cellValue;
	}

	public Cell(object cellValue, Type pType)
		: this(cellValue)
	{
		base.Editor = Factory.Create(pType);
	}

	public Cell(object cellValue, EditorBase pEditor)
		: this(cellValue)
	{
		base.Editor = pEditor;
	}

	public virtual void BindToGrid(Grid p_grid, Position p_Position)
	{
		grid_0 = p_grid;
		gridRow_0 = Grid.Rows[p_Position.Row];
		gridColumn_0 = Grid.Columns[p_Position.Column] as GridColumn;
	}

	public virtual void UnBindToGrid()
	{
		grid_0 = null;
		gridColumn_0 = null;
		gridRow_0 = null;
	}

	protected CellContext GetContext()
	{
		return new CellContext(Grid, Range.Start, this);
	}

	public override string ToString()
	{
		return DisplayText;
	}

	public void SetSpan(int rowSpan, int colSpan)
	{
		int columnSpan = ColumnSpan;
		int num = int_1;
		try
		{
			bool flag = false;
			if (int_0 > 1 || int_1 > 1)
			{
				flag = true;
			}
			int_0 = colSpan;
			int_1 = rowSpan;
			if (grid_0 != null && (int_0 != 1 || int_1 != 1))
			{
				if (!flag)
				{
					grid_0.OccupySpannedArea(Row.Index, Column.Index, this);
				}
				else
				{
					grid_0.UpdateSpannedArea(Row.Index, Column.Index, this);
				}
			}
		}
		catch (OverlappingCellException p_InnerException)
		{
			int_0 = columnSpan;
			int_1 = num;
			throw new OverlappingCellException("Can not change span", p_InnerException);
		}
	}

	[SpecialName]
	private ToolTip method_0()
	{
		return (ToolTip)base.Model.FindModel(typeof(ToolTip));
	}

	[SpecialName]
	private SourceGrid.Cells.Models.Image method_1()
	{
		return (SourceGrid.Cells.Models.Image)base.Model.FindModel(typeof(SourceGrid.Cells.Models.Image));
	}
}

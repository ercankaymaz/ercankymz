using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Virtual;

namespace SourceGrid;

[ToolboxItem(true)]
public class ArrayGrid : GridVirtual
{
	[CompilerGenerated]
	private bool bool_7;

	private Array array_0 = null;

	private ICellVirtual icellVirtual_0 = new ArrayColumnHeader();

	private ICellVirtual icellVirtual_1 = new ArrayRowHeader();

	private ICellVirtual icellVirtual_2 = new ArrayHeader();

	private ICellVirtual icellVirtual_3;

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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ArrayRows Rows => (ArrayRows)base.Rows;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ArrayColumns Columns => (ArrayColumns)base.Columns;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Array DataSource
	{
		get
		{
			return array_0;
		}
		set
		{
			if (value != null && value.Rank != 2)
			{
				throw new SourceGridException("Array dimension not valid, must be an array with 2 dimensions");
			}
			array_0 = value;
			Bind();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ICellVirtual ColumnHeader
	{
		get
		{
			return icellVirtual_0;
		}
		set
		{
			icellVirtual_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ICellVirtual RowHeader
	{
		get
		{
			return icellVirtual_1;
		}
		set
		{
			icellVirtual_1 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ICellVirtual Header
	{
		get
		{
			return icellVirtual_2;
		}
		set
		{
			icellVirtual_2 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ICellVirtual ValueCell
	{
		get
		{
			return icellVirtual_3;
		}
		set
		{
			icellVirtual_3 = value;
		}
	}

	protected override RowsBase CreateRowsObject()
	{
		return new ArrayRows(this);
	}

	protected override ColumnsBase CreateColumnsObject()
	{
		return new ArrayColumns(this);
	}

	public override ICellVirtual GetCell(int p_iRow, int p_iCol)
	{
		if (p_iRow >= base.FixedRows || p_iCol >= base.FixedColumns)
		{
			if (p_iRow >= base.FixedRows)
			{
				if (p_iCol >= base.FixedColumns)
				{
					return icellVirtual_3;
				}
				return icellVirtual_1;
			}
			return icellVirtual_0;
		}
		return icellVirtual_2;
	}

	protected virtual void Bind()
	{
		ValueCell = null;
		if (array_0 != null)
		{
			icellVirtual_3 = new CellVirtual();
			icellVirtual_3.Model.AddModel(new ArrayValueModel());
			icellVirtual_3.Editor = Factory.Create(array_0.GetType().GetElementType());
		}
		Rows.RowsChanged();
		Columns.ColumnsChanged();
	}
}

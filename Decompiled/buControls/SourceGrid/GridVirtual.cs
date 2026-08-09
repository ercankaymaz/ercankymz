#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Windows.Forms;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Decorators;
using SourceGrid.Selection;
using ns27;

namespace SourceGrid;

[ToolboxItem(false)]
public abstract class GridVirtual : CustomScrollControl
{
	[CompilerGenerated]
	private sealed class Class65 : IDisposable, IEnumerable, IEnumerator, IEnumerable<Range>, IEnumerator<Range>
	{
		private int int_0;

		private Range range_0;

		private int int_1;

		public GridVirtual gridVirtual_0;

		private Range range_1;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class65(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			switch (int_0)
			{
			case 4:
				int_0 = -1;
				goto IL_002a;
			default:
				return false;
			case 0:
				int_0 = -1;
				range_1 = gridVirtual_0.RangeAtArea(CellPositionType.FixedTopLeft);
				if (!range_1.IsEmpty())
				{
					range_0 = range_1;
					int_0 = 1;
					return true;
				}
				goto IL_005a;
			case 1:
				int_0 = -1;
				goto IL_005a;
			case 2:
				int_0 = -1;
				goto IL_007f;
			case 3:
				{
					int_0 = -1;
					goto IL_00a4;
				}
				IL_005a:
				range_1 = gridVirtual_0.RangeAtArea(CellPositionType.FixedTop);
				if (!range_1.IsEmpty())
				{
					range_0 = range_1;
					int_0 = 2;
					return true;
				}
				goto IL_007f;
				IL_007f:
				range_1 = gridVirtual_0.RangeAtArea(CellPositionType.FixedLeft);
				if (!range_1.IsEmpty())
				{
					range_0 = range_1;
					int_0 = 3;
					return true;
				}
				goto IL_00a4;
				IL_00a4:
				range_1 = gridVirtual_0.RangeAtArea(CellPositionType.Scrollable);
				if (!range_1.IsEmpty())
				{
					range_0 = range_1;
					int_0 = 4;
					return true;
				}
				goto IL_002a;
				IL_002a:
				return false;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class65 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class65(0)
				{
					gridVirtual_0 = gridVirtual_0
				};
			}
			else
			{
				int_0 = 0;
				result = this;
			}
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	private int int_5 = 20;

	private int int_6 = 50;

	private int int_7 = 0;

	private int int_8 = 0;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private Position position_0 = Position.Empty;

	private IGridSelection igridSelection_0;

	private GridSelectionMode gridSelectionMode_0;

	protected Position m_MouseDownPosition = Position.Empty;

	protected Position m_MouseCellPosition = Position.Empty;

	private Range range_0 = Range.Empty;

	private Range range_1 = Range.Empty;

	private Position position_1;

	private bool bool_2 = true;

	private GridSpecialKeys gridSpecialKeys_0 = GridSpecialKeys.Default;

	private bool bool_3 = true;

	[CompilerGenerated]
	private RangePaintEventHandler rangePaintEventHandler_0;

	private Position position_2;

	private bool bool_4 = true;

	private LinkedControlsList linkedControlsList_0;

	[CompilerGenerated]
	private SortRangeRowsEventHandler sortRangeRowsEventHandler_0;

	[CompilerGenerated]
	private SortRangeRowsEventHandler sortRangeRowsEventHandler_1;

	private int int_9 = 0;

	private int int_10 = 0;

	private RowsBase rowsBase_0;

	private ColumnsBase columnsBase_0;

	[CompilerGenerated]
	private ExceptionEventHandler exceptionEventHandler_0;

	private bool bool_5 = false;

	private ToolTip toolTip_0;

	private DecoratorList decoratorList_0 = new DecoratorList();

	private ControllerContainer controllerContainer_0 = new ControllerContainer();

	private ClipboardMode clipboardMode_0 = ClipboardMode.None;

	private bool bool_6 = false;

	[DefaultValue(20)]
	public int DefaultHeight
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	[DefaultValue(50)]
	public int DefaultWidth
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	[DefaultValue(0)]
	public int MinimumHeight
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	[DefaultValue(0)]
	public int MinimumWidth
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoStretchColumnsToFitWidth
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoStretchRowsToFitHeight
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Position DragCellPosition => position_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IGridSelection Selection
	{
		get
		{
			return igridSelection_0;
		}
		protected set
		{
			if (igridSelection_0 != null)
			{
				igridSelection_0.UnBindToGrid();
			}
			igridSelection_0 = value;
			if (igridSelection_0 != null)
			{
				igridSelection_0.BindToGrid(this);
			}
		}
	}

	public GridSelectionMode SelectionMode
	{
		get
		{
			return gridSelectionMode_0;
		}
		set
		{
			gridSelectionMode_0 = value;
			Selection = CreateSelectionObject();
			Invalidate(invalidateChildren: true);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Position MouseDownPosition => m_MouseDownPosition;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Position MouseCellPosition => m_MouseCellPosition;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Range MouseSelectionRange => range_1;

	[DefaultValue(true)]
	public bool OverrideCommonCmdKey
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	[DefaultValue(GridSpecialKeys.Default)]
	public GridSpecialKeys SpecialKeys
	{
		get
		{
			return gridSpecialKeys_0;
		}
		set
		{
			gridSpecialKeys_0 = value;
		}
	}

	[DefaultValue(true)]
	public bool AcceptsInputChar
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LinkedControlsList LinkedControls => linkedControlsList_0;

	public abstract bool EnableSort { get; set; }

	[DefaultValue(0)]
	public int FixedRows
	{
		get
		{
			return int_9;
		}
		set
		{
			if (int_9 != value)
			{
				int_9 = value;
				OnCellsAreaChanged();
			}
		}
	}

	public int ActualFixedRows
	{
		get
		{
			if (FixedRows <= Rows.Count)
			{
				return FixedRows;
			}
			return Rows.Count;
		}
	}

	[DefaultValue(0)]
	public int FixedColumns
	{
		get
		{
			return int_10;
		}
		set
		{
			if (int_10 != value)
			{
				int_10 = value;
				OnCellsAreaChanged();
			}
		}
	}

	public int ActualFixedColumns
	{
		get
		{
			if (FixedColumns <= Columns.Count)
			{
				return FixedColumns;
			}
			return Columns.Count;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RowsBase Rows => rowsBase_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ColumnsBase Columns => columnsBase_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range CompleteRange
	{
		get
		{
			if (Rows.Count <= 0 || Columns.Count <= 0)
			{
				return Range.Empty;
			}
			return new Range(0, 0, Rows.Count - 1, Columns.Count - 1);
		}
	}

	[Description("Change the right-to-left layout.")]
	[DefaultValue(false)]
	[Localizable(true)]
	[Category("Appearance")]
	[Browsable(true)]
	public bool Mirrored
	{
		get
		{
			return bool_5;
		}
		set
		{
			if (bool_5 != value)
			{
				bool_5 = value;
				OnRightToLeftChanged(EventArgs.Empty);
			}
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			if (Mirrored)
			{
				createParams.ExStyle |= 4194304;
			}
			return createParams;
		}
	}

	[Browsable(false)]
	[DefaultValue(RightToLeft.No)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override RightToLeft RightToLeft
	{
		get
		{
			return RightToLeft.No;
		}
		set
		{
		}
	}

	public string ToolTipText
	{
		get
		{
			return toolTip_0.GetToolTip(this);
		}
		set
		{
			toolTip_0.SetToolTip(this, value);
		}
	}

	public ToolTip ToolTip => toolTip_0;

	public DecoratorList Decorators => decoratorList_0;

	public ControllerContainer Controller => controllerContainer_0;

	[DefaultValue(ClipboardMode.None)]
	public ClipboardMode ClipboardMode
	{
		get
		{
			return clipboardMode_0;
		}
		set
		{
			clipboardMode_0 = value;
		}
	}

	[DefaultValue(false)]
	public bool ClipboardUseOnlyActivePosition
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public event RangePaintEventHandler RangePaint
	{
		[CompilerGenerated]
		add
		{
			RangePaintEventHandler rangePaintEventHandler = rangePaintEventHandler_0;
			RangePaintEventHandler rangePaintEventHandler2;
			do
			{
				rangePaintEventHandler2 = rangePaintEventHandler;
				RangePaintEventHandler value2 = (RangePaintEventHandler)Delegate.Combine(rangePaintEventHandler2, value);
				rangePaintEventHandler = Interlocked.CompareExchange(ref rangePaintEventHandler_0, value2, rangePaintEventHandler2);
			}
			while ((object)rangePaintEventHandler != rangePaintEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RangePaintEventHandler rangePaintEventHandler = rangePaintEventHandler_0;
			RangePaintEventHandler rangePaintEventHandler2;
			do
			{
				rangePaintEventHandler2 = rangePaintEventHandler;
				RangePaintEventHandler value2 = (RangePaintEventHandler)Delegate.Remove(rangePaintEventHandler2, value);
				rangePaintEventHandler = Interlocked.CompareExchange(ref rangePaintEventHandler_0, value2, rangePaintEventHandler2);
			}
			while ((object)rangePaintEventHandler != rangePaintEventHandler2);
		}
	}

	[Browsable(true)]
	public event SortRangeRowsEventHandler SortingRangeRows
	{
		[CompilerGenerated]
		add
		{
			SortRangeRowsEventHandler sortRangeRowsEventHandler = sortRangeRowsEventHandler_0;
			SortRangeRowsEventHandler sortRangeRowsEventHandler2;
			do
			{
				sortRangeRowsEventHandler2 = sortRangeRowsEventHandler;
				SortRangeRowsEventHandler value2 = (SortRangeRowsEventHandler)Delegate.Combine(sortRangeRowsEventHandler2, value);
				sortRangeRowsEventHandler = Interlocked.CompareExchange(ref sortRangeRowsEventHandler_0, value2, sortRangeRowsEventHandler2);
			}
			while ((object)sortRangeRowsEventHandler != sortRangeRowsEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SortRangeRowsEventHandler sortRangeRowsEventHandler = sortRangeRowsEventHandler_0;
			SortRangeRowsEventHandler sortRangeRowsEventHandler2;
			do
			{
				sortRangeRowsEventHandler2 = sortRangeRowsEventHandler;
				SortRangeRowsEventHandler value2 = (SortRangeRowsEventHandler)Delegate.Remove(sortRangeRowsEventHandler2, value);
				sortRangeRowsEventHandler = Interlocked.CompareExchange(ref sortRangeRowsEventHandler_0, value2, sortRangeRowsEventHandler2);
			}
			while ((object)sortRangeRowsEventHandler != sortRangeRowsEventHandler2);
		}
	}

	[Browsable(true)]
	public event SortRangeRowsEventHandler SortedRangeRows
	{
		[CompilerGenerated]
		add
		{
			SortRangeRowsEventHandler sortRangeRowsEventHandler = sortRangeRowsEventHandler_1;
			SortRangeRowsEventHandler sortRangeRowsEventHandler2;
			do
			{
				sortRangeRowsEventHandler2 = sortRangeRowsEventHandler;
				SortRangeRowsEventHandler value2 = (SortRangeRowsEventHandler)Delegate.Combine(sortRangeRowsEventHandler2, value);
				sortRangeRowsEventHandler = Interlocked.CompareExchange(ref sortRangeRowsEventHandler_1, value2, sortRangeRowsEventHandler2);
			}
			while ((object)sortRangeRowsEventHandler != sortRangeRowsEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SortRangeRowsEventHandler sortRangeRowsEventHandler = sortRangeRowsEventHandler_1;
			SortRangeRowsEventHandler sortRangeRowsEventHandler2;
			do
			{
				sortRangeRowsEventHandler2 = sortRangeRowsEventHandler;
				SortRangeRowsEventHandler value2 = (SortRangeRowsEventHandler)Delegate.Remove(sortRangeRowsEventHandler2, value);
				sortRangeRowsEventHandler = Interlocked.CompareExchange(ref sortRangeRowsEventHandler_1, value2, sortRangeRowsEventHandler2);
			}
			while ((object)sortRangeRowsEventHandler != sortRangeRowsEventHandler2);
		}
	}

	public event ExceptionEventHandler UserException
	{
		[CompilerGenerated]
		add
		{
			ExceptionEventHandler exceptionEventHandler = exceptionEventHandler_0;
			ExceptionEventHandler exceptionEventHandler2;
			do
			{
				exceptionEventHandler2 = exceptionEventHandler;
				ExceptionEventHandler value2 = (ExceptionEventHandler)Delegate.Combine(exceptionEventHandler2, value);
				exceptionEventHandler = Interlocked.CompareExchange(ref exceptionEventHandler_0, value2, exceptionEventHandler2);
			}
			while ((object)exceptionEventHandler != exceptionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExceptionEventHandler exceptionEventHandler = exceptionEventHandler_0;
			ExceptionEventHandler exceptionEventHandler2;
			do
			{
				exceptionEventHandler2 = exceptionEventHandler;
				ExceptionEventHandler value2 = (ExceptionEventHandler)Delegate.Remove(exceptionEventHandler2, value);
				exceptionEventHandler = Interlocked.CompareExchange(ref exceptionEventHandler_0, value2, exceptionEventHandler2);
			}
			while ((object)exceptionEventHandler != exceptionEventHandler2);
		}
	}

	public GridVirtual()
	{
		SetStyle(ControlStyles.Selectable, value: true);
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.ContainerControl, value: true);
		base.TabStop = true;
		EnableSort = true;
		rowsBase_0 = CreateRowsObject();
		columnsBase_0 = CreateColumnsObject();
		SelectionMode = GridSelectionMode.Cell;
		Controller.AddController(StandardBehavior.Default);
		Controller.AddController(MouseSelection.Default);
		Controller.AddController(CellEventDispatcher.Default);
		linkedControlsList_0 = new LinkedControlsList(this);
		toolTip_0 = new ToolTip();
		ToolTipText = "";
	}

	protected abstract RowsBase CreateRowsObject();

	protected abstract ColumnsBase CreateColumnsObject();

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
		}
		base.Dispose(disposing);
	}

	public virtual void AutoSizeCells(Range p_RangeToAutoSize)
	{
		SuspendLayout();
		if (!p_RangeToAutoSize.IsEmpty())
		{
			Rows.SuspendLayout();
			Columns.SuspendLayout();
			try
			{
				for (int num = p_RangeToAutoSize.End.Column; num >= p_RangeToAutoSize.Start.Column; num--)
				{
					Columns.AutoSizeColumn(num, useRowHeight: false, p_RangeToAutoSize.Start.Row, p_RangeToAutoSize.End.Row);
				}
				for (int num2 = p_RangeToAutoSize.End.Row; num2 >= p_RangeToAutoSize.Start.Row; num2--)
				{
					Rows.AutoSizeRow(num2, useColumnWidth: false, p_RangeToAutoSize.Start.Column, p_RangeToAutoSize.End.Column);
				}
			}
			finally
			{
				Rows.ResumeLayout();
				Columns.ResumeLayout();
			}
			if (AutoStretchColumnsToFitWidth)
			{
				Columns.StretchToFit();
			}
			if (AutoStretchRowsToFitHeight)
			{
				Rows.StretchToFit();
			}
		}
		ResumeLayout(performLayout: false);
	}

	public virtual void AutoSizeCells()
	{
		AutoSizeCells(CompleteRange);
	}

	public virtual void CheckPositions()
	{
		Range completeRange = CompleteRange;
		if (!m_MouseCellPosition.IsEmpty() && !CompleteRange.Contains(m_MouseCellPosition))
		{
			m_MouseCellPosition = Position.Empty;
		}
		if (!m_MouseDownPosition.IsEmpty() && !CompleteRange.Contains(m_MouseDownPosition))
		{
			m_MouseDownPosition = Position.Empty;
		}
		if (!position_0.IsEmpty() && !CompleteRange.Contains(position_0))
		{
			position_0 = Position.Empty;
		}
		RangeRegion rangeRegion = new RangeRegion(completeRange);
		if ((!Selection.ActivePosition.IsEmpty() && !completeRange.Contains(Selection.ActivePosition)) || (!Selection.IsEmpty() && !rangeRegion.Contains(Selection.GetSelectionRegion())))
		{
			Selection.ResetSelection(mantainFocus: false);
		}
	}

	public Rectangle PositionToRectangle(Position position)
	{
		return RangeToRectangle(PositionToCellRange(position));
	}

	public virtual Position PositionAtPoint(Point point)
	{
		int? num = Rows.RowAtPoint(point.Y);
		if (num.HasValue)
		{
			int? num2 = Columns.ColumnAtPoint(point.X);
			if (num2.HasValue)
			{
				Position p_Position = new Position(num.Value, num2.Value);
				return PositionToStartPosition(p_Position);
			}
			return Position.Empty;
		}
		return Position.Empty;
	}

	public Size RangeToSize(Range range)
	{
		if (!range.IsEmpty())
		{
			int num = 0;
			for (int i = range.Start.Column; i <= range.End.Column; i++)
			{
				num += Columns.GetWidth(i);
			}
			int num2 = 0;
			for (int j = range.Start.Row; j <= range.End.Row; j++)
			{
				num2 += Rows.GetHeight(j);
			}
			return new Size(num, num2);
		}
		return Size.Empty;
	}

	public Rectangle RangeToRectangle(Range range)
	{
		if (!range.IsEmpty())
		{
			if (range.Start.Column >= 0)
			{
				int left = Columns.GetLeft(range.Start.Column);
				if (range.Start.Row >= 0)
				{
					int top = Rows.GetTop(range.Start.Row);
					Size size = RangeToSize(range);
					if (!size.IsEmpty)
					{
						return new Rectangle(new Point(left, top), size);
					}
					return Rectangle.Empty;
				}
				throw new ArgumentOutOfRangeException($"range.Start.Row was less than zero: {range.Start.Row}");
			}
			throw new ArgumentOutOfRangeException($"range.Start.Column was less than zero: {range.Start.Column}");
		}
		return Rectangle.Empty;
	}

	public Range RangeAtArea(CellPositionType areaType)
	{
		switch (areaType)
		{
		default:
			throw new SourceGridException("Invalid areaType");
		case CellPositionType.FixedTopLeft:
			if (FixedRows <= 0 || Rows.Count < FixedRows || FixedColumns <= 0 || Columns.Count < FixedColumns)
			{
				return Range.Empty;
			}
			return new Range(0, 0, FixedRows - 1, FixedColumns - 1);
		case CellPositionType.FixedLeft:
		{
			int num2 = FixedColumns;
			if (num2 > Columns.Count)
			{
				num2 = Columns.Count;
			}
			if (num2 > 0)
			{
				int? firstVisibleScrollableRow2 = Rows.FirstVisibleScrollableRow;
				int? lastVisibleScrollableRow2 = Rows.LastVisibleScrollableRow;
				if (firstVisibleScrollableRow2.HasValue && lastVisibleScrollableRow2.HasValue)
				{
					return new Range(firstVisibleScrollableRow2.Value, 0, lastVisibleScrollableRow2.Value, num2 - 1);
				}
				return Range.Empty;
			}
			return Range.Empty;
		}
		case CellPositionType.FixedTop:
		{
			int num = FixedRows;
			if (num > Rows.Count)
			{
				num = Rows.Count;
			}
			if (num > 0)
			{
				int? firstVisibleScrollableColumn2 = Columns.FirstVisibleScrollableColumn;
				int? lastVisibleScrollableColumn2 = Columns.LastVisibleScrollableColumn;
				if (firstVisibleScrollableColumn2.HasValue && lastVisibleScrollableColumn2.HasValue)
				{
					return new Range(0, firstVisibleScrollableColumn2.Value, num - 1, lastVisibleScrollableColumn2.Value);
				}
				return Range.Empty;
			}
			return Range.Empty;
		}
		case CellPositionType.Scrollable:
		{
			int? firstVisibleScrollableRow = Rows.FirstVisibleScrollableRow;
			int? lastVisibleScrollableRow = Rows.LastVisibleScrollableRow;
			int? firstVisibleScrollableColumn = Columns.FirstVisibleScrollableColumn;
			int? lastVisibleScrollableColumn = Columns.LastVisibleScrollableColumn;
			if (firstVisibleScrollableRow.HasValue && firstVisibleScrollableColumn.HasValue && lastVisibleScrollableRow.HasValue && lastVisibleScrollableColumn.HasValue)
			{
				return new Range(firstVisibleScrollableRow.Value, firstVisibleScrollableColumn.Value, lastVisibleScrollableRow.Value, lastVisibleScrollableColumn.Value);
			}
			return Range.Empty;
		}
		}
	}

	[IteratorStateMachine(typeof(Class65))]
	private IEnumerable<Range> method_0()
	{
		//yield-return decompiler failed: Method not found
		return new Class65(-2)
		{
			gridVirtual_0 = this
		};
	}

	public List<int> GetVisibleRows(bool returnsPartial)
	{
		return GetVisibleRows(base.DisplayRectangle, returnsPartial);
	}

	public List<int> GetVisibleRows(Rectangle displayRectangle, bool returnsPartial)
	{
		List<int> list = Rows.RowsInsideRegion(displayRectangle.Y, displayRectangle.Height, returnsPartial, returnsFixedRows: true);
		List<int> list2 = new List<int>(list.Count);
		foreach (int item in list)
		{
			if (Rows.IsRowVisible(item))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public List<int> GetVisibleColumns(bool returnsPartial)
	{
		return GetVisibleColumns(base.DisplayRectangle, returnsPartial);
	}

	public List<int> GetVisibleColumns(Rectangle displayRectangle, bool returnsPartial)
	{
		return Columns.ColumnsInsideRegion(displayRectangle.X, displayRectangle.Width, returnsPartial, returnsFixedColumns: true);
	}

	protected override int GetScrollRows(int displayHeight)
	{
		if (displayHeight >= 0)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < ActualFixedRows; i++)
			{
				displayHeight -= Rows.GetHeight(i);
			}
			for (int num3 = Rows.Count - 1; num3 >= ActualFixedRows; num3--)
			{
				if (Rows.IsRowVisible(num3))
				{
					num += Rows.GetHeight(num3);
					if (num > displayHeight)
					{
						return Rows.Count - num2 - Class76.smethod_228(this, num3);
					}
					num2++;
				}
			}
			return 0;
		}
		return 0;
	}

	protected override int GetActualFixedRows()
	{
		return ActualFixedRows;
	}

	protected override int GetScrollColumns(int displayWidth)
	{
		if (displayWidth >= 0)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < ActualFixedColumns; i++)
			{
				displayWidth -= Columns.GetWidth(i);
			}
			int num3 = Columns.Count - 1;
			while (num3 >= ActualFixedColumns)
			{
				num += Columns.GetWidth(num3);
				if (num <= displayWidth)
				{
					num2++;
					num3--;
					continue;
				}
				return Columns.Count - num2;
			}
			return 0;
		}
		return 0;
	}

	public bool IsCellVisible(Position position, bool partial)
	{
		Point newScrollPosition;
		return !GetScrollPositionToShowCell(position, partial, out newScrollPosition);
	}

	protected virtual bool GetScrollPositionToShowCell(Position position, bool partial, out Point newScrollPosition)
	{
		Rectangle displayRectangle = base.DisplayRectangle;
		List<int> visibleRows = GetVisibleRows(partial);
		List<int> visibleColumns = GetVisibleColumns(partial);
		if (!visibleRows.Contains(position.Row) || !visibleColumns.Contains(position.Column))
		{
			CellPositionType positionType = GetPositionType(position);
			bool flag = false;
			if (positionType == CellPositionType.FixedTop || positionType == CellPositionType.FixedTopLeft)
			{
				flag = true;
			}
			bool flag2 = false;
			if (positionType == CellPositionType.FixedLeft || positionType == CellPositionType.FixedTopLeft)
			{
				flag2 = true;
			}
			int num;
			if (!visibleColumns.Contains(position.Column))
			{
				num = ((!flag2) ? (position.Column - FixedColumns) : 0);
				int scrollColumns = GetScrollColumns(displayRectangle.Width);
				if (num > scrollColumns)
				{
					num = scrollColumns;
				}
			}
			else
			{
				num = CustomScrollPosition.X;
			}
			int num2;
			if (!visibleRows.Contains(position.Row))
			{
				if (CustomScrollPosition.Y + ActualFixedRows <= position.Row)
				{
					num2 = Class76.smethod_798(this, position.Row) - ActualFixedRows;
					num2 = Class76.smethod_214(this, num2);
				}
				else
				{
					num2 = ((!flag) ? (position.Row - FixedRows) : 0);
					int scrollRows = GetScrollRows(displayRectangle.Height);
					if (num2 > scrollRows)
					{
						num2 = scrollRows;
					}
					num2 = Class76.smethod_214(this, num2);
				}
			}
			else
			{
				num2 = CustomScrollPosition.Y;
				num2 = Class76.smethod_214(this, num2);
			}
			newScrollPosition = new Point(num, num2);
			return true;
		}
		newScrollPosition = CustomScrollPosition;
		return false;
	}

	public bool ShowCell(Position p_Position, bool ignorePartial)
	{
		if (!GetScrollPositionToShowCell(p_Position, ignorePartial, out var newScrollPosition))
		{
			return true;
		}
		CustomScrollPosition = newScrollPosition;
		if (FixedRows > 0 || FixedColumns > 0)
		{
			Invalidate();
		}
		return false;
	}

	public virtual void InvalidateCell(Position position)
	{
		InvalidateRange(new Range(position));
	}

	public void InvalidateRange(Range range)
	{
		if (range.IsEmpty())
		{
			return;
		}
		CellPositionType[] array = new CellPositionType[4]
		{
			CellPositionType.FixedLeft,
			CellPositionType.FixedTop,
			CellPositionType.FixedTopLeft,
			CellPositionType.Scrollable
		};
		CellPositionType[] array2 = array;
		foreach (CellPositionType areaType in array2)
		{
			Range p_Range = RangeAtArea(areaType);
			Range range2 = Range.Intersect(range, p_Range);
			if (!range2.IsEmpty())
			{
				Rectangle rc = RangeToRectangle(range2);
				if (!rc.IsEmpty)
				{
					Invalidate(rc, invalidateChildren: true);
				}
			}
		}
	}

	public Range RangeAtAreaExpanded(CellPositionType areaType)
	{
		Range result = RangeAtArea(areaType);
		if (!result.IsEmpty())
		{
			int row = ((result.Start.Row > 0) ? (result.Start.Row - 1) : 0);
			int col = ((result.Start.Column > 0) ? (result.Start.Column - 1) : 0);
			result = new Range(new Position(row, col), result.End);
		}
		return result;
	}

	public void ScrollOnPoint(Point mousePoint)
	{
		Rectangle scrollableArea = GetScrollableArea();
		int? lastVisibleScrollableColumn = Columns.LastVisibleScrollableColumn;
		if (mousePoint.X > scrollableArea.Right && (!lastVisibleScrollableColumn.HasValue || lastVisibleScrollableColumn.Value < Columns.Count - 1 || Columns.GetRight(lastVisibleScrollableColumn.Value) > scrollableArea.Right))
		{
			CustomScrollLineRight();
		}
		lastVisibleScrollableColumn = Rows.LastVisibleScrollableRow;
		if (mousePoint.Y > scrollableArea.Bottom && (!lastVisibleScrollableColumn.HasValue || lastVisibleScrollableColumn.Value < Rows.Count - 1 || Rows.GetBottom(lastVisibleScrollableColumn.Value) > scrollableArea.Bottom))
		{
			CustomScrollLineDown();
		}
		if (mousePoint.X < scrollableArea.Left)
		{
			CustomScrollLineLeft();
		}
		if (mousePoint.Y < scrollableArea.Top)
		{
			CustomScrollLineUp();
		}
	}

	protected override void InvalidateScrollableArea()
	{
		Invalidate(invalidateChildren: true);
	}

	public Rectangle GetScrollableArea()
	{
		Rectangle displayRectangle = base.DisplayRectangle;
		int actualFixedRows = ActualFixedRows;
		int actualFixedColumns = ActualFixedColumns;
		if (actualFixedRows <= 0)
		{
			displayRectangle.Y = 0;
		}
		else
		{
			displayRectangle.Y = Rows.GetAbsoluteBottom(actualFixedRows - 1);
		}
		displayRectangle.Height -= displayRectangle.Y;
		if (actualFixedColumns <= 0)
		{
			displayRectangle.X = 0;
		}
		else
		{
			displayRectangle.X = Columns.GetAbsoluteRight(actualFixedColumns - 1);
		}
		displayRectangle.Width -= displayRectangle.X;
		return displayRectangle;
	}

	public Rectangle GetFixedTopLeftArea()
	{
		Rectangle scrollableArea = GetScrollableArea();
		return new Rectangle(0, 0, scrollableArea.Left, scrollableArea.Top);
	}

	public Rectangle GetFixedTopArea()
	{
		Rectangle scrollableArea = GetScrollableArea();
		return new Rectangle(scrollableArea.Left, 0, scrollableArea.Width, scrollableArea.Top);
	}

	public Rectangle GetFixedLeftArea()
	{
		Rectangle scrollableArea = GetScrollableArea();
		return new Rectangle(0, scrollableArea.Top, scrollableArea.Left, scrollableArea.Height);
	}

	public virtual Range RangeToCellRange(Range range)
	{
		return new Range(range.Start, range.End);
	}

	public Position PositionToStartPosition(Position p_Position)
	{
		return PositionToCellRange(p_Position).Start;
	}

	public virtual Range PositionToCellRange(Position pPosition)
	{
		if (!pPosition.IsEmpty())
		{
			ICellVirtual cell = GetCell(pPosition.Row, pPosition.Column);
			if (cell != null)
			{
				return new Range(pPosition);
			}
			return Range.Empty;
		}
		return Range.Empty;
	}

	public virtual void ChangeDragCell(CellContext cell, DragEventArgs pDragEventArgs)
	{
		if (cell.Position != position_0)
		{
			if (!position_0.IsEmpty())
			{
				Controller.OnDragLeave(new CellContext(this, position_0, GetCell(position_0)), pDragEventArgs);
			}
			if (!cell.Position.IsEmpty())
			{
				Controller.OnDragEnter(cell, pDragEventArgs);
			}
			position_0 = cell.Position;
		}
	}

	protected virtual SelectionBase CreateSelectionObject()
	{
		return SelectionMode switch
		{
			GridSelectionMode.Column => new ColumnSelection(), 
			GridSelectionMode.Cell => new FreeSelection(), 
			GridSelectionMode.Row => new RowSelection(), 
			_ => throw new ArgumentException("SelectionMode not valid", "SelectionMode"), 
		};
	}

	public virtual void ChangeMouseCell(Position p_Cell)
	{
		if (m_MouseCellPosition != p_Cell)
		{
			if (!m_MouseCellPosition.IsEmpty() && m_MouseCellPosition != m_MouseDownPosition)
			{
				Controller.OnMouseLeave(new CellContext(this, m_MouseCellPosition), EventArgs.Empty);
			}
			m_MouseCellPosition = p_Cell;
			if (!m_MouseCellPosition.IsEmpty())
			{
				Controller.OnMouseEnter(new CellContext(this, m_MouseCellPosition), EventArgs.Empty);
			}
		}
	}

	public virtual void ChangeMouseDownCell(Position p_MouseDownCell, Position p_MouseCell)
	{
		m_MouseDownPosition = p_MouseDownCell;
		ChangeMouseCell(p_MouseCell);
	}

	protected virtual void OnMouseSelectionFinish(RangeEventArgs e)
	{
		range_0 = Range.Empty;
	}

	protected virtual void OnUndoMouseSelection(RangeEventArgs e)
	{
		Selection.SelectRange(e.Range, select: false);
	}

	protected virtual void OnApplyMouseSelection(RangeEventArgs e)
	{
		Selection.SelectRange(e.Range, select: true);
	}

	protected virtual void OnMouseSelectionChange(EventArgs e)
	{
		Range mouseSelectionRange = MouseSelectionRange;
		OnUndoMouseSelection(new RangeEventArgs(range_0));
		OnApplyMouseSelection(new RangeEventArgs(mouseSelectionRange));
		range_0 = mouseSelectionRange;
	}

	public void MouseSelectionFinish()
	{
		if (range_1 != Range.Empty)
		{
			OnMouseSelectionFinish(new RangeEventArgs(range_0));
		}
		range_1 = Range.Empty;
	}

	public virtual void ChangeMouseSelectionCorner(Position p_Corner)
	{
		Range range = new Range(Selection.ActivePosition, p_Corner);
		bool flag = false;
		if (range_1 != range)
		{
			range_1 = range;
			flag = true;
		}
		if (flag)
		{
			OnMouseSelectionChange(EventArgs.Empty);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData == (Keys.ShiftKey | Keys.Shift))
		{
			position_1 = Selection.ActivePosition;
		}
		if ((keyData != Keys.Return && keyData != Keys.Escape && keyData != Keys.Tab && keyData != (Keys.Tab | Keys.Shift)) || !OverrideCommonCmdKey)
		{
			return base.ProcessCmdKey(ref msg, keyData);
		}
		KeyEventArgs e = new KeyEventArgs(keyData);
		OnKeyDown(e);
		if (!e.Handled)
		{
			return base.ProcessCmdKey(ref msg, keyData);
		}
		return true;
	}

	public virtual void ProcessSpecialGridKey(KeyEventArgs e)
	{
		if (e.Handled)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if ((SpecialKeys & GridSpecialKeys.Arrows) == GridSpecialKeys.Arrows)
		{
			flag3 = true;
		}
		if ((SpecialKeys & GridSpecialKeys.PageDownUp) == GridSpecialKeys.PageDownUp)
		{
			flag = true;
		}
		if ((SpecialKeys & GridSpecialKeys.Tab) == GridSpecialKeys.Tab)
		{
			flag2 = true;
		}
		bool flag4 = false;
		if ((SpecialKeys & GridSpecialKeys.Escape) == GridSpecialKeys.Escape)
		{
			flag4 = true;
		}
		bool flag5 = false;
		if ((SpecialKeys & GridSpecialKeys.Enter) == GridSpecialKeys.Enter)
		{
			flag5 = true;
		}
		if (e.KeyCode == Keys.Escape && flag4)
		{
			CellContext cellContext = new CellContext(this, Selection.ActivePosition);
			if (cellContext.Cell != null && cellContext.IsEditing() && cellContext.EndEdit(cancel: true))
			{
				e.Handled = true;
			}
		}
		if (e.KeyCode == Keys.Return && flag5)
		{
			CellContext cellContext2 = new CellContext(this, Selection.ActivePosition);
			if (cellContext2.Cell != null && cellContext2.IsEditing())
			{
				cellContext2.EndEdit(cancel: false);
				e.Handled = true;
			}
		}
		if (e.KeyCode == Keys.Tab && flag2)
		{
			CellContext cellContext3 = new CellContext(this, Selection.ActivePosition);
			if (cellContext3.Cell != null && cellContext3.IsEditing() && !cellContext3.EndEdit(cancel: false))
			{
				e.Handled = true;
				return;
			}
		}
		bool flag6;
		bool resetSelection = !(flag6 = e.Modifiers == Keys.Shift);
		if (!(e.KeyCode == Keys.Down && flag3))
		{
			if (!(e.KeyCode == Keys.Up && flag3))
			{
				if (!(e.KeyCode == Keys.Right && flag3))
				{
					if (!(e.KeyCode == Keys.Left && flag3))
					{
						if (!(e.KeyCode == Keys.Tab && flag2))
						{
							if ((e.KeyCode == Keys.Prior || e.KeyCode == Keys.Next) && flag)
							{
								if (e.KeyCode != Keys.Next)
								{
									if (e.KeyCode == Keys.Prior)
									{
										CustomScrollPageUp();
									}
								}
								else
								{
									CustomScrollPageDown();
								}
								e.Handled = true;
							}
						}
						else if (e.Modifiers != Keys.Shift)
						{
							if (!Selection.MoveActiveCell(0, 1, 1, int.MinValue))
							{
								FindForm().SelectNextControl(this, forward: true, tabStopOnly: true, nested: true, wrap: true);
							}
							e.Handled = true;
						}
						else
						{
							if (!Selection.MoveActiveCell(0, -1, -1, int.MaxValue))
							{
								FindForm().SelectNextControl(this, forward: false, tabStopOnly: true, nested: true, wrap: true);
							}
							e.Handled = true;
						}
					}
					else
					{
						Selection.MoveActiveCell(0, -1, resetSelection);
						e.Handled = true;
					}
				}
				else
				{
					Selection.MoveActiveCell(0, 1, resetSelection);
					e.Handled = true;
				}
			}
			else
			{
				Selection.MoveActiveCell(-1, 0, resetSelection);
				e.Handled = true;
			}
		}
		else
		{
			Selection.MoveActiveCell(1, 0, resetSelection);
			e.Handled = true;
		}
		if (flag6)
		{
			Selection.ResetSelection(mantainFocus: true);
			Selection.SelectRange(new Range(position_1, Selection.ActivePosition), select: true);
		}
		RangeRegion selRegion = ((!ClipboardUseOnlyActivePosition) ? Selection.GetSelectionRegion() : new RangeRegion(Selection.ActivePosition));
		if (!e.Control || e.KeyCode != Keys.V)
		{
			if (!e.Control || e.KeyCode != Keys.C)
			{
				if (!e.Control || e.KeyCode != Keys.X)
				{
					if (e.KeyCode == Keys.Delete)
					{
						PerformDelete(selRegion);
						e.Handled = true;
					}
				}
				else
				{
					PerformCut(selRegion);
					e.Handled = true;
				}
			}
			else
			{
				PerformCopy(selRegion);
				e.Handled = true;
			}
		}
		else
		{
			PerformPaste(selRegion);
			e.Handled = true;
		}
	}

	public void PerformCut(RangeRegion selRegion)
	{
		if ((ClipboardMode & ClipboardMode.Cut) == ClipboardMode.Cut && !selRegion.IsEmpty())
		{
			Range sourceRange = selRegion[0];
			RangeData rangeData = RangeData.LoadData(this, sourceRange, CutMode.CutImmediately);
			RangeData.ClipboardSetData(rangeData);
		}
	}

	public void PerformPaste(RangeRegion selRegion)
	{
		if ((ClipboardMode & ClipboardMode.Paste) == ClipboardMode.Paste && !selRegion.IsEmpty())
		{
			RangeData rangeData = RangeData.ClipboardGetData();
			if (rangeData != null)
			{
				Range range = selRegion[0];
				Range sourceRange = rangeData.SourceRange;
				Range range2 = new Range(new Position(range.Start.Row, range.Start.Column), new Position(range.Start.Row + (sourceRange.End.Row - sourceRange.Start.Row), range.Start.Column + (sourceRange.End.Column - sourceRange.Start.Column)));
				rangeData.WriteData(this, range.Start);
				Selection.ResetSelection(mantainFocus: true);
				Selection.SelectRange(range2, select: true);
			}
		}
	}

	public void PerformCopy(RangeRegion selRegion)
	{
		if ((ClipboardMode & ClipboardMode.Copy) == ClipboardMode.Copy && !selRegion.IsEmpty())
		{
			Range sourceRange = selRegion[0];
			RangeData rangeData = RangeData.LoadData(this, sourceRange, CutMode.None);
			RangeData.ClipboardSetData(rangeData);
		}
	}

	public void PerformDelete(RangeRegion selRegion)
	{
		if ((ClipboardMode & ClipboardMode.Delete) == ClipboardMode.Delete && !selRegion.IsEmpty())
		{
			ClearValues(selRegion);
		}
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if (OverrideCommonCmdKey)
		{
			if ((SpecialKeys & GridSpecialKeys.Arrows) == GridSpecialKeys.Arrows)
			{
				if ((uint)(keyData - 37) <= 3u || (uint)(keyData - 65573) <= 3u)
				{
					return true;
				}
			}
			if ((SpecialKeys & GridSpecialKeys.Tab) == GridSpecialKeys.Tab)
			{
				if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift))
				{
					return true;
				}
			}
		}
		return base.IsInputKey(keyData);
	}

	protected override bool IsInputChar(char charCode)
	{
		return AcceptsInputChar;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using GraphicsCache graphicsCache = new GraphicsCache(e.Graphics, e.ClipRectangle);
		foreach (Range item in method_0())
		{
			OnRangePaint(new RangePaintEventArgs(this, graphicsCache, item));
		}
	}

	protected virtual void OnRangePaint(RangePaintEventArgs e)
	{
		Rectangle clip = RangeToRectangle(e.DrawingRange);
		GraphicsState gstate = e.GraphicsCache.Graphics.Save();
		try
		{
			e.GraphicsCache.Graphics.SetClip(clip);
			int num = clip.Top;
			foreach (int item in rowsBase_0.HiddenRowsCoordinator.LoopVisibleRows(e.DrawingRange.Start.Row, e.DrawingRange.End.Row - e.DrawingRange.Start.Row))
			{
				if (Rows.IsRowVisible(item))
				{
					int num2 = Rows.GetHeight(item);
					int num3 = clip.Left;
					for (int i = e.DrawingRange.Start.Column; i <= e.DrawingRange.End.Column; i++)
					{
						int num4 = Columns.GetWidth(i);
						if (!Columns.IsColumnVisible(i))
						{
							continue;
						}
						Position position = new Position(item, i);
						ICellVirtual cell = GetCell(position);
						if (cell != null)
						{
							Rectangle rectangle = new Rectangle(num3, num, num4, num2);
							if (e.GraphicsCache.ClipRectangle.IsEmpty || e.GraphicsCache.ClipRectangle.IntersectsWith(rectangle))
							{
								PaintCell(cellContext: new CellContext(this, position, cell), graphics: e.GraphicsCache, drawRectangle: rectangle);
							}
						}
						num3 += num4;
					}
					num += num2;
					continue;
				}
				throw new SourceGridException("Incorrect internal state. This rows must have been visible");
			}
			foreach (DecoratorBase decorator in Decorators)
			{
				if (decorator.IntersectWith(e.DrawingRange))
				{
					decorator.Draw(e);
				}
			}
			if (rangePaintEventHandler_0 != null)
			{
				rangePaintEventHandler_0(this, e);
			}
		}
		finally
		{
			e.GraphicsCache.Graphics.Restore(gstate);
		}
	}

	protected virtual void PaintCell(GraphicsCache graphics, CellContext cellContext, RectangleF drawRectangle)
	{
		if (!(drawRectangle.Width <= 0f) && drawRectangle.Height > 0f && cellContext.CanBeDrawn())
		{
			cellContext.Cell.View.DrawCell(cellContext, graphics, drawRectangle);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		Position position = PositionAtPoint(new Point(e.X, e.Y));
		ICellVirtual cell = GetCell(position);
		if (MouseDownPosition.IsEmpty())
		{
			ChangeMouseCell(position);
			if (!position.IsEmpty() && cell != null)
			{
				Controller.OnMouseMove(new CellContext(this, position, cell), e);
			}
		}
		else
		{
			ICellVirtual cell2 = GetCell(MouseDownPosition);
			if (cell2 != null)
			{
				Controller.OnMouseMove(new CellContext(this, MouseDownPosition, cell2), e);
			}
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		ChangeMouseCell(Position.Empty);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (!Selection.ActivePosition.IsEmpty())
		{
			CellContext cellContext = new CellContext(this, Selection.ActivePosition);
			if (cellContext.Cell != null && cellContext.IsEditing() && !cellContext.EndEdit(cancel: false))
			{
				return;
			}
		}
		Position position = PositionAtPoint(new Point(e.X, e.Y));
		if (position.IsEmpty())
		{
			ChangeMouseDownCell(Position.Empty, Position.Empty);
			return;
		}
		ICellVirtual cell = GetCell(position);
		if (cell != null)
		{
			ChangeMouseDownCell(position, position);
			CellContext sender = new CellContext(this, position, cell);
			Controller.OnMouseDown(sender, e);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (!MouseDownPosition.IsEmpty())
		{
			ICellVirtual cell = GetCell(MouseDownPosition);
			if (cell != null)
			{
				Controller.OnMouseUp(new CellContext(this, MouseDownPosition, cell), e);
			}
			ChangeMouseDownCell(Position.Empty, PositionAtPoint(new Point(e.X, e.Y)));
		}
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		base.OnMouseClick(e);
		Position position = PositionAtPoint(PointToClient(Control.MousePosition));
		if (!MouseDownPosition.IsEmpty() && MouseDownPosition == position)
		{
			ICellVirtual cell = GetCell(MouseDownPosition);
			if (cell != null)
			{
				Controller.OnClick(new CellContext(this, MouseDownPosition, cell), e);
			}
		}
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		base.OnDoubleClick(e);
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		Position position = PositionAtPoint(PointToClient(Control.MousePosition));
		Class76.smethod_304(position, this, (EventArgs)e);
		base.OnMouseDoubleClick(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		CustomScrollWheel(e.Delta);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		position_2 = Selection.ActivePosition;
		if (!position_2.IsEmpty())
		{
			ICellVirtual cell = GetCell(position_2);
			if (cell != null)
			{
				Controller.OnKeyDown(new CellContext(this, position_2, cell), e);
			}
		}
		if (!e.Handled)
		{
			ProcessSpecialGridKey(e);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (!position_2.IsEmpty())
		{
			ICellVirtual cell = GetCell(position_2);
			if (cell != null)
			{
				Controller.OnKeyUp(new CellContext(this, position_2, cell), e);
			}
		}
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
		if (!position_2.IsEmpty() && e.KeyChar != '\t' && e.KeyChar != '\r' && e.KeyChar != '\u0003' && e.KeyChar != '\u0016' && e.KeyChar != '\u0018')
		{
			ICellVirtual cell = GetCell(position_2);
			if (cell != null)
			{
				Controller.OnKeyPress(new CellContext(this, position_2, cell), e);
			}
		}
	}

	public virtual bool Focus(bool selectFirstCell)
	{
		try
		{
			bool_4 = selectFirstCell;
			return Focus();
		}
		finally
		{
			bool_4 = true;
		}
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
		if ((Selection.FocusStyle & FocusStyle.FocusFirstCellOnEnter) == FocusStyle.FocusFirstCellOnEnter && bool_4 && Selection.ActivePosition.IsEmpty())
		{
			Selection.FocusFirstCell(pResetSelection: false);
		}
	}

	protected override void OnValidated(EventArgs e)
	{
		base.OnValidated(e);
		if ((Selection.FocusStyle & FocusStyle.RemoveFocusCellOnLeave) == FocusStyle.RemoveFocusCellOnLeave)
		{
			Selection.Focus(Position.Empty, pResetSelection: false);
		}
		if ((Selection.FocusStyle & FocusStyle.RemoveSelectionOnLeave) == FocusStyle.RemoveSelectionOnLeave)
		{
			Selection.ResetSelection(mantainFocus: true);
		}
	}

	protected override void OnHScrollPositionChanged(ScrollPositionChangedEventArgs e)
	{
		base.OnHScrollPositionChanged(e);
		ArrangeLinkedControls();
	}

	protected override void OnVScrollPositionChanged(ScrollPositionChangedEventArgs e)
	{
		base.OnVScrollPositionChanged(e);
		ArrangeLinkedControls();
	}

	public virtual void ArrangeLinkedControls()
	{
		SuspendLayout();
		foreach (LinkedControlValue item in linkedControlsList_0)
		{
			if (!item.Position.IsEmpty())
			{
				Control control = item.Control;
				ICellVirtual cell = GetCell(item.Position);
				Rectangle rectangle = PositionToRectangle(item.Position);
				if (cell != null && item.UseCellBorder)
				{
					rectangle = Rectangle.Round(cell.View.Border.GetContentRectangle(rectangle));
				}
				control.Bounds = rectangle;
				if (item.Position.Row >= FixedRows && item.Position.Column >= FixedColumns)
				{
					Range range = RangeAtArea(CellPositionType.Scrollable);
					Rectangle b = RangeToRectangle(range);
					control.Visible = !Rectangle.Intersect(rectangle, b).IsEmpty;
				}
			}
		}
		ResumeLayout(performLayout: false);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		SuspendLayout();
		Class76.smethod_698(this);
		Class76.smethod_57(this);
		ResumeLayout(performLayout: true);
	}

	public virtual void OnCellsAreaChanged()
	{
		SuspendLayout();
		Class76.smethod_698(this);
		CheckPositions();
		ArrangeLinkedControls();
		ResumeLayout(performLayout: true);
	}

	public void SortRangeRows(IRangeLoader p_RangeToSort, int keyColumn, bool p_bAsc, IComparer p_CellComparer)
	{
		Range range = p_RangeToSort.GetRange(this);
		SortRangeRows(range, keyColumn, p_bAsc, p_CellComparer);
	}

	public void SortRangeRows(Range p_Range, int keyColumn, bool p_bAscending, IComparer p_CellComparer)
	{
		SortRangeRowsEventArgs e = new SortRangeRowsEventArgs(p_Range, keyColumn, p_bAscending, p_CellComparer);
		if (sortRangeRowsEventHandler_0 != null)
		{
			sortRangeRowsEventHandler_0(this, e);
		}
		OnSortingRangeRows(e);
		if (sortRangeRowsEventHandler_1 != null)
		{
			sortRangeRowsEventHandler_1(this, e);
		}
		OnSortedRangeRows(e);
	}

	protected virtual void OnSortingRangeRows(SortRangeRowsEventArgs e)
	{
	}

	protected virtual void OnSortedRangeRows(SortRangeRowsEventArgs e)
	{
	}

	public abstract ICellVirtual GetCell(int p_iRow, int p_iCol);

	public ICellVirtual GetCell(Position p_Position)
	{
		if (!p_Position.IsEmpty())
		{
			return GetCell(p_Position.Row, p_Position.Column);
		}
		return null;
	}

	public virtual ICellVirtual[] GetCellsAtRow(int p_RowIndex)
	{
		ICellVirtual[] array = new ICellVirtual[Columns.Count];
		for (int i = 0; i < Columns.Count; i++)
		{
			array[i] = GetCell(p_RowIndex, i);
		}
		return array;
	}

	public virtual ICellVirtual[] GetCellsAtColumn(int p_ColumnIndex)
	{
		ICellVirtual[] array = new ICellVirtual[Rows.Count];
		for (int i = 0; i < Rows.Count; i++)
		{
			array[i] = GetCell(i, p_ColumnIndex);
		}
		return array;
	}

	public CellPositionType GetPositionType(Position position)
	{
		if (!position.IsEmpty())
		{
			if (position.Row >= FixedRows || position.Column >= FixedColumns)
			{
				if (position.Row >= FixedRows)
				{
					if (position.Column >= FixedColumns)
					{
						return CellPositionType.Scrollable;
					}
					return CellPositionType.FixedLeft;
				}
				return CellPositionType.FixedTop;
			}
			return CellPositionType.FixedTopLeft;
		}
		return CellPositionType.Empty;
	}

	public virtual void OnUserException(ExceptionEventArgs e)
	{
		Debug.WriteLine("Exception on editing cell: " + e.Exception.ToString());
		if (exceptionEventHandler_0 != null)
		{
			exceptionEventHandler_0(this, e);
		}
		if (!e.Handled)
		{
			ErrorDialog.Show(this, e.Exception, "Error");
			e.Handled = true;
		}
	}

	public virtual void ClearValues(RangeRegion region)
	{
		PositionCollection cellsPositions = region.GetCellsPositions();
		foreach (Position item in cellsPositions)
		{
			CellContext cellContext = new CellContext(this, item);
			if (cellContext.Cell != null && cellContext.Cell.Editor != null)
			{
				cellContext.Cell.Editor.ClearCell(cellContext);
			}
		}
	}

	public override void CustomScrollPageDown()
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		Range range = PositionToCellRange(Selection.ActivePosition);
		if (!range.IsEmpty())
		{
			List<int> visibleRows = GetVisibleRows(returnsPartial: false);
			if (visibleRows.Count > ActualFixedRows + 1)
			{
				int num3 = visibleRows[ActualFixedRows];
				int num4 = visibleRows[visibleRows.Count - 1];
				if (!Class76.smethod_308(this, range.Start.Row))
				{
					flag = true;
					num = range.Start.Row;
					int num5 = Class76.smethod_448(num, this);
					num2 = Class76.smethod_131(num, num5, this);
				}
				else
				{
					int num6 = Class76.smethod_131(num3, num4, this);
					if (!range.ContainsRow(num6))
					{
						Position pCellToActivate = new Position(num6, Selection.ActivePosition.Column);
						Selection.Focus(pCellToActivate, pResetSelection: true);
					}
					else
					{
						int num7 = Class76.smethod_23(this, num4);
						if (num7 == -1)
						{
							Selection.MoveActiveCell(1, 0);
							return;
						}
						flag = true;
						num = num4;
						int num8 = Class76.smethod_448(num, this);
						num2 = Class76.smethod_131(num, num8, this);
						if (num2 == -1)
						{
							num2 = Class76.smethod_23(this, num8);
							num = Class76.smethod_798(this, num2);
						}
					}
				}
				if (flag)
				{
					int num9 = 0;
					int num10 = 0;
					Class76.smethod_291(num, num2, this, out num10, ref num9);
					num9 = Class76.smethod_214(this, num9);
					base.CustomScrollPageToLine(num9 - ActualFixedRows);
					if (!range.ContainsRow(num10))
					{
						Position pCellToActivate2 = new Position(num10, Selection.ActivePosition.Column);
						Selection.Focus(pCellToActivate2, pResetSelection: true);
					}
				}
			}
			else
			{
				Selection.MoveActiveCell(1, 0);
			}
		}
		else
		{
			Selection.MoveActiveCell(1, 0);
		}
	}

	public override void CustomScrollPageUp()
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int row = Selection.ActivePosition.Row;
		if (row != -1)
		{
			List<int> visibleRows = GetVisibleRows(returnsPartial: false);
			if (visibleRows.Count > ActualFixedRows + 1)
			{
				int num3 = visibleRows[ActualFixedRows];
				int num4 = visibleRows[visibleRows.Count - 1];
				if (row == num3 && row > ActualFixedRows)
				{
					int num5 = base.DisplayRectangle.Height;
					for (int i = 0; i < ActualFixedRows; i++)
					{
						num5 -= Rows.GetHeight(i);
					}
					if (num5 <= Rows.GetHeight(row - 1))
					{
						Selection.MoveActiveCell(-1, 0);
						return;
					}
				}
				if (!Class76.smethod_308(this, row))
				{
					flag = true;
					int num6 = row;
					num = Class76.smethod_798(this, num6);
					num2 = Class76.smethod_485(num6, this, num);
				}
				else
				{
					int num7 = Class76.smethod_485(num4, this, num3);
					if (num7 != row)
					{
						Position pCellToActivate = new Position(num7, Selection.ActivePosition.Column);
						Selection.Focus(pCellToActivate, pResetSelection: true);
					}
					else
					{
						int num8 = Class76.smethod_545(num3, this);
						if (num8 == -1)
						{
							Selection.MoveActiveCell(-1, 0);
							return;
						}
						flag = true;
						int num9 = num3;
						num = Class76.smethod_798(this, num9);
						num2 = Class76.smethod_485(num9, this, num);
						if (num2 == -1)
						{
							num2 = Class76.smethod_545(num, this);
							num = num2;
						}
					}
				}
				if (flag)
				{
					int num10 = 0;
					int num11 = 0;
					Class76.smethod_830(num2, num, out num11, out num10, this);
					num10 = Class76.smethod_214(this, num10);
					base.CustomScrollPageToLine(num10 - ActualFixedRows);
					if (num11 != row)
					{
						Position pCellToActivate2 = new Position(num11, Selection.ActivePosition.Column);
						Selection.Focus(pCellToActivate2, pResetSelection: true);
					}
				}
			}
			else
			{
				Selection.MoveActiveCell(-1, 0);
			}
		}
		else
		{
			Selection.MoveActiveCell(-1, 0);
		}
	}
}

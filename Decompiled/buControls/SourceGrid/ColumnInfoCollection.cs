using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SourceGrid;

public class ColumnInfoCollection(GridVirtual grid) : ColumnsBase(grid), IEnumerable
{
	private List<ColumnInfo> list_0 = new List<ColumnInfo>();

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_0;

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_1;

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_2;

	[CompilerGenerated]
	private ColumnInfoEventHandler columnInfoEventHandler_0;

	public ColumnInfo this[int p]
	{
		get
		{
			if (p >= 0)
			{
				if (p < list_0.Count)
				{
					return list_0[p];
				}
				return null;
			}
			return null;
		}
	}

	public override int Count => list_0.Count;

	public event IndexRangeEventHandler ColumnsAdded
	{
		[CompilerGenerated]
		add
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_0;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Combine(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_0, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_0;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Remove(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_0, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
	}

	public event IndexRangeEventHandler ColumnsRemoved
	{
		[CompilerGenerated]
		add
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_1;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Combine(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_1, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_1;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Remove(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_1, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
	}

	public event IndexRangeEventHandler ColumnsRemoving
	{
		[CompilerGenerated]
		add
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_2;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Combine(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_2, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IndexRangeEventHandler indexRangeEventHandler = indexRangeEventHandler_2;
			IndexRangeEventHandler indexRangeEventHandler2;
			do
			{
				indexRangeEventHandler2 = indexRangeEventHandler;
				IndexRangeEventHandler value2 = (IndexRangeEventHandler)Delegate.Remove(indexRangeEventHandler2, value);
				indexRangeEventHandler = Interlocked.CompareExchange(ref indexRangeEventHandler_2, value2, indexRangeEventHandler2);
			}
			while ((object)indexRangeEventHandler != indexRangeEventHandler2);
		}
	}

	public event ColumnInfoEventHandler ColumnWidthChanged
	{
		[CompilerGenerated]
		add
		{
			ColumnInfoEventHandler columnInfoEventHandler = columnInfoEventHandler_0;
			ColumnInfoEventHandler columnInfoEventHandler2;
			do
			{
				columnInfoEventHandler2 = columnInfoEventHandler;
				ColumnInfoEventHandler value2 = (ColumnInfoEventHandler)Delegate.Combine(columnInfoEventHandler2, value);
				columnInfoEventHandler = Interlocked.CompareExchange(ref columnInfoEventHandler_0, value2, columnInfoEventHandler2);
			}
			while ((object)columnInfoEventHandler != columnInfoEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ColumnInfoEventHandler columnInfoEventHandler = columnInfoEventHandler_0;
			ColumnInfoEventHandler columnInfoEventHandler2;
			do
			{
				columnInfoEventHandler2 = columnInfoEventHandler;
				ColumnInfoEventHandler value2 = (ColumnInfoEventHandler)Delegate.Remove(columnInfoEventHandler2, value);
				columnInfoEventHandler = Interlocked.CompareExchange(ref columnInfoEventHandler_0, value2, columnInfoEventHandler2);
			}
			while ((object)columnInfoEventHandler != columnInfoEventHandler2);
		}
	}

	public bool IsValidRange(int p_StartIndex, int p_Count)
	{
		if (p_StartIndex >= Count || p_StartIndex < 0 || p_Count <= 0 || p_StartIndex + p_Count > Count)
		{
			return false;
		}
		return true;
	}

	public bool IsValidRangeForInsert(int p_StartIndex, int p_Count)
	{
		if (p_StartIndex > Count || p_StartIndex < 0 || p_Count <= 0)
		{
			return false;
		}
		return true;
	}

	public void Add(ColumnInfo column)
	{
		Insert(Count, column);
	}

	public void Insert(int index, ColumnInfo dataGridColumn)
	{
		InsertRange(index, dataGridColumn);
	}

	public void InsertRange(int p_StartIndex, params ColumnInfo[] columns)
	{
		if (IsValidRangeForInsert(p_StartIndex, columns.Length))
		{
			for (int i = 0; i < columns.Length; i++)
			{
				list_0.Insert(p_StartIndex + i, columns[i]);
			}
			PerformLayout();
			OnColumnsAdded(new IndexRangeEventArgs(p_StartIndex, columns.Length));
			return;
		}
		throw new SourceGridException("Invalid index");
	}

	public void Remove(int p_Index)
	{
		RemoveRange(p_Index, 1);
	}

	public virtual void RemoveRange(int p_StartIndex, int p_Count)
	{
		if (!IsValidRange(p_StartIndex, p_Count))
		{
			throw new SourceGridException("Invalid index");
		}
		IndexRangeEventArgs e = new IndexRangeEventArgs(p_StartIndex, p_Count);
		OnColumnsRemoving(e);
		list_0.RemoveRange(p_StartIndex, p_Count);
		OnColumnsRemoved(e);
		PerformLayout();
	}

	public void Move(int p_CurrentColumnPosition, int p_NewColumnPosition)
	{
		if (p_CurrentColumnPosition == p_NewColumnPosition)
		{
			return;
		}
		if (p_CurrentColumnPosition >= p_NewColumnPosition)
		{
			for (int num = p_CurrentColumnPosition; num > p_NewColumnPosition; num--)
			{
				Swap(num, num - 1);
			}
		}
		else
		{
			for (int i = p_CurrentColumnPosition; i < p_NewColumnPosition; i++)
			{
				Swap(i, i + 1);
			}
		}
	}

	public void Swap(int p_ColumnIndex1, int p_ColumnIndex2)
	{
		if (p_ColumnIndex1 != p_ColumnIndex2)
		{
			ColumnInfo value = this[p_ColumnIndex1];
			ColumnInfo value2 = this[p_ColumnIndex2];
			list_0[p_ColumnIndex1] = value2;
			list_0[p_ColumnIndex2] = value;
			PerformLayout();
		}
	}

	protected virtual void OnColumnsAdded(IndexRangeEventArgs e)
	{
		if (indexRangeEventHandler_0 != null)
		{
			indexRangeEventHandler_0(this, e);
		}
		ColumnsChanged();
	}

	protected virtual void OnColumnsRemoved(IndexRangeEventArgs e)
	{
		if (indexRangeEventHandler_1 != null)
		{
			indexRangeEventHandler_1(this, e);
		}
		ColumnsChanged();
	}

	protected virtual void OnColumnsRemoving(IndexRangeEventArgs e)
	{
		if (indexRangeEventHandler_2 != null)
		{
			indexRangeEventHandler_2(this, e);
		}
	}

	protected override void OnLayout()
	{
		base.OnLayout();
	}

	public void OnColumnWidthChanged(ColumnInfoEventArgs e)
	{
		PerformLayout();
		if (columnInfoEventHandler_0 != null)
		{
			columnInfoEventHandler_0(this, e);
		}
	}

	public int IndexOf(ColumnInfo p_Info)
	{
		return list_0.IndexOf(p_Info);
	}

	public void AutoSizeView()
	{
		List<int> list = base.Grid.Rows.RowsInsideRegion(base.Grid.DisplayRectangle.Y, base.Grid.DisplayRectangle.Height, returnsPartial: true, returnsFixedRows: false);
		if (list.Count > 0)
		{
			AutoSize(useRowHeight: false, list[0], list[list.Count - 1]);
		}
	}

	public void Clear()
	{
		if (Count > 0)
		{
			RemoveRange(0, Count);
		}
	}

	public override int GetWidth(int column)
	{
		return IsColumnVisible(column) ? this[column].Width : 0;
	}

	public override void SetWidth(int column, int width)
	{
		this[column].Width = width;
	}

	public override AutoSizeMode GetAutoSizeMode(int column)
	{
		return this[column].AutoSizeMode;
	}

	public override bool IsColumnVisible(int column)
	{
		return this[column].Visible;
	}

	public override void HideColumn(int column)
	{
		this[column].Visible = false;
	}

	public override void ShowColumn(int column)
	{
		this[column].Visible = true;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}

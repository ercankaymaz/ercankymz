using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SourceGrid;

public abstract class RowInfoCollection : RowsBase, IEnumerable, IEnumerable<RowInfo>
{
	private List<RowInfo> list_0 = new List<RowInfo>();

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_0;

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_1;

	[CompilerGenerated]
	private IndexRangeEventHandler indexRangeEventHandler_2;

	[CompilerGenerated]
	private RowInfoEventHandler rowInfoEventHandler_0;

	public RowInfo this[int p]
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

	public event IndexRangeEventHandler RowsAdded
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

	public event IndexRangeEventHandler RowsRemoved
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

	public event IndexRangeEventHandler RowsRemoving
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

	public event RowInfoEventHandler RowHeightChanged
	{
		[CompilerGenerated]
		add
		{
			RowInfoEventHandler rowInfoEventHandler = rowInfoEventHandler_0;
			RowInfoEventHandler rowInfoEventHandler2;
			do
			{
				rowInfoEventHandler2 = rowInfoEventHandler;
				RowInfoEventHandler value2 = (RowInfoEventHandler)Delegate.Combine(rowInfoEventHandler2, value);
				rowInfoEventHandler = Interlocked.CompareExchange(ref rowInfoEventHandler_0, value2, rowInfoEventHandler2);
			}
			while ((object)rowInfoEventHandler != rowInfoEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RowInfoEventHandler rowInfoEventHandler = rowInfoEventHandler_0;
			RowInfoEventHandler rowInfoEventHandler2;
			do
			{
				rowInfoEventHandler2 = rowInfoEventHandler;
				RowInfoEventHandler value2 = (RowInfoEventHandler)Delegate.Remove(rowInfoEventHandler2, value);
				rowInfoEventHandler = Interlocked.CompareExchange(ref rowInfoEventHandler_0, value2, rowInfoEventHandler2);
			}
			while ((object)rowInfoEventHandler != rowInfoEventHandler2);
		}
	}

	public RowInfoCollection(GridVirtual grid)
		: base(grid)
	{
		m_HiddenRowsCoordinator = new RowInfoCollectoinHiddenRowCoordinator(this);
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

	protected void InsertRange(int p_StartIndex, RowInfo[] rows)
	{
		if (IsValidRangeForInsert(p_StartIndex, rows.Length))
		{
			for (int i = 0; i < rows.Length; i++)
			{
				list_0.Insert(p_StartIndex + i, rows[i]);
			}
			PerformLayout();
			OnRowsAdded(new IndexRangeEventArgs(p_StartIndex, rows.Length));
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
		OnRowsRemoving(e);
		list_0.RemoveRange(p_StartIndex, p_Count);
		OnRowsRemoved(e);
		PerformLayout();
	}

	public void Move(int p_CurrentRowPosition, int p_NewRowPosition)
	{
		if (p_CurrentRowPosition == p_NewRowPosition)
		{
			return;
		}
		if (p_CurrentRowPosition >= p_NewRowPosition)
		{
			for (int num = p_CurrentRowPosition; num > p_NewRowPosition; num--)
			{
				Swap(num, num - 1);
			}
		}
		else
		{
			for (int i = p_CurrentRowPosition; i < p_NewRowPosition; i++)
			{
				Swap(i, i + 1);
			}
		}
	}

	public virtual void Swap(int p_RowIndex1, int p_RowIndex2)
	{
		if (p_RowIndex1 != p_RowIndex2)
		{
			RowInfo value = this[p_RowIndex1];
			RowInfo value2 = this[p_RowIndex2];
			list_0[p_RowIndex1] = value2;
			list_0[p_RowIndex2] = value;
			PerformLayout();
		}
	}

	protected virtual void OnRowsAdded(IndexRangeEventArgs e)
	{
		if (indexRangeEventHandler_0 != null)
		{
			indexRangeEventHandler_0(this, e);
		}
		RowsChanged();
	}

	protected virtual void OnRowsRemoved(IndexRangeEventArgs e)
	{
		if (indexRangeEventHandler_1 != null)
		{
			indexRangeEventHandler_1(this, e);
		}
		RowsChanged();
	}

	protected virtual void OnRowsRemoving(IndexRangeEventArgs e)
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

	public void OnRowHeightChanged(RowInfoEventArgs e)
	{
		PerformLayout();
		if (rowInfoEventHandler_0 != null)
		{
			rowInfoEventHandler_0(this, e);
		}
	}

	public int IndexOf(RowInfo p_Info)
	{
		return list_0.IndexOf(p_Info);
	}

	public void AutoSizeView()
	{
		List<int> list = base.Grid.Columns.ColumnsInsideRegion(base.Grid.DisplayRectangle.X, base.Grid.DisplayRectangle.Width, returnsPartial: true, returnsFixedColumns: false);
		if (list.Count > 0)
		{
			AutoSize(useColumnWidth: false, list[0], list[list.Count - 1]);
		}
	}

	public void Clear()
	{
		if (Count != 0)
		{
			base.Grid.LinkedControls.Clear();
			RemoveRange(0, Count);
		}
	}

	public override int GetHeight(int row)
	{
		return this[row].Height;
	}

	public override void SetHeight(int row, int height)
	{
		this[row].Height = height;
	}

	public override AutoSizeMode GetAutoSizeMode(int row)
	{
		return this[row].AutoSizeMode;
	}

	public IEnumerator<RowInfo> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}

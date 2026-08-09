using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SourceGrid.Selection;
using ns27;

namespace SourceGrid;

public class StandardHiddenRowCoordinator : IHiddenRowCoordinator
{
	[CompilerGenerated]
	private sealed class Class67 : IDisposable, IEnumerable, IEnumerator, IEnumerable<int>, IEnumerator<int>
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		public int int_4;

		private int int_5;

		public int int_6;

		public StandardHiddenRowCoordinator standardHiddenRowCoordinator_0;

		private int int_7;

		private int int_8;

		private int? nullable_0;

		private int? nullable_1;

		int IEnumerator<int>.Current => int_1;

		object IEnumerator.Current => int_1;

		public Class67(int int_9)
		{
			int_0 = int_9;
			int_2 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			int num = int_0;
			if (num == 0)
			{
				int_0 = -1;
				int_7 = 0;
				int_8 = int_3;
				if (!standardHiddenRowCoordinator_0.Rows.IsRowVisible(int_3))
				{
					StandardHiddenRowCoordinator standardHiddenRowCoordinator = standardHiddenRowCoordinator_0;
					int num2 = int_8;
					nullable_0 = Class76.smethod_24(num2, standardHiddenRowCoordinator);
					if (!nullable_0.HasValue)
					{
						return false;
					}
					int_8 = nullable_0.Value;
				}
			}
			else
			{
				if (num != 1)
				{
					return false;
				}
				int_0 = -1;
				int_7++;
				StandardHiddenRowCoordinator standardHiddenRowCoordinator = standardHiddenRowCoordinator_0;
				int num2 = int_8;
				nullable_1 = Class76.smethod_24(num2, standardHiddenRowCoordinator);
				if (!nullable_1.HasValue)
				{
					goto IL_0110;
				}
				int_8 = nullable_1.Value;
			}
			if (int_7 <= int_5)
			{
				int_1 = int_8;
				int_0 = 1;
				return true;
			}
			goto IL_0110;
			IL_0110:
			return false;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			Class67 @class;
			if (int_0 != -2 || int_2 != Environment.CurrentManagedThreadId)
			{
				@class = new Class67(0)
				{
					standardHiddenRowCoordinator_0 = standardHiddenRowCoordinator_0
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.int_3 = int_4;
			@class.int_5 = int_6;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	protected RowsBase m_rows = null;

	protected int m_totalHiddenRows = 0;

	protected RangeMergerByRows m_rowMerger = new RangeMergerByRows();

	public RowsBase Rows => m_rows;

	public int GetTotalHiddenRows()
	{
		return m_totalHiddenRows;
	}

	public StandardHiddenRowCoordinator(RowsBase rows)
	{
		m_rows = rows;
		rows.RowVisibilityChanged += delegate(int int_0, bool bool_0)
		{
			Range range = new Range(int_0, 0, int_0, 1);
			if (!bool_0)
			{
				m_rowMerger.AddRange(range);
			}
			else
			{
				m_rowMerger.RemoveRange(range);
			}
		};
		rows.RowVisibilityChanged += delegate(int int_0, bool bool_0)
		{
			if (!bool_0)
			{
				m_totalHiddenRows++;
			}
			else
			{
				m_totalHiddenRows--;
			}
			if (m_totalHiddenRows < 0)
			{
				throw new SourceGridException("Total hidden rows becamse less than 0. This indicates a bug");
			}
		};
	}

	public int ConvertScrollbarValueToRowIndex(int scrollBarValue)
	{
		int num = 0;
		int num2 = 0;
		foreach (Range item in m_rowMerger.LoopAllRanges())
		{
			int num3 = item.End.Row - num + 1;
			int num4 = item.Start.Row - num;
			if (num2 <= scrollBarValue)
			{
				if (num2 + num4 > scrollBarValue)
				{
					num3 = num4 - (num2 + num4 - scrollBarValue);
				}
				num += num3;
				num2 += num4;
				continue;
			}
			break;
		}
		if (num2 < scrollBarValue)
		{
			num += scrollBarValue - num2;
		}
		return num;
	}

	[IteratorStateMachine(typeof(Class67))]
	public IEnumerable<int> LoopVisibleRows(int scrollBarValue, int numberOfRowsToProduce)
	{
		//yield-return decompiler failed: Method not found
		return new Class67(-2)
		{
			standardHiddenRowCoordinator_0 = this,
			int_4 = scrollBarValue,
			int_6 = numberOfRowsToProduce
		};
	}

	[CompilerGenerated]
	private void method_0(int int_0, bool bool_0)
	{
		Range range = new Range(int_0, 0, int_0, 1);
		if (!bool_0)
		{
			m_rowMerger.AddRange(range);
		}
		else
		{
			m_rowMerger.RemoveRange(range);
		}
	}

	[CompilerGenerated]
	private void method_1(int int_0, bool bool_0)
	{
		if (!bool_0)
		{
			m_totalHiddenRows++;
		}
		else
		{
			m_totalHiddenRows--;
		}
		if (m_totalHiddenRows < 0)
		{
			throw new SourceGridException("Total hidden rows becamse less than 0. This indicates a bug");
		}
	}
}

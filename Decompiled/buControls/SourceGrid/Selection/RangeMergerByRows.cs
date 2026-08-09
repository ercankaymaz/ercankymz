using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns27;

namespace SourceGrid.Selection;

public class RangeMergerByRows
{
	[CompilerGenerated]
	internal sealed class Class68 : IDisposable, IEnumerable, IEnumerator, IEnumerable<Range>, IEnumerator<Range>
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		public RangeMergerByRows rangeMergerByRows_0;

		internal List<Range>.Enumerator enumerator_0;

		private Range range_1;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class68(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_76(this);
				}
			}
			enumerator_0 = default(List<Range>.Enumerator);
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					enumerator_0 = rangeMergerByRows_0.list_0.GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
				}
				if (enumerator_0.MoveNext())
				{
					range_1 = enumerator_0.Current;
					range_0 = range_1;
					int_0 = 1;
					return true;
				}
				Class76.smethod_76(this);
				enumerator_0 = default(List<Range>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class68 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class68(0)
				{
					rangeMergerByRows_0 = rangeMergerByRows_0
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

	internal List<Range> list_0 = new List<Range>();

	internal int int_0 = 0;

	internal int int_1 = 0;

	[IteratorStateMachine(typeof(Class68))]
	public IEnumerable<Range> LoopAllRanges()
	{
		//yield-return decompiler failed: Method not found
		return new Class68(-2)
		{
			rangeMergerByRows_0 = this
		};
	}

	public List<Range> GetSelectedRowRegions(int startColumn, int endColumn)
	{
		if (startColumn <= endColumn)
		{
			List<Range> list = new List<Range>();
			foreach (Range item in list_0)
			{
				list.Add(new Range(item.Start.Row, startColumn, item.End.Row, endColumn));
			}
			return list;
		}
		throw new ArgumentException("end column can not be less than startColumn");
	}

	public RangeMergerByRows AddRange(Range rangeToAdd)
	{
		rangeToAdd = Class76.smethod_738(this, rangeToAdd);
		Class76.smethod_385(this, rangeToAdd);
		Class76.smethod_174(this);
		return this;
	}

	public RangeMergerByRows RemoveRange(Range rangeToRemove)
	{
		while (Class76.smethod_394(this, rangeToRemove))
		{
		}
		return this;
	}

	public IList<int> GetRowsIndex()
	{
		IList<int> list = new List<int>();
		foreach (Range item in list_0)
		{
			for (int i = item.Start.Row; i <= item.End.Row; i++)
			{
				list.Add(i);
			}
		}
		return list;
	}

	public bool IsEmpty()
	{
		return list_0.Count == 0;
	}

	public bool IsSelectedRow(int rowIndex)
	{
		Position p_Position = new Position(rowIndex, 0);
		foreach (Range item in list_0)
		{
			if (item.Contains(p_Position))
			{
				return true;
			}
		}
		return false;
	}

	public RangeMergerByRows Clear()
	{
		list_0.Clear();
		return this;
	}
}

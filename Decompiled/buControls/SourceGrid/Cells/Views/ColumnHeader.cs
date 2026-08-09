using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid.Cells.Models;
using ns27;

namespace SourceGrid.Cells.Views;

[Serializable]
public class ColumnHeader : Header
{
	[CompilerGenerated]
	internal sealed class Class71 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		internal int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public ColumnHeader columnHeader_0;

		internal IEnumerator<IVisualElement> ienumerator_0;

		private IVisualElement ivisualElement_1;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class71(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_157(this);
				}
			}
			ienumerator_0 = null;
			ivisualElement_1 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 2:
					int_0 = -3;
					ivisualElement_1 = null;
					goto IL_002a;
				default:
					return false;
				case 0:
					int_0 = -1;
					if (columnHeader_0.ElementSort != null)
					{
						ivisualElement_0 = columnHeader_0.ElementSort;
						int_0 = 1;
						return true;
					}
					goto IL_007d;
				case 1:
					{
						int_0 = -1;
						goto IL_007d;
					}
					IL_007d:
					ienumerator_0 = columnHeader_0.method_0().GetEnumerator();
					int_0 = -3;
					goto IL_002a;
					IL_002a:
					if (ienumerator_0.MoveNext())
					{
						ivisualElement_1 = ienumerator_0.Current;
						ivisualElement_0 = ivisualElement_1;
						int_0 = 2;
						return true;
					}
					Class76.smethod_157(this);
					ienumerator_0 = null;
					return false;
				}
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

		IEnumerator<IVisualElement> IEnumerable<IVisualElement>.GetEnumerator()
		{
			Class71 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class71(0)
				{
					columnHeader_0 = columnHeader_0
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
			return ((IEnumerable<IVisualElement>)this).GetEnumerator();
		}
	}

	public new static readonly ColumnHeader Default;

	private ISortIndicator mElementSort = new SortIndicator();

	public new IColumnHeader Background
	{
		get
		{
			return (IColumnHeader)base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	public ISortIndicator ElementSort
	{
		get
		{
			return mElementSort;
		}
		set
		{
			mElementSort = value;
		}
	}

	static ColumnHeader()
	{
		Default = new ColumnHeader();
	}

	public ColumnHeader()
	{
		Background = new ColumnHeaderThemed();
	}

	public ColumnHeader(ColumnHeader p_Source)
		: base(p_Source)
	{
	}

	public override object Clone()
	{
		return new ColumnHeader(this);
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		PrepareVisualElementSortIndicator(context);
	}

	[IteratorStateMachine(typeof(Class71))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class71(-2)
		{
			columnHeader_0 = this
		};
	}

	private IEnumerable<IVisualElement> method_0()
	{
		return base.GetElements();
	}

	protected virtual void PrepareVisualElementSortIndicator(CellContext context)
	{
		ISortableHeader sortableHeader = (ISortableHeader)context.Cell.Model.FindModel(typeof(ISortableHeader));
		if (sortableHeader == null)
		{
			ElementSort.SortStyle = HeaderSortStyle.None;
			return;
		}
		SortStatus sortStatus = sortableHeader.GetSortStatus(context);
		ElementSort.SortStyle = sortStatus.Style;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns27;

namespace SourceGrid.Cells.Views;

public class ComboBox : Cell
{
	[CompilerGenerated]
	internal sealed class Class72 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		internal int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public ComboBox comboBox_0;

		internal IEnumerator<IVisualElement> ienumerator_0;

		private IVisualElement ivisualElement_1;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class72(int int_2)
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
					Class76.smethod_139(this);
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
					if (comboBox_0.ElementDropDown != null)
					{
						ivisualElement_0 = comboBox_0.ElementDropDown;
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
					ienumerator_0 = comboBox_0.method_0().GetEnumerator();
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
					Class76.smethod_139(this);
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
			Class72 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class72(0)
				{
					comboBox_0 = comboBox_0
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

	public new static readonly ComboBox Default;

	private IDropDownButton idropDownButton_0 = new DropDownButtonThemed();

	public IDropDownButton ElementDropDown
	{
		get
		{
			return idropDownButton_0;
		}
		set
		{
			idropDownButton_0 = value;
		}
	}

	static ComboBox()
	{
		Default = new ComboBox();
	}

	public ComboBox()
	{
		ElementDropDown.AnchorArea = new AnchorArea(float.NaN, 0f, 0f, 0f, center: false, middle: false);
	}

	public ComboBox(ComboBox p_Source)
		: base(p_Source)
	{
		ElementDropDown = (IDropDownButton)p_Source.ElementDropDown.Clone();
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		PrepareVisualElementDropDown(context);
	}

	[IteratorStateMachine(typeof(Class72))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class72(-2)
		{
			comboBox_0 = this
		};
	}

	private IEnumerable<IVisualElement> method_0()
	{
		return base.GetElements();
	}

	protected virtual void PrepareVisualElementDropDown(CellContext context)
	{
		if (!context.CellRange.Contains(context.Grid.MouseCellPosition))
		{
			ElementDropDown.Style = ButtonStyle.Normal;
		}
		else
		{
			ElementDropDown.Style = ButtonStyle.Hot;
		}
	}

	public override object Clone()
	{
		return new ComboBox(this);
	}
}

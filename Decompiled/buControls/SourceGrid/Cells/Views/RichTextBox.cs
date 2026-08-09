using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using DevAge.Drawing.VisualElements;
using DevAge.Windows.Forms;
using ns27;

namespace SourceGrid.Cells.Views;

[Serializable]
public class RichTextBox : Cell
{
	[CompilerGenerated]
	internal sealed class Class74 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		internal int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public RichTextBox richTextBox_0;

		internal IEnumerator<IVisualElement> ienumerator_0;

		private IVisualElement ivisualElement_1;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class74(int int_2)
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
					Class76.smethod_415(this);
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
					if (richTextBox_0.ElementRichText != null)
					{
						ivisualElement_0 = richTextBox_0.ElementRichText;
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
					ienumerator_0 = richTextBox_0.method_0().GetEnumerator();
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
					Class76.smethod_415(this);
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
			Class74 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class74(0)
				{
					richTextBox_0 = richTextBox_0
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

	public new static readonly RichTextBox Default = new RichTextBox();

	private IRichText m_ElementRichText = null;

	private RotateFlipType m_RotateFlipType = RotateFlipType.RotateNoneFlipNone;

	public IRichText ElementRichText
	{
		get
		{
			return m_ElementRichText;
		}
		set
		{
			m_ElementRichText = value;
		}
	}

	public RotateFlipType RotateFlipType
	{
		get
		{
			return m_RotateFlipType;
		}
		set
		{
			m_RotateFlipType = value;
		}
	}

	public RichTextBox()
	{
		ElementRichText = new RichTextGDI();
	}

	public RichTextBox(RichTextBox p_Source)
		: base(p_Source)
	{
		ElementRichText = (IRichText)p_Source.ElementRichText.Clone();
	}

	protected override void PrepareView(CellContext context)
	{
		PrepareVisualElementRichTextBox(context);
	}

	[IteratorStateMachine(typeof(Class74))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class74(-2)
		{
			richTextBox_0 = this
		};
	}

	private IEnumerable<IVisualElement> method_0()
	{
		return base.GetElements();
	}

	protected virtual void PrepareVisualElementRichTextBox(CellContext context)
	{
		ElementRichText.Value = context.Cell.Model.ValueModel.GetValue(context) as DevAge.Windows.Forms.RichText;
		ElementRichText.ForeColor = base.ForeColor;
		ElementRichText.TextAlignment = base.TextAlignment;
		ElementRichText.Font = GetDrawingFont(context.Grid);
		ElementRichText.RotateFlipType = RotateFlipType;
	}

	public override object Clone()
	{
		return new RichTextBox(this);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using DevAge.Windows.Forms;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells.Views;

[Serializable]
public class Cell : ViewBase
{
	[CompilerGenerated]
	private sealed class Class69 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		private int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public Cell cell_0;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class69(int int_2)
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
			case 2:
				int_0 = -1;
				goto IL_0022;
			default:
				return false;
			case 0:
				int_0 = -1;
				if (cell_0.ElementImage != null)
				{
					ivisualElement_0 = cell_0.ElementImage;
					int_0 = 1;
					return true;
				}
				goto IL_003d;
			case 1:
				{
					int_0 = -1;
					goto IL_003d;
				}
				IL_003d:
				if (cell_0.ElementText != null)
				{
					ivisualElement_0 = cell_0.ElementText;
					int_0 = 2;
					return true;
				}
				goto IL_0022;
				IL_0022:
				return false;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<IVisualElement> IEnumerable<IVisualElement>.GetEnumerator()
		{
			Class69 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class69(0)
				{
					cell_0 = cell_0
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

	public static readonly Cell Default = new Cell();

	private IText mElementText = new TextGDI();

	private DevAge.Drawing.VisualElements.IImage mElementImage = new DevAge.Drawing.VisualElements.Image();

	public IText ElementText
	{
		get
		{
			return mElementText;
		}
		set
		{
			mElementText = value;
		}
	}

	public DevAge.Drawing.VisualElements.IImage ElementImage
	{
		get
		{
			return mElementImage;
		}
		set
		{
			mElementImage = value;
		}
	}

	public Cell()
	{
		base.ElementsDrawMode = ElementsDrawMode.Align;
	}

	public Cell(Cell p_Source)
		: base(p_Source)
	{
		ElementImage = (DevAge.Drawing.VisualElements.IImage)p_Source.ElementImage.Clone();
		ElementText = (IText)p_Source.ElementText.Clone();
	}

	public override object Clone()
	{
		return new Cell(this);
	}

	[IteratorStateMachine(typeof(Class69))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class69(-2)
		{
			cell_0 = this
		};
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		PrepareVisualElementText(context);
		PrepareVisualElementImage(context);
	}

	protected virtual void PrepareVisualElementText(CellContext context)
	{
		if (!(ElementText is DevAge.Drawing.VisualElements.TextRenderer))
		{
			if (ElementText is TextGDI)
			{
				TextGDI textGDI = (TextGDI)ElementText;
				if (!base.WordWrap)
				{
					textGDI.StringFormat.FormatFlags = StringFormatFlags.NoWrap;
				}
				else
				{
					textGDI.StringFormat.FormatFlags = (StringFormatFlags)0;
				}
				if (base.TrimmingMode != TrimmingMode.Char)
				{
					if (base.TrimmingMode != TrimmingMode.Word)
					{
						textGDI.StringFormat.Trimming = StringTrimming.None;
					}
					else
					{
						textGDI.StringFormat.Trimming = StringTrimming.EllipsisWord;
					}
				}
				else
				{
					textGDI.StringFormat.Trimming = StringTrimming.EllipsisCharacter;
				}
				textGDI.Alignment = base.TextAlignment;
			}
		}
		else
		{
			DevAge.Drawing.VisualElements.TextRenderer textRenderer = (DevAge.Drawing.VisualElements.TextRenderer)ElementText;
			textRenderer.TextFormatFlags = TextFormatFlags.NoPrefix;
			if (base.WordWrap)
			{
				textRenderer.TextFormatFlags |= TextFormatFlags.WordBreak;
			}
			if (base.TrimmingMode != TrimmingMode.Char)
			{
				if (base.TrimmingMode == TrimmingMode.Word)
				{
					textRenderer.TextFormatFlags |= TextFormatFlags.WordEllipsis;
				}
			}
			else
			{
				textRenderer.TextFormatFlags |= TextFormatFlags.EndEllipsis;
			}
			textRenderer.TextFormatFlags |= DevAge.Windows.Forms.Utilities.ContentAligmentToTextFormatFlags(base.TextAlignment);
		}
		ElementText.Font = GetDrawingFont(context.Grid);
		ElementText.ForeColor = base.ForeColor;
		ElementText.Value = context.DisplayText;
	}

	protected virtual void PrepareVisualElementImage(CellContext context)
	{
		ElementImage.AnchorArea = new AnchorArea(base.ImageAlignment, base.ImageStretch);
		System.Drawing.Image value = null;
		SourceGrid.Cells.Models.IImage image = (SourceGrid.Cells.Models.IImage)context.Cell.Model.FindModel(typeof(SourceGrid.Cells.Models.IImage));
		if (image != null)
		{
			value = image.GetImage(context);
		}
		ElementImage.Value = value;
	}
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevAge.Windows.Forms;
using SourceGrid.Cells.Editors;
using ns27;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RichTextGDI : RichText
{
	private struct Struct32
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	private struct Struct33
	{
		public int int_0;

		public int int_1;
	}

	private struct Struct34
	{
		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public Struct32 struct32_0;

		public Struct32 struct32_1;

		public Struct33 struct33_0;
	}

	private static SourceGrid.Cells.Editors.RichTextBox m_RichTextBoxEditor;

	private const int WM_USER = 1024;

	private const int EM_FORMATRANGE = 1081;

	public SourceGrid.Cells.Editors.RichTextBox RichTextBoxEditor
	{
		get
		{
			return m_RichTextBoxEditor;
		}
		set
		{
			m_RichTextBoxEditor = value;
		}
	}

	public RichTextGDI()
	{
	}

	public RichTextGDI(DevAge.Windows.Forms.RichText value)
		: base(value)
	{
	}

	public RichTextGDI(RichTextGDI other)
		: base(other)
	{
	}

	protected virtual void AssertRichTextBoxEditor()
	{
		if (RichTextBoxEditor == null)
		{
			RichTextBoxEditor = new SourceGrid.Cells.Editors.RichTextBox();
		}
		RichTextBoxEditor.Control.Clear();
		RichTextBoxEditor.Control.Value = Value;
		if (ForeColor != Color.FromKnownColor(KnownColor.WindowText))
		{
			RichTextBoxEditor.Control.SelectAll();
			RichTextBoxEditor.Control.SelectionColor = ForeColor;
		}
		if (base.TextAlignment != ContentAlignment.MiddleLeft)
		{
			RichTextBoxEditor.Control.SelectAll();
			RichTextBoxEditor.Control.SelectionAlignment = DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(base.TextAlignment);
		}
		if (Font != Control.DefaultFont)
		{
			RichTextBoxEditor.Control.SelectAll();
			RichTextBoxEditor.Control.SelectionFont = Font;
		}
	}

	public int FormatRange(bool measureOnly, DevAgeRichTextBox rtb, ref Bitmap b, int charFrom, int charTo)
	{
		Struct33 struct33_ = default(Struct33);
		struct33_.int_0 = charFrom;
		struct33_.int_1 = charTo;
		Struct32 struct32_ = default(Struct32);
		struct32_.int_1 = Class76.smethod_436(this, 0f);
		struct32_.int_3 = Class76.smethod_436(this, (float)b.Height);
		struct32_.int_0 = Class76.smethod_436(this, 0f);
		struct32_.int_2 = Class76.smethod_436(this, (float)b.Width);
		Struct32 struct32_2 = default(Struct32);
		struct32_2.int_1 = Class76.smethod_436(this, 0f);
		struct32_2.int_3 = Class76.smethod_436(this, (float)b.Height);
		struct32_2.int_0 = Class76.smethod_436(this, 0f);
		struct32_2.int_2 = Class76.smethod_436(this, (float)b.Width);
		Graphics graphics = Graphics.FromImage(b);
		IntPtr hdc = graphics.GetHdc();
		Struct34 structure = default(Struct34);
		structure.struct33_0 = struct33_;
		structure.intptr_0 = hdc;
		structure.intptr_1 = hdc;
		structure.struct32_0 = struct32_;
		structure.struct32_1 = struct32_2;
		int int_ = ((!measureOnly) ? 1 : 0);
		IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
		Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
		int result = Class76.SendMessage_2(rtb.Handle, 1081, int_, intPtr);
		Marshal.FreeCoTaskMem(intPtr);
		graphics.ReleaseHdc(hdc);
		graphics.Dispose();
		return result;
	}

	public void FormatRangeDone(DevAgeRichTextBox RTB)
	{
		Class76.SendMessage_2(intptr_1: new IntPtr(0), intptr_0: RTB.Handle, int_0: 1081, int_1: 0);
	}

	protected Bitmap GetBitmapArea(RectangleF area, RotateFlipType rotateFlipType)
	{
		int height = (int)area.Height;
		int num = (int)area.Width;
		if (rotateFlipType == RotateFlipType.Rotate90FlipNone || rotateFlipType == RotateFlipType.Rotate90FlipX || rotateFlipType == RotateFlipType.Rotate270FlipX || rotateFlipType == RotateFlipType.Rotate270FlipNone)
		{
			height = num;
			num = (int)area.Height;
		}
		return new Bitmap(num, height);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		lock (this)
		{
			Bitmap bitmap = null;
			if (area.Width <= 0f || !(area.Height > 0f))
			{
				bitmap = new Bitmap(1, 1);
			}
			else
			{
				AssertRichTextBoxEditor();
				bitmap = GetBitmapArea(area, base.RotateFlipType);
				FormatRange(measureOnly: false, RichTextBoxEditor.Control, ref bitmap, 0, RichTextBoxEditor.Control.Text.Length);
				FormatRangeDone(RichTextBoxEditor.Control);
			}
			DrawImage(graphics, area, bitmap);
		}
	}

	protected virtual void DrawImage(GraphicsCache graphics, RectangleF area, Bitmap bmp)
	{
		bmp.MakeTransparent(Color.White);
		bmp.RotateFlip(base.RotateFlipType);
		graphics.Graphics.DrawImage(bmp, area);
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		string text = string.Empty;
		if (Value != null && Value.Rtf.Length > 0)
		{
			text = RichTextConversion.RichTextToString(Value);
		}
		return measure.Graphics.MeasureString(text, Font, maxSize);
	}

	public override object Clone()
	{
		return new RichTextGDI(this);
	}
}

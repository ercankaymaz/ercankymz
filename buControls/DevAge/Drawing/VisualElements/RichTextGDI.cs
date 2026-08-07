// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.RichTextGDI
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using ns7;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RichTextGDI : RichText
{
  private static SourceGrid.Cells.Editors.RichTextBox m_RichTextBoxEditor;
  private const int WM_USER = 1024 /*0x0400*/;
  private const int EM_FORMATRANGE = 1081;

  public RichTextGDI()
  {
  }

  public RichTextGDI(DevAge.Windows.Forms.RichText value)
    : base(value)
  {
  }

  public RichTextGDI(RichTextGDI other)
    : base((RichText) other)
  {
  }

  protected virtual void AssertRichTextBoxEditor()
  {
    if (this.RichTextBoxEditor == null)
      this.RichTextBoxEditor = new SourceGrid.Cells.Editors.RichTextBox();
    this.RichTextBoxEditor.Control.Clear();
    this.RichTextBoxEditor.Control.Value = this.Value;
    if (this.ForeColor != Color.FromKnownColor(KnownColor.WindowText))
    {
      this.RichTextBoxEditor.Control.SelectAll();
      this.RichTextBoxEditor.Control.SelectionColor = this.ForeColor;
    }
    if (this.TextAlignment != DevAge.Drawing.ContentAlignment.MiddleLeft)
    {
      this.RichTextBoxEditor.Control.SelectAll();
      this.RichTextBoxEditor.Control.SelectionAlignment = DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(this.TextAlignment);
    }
    if (this.Font == Control.DefaultFont)
      return;
    this.RichTextBoxEditor.Control.SelectAll();
    this.RichTextBoxEditor.Control.SelectionFont = this.Font;
  }

  public SourceGrid.Cells.Editors.RichTextBox RichTextBoxEditor
  {
    get => RichTextGDI.m_RichTextBoxEditor;
    set => RichTextGDI.m_RichTextBoxEditor = value;
  }

  public int FormatRange(
    bool measureOnly,
    DevAgeRichTextBox rtb,
    ref Bitmap b,
    int charFrom,
    int charTo)
  {
    RichTextGDI.Struct3 struct3;
    struct3.int_0 = charFrom;
    struct3.int_1 = charTo;
    RichTextGDI.Struct2 struct2_1;
    struct2_1.int_1 = Class39.smethod_436(this, 0.0f);
    struct2_1.int_3 = Class39.smethod_436(this, (float) b.Height);
    struct2_1.int_0 = Class39.smethod_436(this, 0.0f);
    struct2_1.int_2 = Class39.smethod_436(this, (float) b.Width);
    RichTextGDI.Struct2 struct2_2;
    struct2_2.int_1 = Class39.smethod_436(this, 0.0f);
    struct2_2.int_3 = Class39.smethod_436(this, (float) b.Height);
    struct2_2.int_0 = Class39.smethod_436(this, 0.0f);
    struct2_2.int_2 = Class39.smethod_436(this, (float) b.Width);
    Graphics graphics = Graphics.FromImage((System.Drawing.Image) b);
    IntPtr hdc = graphics.GetHdc();
    RichTextGDI.Struct4 structure;
    structure.struct3_0 = struct3;
    structure.intptr_0 = hdc;
    structure.intptr_1 = hdc;
    structure.struct2_0 = struct2_1;
    structure.struct2_1 = struct2_2;
    int int_1 = measureOnly ? 0 : 1;
    IntPtr num1 = Marshal.AllocCoTaskMem(Marshal.SizeOf<RichTextGDI.Struct4>(structure));
    Marshal.StructureToPtr<RichTextGDI.Struct4>(structure, num1, false);
    int num2 = Class39.SendMessage_2(rtb.Handle, 1081, int_1, num1);
    Marshal.FreeCoTaskMem(num1);
    graphics.ReleaseHdc(hdc);
    graphics.Dispose();
    return num2;
  }

  public void FormatRangeDone(DevAgeRichTextBox RTB)
  {
    IntPtr intptr_1 = new IntPtr(0);
    Class39.SendMessage_2(RTB.Handle, 1081, 0, intptr_1);
  }

  protected Bitmap GetBitmapArea(RectangleF area, RotateFlipType rotateFlipType)
  {
    int height = (int) area.Height;
    int width = (int) area.Width;
    if ((rotateFlipType == RotateFlipType.Rotate90FlipNone || rotateFlipType == RotateFlipType.Rotate90FlipX || rotateFlipType == RotateFlipType.Rotate270FlipX ? 1 : (rotateFlipType == RotateFlipType.Rotate270FlipNone ? 1 : 0)) != 0)
    {
      height = width;
      width = (int) area.Height;
    }
    return new Bitmap(width, height);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    lock (this)
    {
      Bitmap b;
      if (((double) area.Width <= 0.0 ? 0 : ((double) area.Height > 0.0 ? 1 : 0)) != 0)
      {
        this.AssertRichTextBoxEditor();
        b = this.GetBitmapArea(area, this.RotateFlipType);
        this.FormatRange(false, this.RichTextBoxEditor.Control, ref b, 0, this.RichTextBoxEditor.Control.Text.Length);
        this.FormatRangeDone(this.RichTextBoxEditor.Control);
      }
      else
        b = new Bitmap(1, 1);
      this.DrawImage(graphics, area, b);
    }
  }

  protected virtual void DrawImage(GraphicsCache graphics, RectangleF area, Bitmap bmp)
  {
    bmp.MakeTransparent(Color.White);
    bmp.RotateFlip(this.RotateFlipType);
    graphics.Graphics.DrawImage((System.Drawing.Image) bmp, area);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    string empty = string.Empty;
    if ((this.Value == null ? 0 : (this.Value.Rtf.Length > 0 ? 1 : 0)) != 0)
      empty = RichTextConversion.RichTextToString(this.Value);
    return measure.Graphics.MeasureString(empty, this.Font, maxSize);
  }

  public override object Clone() => (object) new RichTextGDI(this);

  private struct Struct2
  {
    public int int_0;
    public int int_1;
    public int int_2;
    public int int_3;
  }

  private struct Struct3
  {
    public int int_0;
    public int int_1;
  }

  private struct Struct4
  {
    public IntPtr intptr_0;
    public IntPtr intptr_1;
    public RichTextGDI.Struct2 struct2_0;
    public RichTextGDI.Struct2 struct2_1;
    public RichTextGDI.Struct3 struct3_0;
  }
}

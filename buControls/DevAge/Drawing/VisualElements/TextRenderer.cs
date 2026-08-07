// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.TextRenderer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class TextRenderer : Text
{
  private TextFormatFlags mTextFormatFlags = TextFormatFlags.NoPrefix;

  public TextRenderer()
  {
  }

  public TextRenderer(string value) => this.Value = value;

  public TextRenderer(TextRenderer other)
    : base((Text) other)
  {
    this.TextFormatFlags = other.TextFormatFlags;
  }

  public override object Clone() => (object) new TextRenderer(this);

  public virtual TextFormatFlags TextFormatFlags
  {
    get => this.mTextFormatFlags;
    set => this.mTextFormatFlags = value;
  }

  protected virtual bool ShouldSerializeTextFormatFlags()
  {
    return this.TextFormatFlags != TextFormatFlags.NoPrefix;
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((this.Value == null ? 1 : (this.Value.Length == 0 ? 1 : 0)) != 0)
      return;
    if (this.Enabled)
      System.Windows.Forms.TextRenderer.DrawText((IDeviceContext) graphics.Graphics, this.Value, this.Font, Rectangle.Round(area), this.ForeColor, this.TextFormatFlags);
    else
      System.Windows.Forms.TextRenderer.DrawText((IDeviceContext) graphics.Graphics, this.Value, this.Font, Rectangle.Round(area), Color.FromKnownColor(KnownColor.GrayText), this.TextFormatFlags);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    Size proposedSize;
    if (maxSize != SizeF.Empty)
    {
      proposedSize = Size.Ceiling(maxSize);
      if (proposedSize.Width == 0)
        proposedSize.Width = int.MaxValue;
      if (proposedSize.Height == 0)
        proposedSize.Height = int.MaxValue;
    }
    else
      proposedSize = new Size(int.MaxValue, int.MaxValue);
    return (SizeF) System.Windows.Forms.TextRenderer.MeasureText((IDeviceContext) measure.Graphics, this.Value, this.Font, proposedSize, this.TextFormatFlags);
  }
}

// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.TextGDI
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class TextGDI : Text
{
  private StringFormat mStringFormat = new StringFormat(StringFormat.GenericDefault);

  public TextGDI()
  {
  }

  public TextGDI(string value) => this.Value = value;

  public TextGDI(TextGDI other)
    : base((Text) other)
  {
    if (other.StringFormat != null)
      this.StringFormat = (StringFormat) other.StringFormat.Clone();
    else
      this.StringFormat = (StringFormat) null;
  }

  [TypeConverter(typeof (ExpandableObjectConverter))]
  public virtual StringFormat StringFormat
  {
    get => this.mStringFormat;
    set => this.mStringFormat = value;
  }

  public virtual DevAge.Drawing.ContentAlignment Alignment
  {
    get => Utilities.StringFormatToContentAlignment(this.StringFormat);
    set => Utilities.ApplyContentAlignmentToStringFormat(value, this.StringFormat);
  }

  protected virtual bool ShouldSerializeAlignment() => false;

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((this.Value == null ? 1 : (this.Value.Length == 0 ? 1 : 0)) != 0)
      return;
    SolidBrush solidBrush = !this.Enabled ? graphics.BrushsCache.GetBrush(Color.FromKnownColor(KnownColor.GrayText)) : graphics.BrushsCache.GetBrush(this.ForeColor);
    graphics.Graphics.DrawString(this.Value, this.Font, (Brush) solidBrush, area, this.StringFormat);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return !(maxSize != SizeF.Empty) ? measure.Graphics.MeasureString(this.Value, this.Font, new SizeF(5000f, 5000f), this.StringFormat) : measure.Graphics.MeasureString(this.Value, this.Font, maxSize, this.StringFormat);
  }

  public override object Clone() => (object) new TextGDI(this);
}

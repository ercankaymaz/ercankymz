// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.RichText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RichText : VisualElementBase, ICloneable, IVisualElement, IRichText
{
  private DevAge.Windows.Forms.RichText m_Value = (DevAge.Windows.Forms.RichText) null;
  private Color m_ForeColor = Control.DefaultForeColor;
  private DevAge.Drawing.ContentAlignment m_TextAlignment;
  private Font m_Font = Control.DefaultFont;
  private RotateFlipType m_RotateFlipType = RotateFlipType.RotateNoneFlipNone;

  public RichText()
  {
  }

  public RichText(DevAge.Windows.Forms.RichText value) => this.Value = value;

  public RichText(RichText other)
    : base((VisualElementBase) other)
  {
    this.Value = other.Value;
    this.ForeColor = other.ForeColor;
    this.TextAlignment = other.TextAlignment;
    this.Font = other.Font;
  }

  [DefaultValue(null)]
  public virtual DevAge.Windows.Forms.RichText Value
  {
    get => this.m_Value;
    set => this.m_Value = value;
  }

  public virtual Color ForeColor
  {
    get => this.m_ForeColor;
    set => this.m_ForeColor = value;
  }

  public DevAge.Drawing.ContentAlignment TextAlignment
  {
    get => this.m_TextAlignment;
    set => this.m_TextAlignment = value;
  }

  public virtual Font Font
  {
    get => this.m_Font;
    set => this.m_Font = value;
  }

  public RotateFlipType RotateFlipType
  {
    get => this.m_RotateFlipType;
    set => this.m_RotateFlipType = value;
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    Font defaultFont = Control.DefaultFont;
    return !(maxSize != SizeF.Empty) ? measure.Graphics.MeasureString(this.Value.Rtf, defaultFont) : measure.Graphics.MeasureString(this.Value.Rtf, defaultFont, maxSize);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    Color defaultForeColor = Control.DefaultForeColor;
    Font defaultFont = Control.DefaultFont;
    SolidBrush brush = graphics.BrushsCache.GetBrush(defaultForeColor);
    graphics.Graphics.DrawString(this.Value.Rtf, defaultFont, (Brush) brush, area);
  }

  public override object Clone() => (object) new RichText(this);
}

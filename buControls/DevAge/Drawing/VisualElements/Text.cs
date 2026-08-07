// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Text
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
public class Text : VisualElementBase, ICloneable, IVisualElement, IText
{
  private Font mFont = Control.DefaultFont;
  private Color mForeColor = Control.DefaultForeColor;
  private string mValue = (string) null;
  private bool mEnabled = true;

  public Text()
  {
  }

  public Text(string value) => this.Value = value;

  public Text(Text other)
    : base((VisualElementBase) other)
  {
    this.Value = other.Value;
    this.Font = other.Font;
    this.ForeColor = other.ForeColor;
    this.Enabled = other.Enabled;
  }

  public virtual Font Font
  {
    get => this.mFont;
    set => this.mFont = value;
  }

  private bool ShouldSerializeFont() => this.Font.ToString() != Control.DefaultFont.ToString();

  public virtual Color ForeColor
  {
    get => this.mForeColor;
    set => this.mForeColor = value;
  }

  private bool ShouldSerializeForeColor() => this.ForeColor != Control.DefaultForeColor;

  [DefaultValue(null)]
  public virtual string Value
  {
    get => this.mValue;
    set => this.mValue = value;
  }

  public bool Enabled
  {
    get => this.mEnabled;
    set => this.mEnabled = value;
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return !(maxSize != SizeF.Empty) ? measure.Graphics.MeasureString(this.Value, this.Font) : measure.Graphics.MeasureString(this.Value, this.Font, maxSize);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    SolidBrush solidBrush = !this.Enabled ? graphics.BrushsCache.GetBrush(Color.FromKnownColor(KnownColor.GrayText)) : graphics.BrushsCache.GetBrush(this.ForeColor);
    graphics.Graphics.DrawString(this.Value, this.Font, (Brush) solidBrush, area);
  }

  public override object Clone() => (object) new Text(this);
}

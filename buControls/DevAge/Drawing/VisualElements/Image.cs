// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Image
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Image : VisualElementBase, ICloneable, IVisualElement, IImage
{
  private System.Drawing.Image mValue = (System.Drawing.Image) null;
  private bool mEnabled = true;

  public Image()
  {
  }

  public Image(System.Drawing.Image value) => this.Value = value;

  public Image(Image other)
    : base((VisualElementBase) other)
  {
    this.Value = other.Value == null ? (System.Drawing.Image) null : (System.Drawing.Image) other.Value.Clone();
    this.Enabled = other.Enabled;
  }

  [DefaultValue(null)]
  public System.Drawing.Image Value
  {
    get => this.mValue;
    set => this.mValue = value;
  }

  public bool Enabled
  {
    get => this.mEnabled;
    set => this.mEnabled = value;
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if (this.Value == null)
      return;
    if (this.Enabled)
    {
      graphics.Graphics.DrawImage(this.Value, Rectangle.Round(area));
    }
    else
    {
      using (System.Drawing.Image disabledImage = Utilities.CreateDisabledImage(this.Value, Color.White))
        graphics.Graphics.DrawImage(disabledImage, area);
    }
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return this.Value == null ? SizeF.Empty : (SizeF) this.Value.Size;
  }

  public override object Clone() => (object) new Image(this);
}

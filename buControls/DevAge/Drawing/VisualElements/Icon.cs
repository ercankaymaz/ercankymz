// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Icon
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Icon : VisualElementBase, ICloneable, IVisualElement, IIcon
{
  private System.Drawing.Icon mValue = (System.Drawing.Icon) null;

  public Icon()
  {
  }

  public Icon(System.Drawing.Icon value) => this.Value = value;

  public Icon(Icon other)
    : base((VisualElementBase) other)
  {
    if (other.Value != null)
      this.Value = (System.Drawing.Icon) other.Value.Clone();
    else
      this.Value = (System.Drawing.Icon) null;
  }

  [DefaultValue(null)]
  public System.Drawing.Icon Value
  {
    get => this.mValue;
    set => this.mValue = value;
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if (this.Value == null)
      return;
    graphics.Graphics.DrawIcon(this.Value, Rectangle.Round(area));
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return this.Value == null ? SizeF.Empty : (SizeF) this.Value.Size;
  }

  public override object Clone() => (object) new Icon(this);
}

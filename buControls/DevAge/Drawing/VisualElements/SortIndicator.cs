// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.SortIndicator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class SortIndicator : Icon, ICloneable, IVisualElement, ISortIndicator
{
  private HeaderSortStyle mHeaderSortStyle = HeaderSortStyle.None;

  public SortIndicator()
  {
    this.AnchorArea = new AnchorArea(float.NaN, float.NaN, 0.0f, float.NaN, false, true);
  }

  public SortIndicator(SortIndicator other)
    : base((Icon) other)
  {
    this.SortStyle = other.SortStyle;
  }

  public override object Clone() => (object) new SortIndicator(this);

  [DefaultValue(HeaderSortStyle.None)]
  public virtual HeaderSortStyle SortStyle
  {
    get => this.mHeaderSortStyle;
    set
    {
      this.mHeaderSortStyle = value;
      if (this.mHeaderSortStyle == HeaderSortStyle.Ascending)
        this.Value = Class39.smethod_748();
      else if (this.mHeaderSortStyle == HeaderSortStyle.Descending)
        this.Value = Class39.smethod_726();
      else
        this.Value = (System.Drawing.Icon) null;
    }
  }
}

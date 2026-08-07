// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.HeaderBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class HeaderBase : BackgroundBase, ICloneable, IVisualElement, IBackground, IHeader
{
  private ControlDrawStyle mControlDrawStyle = ControlDrawStyle.Normal;

  public HeaderBase()
  {
  }

  public HeaderBase(HeaderBase other)
    : base((BackgroundBase) other)
  {
    this.Style = other.Style;
  }

  public virtual ControlDrawStyle Style
  {
    get => this.mControlDrawStyle;
    set => this.mControlDrawStyle = value;
  }

  protected virtual bool ShouldSerializeStyle() => this.Style != ControlDrawStyle.Normal;
}

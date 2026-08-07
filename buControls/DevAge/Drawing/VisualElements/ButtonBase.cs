// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.ButtonBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class ButtonBase : BackgroundBase, ICloneable, IVisualElement, IBackground, IButton
{
  private ButtonStyle mControlDrawStyle = ButtonStyle.Normal;

  public ButtonBase()
  {
  }

  public ButtonBase(ButtonBase other)
    : base((BackgroundBase) other)
  {
    this.Style = other.Style;
  }

  public virtual ButtonStyle Style
  {
    get => this.mControlDrawStyle;
    set => this.mControlDrawStyle = value;
  }

  protected virtual bool ShouldSerializeStyle() => this.Style != ButtonStyle.Normal;
}

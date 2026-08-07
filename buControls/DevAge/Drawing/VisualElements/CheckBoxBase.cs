// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.CheckBoxBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class CheckBoxBase : VisualElementBase, ICloneable, IVisualElement, ICheckBox
{
  private ControlDrawStyle mControlDrawStyle = ControlDrawStyle.Normal;
  private CheckBoxState mCheckBoxState = CheckBoxState.Undefined;

  public CheckBoxBase()
  {
    this.AnchorArea = new AnchorArea(float.NaN, float.NaN, float.NaN, float.NaN, true, true);
  }

  public CheckBoxBase(CheckBoxBase other)
    : base((VisualElementBase) other)
  {
    this.Style = other.Style;
    this.CheckBoxState = other.CheckBoxState;
  }

  public virtual ControlDrawStyle Style
  {
    get => this.mControlDrawStyle;
    set => this.mControlDrawStyle = value;
  }

  protected virtual bool ShouldSerializeStyle() => this.Style != ControlDrawStyle.Normal;

  public virtual CheckBoxState CheckBoxState
  {
    get => this.mCheckBoxState;
    set => this.mCheckBoxState = value;
  }

  protected virtual bool ShouldSerializeCheckBoxState() => this.CheckBoxState != 0;
}

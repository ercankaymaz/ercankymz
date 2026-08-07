// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.CheckBoxStatus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;

#nullable disable
namespace SourceGrid.Cells.Models;

public struct CheckBoxStatus
{
  private CheckBoxState checkState;
  public bool CheckEnable;
  public string Caption;

  public CheckBoxStatus(bool checkEnable, bool? bChecked, string caption)
  {
    this.CheckEnable = checkEnable;
    this.Caption = caption;
    this.checkState = CheckBoxState.Undefined;
    this.Checked = bChecked;
  }

  public CheckBoxStatus(bool checkEnable, CheckBoxState checkState, string caption)
  {
    this.CheckEnable = checkEnable;
    this.checkState = checkState;
    this.Caption = caption;
  }

  public CheckBoxState CheckState
  {
    get => this.checkState;
    set => this.checkState = value;
  }

  public bool? Checked
  {
    get
    {
      return this.CheckState != CheckBoxState.Checked ? (this.CheckState != CheckBoxState.Unchecked ? new bool?() : new bool?(false)) : new bool?(true);
    }
    set
    {
      if (!value.HasValue)
        this.CheckState = CheckBoxState.Undefined;
      else if (value.Value)
        this.CheckState = CheckBoxState.Checked;
      else
        this.CheckState = CheckBoxState.Unchecked;
    }
  }
}

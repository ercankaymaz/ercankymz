// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ICheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Cells.Models;

public interface ICheckBox : IModel
{
  CheckBoxStatus GetCheckBoxStatus(CellContext cellContext);

  void SetCheckedValue(CellContext cellContext, bool? pChecked);
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Conditions.ICondition
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;

#nullable disable
namespace SourceGrid.Conditions;

public interface ICondition
{
  bool Evaluate(DataGridColumn column, int gridRow, object itemRow);

  ICellVirtual ApplyCondition(ICellVirtual cell);
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Conditions.ConditionCell
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;

#nullable disable
namespace SourceGrid.Conditions;

public class ConditionCell : ICondition
{
  public ConditionCell.EvaluateFunctionDelegate EvaluateFunction;
  private ICellVirtual cell;

  public ConditionCell(ICellVirtual cell) => this.cell = cell;

  public ICellVirtual Cell => this.cell;

  public bool Evaluate(DataGridColumn column, int gridRow, object itemRow)
  {
    return this.EvaluateFunction != null && this.EvaluateFunction(column, gridRow, itemRow);
  }

  public ICellVirtual ApplyCondition(ICellVirtual cell) => this.Cell;

  public delegate bool EvaluateFunctionDelegate(DataGridColumn column, int gridRow, object itemRow);
}

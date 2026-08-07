// Decompiled with JetBrains decompiler
// Type: SourceGrid.Conditions.ConditionView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Conditions;

public class ConditionView : ICondition
{
  public ConditionView.EvaluateFunctionDelegate EvaluateFunction;
  private IView view;

  public ConditionView(IView view) => this.view = view;

  public IView View => this.view;

  public bool Evaluate(DataGridColumn column, int gridRow, object itemRow)
  {
    return this.EvaluateFunction != null && this.EvaluateFunction(column, gridRow, itemRow);
  }

  public ICellVirtual ApplyCondition(ICellVirtual cell)
  {
    ICellVirtual cellVirtual = cell.Copy();
    cellVirtual.View = this.View;
    return cellVirtual;
  }

  public delegate bool EvaluateFunctionDelegate(DataGridColumn column, int gridRow, object itemRow);
}

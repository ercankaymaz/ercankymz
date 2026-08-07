// Decompiled with JetBrains decompiler
// Type: SourceGrid.Conditions.ConditionBuilder
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Views;
using System.Drawing;

#nullable disable
namespace SourceGrid.Conditions;

public static class ConditionBuilder
{
  public static ICondition AlternateView(
    IView view,
    Color alternateBackcolor,
    Color alternateForecolor)
  {
    IView view1 = (IView) view.Clone();
    view1.BackColor = alternateBackcolor;
    view1.ForeColor = alternateForecolor;
    return (ICondition) new ConditionView(view1)
    {
      EvaluateFunction = (ConditionView.EvaluateFunctionDelegate) ((dataGridColumn_0, int_0, object_0) => (int_0 & 1) == 1)
    };
  }
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ToolTip
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Cells.Models;

public class ToolTip : IModel, IToolTipText
{
  private string string_0;

  public string GetToolTipText(CellContext cellContext)
  {
    return (!string.IsNullOrEmpty(this.string_0) ? 0 : (!cellContext.IsEmpty() ? 1 : 0)) == 0 ? this.string_0 : cellContext.DisplayText;
  }

  public string ToolTipText
  {
    get => this.string_0;
    set => this.string_0 = value;
  }
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.ColumnFocus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class ColumnFocus : ControllerBase
{
  public static readonly ColumnFocus Default = new ColumnFocus();

  public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    base.OnFocusEntering(sender, e);
    sender.Grid.Selection.FocusColumn(sender.Position.Column);
  }
}

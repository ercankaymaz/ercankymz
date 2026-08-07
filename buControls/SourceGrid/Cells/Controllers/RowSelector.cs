// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.RowSelector
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class RowSelector : ControllerBase
{
  public static readonly RowSelector Default = new RowSelector();

  public override void OnClick(CellContext sender, EventArgs e)
  {
    base.OnClick(sender, e);
    sender.Grid.Selection.SelectRow(sender.Position.Row, true);
  }
}

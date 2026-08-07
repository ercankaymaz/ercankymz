// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.MouseInvalidate
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class MouseInvalidate : ControllerBase
{
  public static readonly MouseInvalidate Default = new MouseInvalidate();

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseUp(sender, e);
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnMouseEnter(CellContext sender, EventArgs e)
  {
    base.OnMouseEnter(sender, e);
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    sender.Grid.InvalidateCell(sender.Position);
  }
}

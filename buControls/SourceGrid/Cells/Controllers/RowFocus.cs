// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.RowFocus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class RowFocus : ControllerBase
{
  public static readonly RowFocus Default = new RowFocus();
  public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));
  private MouseCursor mouseCursor_0 = new MouseCursor(Resources.CursorRightArrow, false);

  public override void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseMove(sender, e);
    if (this.LogicalBorder.GetPointPartType((RectangleF) sender.Grid.PositionToRectangle(sender.Position), (PointF) new Point(e.X, e.Y), out float _) != RectanglePartType.ContentArea)
      return;
    this.mouseCursor_0.ApplyCursor(sender, (EventArgs) e);
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    this.mouseCursor_0.ResetCursor(sender, e);
  }

  public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    base.OnFocusEntering(sender, e);
    sender.Grid.Selection.FocusRow(sender.Position.Row);
  }
}

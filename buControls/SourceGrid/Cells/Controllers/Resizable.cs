// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.Resizable
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class Resizable : ControllerBase
{
  public static readonly Resizable ResizeBoth = new Resizable(CellResizeMode.Both);
  public static readonly Resizable ResizeWidth = new Resizable(CellResizeMode.Width);
  public static readonly Resizable ResizeHeight = new Resizable(CellResizeMode.Height);
  public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));
  private MouseCursor mouseCursor_0 = new MouseCursor(Cursors.VSplit, false);
  private MouseCursor mouseCursor_1 = new MouseCursor(Cursors.HSplit, false);
  private CellResizeMode p_Mode = CellResizeMode.Both;
  private bool bool_0 = false;
  private bool bool_1 = false;
  private float float_0 = 0.0f;

  public Resizable(CellResizeMode p_Mode) => this.p_Mode = p_Mode;

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    this.bool_1 = false;
    this.bool_0 = false;
    RectanglePartType pointPartType = this.LogicalBorder.GetPointPartType((RectangleF) sender.Grid.PositionToRectangle(sender.Position), (PointF) new Point(e.X, e.Y), out this.float_0);
    if (((this.ResizeMode & CellResizeMode.Width) != CellResizeMode.Width ? 0 : (pointPartType == RectanglePartType.RightBorder ? 1 : 0)) != 0)
    {
      this.bool_0 = true;
    }
    else
    {
      if (((this.ResizeMode & CellResizeMode.Height) != CellResizeMode.Height ? 0 : (pointPartType == RectanglePartType.BottomBorder ? 1 : 0)) == 0)
        return;
      this.bool_1 = true;
    }
  }

  public override void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseUp(sender, e);
    this.bool_0 = false;
    this.bool_1 = false;
  }

  public override void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseMove(sender, e);
    Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
    if (rectangle.IsEmpty)
      return;
    Point point = new Point(e.X, e.Y);
    RectanglePartType pointPartType = this.LogicalBorder.GetPointPartType((RectangleF) rectangle, (PointF) point, out float _);
    if (sender.Grid.MouseDownPosition == sender.Position)
    {
      if (this.bool_0)
      {
        int num = point.X - rectangle.Left;
        if (num > 0)
        {
          GridVirtual grid = sender.Grid;
          Position position = sender.Position;
          int int_0 = (int) ((double) num + (double) this.float_0);
          Class39.smethod_717(position, grid, this, int_0);
        }
        this.mouseCursor_0.ApplyCursor(sender, (EventArgs) e);
        this.mouseCursor_1.ResetCursor(sender, (EventArgs) e);
      }
      else
      {
        if (!this.bool_1)
          return;
        int num = point.Y - rectangle.Top;
        if (num > 0)
        {
          GridVirtual grid = sender.Grid;
          Position position = sender.Position;
          int int_0 = (int) ((double) num + (double) this.float_0);
          Class39.smethod_344(position, grid, this, int_0);
        }
        this.mouseCursor_1.ApplyCursor(sender, (EventArgs) e);
        this.mouseCursor_0.ResetCursor(sender, (EventArgs) e);
      }
    }
    else if ((pointPartType != RectanglePartType.RightBorder ? 0 : ((this.ResizeMode & CellResizeMode.Width) == CellResizeMode.Width ? 1 : 0)) != 0)
      this.mouseCursor_0.ApplyCursor(sender, (EventArgs) e);
    else if ((pointPartType != RectanglePartType.BottomBorder ? 0 : ((this.ResizeMode & CellResizeMode.Height) == CellResizeMode.Height ? 1 : 0)) != 0)
    {
      this.mouseCursor_1.ApplyCursor(sender, (EventArgs) e);
    }
    else
    {
      this.mouseCursor_0.ResetCursor(sender, (EventArgs) e);
      this.mouseCursor_1.ResetCursor(sender, (EventArgs) e);
    }
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    this.mouseCursor_0.ResetCursor(sender, e);
    this.mouseCursor_1.ResetCursor(sender, e);
    this.bool_0 = false;
    this.bool_1 = false;
  }

  public override void OnDoubleClick(CellContext sender, EventArgs e)
  {
    base.OnDoubleClick(sender, e);
    Point client = sender.Grid.PointToClient(Control.MousePosition);
    RectanglePartType pointPartType = this.LogicalBorder.GetPointPartType((RectangleF) sender.Grid.PositionToRectangle(sender.Position), (PointF) client, out float _);
    if (((this.ResizeMode & CellResizeMode.Width) != CellResizeMode.Width ? 0 : (pointPartType == RectanglePartType.RightBorder ? 1 : 0)) != 0)
    {
      sender.Grid.Columns.AutoSizeColumn(sender.Position.Column);
    }
    else
    {
      if (((this.ResizeMode & CellResizeMode.Height) != CellResizeMode.Height ? 0 : (pointPartType == RectanglePartType.BottomBorder ? 1 : 0)) == 0)
        return;
      sender.Grid.Rows.AutoSizeRow(sender.Position.Row);
    }
  }

  public CellResizeMode ResizeMode => this.p_Mode;

  public bool IsWidthResizing => this.bool_0;

  public bool IsHeightResizing => this.bool_1;
}

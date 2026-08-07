// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.MouseCursor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class MouseCursor : ControllerBase
{
  public static readonly MouseCursor Default = new MouseCursor(Cursors.Default, true);
  public static readonly MouseCursor Hand = new MouseCursor(Cursors.Hand, true);
  private bool applyOnMouseEnter = false;
  private Cursor cursor = (Cursor) null;

  public MouseCursor(Cursor cursor, bool applyOnMouseEnter)
  {
    this.applyOnMouseEnter = applyOnMouseEnter;
    this.cursor = cursor;
  }

  public override void OnMouseEnter(CellContext sender, EventArgs e)
  {
    base.OnMouseEnter(sender, e);
    if (!this.applyOnMouseEnter)
      return;
    this.ApplyCursor(sender, e);
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    if (!this.applyOnMouseEnter)
      return;
    this.ResetCursor(sender, e);
  }

  public virtual void ApplyCursor(CellContext sender, EventArgs e)
  {
    if (!(this.Cursor != (Cursor) null))
      return;
    sender.Grid.Cursor = this.Cursor;
  }

  public virtual void ResetCursor(CellContext sender, EventArgs e)
  {
    if (!(this.Cursor != (Cursor) null) || !(sender.Grid.Cursor == this.Cursor))
      return;
    sender.Grid.Cursor = (Cursor) null;
  }

  public Cursor Cursor
  {
    get => this.cursor;
    set => this.cursor = value;
  }
}

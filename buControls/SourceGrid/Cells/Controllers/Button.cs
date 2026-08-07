// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.Button
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class Button : ControllerBase
{
  private MouseButtons mouseButtons_0 = MouseButtons.None;

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    this.mouseButtons_0 = e.Button;
  }

  public override void OnClick(CellContext sender, EventArgs e)
  {
    base.OnClick(sender, e);
    if (this.mouseButtons_0 != MouseButtons.Left)
      return;
    this.OnExecuted(sender, e);
  }

  public override void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
    base.OnKeyDown(sender, e);
    if (e.Handled || (e.KeyCode == Keys.Space ? 1 : (e.KeyCode == Keys.Return ? 1 : 0)) == 0)
      return;
    this.OnExecuted(sender, (EventArgs) e);
    e.Handled = true;
  }

  public event EventHandler Executed;

  public virtual void OnExecuted(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) sender, e);
  }
}

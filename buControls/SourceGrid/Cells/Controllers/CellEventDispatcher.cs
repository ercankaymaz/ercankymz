// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.CellEventDispatcher
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class CellEventDispatcher : ControllerBase
{
  public static readonly CellEventDispatcher Default = new CellEventDispatcher();

  public override void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
    base.OnKeyDown(sender, e);
    if ((sender.Cell == null || sender.Cell.Controller == null ? 0 : (!e.Handled ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnKeyDown(sender, e);
  }

  public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
    base.OnKeyPress(sender, e);
    if ((sender.Cell == null || sender.Cell.Controller == null ? 0 : (!e.Handled ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnKeyPress(sender, e);
  }

  public override void OnDoubleClick(CellContext sender, EventArgs e)
  {
    base.OnDoubleClick(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnDoubleClick(sender, e);
  }

  public override void OnClick(CellContext sender, EventArgs e)
  {
    base.OnClick(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnClick(sender, e);
  }

  public override void OnFocusEntered(CellContext sender, EventArgs e)
  {
    base.OnFocusEntered(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnFocusEntered(sender, e);
  }

  public override void OnFocusLeft(CellContext sender, EventArgs e)
  {
    base.OnFocusLeft(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnFocusLeft(sender, e);
  }

  public override void OnValueChanged(CellContext sender, EventArgs e)
  {
    base.OnValueChanged(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnValueChanged(sender, e);
  }

  public override void OnEditEnded(CellContext sender, EventArgs e)
  {
    base.OnEditEnded(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnEditEnded(sender, e);
  }

  public override bool CanReceiveFocus(CellContext sender, EventArgs e)
  {
    return base.CanReceiveFocus(sender, e) && sender.Cell != null && (sender.Cell.Controller == null || sender.Cell.Controller.CanReceiveFocus(sender, e));
  }

  public override void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
    base.OnEditStarting(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnEditStarting(sender, e);
  }

  public override void OnEditStarted(CellContext sender, EventArgs e)
  {
    base.OnEditStarted(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnEditStarted(sender, e);
  }

  public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
    base.OnValueChanging(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnValueChanging(sender, e);
  }

  public override void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    base.OnFocusEntering(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnFocusEntering(sender, e);
  }

  public override void OnFocusLeaving(CellContext sender, CancelEventArgs e)
  {
    base.OnFocusLeaving(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnFocusLeaving(sender, e);
  }

  public override void OnKeyUp(CellContext sender, KeyEventArgs e)
  {
    base.OnKeyUp(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnKeyUp(sender, e);
  }

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnMouseDown(sender, e);
  }

  public override void OnMouseEnter(CellContext sender, EventArgs e)
  {
    base.OnMouseEnter(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnMouseEnter(sender, e);
  }

  public override void OnMouseLeave(CellContext sender, EventArgs e)
  {
    base.OnMouseLeave(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnMouseLeave(sender, e);
  }

  public override void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseMove(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnMouseMove(sender, e);
  }

  public override void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseUp(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnMouseUp(sender, e);
  }

  public override void OnDragDrop(CellContext sender, DragEventArgs e)
  {
    base.OnDragDrop(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnDragDrop(sender, e);
  }

  public override void OnDragEnter(CellContext sender, DragEventArgs e)
  {
    base.OnDragEnter(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnDragEnter(sender, e);
  }

  public override void OnDragLeave(CellContext sender, EventArgs e)
  {
    base.OnDragLeave(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnDragLeave(sender, e);
  }

  public override void OnDragOver(CellContext sender, DragEventArgs e)
  {
    base.OnDragOver(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnDragOver(sender, e);
  }

  public override void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
  {
    base.OnGiveFeedback(sender, e);
    if ((sender.Cell == null ? 0 : (sender.Cell.Controller != null ? 1 : 0)) == 0)
      return;
    sender.Cell.Controller.OnGiveFeedback(sender, e);
  }
}

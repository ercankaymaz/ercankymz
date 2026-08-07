// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.ControllerContainer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class ControllerContainer : IController
{
  private ControllerContainer.ControllerList controllerList_0 = (ControllerContainer.ControllerList) null;

  public virtual IController FindController(System.Type modelType)
  {
    if (this.controllerList_0 == null)
      this.controllerList_0 = new ControllerContainer.ControllerList();
    return this.controllerList_0.GetByType(modelType);
  }

  public virtual void AddController(IController model)
  {
    if (this.controllerList_0 == null)
      this.controllerList_0 = new ControllerContainer.ControllerList();
    this.controllerList_0.Add(model);
  }

  public virtual void RemoveController(IController model)
  {
    if (this.controllerList_0 == null)
      return;
    this.controllerList_0.Remove(model);
  }

  public void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnMouseDown(sender, e);
  }

  public void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnMouseUp(sender, e);
  }

  public void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnMouseMove(sender, e);
  }

  public void OnMouseEnter(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnMouseEnter(sender, e);
  }

  public void OnMouseLeave(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnMouseLeave(sender, e);
  }

  public void OnKeyUp(CellContext sender, KeyEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnKeyUp(sender, e);
  }

  public void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnKeyDown(sender, e);
  }

  public void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnKeyPress(sender, e);
  }

  public void OnDoubleClick(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnDoubleClick(sender, e);
  }

  public void OnClick(CellContext sender, EventArgs e)
  {
    for (int index = 0; index < this.controllerList_0.Count; ++index)
      this.controllerList_0[index].OnClick(sender, e);
  }

  public void OnFocusLeaving(CellContext sender, CancelEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnFocusLeaving(sender, e);
  }

  public void OnFocusLeft(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnFocusLeft(sender, e);
  }

  public void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnFocusEntering(sender, e);
  }

  public void OnFocusEntered(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnFocusEntered(sender, e);
  }

  public void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnValueChanging(sender, e);
  }

  public void OnValueChanged(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnValueChanged(sender, e);
  }

  public void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnEditStarting(sender, e);
  }

  public void OnEditStarted(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnEditStarted(sender, e);
  }

  public void OnEditEnded(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnEditEnded(sender, e);
  }

  public bool CanReceiveFocus(CellContext sender, EventArgs e)
  {
    bool focus;
    foreach (IController controller in (List<IController>) this.controllerList_0)
    {
      if (!controller.CanReceiveFocus(sender, e))
      {
        focus = false;
        goto label_7;
      }
    }
    focus = true;
label_7:
    return focus;
  }

  public void OnDragDrop(CellContext sender, DragEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnDragDrop(sender, e);
  }

  public void OnDragEnter(CellContext sender, DragEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnDragEnter(sender, e);
  }

  public void OnDragLeave(CellContext sender, EventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnDragLeave(sender, e);
  }

  public void OnDragOver(CellContext sender, DragEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnDragOver(sender, e);
  }

  public void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
  {
    foreach (IController controller in (List<IController>) this.controllerList_0)
      controller.OnGiveFeedback(sender, e);
  }

  public class ControllerList : ListByType<IController>
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.ControllerBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public abstract class ControllerBase : IController
{
  public virtual void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
  }

  public virtual void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
  }

  public virtual void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
  }

  public virtual void OnMouseEnter(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnMouseLeave(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnKeyUp(CellContext sender, KeyEventArgs e)
  {
  }

  public virtual void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
  }

  public virtual void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
  }

  public virtual void OnDoubleClick(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnClick(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnFocusLeaving(CellContext sender, CancelEventArgs e)
  {
  }

  public virtual void OnFocusLeft(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
  }

  public virtual void OnFocusEntered(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
  }

  public virtual void OnValueChanged(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
  }

  public virtual void OnEditStarted(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnEditEnded(CellContext sender, EventArgs e)
  {
  }

  public virtual bool CanReceiveFocus(CellContext sender, EventArgs e) => true;

  public virtual void OnDragDrop(CellContext sender, DragEventArgs e)
  {
  }

  public virtual void OnDragEnter(CellContext sender, DragEventArgs e)
  {
  }

  public virtual void OnDragLeave(CellContext sender, EventArgs e)
  {
  }

  public virtual void OnDragOver(CellContext sender, DragEventArgs e)
  {
  }

  public virtual void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
  {
  }
}

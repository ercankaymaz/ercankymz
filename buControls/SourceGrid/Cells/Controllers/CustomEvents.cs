// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.CustomEvents
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class CustomEvents : IController
{
  public event MouseEventHandler MouseDown;

  public void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.mouseEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.mouseEventHandler_0((object) sender, e);
  }

  public event MouseEventHandler MouseUp;

  public void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.mouseEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.mouseEventHandler_1((object) sender, e);
  }

  public event MouseEventHandler MouseMove;

  public void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.mouseEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.mouseEventHandler_2((object) sender, e);
  }

  public event EventHandler MouseEnter;

  public void OnMouseEnter(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) sender, e);
  }

  public event EventHandler MouseLeave;

  public void OnMouseLeave(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) sender, e);
  }

  public event KeyEventHandler KeyUp;

  public void OnKeyUp(CellContext sender, KeyEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.keyEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyEventHandler_0((object) sender, e);
  }

  public event KeyEventHandler KeyDown;

  public void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.keyEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyEventHandler_1((object) sender, e);
  }

  public event KeyPressEventHandler KeyPress;

  public void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.keyPressEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyPressEventHandler_0((object) sender, e);
  }

  public event EventHandler DoubleClick;

  public void OnDoubleClick(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_2((object) sender, e);
  }

  public event EventHandler Click;

  public void OnClick(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_3 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_3((object) sender, e);
  }

  public event CancelEventHandler FocusLeaving;

  public void OnFocusLeaving(CellContext sender, CancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cancelEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelEventHandler_0((object) sender, e);
  }

  public event EventHandler FocusLeft;

  public void OnFocusLeft(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_4 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_4((object) sender, e);
  }

  public event CancelEventHandler FocusEntering;

  public void OnFocusEntering(CellContext sender, CancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cancelEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelEventHandler_1((object) sender, e);
  }

  public event EventHandler FocusEntered;

  public void OnFocusEntered(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_5 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_5((object) sender, e);
  }

  public event ValueChangeEventHandler ValueChanging;

  public void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangeEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangeEventHandler_0((object) sender, e);
  }

  public event EventHandler ValueChanged;

  public void OnValueChanged(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_6 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_6((object) sender, e);
  }

  public event CancelEventHandler EditStarting;

  public virtual void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cancelEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelEventHandler_2((object) sender, e);
  }

  public event EventHandler EditStarted;

  public virtual void OnEditStarted(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_7 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_7((object) sender, e);
  }

  public event EventHandler EditEnded;

  public virtual void OnEditEnded(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_8 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_8((object) sender, e);
  }

  public virtual bool CanReceiveFocus(CellContext sender, EventArgs e) => true;

  public event DragEventHandler DragDrop;

  public virtual void OnDragDrop(CellContext sender, DragEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.dragEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.dragEventHandler_0((object) sender, e);
  }

  public event DragEventHandler DragEnter;

  public virtual void OnDragEnter(CellContext sender, DragEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.dragEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.dragEventHandler_1((object) sender, e);
  }

  public event EventHandler DragLeave;

  public virtual void OnDragLeave(CellContext sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_9 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_9((object) sender, e);
  }

  public event DragEventHandler DragOver;

  public virtual void OnDragOver(CellContext sender, DragEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.dragEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.dragEventHandler_2((object) sender, e);
  }

  public event GiveFeedbackEventHandler GiveFeedback;

  public virtual void OnGiveFeedback(CellContext sender, GiveFeedbackEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.giveFeedbackEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.giveFeedbackEventHandler_0((object) sender, e);
  }
}

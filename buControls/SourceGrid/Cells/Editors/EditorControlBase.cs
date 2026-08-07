// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.EditorControlBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public abstract class EditorControlBase : EditorBase
{
  private Control control_0;
  internal GridVirtual gridVirtual_0;
  internal LinkedControlValue linkedControlValue_0;
  private bool bool_6 = false;

  public EditorControlBase(System.Type p_Type)
    : base(p_Type)
  {
    this.control_0 = this.CreateControl();
    if (this.Control == null)
      throw new SourceGridException("Control cannot be null");
    this.Control.Hide();
  }

  public Control Control => this.control_0;

  public GridVirtual Grid => this.gridVirtual_0;

  protected abstract Control CreateControl();

  internal override void vmethod_0(CellContext cellContext_1)
  {
    base.vmethod_0(cellContext_1);
    if (this.Control == null)
      throw new SourceGridException("Control cannot be null");
    if ((this.IsEditing ? 0 : (this.EnableEdit ? 1 : 0)) == 0)
      return;
    if (this.EditCell != null)
      throw new SourceGridException("There is already a Cell in edit state");
    if (!Class39.smethod_154(this))
      Class39.smethod_676(this, cellContext_1.Grid);
    this.linkedControlValue_0.Position = cellContext_1.Position;
    cellContext_1.Grid.ArrangeLinkedControls();
    this.OnStartingEdit(cellContext_1, this.Control);
    this.SetEditCell(cellContext_1);
    this.SafeSetEditValue(cellContext_1.Cell.Model.ValueModel.GetValue(cellContext_1));
    this.ShowControl(this.Control);
  }

  protected virtual void OnStartingEdit(CellContext cellContext, Control editorControl)
  {
    if (!this.UseCellViewProperties)
      return;
    editorControl.BackColor = cellContext.Cell.View.BackColor;
    editorControl.ForeColor = cellContext.Cell.View.ForeColor;
    editorControl.Font = cellContext.Cell.View.Font;
  }

  protected virtual void ShowControl(Control editorControl)
  {
    editorControl.Show();
    editorControl.BringToFront();
    editorControl.Focus();
  }

  public override bool ApplyEdit()
  {
    bool flag;
    if (this.IsEditing)
    {
      try
      {
        flag = this.SetCellValue(this.EditCellContext, this.GetEditedValue());
      }
      catch (Exception ex)
      {
        this.OnEditException(new ExceptionEventArgs(ex));
        flag = false;
      }
    }
    else
      flag = true;
    return flag;
  }

  internal override bool vmethod_1(bool bool_7)
  {
    if (!this.IsEditing)
      return true;
    if (this.bool_6)
      return false;
    this.bool_6 = true;
    try
    {
      bool flag = true;
      if (bool_7)
        this.UndoEditValue();
      if (this.Control.ContainsFocus && !this.EditCellContext.Grid.Focus())
        flag = false;
      if ((!flag ? 0 : (!bool_7 ? 1 : 0)) != 0)
        flag = this.ApplyEdit();
      if (flag)
      {
        Class39.smethod_272(this);
        this.linkedControlValue_0.Position = Position.Empty;
        this.SetEditCell(CellContext.Empty);
      }
      else if (!this.Control.ContainsFocus)
        this.Control.Focus();
      return flag;
    }
    finally
    {
      this.bool_6 = false;
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      if (!this.IsEditing)
        return;
      this.EditCellContext.EndEdit(false);
    }
    catch (Exception ex)
    {
      this.OnEditException(new ExceptionEventArgs(ex));
    }
  }

  internal void method_6(object sender, KeyPressEventArgs e)
  {
    if (e.Handled)
      return;
    this.OnKeyPress(e);
  }

  public virtual void UndoEditValue()
  {
    if (this.EditCell == null)
      throw new SourceGridException("Not in edit state");
    this.SafeSetEditValue(this.EditCell.Model.ValueModel.GetValue(this.EditCellContext));
  }

  public void SafeSetEditValue(object editValue)
  {
    try
    {
      this.SetEditValue(editValue);
    }
    catch (Exception ex)
    {
      this.EditCellContext.Grid.OnUserException(new ExceptionEventArgs((Exception) new EditingCellException(ex)));
      this.SetEditValue(this.DefaultValue);
    }
  }

  public abstract override object GetEditedValue();

  public abstract void SetEditValue(object editValue);

  public event KeyPressEventHandler KeyPress;

  protected virtual void OnKeyPress(KeyPressEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (e.Handled || this.keyPressEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyPressEventHandler_0((object) this, e);
  }

  public sealed override void SendCharToEditor(char key)
  {
    KeyPressEventArgs e = new KeyPressEventArgs(key);
    this.OnKeyPress(e);
    if (e.Handled)
      return;
    this.OnSendCharToEditor(e.KeyChar);
  }

  protected abstract void OnSendCharToEditor(char key);

  public override Size GetMinimumSize(CellContext cellContext)
  {
    return this.Control.GetPreferredSize(Size.Empty);
  }
}

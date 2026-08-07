// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.EditorBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class EditorBase(Type p_Type) : ValidatorTypeConverter(p_Type)
{
  private CellContext cellContext_0 = CellContext.Empty;
  private string string_2 = "#ERROR!";
  private bool bool_3 = true;
  private EditableMode editableMode_0 = EditableMode.Default;
  private bool bool_4 = true;
  private bool bool_5 = true;

  public CellContext EditCellContext => this.cellContext_0;

  public ICellVirtual EditCell => this.cellContext_0.Cell;

  public Position EditPosition => this.cellContext_0.Position;

  protected void SetEditCell(CellContext cellContext) => this.cellContext_0 = cellContext;

  public bool IsErrorString(string p_str) => p_str == this.ErrorString;

  public string ErrorString
  {
    get => this.string_2;
    set => this.string_2 = value;
  }

  public bool EnableEdit
  {
    get => this.bool_3;
    set => this.bool_3 = value;
  }

  public EditableMode EditableMode
  {
    get => this.editableMode_0;
    set => this.editableMode_0 = value;
  }

  public virtual bool EnableCellDrawOnEdit
  {
    get => this.bool_4;
    set => this.bool_4 = value;
  }

  public virtual bool UseCellViewProperties
  {
    get => this.bool_5;
    set => this.bool_5 = value;
  }

  public bool IsEditing => this.EditCell != null;

  internal virtual void vmethod_0(CellContext cellContext_1)
  {
    if (cellContext_1.Cell == null)
      throw new ArgumentNullException("cellContext.Cell");
    if (cellContext_1.Grid == null)
      throw new ArgumentNullException("cellContext.Grid");
    if (cellContext_1.Grid.Selection.ActivePosition != cellContext_1.Position)
      throw new SourceGridException("Cell must have the focus");
  }

  public virtual bool ApplyEdit() => true;

  internal virtual bool vmethod_1(bool bool_6) => true;

  public virtual object GetEditedValue()
  {
    throw new SourceGridException("No valid cell editor found");
  }

  public virtual void ClearCell(CellContext cellContext)
  {
    this.SetCellValue(cellContext, this.DefaultValue);
  }

  public virtual bool SetCellValue(CellContext cellContext, object p_NewValue)
  {
    bool flag;
    if (this.EnableEdit)
    {
      ValidatingCellEventArgs e = cellContext.Cell != null ? new ValidatingCellEventArgs(cellContext, p_NewValue) : throw new SourceGridException("Invalid CellContext, cell is null");
      this.OnValidating(e);
      if (!e.Cancel)
      {
        object p_Value = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
        try
        {
          cellContext.Cell.Model.ValueModel.SetValue(cellContext, this.ObjectToValue(e.NewValue));
          this.OnValidated(new CellContextEventArgs(cellContext));
        }
        catch (Exception ex)
        {
          this.OnEditException(new ExceptionEventArgs(ex));
          cellContext.Cell.Model.ValueModel.SetValue(cellContext, p_Value);
          e.Cancel = true;
        }
      }
      flag = !e.Cancel;
    }
    else
      flag = false;
    return flag;
  }

  protected void OnValidated(CellContextEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cellContextEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cellContextEventHandler_0((object) this, e);
  }

  protected void OnValidating(ValidatingCellEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.validatingCellEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.validatingCellEventHandler_0((object) this, e);
  }

  [Obsolete("You should use the Control.Validating event")]
  public event ValidatingCellEventHandler Validating
  {
    add => this.method_1(value);
    remove => this.method_2(value);
  }

  [Obsolete("You should use the Control.Validated event")]
  public event CellContextEventHandler Validated
  {
    add => this.method_3(value);
    remove => this.method_4(value);
  }

  public event ExceptionEventHandler EditException;

  protected virtual void OnEditException(ExceptionEventArgs e)
  {
    Debug.WriteLine("Exception on editing cell: " + e.Exception.ToString());
    // ISSUE: reference to a compiler-generated field
    if (this.exceptionEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.exceptionEventHandler_0((object) this, e);
  }

  public virtual void SendCharToEditor(char key)
  {
  }

  public virtual Size GetMinimumSize(CellContext cellContext) => Size.Empty;
}

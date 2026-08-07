// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.CheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class CheckBox : CellVirtual
{
  public CheckBox()
  {
    this.View = (IView) SourceGrid.Cells.Views.CheckBox.Default;
    this.AddController((IController) SourceGrid.Cells.Controllers.CheckBox.Default);
    this.AddController((IController) MouseInvalidate.Default);
    this.Editor = new EditorBase(typeof (bool));
    this.Editor.EditableMode = EditableMode.None;
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.CheckBox());
  }
}

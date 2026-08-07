// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.CheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;
using System.Runtime.CompilerServices;

#nullable disable
namespace SourceGrid.Cells;

public class CheckBox : Cell
{
  public CheckBox()
    : this((string) null, new bool?(false))
  {
  }

  public CheckBox(string caption, bool? checkValue)
    : base((object) checkValue)
  {
    if ((caption == null ? 0 : (caption.Length > 0 ? 1 : 0)) != 0)
      this.View = (IView) SourceGrid.Cells.Views.CheckBox.MiddleLeftAlign;
    else
      this.View = (IView) SourceGrid.Cells.Views.CheckBox.Default;
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.CheckBox());
    this.AddController((IController) SourceGrid.Cells.Controllers.CheckBox.Default);
    this.AddController((IController) MouseInvalidate.Default);
    this.Editor = new EditorBase(typeof (bool));
    this.Editor.EditableMode = EditableMode.None;
    this.Caption = caption;
  }

  [SpecialName]
  private SourceGrid.Cells.Models.CheckBox method_2()
  {
    return (SourceGrid.Cells.Models.CheckBox) this.Model.FindModel(typeof (SourceGrid.Cells.Models.CheckBox));
  }

  public bool? Checked
  {
    get => this.method_2().GetCheckBoxStatus(this.GetContext()).Checked;
    set => this.method_2().SetCheckedValue(this.GetContext(), value);
  }

  public string Caption
  {
    get => this.method_2().Caption;
    set => this.method_2().Caption = value;
  }
}

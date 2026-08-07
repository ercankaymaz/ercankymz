// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class RichTextBox : CellVirtual
{
  public RichTextBox()
  {
    this.View = (IView) SourceGrid.Cells.Views.RichTextBox.Default;
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.RichTextBox());
    this.AddController((IController) SourceGrid.Cells.Controllers.RichTextBox.Default);
    this.Editor = (EditorBase) new SourceGrid.Cells.Editors.RichTextBox();
  }
}

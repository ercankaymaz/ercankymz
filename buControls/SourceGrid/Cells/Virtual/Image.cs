// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.Image
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class Image : CellVirtual
{
  public Image()
  {
    this.Model.AddModel((IModel) ValueImage.Default);
    this.Editor = (EditorBase) ImagePicker.Default;
  }
}

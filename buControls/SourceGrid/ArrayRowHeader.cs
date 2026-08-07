// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayRowHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

#nullable disable
namespace SourceGrid;

public class ArrayRowHeader : RowHeader
{
  public ArrayRowHeader()
  {
    this.Model.AddModel((IModel) new ArrayRowHeaderModel());
    this.ResizeEnabled = false;
  }
}

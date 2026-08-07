// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayColumnHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

#nullable disable
namespace SourceGrid;

public class ArrayColumnHeader : ColumnHeader
{
  public ArrayColumnHeader()
  {
    this.Model.AddModel((IModel) new ArrayColumnHeaderModel());
    this.AutomaticSortEnabled = false;
    this.ResizeEnabled = false;
  }
}

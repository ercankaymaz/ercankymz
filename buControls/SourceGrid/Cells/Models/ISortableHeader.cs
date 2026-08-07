// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ISortableHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;

#nullable disable
namespace SourceGrid.Cells.Models;

public interface ISortableHeader : IModel
{
  SortStatus GetSortStatus(CellContext cellContext);

  void SetSortMode(CellContext cellContext, HeaderSortStyle pStyle);
}

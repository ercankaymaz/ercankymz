// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayColumns
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class ArrayColumns(ArrayGrid grid) : ColumnInfoCollection((GridVirtual) grid)
{
  public ArrayGrid Grid => (ArrayGrid) base.Grid;
}

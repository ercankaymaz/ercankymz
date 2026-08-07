// Decompiled with JetBrains decompiler
// Type: SourceGrid.Exporter.CSV
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.Globalization;
using System.IO;

#nullable disable
namespace SourceGrid.Exporter;

public class CSV
{
  private string string_0;
  private string string_1;

  public CSV()
  {
    this.string_0 = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
    this.string_1 = Environment.NewLine;
  }

  public string FieldSeparator
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public string LineSeparator
  {
    get => this.string_1;
    set => this.string_1 = value;
  }

  public virtual void Export(GridVirtual grid, TextWriter stream)
  {
    for (int index1 = 0; index1 < grid.Rows.Count; ++index1)
    {
      for (int index2 = 0; index2 < grid.Columns.Count; ++index2)
      {
        if (index2 > 0)
          stream.Write(this.string_0);
        ICellVirtual cell = grid.GetCell(index1, index2);
        Position pPosition = new Position(index1, index2);
        this.ExportCSVCell(new CellContext(grid, pPosition, cell), stream);
      }
      stream.Write(this.string_1);
    }
  }

  protected virtual void ExportCSVCell(CellContext context, TextWriter stream)
  {
    if (context.Cell != null)
    {
      string str = (context.DisplayText ?? string.Empty).Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
      stream.Write(str);
    }
    else
      stream.Write("");
  }
}

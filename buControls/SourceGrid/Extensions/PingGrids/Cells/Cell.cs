// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.Cells.Cell
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;
using System;

#nullable disable
namespace SourceGrid.Extensions.PingGrids.Cells;

public class Cell : CellVirtual
{
  public Cell() => this.Model.AddModel((IModel) new PingGridValueModel());

  public static ICellVirtual Create(Type type, bool editable)
  {
    ICellVirtual cellVirtual;
    if (type == typeof (bool))
    {
      cellVirtual = (ICellVirtual) new CheckBox();
    }
    else
    {
      cellVirtual = (ICellVirtual) new Cell();
      cellVirtual.Editor = Factory.Create(type);
    }
    if (cellVirtual.Editor != null)
    {
      cellVirtual.Editor.AllowNull = true;
      cellVirtual.Editor.EnableEdit = editable;
    }
    return cellVirtual;
  }
}

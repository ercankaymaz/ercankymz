// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayColumnHeaderModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;

#nullable disable
namespace SourceGrid;

public class ArrayColumnHeaderModel : IValueModel, IModel
{
  public virtual object GetValue(CellContext cellContext)
  {
    return (object) (cellContext.Position.Column - cellContext.Grid.FixedColumns);
  }

  public virtual void SetValue(CellContext cellContext, object p_Value)
  {
    throw new ApplicationException("Not supported");
  }
}

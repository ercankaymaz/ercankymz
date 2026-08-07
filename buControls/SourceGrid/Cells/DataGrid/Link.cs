// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.DataGrid.Link
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;

#nullable disable
namespace SourceGrid.Cells.DataGrid;

public class Link : SourceGrid.Cells.Virtual.Link
{
  public Link() => this.Model.AddModel((IModel) new DataGridValueModel());
}

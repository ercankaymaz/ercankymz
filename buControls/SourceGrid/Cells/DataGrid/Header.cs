// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.DataGrid.Header
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;

#nullable disable
namespace SourceGrid.Cells.DataGrid;

public class Header : SourceGrid.Cells.Virtual.Header
{
  public Header() => this.Model.AddModel((IModel) new NullValueModel());
}

// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.Cells.Image
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;

#nullable disable
namespace SourceGrid.Extensions.PingGrids.Cells;

public class Image : SourceGrid.Cells.Virtual.Image
{
  public Image() => this.Model.AddModel((IModel) new PingGridValueModel());
}

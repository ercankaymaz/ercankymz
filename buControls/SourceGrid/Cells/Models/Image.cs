// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.Image
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Cells.Models;

public class Image : IModel, IImage
{
  private System.Drawing.Image image;

  public Image()
  {
  }

  public Image(System.Drawing.Image image) => this.image = image;

  public System.Drawing.Image GetImage(CellContext cellContext) => this.image;

  public System.Drawing.Image ImageValue
  {
    get => this.image;
    set => this.image = value;
  }
}

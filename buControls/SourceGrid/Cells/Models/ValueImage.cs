// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.ValueImage
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;

#nullable disable
namespace SourceGrid.Cells.Models;

public class ValueImage : IModel, IImage
{
  public static readonly ValueImage Default = new ValueImage();
  private ValidatorTypeConverter validatorTypeConverter_0 = new ValidatorTypeConverter(typeof (System.Drawing.Image));

  public System.Drawing.Image GetImage(CellContext cellContext)
  {
    return (System.Drawing.Image) this.validatorTypeConverter_0.ObjectToValue(cellContext.Cell.Model.ValueModel.GetValue(cellContext));
  }
}

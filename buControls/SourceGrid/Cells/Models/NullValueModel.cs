// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.NullValueModel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Cells.Models;

public class NullValueModel : IValueModel, IModel
{
  public static readonly NullValueModel Default = new NullValueModel();

  public object GetValue(CellContext cellContext) => (object) null;

  public void SetValue(CellContext cellContext, object p_Value)
  {
    throw new ApplicationException("This model doesn't support editing");
  }

  public string GetDisplayText(CellContext cellContext) => (string) null;
}

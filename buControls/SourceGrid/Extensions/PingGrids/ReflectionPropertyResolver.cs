// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.ReflectionPropertyResolver
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Reflection;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class ReflectionPropertyResolver : IPropertyResolver
{
  public static ReflectionPropertyResolver SharedInstance = new ReflectionPropertyResolver();

  public object ReadValue(object obj, string propertyPath)
  {
    PropertyInfo property = obj.GetType().GetProperty(propertyPath);
    return !(property == (PropertyInfo) null) ? property.GetValue(obj, (object[]) null) : (object) string.Empty;
  }
}

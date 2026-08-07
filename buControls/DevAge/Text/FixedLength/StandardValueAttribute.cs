// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.StandardValueAttribute
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class StandardValueAttribute : Attribute
{
  private object standardValue;

  public StandardValueAttribute(object standardValue) => this.standardValue = standardValue;

  public object StandardValue
  {
    get => this.standardValue;
    set => this.standardValue = value;
  }
}

// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.ValueMappingAttribute
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ValueMappingAttribute : Attribute
{
  private string string_0;
  private object object_0;

  public ValueMappingAttribute(string stringValue, object fieldValue)
  {
    this.StringValue = stringValue;
    this.FieldValue = fieldValue;
  }

  public string StringValue
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public object FieldValue
  {
    get => this.object_0;
    set => this.object_0 = value;
  }
}

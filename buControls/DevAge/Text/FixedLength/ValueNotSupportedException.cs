// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.ValueNotSupportedException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace DevAge.Text.FixedLength;

[Serializable]
public class ValueNotSupportedException : DevAgeApplicationException
{
  public ValueNotSupportedException(string value, Type type)
    : base($"Value {value} not supported, type is {type.Name}")
  {
  }

  protected ValueNotSupportedException(
    SerializationInfo p_Info,
    StreamingContext p_StreamingContext)
    : base(p_Info, p_StreamingContext)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.FieldStringConvertException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace DevAge.Text.FixedLength;

[Serializable]
public class FieldStringConvertException : DevAgeApplicationException
{
  public FieldStringConvertException(string name, object value, Exception innerException)
    : base($"Failed to convert to string field {name} '{Class39.smethod_765(value)}' - {innerException.Message}", innerException)
  {
  }

  protected FieldStringConvertException(
    SerializationInfo p_Info,
    StreamingContext p_StreamingContext)
    : base(p_Info, p_StreamingContext)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.FailedPropertyGetFieldException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace DevAge.Text.FixedLength;

[Serializable]
public class FailedPropertyGetFieldException : DevAgeApplicationException
{
  public FailedPropertyGetFieldException(string field, Exception innerException)
    : base($"Failed to get property for field {field} - {innerException.Message}", innerException)
  {
  }

  protected FailedPropertyGetFieldException(
    SerializationInfo p_Info,
    StreamingContext p_StreamingContext)
    : base(p_Info, p_StreamingContext)
  {
  }
}

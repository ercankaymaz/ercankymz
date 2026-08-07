// Decompiled with JetBrains decompiler
// Type: DevAge.DevAgeApplicationException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace DevAge;

[Serializable]
public class DevAgeApplicationException : ApplicationException
{
  public DevAgeApplicationException(string p_strErrDescription)
    : base(p_strErrDescription)
  {
  }

  public DevAgeApplicationException(string p_strErrDescription, Exception p_InnerException)
    : base(p_strErrDescription, p_InnerException)
  {
  }

  protected DevAgeApplicationException(
    SerializationInfo p_Info,
    StreamingContext p_StreamingContext)
    : base(p_Info, p_StreamingContext)
  {
  }
}

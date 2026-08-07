// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

[Serializable]
public class LmsException : Exception
{
  public LmsException()
  {
  }

  public LmsException(string message)
    : base(message)
  {
  }

  public LmsException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected LmsException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}

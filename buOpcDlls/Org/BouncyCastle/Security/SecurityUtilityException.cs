// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.SecurityUtilityException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Security;

[Serializable]
public class SecurityUtilityException : Exception
{
  public SecurityUtilityException()
  {
  }

  public SecurityUtilityException(string message)
    : base(message)
  {
  }

  public SecurityUtilityException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected SecurityUtilityException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}

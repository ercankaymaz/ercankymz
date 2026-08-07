// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathBuilderException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Pkix;

[Serializable]
public class PkixCertPathBuilderException : GeneralSecurityException
{
  public PkixCertPathBuilderException()
  {
  }

  public PkixCertPathBuilderException(string message)
    : base(message)
  {
  }

  public PkixCertPathBuilderException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected PkixCertPathBuilderException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}

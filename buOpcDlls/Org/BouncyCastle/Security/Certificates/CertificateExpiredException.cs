// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.Certificates.CertificateExpiredException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Security.Certificates;

[Serializable]
public class CertificateExpiredException : CertificateException
{
  public CertificateExpiredException()
  {
  }

  public CertificateExpiredException(string message)
    : base(message)
  {
  }

  public CertificateExpiredException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected CertificateExpiredException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathValidatorException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Pkix;

[Serializable]
public class PkixCertPathValidatorException : GeneralSecurityException
{
  protected readonly int m_index = -1;

  public PkixCertPathValidatorException()
  {
  }

  public PkixCertPathValidatorException(string message)
    : base(message)
  {
  }

  public PkixCertPathValidatorException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  public PkixCertPathValidatorException(string message, Exception innerException, int index)
    : base(message, innerException)
  {
    this.m_index = index >= -1 ? index : throw new ArgumentException("cannot be < -1", nameof (index));
  }

  protected PkixCertPathValidatorException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
    this.m_index = info.GetInt32("index");
  }

  public override void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    base.GetObjectData(info, context);
    info.AddValue("index", this.m_index);
  }

  public int Index => this.m_index;
}

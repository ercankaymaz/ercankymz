// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public abstract class NtruKeyParameters : AsymmetricKeyParameter
{
  private readonly NtruParameters m_parameters;

  internal NtruKeyParameters(bool privateKey, NtruParameters parameters)
    : base(privateKey)
  {
    this.m_parameters = parameters;
  }

  public NtruParameters Parameters => this.m_parameters;

  public abstract byte[] GetEncoded();
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public sealed class PicnicPrivateKeyParameters : PicnicKeyParameters
{
  private readonly byte[] m_privateKey;

  public PicnicPrivateKeyParameters(PicnicParameters parameters, byte[] skEncoded)
    : base(true, parameters)
  {
    this.m_privateKey = Arrays.Clone(skEncoded);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.m_privateKey);
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikePrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikePrivateKeyParameters : SikeKeyParameters
{
  private readonly byte[] privateKey;

  public SikePrivateKeyParameters(SikeParameters param, byte[] privateKey)
    : base(true, param)
  {
    this.privateKey = Arrays.Clone(privateKey);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.privateKey);

  public byte[] GetPrivateKey() => Arrays.Clone(this.privateKey);
}

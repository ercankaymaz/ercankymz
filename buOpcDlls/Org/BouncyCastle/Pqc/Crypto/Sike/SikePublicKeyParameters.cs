// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikePublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikePublicKeyParameters : SikeKeyParameters
{
  public readonly byte[] publicKey;

  public SikePublicKeyParameters(SikeParameters param, byte[] publicKey)
    : base(false, param)
  {
    this.publicKey = Arrays.Clone(publicKey);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.publicKey);

  public byte[] GetPublicKey() => Arrays.Clone(this.publicKey);
}

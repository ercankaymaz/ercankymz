// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmcePublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmcePublicKeyParameters : CmceKeyParameters
{
  internal readonly byte[] publicKey;

  public CmcePublicKeyParameters(CmceParameters parameters, byte[] publicKey)
    : base(false, parameters)
  {
    this.publicKey = Arrays.Clone(publicKey);
  }

  public byte[] GetPublicKey() => Arrays.Clone(this.publicKey);

  public byte[] GetEncoded() => this.GetPublicKey();
}

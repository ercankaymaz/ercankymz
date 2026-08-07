// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public sealed class FalconPrivateKeyParameters : FalconKeyParameters
{
  private readonly byte[] pk;
  private readonly byte[] f;
  private readonly byte[] g;
  private readonly byte[] F;

  public FalconPrivateKeyParameters(
    FalconParameters parameters,
    byte[] f,
    byte[] g,
    byte[] F,
    byte[] pk_encoded)
    : base(true, parameters)
  {
    this.f = Arrays.Clone(f);
    this.g = Arrays.Clone(g);
    this.F = Arrays.Clone(F);
    this.pk = Arrays.Clone(pk_encoded);
  }

  public byte[] GetEncoded() => Arrays.ConcatenateAll(this.f, this.g, this.F);

  public byte[] GetPublicKey() => Arrays.Clone(this.pk);

  public byte[] GetSpolyLittleF() => Arrays.Clone(this.f);

  public byte[] GetG() => Arrays.Clone(this.g);

  public byte[] GetSpolyBigF() => Arrays.Clone(this.F);
}

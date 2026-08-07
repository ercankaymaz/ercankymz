// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public sealed class HqcPublicKeyParameters : HqcKeyParameters
{
  private byte[] pk;

  public HqcPublicKeyParameters(HqcParameters param, byte[] pk)
    : base(false, param)
  {
    this.pk = Arrays.Clone(pk);
  }

  public byte[] PublicKey => Arrays.Clone(this.pk);

  public byte[] GetEncoded() => this.PublicKey;
}

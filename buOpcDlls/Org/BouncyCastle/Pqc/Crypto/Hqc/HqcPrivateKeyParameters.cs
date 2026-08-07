// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public sealed class HqcPrivateKeyParameters : HqcKeyParameters
{
  private byte[] sk;

  public HqcPrivateKeyParameters(HqcParameters param, byte[] sk)
    : base(true, param)
  {
    this.sk = Arrays.Clone(sk);
  }

  public byte[] PrivateKey => Arrays.Clone(this.sk);

  public byte[] GetEncoded() => this.PrivateKey;
}

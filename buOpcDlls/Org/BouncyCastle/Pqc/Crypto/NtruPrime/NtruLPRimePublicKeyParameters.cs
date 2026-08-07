// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.NtruLPRimePublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public sealed class NtruLPRimePublicKeyParameters : NtruLPRimeKeyParameters
{
  internal byte[] pubKey;

  public NtruLPRimePublicKeyParameters(NtruLPRimeParameters primeParameters, byte[] pubKey)
    : base(false, primeParameters)
  {
    this.pubKey = Arrays.Clone(pubKey);
  }

  public byte[] GetPublicKey() => Arrays.Clone(this.pubKey);

  public byte[] GetEncoded() => this.GetPublicKey();
}

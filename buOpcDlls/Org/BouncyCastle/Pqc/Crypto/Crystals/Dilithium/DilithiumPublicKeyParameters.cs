// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public sealed class DilithiumPublicKeyParameters : DilithiumKeyParameters
{
  internal byte[] rho;
  internal byte[] t1;

  public DilithiumPublicKeyParameters(DilithiumParameters parameters, byte[] pkEncoded)
    : base(false, parameters)
  {
    this.rho = Arrays.CopyOfRange(pkEncoded, 0, 32 /*0x20*/);
    this.t1 = Arrays.CopyOfRange(pkEncoded, 32 /*0x20*/, pkEncoded.Length);
  }

  public DilithiumPublicKeyParameters(DilithiumParameters parameters, byte[] rho, byte[] t1)
    : base(false, parameters)
  {
    this.rho = Arrays.Clone(rho);
    this.t1 = Arrays.Clone(t1);
  }

  public byte[] GetEncoded() => Arrays.Concatenate(this.rho, this.t1);

  internal byte[] Rho => this.rho;

  internal byte[] T1 => this.t1;
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public sealed class FalconPublicKeyParameters : FalconKeyParameters
{
  private readonly byte[] publicKey;

  public FalconPublicKeyParameters(FalconParameters parameters, byte[] h)
    : base(false, parameters)
  {
    this.publicKey = Arrays.Clone(h);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.publicKey);
}

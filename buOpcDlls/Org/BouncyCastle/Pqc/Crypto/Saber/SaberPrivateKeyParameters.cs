// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public sealed class SaberPrivateKeyParameters : SaberKeyParameters
{
  private readonly byte[] privateKey;

  public SaberPrivateKeyParameters(SaberParameters parameters, byte[] privateKey)
    : base(true, parameters)
  {
    this.privateKey = Arrays.Clone(privateKey);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.privateKey);

  public byte[] GetPrivateKey() => Arrays.Clone(this.privateKey);
}

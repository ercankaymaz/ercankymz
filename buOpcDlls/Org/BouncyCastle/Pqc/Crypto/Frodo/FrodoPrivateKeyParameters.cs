// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public sealed class FrodoPrivateKeyParameters : FrodoKeyParameters
{
  internal byte[] privateKey;

  public FrodoPrivateKeyParameters(FrodoParameters parameters, byte[] privateKey)
    : base(true, parameters)
  {
    this.privateKey = Arrays.Clone(privateKey);
  }

  public byte[] GetPrivateKey() => Arrays.Clone(this.privateKey);

  public byte[] GetEncoded() => Arrays.Clone(this.privateKey);
}

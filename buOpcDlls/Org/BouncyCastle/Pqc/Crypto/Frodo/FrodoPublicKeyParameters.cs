// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public sealed class FrodoPublicKeyParameters : FrodoKeyParameters
{
  internal readonly byte[] m_publicKey;

  public FrodoPublicKeyParameters(FrodoParameters parameters, byte[] publicKey)
    : base(false, parameters)
  {
    this.m_publicKey = Arrays.Clone(publicKey);
  }

  public byte[] GetPublicKey() => Arrays.Clone(this.m_publicKey);

  public byte[] GetEncoded() => this.GetPublicKey();
}

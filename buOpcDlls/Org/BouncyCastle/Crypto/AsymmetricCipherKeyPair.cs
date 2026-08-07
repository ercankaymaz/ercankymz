// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class AsymmetricCipherKeyPair
{
  private readonly AsymmetricKeyParameter publicParameter;
  private readonly AsymmetricKeyParameter privateParameter;

  public AsymmetricCipherKeyPair(
    AsymmetricKeyParameter publicParameter,
    AsymmetricKeyParameter privateParameter)
  {
    if (publicParameter.IsPrivate)
      throw new ArgumentException("Expected a public key", nameof (publicParameter));
    if (!privateParameter.IsPrivate)
      throw new ArgumentException("Expected a private key", nameof (privateParameter));
    this.publicParameter = publicParameter;
    this.privateParameter = privateParameter;
  }

  public AsymmetricKeyParameter Public => this.publicParameter;

  public AsymmetricKeyParameter Private => this.privateParameter;
}

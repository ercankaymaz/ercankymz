// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPrivateKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpPrivateKey
{
  private readonly long keyID;
  private readonly PublicKeyPacket publicKeyPacket;
  private readonly AsymmetricKeyParameter privateKey;

  public PgpPrivateKey(
    long keyID,
    PublicKeyPacket publicKeyPacket,
    AsymmetricKeyParameter privateKey)
  {
    if (!privateKey.IsPrivate)
      throw new ArgumentException("Expected a private key", nameof (privateKey));
    this.keyID = keyID;
    this.publicKeyPacket = publicKeyPacket;
    this.privateKey = privateKey;
  }

  public long KeyId => this.keyID;

  public PublicKeyPacket PublicKeyPacket => this.publicKeyPacket;

  public AsymmetricKeyParameter Key => this.privateKey;
}

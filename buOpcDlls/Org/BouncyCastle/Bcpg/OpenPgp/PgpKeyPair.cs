// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKeyPair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpKeyPair
{
  private readonly PgpPublicKey pub;
  private readonly PgpPrivateKey priv;

  public PgpKeyPair(
    PublicKeyAlgorithmTag algorithm,
    AsymmetricCipherKeyPair keyPair,
    DateTime time)
    : this(algorithm, keyPair.Public, keyPair.Private, time)
  {
  }

  public PgpKeyPair(
    PublicKeyAlgorithmTag algorithm,
    AsymmetricKeyParameter pubKey,
    AsymmetricKeyParameter privKey,
    DateTime time)
  {
    this.pub = new PgpPublicKey(algorithm, pubKey, time);
    this.priv = new PgpPrivateKey(this.pub.KeyId, this.pub.PublicKeyPacket, privKey);
  }

  public PgpKeyPair(PgpPublicKey pub, PgpPrivateKey priv)
  {
    this.pub = pub;
    this.priv = priv;
  }

  public long KeyId => this.pub.KeyId;

  public PgpPublicKey PublicKey => this.pub;

  public PgpPrivateKey PrivateKey => this.priv;
}

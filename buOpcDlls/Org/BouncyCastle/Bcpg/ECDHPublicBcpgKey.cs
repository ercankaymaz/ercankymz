// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ECDHPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ECDHPublicBcpgKey : ECPublicBcpgKey
{
  private byte reserved;
  private HashAlgorithmTag hashFunctionId;
  private SymmetricKeyAlgorithmTag symAlgorithmId;

  public ECDHPublicBcpgKey(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
    if (bcpgIn.ReadByte() != 3)
      throw new InvalidOperationException("KDF parameters size of 3 expected.");
    byte[] buffer = new byte[3];
    bcpgIn.ReadFully(buffer);
    this.reserved = buffer[0];
    this.hashFunctionId = (HashAlgorithmTag) buffer[1];
    this.symAlgorithmId = (SymmetricKeyAlgorithmTag) buffer[2];
    this.VerifyHashAlgorithm();
    this.VerifySymmetricKeyAlgorithm();
  }

  public ECDHPublicBcpgKey(
    DerObjectIdentifier oid,
    ECPoint point,
    HashAlgorithmTag hashAlgorithm,
    SymmetricKeyAlgorithmTag symmetricKeyAlgorithm)
    : base(oid, point)
  {
    this.reserved = (byte) 1;
    this.hashFunctionId = hashAlgorithm;
    this.symAlgorithmId = symmetricKeyAlgorithm;
    this.VerifyHashAlgorithm();
    this.VerifySymmetricKeyAlgorithm();
  }

  public ECDHPublicBcpgKey(
    DerObjectIdentifier oid,
    BigInteger point,
    HashAlgorithmTag hashAlgorithm,
    SymmetricKeyAlgorithmTag symmetricKeyAlgorithm)
    : base(oid, point)
  {
    this.reserved = (byte) 1;
    this.hashFunctionId = hashAlgorithm;
    this.symAlgorithmId = symmetricKeyAlgorithm;
    this.VerifyHashAlgorithm();
    this.VerifySymmetricKeyAlgorithm();
  }

  public virtual byte Reserved => this.reserved;

  public virtual HashAlgorithmTag HashAlgorithm => this.hashFunctionId;

  public virtual SymmetricKeyAlgorithmTag SymmetricKeyAlgorithm => this.symAlgorithmId;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    base.Encode(bcpgOut);
    bcpgOut.WriteByte((byte) 3);
    bcpgOut.WriteByte(this.reserved);
    bcpgOut.WriteByte((byte) this.hashFunctionId);
    bcpgOut.WriteByte((byte) this.symAlgorithmId);
  }

  private void VerifyHashAlgorithm()
  {
    switch (this.hashFunctionId)
    {
      case HashAlgorithmTag.Sha256:
      case HashAlgorithmTag.Sha384:
      case HashAlgorithmTag.Sha512:
        break;
      default:
        throw new InvalidOperationException("Hash algorithm must be SHA-256 or stronger.");
    }
  }

  private void VerifySymmetricKeyAlgorithm()
  {
    switch (this.symAlgorithmId)
    {
      case SymmetricKeyAlgorithmTag.Aes128:
      case SymmetricKeyAlgorithmTag.Aes192:
      case SymmetricKeyAlgorithmTag.Aes256:
        break;
      default:
        throw new InvalidOperationException("Symmetric key algorithm must be AES-128 or stronger.");
    }
  }
}

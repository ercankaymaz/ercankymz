// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.PrivateKeyInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class PrivateKeyInfo : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly AlgorithmIdentifier privateKeyAlgorithm;
  private readonly Asn1OctetString privateKey;
  private readonly Asn1Set attributes;
  private readonly DerBitString publicKey;

  public static PrivateKeyInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return PrivateKeyInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static PrivateKeyInfo GetInstance(object obj)
  {
    if (obj == null)
      return (PrivateKeyInfo) null;
    return obj is PrivateKeyInfo ? (PrivateKeyInfo) obj : new PrivateKeyInfo(Asn1Sequence.GetInstance(obj));
  }

  private static int GetVersionValue(DerInteger version)
  {
    BigInteger bigInteger = version.Value;
    if (bigInteger.CompareTo(BigInteger.Zero) < 0 || bigInteger.CompareTo(BigInteger.One) > 0)
      throw new ArgumentException("invalid version for private key info", nameof (version));
    return bigInteger.IntValue;
  }

  public PrivateKeyInfo(AlgorithmIdentifier privateKeyAlgorithm, Asn1Encodable privateKey)
    : this(privateKeyAlgorithm, privateKey, (Asn1Set) null, (byte[]) null)
  {
  }

  public PrivateKeyInfo(
    AlgorithmIdentifier privateKeyAlgorithm,
    Asn1Encodable privateKey,
    Asn1Set attributes)
    : this(privateKeyAlgorithm, privateKey, attributes, (byte[]) null)
  {
  }

  public PrivateKeyInfo(
    AlgorithmIdentifier privateKeyAlgorithm,
    Asn1Encodable privateKey,
    Asn1Set attributes,
    byte[] publicKey)
  {
    this.version = new DerInteger(publicKey != null ? BigInteger.One : BigInteger.Zero);
    this.privateKeyAlgorithm = privateKeyAlgorithm;
    this.privateKey = (Asn1OctetString) new DerOctetString(privateKey);
    this.attributes = attributes;
    this.publicKey = publicKey == null ? (DerBitString) null : new DerBitString(publicKey);
  }

  private PrivateKeyInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    this.version = DerInteger.GetInstance((object) CollectionUtilities.RequireNext<Asn1Encodable>(enumerator));
    int versionValue = PrivateKeyInfo.GetVersionValue(this.version);
    this.privateKeyAlgorithm = AlgorithmIdentifier.GetInstance((object) CollectionUtilities.RequireNext<Asn1Encodable>(enumerator));
    this.privateKey = Asn1OctetString.GetInstance((object) CollectionUtilities.RequireNext<Asn1Encodable>(enumerator));
    int num = -1;
    while (enumerator.MoveNext())
    {
      Asn1TaggedObject current = (Asn1TaggedObject) enumerator.Current;
      int tagNo = current.TagNo;
      num = tagNo > num ? tagNo : throw new ArgumentException("invalid optional field in private key info", nameof (seq));
      if (tagNo != 0)
      {
        if (tagNo != 1)
          throw new ArgumentException("unknown optional field in private key info", nameof (seq));
        if (versionValue < 1)
          throw new ArgumentException("'publicKey' requires version v2(1) or later", nameof (seq));
        this.publicKey = DerBitString.GetInstance(current, false);
      }
      else
        this.attributes = Asn1Set.GetInstance(current, false);
    }
  }

  public virtual DerInteger Version => this.version;

  public virtual Asn1Set Attributes => this.attributes;

  public virtual bool HasPublicKey => this.publicKey != null;

  public virtual AlgorithmIdentifier PrivateKeyAlgorithm => this.privateKeyAlgorithm;

  public virtual Asn1OctetString PrivateKeyData => this.privateKey;

  public virtual Asn1Object ParsePrivateKey()
  {
    return Asn1Object.FromByteArray(this.privateKey.GetOctets());
  }

  public virtual Asn1Object ParsePublicKey()
  {
    return this.publicKey != null ? Asn1Object.FromByteArray(this.publicKey.GetOctets()) : (Asn1Object) null;
  }

  public virtual DerBitString PublicKeyData => this.publicKey;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.privateKeyAlgorithm,
      (Asn1Encodable) this.privateKey
    });
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.attributes);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.publicKey);
    return (Asn1Object) new DerSequence(elementVector);
  }
}

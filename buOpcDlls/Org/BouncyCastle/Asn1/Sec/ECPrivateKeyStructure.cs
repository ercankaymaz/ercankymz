// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Sec.ECPrivateKeyStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Sec;

public class ECPrivateKeyStructure : Asn1Encodable
{
  private readonly Asn1Sequence m_seq;

  public static ECPrivateKeyStructure GetInstance(object obj)
  {
    if (obj == null)
      return (ECPrivateKeyStructure) null;
    return obj is ECPrivateKeyStructure privateKeyStructure ? privateKeyStructure : new ECPrivateKeyStructure(Asn1Sequence.GetInstance(obj));
  }

  private ECPrivateKeyStructure(Asn1Sequence seq)
  {
    this.m_seq = seq ?? throw new ArgumentNullException(nameof (seq));
  }

  public ECPrivateKeyStructure(int orderBitLength, BigInteger key)
    : this(orderBitLength, key, (Asn1Encodable) null)
  {
  }

  public ECPrivateKeyStructure(int orderBitLength, BigInteger key, Asn1Encodable parameters)
    : this(orderBitLength, key, (DerBitString) null, parameters)
  {
  }

  public ECPrivateKeyStructure(
    int orderBitLength,
    BigInteger key,
    DerBitString publicKey,
    Asn1Encodable parameters)
  {
    if (key == null)
      throw new ArgumentNullException(nameof (key));
    if (orderBitLength < key.BitLength)
      throw new ArgumentException("must be >= key bitlength", nameof (orderBitLength));
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) new DerInteger(1), (Asn1Encodable) new DerOctetString(BigIntegers.AsUnsignedByteArray((orderBitLength + 7) / 8, key)));
    elementVector.AddOptionalTagged(true, 0, parameters);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) publicKey);
    this.m_seq = (Asn1Sequence) new DerSequence(elementVector);
  }

  public virtual BigInteger GetKey()
  {
    return new BigInteger(1, ((Asn1OctetString) this.m_seq[1]).GetOctets());
  }

  public virtual DerBitString GetPublicKey() => (DerBitString) this.GetObjectInTag(1, 3);

  public virtual Asn1Object GetParameters() => this.GetObjectInTag(0, -1);

  private Asn1Object GetObjectInTag(int tagNo, int baseTagNo)
  {
    foreach (Asn1Encodable asn1Encodable in this.m_seq)
    {
      if (asn1Encodable.ToAsn1Object() is Asn1TaggedObject asn1Object && asn1Object.HasContextTag(tagNo))
        return baseTagNo < 0 ? asn1Object.GetExplicitBaseObject().ToAsn1Object() : asn1Object.GetBaseUniversal(true, baseTagNo);
    }
    return (Asn1Object) null;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_seq;
}

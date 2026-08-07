// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.EncryptedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class EncryptedData : Asn1Encodable
{
  private readonly Asn1Sequence data;

  public static EncryptedData GetInstance(object obj)
  {
    switch (obj)
    {
      case EncryptedData _:
        return (EncryptedData) obj;
      case Asn1Sequence _:
        return new EncryptedData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private EncryptedData(Asn1Sequence seq)
  {
    if (seq.Count != 2)
      throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.data = ((DerInteger) seq[0]).HasValue(0) ? (Asn1Sequence) seq[1] : throw new ArgumentException("sequence not version 0");
  }

  public EncryptedData(
    DerObjectIdentifier contentType,
    AlgorithmIdentifier encryptionAlgorithm,
    Asn1Encodable content)
  {
    this.data = (Asn1Sequence) new BerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) contentType,
      (Asn1Encodable) encryptionAlgorithm.ToAsn1Object(),
      (Asn1Encodable) new BerTaggedObject(false, 0, content)
    });
  }

  public DerObjectIdentifier ContentType => (DerObjectIdentifier) this.data[0];

  public AlgorithmIdentifier EncryptionAlgorithm
  {
    get => AlgorithmIdentifier.GetInstance((object) this.data[1]);
  }

  public Asn1OctetString Content
  {
    get
    {
      return this.data.Count == 3 ? Asn1OctetString.GetInstance((Asn1TaggedObject) this.data[2], false) : (Asn1OctetString) null;
    }
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new BerSequence((Asn1Encodable) new DerInteger(0), (Asn1Encodable) this.data);
  }
}

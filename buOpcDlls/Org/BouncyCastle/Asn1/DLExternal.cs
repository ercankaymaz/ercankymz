// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLExternal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLExternal : DerExternal
{
  internal DLExternal(Asn1EncodableVector vector)
    : base(vector)
  {
  }

  internal DLExternal(Asn1Sequence sequence)
    : base(sequence)
  {
  }

  internal DLExternal(
    DerObjectIdentifier directReference,
    DerInteger indirectReference,
    Asn1ObjectDescriptor dataValueDescriptor,
    Asn1TaggedObject externalData)
    : base(directReference, indirectReference, dataValueDescriptor, externalData)
  {
  }

  internal DLExternal(
    DerObjectIdentifier directReference,
    DerInteger indirectReference,
    Asn1ObjectDescriptor dataValueDescriptor,
    int encoding,
    Asn1Object externalData)
    : base(directReference, indirectReference, dataValueDescriptor, encoding, externalData)
  {
  }

  internal override Asn1Sequence BuildSequence()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(4);
    elementVector.AddOptional((Asn1Encodable) this.directReference, (Asn1Encodable) this.indirectReference, (Asn1Encodable) this.dataValueDescriptor);
    elementVector.Add((Asn1Encodable) new DLTaggedObject(this.encoding == 0, this.encoding, (Asn1Encodable) this.externalContent));
    return (Asn1Sequence) new DLSequence(elementVector);
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 2 == encoding ? base.GetEncoding(encoding) : this.BuildSequence().GetEncodingImplicit(encoding, 0, 8);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 2 == encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : this.BuildSequence().GetEncodingImplicit(encoding, tagClass, tagNo);
  }
}

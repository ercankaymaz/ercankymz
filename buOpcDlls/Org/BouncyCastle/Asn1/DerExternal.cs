// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerExternal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerExternal : Asn1Object
{
  internal readonly DerObjectIdentifier directReference;
  internal readonly DerInteger indirectReference;
  internal readonly Asn1ObjectDescriptor dataValueDescriptor;
  internal readonly int encoding;
  internal readonly Asn1Object externalContent;

  public static DerExternal GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerExternal) null;
      case DerExternal instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerExternal asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerExternal) DerExternal.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct external from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static DerExternal GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerExternal) DerExternal.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerExternal(Asn1EncodableVector vector)
    : this((Asn1Sequence) new BerSequence(vector))
  {
  }

  public DerExternal(Asn1Sequence sequence)
  {
    int num = 0;
    Asn1Object objFromSequence = DerExternal.GetObjFromSequence(sequence, 0);
    if (objFromSequence is DerObjectIdentifier)
    {
      this.directReference = (DerObjectIdentifier) objFromSequence;
      objFromSequence = DerExternal.GetObjFromSequence(sequence, ++num);
    }
    if (objFromSequence is DerInteger)
    {
      this.indirectReference = (DerInteger) objFromSequence;
      objFromSequence = DerExternal.GetObjFromSequence(sequence, ++num);
    }
    if (!(objFromSequence is Asn1TaggedObject))
    {
      this.dataValueDescriptor = (Asn1ObjectDescriptor) objFromSequence;
      objFromSequence = DerExternal.GetObjFromSequence(sequence, ++num);
    }
    if (sequence.Count != num + 1)
      throw new ArgumentException("input sequence too large", nameof (sequence));
    Asn1TaggedObject encoding = objFromSequence is Asn1TaggedObject ? (Asn1TaggedObject) objFromSequence : throw new ArgumentException("No tagged object found in sequence. Structure doesn't seem to be of type External", nameof (sequence));
    this.encoding = DerExternal.CheckEncoding(encoding.TagNo);
    this.externalContent = DerExternal.GetExternalContent(encoding);
  }

  [Obsolete("Pass 'externalData' at type Asn1TaggedObject")]
  public DerExternal(
    DerObjectIdentifier directReference,
    DerInteger indirectReference,
    Asn1ObjectDescriptor dataValueDescriptor,
    DerTaggedObject externalData)
    : this(directReference, indirectReference, dataValueDescriptor, (Asn1TaggedObject) externalData)
  {
  }

  public DerExternal(
    DerObjectIdentifier directReference,
    DerInteger indirectReference,
    Asn1ObjectDescriptor dataValueDescriptor,
    Asn1TaggedObject externalData)
  {
    this.directReference = directReference;
    this.indirectReference = indirectReference;
    this.dataValueDescriptor = dataValueDescriptor;
    this.encoding = DerExternal.CheckEncoding(externalData.TagNo);
    this.externalContent = DerExternal.GetExternalContent(externalData);
  }

  public DerExternal(
    DerObjectIdentifier directReference,
    DerInteger indirectReference,
    Asn1ObjectDescriptor dataValueDescriptor,
    int encoding,
    Asn1Object externalData)
  {
    this.directReference = directReference;
    this.indirectReference = indirectReference;
    this.dataValueDescriptor = dataValueDescriptor;
    this.encoding = DerExternal.CheckEncoding(encoding);
    this.externalContent = DerExternal.CheckExternalContent(encoding, externalData);
  }

  internal virtual Asn1Sequence BuildSequence()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(4);
    elementVector.AddOptional((Asn1Encodable) this.directReference, (Asn1Encodable) this.indirectReference, (Asn1Encodable) this.dataValueDescriptor);
    elementVector.Add((Asn1Encodable) new DerTaggedObject(this.encoding == 0, this.encoding, (Asn1Encodable) this.externalContent));
    return (Asn1Sequence) new DerSequence(elementVector);
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return this.BuildSequence().GetEncodingImplicit(2, 0, 8);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return this.BuildSequence().GetEncodingImplicit(2, tagClass, tagNo);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return this.BuildSequence().GetEncodingDerImplicit(0, 8);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return this.BuildSequence().GetEncodingDerImplicit(tagClass, tagNo);
  }

  protected override int Asn1GetHashCode()
  {
    return Objects.GetHashCode((object) this.directReference) ^ Objects.GetHashCode((object) this.indirectReference) ^ Objects.GetHashCode((object) this.dataValueDescriptor) ^ this.encoding ^ this.externalContent.GetHashCode();
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerExternal derExternal && object.Equals((object) this.directReference, (object) derExternal.directReference) && object.Equals((object) this.indirectReference, (object) derExternal.indirectReference) && object.Equals((object) this.dataValueDescriptor, (object) derExternal.dataValueDescriptor) && this.encoding == derExternal.encoding && this.externalContent.Equals(derExternal.externalContent);
  }

  public Asn1ObjectDescriptor DataValueDescriptor => this.dataValueDescriptor;

  public DerObjectIdentifier DirectReference => this.directReference;

  public int Encoding => this.encoding;

  public Asn1Object ExternalContent => this.externalContent;

  public DerInteger IndirectReference => this.indirectReference;

  private static Asn1ObjectDescriptor CheckDataValueDescriptor(Asn1Object dataValueDescriptor)
  {
    switch (dataValueDescriptor)
    {
      case Asn1ObjectDescriptor _:
        return (Asn1ObjectDescriptor) dataValueDescriptor;
      case DerGraphicString _:
        return new Asn1ObjectDescriptor((DerGraphicString) dataValueDescriptor);
      default:
        throw new ArgumentException("incompatible type for data-value-descriptor", nameof (dataValueDescriptor));
    }
  }

  private static int CheckEncoding(int encoding)
  {
    return encoding >= 0 && encoding <= 2 ? encoding : throw new InvalidOperationException("invalid encoding value: " + encoding.ToString());
  }

  private static Asn1Object CheckExternalContent(int tagNo, Asn1Object externalContent)
  {
    if (tagNo == 1)
      return Asn1OctetString.Meta.Instance.CheckedCast(externalContent);
    return tagNo != 2 ? externalContent : DerBitString.Meta.Instance.CheckedCast(externalContent);
  }

  private static Asn1Object GetExternalContent(Asn1TaggedObject encoding)
  {
    int tagClass = encoding.TagClass;
    int tagNo = encoding.TagNo;
    if (128 /*0x80*/ != tagClass)
      throw new ArgumentException("invalid tag: " + Asn1Utilities.GetTagText(tagClass, tagNo), nameof (encoding));
    switch (tagNo)
    {
      case 0:
        return encoding.GetExplicitBaseObject().ToAsn1Object();
      case 1:
        return (Asn1Object) Asn1OctetString.GetInstance(encoding, false);
      case 2:
        return (Asn1Object) DerBitString.GetInstance(encoding, false);
      default:
        throw new ArgumentException("invalid tag: " + Asn1Utilities.GetTagText(tagClass, tagNo), nameof (encoding));
    }
  }

  private static Asn1Object GetObjFromSequence(Asn1Sequence sequence, int index)
  {
    if (sequence.Count <= index)
      throw new ArgumentException("too few objects in input sequence", nameof (sequence));
    return sequence[index].ToAsn1Object();
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerExternal.Meta();

    private Meta()
      : base(typeof (DerExternal), 8)
    {
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) sequence.ToAsn1External();
    }
  }
}

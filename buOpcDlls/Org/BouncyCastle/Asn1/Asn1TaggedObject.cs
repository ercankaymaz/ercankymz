// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1TaggedObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1TaggedObject : Asn1Object, Asn1TaggedObjectParser, IAsn1Convertible
{
  private const int DeclaredExplicit = 1;
  private const int DeclaredImplicit = 2;
  private const int ParsedExplicit = 3;
  private const int ParsedImplicit = 4;
  internal readonly int m_explicitness;
  internal readonly int m_tagClass;
  internal readonly int m_tagNo;
  internal readonly Asn1Encodable m_object;

  public static Asn1TaggedObject GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1TaggedObject) null;
      case Asn1TaggedObject instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1TaggedObject asn1Object)
          return asn1Object;
        break;
      case byte[] data:
        try
        {
          return Asn1TaggedObject.CheckedCast(Asn1Object.FromByteArray(data));
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct tagged object from byte[]", nameof (obj), (Exception) ex);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1TaggedObject GetInstance(object obj, int tagClass)
  {
    return Asn1Utilities.CheckTagClass(Asn1TaggedObject.CheckInstance(obj), tagClass);
  }

  public static Asn1TaggedObject GetInstance(object obj, int tagClass, int tagNo)
  {
    return Asn1Utilities.CheckTag(Asn1TaggedObject.CheckInstance(obj), tagClass, tagNo);
  }

  public static Asn1TaggedObject GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetExplicitContextBaseTagged(Asn1TaggedObject.CheckInstance(taggedObject, declaredExplicit));
  }

  public static Asn1TaggedObject GetInstance(
    Asn1TaggedObject taggedObject,
    int tagClass,
    bool declaredExplicit)
  {
    return Asn1Utilities.GetExplicitBaseTagged(Asn1TaggedObject.CheckInstance(taggedObject, declaredExplicit), tagClass);
  }

  public static Asn1TaggedObject GetInstance(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    bool declaredExplicit)
  {
    return Asn1Utilities.GetExplicitBaseTagged(Asn1TaggedObject.CheckInstance(taggedObject, declaredExplicit), tagClass, tagNo);
  }

  private static Asn1TaggedObject CheckInstance(object obj)
  {
    return Asn1TaggedObject.GetInstance(obj ?? throw new ArgumentNullException(nameof (obj)));
  }

  private static Asn1TaggedObject CheckInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    if (!declaredExplicit)
      throw new ArgumentException("this method not valid for implicitly tagged tagged objects");
    return taggedObject ?? throw new ArgumentNullException(nameof (taggedObject));
  }

  protected Asn1TaggedObject(bool isExplicit, int tagNo, Asn1Encodable obj)
    : this(isExplicit, 128 /*0x80*/, tagNo, obj)
  {
  }

  protected Asn1TaggedObject(bool isExplicit, int tagClass, int tagNo, Asn1Encodable obj)
    : this(isExplicit ? 1 : 2, tagClass, tagNo, obj)
  {
  }

  internal Asn1TaggedObject(int explicitness, int tagClass, int tagNo, Asn1Encodable obj)
  {
    if (obj == null)
      throw new ArgumentNullException(nameof (obj));
    if (tagClass == 0 || (tagClass & 192 /*0xC0*/) != tagClass)
      throw new ArgumentException("invalid tag class: " + tagClass.ToString(), nameof (tagClass));
    this.m_explicitness = obj is IAsn1Choice ? 1 : explicitness;
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
    this.m_object = obj;
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    if (!(asn1Object is Asn1TaggedObject asn1TaggedObject) || this.m_tagNo != asn1TaggedObject.m_tagNo || this.m_tagClass != asn1TaggedObject.m_tagClass || this.m_explicitness != asn1TaggedObject.m_explicitness && this.IsExplicit() != asn1TaggedObject.IsExplicit())
      return false;
    Asn1Object asn1Object1 = this.m_object.ToAsn1Object();
    Asn1Object asn1Object2 = asn1TaggedObject.m_object.ToAsn1Object();
    if (asn1Object1 == asn1Object2)
      return true;
    if (this.IsExplicit())
      return asn1Object1.CallAsn1Equals(asn1Object2);
    try
    {
      return Arrays.AreEqual(this.GetEncoded(), asn1TaggedObject.GetEncoded());
    }
    catch (IOException ex)
    {
      return false;
    }
  }

  protected override int Asn1GetHashCode()
  {
    return this.m_tagClass * 7919 ^ this.m_tagNo ^ (this.IsExplicit() ? 15 : 240 /*0xF0*/) ^ this.m_object.ToAsn1Object().CallAsn1GetHashCode();
  }

  public int TagClass => this.m_tagClass;

  public int TagNo => this.m_tagNo;

  public bool HasContextTag() => this.m_tagClass == 128 /*0x80*/;

  public bool HasContextTag(int tagNo) => this.m_tagClass == 128 /*0x80*/ && this.m_tagNo == tagNo;

  public bool HasTag(int tagClass, int tagNo)
  {
    return this.m_tagClass == tagClass && this.m_tagNo == tagNo;
  }

  public bool HasTagClass(int tagClass) => this.m_tagClass == tagClass;

  public bool IsExplicit()
  {
    switch (this.m_explicitness)
    {
      case 1:
      case 3:
        return true;
      default:
        return false;
    }
  }

  internal bool IsParsed()
  {
    switch (this.m_explicitness)
    {
      case 3:
      case 4:
        return true;
      default:
        return false;
    }
  }

  public Asn1Object GetObject()
  {
    Asn1Utilities.CheckTagClass(this, 128 /*0x80*/);
    return this.m_object.ToAsn1Object();
  }

  public Asn1Encodable GetBaseObject() => this.m_object;

  public Asn1Encodable GetExplicitBaseObject()
  {
    if (!this.IsExplicit())
      throw new InvalidOperationException("object implicit - explicit expected.");
    return this.m_object;
  }

  public Asn1TaggedObject GetExplicitBaseTagged()
  {
    if (!this.IsExplicit())
      throw new InvalidOperationException("object implicit - explicit expected.");
    return Asn1TaggedObject.CheckedCast(this.m_object.ToAsn1Object());
  }

  public Asn1TaggedObject GetImplicitBaseTagged(int baseTagClass, int baseTagNo)
  {
    if (baseTagClass == 0 || (baseTagClass & 192 /*0xC0*/) != baseTagClass)
      throw new ArgumentException("invalid base tag class: " + baseTagClass.ToString(), nameof (baseTagClass));
    switch (this.m_explicitness)
    {
      case 1:
        throw new InvalidOperationException("object explicit - implicit expected.");
      case 2:
        return Asn1Utilities.CheckTag(Asn1TaggedObject.CheckedCast(this.m_object.ToAsn1Object()), baseTagClass, baseTagNo);
      default:
        return this.ReplaceTag(baseTagClass, baseTagNo);
    }
  }

  public Asn1Object GetBaseUniversal(bool declaredExplicit, int tagNo)
  {
    Asn1UniversalType universalType = Asn1UniversalTypes.Get(tagNo) ?? throw new ArgumentException("unsupported UNIVERSAL tag number: " + tagNo.ToString(), nameof (tagNo));
    return this.GetBaseUniversal(declaredExplicit, universalType);
  }

  internal Asn1Object GetBaseUniversal(bool declaredExplicit, Asn1UniversalType universalType)
  {
    if (declaredExplicit)
    {
      if (!this.IsExplicit())
        throw new InvalidOperationException("object explicit - implicit expected.");
      return universalType.CheckedCast(this.m_object.ToAsn1Object());
    }
    if (1 == this.m_explicitness)
      throw new InvalidOperationException("object explicit - implicit expected.");
    Asn1Object asn1Object = this.m_object.ToAsn1Object();
    switch (this.m_explicitness)
    {
      case 3:
        return universalType.FromImplicitConstructed(this.RebuildConstructed(asn1Object));
      case 4:
        return asn1Object is Asn1Sequence sequence ? universalType.FromImplicitConstructed(sequence) : universalType.FromImplicitPrimitive((DerOctetString) asn1Object);
      default:
        return universalType.CheckedCast(asn1Object);
    }
  }

  public IAsn1Convertible ParseBaseUniversal(bool declaredExplicit, int baseTagNo)
  {
    Asn1Object baseUniversal = this.GetBaseUniversal(declaredExplicit, baseTagNo);
    switch (baseTagNo)
    {
      case 3:
        return (IAsn1Convertible) ((DerBitString) baseUniversal).Parser;
      case 4:
        return (IAsn1Convertible) ((Asn1OctetString) baseUniversal).Parser;
      case 16 /*0x10*/:
        return (IAsn1Convertible) ((Asn1Sequence) baseUniversal).Parser;
      case 17:
        return (IAsn1Convertible) ((Asn1Set) baseUniversal).Parser;
      default:
        return (IAsn1Convertible) baseUniversal;
    }
  }

  public IAsn1Convertible ParseExplicitBaseObject()
  {
    return (IAsn1Convertible) this.GetExplicitBaseObject();
  }

  public Asn1TaggedObjectParser ParseExplicitBaseTagged()
  {
    return (Asn1TaggedObjectParser) this.GetExplicitBaseTagged();
  }

  public Asn1TaggedObjectParser ParseImplicitBaseTagged(int baseTagClass, int baseTagNo)
  {
    return (Asn1TaggedObjectParser) this.GetImplicitBaseTagged(baseTagClass, baseTagNo);
  }

  public override string ToString()
  {
    return Asn1Utilities.GetTagText(this.m_tagClass, this.m_tagNo) + this.m_object?.ToString();
  }

  internal abstract string Asn1Encoding { get; }

  internal abstract Asn1Sequence RebuildConstructed(Asn1Object asn1Object);

  internal abstract Asn1TaggedObject ReplaceTag(int tagClass, int tagNo);

  internal static Asn1Object CreateConstructedDL(
    int tagClass,
    int tagNo,
    Asn1EncodableVector contentsElements)
  {
    return contentsElements.Count != 1 ? (Asn1Object) new DLTaggedObject(4, tagClass, tagNo, (Asn1Encodable) DLSequence.FromVector(contentsElements)) : (Asn1Object) new DLTaggedObject(3, tagClass, tagNo, contentsElements[0]);
  }

  internal static Asn1Object CreateConstructedIL(
    int tagClass,
    int tagNo,
    Asn1EncodableVector contentsElements)
  {
    return contentsElements.Count != 1 ? (Asn1Object) new BerTaggedObject(4, tagClass, tagNo, (Asn1Encodable) BerSequence.FromVector(contentsElements)) : (Asn1Object) new BerTaggedObject(3, tagClass, tagNo, contentsElements[0]);
  }

  internal static Asn1Object CreatePrimitive(int tagClass, int tagNo, byte[] contentsOctets)
  {
    return (Asn1Object) new DLTaggedObject(4, tagClass, tagNo, (Asn1Encodable) new DerOctetString(contentsOctets));
  }

  private static Asn1TaggedObject CheckedCast(Asn1Object asn1Object)
  {
    return asn1Object is Asn1TaggedObject asn1TaggedObject ? asn1TaggedObject : throw new InvalidOperationException("unexpected object: " + Platform.GetTypeName((object) asn1Object));
  }
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Utilities
{
  internal static Asn1TaggedObject CheckTagClass(Asn1TaggedObject taggedObject, int tagClass)
  {
    return taggedObject.HasTagClass(tagClass) ? taggedObject : throw new InvalidOperationException($"Expected {Asn1Utilities.GetTagClassText(tagClass)} tag but found {Asn1Utilities.GetTagClassText(taggedObject)}");
  }

  internal static Asn1TaggedObjectParser CheckTagClass(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass)
  {
    if (taggedObjectParser.TagClass != tagClass)
      throw new InvalidOperationException($"Expected {Asn1Utilities.GetTagClassText(tagClass)} tag but found {Asn1Utilities.GetTagClassText(taggedObjectParser)}");
    return taggedObjectParser;
  }

  internal static Asn1TaggedObject CheckTag(Asn1TaggedObject taggedObject, int tagClass, int tagNo)
  {
    if (!taggedObject.HasTag(tagClass, tagNo))
      throw new InvalidOperationException($"Expected {Asn1Utilities.GetTagText(tagClass, tagNo)} tag but found {Asn1Utilities.GetTagText(taggedObject)}");
    return taggedObject;
  }

  internal static Asn1TaggedObjectParser CheckTag(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo)
  {
    if (!taggedObjectParser.HasTag(tagClass, tagNo))
      throw new InvalidOperationException($"Expected {Asn1Utilities.GetTagText(tagClass, tagNo)} tag but found {Asn1Utilities.GetTagText(taggedObjectParser)}");
    return taggedObjectParser;
  }

  internal static TChoice GetInstanceFromChoice<TChoice>(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit,
    Func<object, TChoice> constructor)
    where TChoice : Asn1Encodable, IAsn1Choice
  {
    if (!declaredExplicit)
      throw new ArgumentException($"Implicit tagging cannot be used with untagged choice type {Platform.GetTypeName(typeof (TChoice))} (X.680 30.6, 30.8).", nameof (declaredExplicit));
    if (taggedObject == null)
      throw new ArgumentNullException(nameof (taggedObject));
    return constructor((object) taggedObject.GetExplicitBaseObject());
  }

  public static string GetTagClassText(int tagClass)
  {
    switch (tagClass)
    {
      case 64 /*0x40*/:
        return "APPLICATION";
      case 128 /*0x80*/:
        return "CONTEXT";
      case 192 /*0xC0*/:
        return "PRIVATE";
      default:
        return "UNIVERSAL";
    }
  }

  public static string GetTagClassText(Asn1TaggedObject taggedObject)
  {
    return Asn1Utilities.GetTagClassText(taggedObject.TagClass);
  }

  public static string GetTagClassText(Asn1TaggedObjectParser taggedObjectParser)
  {
    return Asn1Utilities.GetTagClassText(taggedObjectParser.TagClass);
  }

  internal static string GetTagText(Asn1Tag tag)
  {
    return Asn1Utilities.GetTagText(tag.TagClass, tag.TagNo);
  }

  public static string GetTagText(Asn1TaggedObject taggedObject)
  {
    return Asn1Utilities.GetTagText(taggedObject.TagClass, taggedObject.TagNo);
  }

  public static string GetTagText(Asn1TaggedObjectParser taggedObjectParser)
  {
    return Asn1Utilities.GetTagText(taggedObjectParser.TagClass, taggedObjectParser.TagNo);
  }

  public static string GetTagText(int tagClass, int tagNo)
  {
    switch (tagClass)
    {
      case 64 /*0x40*/:
        return $"[APPLICATION {tagNo}]";
      case 128 /*0x80*/:
        return $"[CONTEXT {tagNo}]";
      case 192 /*0xC0*/:
        return $"[PRIVATE {tagNo}]";
      default:
        return $"[UNIVERSAL {tagNo}]";
    }
  }

  public static Asn1Encodable GetExplicitBaseObject(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo)
  {
    return Asn1Utilities.CheckTag(taggedObject, tagClass, tagNo).GetExplicitBaseObject();
  }

  public static Asn1Encodable GetExplicitContextBaseObject(Asn1TaggedObject taggedObject, int tagNo)
  {
    return Asn1Utilities.GetExplicitBaseObject(taggedObject, 128 /*0x80*/, tagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1Encodable TryGetExplicitBaseObject(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo)
  {
    return !taggedObject.HasTag(tagClass, tagNo) ? (Asn1Encodable) null : taggedObject.GetExplicitBaseObject();
  }

  public static bool TryGetExplicitBaseObject(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    out Asn1Encodable baseObject)
  {
    bool explicitBaseObject = taggedObject.HasTag(tagClass, tagNo);
    baseObject = explicitBaseObject ? taggedObject.GetExplicitBaseObject() : (Asn1Encodable) null;
    return explicitBaseObject;
  }

  [Obsolete("Will be removed")]
  public static Asn1Encodable TryGetExplicitContextBaseObject(
    Asn1TaggedObject taggedObject,
    int tagNo)
  {
    return Asn1Utilities.TryGetExplicitBaseObject(taggedObject, 128 /*0x80*/, tagNo);
  }

  public static bool TryGetExplicitContextBaseObject(
    Asn1TaggedObject taggedObject,
    int tagNo,
    out Asn1Encodable baseObject)
  {
    return Asn1Utilities.TryGetExplicitBaseObject(taggedObject, 128 /*0x80*/, tagNo, out baseObject);
  }

  public static Asn1TaggedObject GetExplicitBaseTagged(Asn1TaggedObject taggedObject, int tagClass)
  {
    return Asn1Utilities.CheckTagClass(taggedObject, tagClass).GetExplicitBaseTagged();
  }

  public static Asn1TaggedObject GetExplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo)
  {
    return Asn1Utilities.CheckTag(taggedObject, tagClass, tagNo).GetExplicitBaseTagged();
  }

  public static Asn1TaggedObject GetExplicitContextBaseTagged(Asn1TaggedObject taggedObject)
  {
    return Asn1Utilities.GetExplicitBaseTagged(taggedObject, 128 /*0x80*/);
  }

  public static Asn1TaggedObject GetExplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo)
  {
    return Asn1Utilities.GetExplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetExplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass)
  {
    return !taggedObject.HasTagClass(tagClass) ? (Asn1TaggedObject) null : taggedObject.GetExplicitBaseTagged();
  }

  public static bool TryGetExplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    out Asn1TaggedObject baseTagged)
  {
    bool explicitBaseTagged = taggedObject.HasTagClass(tagClass);
    baseTagged = explicitBaseTagged ? taggedObject.GetExplicitBaseTagged() : (Asn1TaggedObject) null;
    return explicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetExplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo)
  {
    return !taggedObject.HasTag(tagClass, tagNo) ? (Asn1TaggedObject) null : taggedObject.GetExplicitBaseTagged();
  }

  public static bool TryGetExplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    out Asn1TaggedObject baseTagged)
  {
    bool explicitBaseTagged = taggedObject.HasTag(tagClass, tagNo);
    baseTagged = explicitBaseTagged ? taggedObject.GetExplicitBaseTagged() : (Asn1TaggedObject) null;
    return explicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetExplicitContextBaseTagged(Asn1TaggedObject taggedObject)
  {
    return Asn1Utilities.TryGetExplicitBaseTagged(taggedObject, 128 /*0x80*/);
  }

  public static bool TryGetExplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    out Asn1TaggedObject baseTagged)
  {
    return Asn1Utilities.TryGetExplicitBaseTagged(taggedObject, 128 /*0x80*/, out baseTagged);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetExplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo)
  {
    return Asn1Utilities.TryGetExplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo);
  }

  public static bool TryGetExplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo,
    out Asn1TaggedObject baseTagged)
  {
    return Asn1Utilities.TryGetExplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo, out baseTagged);
  }

  public static Asn1TaggedObject GetImplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.CheckTag(taggedObject, tagClass, tagNo).GetImplicitBaseTagged(baseTagClass, baseTagNo);
  }

  public static Asn1TaggedObject GetImplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.GetImplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetImplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return !taggedObject.HasTag(tagClass, tagNo) ? (Asn1TaggedObject) null : taggedObject.GetImplicitBaseTagged(baseTagClass, baseTagNo);
  }

  public static bool TryGetImplicitBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo,
    out Asn1TaggedObject baseTagged)
  {
    bool implicitBaseTagged = taggedObject.HasTag(tagClass, tagNo);
    baseTagged = implicitBaseTagged ? taggedObject.GetImplicitBaseTagged(baseTagClass, baseTagNo) : (Asn1TaggedObject) null;
    return implicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObject TryGetImplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.TryGetImplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo);
  }

  public static bool TryGetImplicitContextBaseTagged(
    Asn1TaggedObject taggedObject,
    int tagNo,
    int baseTagClass,
    int baseTagNo,
    out Asn1TaggedObject baseTagged)
  {
    return Asn1Utilities.TryGetImplicitBaseTagged(taggedObject, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo, out baseTagged);
  }

  public static Asn1Object GetBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.CheckTag(taggedObject, tagClass, tagNo).GetBaseUniversal(declaredExplicit, baseTagNo);
  }

  public static Asn1Object GetContextBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.GetBaseUniversal(taggedObject, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1Object TryGetBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return !taggedObject.HasTag(tagClass, tagNo) ? (Asn1Object) null : taggedObject.GetBaseUniversal(declaredExplicit, baseTagNo);
  }

  public static bool TryGetBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo,
    out Asn1Object baseUniversal)
  {
    bool baseUniversal1 = taggedObject.HasTag(tagClass, tagNo);
    baseUniversal = baseUniversal1 ? taggedObject.GetBaseUniversal(declaredExplicit, baseTagNo) : (Asn1Object) null;
    return baseUniversal1;
  }

  [Obsolete("Will be removed")]
  public static Asn1Object TryGetContextBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.TryGetBaseUniversal(taggedObject, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo);
  }

  public static bool TryGetContextBaseUniversal(
    Asn1TaggedObject taggedObject,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo,
    out Asn1Object baseUniversal)
  {
    return Asn1Utilities.TryGetBaseUniversal(taggedObject, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo, out baseUniversal);
  }

  public static Asn1TaggedObjectParser ParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass)
  {
    return Asn1Utilities.CheckTagClass(taggedObjectParser, tagClass).ParseExplicitBaseTagged();
  }

  public static Asn1TaggedObjectParser ParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo)
  {
    return Asn1Utilities.CheckTag(taggedObjectParser, tagClass, tagNo).ParseExplicitBaseTagged();
  }

  public static Asn1TaggedObjectParser ParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser)
  {
    return Asn1Utilities.ParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/);
  }

  public static Asn1TaggedObjectParser ParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo)
  {
    return Asn1Utilities.ParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass)
  {
    return taggedObjectParser.TagClass != tagClass ? (Asn1TaggedObjectParser) null : taggedObjectParser.ParseExplicitBaseTagged();
  }

  public static bool TryParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    out Asn1TaggedObjectParser baseTagged)
  {
    bool explicitBaseTagged = taggedObjectParser.TagClass == tagClass;
    baseTagged = explicitBaseTagged ? taggedObjectParser.ParseExplicitBaseTagged() : (Asn1TaggedObjectParser) null;
    return explicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo)
  {
    return !taggedObjectParser.HasTag(tagClass, tagNo) ? (Asn1TaggedObjectParser) null : taggedObjectParser.ParseExplicitBaseTagged();
  }

  public static bool TryParseExplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    out Asn1TaggedObjectParser baseTagged)
  {
    bool explicitBaseTagged = taggedObjectParser.HasTag(tagClass, tagNo);
    baseTagged = explicitBaseTagged ? taggedObjectParser.ParseExplicitBaseTagged() : (Asn1TaggedObjectParser) null;
    return explicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser)
  {
    return Asn1Utilities.TryParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/);
  }

  public static bool TryParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    out Asn1TaggedObjectParser baseTagged)
  {
    return Asn1Utilities.TryParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, out baseTagged);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo)
  {
    return Asn1Utilities.TryParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo);
  }

  public static bool TryParseExplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    out Asn1TaggedObjectParser baseTagged)
  {
    return Asn1Utilities.TryParseExplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo, out baseTagged);
  }

  public static Asn1TaggedObjectParser ParseImplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.CheckTag(taggedObjectParser, tagClass, tagNo).ParseImplicitBaseTagged(baseTagClass, baseTagNo);
  }

  public static Asn1TaggedObjectParser ParseImplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.ParseImplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo);
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseImplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return !taggedObjectParser.HasTag(tagClass, tagNo) ? (Asn1TaggedObjectParser) null : taggedObjectParser.ParseImplicitBaseTagged(baseTagClass, baseTagNo);
  }

  public static bool TryParseImplicitBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    int baseTagClass,
    int baseTagNo,
    out Asn1TaggedObjectParser baseTagged)
  {
    bool implicitBaseTagged = taggedObjectParser.HasTag(tagClass, tagNo);
    baseTagged = implicitBaseTagged ? taggedObjectParser.ParseImplicitBaseTagged(baseTagClass, baseTagNo) : (Asn1TaggedObjectParser) null;
    return implicitBaseTagged;
  }

  [Obsolete("Will be removed")]
  public static Asn1TaggedObjectParser TryParseImplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    int baseTagClass,
    int baseTagNo)
  {
    return Asn1Utilities.TryParseImplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo);
  }

  public static bool TryParseImplicitContextBaseTagged(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    int baseTagClass,
    int baseTagNo,
    out Asn1TaggedObjectParser baseTagged)
  {
    return Asn1Utilities.TryParseImplicitBaseTagged(taggedObjectParser, 128 /*0x80*/, tagNo, baseTagClass, baseTagNo, out baseTagged);
  }

  public static IAsn1Convertible ParseBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.CheckTag(taggedObjectParser, tagClass, tagNo).ParseBaseUniversal(declaredExplicit, baseTagNo);
  }

  public static IAsn1Convertible ParseContextBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.ParseBaseUniversal(taggedObjectParser, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo);
  }

  [Obsolete("Will be removed")]
  public static IAsn1Convertible TryParseBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return !taggedObjectParser.HasTag(tagClass, tagNo) ? (IAsn1Convertible) null : taggedObjectParser.ParseBaseUniversal(declaredExplicit, baseTagNo);
  }

  public static bool TryParseBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo,
    out IAsn1Convertible baseUniversal)
  {
    bool baseUniversal1 = taggedObjectParser.HasTag(tagClass, tagNo);
    baseUniversal = baseUniversal1 ? taggedObjectParser.ParseBaseUniversal(declaredExplicit, baseTagNo) : (IAsn1Convertible) null;
    return baseUniversal1;
  }

  [Obsolete("Will be removed")]
  public static IAsn1Convertible TryParseContextBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo)
  {
    return Asn1Utilities.TryParseBaseUniversal(taggedObjectParser, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo);
  }

  public static bool TryParseContextBaseUniversal(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    bool declaredExplicit,
    int baseTagNo,
    out IAsn1Convertible baseUniversal)
  {
    return Asn1Utilities.TryParseBaseUniversal(taggedObjectParser, 128 /*0x80*/, tagNo, declaredExplicit, baseTagNo, out baseUniversal);
  }

  public static IAsn1Convertible ParseExplicitBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo)
  {
    return Asn1Utilities.CheckTag(taggedObjectParser, tagClass, tagNo).ParseExplicitBaseObject();
  }

  public static IAsn1Convertible ParseExplicitContextBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo)
  {
    return Asn1Utilities.ParseExplicitBaseObject(taggedObjectParser, 128 /*0x80*/, tagNo);
  }

  [Obsolete("Will be removed")]
  public static IAsn1Convertible TryParseExplicitBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo)
  {
    return !taggedObjectParser.HasTag(tagClass, tagNo) ? (IAsn1Convertible) null : taggedObjectParser.ParseExplicitBaseObject();
  }

  public static bool TryParseExplicitBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagClass,
    int tagNo,
    out IAsn1Convertible baseObject)
  {
    bool explicitBaseObject = taggedObjectParser.HasTag(tagClass, tagNo);
    baseObject = explicitBaseObject ? taggedObjectParser.ParseExplicitBaseObject() : (IAsn1Convertible) null;
    return explicitBaseObject;
  }

  [Obsolete("Will be removed")]
  public static IAsn1Convertible TryParseExplicitContextBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo)
  {
    return Asn1Utilities.TryParseExplicitBaseObject(taggedObjectParser, 128 /*0x80*/, tagNo);
  }

  public static bool TryParseExplicitContextBaseObject(
    Asn1TaggedObjectParser taggedObjectParser,
    int tagNo,
    out IAsn1Convertible baseObject)
  {
    return Asn1Utilities.TryParseExplicitBaseObject(taggedObjectParser, 128 /*0x80*/, tagNo, out baseObject);
  }
}

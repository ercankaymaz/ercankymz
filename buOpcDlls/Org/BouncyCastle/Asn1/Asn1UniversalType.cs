// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1UniversalType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal abstract class Asn1UniversalType : Asn1Type
{
  internal readonly Asn1Tag m_tag;

  internal Asn1UniversalType(Type platformType, int tagNo)
    : base(platformType)
  {
    this.m_tag = Asn1Tag.Create(0, tagNo);
  }

  internal Asn1Object CheckedCast(Asn1Object asn1Object)
  {
    return this.PlatformType.IsInstanceOfType((object) asn1Object) ? asn1Object : throw new InvalidOperationException("unexpected object: " + Platform.GetTypeName((object) asn1Object));
  }

  internal virtual Asn1Object FromImplicitPrimitive(DerOctetString octetString)
  {
    throw new InvalidOperationException("unexpected implicit primitive encoding");
  }

  internal virtual Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
  {
    throw new InvalidOperationException("unexpected implicit constructed encoding");
  }

  internal Asn1Object FromByteArray(byte[] bytes)
  {
    return this.CheckedCast(Asn1Object.FromByteArray(bytes));
  }

  internal Asn1Object GetContextInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return 128 /*0x80*/ == taggedObject.TagClass ? this.CheckedCast(taggedObject.GetBaseUniversal(declaredExplicit, this)) : throw new InvalidOperationException("this method only valid for CONTEXT_SPECIFIC tags");
  }

  internal Asn1Tag Tag => this.m_tag;
}

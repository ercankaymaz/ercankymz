// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1TaggedObjectParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public interface Asn1TaggedObjectParser : IAsn1Convertible
{
  int TagClass { get; }

  int TagNo { get; }

  bool HasContextTag(int tagNo);

  bool HasTag(int tagClass, int tagNo);

  IAsn1Convertible ParseBaseUniversal(bool declaredExplicit, int baseTagNo);

  IAsn1Convertible ParseExplicitBaseObject();

  Asn1TaggedObjectParser ParseExplicitBaseTagged();

  Asn1TaggedObjectParser ParseImplicitBaseTagged(int baseTagClass, int baseTagNo);
}

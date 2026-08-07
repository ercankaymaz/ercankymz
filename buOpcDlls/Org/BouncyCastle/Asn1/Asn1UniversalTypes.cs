// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1UniversalTypes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal sealed class Asn1UniversalTypes
{
  private Asn1UniversalTypes()
  {
  }

  internal static Asn1UniversalType Get(int tagNo)
  {
    switch (tagNo)
    {
      case 1:
        return DerBoolean.Meta.Instance;
      case 2:
        return DerInteger.Meta.Instance;
      case 3:
        return DerBitString.Meta.Instance;
      case 4:
        return Asn1OctetString.Meta.Instance;
      case 5:
        return Asn1Null.Meta.Instance;
      case 6:
        return DerObjectIdentifier.Meta.Instance;
      case 7:
        return Asn1ObjectDescriptor.Meta.Instance;
      case 8:
        return DerExternal.Meta.Instance;
      case 10:
        return DerEnumerated.Meta.Instance;
      case 12:
        return DerUtf8String.Meta.Instance;
      case 13:
        return Asn1RelativeOid.Meta.Instance;
      case 16 /*0x10*/:
        return Asn1Sequence.Meta.Instance;
      case 17:
        return Asn1Set.Meta.Instance;
      case 18:
        return DerNumericString.Meta.Instance;
      case 19:
        return DerPrintableString.Meta.Instance;
      case 20:
        return DerT61String.Meta.Instance;
      case 21:
        return DerVideotexString.Meta.Instance;
      case 22:
        return DerIA5String.Meta.Instance;
      case 23:
        return Asn1UtcTime.Meta.Instance;
      case 24:
        return Asn1GeneralizedTime.Meta.Instance;
      case 25:
        return DerGraphicString.Meta.Instance;
      case 26:
        return DerVisibleString.Meta.Instance;
      case 27:
        return DerGeneralString.Meta.Instance;
      case 28:
        return DerUniversalString.Meta.Instance;
      case 30:
        return DerBmpString.Meta.Instance;
      default:
        return (Asn1UniversalType) null;
    }
  }
}

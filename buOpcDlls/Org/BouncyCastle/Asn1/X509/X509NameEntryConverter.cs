// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509NameEntryConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Encoders;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public abstract class X509NameEntryConverter
{
  protected Asn1Object ConvertHexEncoded(string hexString, int offset)
  {
    return Asn1Object.FromByteArray(Hex.DecodeStrict(hexString, offset, hexString.Length - offset));
  }

  protected bool CanBePrintable(string str) => DerPrintableString.IsPrintableString(str);

  public abstract Asn1Object GetConvertedValue(DerObjectIdentifier oid, string value);
}

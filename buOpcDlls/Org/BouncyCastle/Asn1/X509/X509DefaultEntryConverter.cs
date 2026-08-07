// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509DefaultEntryConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509DefaultEntryConverter : X509NameEntryConverter
{
  public override Asn1Object GetConvertedValue(DerObjectIdentifier oid, string value)
  {
    if (value.Length != 0)
    {
      if (value[0] == '#')
      {
        try
        {
          return this.ConvertHexEncoded(value, 1);
        }
        catch (IOException ex)
        {
          throw new Exception("can't recode value for oid " + oid.Id);
        }
      }
    }
    if (value.Length != 0 && value[0] == '\\')
      value = value.Substring(1);
    if (oid.Equals((Asn1Object) X509Name.EmailAddress) || oid.Equals((Asn1Object) X509Name.DC))
      return (Asn1Object) new DerIA5String(value);
    if (oid.Equals((Asn1Object) X509Name.DateOfBirth))
      return (Asn1Object) new Asn1GeneralizedTime(value);
    return !oid.Equals((Asn1Object) X509Name.C) && !oid.Equals((Asn1Object) X509Name.SerialNumber) && !oid.Equals((Asn1Object) X509Name.DnQualifier) && !oid.Equals((Asn1Object) X509Name.TelephoneNumber) ? (Asn1Object) new DerUtf8String(value) : (Asn1Object) new DerPrintableString(value);
  }
}

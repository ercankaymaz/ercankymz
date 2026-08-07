// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509Extension
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509Extension
{
  internal bool critical;
  internal Asn1OctetString value;

  public X509Extension(DerBoolean critical, Asn1OctetString value)
  {
    this.critical = critical != null ? critical.IsTrue : throw new ArgumentNullException(nameof (critical));
    this.value = value;
  }

  public X509Extension(bool critical, Asn1OctetString value)
  {
    this.critical = critical;
    this.value = value;
  }

  public bool IsCritical => this.critical;

  public Asn1OctetString Value => this.value;

  public Asn1Encodable GetParsedValue() => (Asn1Encodable) X509Extension.ConvertValueToObject(this);

  public override int GetHashCode()
  {
    int hashCode = this.Value.GetHashCode();
    return !this.IsCritical ? ~hashCode : hashCode;
  }

  public override bool Equals(object obj)
  {
    return obj is X509Extension x509Extension && this.Value.Equals((Asn1Object) x509Extension.Value) && this.IsCritical == x509Extension.IsCritical;
  }

  public static Asn1Object ConvertValueToObject(X509Extension ext)
  {
    try
    {
      return Asn1Object.FromByteArray(ext.Value.GetOctets());
    }
    catch (Exception ex)
    {
      throw new ArgumentException("can't convert extension", ex);
    }
  }
}

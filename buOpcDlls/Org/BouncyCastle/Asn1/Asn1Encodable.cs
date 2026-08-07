// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Encodable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Encodable : IAsn1Convertible
{
  public const string Der = "DER";
  public const string Ber = "BER";

  public virtual void EncodeTo(Stream output) => this.ToAsn1Object().EncodeTo(output);

  public virtual void EncodeTo(Stream output, string encoding)
  {
    this.ToAsn1Object().EncodeTo(output, encoding);
  }

  public byte[] GetEncoded() => this.ToAsn1Object().InternalGetEncoded("BER");

  public byte[] GetEncoded(string encoding) => this.ToAsn1Object().InternalGetEncoded(encoding);

  public byte[] GetDerEncoded()
  {
    try
    {
      return this.GetEncoded("DER");
    }
    catch (IOException ex)
    {
      return (byte[]) null;
    }
  }

  public sealed override int GetHashCode() => this.ToAsn1Object().CallAsn1GetHashCode();

  public sealed override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    if (!(obj is IAsn1Convertible asn1Convertible))
      return false;
    Asn1Object asn1Object1 = this.ToAsn1Object();
    Asn1Object asn1Object2 = asn1Convertible.ToAsn1Object();
    if (asn1Object1 == asn1Object2)
      return true;
    return asn1Object2 != null && asn1Object1.CallAsn1Equals(asn1Object2);
  }

  public abstract Asn1Object ToAsn1Object();
}

// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509CrlNumberExtension
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Formats.Asn1;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509CrlNumberExtension : X509Extension
{
  public const string CrlNumberOid = "2.5.29.20";
  private const string kFriendlyName = "CRL Number";

  protected X509CrlNumberExtension()
  {
  }

  public X509CrlNumberExtension(AsnEncodedData encodedExtension, bool critical)
    : this(encodedExtension.Oid, encodedExtension.RawData, critical)
  {
  }

  public X509CrlNumberExtension(string oid, byte[] rawData, bool critical)
    : this(new Oid(oid, "CRL Number"), rawData, critical)
  {
  }

  public X509CrlNumberExtension(Oid oid, byte[] rawData, bool critical)
    : base(oid, rawData, critical)
  {
    this.Decode(rawData);
  }

  public X509CrlNumberExtension(BigInteger crlNumber)
  {
    this.Oid = new Oid("2.5.29.20", "CRL Number");
    this.Critical = false;
    this.CrlNumber = crlNumber;
    this.RawData = this.Encode();
  }

  public override string Format(bool multiLine)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("CRL Number");
    stringBuilder.Append('=');
    stringBuilder.Append((object) this.CrlNumber);
    return stringBuilder.ToString();
  }

  public override void CopyFrom(AsnEncodedData asnEncodedData)
  {
    this.Oid = asnEncodedData != null ? asnEncodedData.Oid : throw new ArgumentNullException(nameof (asnEncodedData));
    this.RawData = asnEncodedData.RawData;
    this.Decode(this.RawData);
  }

  public BigInteger CrlNumber { get; private set; }

  private byte[] Encode()
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.WriteInteger(this.CrlNumber);
    return asnWriter.Encode();
  }

  private void Decode(byte[] data)
  {
    if (!(this.Oid.Value == "2.5.29.20"))
      throw new CryptographicException("Invalid CrlNumberOid.");
    try
    {
      System.Formats.Asn1.AsnReader asnReader = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) data, System.Formats.Asn1.AsnEncodingRules.DER);
      this.CrlNumber = asnReader.ReadInteger();
      asnReader.ThrowIfNotEmpty();
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the CRL Number extension.", (Exception) ex);
    }
  }
}

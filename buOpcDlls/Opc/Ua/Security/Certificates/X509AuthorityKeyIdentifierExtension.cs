// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509AuthorityKeyIdentifierExtension
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
public class X509AuthorityKeyIdentifierExtension : X509Extension
{
  public const string AuthorityKeyIdentifierOid = "2.5.29.1";
  public const string AuthorityKeyIdentifier2Oid = "2.5.29.35";
  private const string kKeyIdentifier = "KeyID";
  private const string kIssuer = "Issuer";
  private const string kSerialNumber = "SerialNumber";
  private const string kFriendlyName = "Authority Key Identifier";
  private byte[] m_keyIdentifier;
  private X500DistinguishedName m_issuer;
  private byte[] m_serialNumber;

  protected X509AuthorityKeyIdentifierExtension()
  {
  }

  public X509AuthorityKeyIdentifierExtension(AsnEncodedData encodedExtension, bool critical)
    : this(encodedExtension.Oid, encodedExtension.RawData, critical)
  {
  }

  public X509AuthorityKeyIdentifierExtension(string oid, byte[] rawData, bool critical)
    : this(new Oid(oid, "Authority Key Identifier"), rawData, critical)
  {
  }

  public X509AuthorityKeyIdentifierExtension(byte[] subjectKeyIdentifier)
  {
    this.m_keyIdentifier = subjectKeyIdentifier != null ? subjectKeyIdentifier : throw new ArgumentNullException(nameof (subjectKeyIdentifier));
    this.Oid = new Oid("2.5.29.35", "Authority Key Identifier");
    this.Critical = false;
    this.RawData = this.Encode();
  }

  public X509AuthorityKeyIdentifierExtension(
    byte[] subjectKeyIdentifier,
    X500DistinguishedName authorityName,
    byte[] serialNumber)
  {
    this.m_issuer = authorityName;
    this.m_keyIdentifier = subjectKeyIdentifier;
    this.m_serialNumber = serialNumber;
    this.Oid = new Oid("2.5.29.35", "Authority Key Identifier");
    this.Critical = false;
    this.RawData = this.Encode();
  }

  public X509AuthorityKeyIdentifierExtension(Oid oid, byte[] rawData, bool critical)
    : base(oid, rawData, critical)
  {
    this.Decode(rawData);
  }

  public override string Format(bool multiLine)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (this.m_keyIdentifier != null && this.m_keyIdentifier.Length != 0)
    {
      if (stringBuilder.Length > 0)
      {
        if (multiLine)
          stringBuilder.AppendLine();
        else
          stringBuilder.Append(", ");
      }
      stringBuilder.Append("KeyID");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_keyIdentifier.ToHexString());
    }
    if (this.m_issuer != null)
    {
      if (multiLine)
        stringBuilder.AppendLine();
      else
        stringBuilder.Append(", ");
      stringBuilder.Append("Issuer");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_issuer.Format(true));
    }
    if (this.m_serialNumber != null && this.m_serialNumber.Length != 0)
    {
      if (stringBuilder.Length > 0 && !multiLine)
        stringBuilder.Append(", ");
      stringBuilder.Append("SerialNumber");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_serialNumber.ToHexString(true));
    }
    return stringBuilder.ToString();
  }

  public override void CopyFrom(AsnEncodedData asnEncodedData)
  {
    this.Oid = asnEncodedData != null ? asnEncodedData.Oid : throw new ArgumentNullException(nameof (asnEncodedData));
    this.RawData = asnEncodedData.RawData;
    this.Decode(asnEncodedData.RawData);
  }

  public string KeyIdentifier => this.m_keyIdentifier.ToHexString();

  public byte[] GetKeyIdentifier() => this.m_keyIdentifier;

  public X500DistinguishedName Issuer => this.m_issuer;

  public string SerialNumber => this.m_serialNumber.ToHexString(true);

  public byte[] GetSerialNumber() => this.m_serialNumber;

  private byte[] Encode()
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.PushSequence();
    if (this.m_keyIdentifier != null)
    {
      System.Formats.Asn1.Asn1Tag asn1Tag = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 0);
      asnWriter.WriteOctetString((System.ReadOnlySpan<byte>) this.m_keyIdentifier, new System.Formats.Asn1.Asn1Tag?(asn1Tag));
    }
    if (this.m_issuer != null)
    {
      System.Formats.Asn1.Asn1Tag asn1Tag1 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 1);
      asnWriter.PushSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
      System.Formats.Asn1.Asn1Tag asn1Tag2 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 4, true);
      asnWriter.PushSetOf(new System.Formats.Asn1.Asn1Tag?(asn1Tag2));
      asnWriter.WriteEncodedValue((System.ReadOnlySpan<byte>) this.m_issuer.RawData);
      asnWriter.PopSetOf(new System.Formats.Asn1.Asn1Tag?(asn1Tag2));
      asnWriter.PopSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
    }
    if (this.m_serialNumber != null)
    {
      System.Formats.Asn1.Asn1Tag asn1Tag = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 2);
      BigInteger bigInteger = new BigInteger(this.m_serialNumber);
      asnWriter.WriteInteger(bigInteger, new System.Formats.Asn1.Asn1Tag?(asn1Tag));
    }
    asnWriter.PopSequence();
    return asnWriter.Encode();
  }

  private void Decode(byte[] data)
  {
    if (!(this.Oid.Value == "2.5.29.1") && !(this.Oid.Value == "2.5.29.35"))
      throw new CryptographicException("Invalid AuthorityKeyIdentifierOid.");
    try
    {
      System.Formats.Asn1.AsnReader asnReader1 = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) data, System.Formats.Asn1.AsnEncodingRules.DER);
      System.Formats.Asn1.AsnReader asnReader2 = asnReader1.ReadSequence();
      asnReader1.ThrowIfNotEmpty();
      if (asnReader2 == null)
        throw new CryptographicException("No valid data in the extension.");
      System.Formats.Asn1.Asn1Tag asn1Tag1 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 0);
      System.Formats.Asn1.Asn1Tag asn1Tag2 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 1, true);
      System.Formats.Asn1.Asn1Tag asn1Tag3 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 2);
      while (asnReader2.HasData)
      {
        System.Formats.Asn1.Asn1Tag asn1Tag4 = asnReader2.PeekTag();
        if (asn1Tag4 == asn1Tag1)
          this.m_keyIdentifier = asnReader2.ReadOctetString(new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
        else if (asn1Tag4 == asn1Tag2)
        {
          System.Formats.Asn1.AsnReader asnReader3 = asnReader2.ReadSequence(new System.Formats.Asn1.Asn1Tag?(new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 1)));
          if (asnReader3 != null)
          {
            System.Formats.Asn1.Asn1Tag asn1Tag5 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 4, true);
            this.m_issuer = new X500DistinguishedName(asnReader3.ReadSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag5)).ReadEncodedValue().ToArray());
            asnReader3.ThrowIfNotEmpty();
          }
        }
        else
          this.m_serialNumber = asn1Tag4 == asn1Tag3 ? asnReader2.ReadInteger(new System.Formats.Asn1.Asn1Tag?(asn1Tag3)).ToByteArray() : throw new AsnContentException("Unknown tag in sequence.");
      }
      asnReader2.ThrowIfNotEmpty();
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the AuthorityKeyIdentifier extension.", (Exception) ex);
    }
  }
}

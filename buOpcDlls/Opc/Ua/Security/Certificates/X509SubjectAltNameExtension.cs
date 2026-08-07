// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509SubjectAltNameExtension
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509SubjectAltNameExtension : X509Extension
{
  public const string SubjectAltNameOid = "2.5.29.7";
  public const string SubjectAltName2Oid = "2.5.29.17";
  private const string kUniformResourceIdentifier = "URL";
  private const string kDnsName = "DNS Name";
  private const string kIpAddress = "IP Address";
  private const string kFriendlyName = "Subject Alternative Name";
  private List<string> m_uris;
  private List<string> m_domainNames;
  private List<string> m_ipAddresses;
  private bool m_decoded;

  protected X509SubjectAltNameExtension()
  {
  }

  public X509SubjectAltNameExtension(AsnEncodedData encodedExtension, bool critical)
    : this(encodedExtension.Oid, encodedExtension.RawData, critical)
  {
  }

  public X509SubjectAltNameExtension(string oid, byte[] rawData, bool critical)
    : this(new Oid(oid, "Subject Alternative Name"), rawData, critical)
  {
  }

  public X509SubjectAltNameExtension(Oid oid, byte[] rawData, bool critical)
    : base(oid, rawData, critical)
  {
    this.m_decoded = false;
  }

  public X509SubjectAltNameExtension(string applicationUri, IEnumerable<string> domainNames)
  {
    this.Oid = new Oid("2.5.29.17", "Subject Alternative Name");
    this.Critical = false;
    this.Initialize(applicationUri, domainNames);
    this.RawData = this.Encode();
    this.m_decoded = true;
  }

  public override string Format(bool multiLine)
  {
    this.EnsureDecoded();
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < this.m_uris.Count; ++index)
    {
      if (stringBuilder.Length > 0)
      {
        if (multiLine)
          stringBuilder.AppendLine();
        else
          stringBuilder.Append(", ");
      }
      stringBuilder.Append("URL");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_uris[index]);
    }
    for (int index = 0; index < this.m_domainNames.Count; ++index)
    {
      if (stringBuilder.Length > 0)
      {
        if (multiLine)
          stringBuilder.AppendLine();
        else
          stringBuilder.Append(", ");
      }
      stringBuilder.Append("DNS Name");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_domainNames[index]);
    }
    for (int index = 0; index < this.m_ipAddresses.Count; ++index)
    {
      if (stringBuilder.Length > 0)
      {
        if (multiLine)
          stringBuilder.AppendLine();
        else
          stringBuilder.Append(", ");
      }
      stringBuilder.Append("IP Address");
      stringBuilder.Append('=');
      stringBuilder.Append(this.m_ipAddresses[index]);
    }
    return stringBuilder.ToString();
  }

  public override void CopyFrom(AsnEncodedData asnEncodedData)
  {
    this.Oid = asnEncodedData != null ? asnEncodedData.Oid : throw new ArgumentNullException(nameof (asnEncodedData));
    this.RawData = asnEncodedData.RawData;
    this.m_decoded = false;
  }

  public IReadOnlyList<string> Uris
  {
    get
    {
      this.EnsureDecoded();
      return (IReadOnlyList<string>) this.m_uris.AsReadOnly();
    }
  }

  public IReadOnlyList<string> DomainNames
  {
    get
    {
      this.EnsureDecoded();
      return (IReadOnlyList<string>) this.m_domainNames.AsReadOnly();
    }
  }

  public IReadOnlyList<string> IPAddresses
  {
    get
    {
      this.EnsureDecoded();
      return (IReadOnlyList<string>) this.m_ipAddresses.AsReadOnly();
    }
  }

  private static string IPAddressToString(byte[] encodedIPAddress)
  {
    try
    {
      return new IPAddress(encodedIPAddress).ToString();
    }
    catch
    {
      throw new CryptographicException("Certificate contains invalid IP address.");
    }
  }

  private byte[] Encode()
  {
    SubjectAlternativeNameBuilder sanBuilder = new SubjectAlternativeNameBuilder();
    foreach (string uri in this.m_uris)
      sanBuilder.AddUri(new Uri(uri));
    X509SubjectAltNameExtension.EncodeGeneralNames(sanBuilder, (IList<string>) this.m_domainNames);
    X509SubjectAltNameExtension.EncodeGeneralNames(sanBuilder, (IList<string>) this.m_ipAddresses);
    return sanBuilder.Build().RawData;
  }

  private static void EncodeGeneralNames(
    SubjectAlternativeNameBuilder sanBuilder,
    IList<string> generalNames)
  {
    foreach (string generalName in (IEnumerable<string>) generalNames)
    {
      if (!string.IsNullOrWhiteSpace(generalName))
      {
        IPAddress address;
        if (IPAddress.TryParse(generalName, out address))
          sanBuilder.AddIpAddress(address);
        else
          sanBuilder.AddDnsName(generalName);
      }
    }
  }

  private void EnsureDecoded()
  {
    if (this.m_decoded)
      return;
    this.Decode(this.RawData);
  }

  private void Decode(byte[] data)
  {
    if (!(this.Oid.Value == "2.5.29.7") && !(this.Oid.Value == "2.5.29.17"))
      throw new CryptographicException("Invalid SubjectAltNameOid.");
    try
    {
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      List<string> stringList3 = new List<string>();
      System.Formats.Asn1.AsnReader asnReader1 = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) data, System.Formats.Asn1.AsnEncodingRules.DER);
      System.Formats.Asn1.AsnReader asnReader2 = asnReader1.ReadSequence();
      asnReader1.ThrowIfNotEmpty();
      if (asnReader2 == null)
        throw new CryptographicException("No valid data in the X509 signature.");
      System.Formats.Asn1.Asn1Tag asn1Tag1 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 6);
      System.Formats.Asn1.Asn1Tag asn1Tag2 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 2);
      System.Formats.Asn1.Asn1Tag asn1Tag3 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 7);
      while (asnReader2.HasData)
      {
        System.Formats.Asn1.Asn1Tag asn1Tag4 = asnReader2.PeekTag();
        if (asn1Tag4 == asn1Tag1)
        {
          string str = asnReader2.ReadCharacterString(System.Formats.Asn1.UniversalTagNumber.IA5String, new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
          stringList1.Add(str);
        }
        else if (asn1Tag4 == asn1Tag2)
        {
          string str = asnReader2.ReadCharacterString(System.Formats.Asn1.UniversalTagNumber.IA5String, new System.Formats.Asn1.Asn1Tag?(asn1Tag2));
          stringList2.Add(str);
        }
        else if (asn1Tag4 == asn1Tag3)
        {
          byte[] encodedIPAddress = asnReader2.ReadOctetString(new System.Formats.Asn1.Asn1Tag?(asn1Tag3));
          stringList3.Add(X509SubjectAltNameExtension.IPAddressToString(encodedIPAddress));
        }
        else
          asnReader2.ReadEncodedValue();
      }
      asnReader2.ThrowIfNotEmpty();
      this.m_uris = stringList1;
      this.m_domainNames = stringList2;
      this.m_ipAddresses = stringList3;
      this.m_decoded = true;
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the SubjectAltName extension.", (Exception) ex);
    }
  }

  private void Initialize(string applicationUri, IEnumerable<string> generalNames)
  {
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    List<string> stringList3 = new List<string>();
    stringList1.Add(applicationUri);
    foreach (string generalName in generalNames)
    {
      switch (Uri.CheckHostName(generalName))
      {
        case UriHostNameType.Dns:
          stringList2.Add(generalName);
          continue;
        case UriHostNameType.IPv4:
        case UriHostNameType.IPv6:
          stringList3.Add(generalName);
          continue;
        default:
          continue;
      }
    }
    this.m_uris = stringList1;
    this.m_domainNames = stringList2;
    this.m_ipAddresses = stringList3;
  }
}

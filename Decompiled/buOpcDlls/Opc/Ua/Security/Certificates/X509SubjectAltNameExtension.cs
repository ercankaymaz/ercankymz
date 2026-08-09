using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

	public IReadOnlyList<string> Uris
	{
		get
		{
			EnsureDecoded();
			return m_uris.AsReadOnly();
		}
	}

	public IReadOnlyList<string> DomainNames
	{
		get
		{
			EnsureDecoded();
			return m_domainNames.AsReadOnly();
		}
	}

	public IReadOnlyList<string> IPAddresses
	{
		get
		{
			EnsureDecoded();
			return m_ipAddresses.AsReadOnly();
		}
	}

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
		m_decoded = false;
	}

	public X509SubjectAltNameExtension(string applicationUri, IEnumerable<string> domainNames)
	{
		base.Oid = new Oid("2.5.29.17", "Subject Alternative Name");
		base.Critical = false;
		Initialize(applicationUri, domainNames);
		base.RawData = Encode();
		m_decoded = true;
	}

	public override string Format(bool multiLine)
	{
		EnsureDecoded();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < m_uris.Count; i++)
		{
			if (stringBuilder.Length > 0)
			{
				if (multiLine)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append("URL");
			stringBuilder.Append('=');
			stringBuilder.Append(m_uris[i]);
		}
		for (int j = 0; j < m_domainNames.Count; j++)
		{
			if (stringBuilder.Length > 0)
			{
				if (multiLine)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append("DNS Name");
			stringBuilder.Append('=');
			stringBuilder.Append(m_domainNames[j]);
		}
		for (int k = 0; k < m_ipAddresses.Count; k++)
		{
			if (stringBuilder.Length > 0)
			{
				if (multiLine)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append("IP Address");
			stringBuilder.Append('=');
			stringBuilder.Append(m_ipAddresses[k]);
		}
		return stringBuilder.ToString();
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		if (asnEncodedData == null)
		{
			throw new ArgumentNullException("asnEncodedData");
		}
		base.Oid = asnEncodedData.Oid;
		base.RawData = asnEncodedData.RawData;
		m_decoded = false;
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
		SubjectAlternativeNameBuilder subjectAlternativeNameBuilder = new SubjectAlternativeNameBuilder();
		foreach (string uri in m_uris)
		{
			subjectAlternativeNameBuilder.AddUri(new Uri(uri));
		}
		EncodeGeneralNames(subjectAlternativeNameBuilder, m_domainNames);
		EncodeGeneralNames(subjectAlternativeNameBuilder, m_ipAddresses);
		return subjectAlternativeNameBuilder.Build().RawData;
	}

	private static void EncodeGeneralNames(SubjectAlternativeNameBuilder sanBuilder, IList<string> generalNames)
	{
		foreach (string generalName in generalNames)
		{
			if (!string.IsNullOrWhiteSpace(generalName))
			{
				if (IPAddress.TryParse(generalName, out var address))
				{
					sanBuilder.AddIpAddress(address);
				}
				else
				{
					sanBuilder.AddDnsName(generalName);
				}
			}
		}
	}

	private void EnsureDecoded()
	{
		if (!m_decoded)
		{
			Decode(base.RawData);
		}
	}

	private void Decode(byte[] data)
	{
		if (base.Oid.Value == "2.5.29.7" || base.Oid.Value == "2.5.29.17")
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				AsnReader asnReader = new AsnReader(data, AsnEncodingRules.DER);
				AsnReader asnReader2 = asnReader.ReadSequence();
				asnReader.ThrowIfNotEmpty();
				if (asnReader2 != null)
				{
					Asn1Tag asn1Tag = new Asn1Tag(TagClass.ContextSpecific, 6);
					Asn1Tag asn1Tag2 = new Asn1Tag(TagClass.ContextSpecific, 2);
					Asn1Tag asn1Tag3 = new Asn1Tag(TagClass.ContextSpecific, 7);
					while (asnReader2.HasData)
					{
						Asn1Tag asn1Tag4 = asnReader2.PeekTag();
						if (asn1Tag4 == asn1Tag)
						{
							string item = asnReader2.ReadCharacterString(UniversalTagNumber.IA5String, asn1Tag);
							list.Add(item);
						}
						else if (asn1Tag4 == asn1Tag2)
						{
							string item2 = asnReader2.ReadCharacterString(UniversalTagNumber.IA5String, asn1Tag2);
							list2.Add(item2);
						}
						else if (asn1Tag4 == asn1Tag3)
						{
							byte[] encodedIPAddress = asnReader2.ReadOctetString(asn1Tag3);
							list3.Add(IPAddressToString(encodedIPAddress));
						}
						else
						{
							asnReader2.ReadEncodedValue();
						}
					}
					asnReader2.ThrowIfNotEmpty();
					m_uris = list;
					m_domainNames = list2;
					m_ipAddresses = list3;
					m_decoded = true;
					return;
				}
				throw new CryptographicException("No valid data in the X509 signature.");
			}
			catch (AsnContentException inner)
			{
				throw new CryptographicException("Failed to decode the SubjectAltName extension.", inner);
			}
		}
		throw new CryptographicException("Invalid SubjectAltNameOid.");
	}

	private void Initialize(string applicationUri, IEnumerable<string> generalNames)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		list.Add(applicationUri);
		foreach (string generalName in generalNames)
		{
			switch (Uri.CheckHostName(generalName))
			{
			case UriHostNameType.Dns:
				list2.Add(generalName);
				break;
			case UriHostNameType.IPv4:
			case UriHostNameType.IPv6:
				list3.Add(generalName);
				break;
			}
		}
		m_uris = list;
		m_domainNames = list2;
		m_ipAddresses = list3;
	}
}

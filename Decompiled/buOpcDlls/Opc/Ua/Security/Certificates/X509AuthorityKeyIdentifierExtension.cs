using System;
using System.Formats.Asn1;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

	public string KeyIdentifier => m_keyIdentifier.ToHexString();

	public X500DistinguishedName Issuer => m_issuer;

	public string SerialNumber => m_serialNumber.ToHexString(invertEndian: true);

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
		if (subjectKeyIdentifier == null)
		{
			throw new ArgumentNullException("subjectKeyIdentifier");
		}
		m_keyIdentifier = subjectKeyIdentifier;
		base.Oid = new Oid("2.5.29.35", "Authority Key Identifier");
		base.Critical = false;
		base.RawData = Encode();
	}

	public X509AuthorityKeyIdentifierExtension(byte[] subjectKeyIdentifier, X500DistinguishedName authorityName, byte[] serialNumber)
	{
		m_issuer = authorityName;
		m_keyIdentifier = subjectKeyIdentifier;
		m_serialNumber = serialNumber;
		base.Oid = new Oid("2.5.29.35", "Authority Key Identifier");
		base.Critical = false;
		base.RawData = Encode();
	}

	public X509AuthorityKeyIdentifierExtension(Oid oid, byte[] rawData, bool critical)
		: base(oid, rawData, critical)
	{
		Decode(rawData);
	}

	public override string Format(bool multiLine)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (m_keyIdentifier != null && m_keyIdentifier.Length != 0)
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
			stringBuilder.Append("KeyID");
			stringBuilder.Append('=');
			stringBuilder.Append(m_keyIdentifier.ToHexString());
		}
		if (m_issuer != null)
		{
			if (multiLine)
			{
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("Issuer");
			stringBuilder.Append('=');
			stringBuilder.Append(m_issuer.Format(multiLine: true));
		}
		if (m_serialNumber != null && m_serialNumber.Length != 0)
		{
			if (stringBuilder.Length > 0 && !multiLine)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("SerialNumber");
			stringBuilder.Append('=');
			stringBuilder.Append(m_serialNumber.ToHexString(invertEndian: true));
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
		Decode(asnEncodedData.RawData);
	}

	public byte[] GetKeyIdentifier()
	{
		return m_keyIdentifier;
	}

	public byte[] GetSerialNumber()
	{
		return m_serialNumber;
	}

	private byte[] Encode()
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.PushSequence();
		if (m_keyIdentifier != null)
		{
			asnWriter.WriteOctetString(tag: new Asn1Tag(TagClass.ContextSpecific, 0), value: m_keyIdentifier);
		}
		if (m_issuer != null)
		{
			Asn1Tag value = new Asn1Tag(TagClass.ContextSpecific, 1);
			asnWriter.PushSequence(value);
			Asn1Tag value2 = new Asn1Tag(TagClass.ContextSpecific, 4, isConstructed: true);
			asnWriter.PushSetOf(value2);
			asnWriter.WriteEncodedValue(m_issuer.RawData);
			asnWriter.PopSetOf(value2);
			asnWriter.PopSequence(value);
		}
		if (m_serialNumber != null)
		{
			Asn1Tag value3 = new Asn1Tag(TagClass.ContextSpecific, 2);
			BigInteger value4 = new BigInteger(m_serialNumber);
			asnWriter.WriteInteger(value4, value3);
		}
		asnWriter.PopSequence();
		return asnWriter.Encode();
	}

	private void Decode(byte[] data)
	{
		if (base.Oid.Value == "2.5.29.1" || base.Oid.Value == "2.5.29.35")
		{
			try
			{
				AsnReader asnReader = new AsnReader(data, AsnEncodingRules.DER);
				AsnReader asnReader2 = asnReader.ReadSequence();
				asnReader.ThrowIfNotEmpty();
				if (asnReader2 != null)
				{
					Asn1Tag asn1Tag = new Asn1Tag(TagClass.ContextSpecific, 0);
					Asn1Tag asn1Tag2 = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
					Asn1Tag asn1Tag3 = new Asn1Tag(TagClass.ContextSpecific, 2);
					while (asnReader2.HasData)
					{
						Asn1Tag asn1Tag4 = asnReader2.PeekTag();
						if (asn1Tag4 == asn1Tag)
						{
							m_keyIdentifier = asnReader2.ReadOctetString(asn1Tag);
						}
						else if (asn1Tag4 == asn1Tag2)
						{
							AsnReader asnReader3 = asnReader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
							if (asnReader3 != null)
							{
								Asn1Tag value = new Asn1Tag(TagClass.ContextSpecific, 4, isConstructed: true);
								m_issuer = new X500DistinguishedName(asnReader3.ReadSequence(value).ReadEncodedValue().ToArray());
								asnReader3.ThrowIfNotEmpty();
							}
						}
						else
						{
							if (!(asn1Tag4 == asn1Tag3))
							{
								throw new AsnContentException("Unknown tag in sequence.");
							}
							m_serialNumber = asnReader2.ReadInteger(asn1Tag3).ToByteArray();
						}
					}
					asnReader2.ThrowIfNotEmpty();
					return;
				}
				throw new CryptographicException("No valid data in the extension.");
			}
			catch (AsnContentException inner)
			{
				throw new CryptographicException("Failed to decode the AuthorityKeyIdentifier extension.", inner);
			}
		}
		throw new CryptographicException("Invalid AuthorityKeyIdentifierOid.");
	}
}

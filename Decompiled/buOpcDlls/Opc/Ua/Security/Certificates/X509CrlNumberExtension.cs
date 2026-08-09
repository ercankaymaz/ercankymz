using System;
using System.Formats.Asn1;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509CrlNumberExtension : X509Extension
{
	public const string CrlNumberOid = "2.5.29.20";

	private const string kFriendlyName = "CRL Number";

	public BigInteger CrlNumber { get; private set; }

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
		Decode(rawData);
	}

	public X509CrlNumberExtension(BigInteger crlNumber)
	{
		base.Oid = new Oid("2.5.29.20", "CRL Number");
		base.Critical = false;
		CrlNumber = crlNumber;
		base.RawData = Encode();
	}

	public override string Format(bool multiLine)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("CRL Number");
		stringBuilder.Append('=');
		stringBuilder.Append(CrlNumber);
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
		Decode(base.RawData);
	}

	private byte[] Encode()
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.WriteInteger(CrlNumber);
		return asnWriter.Encode();
	}

	private void Decode(byte[] data)
	{
		if (base.Oid.Value == "2.5.29.20")
		{
			try
			{
				AsnReader asnReader = new AsnReader(data, AsnEncodingRules.DER);
				CrlNumber = asnReader.ReadInteger();
				asnReader.ThrowIfNotEmpty();
				return;
			}
			catch (AsnContentException inner)
			{
				throw new CryptographicException("Failed to decode the CRL Number extension.", inner);
			}
		}
		throw new CryptographicException("Invalid CrlNumberOid.");
	}
}

using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509Signature
{
	public byte[] Tbs { get; private set; }

	public byte[] Signature { get; private set; }

	public byte[] SignatureAlgorithmIdentifier { get; private set; }

	public string SignatureAlgorithm { get; private set; }

	public HashAlgorithmName Name { get; private set; }

	public X509Signature(byte[] signedBlob)
	{
		Decode(signedBlob);
	}

	public X509Signature(byte[] tbs, byte[] signature, byte[] signatureAlgorithmIdentifier)
	{
		Tbs = tbs;
		Signature = signature;
		SignatureAlgorithmIdentifier = signatureAlgorithmIdentifier;
		SignatureAlgorithm = DecodeAlgorithm(signatureAlgorithmIdentifier);
		Name = Oids.GetHashAlgorithmName(SignatureAlgorithm);
	}

	public byte[] Encode()
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		Asn1Tag sequence = Asn1Tag.Sequence;
		asnWriter.PushSequence(sequence);
		asnWriter.WriteEncodedValue(Tbs);
		if (SignatureAlgorithmIdentifier != null)
		{
			asnWriter.WriteEncodedValue(SignatureAlgorithmIdentifier);
		}
		else
		{
			asnWriter.PushSequence();
			string rSAOid = Oids.GetRSAOid(Name);
			asnWriter.WriteObjectIdentifier(rSAOid);
			asnWriter.WriteNull();
			asnWriter.PopSequence();
		}
		asnWriter.WriteBitString(Signature);
		asnWriter.PopSequence(sequence);
		return asnWriter.Encode();
	}

	private void Decode(byte[] crl)
	{
		try
		{
			AsnReader asnReader = new AsnReader(crl, AsnEncodingRules.DER).ReadSequence(Asn1Tag.Sequence);
			if (asnReader != null)
			{
				Tbs = asnReader.ReadEncodedValue().ToArray();
				AsnReader asnReader2 = asnReader.ReadSequence();
				SignatureAlgorithm = asnReader2.ReadObjectIdentifier();
				Name = Oids.GetHashAlgorithmName(SignatureAlgorithm);
				Signature = asnReader.ReadBitString(out var unusedBitCount);
				if (unusedBitCount != 0)
				{
					throw new AsnContentException("Unexpected data in signature.");
				}
				asnReader.ThrowIfNotEmpty();
				return;
			}
			throw new CryptographicException("No valid data in the X509 signature.");
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Failed to decode the X509 signature.", inner);
		}
	}

	public bool Verify(X509Certificate2 certificate)
	{
		switch (SignatureAlgorithm)
		{
		case "1.2.840.113549.1.1.11":
		case "1.2.840.113549.1.1.12":
		case "1.2.840.113549.1.1.13":
		case "1.2.840.113549.1.1.5":
			return VerifyForRSA(certificate, RSASignaturePadding.Pkcs1);
		case "1.2.840.10045.4.3.2":
		case "1.2.840.10045.4.3.3":
		case "1.2.840.10045.4.3.4":
		case "1.2.840.10045.4.1":
			return VerifyForECDsa(certificate);
		default:
			throw new CryptographicException("Failed to verify signature due to unknown signature algorithm.");
		}
	}

	private bool VerifyForRSA(X509Certificate2 certificate, RSASignaturePadding padding)
	{
		using RSA rSA = certificate.GetRSAPublicKey();
		return rSA.VerifyData(Tbs, Signature, Name, padding);
	}

	private bool VerifyForECDsa(X509Certificate2 certificate)
	{
		using ECDsa eCDsa = certificate.GetECDsaPublicKey();
		byte[] signature = DecodeECDsa(Signature, eCDsa.KeySize);
		return eCDsa.VerifyData(Tbs, signature, Name);
	}

	private static string DecodeAlgorithm(byte[] oid)
	{
		AsnReader asnReader = new AsnReader(oid, AsnEncodingRules.DER);
		AsnReader asnReader2 = asnReader.ReadSequence();
		asnReader.ThrowIfNotEmpty();
		string result = asnReader2.ReadObjectIdentifier();
		if (asnReader2.HasData)
		{
			asnReader2.ReadNull();
		}
		asnReader2.ThrowIfNotEmpty();
		return result;
	}

	private static byte[] EncodeECDsa(byte[] signature)
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		Asn1Tag sequence = Asn1Tag.Sequence;
		asnWriter.PushSequence(sequence);
		int num = signature.Length / 2;
		asnWriter.WriteIntegerUnsigned(new ReadOnlySpan<byte>(signature, 0, num));
		asnWriter.WriteIntegerUnsigned(new ReadOnlySpan<byte>(signature, num, num));
		asnWriter.PopSequence(sequence);
		return asnWriter.Encode();
	}

	private static byte[] DecodeECDsa(ReadOnlyMemory<byte> signature, int keySize)
	{
		AsnReader asnReader = new AsnReader(signature, AsnEncodingRules.DER);
		AsnReader asnReader2 = asnReader.ReadSequence();
		asnReader.ThrowIfNotEmpty();
		ReadOnlyMemory<byte> readOnlyMemory = asnReader2.ReadIntegerBytes();
		ReadOnlyMemory<byte> readOnlyMemory2 = asnReader2.ReadIntegerBytes();
		asnReader2.ThrowIfNotEmpty();
		keySize >>= 3;
		if (readOnlyMemory.Span[0] == 0 && readOnlyMemory.Length > keySize)
		{
			readOnlyMemory = readOnlyMemory.Slice(1);
		}
		if (readOnlyMemory2.Span[0] == 0 && readOnlyMemory2.Length > keySize)
		{
			readOnlyMemory2 = readOnlyMemory2.Slice(1);
		}
		byte[] array = new byte[2 * keySize];
		int start = keySize - readOnlyMemory.Length;
		readOnlyMemory.CopyTo(new Memory<byte>(array, start, readOnlyMemory.Length));
		start = 2 * keySize - readOnlyMemory2.Length;
		readOnlyMemory2.CopyTo(new Memory<byte>(array, start, readOnlyMemory2.Length));
		return array;
	}
}

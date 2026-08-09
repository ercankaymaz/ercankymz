using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class AsnUtils
{
	internal static string ToHexString(this byte[] buffer, bool invertEndian = false)
	{
		if (buffer == null || buffer.Length == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
		if (invertEndian)
		{
			for (int num = buffer.Length - 1; num >= 0; num--)
			{
				stringBuilder.AppendFormat("{0:X2}", buffer[num]);
			}
		}
		else
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				stringBuilder.AppendFormat("{0:X2}", buffer[i]);
			}
		}
		return stringBuilder.ToString();
	}

	internal static byte[] FromHexString(this string buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		if (buffer.Length == 0)
		{
			return Array.Empty<byte>();
		}
		byte[] array = new byte[buffer.Length / 2 + buffer.Length % 2];
		for (int i = 0; i < array.Length * 2; i += 2)
		{
			int num = "0123456789ABCDEF".IndexOf(buffer[i]);
			if (num == -1)
			{
				break;
			}
			byte b = (byte)num;
			b <<= 4;
			if (i < buffer.Length - 1)
			{
				num = "0123456789ABCDEF".IndexOf(buffer[i + 1]);
				if (num == -1)
				{
					break;
				}
				b += (byte)num;
			}
			array[i / 2] = b;
		}
		return array;
	}

	internal static void WriteKeyParameterInteger(this AsnWriter writer, ReadOnlySpan<byte> integer)
	{
		if (integer[0] == 0)
		{
			int i;
			for (i = 1; i < integer.Length; i++)
			{
				if (integer[i] >= 128)
				{
					i--;
					break;
				}
				if (integer[i] != 0)
				{
					break;
				}
			}
			if (i == integer.Length)
			{
				i--;
			}
			integer = integer.Slice(i);
		}
		writer.WriteIntegerUnsigned(integer);
	}

	public static byte[] ParseX509Blob(byte[] blob)
	{
		try
		{
			AsnReader asnReader = new AsnReader(blob, AsnEncodingRules.DER);
			byte[] result = blob.AsSpan(0, asnReader.PeekContentBytes().Length + 4).ToArray();
			AsnReader asnReader2 = asnReader.ReadSequence(Asn1Tag.Sequence);
			if (asnReader2 != null)
			{
				asnReader2.ReadEncodedValue();
				Oids.GetHashAlgorithmName(asnReader2.ReadSequence().ReadObjectIdentifier());
				asnReader2.ReadBitString(out var unusedBitCount);
				if (unusedBitCount != 0)
				{
					throw new AsnContentException("Unexpected data in signature.");
				}
				asnReader2.ThrowIfNotEmpty();
				return result;
			}
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Failed to decode the X509 sequence.", inner);
		}
		throw new CryptographicException("Invalid ASN encoding for the X509 sequence.");
	}
}

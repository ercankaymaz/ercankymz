using System;
using System.IO;
using System.Text;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1;

public class Asn1RelativeOid : Asn1Object
{
	internal class Meta : Asn1UniversalType
	{
		internal static readonly Asn1UniversalType Instance = new Meta();

		private Meta()
			: base(typeof(Asn1RelativeOid), 13)
		{
		}

		internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
		{
			return CreatePrimitive(octetString.GetOctets(), clone: false);
		}
	}

	private const long LongLimit = 72057594037927808L;

	private readonly string identifier;

	private byte[] contents;

	public string Id => identifier;

	public static Asn1RelativeOid FromContents(byte[] contents)
	{
		return CreatePrimitive(contents, clone: true);
	}

	public static Asn1RelativeOid GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is Asn1RelativeOid result)
		{
			return result;
		}
		if (obj is IAsn1Convertible asn1Convertible)
		{
			if (asn1Convertible.ToAsn1Object() is Asn1RelativeOid result2)
			{
				return result2;
			}
		}
		else if (obj is byte[] data)
		{
			try
			{
				return (Asn1RelativeOid)Asn1Object.FromByteArray(data);
			}
			catch (IOException ex)
			{
				throw new ArgumentException("failed to construct relative OID from byte[]: " + ex.Message);
			}
		}
		throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), "obj");
	}

	public static Asn1RelativeOid GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		return (Asn1RelativeOid)Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
	}

	public Asn1RelativeOid(string identifier)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		if (!IsValidIdentifier(identifier, 0))
		{
			throw new FormatException("string " + identifier + " not a relative OID");
		}
		this.identifier = identifier;
	}

	private Asn1RelativeOid(Asn1RelativeOid oid, string branchID)
	{
		if (!IsValidIdentifier(branchID, 0))
		{
			throw new FormatException("string " + branchID + " not a valid relative OID branch");
		}
		identifier = oid.Id + "." + branchID;
	}

	private Asn1RelativeOid(byte[] contents, bool clone)
	{
		identifier = ParseContents(contents);
		this.contents = (clone ? Arrays.Clone(contents) : contents);
	}

	public virtual Asn1RelativeOid Branch(string branchID)
	{
		return new Asn1RelativeOid(this, branchID);
	}

	public override string ToString()
	{
		return identifier;
	}

	protected override bool Asn1Equals(Asn1Object asn1Object)
	{
		if (asn1Object is Asn1RelativeOid asn1RelativeOid)
		{
			return identifier == asn1RelativeOid.identifier;
		}
		return false;
	}

	protected override int Asn1GetHashCode()
	{
		return identifier.GetHashCode();
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		return new PrimitiveEncoding(0, 13, GetContents());
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		return new PrimitiveEncoding(tagClass, tagNo, GetContents());
	}

	internal sealed override DerEncoding GetEncodingDer()
	{
		return new PrimitiveDerEncoding(0, 13, GetContents());
	}

	internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
	{
		return new PrimitiveDerEncoding(tagClass, tagNo, GetContents());
	}

	private void DoOutput(MemoryStream bOut)
	{
		OidTokenizer oidTokenizer = new OidTokenizer(identifier);
		while (oidTokenizer.HasMoreTokens)
		{
			string text = oidTokenizer.NextToken();
			if (text.Length <= 18)
			{
				WriteField(bOut, long.Parse(text));
			}
			else
			{
				WriteField(bOut, new BigInteger(text));
			}
		}
	}

	private byte[] GetContents()
	{
		lock (this)
		{
			if (contents == null)
			{
				MemoryStream memoryStream = new MemoryStream();
				DoOutput(memoryStream);
				contents = memoryStream.ToArray();
			}
			return contents;
		}
	}

	internal static Asn1RelativeOid CreatePrimitive(byte[] contents, bool clone)
	{
		return new Asn1RelativeOid(contents, clone);
	}

	internal static bool IsValidIdentifier(string identifier, int from)
	{
		int num = 0;
		int num2 = identifier.Length;
		while (--num2 >= from)
		{
			char c = identifier[num2];
			if (c == '.')
			{
				if (num == 0 || (num > 1 && identifier[num2 + 1] == '0'))
				{
					return false;
				}
				num = 0;
			}
			else
			{
				if ('0' > c || c > '9')
				{
					return false;
				}
				num++;
			}
		}
		if (num == 0 || (num > 1 && identifier[num2 + 1] == '0'))
		{
			return false;
		}
		return true;
	}

	internal static void WriteField(Stream outputStream, long fieldValue)
	{
		byte[] array = new byte[9];
		int num = 8;
		array[num] = (byte)((int)fieldValue & 0x7F);
		while (fieldValue >= 128)
		{
			fieldValue >>= 7;
			array[--num] = (byte)((int)fieldValue | 0x80);
		}
		outputStream.Write(array, num, 9 - num);
	}

	internal static void WriteField(Stream outputStream, BigInteger fieldValue)
	{
		int num = (fieldValue.BitLength + 6) / 7;
		if (num == 0)
		{
			outputStream.WriteByte(0);
			return;
		}
		BigInteger bigInteger = fieldValue;
		byte[] array = new byte[num];
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			array[num2] = (byte)(bigInteger.IntValue | 0x80);
			bigInteger = bigInteger.ShiftRight(7);
		}
		array[num - 1] &= 127;
		outputStream.Write(array, 0, array.Length);
	}

	private static string ParseContents(byte[] contents)
	{
		StringBuilder stringBuilder = new StringBuilder();
		long num = 0L;
		BigInteger bigInteger = null;
		bool flag = true;
		for (int i = 0; i != contents.Length; i++)
		{
			int num2 = contents[i];
			if (num <= 72057594037927808L)
			{
				num += num2 & 0x7F;
				if ((num2 & 0x80) == 0)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append('.');
					}
					stringBuilder.Append(num);
					num = 0L;
				}
				else
				{
					num <<= 7;
				}
				continue;
			}
			if (bigInteger == null)
			{
				bigInteger = BigInteger.ValueOf(num);
			}
			bigInteger = bigInteger.Or(BigInteger.ValueOf(num2 & 0x7F));
			if ((num2 & 0x80) == 0)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append('.');
				}
				stringBuilder.Append(bigInteger);
				bigInteger = null;
				num = 0L;
			}
			else
			{
				bigInteger = bigInteger.ShiftLeft(7);
			}
		}
		return stringBuilder.ToString();
	}
}

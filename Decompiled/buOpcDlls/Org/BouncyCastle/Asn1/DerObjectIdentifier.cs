using System;
using System.IO;
using System.Text;
using System.Threading;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1;

public class DerObjectIdentifier : Asn1Object
{
	internal class Meta : Asn1UniversalType
	{
		internal static readonly Asn1UniversalType Instance = new Meta();

		private Meta()
			: base(typeof(DerObjectIdentifier), 6)
		{
		}

		internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
		{
			return CreatePrimitive(octetString.GetOctets(), clone: false);
		}
	}

	private const long LongLimit = 72057594037927808L;

	private static readonly DerObjectIdentifier[] Cache = new DerObjectIdentifier[1024];

	private readonly string identifier;

	private byte[] contents;

	public string Id => identifier;

	public static DerObjectIdentifier FromContents(byte[] contents)
	{
		return CreatePrimitive(contents, clone: true);
	}

	public static DerObjectIdentifier GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is DerObjectIdentifier result)
		{
			return result;
		}
		if (obj is IAsn1Convertible asn1Convertible)
		{
			if (asn1Convertible.ToAsn1Object() is DerObjectIdentifier result2)
			{
				return result2;
			}
		}
		else if (obj is byte[] bytes)
		{
			try
			{
				return (DerObjectIdentifier)Meta.Instance.FromByteArray(bytes);
			}
			catch (IOException ex)
			{
				throw new ArgumentException("failed to construct object identifier from byte[]: " + ex.Message);
			}
		}
		throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), "obj");
	}

	public static DerObjectIdentifier GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		if (!declaredExplicit && !taggedObject.IsParsed())
		{
			Asn1Object asn1Object = taggedObject.GetObject();
			if (!(asn1Object is DerObjectIdentifier))
			{
				return FromContents(Asn1OctetString.GetInstance(asn1Object).GetOctets());
			}
		}
		return (DerObjectIdentifier)Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
	}

	public DerObjectIdentifier(string identifier)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		if (!IsValidIdentifier(identifier))
		{
			throw new FormatException("string " + identifier + " not an OID");
		}
		this.identifier = identifier;
	}

	private DerObjectIdentifier(DerObjectIdentifier oid, string branchID)
	{
		if (!Asn1RelativeOid.IsValidIdentifier(branchID, 0))
		{
			throw new ArgumentException("string " + branchID + " not a valid OID branch", "branchID");
		}
		identifier = oid.Id + "." + branchID;
	}

	private DerObjectIdentifier(byte[] contents, bool clone)
	{
		identifier = ParseContents(contents);
		this.contents = (clone ? Arrays.Clone(contents) : contents);
	}

	public virtual DerObjectIdentifier Branch(string branchID)
	{
		return new DerObjectIdentifier(this, branchID);
	}

	public virtual bool On(DerObjectIdentifier stem)
	{
		string id = Id;
		string id2 = stem.Id;
		if (id.Length > id2.Length && id[id2.Length] == '.')
		{
			return Platform.StartsWith(id, id2);
		}
		return false;
	}

	public override string ToString()
	{
		return identifier;
	}

	protected override bool Asn1Equals(Asn1Object asn1Object)
	{
		if (asn1Object is DerObjectIdentifier derObjectIdentifier)
		{
			return identifier == derObjectIdentifier.identifier;
		}
		return false;
	}

	protected override int Asn1GetHashCode()
	{
		return identifier.GetHashCode();
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		return new PrimitiveEncoding(0, 6, GetContents());
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		return new PrimitiveEncoding(tagClass, tagNo, GetContents());
	}

	internal sealed override DerEncoding GetEncodingDer()
	{
		return new PrimitiveDerEncoding(0, 6, GetContents());
	}

	internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
	{
		return new PrimitiveDerEncoding(tagClass, tagNo, GetContents());
	}

	private void DoOutput(MemoryStream bOut)
	{
		OidTokenizer oidTokenizer = new OidTokenizer(identifier);
		string s = oidTokenizer.NextToken();
		int num = int.Parse(s) * 40;
		s = oidTokenizer.NextToken();
		if (s.Length <= 18)
		{
			Asn1RelativeOid.WriteField(bOut, num + long.Parse(s));
		}
		else
		{
			Asn1RelativeOid.WriteField(bOut, new BigInteger(s).Add(BigInteger.ValueOf(num)));
		}
		while (oidTokenizer.HasMoreTokens)
		{
			s = oidTokenizer.NextToken();
			if (s.Length <= 18)
			{
				Asn1RelativeOid.WriteField(bOut, long.Parse(s));
			}
			else
			{
				Asn1RelativeOid.WriteField(bOut, new BigInteger(s));
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

	internal static DerObjectIdentifier CreatePrimitive(byte[] contents, bool clone)
	{
		int hashCode = Arrays.GetHashCode(contents);
		hashCode ^= hashCode >> 20;
		hashCode ^= hashCode >> 10;
		hashCode &= 0x3FF;
		DerObjectIdentifier derObjectIdentifier = Volatile.Read(ref Cache[hashCode]);
		if (derObjectIdentifier != null && Arrays.AreEqual(contents, derObjectIdentifier.GetContents()))
		{
			return derObjectIdentifier;
		}
		DerObjectIdentifier derObjectIdentifier2 = new DerObjectIdentifier(contents, clone);
		DerObjectIdentifier derObjectIdentifier3 = Interlocked.CompareExchange(ref Cache[hashCode], derObjectIdentifier2, derObjectIdentifier);
		if (derObjectIdentifier3 != derObjectIdentifier && derObjectIdentifier3 != null && Arrays.AreEqual(contents, derObjectIdentifier3.GetContents()))
		{
			return derObjectIdentifier3;
		}
		return derObjectIdentifier2;
	}

	private static bool IsValidIdentifier(string identifier)
	{
		if (identifier.Length < 3 || identifier[1] != '.')
		{
			return false;
		}
		char c = identifier[0];
		if (c < '0' || c > '2')
		{
			return false;
		}
		return Asn1RelativeOid.IsValidIdentifier(identifier, 2);
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
						if (num < 40)
						{
							stringBuilder.Append('0');
						}
						else if (num < 80)
						{
							stringBuilder.Append('1');
							num -= 40;
						}
						else
						{
							stringBuilder.Append('2');
							num -= 80;
						}
						flag = false;
					}
					stringBuilder.Append('.');
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
					stringBuilder.Append('2');
					bigInteger = bigInteger.Subtract(BigInteger.ValueOf(80L));
					flag = false;
				}
				stringBuilder.Append('.');
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

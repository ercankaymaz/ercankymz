// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerInteger
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerInteger : Asn1Object
{
  public const string AllowUnsafeProperty = "Org.BouncyCastle.Asn1.AllowUnsafeInteger";
  internal const int SignExtSigned = -1;
  internal const int SignExtUnsigned = 255 /*0xFF*/;
  private readonly byte[] bytes;
  private readonly int start;

  internal static bool AllowUnsafe()
  {
    string environmentVariable = Platform.GetEnvironmentVariable("Org.BouncyCastle.Asn1.AllowUnsafeInteger");
    return environmentVariable != null && Platform.EqualsIgnoreCase("true", environmentVariable);
  }

  public static DerInteger GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerInteger) null;
      case DerInteger instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerInteger asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerInteger) DerInteger.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct integer from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerInteger GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerInteger) DerInteger.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerInteger(int value)
  {
    this.bytes = BigInteger.ValueOf((long) value).ToByteArray();
    this.start = 0;
  }

  public DerInteger(long value)
  {
    this.bytes = BigInteger.ValueOf(value).ToByteArray();
    this.start = 0;
  }

  public DerInteger(BigInteger value)
  {
    this.bytes = value != null ? value.ToByteArray() : throw new ArgumentNullException(nameof (value));
    this.start = 0;
  }

  public DerInteger(byte[] bytes)
    : this(bytes, true)
  {
  }

  internal DerInteger(byte[] bytes, bool clone)
  {
    if (DerInteger.IsMalformed(bytes))
      throw new ArgumentException("malformed integer", nameof (bytes));
    this.bytes = clone ? Arrays.Clone(bytes) : bytes;
    this.start = DerInteger.SignBytesToSkip(bytes);
  }

  public BigInteger PositiveValue => new BigInteger(1, this.bytes);

  public BigInteger Value => new BigInteger(this.bytes);

  public bool HasValue(int x)
  {
    return this.bytes.Length - this.start <= 4 && DerInteger.IntValue(this.bytes, this.start, -1) == x;
  }

  public bool HasValue(long x)
  {
    return this.bytes.Length - this.start <= 8 && DerInteger.LongValue(this.bytes, this.start, -1) == x;
  }

  public bool HasValue(BigInteger x)
  {
    return x != null && DerInteger.IntValue(this.bytes, this.start, -1) == x.IntValue && this.Value.Equals(x);
  }

  public int IntPositiveValueExact
  {
    get
    {
      int num = this.bytes.Length - this.start;
      if (num > 4 || num == 4 && ((int) this.bytes[this.start] & 128 /*0x80*/) != 0)
        throw new ArithmeticException("ASN.1 Integer out of positive int range");
      return DerInteger.IntValue(this.bytes, this.start, (int) byte.MaxValue);
    }
  }

  public int IntValueExact
  {
    get
    {
      if (this.bytes.Length - this.start > 4)
        throw new ArithmeticException("ASN.1 Integer out of int range");
      return DerInteger.IntValue(this.bytes, this.start, -1);
    }
  }

  public long LongValueExact
  {
    get
    {
      if (this.bytes.Length - this.start > 8)
        throw new ArithmeticException("ASN.1 Integer out of long range");
      return DerInteger.LongValue(this.bytes, this.start, -1);
    }
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 2, this.bytes);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.bytes);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 2, this.bytes);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.bytes);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.bytes);

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerInteger derInteger && Arrays.AreEqual(this.bytes, derInteger.bytes);
  }

  public override string ToString() => this.Value.ToString();

  internal static DerInteger CreatePrimitive(byte[] contents) => new DerInteger(contents, false);

  internal static int GetEncodingLength(BigInteger x)
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(2, BigIntegers.GetByteLength(x));
  }

  internal static int IntValue(byte[] bytes, int start, int signExt)
  {
    int length = bytes.Length;
    int index = System.Math.Max(start, length - 4);
    int num = (int) (sbyte) bytes[index] & signExt;
    while (++index < length)
      num = num << 8 | (int) bytes[index];
    return num;
  }

  internal static long LongValue(byte[] bytes, int start, int signExt)
  {
    int length = bytes.Length;
    int index = System.Math.Max(start, length - 8);
    long num = (long) ((int) (sbyte) bytes[index] & signExt);
    while (++index < length)
      num = num << 8 | (long) bytes[index];
    return num;
  }

  internal static bool IsMalformed(byte[] bytes)
  {
    switch (bytes.Length)
    {
      case 0:
        return true;
      case 1:
        return false;
      default:
        return (int) (sbyte) bytes[0] == (int) (sbyte) bytes[1] >> 7 && !DerInteger.AllowUnsafe();
    }
  }

  internal static int SignBytesToSkip(byte[] bytes)
  {
    int skip = 0;
    int num = bytes.Length - 1;
    while (skip < num && (int) (sbyte) bytes[skip] == (int) (sbyte) bytes[skip + 1] >> 7)
      ++skip;
    return skip;
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerInteger.Meta();

    private Meta()
      : base(typeof (DerInteger), 2)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerInteger.CreatePrimitive(octetString.GetOctets());
    }
  }
}

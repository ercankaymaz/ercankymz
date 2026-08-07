// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerBitString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerBitString : DerStringBase, Asn1BitStringParser, IAsn1Convertible
{
  private static readonly char[] table = new char[16 /*0x10*/]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'A',
    'B',
    'C',
    'D',
    'E',
    'F'
  };
  internal readonly byte[] contents;

  public static DerBitString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerBitString) null;
      case DerBitString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerBitString asn1Object)
          return asn1Object;
        break;
      case byte[] data:
        try
        {
          return DerBitString.GetInstance((object) Asn1Object.FromByteArray(data));
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct BIT STRING from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerBitString GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    Asn1Object asn1Object = obj.GetObject();
    return !isExplicit && !(asn1Object is DerBitString) ? DerBitString.CreatePrimitive(((Asn1OctetString) asn1Object).GetOctets()) : DerBitString.GetInstance((object) asn1Object);
  }

  public DerBitString(byte data, int padBits)
  {
    this.contents = padBits <= 7 && padBits >= 0 ? new byte[2]
    {
      (byte) padBits,
      data
    } : throw new ArgumentException("pad bits cannot be greater than 7 or less than 0", nameof (padBits));
  }

  public DerBitString(byte[] data)
    : this(data, 0)
  {
  }

  public DerBitString(byte[] data, int padBits)
  {
    if (data == null)
      throw new ArgumentNullException(nameof (data));
    if (padBits < 0 || padBits > 7)
      throw new ArgumentException("must be in the range 0 to 7", nameof (padBits));
    if (data.Length == 0 && padBits != 0)
      throw new ArgumentException("if 'data' is empty, 'padBits' must be 0");
    this.contents = Arrays.Prepend(data, (byte) padBits);
  }

  public DerBitString(int namedBits)
  {
    if (namedBits == 0)
    {
      this.contents = new byte[1];
    }
    else
    {
      int index1 = (32 /*0x20*/ - Integers.NumberOfLeadingZeros(namedBits) + 7) / 8;
      byte[] numArray = new byte[1 + index1];
      for (int index2 = 1; index2 < index1; ++index2)
      {
        numArray[index2] = (byte) namedBits;
        namedBits >>= 8;
      }
      numArray[index1] = (byte) namedBits;
      int num = 0;
      while ((namedBits & 1 << num) == 0)
        ++num;
      numArray[0] = (byte) num;
      this.contents = numArray;
    }
  }

  public DerBitString(Asn1Encodable obj)
    : this(obj.GetDerEncoded())
  {
  }

  internal DerBitString(byte[] contents, bool check)
  {
    if (check)
    {
      if (contents == null)
        throw new ArgumentNullException(nameof (contents));
      int num = contents.Length >= 1 ? (int) contents[0] : throw new ArgumentException("cannot be empty", nameof (contents));
      if (num > 0)
      {
        if (contents.Length < 2)
          throw new ArgumentException("zero length data with non-zero pad bits", nameof (contents));
        if (num > 7)
          throw new ArgumentException("pad bits cannot be greater than 7 or less than 0", nameof (contents));
      }
    }
    this.contents = contents;
  }

  public virtual byte[] GetOctets()
  {
    return this.contents[0] == (byte) 0 ? Arrays.CopyOfRange(this.contents, 1, this.contents.Length) : throw new InvalidOperationException("attempt to get non-octet aligned data from BIT STRING");
  }

  public virtual byte[] GetBytes()
  {
    if (this.contents.Length == 1)
      return Asn1OctetString.EmptyOctets;
    int content = (int) this.contents[0];
    byte[] bytes = Arrays.CopyOfRange(this.contents, 1, this.contents.Length);
    bytes[bytes.Length - 1] &= (byte) ((int) byte.MaxValue << content);
    return bytes;
  }

  public virtual int PadBits => (int) this.contents[0];

  public virtual int IntValue
  {
    get
    {
      int intValue = 0;
      int index1 = Math.Min(5, this.contents.Length - 1);
      for (int index2 = 1; index2 < index1; ++index2)
        intValue |= (int) this.contents[index2] << 8 * (index2 - 1);
      if (1 <= index1 && index1 < 5)
      {
        int content = (int) this.contents[0];
        byte num = (byte) ((uint) this.contents[index1] & (uint) ((int) byte.MaxValue << content));
        intValue |= (int) num << 8 * (index1 - 1);
      }
      return intValue;
    }
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    int content1 = (int) this.contents[0];
    if (content1 != 0)
    {
      int content2 = (int) this.contents[this.contents.Length - 1];
      byte contentsSuffix = (byte) (content2 & (int) byte.MaxValue << content1);
      if (content2 != (int) contentsSuffix)
        return (IAsn1Encoding) new PrimitiveEncodingSuffixed(0, 3, this.contents, contentsSuffix);
    }
    return (IAsn1Encoding) new PrimitiveEncoding(0, 3, this.contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    int content1 = (int) this.contents[0];
    if (content1 != 0)
    {
      int content2 = (int) this.contents[this.contents.Length - 1];
      byte contentsSuffix = (byte) (content2 & (int) byte.MaxValue << content1);
      if (content2 != (int) contentsSuffix)
        return (IAsn1Encoding) new PrimitiveEncodingSuffixed(tagClass, tagNo, this.contents, contentsSuffix);
    }
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    int content1 = (int) this.contents[0];
    if (content1 != 0)
    {
      int content2 = (int) this.contents[this.contents.Length - 1];
      byte contentsSuffix = (byte) (content2 & (int) byte.MaxValue << content1);
      if (content2 != (int) contentsSuffix)
        return (DerEncoding) new PrimitiveDerEncodingSuffixed(0, 3, this.contents, contentsSuffix);
    }
    return (DerEncoding) new PrimitiveDerEncoding(0, 3, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    int content1 = (int) this.contents[0];
    if (content1 != 0)
    {
      int content2 = (int) this.contents[this.contents.Length - 1];
      byte contentsSuffix = (byte) (content2 & (int) byte.MaxValue << content1);
      if (content2 != (int) contentsSuffix)
        return (DerEncoding) new PrimitiveDerEncodingSuffixed(tagClass, tagNo, this.contents, contentsSuffix);
    }
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.contents);
  }

  protected override int Asn1GetHashCode()
  {
    if (this.contents.Length < 2)
      return 1;
    int content = (int) this.contents[0];
    int len = this.contents.Length - 1;
    byte num = (byte) ((uint) this.contents[len] & (uint) ((int) byte.MaxValue << content));
    return Arrays.GetHashCode(this.contents, 0, len) * 257 ^ (int) num;
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    if (!(asn1Object is DerBitString derBitString))
      return false;
    byte[] contents1 = this.contents;
    byte[] contents2 = derBitString.contents;
    int length = contents1.Length;
    if (contents2.Length != length)
      return false;
    if (length == 1)
      return true;
    int index1 = length - 1;
    for (int index2 = 0; index2 < index1; ++index2)
    {
      if ((int) contents1[index2] != (int) contents2[index2])
        return false;
    }
    int num = (int) contents1[0];
    return (int) (byte) ((uint) contents1[index1] & (uint) ((int) byte.MaxValue << num)) == (int) (byte) ((uint) contents2[index1] & (uint) ((int) byte.MaxValue << num));
  }

  public Stream GetBitStream()
  {
    return (Stream) new MemoryStream(this.contents, 1, this.contents.Length - 1, false);
  }

  public Stream GetOctetStream()
  {
    int num = (int) this.contents[0] & (int) byte.MaxValue;
    if (num != 0)
      throw new IOException("expected octet-aligned bitstring, but found padBits: " + num.ToString());
    return this.GetBitStream();
  }

  public Asn1BitStringParser Parser => (Asn1BitStringParser) this;

  public override string GetString()
  {
    byte[] derEncoded = this.GetDerEncoded();
    StringBuilder stringBuilder = new StringBuilder(1 + derEncoded.Length * 2);
    stringBuilder.Append('#');
    for (int index = 0; index != derEncoded.Length; ++index)
    {
      uint num = (uint) derEncoded[index];
      stringBuilder.Append(DerBitString.table[(int) (num >> 4)]);
      stringBuilder.Append(DerBitString.table[(int) num & 15]);
    }
    return stringBuilder.ToString();
  }

  internal static DerBitString CreatePrimitive(byte[] contents)
  {
    int length = contents.Length;
    if (length < 1)
      throw new ArgumentException("truncated BIT STRING detected", nameof (contents));
    int content = (int) contents[0];
    if (content > 0)
    {
      byte num = content <= 7 && length >= 2 ? contents[length - 1] : throw new ArgumentException("invalid pad bits detected", nameof (contents));
      if ((int) num != (int) (byte) ((uint) num & (uint) ((int) byte.MaxValue << content)))
        return (DerBitString) new DLBitString(contents, false);
    }
    return new DerBitString(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerBitString.Meta();

    private Meta()
      : base(typeof (DerBitString), 3)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerBitString.CreatePrimitive(octetString.GetOctets());
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) sequence.ToAsn1BitString();
    }
  }
}

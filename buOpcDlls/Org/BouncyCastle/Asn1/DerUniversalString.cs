// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerUniversalString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerUniversalString : DerStringBase
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
  private readonly byte[] m_contents;

  public static DerUniversalString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerUniversalString) null;
      case DerUniversalString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerUniversalString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerUniversalString) DerUniversalString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct universal string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerUniversalString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerUniversalString) DerUniversalString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerUniversalString(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerUniversalString(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString()
  {
    int length = this.m_contents.Length;
    StringBuilder buf = new StringBuilder("#1C", 3 + 2 * (Asn1OutputStream.GetLengthOfDL(length) + length));
    DerUniversalString.EncodeHexDL(buf, length);
    for (int index = 0; index < length; ++index)
      DerUniversalString.EncodeHexByte(buf, (int) this.m_contents[index]);
    return buf.ToString();
  }

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 28, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 28, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerUniversalString derUniversalString && Arrays.AreEqual(this.m_contents, derUniversalString.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  internal static DerUniversalString CreatePrimitive(byte[] contents)
  {
    return new DerUniversalString(contents, false);
  }

  private static void EncodeHexByte(StringBuilder buf, int i)
  {
    buf.Append(DerUniversalString.table[i >> 4 & 15]);
    buf.Append(DerUniversalString.table[i & 15]);
  }

  private static void EncodeHexDL(StringBuilder buf, int dl)
  {
    if (dl < 128 /*0x80*/)
    {
      DerUniversalString.EncodeHexByte(buf, dl);
    }
    else
    {
      byte[] numArray = new byte[5];
      int num1 = 5;
      do
      {
        numArray[--num1] = (byte) dl;
        dl >>= 8;
      }
      while (dl != 0);
      int num2 = numArray.Length - num1;
      int num3;
      numArray[num3 = num1 - 1] = (byte) (128 /*0x80*/ | num2);
      do
      {
        DerUniversalString.EncodeHexByte(buf, (int) numArray[num3++]);
      }
      while (num3 < numArray.Length);
    }
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerUniversalString.Meta();

    private Meta()
      : base(typeof (DerUniversalString), 28)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerUniversalString.CreatePrimitive(octetString.GetOctets());
    }
  }
}

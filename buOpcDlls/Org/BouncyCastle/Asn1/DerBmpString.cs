// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerBmpString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerBmpString : DerStringBase
{
  private readonly string m_str;

  public static DerBmpString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerBmpString) null;
      case DerBmpString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerBmpString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerBmpString) DerBmpString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct BMP string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerBmpString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerBmpString) DerBmpString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  internal DerBmpString(byte[] contents)
  {
    int num = contents != null ? contents.Length : throw new ArgumentNullException(nameof (contents));
    if ((num & 1) != 0)
      throw new ArgumentException("malformed BMPString encoding encountered", nameof (contents));
    int length = num / 2;
    char[] chArray = new char[length];
    for (int index = 0; index != length; ++index)
      chArray[index] = (char) ((int) contents[2 * index] << 8 | (int) contents[2 * index + 1] & (int) byte.MaxValue);
    this.m_str = new string(chArray);
  }

  internal DerBmpString(char[] str)
  {
    this.m_str = str != null ? new string(str) : throw new ArgumentNullException(nameof (str));
  }

  public DerBmpString(string str)
  {
    this.m_str = str != null ? str : throw new ArgumentNullException(nameof (str));
  }

  public override string GetString() => this.m_str;

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerBmpString derBmpString && this.m_str.Equals(derBmpString.m_str);
  }

  protected override int Asn1GetHashCode() => this.m_str.GetHashCode();

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 30, this.GetContents());
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 30, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents());
  }

  private byte[] GetContents()
  {
    char[] charArray = this.m_str.ToCharArray();
    byte[] contents = new byte[charArray.Length * 2];
    for (int index = 0; index != charArray.Length; ++index)
    {
      contents[2 * index] = (byte) ((uint) charArray[index] >> 8);
      contents[2 * index + 1] = (byte) charArray[index];
    }
    return contents;
  }

  internal static DerBmpString CreatePrimitive(byte[] contents) => new DerBmpString(contents);

  internal static DerBmpString CreatePrimitive(char[] str) => new DerBmpString(str);

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerBmpString.Meta();

    private Meta()
      : base(typeof (DerBmpString), 30)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerBmpString.CreatePrimitive(octetString.GetOctets());
    }
  }
}

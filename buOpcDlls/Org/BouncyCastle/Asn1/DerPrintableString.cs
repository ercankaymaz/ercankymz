// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerPrintableString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerPrintableString : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerPrintableString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerPrintableString) null;
      case DerPrintableString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerPrintableString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerPrintableString) DerPrintableString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct printable string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerPrintableString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerPrintableString) DerPrintableString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerPrintableString(string str)
    : this(str, false)
  {
  }

  public DerPrintableString(string str, bool validate)
  {
    if (str == null)
      throw new ArgumentNullException(nameof (str));
    this.m_contents = !validate || DerPrintableString.IsPrintableString(str) ? Strings.ToAsciiByteArray(str) : throw new ArgumentException("string contains illegal characters", nameof (str));
  }

  public DerPrintableString(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerPrintableString(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromAsciiByteArray(this.m_contents);

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 19, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 19, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerPrintableString derPrintableString && Arrays.AreEqual(this.m_contents, derPrintableString.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  public static bool IsPrintableString(string str)
  {
    foreach (char c in str)
    {
      if (c > '\u007F')
        return false;
      if (!char.IsLetterOrDigit(c))
      {
        switch (c)
        {
          case ' ':
          case '\'':
          case '(':
          case ')':
          case '+':
          case ',':
          case '-':
          case '.':
          case '/':
          case ':':
          case '=':
          case '?':
            continue;
          default:
            return false;
        }
      }
    }
    return true;
  }

  internal static DerPrintableString CreatePrimitive(byte[] contents)
  {
    return new DerPrintableString(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerPrintableString.Meta();

    private Meta()
      : base(typeof (DerPrintableString), 19)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerPrintableString.CreatePrimitive(octetString.GetOctets());
    }
  }
}

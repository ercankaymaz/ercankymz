// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerNumericString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerNumericString : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerNumericString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerNumericString) null;
      case DerNumericString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerNumericString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerNumericString) DerNumericString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct numeric string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerNumericString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerNumericString) DerNumericString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerNumericString(string str)
    : this(str, false)
  {
  }

  public DerNumericString(string str, bool validate)
  {
    if (str == null)
      throw new ArgumentNullException(nameof (str));
    this.m_contents = !validate || DerNumericString.IsNumericString(str) ? Strings.ToAsciiByteArray(str) : throw new ArgumentException("string contains illegal characters", nameof (str));
  }

  public DerNumericString(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerNumericString(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromAsciiByteArray(this.m_contents);

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 18, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 18, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerNumericString derNumericString && Arrays.AreEqual(this.m_contents, derNumericString.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  public static bool IsNumericString(string str)
  {
    foreach (char c in str)
    {
      if (c > '\u007F' || c != ' ' && !char.IsDigit(c))
        return false;
    }
    return true;
  }

  internal static bool IsNumericString(byte[] contents)
  {
    for (int index = 0; index < contents.Length; ++index)
    {
      switch (contents[index])
      {
        case 32 /*0x20*/:
        case 48 /*0x30*/:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 55:
        case 56:
        case 57:
          continue;
        default:
          return false;
      }
    }
    return true;
  }

  internal static DerNumericString CreatePrimitive(byte[] contents)
  {
    return new DerNumericString(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerNumericString.Meta();

    private Meta()
      : base(typeof (DerNumericString), 18)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerNumericString.CreatePrimitive(octetString.GetOctets());
    }
  }
}

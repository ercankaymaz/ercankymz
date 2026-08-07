// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerIA5String
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerIA5String : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerIA5String GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerIA5String) null;
      case DerIA5String instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerIA5String asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerIA5String) DerIA5String.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct IA5 string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerIA5String GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerIA5String) DerIA5String.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerIA5String(string str)
    : this(str, false)
  {
  }

  public DerIA5String(string str, bool validate)
  {
    if (str == null)
      throw new ArgumentNullException(nameof (str));
    this.m_contents = !validate || DerIA5String.IsIA5String(str) ? Strings.ToAsciiByteArray(str) : throw new ArgumentException("string contains illegal characters", nameof (str));
  }

  public DerIA5String(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerIA5String(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromAsciiByteArray(this.m_contents);

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 22, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 22, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerIA5String derIa5String && Arrays.AreEqual(this.m_contents, derIa5String.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  public static bool IsIA5String(string str)
  {
    foreach (char ch in str)
    {
      if (ch > '\u007F')
        return false;
    }
    return true;
  }

  internal static DerIA5String CreatePrimitive(byte[] contents)
  {
    return new DerIA5String(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerIA5String.Meta();

    private Meta()
      : base(typeof (DerIA5String), 22)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerIA5String.CreatePrimitive(octetString.GetOctets());
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1OctetString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1OctetString : Asn1Object, Asn1OctetStringParser, IAsn1Convertible
{
  internal static readonly byte[] EmptyOctets = new byte[0];
  internal readonly byte[] contents;

  public static Asn1OctetString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1OctetString) null;
      case Asn1OctetString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1OctetString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1OctetString) Asn1OctetString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct OCTET STRING from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1OctetString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1OctetString) Asn1OctetString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  internal Asn1OctetString(byte[] contents)
  {
    this.contents = contents != null ? contents : throw new ArgumentNullException(nameof (contents));
  }

  public Stream GetOctetStream() => (Stream) new MemoryStream(this.contents, false);

  public Asn1OctetStringParser Parser => (Asn1OctetStringParser) this;

  public virtual byte[] GetOctets() => this.contents;

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.GetOctets());

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerOctetString derOctetString && Arrays.AreEqual(this.GetOctets(), derOctetString.GetOctets());
  }

  public override string ToString() => "#" + Hex.ToHexString(this.contents);

  internal static Asn1OctetString CreatePrimitive(byte[] contents)
  {
    return (Asn1OctetString) new DerOctetString(contents);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1OctetString.Meta();

    private Meta()
      : base(typeof (Asn1OctetString), 4)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) octetString;
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) sequence.ToAsn1OctetString();
    }
  }
}

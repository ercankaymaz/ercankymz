// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerBoolean
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerBoolean : Asn1Object
{
  public static readonly DerBoolean False = new DerBoolean(false);
  public static readonly DerBoolean True = new DerBoolean(true);
  private readonly byte value;

  public static DerBoolean GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerBoolean) null;
      case DerBoolean instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerBoolean asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerBoolean) DerBoolean.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct boolean from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerBoolean GetInstance(bool value) => !value ? DerBoolean.False : DerBoolean.True;

  public static DerBoolean GetInstance(int value)
  {
    return value == 0 ? DerBoolean.False : DerBoolean.True;
  }

  public static DerBoolean GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerBoolean) DerBoolean.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerBoolean(byte[] val)
  {
    this.value = val.Length == 1 ? val[0] : throw new ArgumentException("byte value should have 1 byte in it", nameof (val));
  }

  private DerBoolean(bool value) => this.value = value ? byte.MaxValue : (byte) 0;

  public bool IsTrue => this.value > (byte) 0;

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 1, this.GetContents(encoding));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents(encoding));
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 1, this.GetContents(2));
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents(2));
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerBoolean derBoolean && this.IsTrue == derBoolean.IsTrue;
  }

  protected override int Asn1GetHashCode() => this.IsTrue.GetHashCode();

  public override string ToString() => !this.IsTrue ? "FALSE" : "TRUE";

  internal static DerBoolean CreatePrimitive(byte[] contents)
  {
    if (contents.Length != 1)
      throw new ArgumentException("BOOLEAN value should have 1 byte in it", nameof (contents));
    switch (contents[0])
    {
      case 0:
        return DerBoolean.False;
      case byte.MaxValue:
        return DerBoolean.True;
      default:
        return new DerBoolean(contents);
    }
  }

  private byte[] GetContents(int encoding)
  {
    byte maxValue = this.value;
    if (2 == encoding && this.IsTrue)
      maxValue = byte.MaxValue;
    return new byte[1]{ maxValue };
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerBoolean.Meta();

    private Meta()
      : base(typeof (DerBoolean), 1)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerBoolean.CreatePrimitive(octetString.GetOctets());
    }
  }
}

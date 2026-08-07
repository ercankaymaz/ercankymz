// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.CryptoPro.Gost28147Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.CryptoPro;

public class Gost28147Parameters : Asn1Encodable
{
  private readonly Asn1OctetString iv;
  private readonly DerObjectIdentifier paramSet;

  public static Gost28147Parameters GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return Gost28147Parameters.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static Gost28147Parameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Gost28147Parameters _:
        return (Gost28147Parameters) obj;
      case Asn1Sequence seq:
        return new Gost28147Parameters(seq);
      default:
        throw new ArgumentException("Invalid GOST3410Parameter: " + Platform.GetTypeName(obj));
    }
  }

  private Gost28147Parameters(Asn1Sequence seq)
  {
    this.iv = seq.Count == 2 ? Asn1OctetString.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.paramSet = DerObjectIdentifier.GetInstance((object) seq[1]);
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.iv, (Asn1Encodable) this.paramSet);
  }
}

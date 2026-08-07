// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Misc.IdeaCbcPar
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Misc;

public class IdeaCbcPar : Asn1Encodable
{
  internal Asn1OctetString iv;

  public static IdeaCbcPar GetInstance(object o)
  {
    switch (o)
    {
      case IdeaCbcPar _:
        return (IdeaCbcPar) o;
      case Asn1Sequence _:
        return new IdeaCbcPar((Asn1Sequence) o);
      default:
        throw new ArgumentException("unknown object in IDEACBCPar factory");
    }
  }

  public IdeaCbcPar(byte[] iv) => this.iv = (Asn1OctetString) new DerOctetString(iv);

  private IdeaCbcPar(Asn1Sequence seq)
  {
    if (seq.Count != 1)
      return;
    this.iv = (Asn1OctetString) seq[0];
  }

  public byte[] GetIV() => this.iv != null ? this.iv.GetOctets() : (byte[]) null;

  public override Asn1Object ToAsn1Object()
  {
    return this.iv == null ? (Asn1Object) DerSequence.Empty : (Asn1Object) new DerSequence((Asn1Encodable) this.iv);
  }
}

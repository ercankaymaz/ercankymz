// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.BasicConstraints
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class BasicConstraints : Asn1Encodable
{
  private readonly DerBoolean cA;
  private readonly DerInteger pathLenConstraint;

  public static BasicConstraints GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return BasicConstraints.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static BasicConstraints GetInstance(object obj)
  {
    switch (obj)
    {
      case BasicConstraints _:
        return (BasicConstraints) obj;
      case X509Extension _:
        return BasicConstraints.GetInstance((object) X509Extension.ConvertValueToObject((X509Extension) obj));
      case null:
        return (BasicConstraints) null;
      default:
        return new BasicConstraints(Asn1Sequence.GetInstance(obj));
    }
  }

  public static BasicConstraints FromExtensions(X509Extensions extensions)
  {
    return BasicConstraints.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.BasicConstraints));
  }

  private BasicConstraints(Asn1Sequence seq)
  {
    if (seq.Count <= 0)
      return;
    if (seq[0] is DerBoolean derBoolean)
      this.cA = derBoolean;
    else
      this.pathLenConstraint = DerInteger.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    if (this.cA == null)
      throw new ArgumentException("wrong sequence in constructor", nameof (seq));
    this.pathLenConstraint = DerInteger.GetInstance((object) seq[1]);
  }

  public BasicConstraints(bool cA)
  {
    if (!cA)
      return;
    this.cA = DerBoolean.True;
  }

  public BasicConstraints(int pathLenConstraint)
  {
    this.cA = DerBoolean.True;
    this.pathLenConstraint = new DerInteger(pathLenConstraint);
  }

  public bool IsCA() => this.cA != null && this.cA.IsTrue;

  public BigInteger PathLenConstraint
  {
    get => this.pathLenConstraint != null ? this.pathLenConstraint.Value : (BigInteger) null;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.cA, (Asn1Encodable) this.pathLenConstraint);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public override string ToString()
  {
    return this.pathLenConstraint == null ? $"BasicConstraints: isCa({this.IsCA().ToString()})" : $"BasicConstraints: isCa({this.IsCA().ToString()}), pathLenConstraint = {this.pathLenConstraint.Value?.ToString()}";
  }
}

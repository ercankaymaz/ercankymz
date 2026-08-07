// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PopoSigningKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PopoSigningKey : Asn1Encodable
{
  private readonly PopoSigningKeyInput poposkInput;
  private readonly AlgorithmIdentifier algorithmIdentifier;
  private readonly DerBitString signature;

  private PopoSigningKey(Asn1Sequence seq)
  {
    int num = 0;
    if (seq[0] is Asn1TaggedObject)
    {
      Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) seq[num++];
      this.poposkInput = asn1TaggedObject.TagNo == 0 ? PopoSigningKeyInput.GetInstance((object) asn1TaggedObject.GetObject()) : throw new ArgumentException("Unknown PopoSigningKeyInput tag: " + asn1TaggedObject.TagNo.ToString(), nameof (seq));
    }
    Asn1Sequence asn1Sequence = seq;
    int index1 = num;
    int index2 = index1 + 1;
    this.algorithmIdentifier = AlgorithmIdentifier.GetInstance((object) asn1Sequence[index1]);
    this.signature = DerBitString.GetInstance((object) seq[index2]);
  }

  public static PopoSigningKey GetInstance(object obj)
  {
    switch (obj)
    {
      case PopoSigningKey _:
        return (PopoSigningKey) obj;
      case Asn1Sequence _:
        return new PopoSigningKey((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static PopoSigningKey GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return PopoSigningKey.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public PopoSigningKey(
    PopoSigningKeyInput poposkIn,
    AlgorithmIdentifier aid,
    DerBitString signature)
  {
    this.poposkInput = poposkIn;
    this.algorithmIdentifier = aid;
    this.signature = signature;
  }

  public virtual PopoSigningKeyInput PoposkInput => this.poposkInput;

  public virtual AlgorithmIdentifier AlgorithmIdentifier => this.algorithmIdentifier;

  public virtual DerBitString Signature => this.signature;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.poposkInput);
    elementVector.Add((Asn1Encodable) this.algorithmIdentifier);
    elementVector.Add((Asn1Encodable) this.signature);
    return (Asn1Object) new DerSequence(elementVector);
  }
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Tsp.MessageImprint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Tsp;

public class MessageImprint : Asn1Encodable
{
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly byte[] hashedMessage;

  public static MessageImprint GetInstance(object obj)
  {
    if (obj is MessageImprint)
      return (MessageImprint) obj;
    return obj == null ? (MessageImprint) null : new MessageImprint(Asn1Sequence.GetInstance(obj));
  }

  private MessageImprint(Asn1Sequence seq)
  {
    this.hashAlgorithm = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.hashedMessage = Asn1OctetString.GetInstance((object) seq[1]).GetOctets();
  }

  public MessageImprint(AlgorithmIdentifier hashAlgorithm, byte[] hashedMessage)
  {
    this.hashAlgorithm = hashAlgorithm;
    this.hashedMessage = hashedMessage;
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public byte[] GetHashedMessage() => this.hashedMessage;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.hashAlgorithm, (Asn1Encodable) new DerOctetString(this.hashedMessage));
  }
}

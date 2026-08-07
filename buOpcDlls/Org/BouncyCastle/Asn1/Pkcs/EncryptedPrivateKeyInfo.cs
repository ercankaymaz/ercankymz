// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.EncryptedPrivateKeyInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class EncryptedPrivateKeyInfo : Asn1Encodable
{
  private readonly AlgorithmIdentifier algId;
  private readonly Asn1OctetString data;

  private EncryptedPrivateKeyInfo(Asn1Sequence seq)
  {
    this.algId = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.data = Asn1OctetString.GetInstance((object) seq[1]);
  }

  public EncryptedPrivateKeyInfo(AlgorithmIdentifier algId, byte[] encoding)
  {
    this.algId = algId;
    this.data = (Asn1OctetString) new DerOctetString(encoding);
  }

  public static EncryptedPrivateKeyInfo GetInstance(object obj)
  {
    if (obj == null)
      return (EncryptedPrivateKeyInfo) null;
    return obj is EncryptedPrivateKeyInfo encryptedPrivateKeyInfo ? encryptedPrivateKeyInfo : new EncryptedPrivateKeyInfo(Asn1Sequence.GetInstance(obj));
  }

  public AlgorithmIdentifier EncryptionAlgorithm => this.algId;

  public byte[] GetEncryptedData() => this.data.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.algId, (Asn1Encodable) this.data);
  }
}

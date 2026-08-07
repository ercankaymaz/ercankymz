// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.EncryptionScheme
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class EncryptionScheme : AlgorithmIdentifier
{
  public EncryptionScheme(DerObjectIdentifier objectID)
    : base(objectID)
  {
  }

  public EncryptionScheme(DerObjectIdentifier objectID, Asn1Encodable parameters)
    : base(objectID, parameters)
  {
  }

  internal EncryptionScheme(Asn1Sequence seq)
    : this((DerObjectIdentifier) seq[0], seq[1])
  {
  }

  public static EncryptionScheme GetInstance(object obj)
  {
    switch (obj)
    {
      case EncryptionScheme _:
        return (EncryptionScheme) obj;
      case Asn1Sequence _:
        return new EncryptionScheme((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Asn1Object Asn1Object => this.Parameters.ToAsn1Object();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.Algorithm, this.Parameters);
  }
}

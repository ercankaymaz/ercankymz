// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Smime.SmimeCapability
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Smime;

public class SmimeCapability : Asn1Encodable
{
  public static readonly DerObjectIdentifier PreferSignedData = PkcsObjectIdentifiers.PreferSignedData;
  public static readonly DerObjectIdentifier CannotDecryptAny = PkcsObjectIdentifiers.CannotDecryptAny;
  public static readonly DerObjectIdentifier SmimeCapabilitiesVersions = PkcsObjectIdentifiers.SmimeCapabilitiesVersions;
  public static readonly DerObjectIdentifier DesCbc = new DerObjectIdentifier("1.3.14.3.2.7");
  public static readonly DerObjectIdentifier DesEde3Cbc = PkcsObjectIdentifiers.DesEde3Cbc;
  public static readonly DerObjectIdentifier RC2Cbc = PkcsObjectIdentifiers.RC2Cbc;
  private DerObjectIdentifier capabilityID;
  private Asn1Object parameters;

  public SmimeCapability(Asn1Sequence seq)
  {
    this.capabilityID = (DerObjectIdentifier) seq[0].ToAsn1Object();
    if (seq.Count <= 1)
      return;
    this.parameters = seq[1].ToAsn1Object();
  }

  public SmimeCapability(DerObjectIdentifier capabilityID, Asn1Encodable parameters)
  {
    this.capabilityID = capabilityID != null ? capabilityID : throw new ArgumentNullException(nameof (capabilityID));
    if (parameters == null)
      return;
    this.parameters = parameters.ToAsn1Object();
  }

  public static SmimeCapability GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SmimeCapability _:
        return (SmimeCapability) obj;
      case Asn1Sequence _:
        return new SmimeCapability((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid SmimeCapability");
    }
  }

  public DerObjectIdentifier CapabilityID => this.capabilityID;

  public Asn1Object Parameters => this.parameters;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.capabilityID);
    elementVector.AddOptional((Asn1Encodable) this.parameters);
    return (Asn1Object) new DerSequence(elementVector);
  }
}

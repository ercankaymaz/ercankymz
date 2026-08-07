// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Smime.SmimeCapabilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Smime;

public class SmimeCapabilities : Asn1Encodable
{
  public static readonly DerObjectIdentifier PreferSignedData = PkcsObjectIdentifiers.PreferSignedData;
  public static readonly DerObjectIdentifier CannotDecryptAny = PkcsObjectIdentifiers.CannotDecryptAny;
  public static readonly DerObjectIdentifier SmimeCapabilitesVersions = PkcsObjectIdentifiers.SmimeCapabilitiesVersions;
  public static readonly DerObjectIdentifier Aes256Cbc = NistObjectIdentifiers.IdAes256Cbc;
  public static readonly DerObjectIdentifier Aes192Cbc = NistObjectIdentifiers.IdAes192Cbc;
  public static readonly DerObjectIdentifier Aes128Cbc = NistObjectIdentifiers.IdAes128Cbc;
  public static readonly DerObjectIdentifier IdeaCbc = new DerObjectIdentifier("1.3.6.1.4.1.188.7.1.1.2");
  public static readonly DerObjectIdentifier Cast5Cbc = new DerObjectIdentifier("1.2.840.113533.7.66.10");
  public static readonly DerObjectIdentifier DesCbc = new DerObjectIdentifier("1.3.14.3.2.7");
  public static readonly DerObjectIdentifier DesEde3Cbc = PkcsObjectIdentifiers.DesEde3Cbc;
  public static readonly DerObjectIdentifier RC2Cbc = PkcsObjectIdentifiers.RC2Cbc;
  private Asn1Sequence capabilities;

  public static SmimeCapabilities GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SmimeCapabilities _:
        return (SmimeCapabilities) obj;
      case Asn1Sequence _:
        return new SmimeCapabilities((Asn1Sequence) obj);
      case AttributeX509 _:
        return new SmimeCapabilities((Asn1Sequence) ((AttributeX509) obj).AttrValues[0]);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public SmimeCapabilities(Asn1Sequence seq) => this.capabilities = seq;

  public IList<SmimeCapability> GetCapabilitiesForOid(DerObjectIdentifier capability)
  {
    List<SmimeCapability> list = new List<SmimeCapability>();
    this.DoGetCapabilitiesForOid(capability, (IList<SmimeCapability>) list);
    return (IList<SmimeCapability>) list;
  }

  private void DoGetCapabilitiesForOid(DerObjectIdentifier capability, IList<SmimeCapability> list)
  {
    foreach (object capability1 in this.capabilities)
    {
      SmimeCapability instance = SmimeCapability.GetInstance(capability1);
      if (capability == null || capability.Equals((Asn1Object) instance.CapabilityID))
        list.Add(instance);
    }
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.capabilities;
}

// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Smime.SmimeCapabilityVector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Smime;

public class SmimeCapabilityVector
{
  private readonly Asn1EncodableVector capabilities = new Asn1EncodableVector();

  public void AddCapability(DerObjectIdentifier capability)
  {
    this.capabilities.Add((Asn1Encodable) new DerSequence((Asn1Encodable) capability));
  }

  public void AddCapability(DerObjectIdentifier capability, int value)
  {
    this.capabilities.Add((Asn1Encodable) new DerSequence((Asn1Encodable) capability, (Asn1Encodable) new DerInteger(value)));
  }

  public void AddCapability(DerObjectIdentifier capability, Asn1Encodable parameters)
  {
    this.capabilities.Add((Asn1Encodable) new DerSequence((Asn1Encodable) capability, parameters));
  }

  public Asn1EncodableVector ToAsn1EncodableVector() => this.capabilities;
}

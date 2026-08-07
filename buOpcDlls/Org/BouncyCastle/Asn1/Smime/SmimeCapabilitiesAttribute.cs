// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Smime.SmimeCapabilitiesAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Smime;

public class SmimeCapabilitiesAttribute(SmimeCapabilityVector capabilities) : AttributeX509(SmimeAttributes.SmimeCapabilities, (Asn1Set) new DerSet((Asn1Encodable) new DerSequence(capabilities.ToAsn1EncodableVector())))
{
}

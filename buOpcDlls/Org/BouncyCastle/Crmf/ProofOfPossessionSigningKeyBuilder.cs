// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.ProofOfPossessionSigningKeyBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class ProofOfPossessionSigningKeyBuilder
{
  private CertRequest _certRequest;
  private SubjectPublicKeyInfo _pubKeyInfo;
  private GeneralName _name;
  private PKMacValue _publicKeyMAC;

  public ProofOfPossessionSigningKeyBuilder(CertRequest certRequest)
  {
    this._certRequest = certRequest;
  }

  public ProofOfPossessionSigningKeyBuilder(SubjectPublicKeyInfo pubKeyInfo)
  {
    this._pubKeyInfo = pubKeyInfo;
  }

  public ProofOfPossessionSigningKeyBuilder SetSender(GeneralName name)
  {
    this._name = name;
    return this;
  }

  public ProofOfPossessionSigningKeyBuilder SetPublicKeyMac(PKMacBuilder generator, char[] password)
  {
    return this.ImplSetPublicKeyMac(generator.Build(password));
  }

  public PopoSigningKey Build(ISignatureFactory signer)
  {
    if (this._name != null && this._publicKeyMAC != null)
      throw new InvalidOperationException("name and publicKeyMAC cannot both be set.");
    PopoSigningKeyInput poposkIn;
    Asn1Encodable asn1Encodable;
    if (this._certRequest != null)
    {
      poposkIn = (PopoSigningKeyInput) null;
      asn1Encodable = (Asn1Encodable) this._certRequest;
    }
    else if (this._name != null)
    {
      poposkIn = new PopoSigningKeyInput(this._name, this._pubKeyInfo);
      asn1Encodable = (Asn1Encodable) poposkIn;
    }
    else
    {
      poposkIn = new PopoSigningKeyInput(this._publicKeyMAC, this._pubKeyInfo);
      asn1Encodable = (Asn1Encodable) poposkIn;
    }
    DerBitString signature = X509Utilities.GenerateSignature(signer, asn1Encodable);
    return new PopoSigningKey(poposkIn, (AlgorithmIdentifier) signer.AlgorithmDetails, signature);
  }

  private ProofOfPossessionSigningKeyBuilder ImplSetPublicKeyMac(IMacFactory macFactory)
  {
    DerBitString mac = X509Utilities.GenerateMac(macFactory, (Asn1Encodable) this._pubKeyInfo);
    this._publicKeyMAC = new PKMacValue((AlgorithmIdentifier) macFactory.AlgorithmDetails, mac);
    return this;
  }
}

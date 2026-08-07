// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.ProtectedPkiMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Crmf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public class ProtectedPkiMessage
{
  private readonly PkiMessage m_pkiMessage;

  public ProtectedPkiMessage(GeneralPkiMessage pkiMessage)
  {
    this.m_pkiMessage = pkiMessage.HasProtection ? pkiMessage.ToAsn1Structure() : throw new ArgumentException("GeneralPkiMessage not protected");
  }

  public ProtectedPkiMessage(PkiMessage pkiMessage)
  {
    if (pkiMessage.Header.ProtectionAlg == null)
      throw new ArgumentException("PkiMessage not protected");
    this.m_pkiMessage = pkiMessage;
  }

  public virtual PkiHeader Header => this.m_pkiMessage.Header;

  public virtual PkiBody Body => this.m_pkiMessage.Body;

  public virtual PkiMessage ToAsn1Message() => this.m_pkiMessage;

  public virtual bool HasPasswordBasedMacProtected
  {
    get
    {
      return CmpObjectIdentifiers.passwordBasedMac.Equals((Asn1Object) this.Header.ProtectionAlg.Algorithm);
    }
  }

  public virtual X509Certificate[] GetCertificates()
  {
    CmpCertificate[] extraCerts = this.m_pkiMessage.GetExtraCerts();
    if (extraCerts == null)
      return new X509Certificate[0];
    X509Certificate[] certificates = new X509Certificate[extraCerts.Length];
    for (int index = 0; index < extraCerts.Length; ++index)
      certificates[index] = new X509Certificate(extraCerts[index].X509v3PKCert);
    return certificates;
  }

  public virtual bool Verify(IVerifierFactory verifierFactory)
  {
    return this.Process<IVerifier>(verifierFactory.CreateCalculator()).IsVerified(this.m_pkiMessage.Protection.GetBytes());
  }

  public virtual bool Verify(PKMacBuilder pkMacBuilder, char[] password)
  {
    if (!CmpObjectIdentifiers.passwordBasedMac.Equals((Asn1Object) this.m_pkiMessage.Header.ProtectionAlg.Algorithm))
      throw new InvalidOperationException("protection algorithm is not mac based");
    PbmParameter instance = PbmParameter.GetInstance((object) this.m_pkiMessage.Header.ProtectionAlg.Parameters);
    pkMacBuilder.SetParameters(instance);
    return Arrays.FixedTimeEquals(this.Process<IBlockResult>(pkMacBuilder.Build(password).CreateCalculator()).Collect(), this.m_pkiMessage.Protection.GetBytes());
  }

  private TResult Process<TResult>(IStreamCalculator<TResult> streamCalculator)
  {
    DerSequence derSequence = new DerSequence((Asn1Encodable) this.m_pkiMessage.Header, (Asn1Encodable) this.m_pkiMessage.Body);
    return X509Utilities.CalculateResult<TResult>(streamCalculator, (Asn1Encodable) derSequence);
  }
}

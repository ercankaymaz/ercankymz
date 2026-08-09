using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Crmf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cmp;

public class ProtectedPkiMessage
{
	private readonly PkiMessage m_pkiMessage;

	public virtual PkiHeader Header => m_pkiMessage.Header;

	public virtual PkiBody Body => m_pkiMessage.Body;

	public virtual bool HasPasswordBasedMacProtected => CmpObjectIdentifiers.passwordBasedMac.Equals(Header.ProtectionAlg.Algorithm);

	public ProtectedPkiMessage(GeneralPkiMessage pkiMessage)
	{
		if (!pkiMessage.HasProtection)
		{
			throw new ArgumentException("GeneralPkiMessage not protected");
		}
		m_pkiMessage = pkiMessage.ToAsn1Structure();
	}

	public ProtectedPkiMessage(PkiMessage pkiMessage)
	{
		if (pkiMessage.Header.ProtectionAlg == null)
		{
			throw new ArgumentException("PkiMessage not protected");
		}
		m_pkiMessage = pkiMessage;
	}

	public virtual PkiMessage ToAsn1Message()
	{
		return m_pkiMessage;
	}

	public virtual X509Certificate[] GetCertificates()
	{
		CmpCertificate[] extraCerts = m_pkiMessage.GetExtraCerts();
		if (extraCerts == null)
		{
			return new X509Certificate[0];
		}
		X509Certificate[] array = new X509Certificate[extraCerts.Length];
		for (int i = 0; i < extraCerts.Length; i++)
		{
			array[i] = new X509Certificate(extraCerts[i].X509v3PKCert);
		}
		return array;
	}

	public virtual bool Verify(IVerifierFactory verifierFactory)
	{
		IStreamCalculator<IVerifier> streamCalculator = verifierFactory.CreateCalculator();
		return Process(streamCalculator).IsVerified(m_pkiMessage.Protection.GetBytes());
	}

	public virtual bool Verify(PKMacBuilder pkMacBuilder, char[] password)
	{
		if (!CmpObjectIdentifiers.passwordBasedMac.Equals(m_pkiMessage.Header.ProtectionAlg.Algorithm))
		{
			throw new InvalidOperationException("protection algorithm is not mac based");
		}
		PbmParameter instance = PbmParameter.GetInstance(m_pkiMessage.Header.ProtectionAlg.Parameters);
		pkMacBuilder.SetParameters(instance);
		IMacFactory macFactory = pkMacBuilder.Build(password);
		return Arrays.FixedTimeEquals(Process(macFactory.CreateCalculator()).Collect(), m_pkiMessage.Protection.GetBytes());
	}

	private TResult Process<TResult>(IStreamCalculator<TResult> streamCalculator)
	{
		DerSequence asn1Encodable = new DerSequence(m_pkiMessage.Header, m_pkiMessage.Body);
		return X509Utilities.CalculateResult(streamCalculator, asn1Encodable);
	}
}

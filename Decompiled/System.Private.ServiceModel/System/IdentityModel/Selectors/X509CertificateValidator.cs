using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;

namespace System.IdentityModel.Selectors;

public abstract class X509CertificateValidator
{
	private class NoneX509CertificateValidator : X509CertificateValidator
	{
		public override void Validate(X509Certificate2 certificate)
		{
			if (certificate == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
			}
		}
	}

	private class PeerTrustValidator : X509CertificateValidator
	{
		public override void Validate(X509Certificate2 certificate)
		{
			if (certificate == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
			}
			if (!TryValidate(certificate, out var exception))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
			}
		}

		private static bool StoreContainsCertificate(StoreName storeName, X509Certificate2 certificate)
		{
			X509Store x509Store = new X509Store(storeName, StoreLocation.CurrentUser);
			X509Certificate2Collection x509Certificate2Collection = null;
			try
			{
				x509Store.Open(OpenFlags.ReadOnly);
				x509Certificate2Collection = x509Store.Certificates.Find(X509FindType.FindByThumbprint, certificate.Thumbprint, validOnly: false);
				return x509Certificate2Collection.Count > 0;
			}
			finally
			{
				SecurityUtils.ResetAllCertificates(x509Certificate2Collection);
				x509Store.Dispose();
			}
		}

		internal bool TryValidate(X509Certificate2 certificate, out Exception exception)
		{
			DateTime now = DateTime.Now;
			if (now > certificate.NotAfter || now < certificate.NotBefore)
			{
				exception = new SecurityTokenValidationException(System.SR.Format(System.SR.X509InvalidUsageTime, SecurityUtils.GetCertificateId(certificate), now, certificate.NotBefore, certificate.NotAfter));
				return false;
			}
			if (!StoreContainsCertificate(StoreName.TrustedPeople, certificate))
			{
				exception = new SecurityTokenValidationException(System.SR.Format(System.SR.X509IsNotInTrustedStore, SecurityUtils.GetCertificateId(certificate)));
				return false;
			}
			if (StoreContainsCertificate(StoreName.Disallowed, certificate))
			{
				exception = new SecurityTokenValidationException(System.SR.Format(System.SR.X509IsInUntrustedStore, SecurityUtils.GetCertificateId(certificate)));
				return false;
			}
			exception = null;
			return true;
		}
	}

	private class ChainTrustValidator : X509CertificateValidator
	{
		private bool _useMachineContext;

		private X509ChainPolicy _chainPolicy;

		private uint _chainPolicyOID = 1u;

		public ChainTrustValidator()
		{
			_chainPolicy = null;
		}

		public ChainTrustValidator(bool useMachineContext, X509ChainPolicy chainPolicy, uint chainPolicyOID)
		{
			_useMachineContext = useMachineContext;
			_chainPolicy = chainPolicy;
			_chainPolicyOID = chainPolicyOID;
		}

		public override void Validate(X509Certificate2 certificate)
		{
			if (certificate == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
			}
			X509Chain x509Chain = new X509Chain();
			if (_chainPolicy != null)
			{
				_chainPolicy.VerificationTime = DateTime.Now;
				x509Chain.ChainPolicy = _chainPolicy;
			}
			if (!x509Chain.Build(certificate))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenValidationException(System.SR.Format(System.SR.X509ChainBuildFail, SecurityUtils.GetCertificateId(certificate), GetChainStatusInformation(x509Chain.ChainStatus))));
			}
		}

		private static string GetChainStatusInformation(X509ChainStatus[] chainStatus)
		{
			if (chainStatus != null)
			{
				StringBuilder stringBuilder = new StringBuilder(128);
				for (int i = 0; i < chainStatus.Length; i++)
				{
					stringBuilder.Append(chainStatus[i].StatusInformation);
					stringBuilder.Append(" ");
				}
				return stringBuilder.ToString();
			}
			return string.Empty;
		}
	}

	private class PeerOrChainTrustValidator : X509CertificateValidator
	{
		private X509CertificateValidator _chain;

		private PeerTrustValidator _peer;

		public PeerOrChainTrustValidator()
		{
			_chain = ChainTrust;
			_peer = (PeerTrustValidator)PeerTrust;
		}

		public PeerOrChainTrustValidator(bool useMachineContext, X509ChainPolicy chainPolicy)
		{
			_chain = CreateChainTrustValidator(useMachineContext, chainPolicy);
			_peer = (PeerTrustValidator)PeerTrust;
		}

		public override void Validate(X509Certificate2 certificate)
		{
			if (certificate == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
			}
			if (_peer.TryValidate(certificate, out var exception))
			{
				return;
			}
			try
			{
				_chain.Validate(certificate);
			}
			catch (SecurityTokenValidationException ex)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenValidationException(exception.Message + " " + ex.Message));
			}
		}
	}

	private static X509CertificateValidator s_peerTrust;

	private static X509CertificateValidator s_chainTrust;

	private static X509CertificateValidator s_peerOrChainTrust;

	private static X509CertificateValidator s_none;

	public static X509CertificateValidator None
	{
		get
		{
			if (s_none == null)
			{
				s_none = new NoneX509CertificateValidator();
			}
			return s_none;
		}
	}

	public static X509CertificateValidator PeerTrust
	{
		get
		{
			if (s_peerTrust == null)
			{
				s_peerTrust = new PeerTrustValidator();
			}
			return s_peerTrust;
		}
	}

	public static X509CertificateValidator ChainTrust
	{
		get
		{
			if (s_chainTrust == null)
			{
				s_chainTrust = new ChainTrustValidator();
			}
			return s_chainTrust;
		}
	}

	public static X509CertificateValidator PeerOrChainTrust
	{
		get
		{
			if (s_peerOrChainTrust == null)
			{
				s_peerOrChainTrust = new PeerOrChainTrustValidator();
			}
			return s_peerOrChainTrust;
		}
	}

	public static X509CertificateValidator CreateChainTrustValidator(bool useMachineContext, X509ChainPolicy chainPolicy)
	{
		if (chainPolicy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("chainPolicy");
		}
		return new ChainTrustValidator(useMachineContext, chainPolicy, 1u);
	}

	public static X509CertificateValidator CreatePeerOrChainTrustValidator(bool useMachineContext, X509ChainPolicy chainPolicy)
	{
		if (chainPolicy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("chainPolicy");
		}
		return new PeerOrChainTrustValidator(useMachineContext, chainPolicy);
	}

	public abstract void Validate(X509Certificate2 certificate);
}

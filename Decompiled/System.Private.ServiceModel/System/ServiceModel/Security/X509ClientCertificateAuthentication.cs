using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;

namespace System.ServiceModel.Security;

public class X509ClientCertificateAuthentication
{
	internal const X509CertificateValidationMode DefaultCertificateValidationMode = X509CertificateValidationMode.ChainTrust;

	internal const X509RevocationMode DefaultRevocationMode = X509RevocationMode.Online;

	internal const StoreLocation DefaultTrustedStoreLocation = StoreLocation.LocalMachine;

	private static X509CertificateValidator s_defaultCertificateValidator;

	internal static X509CertificateValidator DefaultCertificateValidator
	{
		get
		{
			if (s_defaultCertificateValidator == null)
			{
				bool useMachineContext = true;
				X509ChainPolicy x509ChainPolicy = new X509ChainPolicy();
				x509ChainPolicy.RevocationMode = X509RevocationMode.Online;
				s_defaultCertificateValidator = X509CertificateValidator.CreateChainTrustValidator(useMachineContext, x509ChainPolicy);
			}
			return s_defaultCertificateValidator;
		}
	}
}

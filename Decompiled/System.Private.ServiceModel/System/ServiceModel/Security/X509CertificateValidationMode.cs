namespace System.ServiceModel.Security;

public enum X509CertificateValidationMode
{
	None,
	PeerTrust,
	ChainTrust,
	PeerOrChainTrust,
	Custom
}

namespace System.ServiceModel;

public enum HttpClientCredentialType
{
	None,
	Basic,
	Digest,
	Ntlm,
	Windows,
	Certificate,
	InheritedFromHost
}

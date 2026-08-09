namespace System.ServiceModel.Security;

internal enum ReceiveSecurityHeaderElementCategory
{
	Signature,
	EncryptedData,
	EncryptedKey,
	SignatureConfirmation,
	ReferenceList,
	SecurityTokenReference,
	Timestamp,
	Token
}

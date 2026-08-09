namespace System.ServiceModel.Security;

public enum MessageProtectionOrder
{
	SignBeforeEncrypt,
	SignBeforeEncryptAndEncryptSignature,
	EncryptBeforeSign
}

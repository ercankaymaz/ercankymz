namespace System.ServiceModel.Security;

internal enum MessagePartProtectionMode
{
	None,
	Sign,
	Encrypt,
	SignThenEncrypt,
	EncryptThenSign
}

namespace System.ServiceModel.Security;

internal static class MessageProtectionOrderHelper
{
	internal static bool IsDefined(MessageProtectionOrder value)
	{
		if (value != MessageProtectionOrder.SignBeforeEncrypt && value != MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature)
		{
			return value == MessageProtectionOrder.EncryptBeforeSign;
		}
		return true;
	}
}

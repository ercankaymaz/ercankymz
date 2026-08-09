namespace System.ServiceModel.Security;

internal static class MessagePartProtectionModeHelper
{
	public static MessagePartProtectionMode GetProtectionMode(bool sign, bool encrypt, bool signThenEncrypt)
	{
		if (sign)
		{
			if (encrypt)
			{
				if (signThenEncrypt)
				{
					return MessagePartProtectionMode.SignThenEncrypt;
				}
				return MessagePartProtectionMode.EncryptThenSign;
			}
			return MessagePartProtectionMode.Sign;
		}
		if (encrypt)
		{
			return MessagePartProtectionMode.Encrypt;
		}
		return MessagePartProtectionMode.None;
	}
}

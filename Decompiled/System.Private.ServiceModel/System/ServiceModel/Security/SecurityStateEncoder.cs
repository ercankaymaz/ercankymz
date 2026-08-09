namespace System.ServiceModel.Security;

public abstract class SecurityStateEncoder
{
	protected internal abstract byte[] DecodeSecurityState(byte[] data);

	protected internal abstract byte[] EncodeSecurityState(byte[] data);
}

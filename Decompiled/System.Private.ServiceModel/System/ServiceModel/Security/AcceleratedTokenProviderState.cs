namespace System.ServiceModel.Security;

internal class AcceleratedTokenProviderState : IssuanceTokenProviderState
{
	private byte[] _entropy;

	public AcceleratedTokenProviderState(byte[] value)
	{
		_entropy = value;
	}

	public byte[] GetRequestorEntropy()
	{
		return _entropy;
	}
}

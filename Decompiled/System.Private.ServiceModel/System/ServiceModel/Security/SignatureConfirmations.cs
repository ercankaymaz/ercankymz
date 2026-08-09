namespace System.ServiceModel.Security;

internal class SignatureConfirmations
{
	private struct SignatureConfirmation(byte[] value)
	{
		public byte[] value = value;
	}

	private SignatureConfirmation[] _confirmations;

	public int Count { get; private set; }

	public bool IsMarkedForEncryption { get; private set; }

	public SignatureConfirmations()
	{
		_confirmations = new SignatureConfirmation[1];
		Count = 0;
	}

	public void AddConfirmation(byte[] value, bool encrypted)
	{
		if (_confirmations.Length == Count)
		{
			SignatureConfirmation[] array = new SignatureConfirmation[Count * 2];
			Array.Copy(_confirmations, 0, array, 0, Count);
			_confirmations = array;
		}
		_confirmations[Count] = new SignatureConfirmation(value);
		int count = Count + 1;
		Count = count;
		IsMarkedForEncryption |= encrypted;
	}
}

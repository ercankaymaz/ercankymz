namespace System.ServiceModel.Channels;

internal static class IntEncoder
{
	public const int MaxEncodedSize = 5;

	public static int Encode(int value, byte[] bytes, int offset)
	{
		int num = 1;
		while ((value & 0xFFFFFF80u) != 0L)
		{
			bytes[offset++] = (byte)((value & 0x7F) | 0x80);
			num++;
			value >>= 7;
		}
		bytes[offset] = (byte)value;
		return num;
	}

	public static int GetEncodedSize(int value)
	{
		if (value < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
		}
		int num = 1;
		while ((value & 0xFFFFFF80u) != 0L)
		{
			num++;
			value >>= 7;
		}
		return num;
	}
}

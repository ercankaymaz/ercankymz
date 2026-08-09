namespace System.ServiceModel.Channels;

internal static class DecoderHelper
{
	public static void ValidateSize(int size)
	{
		if (size <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.ValueMustBePositive));
		}
	}
}

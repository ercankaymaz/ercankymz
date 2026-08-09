namespace System.ServiceModel;

internal static class OperationFormatUseHelper
{
	public static bool IsDefined(OperationFormatUse x)
	{
		if (x != OperationFormatUse.Literal)
		{
			return x == OperationFormatUse.Encoded;
		}
		return true;
	}
}

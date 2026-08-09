namespace System.ServiceModel;

internal static class NetHttpMessageEncodingHelper
{
	internal static bool IsDefined(NetHttpMessageEncoding value)
	{
		if (value != NetHttpMessageEncoding.Binary && value != NetHttpMessageEncoding.Text)
		{
			return value == NetHttpMessageEncoding.Mtom;
		}
		return true;
	}
}

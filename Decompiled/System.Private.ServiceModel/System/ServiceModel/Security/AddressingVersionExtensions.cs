using System.ServiceModel.Channels;

namespace System.ServiceModel.Security;

internal static class AddressingVersionExtensions
{
	public static string Namespace(this AddressingVersion addressingVersion)
	{
		string text = AddressingVersion.WSAddressingAugust2004.ToString();
		int num = text.IndexOf('(');
		return text.Substring(num + 1, text.Length - num - 2);
	}
}

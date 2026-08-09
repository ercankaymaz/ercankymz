using System.ServiceModel.Channels;

namespace System.ServiceModel;

internal static class WSMessageEncodingHelper
{
	internal static bool IsDefined(WSMessageEncoding value)
	{
		return value == WSMessageEncoding.Text;
	}

	internal static void SyncUpEncodingBindingElementProperties(TextMessageEncodingBindingElement textEncoding, MtomMessageEncodingBindingElement mtomEncoding)
	{
		textEncoding.ReaderQuotas.CopyTo(mtomEncoding.ReaderQuotas);
		mtomEncoding.WriteEncoding = textEncoding.WriteEncoding;
	}
}

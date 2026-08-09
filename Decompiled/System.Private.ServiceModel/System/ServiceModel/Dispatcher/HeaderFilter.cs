using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal abstract class HeaderFilter : MessageFilter
{
	public override bool Match(MessageBuffer buffer)
	{
		if (buffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
		}
		Message message = buffer.CreateMessage();
		try
		{
			return Match(message);
		}
		finally
		{
			message.Close();
		}
	}
}

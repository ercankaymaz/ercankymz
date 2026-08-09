using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Description;

internal class XmlMessageConverter : TypedMessageConverter
{
	private OperationFormatter formatter;

	internal string Action => formatter.RequestAction;

	internal XmlMessageConverter(OperationFormatter formatter)
	{
		this.formatter = formatter;
	}

	public override Message ToMessage(object typedMessage)
	{
		return ToMessage(typedMessage, MessageVersion.Soap12WSAddressing10);
	}

	public override Message ToMessage(object typedMessage, MessageVersion version)
	{
		if (typedMessage == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("typedMessage"));
		}
		return formatter.SerializeRequest(version, new object[1] { typedMessage });
	}

	public override object FromMessage(Message message)
	{
		if (Action != null && message.Headers.Action != null && message.Headers.Action != Action)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxActionMismatch, Action, message.Headers.Action)));
		}
		object[] array = new object[1];
		formatter.DeserializeRequest(message, array);
		return array[0];
	}
}

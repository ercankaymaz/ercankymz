using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal sealed class MessageOperationFormatter : IClientMessageFormatter, IDispatchMessageFormatter
{
	private static MessageOperationFormatter s_instance;

	internal static MessageOperationFormatter Instance
	{
		get
		{
			if (s_instance == null)
			{
				s_instance = new MessageOperationFormatter();
			}
			return s_instance;
		}
	}

	public object DeserializeReply(Message message, object[] parameters)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		if (parameters != null && parameters.Length != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxParametersMustBeEmpty));
		}
		return message;
	}

	public void DeserializeRequest(Message message, object[] parameters)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		if (parameters == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("parameters"), message);
		}
		if (parameters.Length != 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxParameterMustBeArrayOfOneElement));
		}
		parameters[0] = message;
	}

	public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
	{
		if (!(result is Message))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxResultMustBeMessage));
		}
		if (parameters != null && parameters.Length != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxParametersMustBeEmpty));
		}
		return (Message)result;
	}

	public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
	{
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parameters"));
		}
		if (parameters.Length != 1 || !(parameters[0] is Message))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFxParameterMustBeMessage));
		}
		return (Message)parameters[0];
	}
}

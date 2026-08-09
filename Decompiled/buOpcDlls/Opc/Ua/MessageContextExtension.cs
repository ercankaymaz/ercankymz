using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class MessageContextExtension
{
	public static MessageContextExtension Current => null;

	public static IServiceMessageContext CurrentContext
	{
		get
		{
			MessageContextExtension current = Current;
			if (current != null)
			{
				return current.MessageContext;
			}
			return ServiceMessageContext.ThreadContext;
		}
	}

	public IServiceMessageContext MessageContext { get; private set; }

	public MessageContextExtension(IServiceMessageContext messageContext)
	{
		MessageContext = messageContext;
	}
}

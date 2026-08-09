using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Description;

public abstract class TypedMessageConverter
{
	public static TypedMessageConverter Create(Type messageContract, string action)
	{
		return Create(messageContract, action, null, TypeLoader.DefaultDataContractFormatAttribute);
	}

	public static TypedMessageConverter Create(Type messageContract, string action, string defaultNamespace)
	{
		return Create(messageContract, action, defaultNamespace, TypeLoader.DefaultDataContractFormatAttribute);
	}

	public static TypedMessageConverter Create(Type messageContract, string action, XmlSerializerFormatAttribute formatterAttribute)
	{
		return Create(messageContract, action, null, formatterAttribute);
	}

	public static TypedMessageConverter Create(Type messageContract, string action, DataContractFormatAttribute formatterAttribute)
	{
		return Create(messageContract, action, null, formatterAttribute);
	}

	public static TypedMessageConverter Create(Type messageContract, string action, string defaultNamespace, XmlSerializerFormatAttribute formatterAttribute)
	{
		if (messageContract == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageContract"));
		}
		if (defaultNamespace == null)
		{
			defaultNamespace = "http://tempuri.org/";
		}
		return new XmlMessageConverter(GetOperationFormatter(messageContract, formatterAttribute, defaultNamespace, action));
	}

	public static TypedMessageConverter Create(Type messageContract, string action, string defaultNamespace, DataContractFormatAttribute formatterAttribute)
	{
		if (messageContract == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageContract"));
		}
		if (!messageContract.IsDefined(typeof(MessageContractAttribute), inherit: false))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SFxMessageContractAttributeRequired, messageContract), "messageContract"));
		}
		if (defaultNamespace == null)
		{
			defaultNamespace = "http://tempuri.org/";
		}
		return new XmlMessageConverter(GetOperationFormatter(messageContract, formatterAttribute, defaultNamespace, action));
	}

	public abstract Message ToMessage(object typedMessage);

	public abstract Message ToMessage(object typedMessage, MessageVersion version);

	public abstract object FromMessage(Message message);

	private static OperationFormatter GetOperationFormatter(Type t, Attribute formatAttribute, string defaultNS, string action)
	{
		bool flag = formatAttribute is XmlSerializerFormatAttribute;
		TypeLoader typeLoader = new TypeLoader();
		MessageDescription item = typeLoader.CreateTypedMessageDescription(t, null, null, defaultNS, action, MessageDirection.Output);
		ContractDescription declaringContract = new ContractDescription("dummy_contract", defaultNS);
		OperationDescription operationDescription = new OperationDescription(NamingHelper.XmlName(t.Name), declaringContract, validateRpcWrapperName: false);
		operationDescription.Messages.Add(item);
		if (flag)
		{
			return XmlSerializerOperationBehavior.CreateOperationFormatter(operationDescription, (XmlSerializerFormatAttribute)formatAttribute);
		}
		return new DataContractSerializerOperationFormatter(operationDescription, (DataContractFormatAttribute)formatAttribute, null);
	}
}

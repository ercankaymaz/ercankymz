using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace System.ServiceModel.Description;

public class DataContractSerializerOperationBehavior : IOperationBehavior
{
	private OperationDescription _operation;

	internal bool ignoreExtensionDataObject;

	internal int maxItemsInObjectGraph = int.MaxValue;

	private DataContractResolver _dataContractResolver;

	public DataContractFormatAttribute DataContractFormatAttribute { get; }

	internal bool IsBuiltInOperationBehavior { get; }

	public int MaxItemsInObjectGraph
	{
		get
		{
			return maxItemsInObjectGraph;
		}
		set
		{
			maxItemsInObjectGraph = value;
			MaxItemsInObjectGraphSetExplicit = true;
		}
	}

	internal bool MaxItemsInObjectGraphSetExplicit { get; set; }

	public bool IgnoreExtensionDataObject
	{
		get
		{
			return ignoreExtensionDataObject;
		}
		set
		{
			ignoreExtensionDataObject = value;
			IgnoreExtensionDataObjectSetExplicit = true;
		}
	}

	internal bool IgnoreExtensionDataObjectSetExplicit { get; set; }

	public ISerializationSurrogateProvider SerializationSurrogateProvider { get; set; }

	public DataContractResolver DataContractResolver
	{
		get
		{
			return _dataContractResolver;
		}
		set
		{
			_dataContractResolver = value;
		}
	}

	public DataContractSerializerOperationBehavior(OperationDescription operation)
		: this(operation, null)
	{
	}

	public DataContractSerializerOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
	{
		DataContractFormatAttribute = dataContractFormatAttribute ?? new DataContractFormatAttribute();
		_operation = operation;
	}

	internal DataContractSerializerOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute, bool builtInOperationBehavior)
		: this(operation, dataContractFormatAttribute)
	{
		IsBuiltInOperationBehavior = builtInOperationBehavior;
	}

	public virtual XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
	{
		XmlDictionary xmlDictionary = new XmlDictionary(2);
		DataContractSerializerSettings dataContractSerializerSettings = new DataContractSerializerSettings();
		dataContractSerializerSettings.RootName = xmlDictionary.Add(name);
		dataContractSerializerSettings.RootNamespace = xmlDictionary.Add(ns);
		dataContractSerializerSettings.KnownTypes = knownTypes;
		dataContractSerializerSettings.MaxItemsInObjectGraph = MaxItemsInObjectGraph;
		dataContractSerializerSettings.DataContractResolver = DataContractResolver;
		DataContractSerializer dataContractSerializer = new DataContractSerializer(type, dataContractSerializerSettings);
		dataContractSerializer.SetSerializationSurrogateProvider(SerializationSurrogateProvider);
		return dataContractSerializer;
	}

	public virtual XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
	{
		DataContractSerializerSettings dataContractSerializerSettings = new DataContractSerializerSettings();
		dataContractSerializerSettings.RootName = name;
		dataContractSerializerSettings.RootNamespace = ns;
		dataContractSerializerSettings.KnownTypes = knownTypes;
		dataContractSerializerSettings.MaxItemsInObjectGraph = MaxItemsInObjectGraph;
		dataContractSerializerSettings.DataContractResolver = DataContractResolver;
		DataContractSerializer dataContractSerializer = new DataContractSerializer(type, dataContractSerializerSettings);
		dataContractSerializer.SetSerializationSurrogateProvider(SerializationSurrogateProvider);
		return dataContractSerializer;
	}

	internal object GetFormatter(OperationDescription operation, out bool formatRequest, out bool formatReply, bool isProxy)
	{
		MessageDescription messageDescription = operation.Messages[0];
		MessageDescription messageDescription2 = null;
		if (operation.Messages.Count == 2)
		{
			messageDescription2 = operation.Messages[1];
		}
		formatRequest = messageDescription != null && !messageDescription.IsUntypedMessage;
		formatReply = messageDescription2 != null && !messageDescription2.IsUntypedMessage;
		if (formatRequest | formatReply)
		{
			if (PrimitiveOperationFormatter.IsContractSupported(operation))
			{
				return new PrimitiveOperationFormatter(operation, DataContractFormatAttribute.Style == OperationFormatStyle.Rpc);
			}
			return new DataContractSerializerOperationFormatter(operation, DataContractFormatAttribute, this);
		}
		return null;
	}

	void IOperationBehavior.Validate(OperationDescription description)
	{
	}

	void IOperationBehavior.AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
	{
	}

	void IOperationBehavior.ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (dispatch == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("dispatch");
		}
		if (dispatch.Formatter == null)
		{
			dispatch.Formatter = (IDispatchMessageFormatter)GetFormatter(description, out var formatRequest, out var formatReply, isProxy: false);
			dispatch.DeserializeRequest = formatRequest;
			dispatch.SerializeReply = formatReply;
		}
	}

	void IOperationBehavior.ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (proxy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("proxy");
		}
		if (proxy.Formatter == null)
		{
			proxy.Formatter = (IClientMessageFormatter)GetFormatter(description, out var formatRequest, out var formatReply, isProxy: true);
			proxy.SerializeRequest = formatRequest;
			proxy.DeserializeReply = formatReply;
		}
	}
}

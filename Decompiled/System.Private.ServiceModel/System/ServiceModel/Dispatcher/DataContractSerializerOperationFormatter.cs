using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class DataContractSerializerOperationFormatter : OperationFormatter
{
	internal class DataContractSerializerMessageHeader : XmlObjectSerializerHeader
	{
		private PartInfo _headerPart;

		public DataContractSerializerMessageHeader(PartInfo headerPart, object headerValue, bool mustUnderstand, string actor, bool relay)
			: base(headerPart.DictionaryName.Value, headerPart.DictionaryNamespace.Value, headerValue, headerPart.Serializer, mustUnderstand, actor ?? string.Empty, relay)
		{
			_headerPart = headerPart;
		}

		protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			string prefix = ((Namespace == null || Namespace.Length == 0) ? string.Empty : "h");
			writer.WriteStartElement(prefix, _headerPart.DictionaryName, _headerPart.DictionaryNamespace);
			WriteHeaderAttributes(writer, messageVersion);
		}
	}

	internal class MessageInfo
	{
		internal PartInfo[] HeaderParts;

		internal XmlDictionaryString WrapperName;

		internal XmlDictionaryString WrapperNamespace;

		internal PartInfo[] BodyParts;

		internal PartInfo ReturnPart;

		internal MessageHeaderDescriptionTable HeaderDescriptionTable;

		internal MessageHeaderDescription UnknownHeaderDescription;

		internal bool AnyHeaders;
	}

	internal class PartInfo
	{
		private XmlDictionaryString _dictionaryNamespace;

		private XmlObjectSerializer _serializer;

		private IList<Type> _knownTypes;

		private DataContractSerializerOperationBehavior _serializerFactory;

		private bool _isQueryable;

		public Type ContractType { get; }

		public MessagePartDescription Description { get; }

		public XmlDictionaryString DictionaryName { get; }

		public XmlDictionaryString DictionaryNamespace => _dictionaryNamespace;

		public XmlObjectSerializer Serializer
		{
			get
			{
				if (_serializer == null)
				{
					_serializer = _serializerFactory.CreateSerializer(Description.Type, DictionaryName, DictionaryNamespace, _knownTypes);
				}
				return _serializer;
			}
		}

		public PartInfo(MessagePartDescription description, XmlDictionaryString dictionaryName, XmlDictionaryString dictionaryNamespace, IList<Type> knownTypes, DataContractSerializerOperationBehavior behavior)
		{
			DictionaryName = dictionaryName;
			_dictionaryNamespace = dictionaryNamespace;
			Description = description;
			_knownTypes = knownTypes;
			_serializerFactory = behavior;
			ContractType = null;
			_isQueryable = false;
		}

		public object ReadObject(XmlDictionaryReader reader)
		{
			return ReadObject(reader, Serializer);
		}

		public object ReadObject(XmlDictionaryReader reader, XmlObjectSerializer serializer)
		{
			object obj = _serializer.ReadObject(reader, verifyObjectName: false);
			if (_isQueryable && obj != null)
			{
				return ((IEnumerable)obj).AsQueryable();
			}
			return obj;
		}
	}

	private static Type s_typeOfIQueryable = typeof(IQueryable);

	private static Type s_typeOfIQueryableGeneric = typeof(IQueryable<>);

	private static Type s_typeOfIEnumerable = typeof(IEnumerable);

	private static Type s_typeOfIEnumerableGeneric = typeof(IEnumerable<>);

	protected MessageInfo requestMessageInfo;

	protected MessageInfo replyMessageInfo;

	private IList<Type> _knownTypes;

	private DataContractSerializerOperationBehavior _serializerFactory;

	public DataContractSerializerOperationFormatter(OperationDescription description, DataContractFormatAttribute dataContractFormatAttribute, DataContractSerializerOperationBehavior serializerFactory)
		: base(description, dataContractFormatAttribute.Style == OperationFormatStyle.Rpc, isEncoded: false)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		_serializerFactory = serializerFactory ?? new DataContractSerializerOperationBehavior(description);
		foreach (Type knownType in description.KnownTypes)
		{
			if (_knownTypes == null)
			{
				_knownTypes = new List<Type>();
			}
			if (knownType == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxKnownTypeNull, description.Name)));
			}
			ValidateDataContractType(knownType);
			_knownTypes.Add(knownType);
		}
		requestMessageInfo = CreateMessageInfo(dataContractFormatAttribute, base.RequestDescription, _serializerFactory);
		if (base.ReplyDescription != null)
		{
			replyMessageInfo = CreateMessageInfo(dataContractFormatAttribute, base.ReplyDescription, _serializerFactory);
		}
	}

	private MessageInfo CreateMessageInfo(DataContractFormatAttribute dataContractFormatAttribute, MessageDescription messageDescription, DataContractSerializerOperationBehavior serializerFactory)
	{
		if (messageDescription.IsUntypedMessage)
		{
			return null;
		}
		MessageInfo messageInfo = new MessageInfo();
		MessageBodyDescription body = messageDescription.Body;
		if (body.WrapperName != null)
		{
			messageInfo.WrapperName = AddToDictionary(body.WrapperName);
			messageInfo.WrapperNamespace = AddToDictionary(body.WrapperNamespace);
		}
		MessagePartDescriptionCollection parts = body.Parts;
		messageInfo.BodyParts = new PartInfo[parts.Count];
		for (int i = 0; i < parts.Count; i++)
		{
			messageInfo.BodyParts[i] = CreatePartInfo(parts[i], dataContractFormatAttribute.Style, serializerFactory);
		}
		if (OperationFormatter.IsValidReturnValue(messageDescription.Body.ReturnValue))
		{
			messageInfo.ReturnPart = CreatePartInfo(messageDescription.Body.ReturnValue, dataContractFormatAttribute.Style, serializerFactory);
		}
		messageInfo.HeaderDescriptionTable = new MessageHeaderDescriptionTable();
		messageInfo.HeaderParts = new PartInfo[messageDescription.Headers.Count];
		for (int j = 0; j < messageDescription.Headers.Count; j++)
		{
			MessageHeaderDescription messageHeaderDescription = messageDescription.Headers[j];
			if (messageHeaderDescription.IsUnknownHeaderCollection)
			{
				messageInfo.UnknownHeaderDescription = messageHeaderDescription;
			}
			else
			{
				ValidateDataContractType(messageHeaderDescription.Type);
				messageInfo.HeaderDescriptionTable.Add(messageHeaderDescription.Name, messageHeaderDescription.Namespace, messageHeaderDescription);
			}
			messageInfo.HeaderParts[j] = CreatePartInfo(messageHeaderDescription, OperationFormatStyle.Document, serializerFactory);
		}
		messageInfo.AnyHeaders = messageInfo.UnknownHeaderDescription != null || messageInfo.HeaderDescriptionTable.Count > 0;
		return messageInfo;
	}

	private void ValidateDataContractType(Type type)
	{
	}

	private PartInfo CreatePartInfo(MessagePartDescription part, OperationFormatStyle style, DataContractSerializerOperationBehavior serializerFactory)
	{
		string s = ((style == OperationFormatStyle.Rpc || part.Namespace == null) ? string.Empty : part.Namespace);
		return new PartInfo(part, AddToDictionary(part.Name), AddToDictionary(s), _knownTypes, serializerFactory);
	}

	protected override void AddHeadersToMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		MessageInfo messageInfo = (isRequest ? requestMessageInfo : replyMessageInfo);
		PartInfo[] headerParts = messageInfo.HeaderParts;
		if (headerParts == null || headerParts.Length == 0)
		{
			return;
		}
		MessageHeaders headers = message.Headers;
		foreach (PartInfo partInfo in headerParts)
		{
			MessageHeaderDescription messageHeaderDescription = (MessageHeaderDescription)partInfo.Description;
			object obj = parameters[messageHeaderDescription.Index];
			if (messageHeaderDescription.Multiple)
			{
				if (obj == null)
				{
					continue;
				}
				foreach (object item in (IEnumerable)obj)
				{
					AddMessageHeaderForParameter(headers, partInfo, message.Version, item, isXmlElement: false);
				}
			}
			else
			{
				AddMessageHeaderForParameter(headers, partInfo, message.Version, obj, isXmlElement: false);
			}
		}
	}

	private void AddMessageHeaderForParameter(MessageHeaders headers, PartInfo headerPart, MessageVersion messageVersion, object parameterValue, bool isXmlElement)
	{
		MessageHeaderDescription headerDescription = (MessageHeaderDescription)headerPart.Description;
		bool mustUnderstand;
		bool relay;
		string actor;
		object contentOfMessageHeaderOfT = OperationFormatter.GetContentOfMessageHeaderOfT(headerDescription, parameterValue, out mustUnderstand, out relay, out actor);
		if (isXmlElement)
		{
			if (contentOfMessageHeaderOfT != null)
			{
				XmlElement xmlElement = (XmlElement)contentOfMessageHeaderOfT;
				headers.Add(new XmlElementMessageHeader(this, messageVersion, xmlElement.LocalName, xmlElement.NamespaceURI, mustUnderstand, actor, relay, xmlElement));
			}
		}
		else
		{
			headers.Add(new DataContractSerializerMessageHeader(headerPart, contentOfMessageHeaderOfT, mustUnderstand, actor, relay));
		}
	}

	protected override void SerializeBody(XmlDictionaryWriter writer, MessageVersion version, string action, MessageDescription messageDescription, object returnValue, object[] parameters, bool isRequest)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parameters"));
		}
		MessageInfo messageInfo = ((!isRequest) ? replyMessageInfo : requestMessageInfo);
		if (messageInfo.WrapperName != null)
		{
			writer.WriteStartElement(messageInfo.WrapperName, messageInfo.WrapperNamespace);
		}
		if (messageInfo.ReturnPart != null)
		{
			SerializeParameter(writer, messageInfo.ReturnPart, returnValue);
		}
		SerializeParameters(writer, messageInfo.BodyParts, parameters);
		if (messageInfo.WrapperName != null)
		{
			writer.WriteEndElement();
		}
	}

	private void SerializeParameters(XmlDictionaryWriter writer, PartInfo[] parts, object[] parameters)
	{
		foreach (PartInfo partInfo in parts)
		{
			object graph = parameters[partInfo.Description.Index];
			SerializeParameter(writer, partInfo, graph);
		}
	}

	private void SerializeParameter(XmlDictionaryWriter writer, PartInfo part, object graph)
	{
		if (part.Description.Multiple)
		{
			if (graph == null)
			{
				return;
			}
			{
				foreach (object item in (IEnumerable)graph)
				{
					SerializeParameterPart(writer, part, item);
				}
				return;
			}
		}
		SerializeParameterPart(writer, part, graph);
	}

	private void SerializeParameterPart(XmlDictionaryWriter writer, PartInfo part, object graph)
	{
		try
		{
			part.Serializer.WriteObject(writer, graph);
		}
		catch (SerializationException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxInvalidMessageBodyErrorSerializingParameter, part.Description.Namespace, part.Description.Name, ex.Message), ex));
		}
	}

	protected override void GetHeadersFromMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		MessageInfo messageInfo = (isRequest ? requestMessageInfo : replyMessageInfo);
		if (!messageInfo.AnyHeaders)
		{
			return;
		}
		MessageHeaders headers = message.Headers;
		KeyValuePair<Type, ArrayList>[] array = null;
		ArrayList arrayList = null;
		if (messageInfo.UnknownHeaderDescription != null)
		{
			arrayList = new ArrayList();
		}
		for (int i = 0; i < headers.Count; i++)
		{
			MessageHeaderInfo messageHeaderInfo = headers[i];
			MessageHeaderDescription messageHeaderDescription = messageInfo.HeaderDescriptionTable.Get(messageHeaderInfo.Name, messageHeaderInfo.Namespace);
			if (messageHeaderDescription != null)
			{
				if (messageHeaderInfo.MustUnderstand)
				{
					headers.UnderstoodHeaders.Add(messageHeaderInfo);
				}
				object obj = null;
				XmlDictionaryReader readerAtHeader = headers.GetReaderAtHeader(i);
				try
				{
					object obj2 = DeserializeHeaderContents(readerAtHeader, messageDescription, messageHeaderDescription);
					obj = ((!messageHeaderDescription.TypedHeader) ? obj2 : TypedHeaderManager.Create(messageHeaderDescription.Type, obj2, headers[i].MustUnderstand, headers[i].Relay, headers[i].Actor));
				}
				finally
				{
					readerAtHeader.Dispose();
				}
				if (messageHeaderDescription.Multiple)
				{
					if (array == null)
					{
						array = new KeyValuePair<Type, ArrayList>[parameters.Length];
					}
					if (array[messageHeaderDescription.Index].Key == null)
					{
						array[messageHeaderDescription.Index] = new KeyValuePair<Type, ArrayList>(messageHeaderDescription.TypedHeader ? TypedHeaderManager.GetMessageHeaderType(messageHeaderDescription.Type) : messageHeaderDescription.Type, new ArrayList());
					}
					array[messageHeaderDescription.Index].Value.Add(obj);
				}
				else
				{
					parameters[messageHeaderDescription.Index] = obj;
				}
			}
			else
			{
				if (messageInfo.UnknownHeaderDescription == null)
				{
					continue;
				}
				MessageHeaderDescription unknownHeaderDescription = messageInfo.UnknownHeaderDescription;
				XmlDictionaryReader readerAtHeader2 = headers.GetReaderAtHeader(i);
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					object obj3 = xmlDocument.ReadNode(readerAtHeader2);
					if (obj3 != null && unknownHeaderDescription.TypedHeader)
					{
						obj3 = TypedHeaderManager.Create(unknownHeaderDescription.Type, obj3, headers[i].MustUnderstand, headers[i].Relay, headers[i].Actor);
					}
					arrayList.Add(obj3);
				}
				finally
				{
					readerAtHeader2.Dispose();
				}
			}
		}
		if (array == null)
		{
			return;
		}
		for (int j = 0; j < parameters.Length; j++)
		{
			if (array[j].Key != null)
			{
				parameters[j] = array[j].Value.ToArray(array[j].Key);
			}
		}
	}

	private object DeserializeHeaderContents(XmlDictionaryReader reader, MessageDescription messageDescription, MessageHeaderDescription headerDescription)
	{
		bool isQueryable;
		Type substituteDataContractType = GetSubstituteDataContractType(headerDescription.Type, out isQueryable);
		XmlObjectSerializer xmlObjectSerializer = _serializerFactory.CreateSerializer(substituteDataContractType, headerDescription.Name, headerDescription.Namespace, _knownTypes);
		object obj = xmlObjectSerializer.ReadObject(reader);
		if (isQueryable && obj != null)
		{
			return ((IEnumerable)obj).AsQueryable();
		}
		return obj;
	}

	protected override object DeserializeBody(XmlDictionaryReader reader, MessageVersion version, string action, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reader"));
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parameters"));
		}
		MessageInfo messageInfo = ((!isRequest) ? replyMessageInfo : requestMessageInfo);
		if (messageInfo.WrapperName != null)
		{
			if (!reader.IsStartElement(messageInfo.WrapperName, messageInfo.WrapperNamespace))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SerializationException(System.SR.Format(System.SR.SFxInvalidMessageBody, messageInfo.WrapperName, messageInfo.WrapperNamespace, reader.NodeType, reader.Name, reader.NamespaceURI)));
			}
			bool isEmptyElement = reader.IsEmptyElement;
			reader.Read();
			if (isEmptyElement)
			{
				return null;
			}
		}
		object result = null;
		if (messageInfo.ReturnPart != null)
		{
			while (true)
			{
				PartInfo returnPart = messageInfo.ReturnPart;
				if (returnPart.Serializer.IsStartObject(reader))
				{
					result = DeserializeParameter(reader, returnPart, isRequest);
					break;
				}
				if (!reader.IsStartElement())
				{
					break;
				}
				OperationFormatter.TraceAndSkipElement(reader);
			}
		}
		DeserializeParameters(reader, messageInfo.BodyParts, parameters, isRequest);
		if (messageInfo.WrapperName != null)
		{
			reader.ReadEndElement();
		}
		return result;
	}

	private void DeserializeParameters(XmlDictionaryReader reader, PartInfo[] parts, object[] parameters, bool isRequest)
	{
		int num = 0;
		while (reader.IsStartElement())
		{
			for (int i = num; i < parts.Length; i++)
			{
				PartInfo partInfo = parts[i];
				if (partInfo.Serializer.IsStartObject(reader))
				{
					object obj = DeserializeParameter(reader, partInfo, isRequest);
					parameters[partInfo.Description.Index] = obj;
					num = i + 1;
				}
				else
				{
					parameters[partInfo.Description.Index] = null;
				}
			}
			if (reader.IsStartElement())
			{
				OperationFormatter.TraceAndSkipElement(reader);
			}
		}
	}

	private object DeserializeParameter(XmlDictionaryReader reader, PartInfo part, bool isRequest)
	{
		if (part.Description.Multiple)
		{
			ArrayList arrayList = new ArrayList();
			while (part.Serializer.IsStartObject(reader))
			{
				arrayList.Add(DeserializeParameterPart(reader, part, isRequest));
			}
			return arrayList.ToArray(part.Description.Type);
		}
		return DeserializeParameterPart(reader, part, isRequest);
	}

	private object DeserializeParameterPart(XmlDictionaryReader reader, PartInfo part, bool isRequest)
	{
		try
		{
			return part.ReadObject(reader);
		}
		catch (InvalidOperationException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidMessageBodyErrorDeserializingParameter, part.Description.Namespace, part.Description.Name), innerException));
		}
		catch (InvalidDataContractException innerException2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataContractException(System.SR.Format(System.SR.SFxInvalidMessageBodyErrorDeserializingParameter, part.Description.Namespace, part.Description.Name), innerException2));
		}
		catch (FormatException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(OperationFormatter.CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxInvalidMessageBodyErrorDeserializingParameterMore, part.Description.Namespace, part.Description.Name, ex.Message), ex));
		}
		catch (SerializationException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(OperationFormatter.CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxInvalidMessageBodyErrorDeserializingParameterMore, part.Description.Namespace, part.Description.Name, ex2.Message), ex2));
		}
	}

	internal static Type GetSubstituteDataContractType(Type type, out bool isQueryable)
	{
		if (type == s_typeOfIQueryable)
		{
			isQueryable = true;
			return s_typeOfIEnumerable;
		}
		if (type.IsGenericType() && type.GetGenericTypeDefinition() == s_typeOfIQueryableGeneric)
		{
			isQueryable = true;
			return s_typeOfIEnumerableGeneric.MakeGenericType(type.GetGenericArguments());
		}
		isQueryable = false;
		return type;
	}
}

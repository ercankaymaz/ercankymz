using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class PrimitiveOperationFormatter : IClientMessageFormatter, IDispatchMessageFormatter
{
	internal class PartInfo
	{
		private XmlDictionaryString _itemName;

		private XmlDictionaryString _itemNamespace;

		private TypeCode _typeCode;

		private bool _isArray;

		public MessagePartDescription Description { get; }

		public XmlDictionaryString DictionaryName { get; }

		public XmlDictionaryString DictionaryNamespace { get; }

		public PartInfo(MessagePartDescription description, XmlDictionaryString dictionaryName, XmlDictionaryString dictionaryNamespace, XmlDictionaryString itemName, XmlDictionaryString itemNamespace)
		{
			DictionaryName = dictionaryName;
			DictionaryNamespace = dictionaryNamespace;
			_itemName = itemName;
			_itemNamespace = itemNamespace;
			Description = description;
			if (description.Type.IsArray)
			{
				_isArray = true;
				_typeCode = description.Type.GetElementType().GetTypeCode();
			}
			else
			{
				_isArray = false;
				_typeCode = description.Type.GetTypeCode();
			}
		}

		public object ReadValue(XmlDictionaryReader reader)
		{
			object result;
			if (_isArray)
			{
				switch (_typeCode)
				{
				case TypeCode.Byte:
					result = reader.ReadElementContentAsBase64();
					break;
				case TypeCode.Boolean:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadBooleanArray(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<bool>();
					}
					break;
				case TypeCode.DateTime:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadDateTimeArray(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<DateTime>();
					}
					break;
				case TypeCode.Decimal:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadDecimalArray(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<decimal>();
					}
					break;
				case TypeCode.Int32:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadInt32Array(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<int>();
					}
					break;
				case TypeCode.Int64:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadInt64Array(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<long>();
					}
					break;
				case TypeCode.Single:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadSingleArray(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<float>();
					}
					break;
				case TypeCode.Double:
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
						result = reader.ReadDoubleArray(_itemName, _itemNamespace);
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
						result = Array.Empty<double>();
					}
					break;
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidUseOfPrimitiveOperationFormatter));
				}
			}
			else
			{
				switch (_typeCode)
				{
				case TypeCode.Boolean:
					result = reader.ReadElementContentAsBoolean();
					break;
				case TypeCode.DateTime:
					result = reader.ReadElementContentAsDateTime();
					break;
				case TypeCode.Decimal:
					result = reader.ReadElementContentAsDecimal();
					break;
				case TypeCode.Double:
					result = reader.ReadElementContentAsDouble();
					break;
				case TypeCode.Int32:
					result = reader.ReadElementContentAsInt();
					break;
				case TypeCode.Int64:
					result = reader.ReadElementContentAsLong();
					break;
				case TypeCode.Single:
					result = reader.ReadElementContentAsFloat();
					break;
				case TypeCode.String:
					return reader.ReadElementContentAsString();
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidUseOfPrimitiveOperationFormatter));
				}
			}
			return result;
		}

		public void WriteValue(XmlDictionaryWriter writer, object value)
		{
			if (_isArray)
			{
				switch (_typeCode)
				{
				case TypeCode.Byte:
				{
					byte[] array8 = (byte[])value;
					writer.WriteBase64(array8, 0, array8.Length);
					break;
				}
				case TypeCode.Boolean:
				{
					bool[] array7 = (bool[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array7, 0, array7.Length);
					break;
				}
				case TypeCode.DateTime:
				{
					DateTime[] array6 = (DateTime[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array6, 0, array6.Length);
					break;
				}
				case TypeCode.Decimal:
				{
					decimal[] array5 = (decimal[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array5, 0, array5.Length);
					break;
				}
				case TypeCode.Int32:
				{
					int[] array4 = (int[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array4, 0, array4.Length);
					break;
				}
				case TypeCode.Int64:
				{
					long[] array3 = (long[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array3, 0, array3.Length);
					break;
				}
				case TypeCode.Single:
				{
					float[] array2 = (float[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array2, 0, array2.Length);
					break;
				}
				case TypeCode.Double:
				{
					double[] array = (double[])value;
					writer.WriteArray(null, _itemName, _itemNamespace, array, 0, array.Length);
					break;
				}
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidUseOfPrimitiveOperationFormatter));
				}
			}
			else
			{
				switch (_typeCode)
				{
				case TypeCode.Boolean:
					writer.WriteValue((bool)value);
					break;
				case TypeCode.DateTime:
					writer.WriteValue((DateTime)value);
					break;
				case TypeCode.Decimal:
					writer.WriteValue((decimal)value);
					break;
				case TypeCode.Double:
					writer.WriteValue((double)value);
					break;
				case TypeCode.Int32:
					writer.WriteValue((int)value);
					break;
				case TypeCode.Int64:
					writer.WriteValue((long)value);
					break;
				case TypeCode.Single:
					writer.WriteValue((float)value);
					break;
				case TypeCode.String:
					writer.WriteString((string)value);
					break;
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidUseOfPrimitiveOperationFormatter));
				}
			}
		}
	}

	internal class PrimitiveRequestBodyWriter : BodyWriter
	{
		private object[] _parameters;

		private PrimitiveOperationFormatter _primitiveOperationFormatter;

		public PrimitiveRequestBodyWriter(object[] parameters, PrimitiveOperationFormatter primitiveOperationFormatter)
			: base(isBuffered: true)
		{
			_parameters = parameters;
			_primitiveOperationFormatter = primitiveOperationFormatter;
		}

		protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
		{
			_primitiveOperationFormatter.SerializeRequest(writer, _parameters);
		}
	}

	internal class PrimitiveResponseBodyWriter : BodyWriter
	{
		private object[] _parameters;

		private object _returnValue;

		private PrimitiveOperationFormatter _primitiveOperationFormatter;

		public PrimitiveResponseBodyWriter(object[] parameters, object returnValue, PrimitiveOperationFormatter primitiveOperationFormatter)
			: base(isBuffered: true)
		{
			_parameters = parameters;
			_returnValue = returnValue;
			_primitiveOperationFormatter = primitiveOperationFormatter;
		}

		protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
		{
			_primitiveOperationFormatter.SerializeResponse(writer, _returnValue, _parameters);
		}
	}

	private OperationDescription _operation;

	private MessageDescription _responseMessage;

	private MessageDescription _requestMessage;

	private XmlDictionaryString _action;

	private XmlDictionaryString _replyAction;

	private ActionHeader _actionHeaderNone;

	private ActionHeader _actionHeader10;

	private ActionHeader _actionHeaderAugust2004;

	private ActionHeader _replyActionHeaderNone;

	private ActionHeader _replyActionHeader10;

	private ActionHeader _replyActionHeaderAugust2004;

	private XmlDictionaryString _requestWrapperName;

	private XmlDictionaryString _requestWrapperNamespace;

	private XmlDictionaryString _responseWrapperName;

	private XmlDictionaryString _responseWrapperNamespace;

	private PartInfo[] _requestParts;

	private PartInfo[] _responseParts;

	private PartInfo _returnPart;

	private XmlDictionaryString _xsiNilLocalName;

	private XmlDictionaryString _xsiNilNamespace;

	private ActionHeader ActionHeaderNone
	{
		get
		{
			if (_actionHeaderNone == null)
			{
				_actionHeaderNone = ActionHeader.Create(_action, AddressingVersion.None);
			}
			return _actionHeaderNone;
		}
	}

	private ActionHeader ActionHeader10
	{
		get
		{
			if (_actionHeader10 == null)
			{
				_actionHeader10 = ActionHeader.Create(_action, AddressingVersion.WSAddressing10);
			}
			return _actionHeader10;
		}
	}

	private ActionHeader ActionHeaderAugust2004
	{
		get
		{
			if (_actionHeaderAugust2004 == null)
			{
				_actionHeaderAugust2004 = ActionHeader.Create(_action, AddressingVersion.WSAddressingAugust2004);
			}
			return _actionHeaderAugust2004;
		}
	}

	private ActionHeader ReplyActionHeaderNone
	{
		get
		{
			if (_replyActionHeaderNone == null)
			{
				_replyActionHeaderNone = ActionHeader.Create(_replyAction, AddressingVersion.None);
			}
			return _replyActionHeaderNone;
		}
	}

	private ActionHeader ReplyActionHeader10
	{
		get
		{
			if (_replyActionHeader10 == null)
			{
				_replyActionHeader10 = ActionHeader.Create(_replyAction, AddressingVersion.WSAddressing10);
			}
			return _replyActionHeader10;
		}
	}

	private ActionHeader ReplyActionHeaderAugust2004
	{
		get
		{
			if (_replyActionHeaderAugust2004 == null)
			{
				_replyActionHeaderAugust2004 = ActionHeader.Create(_replyAction, AddressingVersion.WSAddressingAugust2004);
			}
			return _replyActionHeaderAugust2004;
		}
	}

	public PrimitiveOperationFormatter(OperationDescription description, bool isRpc)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		OperationFormatter.Validate(description, isRpc, isEncoded: false);
		_operation = description;
		_requestMessage = description.Messages[0];
		if (description.Messages.Count == 2)
		{
			_responseMessage = description.Messages[1];
		}
		int num = 3 + _requestMessage.Body.Parts.Count;
		if (_responseMessage != null)
		{
			num += 2 + _responseMessage.Body.Parts.Count;
		}
		XmlDictionary xmlDictionary = new XmlDictionary(num * 2);
		_xsiNilLocalName = xmlDictionary.Add("nil");
		_xsiNilNamespace = xmlDictionary.Add(EndpointAddressProcessor.XsiNs);
		OperationFormatter.GetActions(description, xmlDictionary, out _action, out _replyAction);
		if (_requestMessage.Body.WrapperName != null)
		{
			_requestWrapperName = AddToDictionary(xmlDictionary, _requestMessage.Body.WrapperName);
			_requestWrapperNamespace = AddToDictionary(xmlDictionary, _requestMessage.Body.WrapperNamespace);
		}
		_requestParts = AddToDictionary(xmlDictionary, _requestMessage.Body.Parts, isRpc);
		if (_responseMessage != null)
		{
			if (_responseMessage.Body.WrapperName != null)
			{
				_responseWrapperName = AddToDictionary(xmlDictionary, _responseMessage.Body.WrapperName);
				_responseWrapperNamespace = AddToDictionary(xmlDictionary, _responseMessage.Body.WrapperNamespace);
			}
			_responseParts = AddToDictionary(xmlDictionary, _responseMessage.Body.Parts, isRpc);
			if (_responseMessage.Body.ReturnValue != null && _responseMessage.Body.ReturnValue.Type != typeof(void))
			{
				_returnPart = AddToDictionary(xmlDictionary, _responseMessage.Body.ReturnValue, isRpc);
			}
		}
	}

	private static XmlDictionaryString AddToDictionary(XmlDictionary dictionary, string s)
	{
		if (!dictionary.TryLookup(s, out XmlDictionaryString result))
		{
			return dictionary.Add(s);
		}
		return result;
	}

	private static PartInfo[] AddToDictionary(XmlDictionary dictionary, MessagePartDescriptionCollection parts, bool isRpc)
	{
		PartInfo[] array = new PartInfo[parts.Count];
		for (int i = 0; i < parts.Count; i++)
		{
			array[i] = AddToDictionary(dictionary, parts[i], isRpc);
		}
		return array;
	}

	private ActionHeader GetActionHeader(AddressingVersion addressing)
	{
		if (_action == null)
		{
			return null;
		}
		if (addressing == AddressingVersion.WSAddressingAugust2004)
		{
			return ActionHeaderAugust2004;
		}
		if (addressing == AddressingVersion.WSAddressing10)
		{
			return ActionHeader10;
		}
		if (addressing == AddressingVersion.None)
		{
			return ActionHeaderNone;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.AddressingVersionNotSupported, addressing)));
	}

	private ActionHeader GetReplyActionHeader(AddressingVersion addressing)
	{
		if (_replyAction == null)
		{
			return null;
		}
		if (addressing == AddressingVersion.WSAddressingAugust2004)
		{
			return ReplyActionHeaderAugust2004;
		}
		if (addressing == AddressingVersion.WSAddressing10)
		{
			return ReplyActionHeader10;
		}
		if (addressing == AddressingVersion.None)
		{
			return ReplyActionHeaderNone;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.AddressingVersionNotSupported, addressing)));
	}

	private static string GetArrayItemName(Type type)
	{
		return type.GetTypeCode() switch
		{
			TypeCode.Boolean => "boolean", 
			TypeCode.DateTime => "dateTime", 
			TypeCode.Decimal => "decimal", 
			TypeCode.Int32 => "int", 
			TypeCode.Int64 => "long", 
			TypeCode.Single => "float", 
			TypeCode.Double => "double", 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidUseOfPrimitiveOperationFormatter)), 
		};
	}

	private static PartInfo AddToDictionary(XmlDictionary dictionary, MessagePartDescription part, bool isRpc)
	{
		Type type = part.Type;
		XmlDictionaryString itemName = null;
		XmlDictionaryString itemNamespace = null;
		if (type.IsArray && type != typeof(byte[]))
		{
			string arrayItemName = GetArrayItemName(type.GetElementType());
			itemName = AddToDictionary(dictionary, arrayItemName);
			itemNamespace = AddToDictionary(dictionary, "http://schemas.microsoft.com/2003/10/Serialization/Arrays");
		}
		return new PartInfo(part, AddToDictionary(dictionary, part.Name), AddToDictionary(dictionary, isRpc ? string.Empty : part.Namespace), itemName, itemNamespace);
	}

	public static bool IsContractSupported(OperationDescription description)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		MessageDescription messageDescription = description.Messages[0];
		MessageDescription messageDescription2 = null;
		if (description.Messages.Count == 2)
		{
			messageDescription2 = description.Messages[1];
		}
		if (messageDescription.Headers.Count > 0)
		{
			return false;
		}
		if (messageDescription.Properties.Count > 0)
		{
			return false;
		}
		if (messageDescription.IsTypedMessage)
		{
			return false;
		}
		if (messageDescription2 != null)
		{
			if (messageDescription2.Headers.Count > 0)
			{
				return false;
			}
			if (messageDescription2.Properties.Count > 0)
			{
				return false;
			}
			if (messageDescription2.IsTypedMessage)
			{
				return false;
			}
		}
		if (!AreTypesSupported(messageDescription.Body.Parts))
		{
			return false;
		}
		if (messageDescription2 != null)
		{
			if (!AreTypesSupported(messageDescription2.Body.Parts))
			{
				return false;
			}
			if (messageDescription2.Body.ReturnValue != null && !IsTypeSupported(messageDescription2.Body.ReturnValue))
			{
				return false;
			}
		}
		return true;
	}

	private static bool AreTypesSupported(MessagePartDescriptionCollection bodyDescriptions)
	{
		for (int i = 0; i < bodyDescriptions.Count; i++)
		{
			if (!IsTypeSupported(bodyDescriptions[i]))
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsTypeSupported(MessagePartDescription bodyDescription)
	{
		Type type = bodyDescription.Type;
		if (type == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxMessagePartDescriptionMissingType, bodyDescription.Name, bodyDescription.Namespace)));
		}
		if (bodyDescription.Multiple)
		{
			return false;
		}
		if (type == typeof(void))
		{
			return true;
		}
		if (type.IsEnum())
		{
			return false;
		}
		switch (type.GetTypeCode())
		{
		case TypeCode.Boolean:
		case TypeCode.Int32:
		case TypeCode.Int64:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
		case TypeCode.DateTime:
		case TypeCode.String:
			return true;
		case TypeCode.Object:
			if (type.IsArray && type.GetArrayRank() == 1 && IsArrayTypeSupported(type.GetElementType()))
			{
				return true;
			}
			break;
		}
		return false;
	}

	private static bool IsArrayTypeSupported(Type type)
	{
		if (type.IsEnum())
		{
			return false;
		}
		switch (type.GetTypeCode())
		{
		case TypeCode.Boolean:
		case TypeCode.Byte:
		case TypeCode.Int32:
		case TypeCode.Int64:
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
		case TypeCode.DateTime:
			return true;
		default:
			return false;
		}
	}

	public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		return Message.CreateMessage(messageVersion, GetActionHeader(messageVersion.Addressing), new PrimitiveRequestBodyWriter(parameters, this));
	}

	public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		return Message.CreateMessage(messageVersion, GetReplyActionHeader(messageVersion.Addressing), new PrimitiveResponseBodyWriter(parameters, result, this));
	}

	public object DeserializeReply(Message message, object[] parameters)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		if (parameters == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("parameters"), message);
		}
		try
		{
			if (message.IsEmpty)
			{
				if (_responseWrapperName == null)
				{
					return null;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SerializationException(System.SR.SFxInvalidMessageBodyEmptyMessage));
			}
			XmlDictionaryReader readerAtBodyContents = message.GetReaderAtBodyContents();
			using (readerAtBodyContents)
			{
				object result = DeserializeResponse(readerAtBodyContents, parameters);
				message.ReadFromBodyContentsToEnd(readerAtBodyContents);
				return result;
			}
		}
		catch (XmlException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operation.Name, ex.Message), ex));
		}
		catch (FormatException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operation.Name, ex2.Message), ex2));
		}
		catch (SerializationException ex3)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operation.Name, ex3.Message), ex3));
		}
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
		try
		{
			if (message.IsEmpty)
			{
				if (_requestWrapperName == null)
				{
					return;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SerializationException(System.SR.SFxInvalidMessageBodyEmptyMessage));
			}
			XmlDictionaryReader readerAtBodyContents = message.GetReaderAtBodyContents();
			using (readerAtBodyContents)
			{
				DeserializeRequest(readerAtBodyContents, parameters);
				message.ReadFromBodyContentsToEnd(readerAtBodyContents);
			}
		}
		catch (XmlException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(OperationFormatter.CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operation.Name, ex.Message), ex));
		}
		catch (FormatException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(OperationFormatter.CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operation.Name, ex2.Message), ex2));
		}
		catch (SerializationException ex3)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operation.Name, ex3.Message), ex3));
		}
	}

	private void DeserializeRequest(XmlDictionaryReader reader, object[] parameters)
	{
		if (_requestWrapperName != null)
		{
			if (!reader.IsStartElement(_requestWrapperName, _requestWrapperNamespace))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SerializationException(System.SR.Format(System.SR.SFxInvalidMessageBody, _requestWrapperName, _requestWrapperNamespace, reader.NodeType, reader.Name, reader.NamespaceURI)));
			}
			bool isEmptyElement = reader.IsEmptyElement;
			reader.Read();
			if (isEmptyElement)
			{
				return;
			}
		}
		DeserializeParameters(reader, _requestParts, parameters);
		if (_requestWrapperName != null)
		{
			reader.ReadEndElement();
		}
	}

	private object DeserializeResponse(XmlDictionaryReader reader, object[] parameters)
	{
		if (_responseWrapperName != null)
		{
			if (!reader.IsStartElement(_responseWrapperName, _responseWrapperNamespace))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SerializationException(System.SR.Format(System.SR.SFxInvalidMessageBody, _responseWrapperName, _responseWrapperNamespace, reader.NodeType, reader.Name, reader.NamespaceURI)));
			}
			bool isEmptyElement = reader.IsEmptyElement;
			reader.Read();
			if (isEmptyElement)
			{
				return null;
			}
		}
		object result = null;
		if (_returnPart != null)
		{
			while (true)
			{
				if (IsPartElement(reader, _returnPart))
				{
					result = DeserializeParameter(reader, _returnPart);
					break;
				}
				if (!reader.IsStartElement() || IsPartElements(reader, _responseParts))
				{
					break;
				}
				OperationFormatter.TraceAndSkipElement(reader);
			}
		}
		DeserializeParameters(reader, _responseParts, parameters);
		if (_responseWrapperName != null)
		{
			reader.ReadEndElement();
		}
		return result;
	}

	private void DeserializeParameters(XmlDictionaryReader reader, PartInfo[] parts, object[] parameters)
	{
		if (parts.Length != parameters.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SFxParameterCountMismatch, "parts", parts.Length, "parameters", parameters.Length), "parameters"));
		}
		int num = 0;
		while (reader.IsStartElement())
		{
			for (int i = num; i < parts.Length; i++)
			{
				PartInfo partInfo = parts[i];
				if (IsPartElement(reader, partInfo))
				{
					parameters[partInfo.Description.Index] = DeserializeParameter(reader, parts[i]);
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

	private bool IsPartElements(XmlDictionaryReader reader, PartInfo[] parts)
	{
		foreach (PartInfo part in parts)
		{
			if (IsPartElement(reader, part))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsPartElement(XmlDictionaryReader reader, PartInfo part)
	{
		return reader.IsStartElement(part.DictionaryName, part.DictionaryNamespace);
	}

	private object DeserializeParameter(XmlDictionaryReader reader, PartInfo part)
	{
		if (reader.AttributeCount > 0 && reader.MoveToAttribute(_xsiNilLocalName.Value, _xsiNilNamespace.Value) && reader.ReadContentAsBoolean())
		{
			reader.Skip();
			return null;
		}
		return part.ReadValue(reader);
	}

	private void SerializeParameter(XmlDictionaryWriter writer, PartInfo part, object graph)
	{
		writer.WriteStartElement(part.DictionaryName, part.DictionaryNamespace);
		if (graph == null)
		{
			writer.WriteStartAttribute(_xsiNilLocalName, _xsiNilNamespace);
			writer.WriteValue(value: true);
			writer.WriteEndAttribute();
		}
		else
		{
			part.WriteValue(writer, graph);
		}
		writer.WriteEndElement();
	}

	private void SerializeParameters(XmlDictionaryWriter writer, PartInfo[] parts, object[] parameters)
	{
		if (parts.Length != parameters.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SFxParameterCountMismatch, "parts", parts.Length, "parameters", parameters.Length), "parameters"));
		}
		foreach (PartInfo partInfo in parts)
		{
			SerializeParameter(writer, partInfo, parameters[partInfo.Description.Index]);
		}
	}

	private void SerializeRequest(XmlDictionaryWriter writer, object[] parameters)
	{
		if (_requestWrapperName != null)
		{
			writer.WriteStartElement(_requestWrapperName, _requestWrapperNamespace);
		}
		SerializeParameters(writer, _requestParts, parameters);
		if (_requestWrapperName != null)
		{
			writer.WriteEndElement();
		}
	}

	private void SerializeResponse(XmlDictionaryWriter writer, object returnValue, object[] parameters)
	{
		if (_responseWrapperName != null)
		{
			writer.WriteStartElement(_responseWrapperName, _responseWrapperNamespace);
		}
		if (_returnPart != null)
		{
			SerializeParameter(writer, _returnPart, returnValue);
		}
		SerializeParameters(writer, _responseParts, parameters);
		if (_responseWrapperName != null)
		{
			writer.WriteEndElement();
		}
	}
}

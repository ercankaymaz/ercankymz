using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Dispatcher;

internal class XmlSerializerOperationFormatter : OperationFormatter
{
	internal abstract class MessageInfo
	{
		internal abstract XmlSerializer BodySerializer { get; }

		internal abstract XmlSerializer HeaderSerializer { get; }

		internal abstract MessageHeaderDescriptionTable HeaderDescriptionTable { get; }

		internal abstract MessageHeaderDescription UnknownHeaderDescription { get; }

		internal abstract MessagePartDescriptionCollection RpcEncodedTypedMessageBodyParts { get; }
	}

	private class MessageHeaderOfTHelper
	{
		private object[] _attributes;

		internal MessageHeaderOfTHelper(int parameterCount)
		{
			_attributes = new object[parameterCount];
		}

		internal object GetContentAndSaveHeaderAttributes(object parameterValue, MessageHeaderDescription headerDescription)
		{
			if (parameterValue == null)
			{
				return null;
			}
			bool mustUnderstand;
			bool relay;
			string actor;
			if (headerDescription.Multiple)
			{
				object[] array = (object[])parameterValue;
				MessageHeader<object>[] array2 = new MessageHeader<object>[array.Length];
				Array array3 = Array.CreateInstance(headerDescription.Type, array.Length);
				for (int i = 0; i < array3.Length; i++)
				{
					array3.SetValue(OperationFormatter.GetContentOfMessageHeaderOfT(headerDescription, array[i], out mustUnderstand, out relay, out actor), i);
					array2[i] = new MessageHeader<object>(null, mustUnderstand, actor, relay);
				}
				_attributes[headerDescription.Index] = array2;
				return array3;
			}
			object contentOfMessageHeaderOfT = OperationFormatter.GetContentOfMessageHeaderOfT(headerDescription, parameterValue, out mustUnderstand, out relay, out actor);
			_attributes[headerDescription.Index] = new MessageHeader<object>(null, mustUnderstand, actor, relay);
			return contentOfMessageHeaderOfT;
		}

		internal void GetHeaderAttributes(MessageHeaderDescription headerDescription, out bool mustUnderstand, out bool relay, out string actor)
		{
			MessageHeader<object> messageHeader = null;
			if (headerDescription.Multiple)
			{
				MessageHeader<object>[] array = (MessageHeader<object>[])_attributes[headerDescription.Index];
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null)
					{
						messageHeader = array[i];
						array[i] = null;
						break;
					}
				}
			}
			else
			{
				messageHeader = (MessageHeader<object>)_attributes[headerDescription.Index];
			}
			mustUnderstand = messageHeader.MustUnderstand;
			relay = messageHeader.Relay;
			actor = messageHeader.Actor;
		}

		internal void SetHeaderAttributes(MessageHeaderDescription headerDescription, bool mustUnderstand, bool relay, string actor)
		{
			if (headerDescription.Multiple)
			{
				if (_attributes[headerDescription.Index] == null)
				{
					_attributes[headerDescription.Index] = new List<MessageHeader<object>>();
				}
				((List<MessageHeader<object>>)_attributes[headerDescription.Index]).Add(new MessageHeader<object>(null, mustUnderstand, actor, relay));
			}
			else
			{
				_attributes[headerDescription.Index] = new MessageHeader<object>(null, mustUnderstand, actor, relay);
			}
		}

		internal object CreateMessageHeader(MessageHeaderDescription headerDescription, object headerValue)
		{
			if (headerDescription.Multiple)
			{
				IList<MessageHeader<object>> list = (IList<MessageHeader<object>>)_attributes[headerDescription.Index];
				object[] array = (object[])Array.CreateInstance(TypedHeaderManager.GetMessageHeaderType(headerDescription.Type), list.Count);
				Array array2 = (Array)headerValue;
				for (int i = 0; i < array.Length; i++)
				{
					MessageHeader<object> messageHeader = list[i];
					array[i] = TypedHeaderManager.Create(headerDescription.Type, array2.GetValue(i), messageHeader.MustUnderstand, messageHeader.Relay, messageHeader.Actor);
				}
				return array;
			}
			MessageHeader<object> messageHeader2 = (MessageHeader<object>)_attributes[headerDescription.Index];
			return TypedHeaderManager.Create(headerDescription.Type, headerValue, messageHeader2.MustUnderstand, messageHeader2.Relay, messageHeader2.Actor);
		}
	}

	private const string soap11Encoding = "http://schemas.xmlsoap.org/soap/encoding/";

	private const string soap12Encoding = "http://www.w3.org/2003/05/soap-encoding";

	private bool _isEncoded;

	private MessageInfo _requestMessageInfo;

	private MessageInfo _replyMessageInfo;

	public XmlSerializerOperationFormatter(OperationDescription description, XmlSerializerFormatAttribute xmlSerializerFormatAttribute, MessageInfo requestMessageInfo, MessageInfo replyMessageInfo)
		: base(description, xmlSerializerFormatAttribute.Style == OperationFormatStyle.Rpc, xmlSerializerFormatAttribute.IsEncoded)
	{
		if (xmlSerializerFormatAttribute.IsEncoded && xmlSerializerFormatAttribute.Style != OperationFormatStyle.Rpc)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxDocEncodedNotSupported, description.Name)));
		}
		_isEncoded = xmlSerializerFormatAttribute.IsEncoded;
		_requestMessageInfo = requestMessageInfo;
		_replyMessageInfo = replyMessageInfo;
	}

	protected override void AddHeadersToMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		try
		{
			XmlSerializer headerSerializer;
			MessageHeaderDescriptionTable headerDescriptionTable;
			MessageHeaderDescription unknownHeaderDescription;
			if (isRequest)
			{
				headerSerializer = _requestMessageInfo.HeaderSerializer;
				headerDescriptionTable = _requestMessageInfo.HeaderDescriptionTable;
				unknownHeaderDescription = _requestMessageInfo.UnknownHeaderDescription;
			}
			else
			{
				headerSerializer = _replyMessageInfo.HeaderSerializer;
				headerDescriptionTable = _replyMessageInfo.HeaderDescriptionTable;
				unknownHeaderDescription = _replyMessageInfo.UnknownHeaderDescription;
			}
			bool mustUnderstand;
			bool relay;
			string actor;
			if (headerSerializer != null)
			{
				object[] array = new object[headerDescriptionTable.Count];
				MessageHeaderOfTHelper messageHeaderOfTHelper = null;
				int num = 0;
				foreach (MessageHeaderDescription header in messageDescription.Headers)
				{
					object obj = parameters[header.Index];
					if (header.IsUnknownHeaderCollection)
					{
						continue;
					}
					if (header.TypedHeader)
					{
						if (messageHeaderOfTHelper == null)
						{
							messageHeaderOfTHelper = new MessageHeaderOfTHelper(parameters.Length);
						}
						array[num++] = messageHeaderOfTHelper.GetContentAndSaveHeaderAttributes(parameters[header.Index], header);
					}
					else
					{
						array[num++] = obj;
					}
				}
				MemoryStream memoryStream = new MemoryStream();
				XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream);
				xmlDictionaryWriter.WriteStartElement("root");
				headerSerializer.Serialize(xmlDictionaryWriter, array, null, _isEncoded ? GetEncoding(message.Version.Envelope) : null);
				xmlDictionaryWriter.WriteEndElement();
				xmlDictionaryWriter.Flush();
				XmlDocument xmlDocument = new XmlDocument();
				memoryStream.Position = 0L;
				xmlDocument.Load(memoryStream);
				foreach (XmlElement childNode in xmlDocument.DocumentElement.ChildNodes)
				{
					MessageHeaderDescription messageHeaderDescription = headerDescriptionTable.Get(childNode.LocalName, childNode.NamespaceURI);
					if (messageHeaderDescription == null)
					{
						message.Headers.Add(new XmlElementMessageHeader(this, message.Version, childNode.LocalName, childNode.NamespaceURI, mustUnderstand: false, null, relay: false, childNode));
						continue;
					}
					if (messageHeaderDescription.TypedHeader)
					{
						messageHeaderOfTHelper.GetHeaderAttributes(messageHeaderDescription, out mustUnderstand, out relay, out actor);
					}
					else
					{
						mustUnderstand = messageHeaderDescription.MustUnderstand;
						relay = messageHeaderDescription.Relay;
						actor = messageHeaderDescription.Actor;
					}
					message.Headers.Add(new XmlElementMessageHeader(this, message.Version, childNode.LocalName, childNode.NamespaceURI, mustUnderstand, actor, relay, childNode));
				}
			}
			if (unknownHeaderDescription == null || parameters[unknownHeaderDescription.Index] == null)
			{
				return;
			}
			foreach (object item in (IEnumerable)parameters[unknownHeaderDescription.Index])
			{
				XmlElement xmlElement2 = (XmlElement)OperationFormatter.GetContentOfMessageHeaderOfT(unknownHeaderDescription, item, out mustUnderstand, out relay, out actor);
				if (xmlElement2 != null)
				{
					message.Headers.Add(new XmlElementMessageHeader(this, message.Version, xmlElement2.LocalName, xmlElement2.NamespaceURI, mustUnderstand, actor, relay, xmlElement2));
				}
			}
		}
		catch (InvalidOperationException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorSerializingHeader, messageDescription.MessageName, ex.Message), ex));
		}
	}

	protected override void GetHeadersFromMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		try
		{
			XmlSerializer headerSerializer;
			MessageHeaderDescriptionTable headerDescriptionTable;
			MessageHeaderDescription unknownHeaderDescription;
			if (isRequest)
			{
				headerSerializer = _requestMessageInfo.HeaderSerializer;
				headerDescriptionTable = _requestMessageInfo.HeaderDescriptionTable;
				unknownHeaderDescription = _requestMessageInfo.UnknownHeaderDescription;
			}
			else
			{
				headerSerializer = _replyMessageInfo.HeaderSerializer;
				headerDescriptionTable = _replyMessageInfo.HeaderDescriptionTable;
				unknownHeaderDescription = _replyMessageInfo.UnknownHeaderDescription;
			}
			MessageHeaders headers = message.Headers;
			ArrayList arrayList = null;
			XmlDocument xmlDoc = null;
			if (unknownHeaderDescription != null)
			{
				arrayList = new ArrayList();
				xmlDoc = new XmlDocument();
			}
			if (headerSerializer == null)
			{
				if (unknownHeaderDescription != null)
				{
					for (int i = 0; i < headers.Count; i++)
					{
						AddUnknownHeader(unknownHeaderDescription, arrayList, xmlDoc, null, headers[i], headers.GetReaderAtHeader(i));
					}
					parameters[unknownHeaderDescription.Index] = arrayList.ToArray(unknownHeaderDescription.TypedHeader ? typeof(MessageHeader<XmlElement>) : typeof(XmlElement));
				}
				return;
			}
			MemoryStream memoryStream = new MemoryStream();
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream);
			message.WriteStartEnvelope(xmlDictionaryWriter);
			message.WriteStartHeaders(xmlDictionaryWriter);
			MessageHeaderOfTHelper messageHeaderOfTHelper = null;
			for (int j = 0; j < headers.Count; j++)
			{
				MessageHeaderInfo messageHeaderInfo = headers[j];
				XmlDictionaryReader readerAtHeader = headers.GetReaderAtHeader(j);
				MessageHeaderDescription messageHeaderDescription = headerDescriptionTable.Get(messageHeaderInfo.Name, messageHeaderInfo.Namespace);
				if (messageHeaderDescription != null)
				{
					if (messageHeaderInfo.MustUnderstand)
					{
						headers.UnderstoodHeaders.Add(messageHeaderInfo);
					}
					if (messageHeaderDescription.TypedHeader)
					{
						if (messageHeaderOfTHelper == null)
						{
							messageHeaderOfTHelper = new MessageHeaderOfTHelper(parameters.Length);
						}
						messageHeaderOfTHelper.SetHeaderAttributes(messageHeaderDescription, messageHeaderInfo.MustUnderstand, messageHeaderInfo.Relay, messageHeaderInfo.Actor);
					}
				}
				if (messageHeaderDescription == null && unknownHeaderDescription != null)
				{
					AddUnknownHeader(unknownHeaderDescription, arrayList, xmlDoc, xmlDictionaryWriter, messageHeaderInfo, readerAtHeader);
				}
				else
				{
					xmlDictionaryWriter.WriteNode(readerAtHeader, defattr: false);
				}
				readerAtHeader.Dispose();
			}
			xmlDictionaryWriter.WriteEndElement();
			xmlDictionaryWriter.WriteEndElement();
			xmlDictionaryWriter.Flush();
			memoryStream.Position = 0L;
			memoryStream.TryGetBuffer(out var buffer);
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(buffer.Array, 0, (int)memoryStream.Length, XmlDictionaryReaderQuotas.Max);
			xmlDictionaryReader.ReadStartElement();
			xmlDictionaryReader.MoveToContent();
			if (!xmlDictionaryReader.IsEmptyElement)
			{
				xmlDictionaryReader.ReadStartElement();
				object[] array = (object[])headerSerializer.Deserialize(xmlDictionaryReader, _isEncoded ? GetEncoding(message.Version.Envelope) : null);
				int num = 0;
				foreach (MessageHeaderDescription header in messageDescription.Headers)
				{
					if (!header.IsUnknownHeaderCollection)
					{
						object obj = array[num++];
						if (header.TypedHeader && obj != null)
						{
							obj = messageHeaderOfTHelper.CreateMessageHeader(header, obj);
						}
						parameters[header.Index] = obj;
					}
				}
				xmlDictionaryReader.Dispose();
			}
			if (unknownHeaderDescription != null)
			{
				parameters[unknownHeaderDescription.Index] = arrayList.ToArray(unknownHeaderDescription.TypedHeader ? typeof(MessageHeader<XmlElement>) : typeof(XmlElement));
			}
		}
		catch (InvalidOperationException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingHeader, messageDescription.MessageName), innerException));
		}
	}

	private static void AddUnknownHeader(MessageHeaderDescription unknownHeaderDescription, ArrayList unknownHeaders, XmlDocument xmlDoc, XmlDictionaryWriter bufferWriter, MessageHeaderInfo header, XmlDictionaryReader headerReader)
	{
		object obj = xmlDoc.ReadNode(headerReader);
		if (bufferWriter != null)
		{
			((XmlElement)obj).WriteTo(bufferWriter);
		}
		if (obj != null && unknownHeaderDescription.TypedHeader)
		{
			obj = TypedHeaderManager.Create(unknownHeaderDescription.Type, obj, header.MustUnderstand, header.Relay, header.Actor);
		}
		unknownHeaders.Add(obj);
	}

	protected override void WriteBodyAttributes(XmlDictionaryWriter writer, MessageVersion version)
	{
		if (_isEncoded && version.Envelope == EnvelopeVersion.Soap11)
		{
			string encoding = GetEncoding(version.Envelope);
			writer.WriteAttributeString("encodingStyle", version.Envelope.Namespace, encoding);
		}
		writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
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
		try
		{
			MessageInfo messageInfo = ((!isRequest) ? _replyMessageInfo : _requestMessageInfo);
			if (messageInfo.RpcEncodedTypedMessageBodyParts == null)
			{
				SerializeBody(writer, version, messageInfo.BodySerializer, messageDescription.Body.ReturnValue, messageDescription.Body.Parts, returnValue, parameters);
				return;
			}
			object[] array = new object[messageInfo.RpcEncodedTypedMessageBodyParts.Count];
			object obj = parameters[messageDescription.Body.Parts[0].Index];
			if (obj == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBodyCannotBeNull, messageDescription.MessageName)));
			}
			int num = 0;
			foreach (MessagePartDescription rpcEncodedTypedMessageBodyPart in messageInfo.RpcEncodedTypedMessageBodyParts)
			{
				MemberInfo memberInfo = rpcEncodedTypedMessageBodyPart.MemberInfo;
				FieldInfo fieldInfo = memberInfo as FieldInfo;
				if (fieldInfo != null)
				{
					array[num++] = fieldInfo.GetValue(obj);
					continue;
				}
				PropertyInfo propertyInfo = memberInfo as PropertyInfo;
				if (propertyInfo != null)
				{
					array[num++] = propertyInfo.GetValue(obj, null);
				}
			}
			SerializeBody(writer, version, messageInfo.BodySerializer, null, messageInfo.RpcEncodedTypedMessageBodyParts, null, array);
		}
		catch (InvalidOperationException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorSerializingBody, messageDescription.MessageName, ex.Message), ex));
		}
	}

	private void SerializeBody(XmlDictionaryWriter writer, MessageVersion version, XmlSerializer serializer, MessagePartDescription returnPart, MessagePartDescriptionCollection bodyParts, object returnValue, object[] parameters)
	{
		if (serializer != null)
		{
			bool flag = OperationFormatter.IsValidReturnValue(returnPart);
			object[] array = new object[bodyParts.Count + (flag ? 1 : 0)];
			int num = 0;
			if (flag)
			{
				array[num++] = returnValue;
			}
			for (int i = 0; i < bodyParts.Count; i++)
			{
				array[num++] = parameters[bodyParts[i].Index];
			}
			string encodingStyle = (_isEncoded ? GetEncoding(version.Envelope) : null);
			serializer.Serialize(writer, array, null, encodingStyle);
		}
	}

	protected override object DeserializeBody(XmlDictionaryReader reader, MessageVersion version, string action, MessageDescription messageDescription, object[] parameters, bool isRequest)
	{
		MessageInfo messageInfo = ((!isRequest) ? _replyMessageInfo : _requestMessageInfo);
		if (messageInfo.RpcEncodedTypedMessageBodyParts == null)
		{
			return DeserializeBody(reader, version, messageInfo.BodySerializer, messageDescription.Body.ReturnValue, messageDescription.Body.Parts, parameters, isRequest);
		}
		object[] array = new object[messageInfo.RpcEncodedTypedMessageBodyParts.Count];
		DeserializeBody(reader, version, messageInfo.BodySerializer, null, messageInfo.RpcEncodedTypedMessageBodyParts, array, isRequest);
		object obj = Activator.CreateInstance(messageDescription.Body.Parts[0].Type);
		int num = 0;
		foreach (MessagePartDescription rpcEncodedTypedMessageBodyPart in messageInfo.RpcEncodedTypedMessageBodyParts)
		{
			MemberInfo memberInfo = rpcEncodedTypedMessageBodyPart.MemberInfo;
			FieldInfo fieldInfo = memberInfo as FieldInfo;
			if (fieldInfo != null)
			{
				fieldInfo.SetValue(obj, array[num++]);
				continue;
			}
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(obj, array[num++], null);
			}
		}
		parameters[messageDescription.Body.Parts[0].Index] = obj;
		return null;
	}

	private object DeserializeBody(XmlDictionaryReader reader, MessageVersion version, XmlSerializer serializer, MessagePartDescription returnPart, MessagePartDescriptionCollection bodyParts, object[] parameters, bool isRequest)
	{
		try
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reader"));
			}
			if (parameters == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parameters"));
			}
			object result = null;
			if (serializer == null)
			{
				return null;
			}
			if (reader.NodeType == XmlNodeType.EndElement)
			{
				return null;
			}
			object[] array = (object[])serializer.Deserialize(reader, _isEncoded ? GetEncoding(version.Envelope) : null);
			int num = 0;
			if (OperationFormatter.IsValidReturnValue(returnPart))
			{
				result = array[num++];
			}
			for (int i = 0; i < bodyParts.Count; i++)
			{
				parameters[bodyParts[i].Index] = array[num++];
			}
			return result;
		}
		catch (InvalidOperationException innerException)
		{
			string resourceFormat = (isRequest ? System.SR.SFxErrorDeserializingRequestBody : System.SR.SFxErrorDeserializingReplyBody);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(resourceFormat, base.OperationName), innerException));
		}
	}

	internal static string GetEncoding(EnvelopeVersion version)
	{
		if (version == EnvelopeVersion.Soap11)
		{
			return "http://schemas.xmlsoap.org/soap/encoding/";
		}
		if (version == EnvelopeVersion.Soap12)
		{
			return "http://www.w3.org/2003/05/soap-encoding";
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("version", System.SR.Format(System.SR.EnvelopeVersionNotSupported, version));
	}
}

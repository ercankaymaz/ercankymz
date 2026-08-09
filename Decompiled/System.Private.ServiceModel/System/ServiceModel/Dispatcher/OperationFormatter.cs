using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal abstract class OperationFormatter : IClientMessageFormatter, IDispatchMessageFormatter
{
	internal class SerializeBodyContentsAsyncResult : AsyncResult
	{
		private static AsyncCompletion s_handleEndSerializeBodyContents = HandleEndSerializeBodyContents;

		private StreamFormatter _streamFormatter;

		internal SerializeBodyContentsAsyncResult(OperationFormatter operationFormatter, XmlDictionaryWriter writer, MessageVersion version, object[] parameters, object returnValue, bool isRequest, AsyncCallback callback, object state)
			: base(callback, state)
		{
			bool flag = true;
			operationFormatter.SetupStreamAndMessageDescription(isRequest, out var streamFormatter, out var messageDescription);
			if (streamFormatter != null)
			{
				_streamFormatter = streamFormatter;
				IAsyncResult result = streamFormatter.BeginSerialize(writer, parameters, returnValue, PrepareAsyncCompletion(s_handleEndSerializeBodyContents), this);
				flag = SyncContinue(result);
			}
			else
			{
				operationFormatter.SerializeBody(writer, version, operationFormatter.RequestAction, messageDescription, returnValue, parameters, isRequest);
				flag = true;
			}
			if (flag)
			{
				Complete(completedSynchronously: true);
			}
		}

		private static bool HandleEndSerializeBodyContents(IAsyncResult result)
		{
			SerializeBodyContentsAsyncResult serializeBodyContentsAsyncResult = (SerializeBodyContentsAsyncResult)result.AsyncState;
			serializeBodyContentsAsyncResult._streamFormatter.EndSerialize(result);
			return true;
		}

		public static void End(IAsyncResult result)
		{
			AsyncResult.End<SerializeBodyContentsAsyncResult>(result);
		}
	}

	internal class TypedMessageParts
	{
		private object _instance;

		private MemberInfo[] _members;

		internal int Count => _members.Length;

		public TypedMessageParts(object instance, MessageDescription description)
		{
			if (description == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("description"));
			}
			_members = new MemberInfo[description.Body.Parts.Count + description.Properties.Count + description.Headers.Count];
			foreach (MessageHeaderDescription header in description.Headers)
			{
				_members[header.Index] = header.MemberInfo;
			}
			foreach (MessagePropertyDescription property in description.Properties)
			{
				_members[property.Index] = property.MemberInfo;
			}
			foreach (MessagePartDescription part in description.Body.Parts)
			{
				_members[part.Index] = part.MemberInfo;
			}
			_instance = instance ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException(System.SR.Format(System.SR.SFxTypedMessageCannotBeNull, description.Action)));
		}

		private object GetValue(int index)
		{
			MemberInfo memberInfo = _members[index];
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo.GetValue(_instance, null);
			}
			return ((FieldInfo)memberInfo).GetValue(_instance);
		}

		private void SetValue(object value, int index)
		{
			MemberInfo memberInfo = _members[index];
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(_instance, value, null);
			}
			else
			{
				((FieldInfo)memberInfo).SetValue(_instance, value);
			}
		}

		internal void GetTypedMessageParts(object[] values)
		{
			for (int i = 0; i < _members.Length; i++)
			{
				values[i] = GetValue(i);
			}
		}

		internal void SetTypedMessageParts(object[] values)
		{
			for (int i = 0; i < _members.Length; i++)
			{
				SetValue(values[i], i);
			}
		}
	}

	internal class OperationFormatterMessage : BodyWriterMessage
	{
		internal class OperationFormatterBodyWriter : BodyWriter
		{
			internal class OnWriteBodyContentsAsyncResult : AsyncResult
			{
				private static AsyncCompletion s_handleEndOnWriteBodyContents = HandleEndOnWriteBodyContents;

				private OperationFormatter _operationFormatter;

				internal OnWriteBodyContentsAsyncResult(OperationFormatterBodyWriter operationFormatterBodyWriter, XmlDictionaryWriter writer, AsyncCallback callback, object state)
					: base(callback, state)
				{
					bool flag = true;
					_operationFormatter = operationFormatterBodyWriter.OperationFormatter;
					IAsyncResult result = _operationFormatter.BeginSerializeBodyContents(writer, operationFormatterBodyWriter._version, operationFormatterBodyWriter._parameters, operationFormatterBodyWriter._returnValue, operationFormatterBodyWriter._isRequest, PrepareAsyncCompletion(s_handleEndOnWriteBodyContents), this);
					if (SyncContinue(result))
					{
						Complete(completedSynchronously: true);
					}
				}

				private static bool HandleEndOnWriteBodyContents(IAsyncResult result)
				{
					OnWriteBodyContentsAsyncResult onWriteBodyContentsAsyncResult = (OnWriteBodyContentsAsyncResult)result.AsyncState;
					onWriteBodyContentsAsyncResult._operationFormatter.EndSerializeBodyContents(result);
					return true;
				}

				public static void End(IAsyncResult result)
				{
					AsyncResult.End<OnWriteBodyContentsAsyncResult>(result);
				}
			}

			private bool _isRequest;

			private object[] _parameters;

			private object _returnValue;

			private MessageVersion _version;

			private bool _onBeginWriteBodyContentsCalled;

			private object ThisLock => this;

			internal OperationFormatter OperationFormatter { get; }

			public OperationFormatterBodyWriter(OperationFormatter operationFormatter, MessageVersion version, object[] parameters, object returnValue, bool isRequest)
				: base(AreParametersBuffered(isRequest, operationFormatter))
			{
				_parameters = parameters;
				_returnValue = returnValue;
				_isRequest = isRequest;
				OperationFormatter = operationFormatter;
				_version = version;
			}

			private static bool AreParametersBuffered(bool isRequest, OperationFormatter operationFormatter)
			{
				StreamFormatter streamFormatter = (isRequest ? operationFormatter.requestStreamFormatter : operationFormatter.replyStreamFormatter);
				return streamFormatter == null;
			}

			protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
			{
				lock (ThisLock)
				{
					OperationFormatter.SerializeBodyContents(writer, _version, _parameters, _returnValue, _isRequest);
				}
			}

			protected override Task OnWriteBodyContentsAsync(XmlDictionaryWriter writer)
			{
				return OperationFormatter.SerializeBodyContentsAsync(writer, _version, _parameters, _returnValue, _isRequest);
			}

			protected override IAsyncResult OnBeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
			{
				_onBeginWriteBodyContentsCalled = true;
				return new OnWriteBodyContentsAsyncResult(this, writer, callback, state);
			}

			protected override void OnEndWriteBodyContents(IAsyncResult result)
			{
				OnWriteBodyContentsAsyncResult.End(result);
			}
		}

		private class OperationFormatterMessageBuffer : BodyWriterMessageBuffer
		{
			public OperationFormatterMessageBuffer(MessageHeaders headers, KeyValuePair<string, object>[] properties, BodyWriter bodyWriter)
				: base(headers, properties, bodyWriter)
			{
			}

			public override Message CreateMessage()
			{
				if (!(base.BodyWriter is OperationFormatterBodyWriter bodyWriter))
				{
					return base.CreateMessage();
				}
				lock (base.ThisLock)
				{
					if (base.Closed)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBufferDisposedException());
					}
					return new OperationFormatterMessage(base.Headers, base.Properties, bodyWriter);
				}
			}
		}

		private OperationFormatter _operationFormatter;

		public OperationFormatterMessage(OperationFormatter operationFormatter, MessageVersion version, ActionHeader action, object[] parameters, object returnValue, bool isRequest)
			: base(version, action, new OperationFormatterBodyWriter(operationFormatter, version, parameters, returnValue, isRequest))
		{
			_operationFormatter = operationFormatter;
		}

		public OperationFormatterMessage(MessageVersion version, string action, BodyWriter bodyWriter)
			: base(version, action, bodyWriter)
		{
		}

		private OperationFormatterMessage(MessageHeaders headers, KeyValuePair<string, object>[] properties, OperationFormatterBodyWriter bodyWriter)
			: base(headers, properties, bodyWriter)
		{
			_operationFormatter = bodyWriter.OperationFormatter;
		}

		protected override void OnWriteStartBody(XmlDictionaryWriter writer)
		{
			base.OnWriteStartBody(writer);
			_operationFormatter.WriteBodyAttributes(writer, Version);
		}

		protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
		{
			BodyWriter bodyWriter = ((!base.BodyWriter.IsBuffered) ? base.BodyWriter.CreateBufferedCopy(maxBufferSize) : base.BodyWriter);
			KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[base.Properties.Count];
			((ICollection<KeyValuePair<string, object>>)base.Properties).CopyTo(array, 0);
			return new OperationFormatterMessageBuffer(base.Headers, array, bodyWriter);
		}
	}

	internal abstract class OperationFormatterHeader : MessageHeader
	{
		protected MessageHeader innerHeader;

		protected OperationFormatter operationFormatter;

		protected MessageVersion version;

		public override string Name => innerHeader.Name;

		public override string Namespace => innerHeader.Namespace;

		public override bool MustUnderstand => innerHeader.MustUnderstand;

		public override bool Relay => innerHeader.Relay;

		public override string Actor => innerHeader.Actor;

		public OperationFormatterHeader(OperationFormatter operationFormatter, MessageVersion version, string name, string ns, bool mustUnderstand, string actor, bool relay)
		{
			this.operationFormatter = operationFormatter;
			this.version = version;
			if (actor != null)
			{
				innerHeader = MessageHeader.CreateHeader(name, ns, null, mustUnderstand, actor, relay);
			}
			else
			{
				innerHeader = MessageHeader.CreateHeader(name, ns, null, mustUnderstand, "", relay);
			}
		}

		public override bool IsMessageVersionSupported(MessageVersion messageVersion)
		{
			return innerHeader.IsMessageVersionSupported(messageVersion);
		}

		protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement((Namespace == null || Namespace.Length == 0) ? string.Empty : "h", Name, Namespace);
			OnWriteHeaderAttributes(writer, messageVersion);
		}

		protected virtual void OnWriteHeaderAttributes(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			WriteHeaderAttributes(writer, messageVersion);
		}
	}

	internal class XmlElementMessageHeader : OperationFormatterHeader
	{
		protected XmlElement headerValue;

		public XmlElementMessageHeader(OperationFormatter operationFormatter, MessageVersion version, string name, string ns, bool mustUnderstand, string actor, bool relay, XmlElement headerValue)
			: base(operationFormatter, version, name, ns, mustUnderstand, actor, relay)
		{
			this.headerValue = headerValue;
		}

		protected override void OnWriteHeaderAttributes(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			WriteHeaderAttributes(writer, messageVersion);
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(new XmlNodeReader(headerValue));
			xmlDictionaryReader.MoveToContent();
			writer.WriteAttributes(xmlDictionaryReader, defattr: false);
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			headerValue.WriteContentTo(writer);
		}
	}

	internal struct QName
	{
		internal string Name;

		internal string Namespace;

		internal QName(string name, string ns)
		{
			Name = name;
			Namespace = ns;
		}
	}

	internal class QNameComparer : IEqualityComparer<QName>
	{
		internal static QNameComparer Singleton = new QNameComparer();

		private QNameComparer()
		{
		}

		public bool Equals(QName x, QName y)
		{
			if (x.Name == y.Name)
			{
				return x.Namespace == y.Namespace;
			}
			return false;
		}

		public int GetHashCode(QName obj)
		{
			return obj.Name.GetHashCode();
		}
	}

	internal class MessageHeaderDescriptionTable : Dictionary<QName, MessageHeaderDescription>
	{
		internal MessageHeaderDescriptionTable()
			: base((IEqualityComparer<QName>?)QNameComparer.Singleton)
		{
		}

		internal void Add(string name, string ns, MessageHeaderDescription message)
		{
			Add(new QName(name, ns), message);
		}

		internal MessageHeaderDescription Get(string name, string ns)
		{
			if (TryGetValue(new QName(name, ns), out var value))
			{
				return value;
			}
			return null;
		}
	}

	private MessageDescription _requestDescription;

	private XmlDictionaryString _action;

	private XmlDictionaryString _replyAction;

	protected StreamFormatter requestStreamFormatter;

	protected StreamFormatter replyStreamFormatter;

	private string _operationName;

	internal string RequestAction
	{
		get
		{
			if (_action != null)
			{
				return _action.Value;
			}
			return null;
		}
	}

	internal string ReplyAction
	{
		get
		{
			if (_replyAction != null)
			{
				return _replyAction.Value;
			}
			return null;
		}
	}

	protected XmlDictionary Dictionary { get; }

	protected string OperationName => _operationName;

	protected MessageDescription ReplyDescription { get; }

	protected MessageDescription RequestDescription => _requestDescription;

	public OperationFormatter(OperationDescription description, bool isRpc, bool isEncoded)
	{
		Validate(description, isRpc, isEncoded);
		_requestDescription = description.Messages[0];
		if (description.Messages.Count == 2)
		{
			ReplyDescription = description.Messages[1];
		}
		int num = 3 + _requestDescription.Body.Parts.Count;
		if (ReplyDescription != null)
		{
			num += 2 + ReplyDescription.Body.Parts.Count;
		}
		Dictionary = new XmlDictionary(num * 2);
		GetActions(description, Dictionary, out _action, out _replyAction);
		_operationName = description.Name;
		requestStreamFormatter = StreamFormatter.Create(_requestDescription, _operationName, isRequest: true);
		if (ReplyDescription != null)
		{
			replyStreamFormatter = StreamFormatter.Create(ReplyDescription, _operationName, isRequest: false);
		}
	}

	protected abstract void AddHeadersToMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest);

	protected abstract void SerializeBody(XmlDictionaryWriter writer, MessageVersion version, string action, MessageDescription messageDescription, object returnValue, object[] parameters, bool isRequest);

	protected virtual Task SerializeBodyAsync(XmlDictionaryWriter writer, MessageVersion version, string action, MessageDescription messageDescription, object returnValue, object[] parameters, bool isRequest)
	{
		SerializeBody(writer, version, action, messageDescription, returnValue, parameters, isRequest);
		return Task.CompletedTask;
	}

	protected abstract void GetHeadersFromMessage(Message message, MessageDescription messageDescription, object[] parameters, bool isRequest);

	protected abstract object DeserializeBody(XmlDictionaryReader reader, MessageVersion version, string action, MessageDescription messageDescription, object[] parameters, bool isRequest);

	protected virtual void WriteBodyAttributes(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
	}

	protected XmlDictionaryString AddToDictionary(string s)
	{
		return AddToDictionary(Dictionary, s);
	}

	public object DeserializeReply(Message message, object[] parameters)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (parameters == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("parameters"), message);
		}
		try
		{
			object obj = null;
			if (ReplyDescription.IsTypedMessage)
			{
				object obj2 = CreateTypedMessageInstance(ReplyDescription.MessageType);
				TypedMessageParts typedMessageParts = new TypedMessageParts(obj2, ReplyDescription);
				object[] array = new object[typedMessageParts.Count];
				GetPropertiesFromMessage(message, ReplyDescription, array);
				GetHeadersFromMessage(message, ReplyDescription, array, isRequest: false);
				DeserializeBodyContents(message, array, isRequest: false);
				typedMessageParts.SetTypedMessageParts(array);
				return obj2;
			}
			GetPropertiesFromMessage(message, ReplyDescription, parameters);
			GetHeadersFromMessage(message, ReplyDescription, parameters, isRequest: false);
			return DeserializeBodyContents(message, parameters, isRequest: false);
		}
		catch (XmlException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operationName, ex.Message), ex));
		}
		catch (FormatException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operationName, ex2.Message), ex2));
		}
		catch (SerializationException ex3)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingReplyBodyMore, _operationName, ex3.Message), ex3));
		}
	}

	private static object CreateTypedMessageInstance(Type messageContractType)
	{
		try
		{
			return Activator.CreateInstance(messageContractType);
		}
		catch (MissingMethodException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxMessageContractRequiresDefaultConstructor, messageContractType.FullName), innerException));
		}
	}

	public void DeserializeRequest(Message message, object[] parameters)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (parameters == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("parameters"), message);
		}
		try
		{
			if (_requestDescription.IsTypedMessage)
			{
				object obj = CreateTypedMessageInstance(_requestDescription.MessageType);
				TypedMessageParts typedMessageParts = new TypedMessageParts(obj, _requestDescription);
				object[] array = new object[typedMessageParts.Count];
				GetPropertiesFromMessage(message, _requestDescription, array);
				GetHeadersFromMessage(message, _requestDescription, array, isRequest: true);
				DeserializeBodyContents(message, array, isRequest: true);
				typedMessageParts.SetTypedMessageParts(array);
				parameters[0] = obj;
			}
			else
			{
				GetPropertiesFromMessage(message, _requestDescription, parameters);
				GetHeadersFromMessage(message, _requestDescription, parameters, isRequest: true);
				DeserializeBodyContents(message, parameters, isRequest: true);
			}
		}
		catch (XmlException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operationName, ex.Message), ex));
		}
		catch (FormatException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateDeserializationFailedFault(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operationName, ex2.Message), ex2));
		}
		catch (SerializationException ex3)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.Format(System.SR.SFxErrorDeserializingRequestBodyMore, _operationName, ex3.Message), ex3));
		}
	}

	private object DeserializeBodyContents(Message message, object[] parameters, bool isRequest)
	{
		SetupStreamAndMessageDescription(isRequest, out var streamFormatter, out var messageDescription);
		if (streamFormatter != null)
		{
			object retVal = null;
			streamFormatter.Deserialize(parameters, ref retVal, message);
			return retVal;
		}
		if (message.IsEmpty)
		{
			return null;
		}
		XmlDictionaryReader readerAtBodyContents = message.GetReaderAtBodyContents();
		using (readerAtBodyContents)
		{
			object result = DeserializeBody(readerAtBodyContents, message.Version, RequestAction, messageDescription, parameters, isRequest);
			message.ReadFromBodyContentsToEnd(readerAtBodyContents);
			return result;
		}
	}

	public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
	{
		object[] array = null;
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		if (_requestDescription.IsTypedMessage)
		{
			TypedMessageParts typedMessageParts = new TypedMessageParts(parameters[0], _requestDescription);
			array = new object[typedMessageParts.Count];
			typedMessageParts.GetTypedMessageParts(array);
		}
		else
		{
			array = parameters;
		}
		Message message = new OperationFormatterMessage(this, messageVersion, (_action == null) ? null : ActionHeader.Create(_action, messageVersion.Addressing), array, null, isRequest: true);
		AddPropertiesToMessage(message, _requestDescription, array);
		AddHeadersToMessage(message, _requestDescription, array, isRequest: true);
		return message;
	}

	public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
	{
		object[] array = null;
		object returnValue = null;
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		if (ReplyDescription.IsTypedMessage)
		{
			TypedMessageParts typedMessageParts = new TypedMessageParts(result, ReplyDescription);
			array = new object[typedMessageParts.Count];
			typedMessageParts.GetTypedMessageParts(array);
		}
		else
		{
			array = parameters;
			returnValue = result;
		}
		Message message = new OperationFormatterMessage(this, messageVersion, (_replyAction == null) ? null : ActionHeader.Create(_replyAction, messageVersion.Addressing), array, returnValue, isRequest: false);
		AddPropertiesToMessage(message, ReplyDescription, array);
		AddHeadersToMessage(message, ReplyDescription, array, isRequest: false);
		return message;
	}

	private void SetupStreamAndMessageDescription(bool isRequest, out StreamFormatter streamFormatter, out MessageDescription messageDescription)
	{
		if (isRequest)
		{
			streamFormatter = requestStreamFormatter;
			messageDescription = _requestDescription;
		}
		else
		{
			streamFormatter = replyStreamFormatter;
			messageDescription = ReplyDescription;
		}
	}

	private void SerializeBodyContents(XmlDictionaryWriter writer, MessageVersion version, object[] parameters, object returnValue, bool isRequest)
	{
		SetupStreamAndMessageDescription(isRequest, out var streamFormatter, out var messageDescription);
		if (streamFormatter != null)
		{
			streamFormatter.Serialize(writer, parameters, returnValue);
		}
		else
		{
			SerializeBody(writer, version, RequestAction, messageDescription, returnValue, parameters, isRequest);
		}
	}

	private async Task SerializeBodyContentsAsync(XmlDictionaryWriter writer, MessageVersion version, object[] parameters, object returnValue, bool isRequest)
	{
		SetupStreamAndMessageDescription(isRequest, out var streamFormatter, out var messageDescription);
		if (streamFormatter != null)
		{
			await streamFormatter.SerializeAsync(writer, parameters, returnValue);
		}
		else
		{
			await SerializeBodyAsync(writer, version, RequestAction, messageDescription, returnValue, parameters, isRequest);
		}
	}

	private IAsyncResult BeginSerializeBodyContents(XmlDictionaryWriter writer, MessageVersion version, object[] parameters, object returnValue, bool isRequest, AsyncCallback callback, object state)
	{
		return new SerializeBodyContentsAsyncResult(this, writer, version, parameters, returnValue, isRequest, callback, state);
	}

	private void EndSerializeBodyContents(IAsyncResult result)
	{
		SerializeBodyContentsAsyncResult.End(result);
	}

	private void AddPropertiesToMessage(Message message, MessageDescription messageDescription, object[] parameters)
	{
		if (messageDescription.Properties.Count > 0)
		{
			AddPropertiesToMessageCore(message, messageDescription, parameters);
		}
	}

	private void AddPropertiesToMessageCore(Message message, MessageDescription messageDescription, object[] parameters)
	{
		MessageProperties properties = message.Properties;
		MessagePropertyDescriptionCollection properties2 = messageDescription.Properties;
		for (int i = 0; i < properties2.Count; i++)
		{
			MessagePropertyDescription messagePropertyDescription = properties2[i];
			object obj = parameters[messagePropertyDescription.Index];
			if (obj != null)
			{
				properties.Add(messagePropertyDescription.Name, obj);
			}
		}
	}

	private void GetPropertiesFromMessage(Message message, MessageDescription messageDescription, object[] parameters)
	{
		if (messageDescription.Properties.Count > 0)
		{
			GetPropertiesFromMessageCore(message, messageDescription, parameters);
		}
	}

	private void GetPropertiesFromMessageCore(Message message, MessageDescription messageDescription, object[] parameters)
	{
		MessageProperties properties = message.Properties;
		MessagePropertyDescriptionCollection properties2 = messageDescription.Properties;
		for (int i = 0; i < properties2.Count; i++)
		{
			MessagePropertyDescription messagePropertyDescription = properties2[i];
			if (properties.ContainsKey(messagePropertyDescription.Name))
			{
				parameters[messagePropertyDescription.Index] = properties[messagePropertyDescription.Name];
			}
		}
	}

	internal static object GetContentOfMessageHeaderOfT(MessageHeaderDescription headerDescription, object parameterValue, out bool mustUnderstand, out bool relay, out string actor)
	{
		actor = headerDescription.Actor;
		mustUnderstand = headerDescription.MustUnderstand;
		relay = headerDescription.Relay;
		if (headerDescription.TypedHeader && parameterValue != null)
		{
			parameterValue = TypedHeaderManager.GetContent(headerDescription.Type, parameterValue, out mustUnderstand, out relay, out actor);
		}
		return parameterValue;
	}

	internal static bool IsValidReturnValue(MessagePartDescription returnValue)
	{
		if (returnValue != null)
		{
			return returnValue.Type != typeof(void);
		}
		return false;
	}

	internal static XmlDictionaryString AddToDictionary(XmlDictionary dictionary, string s)
	{
		if (!dictionary.TryLookup(s, out XmlDictionaryString result))
		{
			return dictionary.Add(s);
		}
		return result;
	}

	internal static void Validate(OperationDescription operation, bool isRpc, bool isEncoded)
	{
		if (isEncoded && !isRpc)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxDocEncodedNotSupported, operation.Name)));
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < operation.Messages.Count; i++)
		{
			MessageDescription messageDescription = operation.Messages[i];
			if (messageDescription.IsTypedMessage || messageDescription.IsUntypedMessage)
			{
				if (isRpc && operation.IsValidateRpcWrapperName && !isEncoded)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxTypedMessageCannotBeRpcLiteral, operation.Name)));
				}
				flag2 = true;
			}
			else if (messageDescription.IsVoid)
			{
				flag = true;
			}
			else
			{
				flag3 = true;
			}
		}
		if (flag3 && flag2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxTypedOrUntypedMessageCannotBeMixedWithParameters, operation.Name)));
		}
		if (isRpc && flag2 && flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxTypedOrUntypedMessageCannotBeMixedWithVoidInRpc, operation.Name)));
		}
	}

	internal static void GetActions(OperationDescription description, XmlDictionary dictionary, out XmlDictionaryString action, out XmlDictionaryString replyAction)
	{
		string text = description.Messages[0].Action;
		if (text == "*")
		{
			text = null;
		}
		string text2 = (description.IsOneWay ? null : description.Messages[1].Action);
		if (text2 == "*")
		{
			text2 = null;
		}
		action = (replyAction = null);
		if (text != null)
		{
			action = AddToDictionary(dictionary, text);
		}
		if (text2 != null)
		{
			replyAction = AddToDictionary(dictionary, text2);
		}
	}

	internal static NetDispatcherFaultException CreateDeserializationFailedFault(string reason, Exception innerException)
	{
		reason = System.SR.Format(System.SR.SFxDeserializationFailed1, reason);
		FaultCode subCode = new FaultCode("DeserializationFailed", "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher");
		subCode = FaultCode.CreateSenderFaultCode(subCode);
		return new NetDispatcherFaultException(reason, subCode, innerException);
	}

	internal static void TraceAndSkipElement(XmlReader xmlReader)
	{
		xmlReader.Skip();
	}
}

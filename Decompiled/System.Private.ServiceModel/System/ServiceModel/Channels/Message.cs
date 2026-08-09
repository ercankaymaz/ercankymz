using System.Globalization;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class Message : IDisposable
{
	private class OnWriteMessageAsyncResult : ScheduleActionItemAsyncResult
	{
		private Message _message;

		private XmlDictionaryWriter _writer;

		public OnWriteMessageAsyncResult(XmlDictionaryWriter writer, Message message, AsyncCallback callback, object state)
			: base(callback, state)
		{
			_message = message;
			_writer = writer;
			Schedule();
		}

		protected override void OnDoWork()
		{
			_message.OnWriteMessage(_writer);
		}
	}

	internal const int InitialBufferSize = 1024;

	public abstract MessageHeaders Headers { get; }

	protected bool IsDisposed => State == MessageState.Closed;

	public virtual bool IsFault
	{
		get
		{
			if (IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return false;
		}
	}

	public virtual bool IsEmpty
	{
		get
		{
			if (IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return false;
		}
	}

	public abstract MessageProperties Properties { get; }

	public abstract MessageVersion Version { get; }

	internal virtual RecycledMessageState RecycledMessageState => null;

	public MessageState State { get; private set; }

	internal void BodyToString(XmlDictionaryWriter writer)
	{
		OnBodyToString(writer);
	}

	public void Close()
	{
		if (State != MessageState.Closed)
		{
			State = MessageState.Closed;
			OnClose();
		}
	}

	public MessageBuffer CreateBufferedCopy(int maxBufferSize)
	{
		if (maxBufferSize < 0)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, System.SR.ValueMustBeNonNegative), this);
		}
		switch (State)
		{
		case MessageState.Created:
			State = MessageState.Copied;
			return OnCreateBufferedCopy(maxBufferSize);
		case MessageState.Closed:
			throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
		case MessageState.Copied:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenCopied), this);
		case MessageState.Read:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenRead), this);
		case MessageState.Written:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenWritten), this);
		default:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.InvalidMessageState), this);
		}
	}

	private static Type GetObjectType(object value)
	{
		if (value != null)
		{
			return value.GetType();
		}
		return typeof(object);
	}

	public static Message CreateMessage(MessageVersion version, string action, object body)
	{
		return CreateMessage(version, action, body, DataContractSerializerDefaults.CreateSerializer(GetObjectType(body), int.MaxValue));
	}

	public static Message CreateMessage(MessageVersion version, string action, object body, XmlObjectSerializer serializer)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return new BodyWriterMessage(version, action, new XmlObjectSerializerBodyWriter(body, serializer));
	}

	public static Message CreateMessage(MessageVersion version, string action, XmlReader body)
	{
		return CreateMessage(version, action, XmlDictionaryReader.CreateDictionaryReader(body));
	}

	public static Message CreateMessage(MessageVersion version, string action, XmlDictionaryReader body)
	{
		if (body == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("body");
		}
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		return CreateMessage(version, action, new XmlReaderBodyWriter(body, version.Envelope));
	}

	public static Message CreateMessage(MessageVersion version, string action, BodyWriter body)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (body == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("body"));
		}
		return new BodyWriterMessage(version, action, body);
	}

	internal static Message CreateMessage(MessageVersion version, ActionHeader actionHeader, BodyWriter body)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (body == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("body"));
		}
		return new BodyWriterMessage(version, actionHeader, body);
	}

	public static Message CreateMessage(MessageVersion version, string action)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		return new BodyWriterMessage(version, action, EmptyBodyWriter.Value);
	}

	internal static Message CreateMessage(MessageVersion version, ActionHeader actionHeader)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		return new BodyWriterMessage(version, actionHeader, EmptyBodyWriter.Value);
	}

	public static Message CreateMessage(XmlReader envelopeReader, int maxSizeOfHeaders, MessageVersion version)
	{
		return CreateMessage(XmlDictionaryReader.CreateDictionaryReader(envelopeReader), maxSizeOfHeaders, version);
	}

	public static Message CreateMessage(XmlDictionaryReader envelopeReader, int maxSizeOfHeaders, MessageVersion version)
	{
		if (envelopeReader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("envelopeReader"));
		}
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		return new StreamedMessage(envelopeReader, maxSizeOfHeaders, version);
	}

	public static Message CreateMessage(MessageVersion version, FaultCode faultCode, string reason, string action)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (faultCode == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("faultCode"));
		}
		if (reason == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reason"));
		}
		return CreateMessage(version, MessageFault.CreateFault(faultCode, reason), action);
	}

	public static Message CreateMessage(MessageVersion version, FaultCode faultCode, string reason, object detail, string action)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (faultCode == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("faultCode"));
		}
		if (reason == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reason"));
		}
		return CreateMessage(version, MessageFault.CreateFault(faultCode, new FaultReason(reason), detail), action);
	}

	public static Message CreateMessage(MessageVersion version, MessageFault fault, string action)
	{
		if (fault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("fault"));
		}
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		return new BodyWriterMessage(version, action, new FaultBodyWriter(fault, version.Envelope));
	}

	internal Exception CreateMessageDisposedException()
	{
		return new ObjectDisposedException("", System.SR.MessageClosed);
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	public T GetBody<T>()
	{
		XmlDictionaryReader readerAtBodyContents = GetReaderAtBodyContents();
		return OnGetBody<T>(readerAtBodyContents);
	}

	protected virtual T OnGetBody<T>(XmlDictionaryReader reader)
	{
		return GetBodyCore<T>(reader, DataContractSerializerDefaults.CreateSerializer(typeof(T), int.MaxValue));
	}

	public T GetBody<T>(XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return GetBodyCore<T>(GetReaderAtBodyContents(), serializer);
	}

	private T GetBodyCore<T>(XmlDictionaryReader reader, XmlObjectSerializer serializer)
	{
		using (reader)
		{
			T result = (T)serializer.ReadObject(reader);
			ReadFromBodyContentsToEnd(reader);
			return result;
		}
	}

	internal virtual XmlDictionaryReader GetReaderAtHeader()
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		WriteStartEnvelope(xmlDictionaryWriter);
		MessageHeaders headers = Headers;
		for (int i = 0; i < headers.Count; i++)
		{
			headers.WriteHeader(i, xmlDictionaryWriter);
		}
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.WriteEndElement();
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		XmlDictionaryReader reader = xmlBuffer.GetReader(0);
		reader.ReadStartElement();
		reader.MoveToStartElement();
		return reader;
	}

	public XmlDictionaryReader GetReaderAtBodyContents()
	{
		EnsureReadMessageState();
		if (IsEmpty)
		{
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageIsEmpty), this);
		}
		return OnGetReaderAtBodyContents();
	}

	internal void EnsureReadMessageState()
	{
		switch (State)
		{
		case MessageState.Created:
			State = MessageState.Read;
			break;
		case MessageState.Copied:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenCopied), this);
		case MessageState.Read:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenRead), this);
		case MessageState.Written:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenWritten), this);
		case MessageState.Closed:
			throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
		default:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.InvalidMessageState), this);
		}
	}

	internal void InitializeReply(Message request)
	{
		UniqueId messageId = request.Headers.MessageId;
		Headers.RelatesTo = messageId ?? throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.RequestMessageDoesNotHaveAMessageID), request);
	}

	internal static bool IsFaultStartElement(XmlDictionaryReader reader, EnvelopeVersion version)
	{
		return reader.IsStartElement(XD.MessageDictionary.Fault, version.DictionaryNamespace);
	}

	protected virtual void OnBodyToString(XmlDictionaryWriter writer)
	{
		writer.WriteString(System.SR.MessageBodyIsUnknown);
	}

	protected virtual MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
	{
		return OnCreateBufferedCopy(maxBufferSize, XmlDictionaryReaderQuotas.Max);
	}

	internal MessageBuffer OnCreateBufferedCopy(int maxBufferSize, XmlDictionaryReaderQuotas quotas)
	{
		XmlBuffer xmlBuffer = new XmlBuffer(maxBufferSize);
		XmlDictionaryWriter writer = xmlBuffer.OpenSection(quotas);
		OnWriteMessage(writer);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return new DefaultMessageBuffer(this, xmlBuffer);
	}

	protected virtual void OnClose()
	{
	}

	protected virtual XmlDictionaryReader OnGetReaderAtBodyContents()
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		if (Version.Envelope != EnvelopeVersion.None)
		{
			OnWriteStartEnvelope(xmlDictionaryWriter);
			OnWriteStartBody(xmlDictionaryWriter);
		}
		OnWriteBodyContents(xmlDictionaryWriter);
		if (Version.Envelope != EnvelopeVersion.None)
		{
			xmlDictionaryWriter.WriteEndElement();
			xmlDictionaryWriter.WriteEndElement();
		}
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		XmlDictionaryReader reader = xmlBuffer.GetReader(0);
		if (Version.Envelope != EnvelopeVersion.None)
		{
			reader.ReadStartElement();
			reader.ReadStartElement();
		}
		reader.MoveToContent();
		return reader;
	}

	protected virtual void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		MessageDictionary messageDictionary = XD.MessageDictionary;
		writer.WriteStartElement(messageDictionary.Prefix.Value, messageDictionary.Body, Version.Envelope.DictionaryNamespace);
	}

	public void WriteBodyContents(XmlDictionaryWriter writer)
	{
		EnsureWriteMessageState(writer);
		OnWriteBodyContents(writer);
	}

	public Task WriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		WriteBodyContents(writer);
		return TaskHelpers.CompletedTask();
	}

	public IAsyncResult BeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		EnsureWriteMessageState(writer);
		return OnBeginWriteBodyContents(writer, callback, state);
	}

	public void EndWriteBodyContents(IAsyncResult result)
	{
		OnEndWriteBodyContents(result);
	}

	protected abstract void OnWriteBodyContents(XmlDictionaryWriter writer);

	protected virtual Task OnWriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		OnWriteBodyContents(writer);
		return TaskHelpers.CompletedTask();
	}

	protected virtual IAsyncResult OnBeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		return OnWriteBodyContentsAsync(writer).ToApm(callback, state);
	}

	protected virtual void OnEndWriteBodyContents(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	public void WriteStartEnvelope(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("writer"), this);
		}
		OnWriteStartEnvelope(writer);
	}

	protected virtual void OnWriteStartEnvelope(XmlDictionaryWriter writer)
	{
		EnvelopeVersion envelope = Version.Envelope;
		if (envelope != EnvelopeVersion.None)
		{
			MessageDictionary messageDictionary = XD.MessageDictionary;
			writer.WriteStartElement(messageDictionary.Prefix.Value, messageDictionary.Envelope, envelope.DictionaryNamespace);
			WriteSharedHeaderPrefixes(writer);
		}
	}

	protected virtual void OnWriteStartHeaders(XmlDictionaryWriter writer)
	{
		EnvelopeVersion envelope = Version.Envelope;
		if (envelope != EnvelopeVersion.None)
		{
			MessageDictionary messageDictionary = XD.MessageDictionary;
			writer.WriteStartElement(messageDictionary.Prefix.Value, messageDictionary.Header, envelope.DictionaryNamespace);
		}
	}

	public override string ToString()
	{
		if (IsDisposed)
		{
			return base.ToString();
		}
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		using XmlWriter writer = XmlWriter.Create(stringWriter, xmlWriterSettings);
		using XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		try
		{
			ToString(xmlDictionaryWriter);
			xmlDictionaryWriter.Flush();
			return stringWriter.ToString();
		}
		catch (XmlException ex)
		{
			return System.SR.Format(System.SR.MessageBodyToStringError, ex.GetType().ToString(), ex.Message);
		}
	}

	internal void ToString(XmlDictionaryWriter writer)
	{
		if (IsDisposed)
		{
			throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
		}
		if (Version.Envelope != EnvelopeVersion.None)
		{
			WriteStartEnvelope(writer);
			WriteStartHeaders(writer);
			MessageHeaders headers = Headers;
			for (int i = 0; i < headers.Count; i++)
			{
				headers.WriteHeader(i, writer);
			}
			writer.WriteEndElement();
			MessageDictionary messageDictionary = XD.MessageDictionary;
			WriteStartBody(writer);
		}
		BodyToString(writer);
		if (Version.Envelope != EnvelopeVersion.None)
		{
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	public string GetBodyAttribute(string localName, string ns)
	{
		if (localName == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("localName"), this);
		}
		if (ns == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("ns"), this);
		}
		return State switch
		{
			MessageState.Copied => throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenCopied), this), 
			MessageState.Read => throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenRead), this), 
			MessageState.Written => throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenWritten), this), 
			MessageState.Closed => throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this), 
			MessageState.Created => OnGetBodyAttribute(localName, ns), 
			_ => throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.InvalidMessageState), this), 
		};
	}

	protected virtual string OnGetBodyAttribute(string localName, string ns)
	{
		return null;
	}

	internal void ReadFromBodyContentsToEnd(XmlDictionaryReader reader)
	{
		ReadFromBodyContentsToEnd(reader, Version.Envelope);
	}

	private static void ReadFromBodyContentsToEnd(XmlDictionaryReader reader, EnvelopeVersion envelopeVersion)
	{
		if (envelopeVersion != EnvelopeVersion.None)
		{
			reader.ReadEndElement();
			reader.ReadEndElement();
		}
		reader.MoveToContent();
	}

	internal static bool ReadStartBody(XmlDictionaryReader reader, EnvelopeVersion envelopeVersion, out bool isFault, out bool isEmpty)
	{
		if (reader.IsEmptyElement)
		{
			reader.Read();
			isEmpty = true;
			isFault = false;
			reader.ReadEndElement();
			return false;
		}
		reader.Read();
		if (reader.NodeType != XmlNodeType.Element)
		{
			reader.MoveToContent();
		}
		if (reader.NodeType == XmlNodeType.Element)
		{
			isFault = IsFaultStartElement(reader, envelopeVersion);
			isEmpty = false;
		}
		else
		{
			if (reader.NodeType == XmlNodeType.EndElement)
			{
				isEmpty = true;
				isFault = false;
				ReadFromBodyContentsToEnd(reader, envelopeVersion);
				return false;
			}
			isEmpty = false;
			isFault = false;
		}
		return true;
	}

	public void WriteBody(XmlWriter writer)
	{
		WriteBody(XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteBody(XmlDictionaryWriter writer)
	{
		WriteStartBody(writer);
		WriteBodyContents(writer);
		writer.WriteEndElement();
	}

	public void WriteStartBody(XmlWriter writer)
	{
		WriteStartBody(XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteStartBody(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("writer"), this);
		}
		OnWriteStartBody(writer);
	}

	internal void WriteStartHeaders(XmlDictionaryWriter writer)
	{
		OnWriteStartHeaders(writer);
	}

	public void WriteMessage(XmlWriter writer)
	{
		WriteMessage(XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteMessage(XmlDictionaryWriter writer)
	{
		EnsureWriteMessageState(writer);
		OnWriteMessage(writer);
	}

	public virtual Task WriteMessageAsync(XmlWriter writer)
	{
		WriteMessage(writer);
		return TaskHelpers.CompletedTask();
	}

	public virtual async Task WriteMessageAsync(XmlDictionaryWriter writer)
	{
		EnsureWriteMessageState(writer);
		await OnWriteMessageAsync(writer);
	}

	public virtual async Task OnWriteMessageAsync(XmlDictionaryWriter writer)
	{
		WriteMessagePreamble(writer);
		await OnWriteBodyContentsAsync(writer);
		WriteMessagePostamble(writer);
	}

	private void EnsureWriteMessageState(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentNullException("writer"), this);
		}
		switch (State)
		{
		case MessageState.Created:
			State = MessageState.Written;
			break;
		case MessageState.Copied:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenCopied), this);
		case MessageState.Read:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenRead), this);
		case MessageState.Written:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MessageHasBeenWritten), this);
		case MessageState.Closed:
			throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
		default:
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.InvalidMessageState), this);
		}
	}

	public IAsyncResult BeginWriteMessage(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		EnsureWriteMessageState(writer);
		return OnBeginWriteMessage(writer, callback, state);
	}

	public void EndWriteMessage(IAsyncResult result)
	{
		OnEndWriteMessage(result);
	}

	protected virtual void OnWriteMessage(XmlDictionaryWriter writer)
	{
		WriteMessagePreamble(writer);
		OnWriteBodyContents(writer);
		WriteMessagePostamble(writer);
	}

	internal void WriteMessagePreamble(XmlDictionaryWriter writer)
	{
		if (Version.Envelope == EnvelopeVersion.None)
		{
			return;
		}
		OnWriteStartEnvelope(writer);
		MessageHeaders headers = Headers;
		int count = headers.Count;
		if (count > 0)
		{
			OnWriteStartHeaders(writer);
			for (int i = 0; i < count; i++)
			{
				headers.WriteHeader(i, writer);
			}
			writer.WriteEndElement();
		}
		OnWriteStartBody(writer);
	}

	internal void WriteMessagePostamble(XmlDictionaryWriter writer)
	{
		if (Version.Envelope != EnvelopeVersion.None)
		{
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	protected virtual IAsyncResult OnBeginWriteMessage(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		return new OnWriteMessageAsyncResult(writer, this, callback, state);
	}

	protected virtual void OnEndWriteMessage(IAsyncResult result)
	{
		ScheduleActionItemAsyncResult.End(result);
	}

	private void WriteSharedHeaderPrefixes(XmlDictionaryWriter writer)
	{
		MessageHeaders headers = Headers;
		int count = headers.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if ((Version.Addressing != AddressingVersion.None || !(headers[i].Namespace == AddressingVersion.None.Namespace)) && headers[i] is IMessageHeaderWithSharedNamespace { SharedPrefix: var sharedPrefix } messageHeaderWithSharedNamespace)
			{
				string value = sharedPrefix.Value;
				if (value.Length != 1)
				{
					throw TraceUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "IMessageHeaderWithSharedNamespace must use a single lowercase letter prefix.")), this);
				}
				int num2 = value[0] - 97;
				if (num2 < 0 || num2 >= 26)
				{
					throw TraceUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "IMessageHeaderWithSharedNamespace must use a single lowercase letter prefix.")), this);
				}
				int num3 = 1 << num2;
				if ((num & num3) == 0)
				{
					writer.WriteXmlnsAttribute(value, messageHeaderWithSharedNamespace.SharedNamespace);
					num |= num3;
				}
			}
		}
	}
}

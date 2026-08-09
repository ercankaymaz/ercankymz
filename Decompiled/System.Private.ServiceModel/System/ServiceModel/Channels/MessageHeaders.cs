using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class MessageHeaders : IEnumerable<MessageHeaderInfo>, IEnumerable
{
	internal enum HeaderType : byte
	{
		Invalid,
		ReadableHeader,
		BufferedMessageHeader,
		WriteableHeader
	}

	internal enum HeaderKind : byte
	{
		Action,
		FaultTo,
		From,
		MessageId,
		ReplyTo,
		RelatesTo,
		To,
		Unknown
	}

	[Flags]
	internal enum HeaderProcessing : byte
	{
		MustUnderstand = 1,
		Understood = 2
	}

	internal struct Header
	{
		private MessageHeaderInfo _info;

		public HeaderType HeaderType { get; }

		public HeaderKind HeaderKind { get; }

		public MessageHeaderInfo HeaderInfo => _info;

		public MessageHeader MessageHeader => (MessageHeader)_info;

		public HeaderProcessing HeaderProcessing { get; set; }

		public ReadableMessageHeader ReadableHeader => (ReadableMessageHeader)_info;

		public Header(HeaderKind kind, MessageHeaderInfo info, HeaderProcessing processing)
		{
			HeaderKind = kind;
			HeaderType = HeaderType.BufferedMessageHeader;
			_info = info;
			HeaderProcessing = processing;
		}

		public Header(HeaderKind kind, ReadableMessageHeader readableHeader, HeaderProcessing processing)
		{
			HeaderKind = kind;
			HeaderType = HeaderType.ReadableHeader;
			_info = readableHeader;
			HeaderProcessing = processing;
		}

		public Header(HeaderKind kind, MessageHeader header, HeaderProcessing processing)
		{
			HeaderKind = kind;
			HeaderType = HeaderType.WriteableHeader;
			_info = header;
			HeaderProcessing = processing;
		}
	}

	private int _headerCount;

	private Header[] _headers;

	private IBufferedMessageData _bufferedMessageData;

	private UnderstoodHeaders _understoodHeaders;

	private const int InitialHeaderCount = 4;

	private const int MaxRecycledArrayLength = 8;

	private static XmlDictionaryString[] s_localNames;

	internal const string WildcardAction = "*";

	private const int MaxBufferedHeaderNodes = 4096;

	private const int MaxBufferedHeaderAttributes = 2048;

	private int _nodeCount;

	private int _attrCount;

	private bool _understoodHeadersModified;

	public string Action
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.Action);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is ActionHeader actionHeader)
			{
				return actionHeader.Action;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return ActionHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetActionHeader(ActionHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.Action, null);
			}
		}
	}

	internal bool CanRecycle => _headers.Length <= 8;

	internal bool ContainsOnlyBufferedMessageHeaders
	{
		get
		{
			if (_bufferedMessageData != null)
			{
				return CollectionVersion == 0;
			}
			return false;
		}
	}

	internal int CollectionVersion { get; private set; }

	public int Count => _headerCount;

	public EndpointAddress FaultTo
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.FaultTo);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is FaultToHeader faultToHeader)
			{
				return faultToHeader.FaultTo;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return FaultToHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetFaultToHeader(FaultToHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.FaultTo, null);
			}
		}
	}

	public EndpointAddress From
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.From);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is FromHeader fromHeader)
			{
				return fromHeader.From;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return FromHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetFromHeader(FromHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.From, null);
			}
		}
	}

	internal bool HasMustUnderstandBeenModified
	{
		get
		{
			if (_understoodHeaders != null)
			{
				return _understoodHeaders.Modified;
			}
			return _understoodHeadersModified;
		}
	}

	public UniqueId MessageId
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.MessageId);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is MessageIDHeader messageIDHeader)
			{
				return messageIDHeader.MessageId;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return MessageIDHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetMessageIDHeader(MessageIDHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.MessageId, null);
			}
		}
	}

	public MessageVersion MessageVersion { get; private set; }

	public UniqueId RelatesTo
	{
		get
		{
			return GetRelatesTo(RelatesToHeader.ReplyRelationshipType);
		}
		set
		{
			SetRelatesTo(RelatesToHeader.ReplyRelationshipType, value);
		}
	}

	public EndpointAddress ReplyTo
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.ReplyTo);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is ReplyToHeader replyToHeader)
			{
				return replyToHeader.ReplyTo;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return ReplyToHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetReplyToHeader(ReplyToHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.ReplyTo, null);
			}
		}
	}

	public Uri To
	{
		get
		{
			int num = FindHeaderProperty(HeaderKind.To);
			if (num < 0)
			{
				return null;
			}
			if (_headers[num].HeaderInfo is ToHeader toHeader)
			{
				return toHeader.To;
			}
			using XmlDictionaryReader reader = GetReaderAtHeader(num);
			return ToHeader.ReadHeaderValue(reader, MessageVersion.Addressing);
		}
		set
		{
			if (value != null)
			{
				SetToHeader(ToHeader.Create(value, MessageVersion.Addressing));
			}
			else
			{
				SetHeaderProperty(HeaderKind.To, null);
			}
		}
	}

	public UnderstoodHeaders UnderstoodHeaders
	{
		get
		{
			if (_understoodHeaders == null)
			{
				_understoodHeaders = new UnderstoodHeaders(this, _understoodHeadersModified);
			}
			return _understoodHeaders;
		}
	}

	public MessageHeaderInfo this[int index]
	{
		get
		{
			if (index < 0 || index >= _headerCount)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
			}
			return _headers[index].HeaderInfo;
		}
	}

	public MessageHeaders(MessageVersion version, int initialSize)
	{
		Init(version, initialSize);
	}

	public MessageHeaders(MessageVersion version)
		: this(version, 4)
	{
	}

	internal MessageHeaders(MessageVersion version, XmlDictionaryReader reader, XmlAttributeHolder[] envelopeAttributes, XmlAttributeHolder[] headerAttributes, ref int maxSizeOfHeaders)
		: this(version)
	{
		if (maxSizeOfHeaders < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxSizeOfHeaders", maxSizeOfHeaders, System.SR.ValueMustBeNonNegative));
		}
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("version"));
		}
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reader"));
		}
		if (reader.IsEmptyElement)
		{
			reader.Read();
			return;
		}
		XmlBuffer xmlBuffer = null;
		EnvelopeVersion envelope = version.Envelope;
		reader.ReadStartElement(XD.MessageDictionary.Header, envelope.DictionaryNamespace);
		while (reader.IsStartElement())
		{
			if (xmlBuffer == null)
			{
				xmlBuffer = new XmlBuffer(maxSizeOfHeaders);
			}
			BufferedHeader bufferedHeader = new BufferedHeader(version, xmlBuffer, reader, envelopeAttributes, headerAttributes);
			HeaderProcessing headerProcessing = (bufferedHeader.MustUnderstand ? HeaderProcessing.MustUnderstand : ((HeaderProcessing)0));
			HeaderKind headerKind = GetHeaderKind(bufferedHeader);
			if (headerKind != HeaderKind.Unknown)
			{
				headerProcessing |= HeaderProcessing.Understood;
				TraceUnderstood(bufferedHeader);
			}
			Header header = new Header(headerKind, bufferedHeader, headerProcessing);
			AddHeader(header);
		}
		if (xmlBuffer != null)
		{
			xmlBuffer.Close();
			maxSizeOfHeaders -= xmlBuffer.BufferSize;
		}
		reader.ReadEndElement();
		CollectionVersion = 0;
	}

	internal MessageHeaders(MessageVersion version, XmlDictionaryReader reader, IBufferedMessageData bufferedMessageData, RecycledMessageState recycledMessageState, bool[] understoodHeaders, bool understoodHeadersModified)
	{
		_headers = new Header[4];
		Init(version, reader, bufferedMessageData, recycledMessageState, understoodHeaders, understoodHeadersModified);
	}

	internal MessageHeaders(MessageVersion version, MessageHeaders headers, IBufferedMessageData bufferedMessageData)
	{
		MessageVersion = version;
		_bufferedMessageData = bufferedMessageData;
		_headerCount = headers._headerCount;
		_headers = new Header[_headerCount];
		Array.Copy(headers._headers, _headers, _headerCount);
		CollectionVersion = 0;
	}

	public MessageHeaders(MessageHeaders collection)
	{
		if (collection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("collection");
		}
		Init(collection.MessageVersion, collection._headers.Length);
		CopyHeadersFrom(collection);
		CollectionVersion = 0;
	}

	public void Add(MessageHeader header)
	{
		Insert(_headerCount, header);
	}

	internal void AddActionHeader(ActionHeader actionHeader)
	{
		Insert(_headerCount, actionHeader, HeaderKind.Action);
	}

	internal void AddMessageIDHeader(MessageIDHeader messageIDHeader)
	{
		Insert(_headerCount, messageIDHeader, HeaderKind.MessageId);
	}

	internal void AddRelatesToHeader(RelatesToHeader relatesToHeader)
	{
		Insert(_headerCount, relatesToHeader, HeaderKind.RelatesTo);
	}

	internal void AddReplyToHeader(ReplyToHeader replyToHeader)
	{
		Insert(_headerCount, replyToHeader, HeaderKind.ReplyTo);
	}

	internal void AddToHeader(ToHeader toHeader)
	{
		Insert(_headerCount, toHeader, HeaderKind.To);
	}

	private void Add(MessageHeader header, HeaderKind kind)
	{
		Insert(_headerCount, header, kind);
	}

	private void AddHeader(Header header)
	{
		InsertHeader(_headerCount, header);
	}

	internal void AddUnderstood(int i)
	{
		_headers[i].HeaderProcessing |= HeaderProcessing.Understood;
		TraceUnderstood(_headers[i].HeaderInfo);
	}

	internal void AddUnderstood(MessageHeaderInfo headerInfo)
	{
		if (headerInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("headerInfo"));
		}
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderInfo == headerInfo)
			{
				if ((_headers[i].HeaderProcessing & HeaderProcessing.Understood) != 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.HeaderAlreadyUnderstood, headerInfo.Name, headerInfo.Namespace), "headerInfo"));
				}
				AddUnderstood(i);
			}
		}
	}

	private void CaptureBufferedHeaders()
	{
		CaptureBufferedHeaders(-1);
	}

	private void CaptureBufferedHeaders(int exceptIndex)
	{
		using (XmlDictionaryReader xmlDictionaryReader = GetBufferedMessageHeaderReaderAtHeaderContents(_bufferedMessageData))
		{
			for (int i = 0; i < _headerCount; i++)
			{
				if (xmlDictionaryReader.NodeType != XmlNodeType.Element && xmlDictionaryReader.MoveToContent() != XmlNodeType.Element)
				{
					break;
				}
				Header header = _headers[i];
				if (i == exceptIndex || header.HeaderType != HeaderType.BufferedMessageHeader)
				{
					xmlDictionaryReader.Skip();
				}
				else
				{
					_headers[i] = new Header(header.HeaderKind, CaptureBufferedHeader(xmlDictionaryReader, header.HeaderInfo), header.HeaderProcessing);
				}
			}
		}
		_bufferedMessageData = null;
	}

	private BufferedHeader CaptureBufferedHeader(XmlDictionaryReader reader, MessageHeaderInfo headerInfo)
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(_bufferedMessageData.Quotas);
		xmlDictionaryWriter.WriteNode(reader, defattr: false);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return new BufferedHeader(MessageVersion, xmlBuffer, 0, headerInfo);
	}

	private BufferedHeader CaptureBufferedHeader(IBufferedMessageData bufferedMessageData, MessageHeaderInfo headerInfo, int bufferedMessageHeaderIndex)
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter writer = xmlBuffer.OpenSection(bufferedMessageData.Quotas);
		WriteBufferedMessageHeader(bufferedMessageData, bufferedMessageHeaderIndex, writer);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return new BufferedHeader(MessageVersion, xmlBuffer, 0, headerInfo);
	}

	private BufferedHeader CaptureWriteableHeader(MessageHeader writeableHeader)
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter writer = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		writeableHeader.WriteHeader(writer, MessageVersion);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return new BufferedHeader(MessageVersion, xmlBuffer, 0, writeableHeader);
	}

	public void Clear()
	{
		for (int i = 0; i < _headerCount; i++)
		{
			_headers[i] = default(Header);
		}
		_headerCount = 0;
		CollectionVersion++;
		_bufferedMessageData = null;
	}

	public void CopyHeaderFrom(Message message, int headerIndex)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		CopyHeaderFrom(message.Headers, headerIndex);
	}

	public void CopyHeaderFrom(MessageHeaders collection, int headerIndex)
	{
		if (collection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("collection");
		}
		if (collection.MessageVersion != MessageVersion)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MessageHeaderVersionMismatch, collection.MessageVersion.ToString(), MessageVersion.ToString()), "collection"));
		}
		if (headerIndex < 0 || headerIndex >= collection._headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, collection._headerCount)));
		}
		Header header = collection._headers[headerIndex];
		HeaderProcessing headerProcessing = (header.HeaderInfo.MustUnderstand ? HeaderProcessing.MustUnderstand : ((HeaderProcessing)0));
		if ((header.HeaderProcessing & HeaderProcessing.Understood) != 0 || header.HeaderKind != HeaderKind.Unknown)
		{
			headerProcessing |= HeaderProcessing.Understood;
		}
		switch (header.HeaderType)
		{
		case HeaderType.BufferedMessageHeader:
			AddHeader(new Header(header.HeaderKind, collection.CaptureBufferedHeader(collection._bufferedMessageData, header.HeaderInfo, headerIndex), headerProcessing));
			break;
		case HeaderType.ReadableHeader:
			AddHeader(new Header(header.HeaderKind, header.ReadableHeader, headerProcessing));
			break;
		case HeaderType.WriteableHeader:
			AddHeader(new Header(header.HeaderKind, header.MessageHeader, headerProcessing));
			break;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, header.HeaderType)));
		}
	}

	public void CopyHeadersFrom(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		CopyHeadersFrom(message.Headers);
	}

	public void CopyHeadersFrom(MessageHeaders collection)
	{
		if (collection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("collection"));
		}
		for (int i = 0; i < collection._headerCount; i++)
		{
			CopyHeaderFrom(collection, i);
		}
	}

	public void CopyTo(MessageHeaderInfo[] array, int index)
	{
		if (array == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("array");
		}
		if (index < 0 || index + _headerCount > array.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, array.Length - _headerCount)));
		}
		for (int i = 0; i < _headerCount; i++)
		{
			array[i + index] = _headers[i].HeaderInfo;
		}
	}

	private Exception CreateDuplicateHeaderException(HeaderKind kind)
	{
		string text = kind switch
		{
			HeaderKind.Action => "Action", 
			HeaderKind.FaultTo => "FaultTo", 
			HeaderKind.From => "From", 
			HeaderKind.MessageId => "MessageID", 
			HeaderKind.ReplyTo => "ReplyTo", 
			HeaderKind.To => "To", 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, kind))), 
		};
		return new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeaders, text, MessageVersion.Addressing.Namespace), text, MessageVersion.Addressing.Namespace, isDuplicate: true);
	}

	public int FindHeader(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("ns"));
		}
		if (ns == MessageVersion.Addressing.Namespace)
		{
			return FindAddressingHeader(name, ns);
		}
		return FindNonAddressingHeader(name, ns, MessageVersion.Envelope.UltimateDestinationActorValues);
	}

	private int FindAddressingHeader(string name, string ns)
	{
		int num = -1;
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderKind == HeaderKind.Unknown)
			{
				continue;
			}
			MessageHeaderInfo headerInfo = _headers[i].HeaderInfo;
			if (headerInfo.Name == name && headerInfo.Namespace == ns)
			{
				if (num >= 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeaders, name, ns), name, ns, isDuplicate: true));
				}
				num = i;
			}
		}
		return num;
	}

	private int FindNonAddressingHeader(string name, string ns, string[] actors)
	{
		int num = -1;
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderKind != HeaderKind.Unknown)
			{
				continue;
			}
			MessageHeaderInfo headerInfo = _headers[i].HeaderInfo;
			if (!(headerInfo.Name == name) || !(headerInfo.Namespace == ns))
			{
				continue;
			}
			for (int j = 0; j < actors.Length; j++)
			{
				if (!(actors[j] == headerInfo.Actor))
				{
					continue;
				}
				if (num >= 0)
				{
					if (actors.Length == 1)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeadersWithActor, name, ns, actors[0]), name, ns, isDuplicate: true));
					}
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeaders, name, ns), name, ns, isDuplicate: true));
				}
				num = i;
			}
		}
		return num;
	}

	public int FindHeader(string name, string ns, params string[] actors)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("ns"));
		}
		if (actors == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("actors"));
		}
		int num = -1;
		for (int i = 0; i < _headerCount; i++)
		{
			MessageHeaderInfo headerInfo = _headers[i].HeaderInfo;
			if (!(headerInfo.Name == name) || !(headerInfo.Namespace == ns))
			{
				continue;
			}
			for (int j = 0; j < actors.Length; j++)
			{
				if (!(actors[j] == headerInfo.Actor))
				{
					continue;
				}
				if (num >= 0)
				{
					if (actors.Length == 1)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeadersWithActor, name, ns, actors[0]), name, ns, isDuplicate: true));
					}
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleMessageHeaders, name, ns), name, ns, isDuplicate: true));
				}
				num = i;
			}
		}
		return num;
	}

	private int FindHeaderProperty(HeaderKind kind)
	{
		int num = -1;
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderKind == kind)
			{
				if (num >= 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateDuplicateHeaderException(kind));
				}
				num = i;
			}
		}
		return num;
	}

	private int FindRelatesTo(Uri relationshipType, out UniqueId messageId)
	{
		UniqueId uniqueId = null;
		int result = -1;
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderKind != HeaderKind.RelatesTo)
			{
				continue;
			}
			GetRelatesToValues(i, out var relationshipType2, out var messageId2);
			if (relationshipType == relationshipType2)
			{
				if (uniqueId != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MultipleRelatesToHeaders, relationshipType.AbsoluteUri), "RelatesTo", MessageVersion.Addressing.Namespace, isDuplicate: true));
				}
				uniqueId = messageId2;
				result = i;
			}
		}
		messageId = uniqueId;
		return result;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<MessageHeaderInfo> GetEnumerator()
	{
		MessageHeaderInfo[] array = new MessageHeaderInfo[_headerCount];
		CopyTo(array, 0);
		return GetEnumerator(array);
	}

	private IEnumerator<MessageHeaderInfo> GetEnumerator(MessageHeaderInfo[] headers)
	{
		IList<MessageHeaderInfo> list = new ReadOnlyCollection<MessageHeaderInfo>(headers);
		return list.GetEnumerator();
	}

	internal IEnumerator<MessageHeaderInfo> GetUnderstoodEnumerator()
	{
		List<MessageHeaderInfo> list = new List<MessageHeaderInfo>();
		for (int i = 0; i < _headerCount; i++)
		{
			if ((_headers[i].HeaderProcessing & HeaderProcessing.Understood) != 0)
			{
				list.Add(_headers[i].HeaderInfo);
			}
		}
		return list.GetEnumerator();
	}

	private static XmlDictionaryReader GetBufferedMessageHeaderReaderAtHeaderContents(IBufferedMessageData bufferedMessageData)
	{
		XmlDictionaryReader messageReader = bufferedMessageData.GetMessageReader();
		if (messageReader.NodeType == XmlNodeType.Element)
		{
			messageReader.Read();
		}
		else
		{
			messageReader.ReadStartElement();
		}
		if (messageReader.NodeType == XmlNodeType.Element)
		{
			messageReader.Read();
		}
		else
		{
			messageReader.ReadStartElement();
		}
		return messageReader;
	}

	private XmlDictionaryReader GetBufferedMessageHeaderReader(IBufferedMessageData bufferedMessageData, int bufferedMessageHeaderIndex)
	{
		if (_nodeCount > 4096 || _attrCount > 2048)
		{
			CaptureBufferedHeaders();
			return _headers[bufferedMessageHeaderIndex].ReadableHeader.GetHeaderReader();
		}
		XmlDictionaryReader bufferedMessageHeaderReaderAtHeaderContents = GetBufferedMessageHeaderReaderAtHeaderContents(bufferedMessageData);
		while (true)
		{
			if (bufferedMessageHeaderReaderAtHeaderContents.NodeType != XmlNodeType.Element)
			{
				bufferedMessageHeaderReaderAtHeaderContents.MoveToContent();
			}
			if (bufferedMessageHeaderIndex == 0)
			{
				break;
			}
			Skip(bufferedMessageHeaderReaderAtHeaderContents);
			bufferedMessageHeaderIndex--;
		}
		return bufferedMessageHeaderReaderAtHeaderContents;
	}

	private void Skip(XmlDictionaryReader reader)
	{
		if (reader.MoveToContent() == XmlNodeType.Element && !reader.IsEmptyElement)
		{
			int depth = reader.Depth;
			do
			{
				_attrCount += reader.AttributeCount;
				_nodeCount++;
			}
			while (reader.Read() && depth < reader.Depth);
			if (reader.NodeType == XmlNodeType.EndElement)
			{
				_nodeCount++;
				reader.Read();
			}
		}
		else
		{
			_attrCount += reader.AttributeCount;
			_nodeCount++;
			reader.Read();
		}
	}

	public T GetHeader<T>(string name, string ns)
	{
		return GetHeader<T>(name, ns, DataContractSerializerDefaults.CreateSerializer(typeof(T), name, ns, int.MaxValue));
	}

	public T GetHeader<T>(string name, string ns, params string[] actors)
	{
		int num = FindHeader(name, ns, actors);
		if (num < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.HeaderNotFound, name, ns), name, ns));
		}
		return GetHeader<T>(num);
	}

	public T GetHeader<T>(string name, string ns, XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		int num = FindHeader(name, ns);
		if (num < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.HeaderNotFound, name, ns), name, ns));
		}
		return GetHeader<T>(num, serializer);
	}

	public T GetHeader<T>(int index)
	{
		if (index < 0 || index >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		MessageHeaderInfo headerInfo = _headers[index].HeaderInfo;
		return GetHeader<T>(index, DataContractSerializerDefaults.CreateSerializer(typeof(T), headerInfo.Name, headerInfo.Namespace, int.MaxValue));
	}

	public T GetHeader<T>(int index, XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		using XmlDictionaryReader reader = GetReaderAtHeader(index);
		return (T)serializer.ReadObject(reader);
	}

	private HeaderKind GetHeaderKind(MessageHeaderInfo headerInfo)
	{
		HeaderKind headerKind = HeaderKind.Unknown;
		if (headerInfo.Namespace == MessageVersion.Addressing.Namespace && MessageVersion.Envelope.IsUltimateDestinationActor(headerInfo.Actor))
		{
			string name = headerInfo.Name;
			if (name.Length > 0)
			{
				switch (name[0])
				{
				case 'A':
					if (name == "Action")
					{
						headerKind = HeaderKind.Action;
					}
					break;
				case 'F':
					if (name == "From")
					{
						headerKind = HeaderKind.From;
					}
					else if (name == "FaultTo")
					{
						headerKind = HeaderKind.FaultTo;
					}
					break;
				case 'M':
					if (name == "MessageID")
					{
						headerKind = HeaderKind.MessageId;
					}
					break;
				case 'R':
					if (name == "ReplyTo")
					{
						headerKind = HeaderKind.ReplyTo;
					}
					else if (name == "RelatesTo")
					{
						headerKind = HeaderKind.RelatesTo;
					}
					break;
				case 'T':
					if (name == "To")
					{
						headerKind = HeaderKind.To;
					}
					break;
				}
			}
		}
		ValidateHeaderKind(headerKind);
		return headerKind;
	}

	private void ValidateHeaderKind(HeaderKind headerKind)
	{
		if (MessageVersion.Envelope == EnvelopeVersion.None && headerKind != HeaderKind.Action && headerKind != HeaderKind.To)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.HeadersCannotBeAddedToEnvelopeVersion, MessageVersion.Envelope)));
		}
		if (MessageVersion.Addressing == AddressingVersion.None && headerKind != HeaderKind.Unknown && headerKind != HeaderKind.Action && headerKind != HeaderKind.To)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.AddressingHeadersCannotBeAddedToAddressingVersion, MessageVersion.Addressing)));
		}
	}

	public XmlDictionaryReader GetReaderAtHeader(int headerIndex)
	{
		if (headerIndex < 0 || headerIndex >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		switch (_headers[headerIndex].HeaderType)
		{
		case HeaderType.ReadableHeader:
			return _headers[headerIndex].ReadableHeader.GetHeaderReader();
		case HeaderType.WriteableHeader:
		{
			MessageHeader messageHeader = _headers[headerIndex].MessageHeader;
			BufferedHeader bufferedHeader = CaptureWriteableHeader(messageHeader);
			_headers[headerIndex] = new Header(_headers[headerIndex].HeaderKind, bufferedHeader, _headers[headerIndex].HeaderProcessing);
			CollectionVersion++;
			return bufferedHeader.GetHeaderReader();
		}
		case HeaderType.BufferedMessageHeader:
			return GetBufferedMessageHeaderReader(_bufferedMessageData, headerIndex);
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, _headers[headerIndex].HeaderType)));
		}
	}

	internal UniqueId GetRelatesTo(Uri relationshipType)
	{
		if (relationshipType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("relationshipType"));
		}
		FindRelatesTo(relationshipType, out var messageId);
		return messageId;
	}

	private void GetRelatesToValues(int index, out Uri relationshipType, out UniqueId messageId)
	{
		if (_headers[index].HeaderInfo is RelatesToHeader relatesToHeader)
		{
			relationshipType = relatesToHeader.RelationshipType;
			messageId = relatesToHeader.UniqueId;
			return;
		}
		using XmlDictionaryReader reader = GetReaderAtHeader(index);
		RelatesToHeader.ReadHeaderValue(reader, MessageVersion.Addressing, out relationshipType, out messageId);
	}

	internal string[] GetHeaderAttributes(string localName, string ns)
	{
		string[] array = null;
		if (ContainsOnlyBufferedMessageHeaders)
		{
			XmlDictionaryReader messageReader = _bufferedMessageData.GetMessageReader();
			messageReader.ReadStartElement();
			messageReader.ReadStartElement();
			int num = 0;
			while (messageReader.IsStartElement())
			{
				string attribute = messageReader.GetAttribute(localName, ns);
				if (attribute != null)
				{
					if (array == null)
					{
						array = new string[_headerCount];
					}
					array[num] = attribute;
				}
				if (num == _headerCount - 1)
				{
					break;
				}
				messageReader.Skip();
				num++;
			}
			messageReader.Dispose();
		}
		else
		{
			for (int i = 0; i < _headerCount; i++)
			{
				if (_headers[i].HeaderType == HeaderType.WriteableHeader)
				{
					continue;
				}
				using XmlDictionaryReader xmlDictionaryReader = GetReaderAtHeader(i);
				string attribute2 = xmlDictionaryReader.GetAttribute(localName, ns);
				if (attribute2 != null)
				{
					if (array == null)
					{
						array = new string[_headerCount];
					}
					array[i] = attribute2;
				}
			}
		}
		return array;
	}

	internal MessageHeader GetMessageHeader(int index)
	{
		if (index < 0 || index >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		switch (_headers[index].HeaderType)
		{
		case HeaderType.ReadableHeader:
		case HeaderType.WriteableHeader:
			return _headers[index].MessageHeader;
		case HeaderType.BufferedMessageHeader:
		{
			MessageHeader messageHeader = CaptureBufferedHeader(_bufferedMessageData, _headers[index].HeaderInfo, index);
			_headers[index] = new Header(_headers[index].HeaderKind, messageHeader, _headers[index].HeaderProcessing);
			CollectionVersion++;
			return messageHeader;
		}
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, _headers[index].HeaderType)));
		}
	}

	internal Collection<MessageHeaderInfo> GetHeadersNotUnderstood()
	{
		Collection<MessageHeaderInfo> collection = null;
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderProcessing == HeaderProcessing.MustUnderstand)
			{
				if (collection == null)
				{
					collection = new Collection<MessageHeaderInfo>();
				}
				MessageHeaderInfo headerInfo = _headers[i].HeaderInfo;
				collection.Add(headerInfo);
			}
		}
		return collection;
	}

	public bool HaveMandatoryHeadersBeenUnderstood()
	{
		return HaveMandatoryHeadersBeenUnderstood(MessageVersion.Envelope.MustUnderstandActorValues);
	}

	public bool HaveMandatoryHeadersBeenUnderstood(params string[] actors)
	{
		if (actors == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("actors"));
		}
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderProcessing != HeaderProcessing.MustUnderstand)
			{
				continue;
			}
			for (int j = 0; j < actors.Length; j++)
			{
				if (_headers[i].HeaderInfo.Actor == actors[j])
				{
					return false;
				}
			}
		}
		return true;
	}

	internal void Init(MessageVersion version, int initialSize)
	{
		_nodeCount = 0;
		_attrCount = 0;
		if (initialSize < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("initialSize", initialSize, System.SR.ValueMustBeNonNegative));
		}
		MessageVersion = version ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		_headers = new Header[initialSize];
	}

	internal void Init(MessageVersion version)
	{
		_nodeCount = 0;
		_attrCount = 0;
		MessageVersion = version;
		CollectionVersion = 0;
	}

	internal void Init(MessageVersion version, XmlDictionaryReader reader, IBufferedMessageData bufferedMessageData, RecycledMessageState recycledMessageState, bool[] understoodHeaders, bool understoodHeadersModified)
	{
		_nodeCount = 0;
		_attrCount = 0;
		MessageVersion = version;
		_bufferedMessageData = bufferedMessageData;
		if (version.Envelope != EnvelopeVersion.None)
		{
			_understoodHeadersModified = understoodHeaders != null && understoodHeadersModified;
			if (reader.IsEmptyElement)
			{
				reader.Read();
				return;
			}
			EnvelopeVersion envelope = version.Envelope;
			reader.ReadStartElement();
			AddressingDictionary addressingDictionary = XD.AddressingDictionary;
			if (s_localNames == null)
			{
				XmlDictionaryString[] array = new XmlDictionaryString[7];
				array[6] = addressingDictionary.To;
				array[0] = addressingDictionary.Action;
				array[3] = addressingDictionary.MessageId;
				array[5] = addressingDictionary.RelatesTo;
				array[4] = addressingDictionary.ReplyTo;
				array[2] = addressingDictionary.From;
				array[1] = addressingDictionary.FaultTo;
				Interlocked.MemoryBarrier();
				s_localNames = array;
			}
			int num = 0;
			while (reader.IsStartElement())
			{
				ReadBufferedHeader(reader, recycledMessageState, s_localNames, understoodHeaders != null && understoodHeaders[num++]);
			}
			reader.ReadEndElement();
		}
		CollectionVersion = 0;
	}

	public void Insert(int headerIndex, MessageHeader header)
	{
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("header"));
		}
		if (!header.IsMessageVersionSupported(MessageVersion))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MessageHeaderVersionNotSupported, header.GetType().FullName, MessageVersion.Envelope.ToString()), "header"));
		}
		Insert(headerIndex, header, GetHeaderKind(header));
	}

	private void Insert(int headerIndex, MessageHeader header, HeaderKind kind)
	{
		ReadableMessageHeader readableMessageHeader = header as ReadableMessageHeader;
		HeaderProcessing headerProcessing = (header.MustUnderstand ? HeaderProcessing.MustUnderstand : ((HeaderProcessing)0));
		if (kind != HeaderKind.Unknown)
		{
			headerProcessing |= HeaderProcessing.Understood;
		}
		if (readableMessageHeader != null)
		{
			InsertHeader(headerIndex, new Header(kind, readableMessageHeader, headerProcessing));
		}
		else
		{
			InsertHeader(headerIndex, new Header(kind, header, headerProcessing));
		}
	}

	private void InsertHeader(int headerIndex, Header header)
	{
		ValidateHeaderKind(header.HeaderKind);
		if (headerIndex < 0 || headerIndex > _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		if (_headerCount == _headers.Length)
		{
			if (_headers.Length == 0)
			{
				_headers = new Header[1];
			}
			else
			{
				Header[] array = new Header[_headers.Length * 2];
				_headers.CopyTo(array, 0);
				_headers = array;
			}
		}
		if (headerIndex < _headerCount)
		{
			if (_bufferedMessageData != null)
			{
				for (int i = headerIndex; i < _headerCount; i++)
				{
					if (_headers[i].HeaderType == HeaderType.BufferedMessageHeader)
					{
						CaptureBufferedHeaders();
						break;
					}
				}
			}
			Array.Copy(_headers, headerIndex, _headers, headerIndex + 1, _headerCount - headerIndex);
		}
		_headers[headerIndex] = header;
		_headerCount++;
		CollectionVersion++;
	}

	internal bool IsUnderstood(int i)
	{
		return (_headers[i].HeaderProcessing & HeaderProcessing.Understood) != 0;
	}

	internal bool IsUnderstood(MessageHeaderInfo headerInfo)
	{
		if (headerInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("headerInfo"));
		}
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderInfo == headerInfo && IsUnderstood(i))
			{
				return true;
			}
		}
		return false;
	}

	private void ReadBufferedHeader(XmlDictionaryReader reader, RecycledMessageState recycledMessageState, XmlDictionaryString[] localNames, bool understood)
	{
		if (MessageVersion.Addressing == AddressingVersion.None && reader.NamespaceURI == AddressingVersion.None.Namespace)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.AddressingHeadersCannotBeAddedToAddressingVersion, MessageVersion.Addressing)));
		}
		MessageHeader.GetHeaderAttributes(reader, MessageVersion, out var actor, out var mustUnderstand, out var relay, out var isReferenceParameter);
		HeaderKind headerKind = HeaderKind.Unknown;
		MessageHeaderInfo messageHeaderInfo = null;
		if (MessageVersion.Envelope.IsUltimateDestinationActor(actor))
		{
			headerKind = (HeaderKind)reader.IndexOfLocalName(localNames, MessageVersion.Addressing.DictionaryNamespace);
			switch (headerKind)
			{
			case HeaderKind.To:
				messageHeaderInfo = ToHeader.ReadHeader(reader, MessageVersion.Addressing, recycledMessageState.UriCache, actor, mustUnderstand, relay);
				break;
			case HeaderKind.Action:
				messageHeaderInfo = ActionHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			case HeaderKind.MessageId:
				messageHeaderInfo = MessageIDHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			case HeaderKind.RelatesTo:
				messageHeaderInfo = RelatesToHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			case HeaderKind.ReplyTo:
				messageHeaderInfo = ReplyToHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			case HeaderKind.From:
				messageHeaderInfo = FromHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			case HeaderKind.FaultTo:
				messageHeaderInfo = FaultToHeader.ReadHeader(reader, MessageVersion.Addressing, actor, mustUnderstand, relay);
				break;
			default:
				headerKind = HeaderKind.Unknown;
				break;
			}
		}
		if (messageHeaderInfo == null)
		{
			messageHeaderInfo = recycledMessageState.HeaderInfoCache.TakeHeaderInfo(reader, actor, mustUnderstand, relay, isReferenceParameter);
			reader.Skip();
		}
		HeaderProcessing headerProcessing = (mustUnderstand ? HeaderProcessing.MustUnderstand : ((HeaderProcessing)0));
		if (headerKind != HeaderKind.Unknown || understood)
		{
			headerProcessing |= HeaderProcessing.Understood;
			TraceUnderstood(messageHeaderInfo);
		}
		AddHeader(new Header(headerKind, messageHeaderInfo, headerProcessing));
	}

	internal void Recycle(HeaderInfoCache headerInfoCache)
	{
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderKind == HeaderKind.Unknown)
			{
				headerInfoCache.ReturnHeaderInfo(_headers[i].HeaderInfo);
			}
		}
		Clear();
		CollectionVersion = 0;
		if (_understoodHeaders != null)
		{
			_understoodHeaders.Modified = false;
		}
	}

	internal void RemoveUnderstood(MessageHeaderInfo headerInfo)
	{
		if (headerInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("headerInfo"));
		}
		for (int i = 0; i < _headerCount; i++)
		{
			if (_headers[i].HeaderInfo == headerInfo)
			{
				if ((_headers[i].HeaderProcessing & HeaderProcessing.Understood) == 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.HeaderAlreadyNotUnderstood, headerInfo.Name, headerInfo.Namespace), "headerInfo"));
				}
				_headers[i].HeaderProcessing &= ~HeaderProcessing.Understood;
			}
		}
	}

	public void RemoveAll(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("ns"));
		}
		for (int num = _headerCount - 1; num >= 0; num--)
		{
			MessageHeaderInfo headerInfo = _headers[num].HeaderInfo;
			if (headerInfo.Name == name && headerInfo.Namespace == ns)
			{
				RemoveAt(num);
			}
		}
	}

	public void RemoveAt(int headerIndex)
	{
		if (headerIndex < 0 || headerIndex >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		if (_bufferedMessageData != null && _headers[headerIndex].HeaderType == HeaderType.BufferedMessageHeader)
		{
			CaptureBufferedHeaders(headerIndex);
		}
		Array.Copy(_headers, headerIndex + 1, _headers, headerIndex, _headerCount - headerIndex - 1);
		_headers[--_headerCount] = default(Header);
		CollectionVersion++;
	}

	internal void ReplaceAt(int headerIndex, MessageHeader header)
	{
		if (headerIndex < 0 || headerIndex >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("header");
		}
		ReplaceAt(headerIndex, header, GetHeaderKind(header));
	}

	private void ReplaceAt(int headerIndex, MessageHeader header, HeaderKind kind)
	{
		HeaderProcessing headerProcessing = (header.MustUnderstand ? HeaderProcessing.MustUnderstand : ((HeaderProcessing)0));
		if (kind != HeaderKind.Unknown)
		{
			headerProcessing |= HeaderProcessing.Understood;
		}
		if (header is ReadableMessageHeader readableHeader)
		{
			_headers[headerIndex] = new Header(kind, readableHeader, headerProcessing);
		}
		else
		{
			_headers[headerIndex] = new Header(kind, header, headerProcessing);
		}
		CollectionVersion++;
	}

	public void SetAction(XmlDictionaryString action)
	{
		if (action == null)
		{
			SetHeaderProperty(HeaderKind.Action, null);
		}
		else
		{
			SetActionHeader(ActionHeader.Create(action, MessageVersion.Addressing));
		}
	}

	internal void SetActionHeader(ActionHeader actionHeader)
	{
		SetHeaderProperty(HeaderKind.Action, actionHeader);
	}

	internal void SetFaultToHeader(FaultToHeader faultToHeader)
	{
		SetHeaderProperty(HeaderKind.FaultTo, faultToHeader);
	}

	internal void SetFromHeader(FromHeader fromHeader)
	{
		SetHeaderProperty(HeaderKind.From, fromHeader);
	}

	internal void SetMessageIDHeader(MessageIDHeader messageIDHeader)
	{
		SetHeaderProperty(HeaderKind.MessageId, messageIDHeader);
	}

	internal void SetRelatesTo(Uri relationshipType, UniqueId messageId)
	{
		if (relationshipType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("relationshipType");
		}
		SetRelatesTo(relatesToHeader: ((object)messageId == null) ? null : RelatesToHeader.Create(messageId, MessageVersion.Addressing, relationshipType), relationshipType: RelatesToHeader.ReplyRelationshipType);
	}

	private void SetRelatesTo(Uri relationshipType, RelatesToHeader relatesToHeader)
	{
		UniqueId messageId;
		int num = FindRelatesTo(relationshipType, out messageId);
		if (num >= 0)
		{
			if (relatesToHeader == null)
			{
				RemoveAt(num);
			}
			else
			{
				ReplaceAt(num, relatesToHeader, HeaderKind.RelatesTo);
			}
		}
		else if (relatesToHeader != null)
		{
			Add(relatesToHeader, HeaderKind.RelatesTo);
		}
	}

	internal void SetReplyToHeader(ReplyToHeader replyToHeader)
	{
		SetHeaderProperty(HeaderKind.ReplyTo, replyToHeader);
	}

	internal void SetToHeader(ToHeader toHeader)
	{
		SetHeaderProperty(HeaderKind.To, toHeader);
	}

	private void SetHeaderProperty(HeaderKind kind, MessageHeader header)
	{
		int num = FindHeaderProperty(kind);
		if (num >= 0)
		{
			if (header == null)
			{
				RemoveAt(num);
			}
			else
			{
				ReplaceAt(num, header, kind);
			}
		}
		else if (header != null)
		{
			Add(header, kind);
		}
	}

	public void WriteHeader(int headerIndex, XmlWriter writer)
	{
		WriteHeader(headerIndex, XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteHeader(int headerIndex, XmlDictionaryWriter writer)
	{
		WriteStartHeader(headerIndex, writer);
		WriteHeaderContents(headerIndex, writer);
		writer.WriteEndElement();
	}

	public void WriteStartHeader(int headerIndex, XmlWriter writer)
	{
		WriteStartHeader(headerIndex, XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteStartHeader(int headerIndex, XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (headerIndex < 0 || headerIndex >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		switch (_headers[headerIndex].HeaderType)
		{
		case HeaderType.ReadableHeader:
		case HeaderType.WriteableHeader:
			_headers[headerIndex].MessageHeader.WriteStartHeader(writer, MessageVersion);
			break;
		case HeaderType.BufferedMessageHeader:
			WriteStartBufferedMessageHeader(_bufferedMessageData, headerIndex, writer);
			break;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, _headers[headerIndex].HeaderType)));
		}
	}

	public void WriteHeaderContents(int headerIndex, XmlWriter writer)
	{
		WriteHeaderContents(headerIndex, XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteHeaderContents(int headerIndex, XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (headerIndex < 0 || headerIndex >= _headerCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("headerIndex", headerIndex, System.SR.Format(System.SR.ValueMustBeInRange, 0, _headerCount)));
		}
		switch (_headers[headerIndex].HeaderType)
		{
		case HeaderType.ReadableHeader:
		case HeaderType.WriteableHeader:
			_headers[headerIndex].MessageHeader.WriteHeaderContents(writer, MessageVersion);
			break;
		case HeaderType.BufferedMessageHeader:
			WriteBufferedMessageHeaderContents(_bufferedMessageData, headerIndex, writer);
			break;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidEnumValue, _headers[headerIndex].HeaderType)));
		}
	}

	private static void TraceUnderstood(MessageHeaderInfo info)
	{
	}

	private void WriteBufferedMessageHeader(IBufferedMessageData bufferedMessageData, int bufferedMessageHeaderIndex, XmlWriter writer)
	{
		using XmlReader reader = GetBufferedMessageHeaderReader(bufferedMessageData, bufferedMessageHeaderIndex);
		writer.WriteNode(reader, defattr: false);
	}

	private void WriteStartBufferedMessageHeader(IBufferedMessageData bufferedMessageData, int bufferedMessageHeaderIndex, XmlWriter writer)
	{
		using XmlReader xmlReader = GetBufferedMessageHeaderReader(bufferedMessageData, bufferedMessageHeaderIndex);
		writer.WriteStartElement(xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI);
		writer.WriteAttributes(xmlReader, defattr: false);
	}

	private void WriteBufferedMessageHeaderContents(IBufferedMessageData bufferedMessageData, int bufferedMessageHeaderIndex, XmlWriter writer)
	{
		using XmlReader xmlReader = GetBufferedMessageHeaderReader(bufferedMessageData, bufferedMessageHeaderIndex);
		if (!xmlReader.IsEmptyElement)
		{
			xmlReader.ReadStartElement();
			while (xmlReader.NodeType != XmlNodeType.EndElement)
			{
				writer.WriteNode(xmlReader, defattr: false);
			}
			xmlReader.ReadEndElement();
		}
	}
}

using System.Collections.Generic;
using System.Runtime;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class MessagePatterns
{
	internal sealed class PatternMessage : ReceivedMessage
	{
		private IBufferedMessageData _messageData;

		private MessageHeaders _headers;

		private RecycledMessageState _recycledMessageState;

		private MessageProperties _properties;

		private XmlDictionaryReader _reader;

		public override MessageHeaders Headers
		{
			get
			{
				if (base.IsDisposed)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateMessageDisposedException());
				}
				return _headers;
			}
		}

		public override MessageProperties Properties
		{
			get
			{
				if (base.IsDisposed)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateMessageDisposedException());
				}
				return _properties;
			}
		}

		public override MessageVersion Version
		{
			get
			{
				if (base.IsDisposed)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateMessageDisposedException());
				}
				return _headers.MessageVersion;
			}
		}

		internal override RecycledMessageState RecycledMessageState => _recycledMessageState;

		public PatternMessage(IBufferedMessageData messageData, MessageVersion messageVersion)
		{
			_messageData = messageData;
			_recycledMessageState = messageData.TakeMessageState();
			if (_recycledMessageState == null)
			{
				_recycledMessageState = new RecycledMessageState();
			}
			_properties = _recycledMessageState.TakeProperties();
			if (_properties == null)
			{
				_properties = new MessageProperties();
			}
			_headers = _recycledMessageState.TakeHeaders();
			if (_headers == null)
			{
				_headers = new MessageHeaders(messageVersion);
			}
			else
			{
				_headers.Init(messageVersion);
			}
			XmlDictionaryReader messageReader = messageData.GetMessageReader();
			messageReader.ReadStartElement();
			ReceivedMessage.VerifyStartBody(messageReader, messageVersion.Envelope);
			ReadStartBody(messageReader);
			_reader = messageReader;
		}

		public PatternMessage(IBufferedMessageData messageData, MessageVersion messageVersion, KeyValuePair<string, object>[] properties, MessageHeaders headers)
		{
			_messageData = messageData;
			_messageData.Open();
			_recycledMessageState = _messageData.TakeMessageState();
			if (_recycledMessageState == null)
			{
				_recycledMessageState = new RecycledMessageState();
			}
			_properties = _recycledMessageState.TakeProperties();
			if (_properties == null)
			{
				_properties = new MessageProperties();
			}
			if (properties != null)
			{
				_properties.CopyProperties(properties);
			}
			_headers = _recycledMessageState.TakeHeaders();
			if (_headers == null)
			{
				_headers = new MessageHeaders(messageVersion);
			}
			if (headers != null)
			{
				_headers.CopyHeadersFrom(headers);
			}
			XmlDictionaryReader messageReader = messageData.GetMessageReader();
			messageReader.ReadStartElement();
			ReceivedMessage.VerifyStartBody(messageReader, messageVersion.Envelope);
			ReadStartBody(messageReader);
			_reader = messageReader;
		}

		private XmlDictionaryReader GetBufferedReaderAtBody()
		{
			XmlDictionaryReader messageReader = _messageData.GetMessageReader();
			messageReader.ReadStartElement();
			messageReader.ReadStartElement();
			return messageReader;
		}

		protected override void OnBodyToString(XmlDictionaryWriter writer)
		{
			using XmlDictionaryReader xmlDictionaryReader = GetBufferedReaderAtBody();
			while (xmlDictionaryReader.NodeType != XmlNodeType.EndElement)
			{
				writer.WriteNode(xmlDictionaryReader, defattr: false);
			}
		}

		protected override void OnClose()
		{
			Exception ex = null;
			try
			{
				base.OnClose();
			}
			catch (Exception ex2)
			{
				if (Fx.IsFatal(ex2))
				{
					throw;
				}
				ex = ex2;
			}
			try
			{
				_properties.Dispose();
			}
			catch (Exception ex3)
			{
				if (Fx.IsFatal(ex3))
				{
					throw;
				}
				if (ex == null)
				{
					ex = ex3;
				}
			}
			try
			{
				if (_reader != null)
				{
					_reader.Dispose();
				}
			}
			catch (Exception ex4)
			{
				if (Fx.IsFatal(ex4))
				{
					throw;
				}
				if (ex == null)
				{
					ex = ex4;
				}
			}
			try
			{
				_recycledMessageState.ReturnHeaders(_headers);
				_recycledMessageState.ReturnProperties(_properties);
				_messageData.ReturnMessageState(_recycledMessageState);
				_recycledMessageState = null;
				_messageData.Close();
				_messageData = null;
			}
			catch (Exception ex5)
			{
				if (Fx.IsFatal(ex5))
				{
					throw;
				}
				if (ex == null)
				{
					ex = ex5;
				}
			}
			if (ex != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
			}
		}

		protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
		{
			KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[Properties.Count];
			((ICollection<KeyValuePair<string, object>>)Properties).CopyTo(array, 0);
			_messageData.EnableMultipleUsers();
			return new PatternMessageBuffer(_messageData, Version, array, _headers);
		}

		protected override XmlDictionaryReader OnGetReaderAtBodyContents()
		{
			XmlDictionaryReader reader = _reader;
			_reader = null;
			return reader;
		}

		protected override string OnGetBodyAttribute(string localName, string ns)
		{
			return null;
		}
	}

	internal class PatternMessageBuffer : MessageBuffer
	{
		private bool _closed;

		private MessageHeaders _headers;

		private IBufferedMessageData _messageDataAtBody;

		private MessageVersion _messageVersion;

		private KeyValuePair<string, object>[] _properties;

		private RecycledMessageState _recycledMessageState;

		public override int BufferSize
		{
			get
			{
				lock (ThisLock)
				{
					if (_closed)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBufferDisposedException());
					}
					return _messageDataAtBody.Buffer.Count;
				}
			}
		}

		private object ThisLock { get; } = new object();

		public PatternMessageBuffer(IBufferedMessageData messageDataAtBody, MessageVersion messageVersion, KeyValuePair<string, object>[] properties, MessageHeaders headers)
		{
			_messageDataAtBody = messageDataAtBody;
			_messageDataAtBody.Open();
			_recycledMessageState = _messageDataAtBody.TakeMessageState();
			if (_recycledMessageState == null)
			{
				_recycledMessageState = new RecycledMessageState();
			}
			_headers = _recycledMessageState.TakeHeaders();
			if (_headers == null)
			{
				_headers = new MessageHeaders(messageVersion);
			}
			_headers.CopyHeadersFrom(headers);
			_properties = properties;
			_messageVersion = messageVersion;
		}

		public override void Close()
		{
			lock (ThisLock)
			{
				if (!_closed)
				{
					_closed = true;
					_recycledMessageState.ReturnHeaders(_headers);
					_messageDataAtBody.ReturnMessageState(_recycledMessageState);
					_messageDataAtBody.Close();
					_recycledMessageState = null;
					_messageDataAtBody = null;
					_properties = null;
					_messageVersion = null;
					_headers = null;
				}
			}
		}

		public override Message CreateMessage()
		{
			lock (ThisLock)
			{
				if (_closed)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBufferDisposedException());
				}
				return new PatternMessage(_messageDataAtBody, _messageVersion, _properties, _headers);
			}
		}
	}

	private static readonly byte[] s_commonFragment;

	private static readonly byte[] s_requestFragment1;

	private static readonly byte[] s_requestFragment2;

	private static readonly byte[] s_responseFragment1;

	private static readonly byte[] s_responseFragment2;

	private static readonly byte[] s_bodyFragment;

	private const int ToValueSessionKey = 1;

	private IXmlDictionary _dictionary;

	private XmlBinaryReaderSession _readerSession;

	private ToHeader _toHeader;

	private MessageVersion _messageVersion;

	static MessagePatterns()
	{
		BinaryFormatBuilder binaryFormatBuilder = new BinaryFormatBuilder();
		MessageDictionary messageDictionary = XD.MessageDictionary;
		Message12Dictionary message12Dictionary = XD.Message12Dictionary;
		AddressingDictionary addressingDictionary = XD.AddressingDictionary;
		Addressing10Dictionary addressing10Dictionary = XD.Addressing10Dictionary;
		char prefix = "s"[0];
		char prefix2 = "a"[0];
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Envelope.Key));
		binaryFormatBuilder.AppendDictionaryXmlnsAttribute(prefix, binaryFormatBuilder.GetStaticKey(message12Dictionary.Namespace.Key));
		binaryFormatBuilder.AppendDictionaryXmlnsAttribute(prefix2, binaryFormatBuilder.GetStaticKey(addressing10Dictionary.Namespace.Key));
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Header.Key));
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.Action.Key));
		binaryFormatBuilder.AppendPrefixDictionaryAttribute(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.MustUnderstand.Key), '1');
		binaryFormatBuilder.AppendDictionaryTextWithEndElement();
		s_commonFragment = binaryFormatBuilder.ToByteArray();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.MessageId.Key));
		binaryFormatBuilder.AppendUniqueIDWithEndElement();
		s_requestFragment1 = binaryFormatBuilder.ToByteArray();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.ReplyTo.Key));
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.Address.Key));
		binaryFormatBuilder.AppendDictionaryTextWithEndElement(binaryFormatBuilder.GetStaticKey(addressing10Dictionary.Anonymous.Key));
		binaryFormatBuilder.AppendEndElement();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.To.Key));
		binaryFormatBuilder.AppendPrefixDictionaryAttribute(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.MustUnderstand.Key), '1');
		binaryFormatBuilder.AppendDictionaryTextWithEndElement(binaryFormatBuilder.GetSessionKey(1));
		binaryFormatBuilder.AppendEndElement();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Body.Key));
		s_requestFragment2 = binaryFormatBuilder.ToByteArray();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.RelatesTo.Key));
		binaryFormatBuilder.AppendUniqueIDWithEndElement();
		s_responseFragment1 = binaryFormatBuilder.ToByteArray();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix2, binaryFormatBuilder.GetStaticKey(addressingDictionary.To.Key));
		binaryFormatBuilder.AppendPrefixDictionaryAttribute(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.MustUnderstand.Key), '1');
		binaryFormatBuilder.AppendDictionaryTextWithEndElement(binaryFormatBuilder.GetStaticKey(addressing10Dictionary.Anonymous.Key));
		binaryFormatBuilder.AppendEndElement();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Body.Key));
		s_responseFragment2 = binaryFormatBuilder.ToByteArray();
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Envelope.Key));
		binaryFormatBuilder.AppendDictionaryXmlnsAttribute(prefix, binaryFormatBuilder.GetStaticKey(message12Dictionary.Namespace.Key));
		binaryFormatBuilder.AppendDictionaryXmlnsAttribute(prefix2, binaryFormatBuilder.GetStaticKey(addressing10Dictionary.Namespace.Key));
		binaryFormatBuilder.AppendPrefixDictionaryElement(prefix, binaryFormatBuilder.GetStaticKey(messageDictionary.Body.Key));
		s_bodyFragment = binaryFormatBuilder.ToByteArray();
	}

	public MessagePatterns(IXmlDictionary dictionary, XmlBinaryReaderSession readerSession, MessageVersion messageVersion)
	{
		_dictionary = dictionary;
		_readerSession = readerSession;
		_messageVersion = messageVersion;
	}

	public Message TryCreateMessage(byte[] buffer, int offset, int size, BufferManager bufferManager, BufferedMessageData messageData)
	{
		int num = offset;
		int num2 = size;
		int num3 = BinaryFormatParser.MatchBytes(buffer, num, num2, s_commonFragment);
		if (num3 == 0)
		{
			return null;
		}
		num += num3;
		num2 -= num3;
		num3 = BinaryFormatParser.MatchKey(buffer, num, num2);
		if (num3 == 0)
		{
			return null;
		}
		int offset2 = num;
		int num4 = num3;
		num += num3;
		num2 -= num3;
		num3 = BinaryFormatParser.MatchBytes(buffer, num, num2, s_requestFragment1);
		MessageIDHeader messageIDHeader;
		RelatesToHeader relatesToHeader;
		XmlDictionaryString result;
		int num6;
		if (num3 != 0)
		{
			num += num3;
			num2 -= num3;
			num3 = BinaryFormatParser.MatchUniqueID(buffer, num, num2);
			if (num3 == 0)
			{
				return null;
			}
			int offset3 = num;
			int num5 = num3;
			num += num3;
			num2 -= num3;
			num3 = BinaryFormatParser.MatchBytes(buffer, num, num2, s_requestFragment2);
			if (num3 == 0)
			{
				return null;
			}
			num += num3;
			num2 -= num3;
			if (BinaryFormatParser.MatchAttributeNode(buffer, num, num2))
			{
				return null;
			}
			UniqueId messageId = BinaryFormatParser.ParseUniqueID(buffer, offset3, num5);
			messageIDHeader = MessageIDHeader.Create(messageId, _messageVersion.Addressing);
			relatesToHeader = null;
			if (!_readerSession.TryLookup(1, out result))
			{
				return null;
			}
			num6 = s_requestFragment1.Length + num5 + s_requestFragment2.Length;
		}
		else
		{
			num3 = BinaryFormatParser.MatchBytes(buffer, num, num2, s_responseFragment1);
			if (num3 == 0)
			{
				return null;
			}
			num += num3;
			num2 -= num3;
			num3 = BinaryFormatParser.MatchUniqueID(buffer, num, num2);
			if (num3 == 0)
			{
				return null;
			}
			int offset4 = num;
			int num7 = num3;
			num += num3;
			num2 -= num3;
			num3 = BinaryFormatParser.MatchBytes(buffer, num, num2, s_responseFragment2);
			if (num3 == 0)
			{
				return null;
			}
			num += num3;
			num2 -= num3;
			if (BinaryFormatParser.MatchAttributeNode(buffer, num, num2))
			{
				return null;
			}
			UniqueId messageId2 = BinaryFormatParser.ParseUniqueID(buffer, offset4, num7);
			relatesToHeader = RelatesToHeader.Create(messageId2, _messageVersion.Addressing);
			messageIDHeader = null;
			result = XD.Addressing10Dictionary.Anonymous;
			num6 = s_responseFragment1.Length + num7 + s_responseFragment2.Length;
		}
		num6 += s_commonFragment.Length + num4;
		int key = BinaryFormatParser.ParseKey(buffer, offset2, num4);
		if (!TryLookupKey(key, out var result2))
		{
			return null;
		}
		ActionHeader actionHeader = ActionHeader.Create(result2, _messageVersion.Addressing);
		if (_toHeader == null)
		{
			_toHeader = ToHeader.Create(new Uri(result.Value), _messageVersion.Addressing);
		}
		int num8 = num6 - s_bodyFragment.Length;
		offset += num8;
		size -= num8;
		Buffer.BlockCopy(s_bodyFragment, 0, buffer, offset, s_bodyFragment.Length);
		messageData.Open(new ArraySegment<byte>(buffer, offset, size), bufferManager);
		PatternMessage patternMessage = new PatternMessage(messageData, _messageVersion);
		MessageHeaders headers = patternMessage.Headers;
		headers.AddActionHeader(actionHeader);
		if (messageIDHeader != null)
		{
			headers.AddMessageIDHeader(messageIDHeader);
			headers.AddReplyToHeader(ReplyToHeader.AnonymousReplyTo10);
		}
		else
		{
			headers.AddRelatesToHeader(relatesToHeader);
		}
		headers.AddToHeader(_toHeader);
		return patternMessage;
	}

	private bool TryLookupKey(int key, out XmlDictionaryString result)
	{
		if (BinaryFormatParser.IsSessionKey(key))
		{
			return _readerSession.TryLookup(BinaryFormatParser.GetSessionKey(key), out result);
		}
		return _dictionary.TryLookup(BinaryFormatParser.GetStaticKey(key), out result);
	}
}

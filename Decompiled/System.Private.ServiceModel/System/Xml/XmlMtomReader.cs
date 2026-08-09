using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime;
using System.ServiceModel;
using System.Text;

namespace System.Xml;

internal class XmlMtomReader : XmlDictionaryReader, IXmlLineInfo, IXmlMtomReaderInitializer
{
	internal class MimePart
	{
		private Stream stream;

		private MimeHeaders headers;

		private byte[] buffer;

		private bool isReferencedFromInfoset;

		internal Stream Stream => stream;

		internal MimeHeaders Headers => headers;

		internal bool ReferencedFromInfoset
		{
			get
			{
				return isReferencedFromInfoset;
			}
			set
			{
				isReferencedFromInfoset = value;
			}
		}

		internal long Length
		{
			get
			{
				if (!stream.CanSeek)
				{
					return 0L;
				}
				return stream.Length;
			}
		}

		internal MimePart(Stream stream, MimeHeaders headers)
		{
			this.stream = stream;
			this.headers = headers;
		}

		internal byte[] GetBuffer(int maxBuffer, ref int remaining)
		{
			if (buffer == null)
			{
				MemoryStream memoryStream = (stream.CanSeek ? new MemoryStream((int)stream.Length) : new MemoryStream());
				int num = 256;
				byte[] array = new byte[num];
				int num2 = 0;
				do
				{
					num2 = stream.Read(array, 0, num);
					DecrementBufferQuota(maxBuffer, ref remaining, num2);
					if (num2 > 0)
					{
						memoryStream.Write(array, 0, num2);
					}
				}
				while (num2 > 0);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				buffer = memoryStream.GetBuffer();
				stream = memoryStream;
			}
			return buffer;
		}

		internal void Release(int maxBuffer, ref int remaining)
		{
			remaining += (int)Length;
			headers.Release(ref remaining);
		}
	}

	internal class XopIncludeReader : XmlDictionaryReader, IXmlLineInfo
	{
		private int _chunkSize = 4096;

		private int _bytesRemaining;

		private MimePart _part;

		private ReadState _readState;

		private XmlDictionaryReader _parentReader;

		private string _stringValue;

		private int _stringOffset;

		private XmlNodeType _nodeType;

		private MemoryStream _binHexStream;

		private byte[] _valueBuffer;

		private int _valueOffset;

		private int _valueCount;

		private bool _finishedStream;

		public override XmlDictionaryReaderQuotas Quotas => _parentReader.Quotas;

		public override XmlNodeType NodeType
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.NodeType;
				}
				return _nodeType;
			}
		}

		public override string Value
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return string.Empty;
				}
				if (_stringValue == null)
				{
					int bytesRemaining = _bytesRemaining;
					bytesRemaining -= bytesRemaining % 3;
					if (_valueCount > 0 && _valueOffset > 0)
					{
						Buffer.BlockCopy(_valueBuffer, _valueOffset, _valueBuffer, 0, _valueCount);
						_valueOffset = 0;
					}
					bytesRemaining -= _valueCount;
					if (_valueBuffer == null)
					{
						_valueBuffer = new byte[bytesRemaining];
					}
					else if (_valueBuffer.Length < bytesRemaining)
					{
						Array.Resize(ref _valueBuffer, bytesRemaining);
					}
					byte[] valueBuffer = _valueBuffer;
					int num = 0;
					int num2 = 0;
					while (bytesRemaining > 0)
					{
						num2 = _part.Stream.Read(valueBuffer, num, bytesRemaining);
						if (num2 == 0)
						{
							_finishedStream = true;
							break;
						}
						_bytesRemaining -= num2;
						_valueCount += num2;
						bytesRemaining -= num2;
						num += num2;
					}
					_stringValue = Convert.ToBase64String(valueBuffer, 0, _valueCount);
				}
				return _stringValue;
			}
		}

		public override int AttributeCount => 0;

		public override string BaseURI => _parentReader.BaseURI;

		public override bool CanReadBinaryContent => true;

		public override bool CanReadValueChunk => true;

		public override bool CanResolveEntity => _parentReader.CanResolveEntity;

		public override int Depth
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.Depth;
				}
				return _parentReader.Depth + 1;
			}
		}

		public override bool EOF => _readState == ReadState.EndOfFile;

		public override bool HasAttributes => false;

		public override bool HasValue => _readState == ReadState.Interactive;

		public override bool IsDefault => false;

		public override bool IsEmptyElement => false;

		public override string LocalName
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.LocalName;
				}
				return string.Empty;
			}
		}

		public override string Name
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.Name;
				}
				return string.Empty;
			}
		}

		public override string NamespaceURI
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.NamespaceURI;
				}
				return string.Empty;
			}
		}

		public override XmlNameTable NameTable => _parentReader.NameTable;

		public override string Prefix
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.Prefix;
				}
				return string.Empty;
			}
		}

		public override char QuoteChar => _parentReader.QuoteChar;

		public override ReadState ReadState => _readState;

		public override XmlReaderSettings Settings => _parentReader.Settings;

		public override string this[int index] => null;

		public override string this[string name] => null;

		public override string this[string name, string ns] => null;

		public override string XmlLang => _parentReader.XmlLang;

		public override XmlSpace XmlSpace => _parentReader.XmlSpace;

		public override Type ValueType
		{
			get
			{
				if (_readState != ReadState.Interactive)
				{
					return _parentReader.ValueType;
				}
				return typeof(byte[]);
			}
		}

		int IXmlLineInfo.LineNumber => ((IXmlLineInfo)_parentReader).LineNumber;

		int IXmlLineInfo.LinePosition => ((IXmlLineInfo)_parentReader).LinePosition;

		public XopIncludeReader(MimePart part, XmlDictionaryReader reader)
		{
			if (part == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("part");
			}
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			_part = part;
			_parentReader = reader;
			_readState = ReadState.Initial;
			_nodeType = XmlNodeType.None;
			_chunkSize = Math.Min(reader.Quotas.MaxBytesPerRead, _chunkSize);
			_bytesRemaining = _chunkSize;
			_finishedStream = false;
		}

		public override bool Read()
		{
			bool result = true;
			switch (_readState)
			{
			case ReadState.Initial:
				_readState = ReadState.Interactive;
				_nodeType = XmlNodeType.Text;
				break;
			case ReadState.Interactive:
				if (_finishedStream || (_bytesRemaining == _chunkSize && _stringValue == null))
				{
					_readState = ReadState.EndOfFile;
					_nodeType = XmlNodeType.EndElement;
				}
				else
				{
					_bytesRemaining = _chunkSize;
				}
				break;
			case ReadState.EndOfFile:
				_nodeType = XmlNodeType.None;
				result = false;
				break;
			}
			_stringValue = null;
			_binHexStream = null;
			_valueOffset = 0;
			_valueCount = 0;
			_stringOffset = 0;
			CloseStreams();
			return result;
		}

		public override int ReadValueAsBase64(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
			}
			if (offset < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
			}
			if (offset > buffer.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, buffer.Length)));
			}
			if (count < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
			}
			if (count > buffer.Length - offset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, buffer.Length - offset)));
			}
			if (_stringValue != null)
			{
				count = Math.Min(count, _valueCount);
				if (count > 0)
				{
					Buffer.BlockCopy(_valueBuffer, _valueOffset, buffer, offset, count);
					_valueOffset += count;
					_valueCount -= count;
				}
				return count;
			}
			if (_bytesRemaining < count)
			{
				count = _bytesRemaining;
			}
			int i = 0;
			if (_readState == ReadState.Interactive)
			{
				int num;
				for (; i < count; i += num)
				{
					num = _part.Stream.Read(buffer, offset + i, count - i);
					if (num == 0)
					{
						_finishedStream = true;
						break;
					}
				}
			}
			_bytesRemaining -= i;
			return i;
		}

		public override int ReadContentAsBase64(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
			}
			if (offset < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
			}
			if (offset > buffer.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, buffer.Length)));
			}
			if (count < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
			}
			if (count > buffer.Length - offset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, buffer.Length - offset)));
			}
			if (_valueCount > 0)
			{
				count = Math.Min(count, _valueCount);
				Buffer.BlockCopy(_valueBuffer, _valueOffset, buffer, offset, count);
				_valueOffset += count;
				_valueCount -= count;
				return count;
			}
			if (_chunkSize < count)
			{
				count = _chunkSize;
			}
			int i = 0;
			if (_readState == ReadState.Interactive)
			{
				int num;
				for (; i < count; i += num)
				{
					num = _part.Stream.Read(buffer, offset + i, count - i);
					if (num == 0)
					{
						_finishedStream = true;
						if (!Read())
						{
							break;
						}
					}
				}
			}
			_bytesRemaining = _chunkSize;
			return i;
		}

		public override int ReadContentAsBinHex(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
			}
			if (offset < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
			}
			if (offset > buffer.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, buffer.Length)));
			}
			if (count < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
			}
			if (count > buffer.Length - offset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, buffer.Length - offset)));
			}
			if (_chunkSize < count)
			{
				count = _chunkSize;
			}
			int num = 0;
			int num2 = 0;
			while (num < count)
			{
				if (_binHexStream == null)
				{
					try
					{
						_binHexStream = new MemoryStream(new System.Text.BinHexEncoding().GetBytes(Value));
					}
					catch (FormatException ex)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(ex.Message, ex));
					}
				}
				int num3 = _binHexStream.Read(buffer, offset + num, count - num);
				if (num3 == 0)
				{
					_finishedStream = true;
					if (!Read())
					{
						break;
					}
					num2 = 0;
				}
				num += num3;
				num2 += num3;
			}
			if (_stringValue != null && num2 > 0)
			{
				_stringValue = _stringValue.Substring(num2 * 2);
				_stringOffset = Math.Max(0, _stringOffset - num2 * 2);
				_bytesRemaining = _chunkSize;
			}
			return num;
		}

		public override int ReadValueChunk(char[] chars, int offset, int count)
		{
			if (chars == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("chars");
			}
			if (offset < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
			}
			if (offset > chars.Length)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
			}
			if (count < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
			}
			if (count > chars.Length - offset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, chars.Length - offset)));
			}
			if (_readState != ReadState.Interactive)
			{
				return 0;
			}
			string value = Value;
			count = Math.Min(_stringValue.Length - _stringOffset, count);
			if (count > 0)
			{
				_stringValue.CopyTo(_stringOffset, chars, offset, count);
				_stringOffset += count;
			}
			return count;
		}

		public override string ReadContentAsString()
		{
			int num = Quotas.MaxStringContentLength;
			StringBuilder stringBuilder = new StringBuilder();
			do
			{
				string value = Value;
				if (value.Length > num)
				{
					System.Xml.XmlExceptionHelper.ThrowMaxStringContentLengthExceeded(this, Quotas.MaxStringContentLength);
				}
				num -= value.Length;
				stringBuilder.Append(value);
			}
			while (Read());
			return stringBuilder.ToString();
		}

		public override void Close()
		{
			CloseStreams();
			_readState = ReadState.Closed;
		}

		private void CloseStreams()
		{
			if (_binHexStream != null)
			{
				_binHexStream.Close();
				_binHexStream = null;
			}
		}

		public override string GetAttribute(int index)
		{
			return null;
		}

		public override string GetAttribute(string name)
		{
			return null;
		}

		public override string GetAttribute(string name, string ns)
		{
			return null;
		}

		public override string GetAttribute(XmlDictionaryString localName, XmlDictionaryString ns)
		{
			return null;
		}

		public override bool IsLocalName(string localName)
		{
			return false;
		}

		public override bool IsLocalName(XmlDictionaryString localName)
		{
			return false;
		}

		public override bool IsNamespaceUri(string ns)
		{
			return false;
		}

		public override bool IsNamespaceUri(XmlDictionaryString ns)
		{
			return false;
		}

		public override bool IsStartElement()
		{
			return false;
		}

		public override bool IsStartElement(string localName)
		{
			return false;
		}

		public override bool IsStartElement(string localName, string ns)
		{
			return false;
		}

		public override bool IsStartElement(XmlDictionaryString localName, XmlDictionaryString ns)
		{
			return false;
		}

		public override string LookupNamespace(string ns)
		{
			return _parentReader.LookupNamespace(ns);
		}

		public override void MoveToAttribute(int index)
		{
		}

		public override bool MoveToAttribute(string name)
		{
			return false;
		}

		public override bool MoveToAttribute(string name, string ns)
		{
			return false;
		}

		public override bool MoveToElement()
		{
			return false;
		}

		public override bool MoveToFirstAttribute()
		{
			return false;
		}

		public override bool MoveToNextAttribute()
		{
			return false;
		}

		public override bool ReadAttributeValue()
		{
			return false;
		}

		public override string ReadInnerXml()
		{
			return ReadContentAsString();
		}

		public override string ReadOuterXml()
		{
			return ReadContentAsString();
		}

		public override void ResolveEntity()
		{
		}

		public override void Skip()
		{
			Read();
		}

		bool IXmlLineInfo.HasLineInfo()
		{
			return ((IXmlLineInfo)_parentReader).HasLineInfo();
		}
	}

	private Encoding[] _encodings;

	private XmlDictionaryReader _xmlReader;

	private XmlDictionaryReader _infosetReader;

	private MimeReader _mimeReader;

	private Dictionary<string, MimePart> _mimeParts;

	private OnXmlDictionaryReaderClose _onClose;

	private bool _readingBinaryElement;

	private int _maxBufferSize;

	private int _bufferRemaining;

	private MimePart _part;

	public override XmlDictionaryReaderQuotas Quotas => _xmlReader.Quotas;

	public override int AttributeCount => _xmlReader.AttributeCount;

	public override string BaseURI => _xmlReader.BaseURI;

	public override bool CanReadBinaryContent => _xmlReader.CanReadBinaryContent;

	public override bool CanReadValueChunk => _xmlReader.CanReadValueChunk;

	public override bool CanResolveEntity => _xmlReader.CanResolveEntity;

	public override int Depth => _xmlReader.Depth;

	public override bool EOF => _xmlReader.EOF;

	public override bool HasAttributes => _xmlReader.HasAttributes;

	public override bool HasValue => _xmlReader.HasValue;

	public override bool IsDefault => _xmlReader.IsDefault;

	public override bool IsEmptyElement => _xmlReader.IsEmptyElement;

	public override string LocalName => _xmlReader.LocalName;

	public override string Name => _xmlReader.Name;

	public override string NamespaceURI => _xmlReader.NamespaceURI;

	public override XmlNameTable NameTable => _xmlReader.NameTable;

	public override XmlNodeType NodeType => _xmlReader.NodeType;

	public override string Prefix => _xmlReader.Prefix;

	public override char QuoteChar => _xmlReader.QuoteChar;

	public override ReadState ReadState
	{
		get
		{
			if (_xmlReader.ReadState != ReadState.Interactive && _infosetReader != null)
			{
				return _infosetReader.ReadState;
			}
			return _xmlReader.ReadState;
		}
	}

	public override XmlReaderSettings Settings => _xmlReader.Settings;

	public override string this[int index] => _xmlReader[index];

	public override string this[string name] => _xmlReader[name];

	public override string this[string name, string ns] => _xmlReader[name, ns];

	public override string Value => _xmlReader.Value;

	public override Type ValueType => _xmlReader.ValueType;

	public override string XmlLang => _xmlReader.XmlLang;

	public override XmlSpace XmlSpace => _xmlReader.XmlSpace;

	public int LineNumber
	{
		get
		{
			if (_xmlReader.ReadState == ReadState.Closed)
			{
				return 0;
			}
			if (!(_xmlReader is IXmlLineInfo xmlLineInfo))
			{
				return 0;
			}
			return xmlLineInfo.LineNumber;
		}
	}

	public int LinePosition
	{
		get
		{
			if (_xmlReader.ReadState == ReadState.Closed)
			{
				return 0;
			}
			if (!(_xmlReader is IXmlLineInfo xmlLineInfo))
			{
				return 0;
			}
			return xmlLineInfo.LinePosition;
		}
	}

	public static XmlDictionaryReader Create(Stream stream, Encoding encoding, XmlDictionaryReaderQuotas quotas)
	{
		if (encoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("encoding");
		}
		return Create(stream, new Encoding[1] { encoding }, quotas);
	}

	public static XmlDictionaryReader Create(Stream stream, Encoding[] encodings, XmlDictionaryReaderQuotas quotas)
	{
		return Create(stream, encodings, null, quotas);
	}

	public static XmlDictionaryReader Create(Stream stream, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas)
	{
		return Create(stream, encodings, contentType, quotas, int.MaxValue, null);
	}

	public static XmlDictionaryReader Create(Stream stream, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas, int maxBufferSize, OnXmlDictionaryReaderClose onClose)
	{
		XmlMtomReader xmlMtomReader = new XmlMtomReader();
		xmlMtomReader.SetInput(stream, encodings, contentType, quotas, maxBufferSize, onClose);
		return xmlMtomReader;
	}

	public static XmlDictionaryReader Create(byte[] buffer, int offset, int count, Encoding encoding, XmlDictionaryReaderQuotas quotas)
	{
		if (encoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("encoding");
		}
		return Create(buffer, offset, count, new Encoding[1] { encoding }, quotas);
	}

	public static XmlDictionaryReader Create(byte[] buffer, int offset, int count, Encoding[] encodings, XmlDictionaryReaderQuotas quotas)
	{
		return Create(buffer, offset, count, encodings, null, quotas);
	}

	public static XmlDictionaryReader Create(byte[] buffer, int offset, int count, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas)
	{
		return Create(buffer, offset, count, encodings, contentType, quotas, int.MaxValue, null);
	}

	public static XmlDictionaryReader Create(byte[] buffer, int offset, int count, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas, int maxBufferSize, OnXmlDictionaryReaderClose onClose)
	{
		XmlMtomReader xmlMtomReader = new XmlMtomReader();
		xmlMtomReader.SetInput(buffer, offset, count, encodings, contentType, quotas, maxBufferSize, onClose);
		return xmlMtomReader;
	}

	internal static void DecrementBufferQuota(int maxBuffer, ref int remaining, int size)
	{
		if (remaining - size <= 0)
		{
			remaining = 0;
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomBufferQuotaExceeded, maxBuffer)));
		}
		remaining -= size;
	}

	private void SetReadEncodings(Encoding[] encodings)
	{
		if (encodings == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("encodings");
		}
		for (int i = 0; i < encodings.Length; i++)
		{
			if (encodings[i] == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(string.Format(CultureInfo.InvariantCulture, "encodings[{0}]", i));
			}
		}
		_encodings = new Encoding[encodings.Length];
		encodings.CopyTo(_encodings, 0);
	}

	private void CheckContentType(string contentType)
	{
		if (contentType != null && contentType.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MtomContentTypeInvalid, "contentType"));
		}
	}

	public void SetInput(byte[] buffer, int offset, int count, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas, int maxBufferSize, OnXmlDictionaryReaderClose onClose)
	{
		SetInput(new MemoryStream(buffer, offset, count), encodings, contentType, quotas, maxBufferSize, onClose);
	}

	public void SetInput(Stream stream, Encoding[] encodings, string contentType, XmlDictionaryReaderQuotas quotas, int maxBufferSize, OnXmlDictionaryReaderClose onClose)
	{
		SetReadEncodings(encodings);
		CheckContentType(contentType);
		Initialize(stream, contentType, quotas, maxBufferSize);
		_onClose = onClose;
	}

	private void Initialize(Stream stream, string contentType, XmlDictionaryReaderQuotas quotas, int maxBufferSize)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		_maxBufferSize = maxBufferSize;
		_bufferRemaining = maxBufferSize;
		string boundary;
		string start;
		string startInfo;
		if (contentType == null)
		{
			MimeMessageReader mimeMessageReader = new MimeMessageReader(stream);
			MimeHeaders mimeHeaders = mimeMessageReader.ReadHeaders(_maxBufferSize, ref _bufferRemaining);
			ReadMessageMimeVersionHeader(mimeHeaders.MimeVersion);
			ReadMessageContentTypeHeader(mimeHeaders.ContentType, out boundary, out start, out startInfo);
			stream = mimeMessageReader.GetContentStream();
			if (stream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomMessageInvalidContent));
			}
		}
		else
		{
			ReadMessageContentTypeHeader(new ContentTypeHeader(contentType), out boundary, out start, out startInfo);
		}
		_mimeReader = new MimeReader(stream, boundary);
		_mimeParts = null;
		_readingBinaryElement = false;
		MimePart mimePart = ((start == null) ? ReadRootMimePart() : ReadMimePart(GetStartUri(start)));
		byte[] buffer = mimePart.GetBuffer(_maxBufferSize, ref _bufferRemaining);
		int count = (int)mimePart.Length;
		Encoding encoding = ReadRootContentTypeHeader(mimePart.Headers.ContentType, _encodings, startInfo);
		CheckContentTransferEncodingOnRoot(mimePart.Headers.ContentTransferEncoding);
		if (_xmlReader is IXmlTextReaderInitializer xmlTextReaderInitializer)
		{
			xmlTextReaderInitializer.SetInput(buffer, 0, count, encoding, quotas, null);
		}
		else
		{
			_xmlReader = XmlDictionaryReader.CreateTextReader(buffer, 0, count, encoding, quotas, null);
		}
	}

	private void ReadMessageMimeVersionHeader(MimeVersionHeader header)
	{
		if (header != null && header.Version != MimeVersionHeader.Default.Version)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomMessageInvalidMimeVersion, header.Version, MimeVersionHeader.Default.Version)));
		}
	}

	private void ReadMessageContentTypeHeader(ContentTypeHeader header, out string boundary, out string start, out string startInfo)
	{
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomMessageContentTypeNotFound));
		}
		if (string.Compare(MtomGlobals.MediaType, header.MediaType, StringComparison.OrdinalIgnoreCase) != 0 || string.Compare(MtomGlobals.MediaSubtype, header.MediaSubtype, StringComparison.OrdinalIgnoreCase) != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomMessageNotMultipart, MtomGlobals.MediaType, MtomGlobals.MediaSubtype)));
		}
		if (!header.Parameters.TryGetValue(MtomGlobals.TypeParam, out var value) || MtomGlobals.XopType != value)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomMessageNotApplicationXopXml, MtomGlobals.XopType)));
		}
		if (!header.Parameters.TryGetValue(MtomGlobals.BoundaryParam, out boundary))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomMessageRequiredParamNotSpecified, MtomGlobals.BoundaryParam)));
		}
		if (!MailBnfHelper.IsValidMimeBoundary(boundary))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomBoundaryInvalid, boundary)));
		}
		if (!header.Parameters.TryGetValue(MtomGlobals.StartParam, out start))
		{
			start = null;
		}
		if (!header.Parameters.TryGetValue(MtomGlobals.StartInfoParam, out startInfo))
		{
			startInfo = null;
		}
	}

	private Encoding ReadRootContentTypeHeader(ContentTypeHeader header, Encoding[] expectedEncodings, string expectedType)
	{
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomRootContentTypeNotFound));
		}
		if (string.Compare(MtomGlobals.XopMediaType, header.MediaType, StringComparison.OrdinalIgnoreCase) != 0 || string.Compare(MtomGlobals.XopMediaSubtype, header.MediaSubtype, StringComparison.OrdinalIgnoreCase) != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomRootNotApplicationXopXml, MtomGlobals.XopMediaType, MtomGlobals.XopMediaSubtype)));
		}
		if (!header.Parameters.TryGetValue(MtomGlobals.CharsetParam, out var value) || value == null || value.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomRootRequiredParamNotSpecified, MtomGlobals.CharsetParam)));
		}
		Encoding encoding = null;
		for (int i = 0; i < _encodings.Length; i++)
		{
			if (string.Compare(value, expectedEncodings[i].WebName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				encoding = expectedEncodings[i];
				break;
			}
		}
		if (encoding == null)
		{
			if (string.Compare(value, "utf-16LE", StringComparison.OrdinalIgnoreCase) == 0)
			{
				for (int j = 0; j < _encodings.Length; j++)
				{
					if (string.Compare(expectedEncodings[j].WebName, Encoding.Unicode.WebName, StringComparison.OrdinalIgnoreCase) == 0)
					{
						encoding = expectedEncodings[j];
						break;
					}
				}
			}
			else if (string.Compare(value, "utf-16BE", StringComparison.OrdinalIgnoreCase) == 0)
			{
				for (int k = 0; k < _encodings.Length; k++)
				{
					if (string.Compare(expectedEncodings[k].WebName, Encoding.BigEndianUnicode.WebName, StringComparison.OrdinalIgnoreCase) == 0)
					{
						encoding = expectedEncodings[k];
						break;
					}
				}
			}
			if (encoding == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int l = 0; l < _encodings.Length; l++)
				{
					if (stringBuilder.Length != 0)
					{
						stringBuilder.Append(" | ");
					}
					stringBuilder.Append(_encodings[l].WebName);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomRootUnexpectedCharset, value, stringBuilder.ToString())));
			}
		}
		if (expectedType != null)
		{
			if (!header.Parameters.TryGetValue(MtomGlobals.TypeParam, out var value2) || value2 == null || value2.Length == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomRootRequiredParamNotSpecified, MtomGlobals.TypeParam)));
			}
			if (value2 != expectedType)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomRootUnexpectedType, value2, expectedType)));
			}
		}
		return encoding;
	}

	private void CheckContentTransferEncodingOnRoot(ContentTransferEncodingHeader header)
	{
		if (header != null && header.ContentTransferEncoding == ContentTransferEncoding.Other)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomContentTransferEncodingNotSupported, header.Value, ContentTransferEncodingHeader.SevenBit.ContentTransferEncodingValue, ContentTransferEncodingHeader.EightBit.ContentTransferEncodingValue, ContentTransferEncodingHeader.Binary.ContentTransferEncodingValue)));
		}
	}

	private void CheckContentTransferEncodingOnBinaryPart(ContentTransferEncodingHeader header)
	{
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomContentTransferEncodingNotPresent, ContentTransferEncodingHeader.Binary.ContentTransferEncodingValue)));
		}
		if (header.ContentTransferEncoding != ContentTransferEncoding.Binary)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomInvalidTransferEncodingForMimePart, header.Value, ContentTransferEncodingHeader.Binary.ContentTransferEncodingValue)));
		}
	}

	private string GetStartUri(string startUri)
	{
		if (startUri.StartsWith("<", StringComparison.Ordinal))
		{
			if (startUri.EndsWith(">", StringComparison.Ordinal))
			{
				return startUri;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomInvalidStartUri, startUri)));
		}
		return string.Format(CultureInfo.InvariantCulture, "<{0}>", startUri);
	}

	public override bool Read()
	{
		bool flag = _xmlReader.Read();
		if (_xmlReader.NodeType == XmlNodeType.Element)
		{
			XopIncludeReader xopIncludeReader = null;
			if (_xmlReader.IsStartElement(MtomGlobals.XopIncludeLocalName, MtomGlobals.XopIncludeNamespace))
			{
				string text = null;
				while (_xmlReader.MoveToNextAttribute())
				{
					if (_xmlReader.LocalName == MtomGlobals.XopIncludeHrefLocalName && _xmlReader.NamespaceURI == MtomGlobals.XopIncludeHrefNamespace)
					{
						text = _xmlReader.Value;
					}
					else if (_xmlReader.NamespaceURI == MtomGlobals.XopIncludeNamespace)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomXopIncludeInvalidXopAttributes, _xmlReader.LocalName, MtomGlobals.XopIncludeNamespace)));
					}
				}
				if (text == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomXopIncludeHrefNotSpecified, MtomGlobals.XopIncludeHrefLocalName)));
				}
				MimePart mimePart = ReadMimePart(text);
				CheckContentTransferEncodingOnBinaryPart(mimePart.Headers.ContentTransferEncoding);
				_part = mimePart;
				xopIncludeReader = new XopIncludeReader(mimePart, _xmlReader);
				xopIncludeReader.Read();
				_xmlReader.MoveToElement();
				if (_xmlReader.IsEmptyElement)
				{
					_xmlReader.Read();
				}
				else
				{
					int depth = _xmlReader.Depth;
					_xmlReader.ReadStartElement();
					while (_xmlReader.Depth > depth)
					{
						if (_xmlReader.IsStartElement() && _xmlReader.NamespaceURI == MtomGlobals.XopIncludeNamespace)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomXopIncludeInvalidXopElement, _xmlReader.LocalName, MtomGlobals.XopIncludeNamespace)));
						}
						_xmlReader.Skip();
					}
					_xmlReader.ReadEndElement();
				}
			}
			if (xopIncludeReader != null)
			{
				_xmlReader.MoveToContent();
				_infosetReader = _xmlReader;
				_xmlReader = xopIncludeReader;
				xopIncludeReader = null;
			}
		}
		if (_xmlReader.ReadState == ReadState.EndOfFile && _infosetReader != null)
		{
			if (!flag)
			{
				flag = _infosetReader.Read();
			}
			_part.Release(_maxBufferSize, ref _bufferRemaining);
			_xmlReader = _infosetReader;
			_infosetReader = null;
		}
		return flag;
	}

	private MimePart ReadMimePart(string uri)
	{
		MimePart value = null;
		if (uri == null || uri.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomInvalidEmptyURI));
		}
		string text = null;
		if (uri.StartsWith(MimeGlobals.ContentIDScheme, StringComparison.Ordinal))
		{
			text = string.Format(CultureInfo.InvariantCulture, "<{0}>", Uri.UnescapeDataString(uri.Substring(MimeGlobals.ContentIDScheme.Length)));
		}
		else if (uri.StartsWith("<", StringComparison.Ordinal))
		{
			text = uri;
		}
		if (text == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomInvalidCIDUri, uri)));
		}
		if (_mimeParts != null && _mimeParts.TryGetValue(text, out value))
		{
			if (value.ReferencedFromInfoset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomMimePartReferencedMoreThanOnce, text)));
			}
		}
		else
		{
			int num = 1000;
			while (value == null && _mimeReader.ReadNextPart())
			{
				MimeHeaders mimeHeaders = _mimeReader.ReadHeaders(_maxBufferSize, ref _bufferRemaining);
				Stream contentStream = _mimeReader.GetContentStream();
				if (contentStream == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomMessageInvalidContentInMimePart));
				}
				ContentIDHeader contentIDHeader = mimeHeaders?.ContentID;
				if (contentIDHeader == null || contentIDHeader.Value == null)
				{
					int num2 = 256;
					byte[] buffer = new byte[num2];
					int num3 = 0;
					do
					{
						num3 = contentStream.Read(buffer, 0, num2);
					}
					while (num3 > 0);
					continue;
				}
				string value2 = mimeHeaders.ContentID.Value;
				MimePart mimePart = new MimePart(contentStream, mimeHeaders);
				if (_mimeParts == null)
				{
					_mimeParts = new Dictionary<string, MimePart>();
				}
				_mimeParts.Add(value2, mimePart);
				if (_mimeParts.Count > num)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MaxMimePartsExceeded, num, "MtomMessageEncoderBindingElement")));
				}
				if (value2.Equals(text))
				{
					value = mimePart;
				}
				else
				{
					mimePart.GetBuffer(_maxBufferSize, ref _bufferRemaining);
				}
			}
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomPartNotFound, uri)));
			}
		}
		value.ReferencedFromInfoset = true;
		return value;
	}

	private MimePart ReadRootMimePart()
	{
		MimePart mimePart = null;
		if (!_mimeReader.ReadNextPart())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomRootPartNotFound));
		}
		MimeHeaders headers = _mimeReader.ReadHeaders(_maxBufferSize, ref _bufferRemaining);
		Stream contentStream = _mimeReader.GetContentStream();
		if (contentStream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.MtomMessageInvalidContentInMimePart));
		}
		return new MimePart(contentStream, headers);
	}

	private void AdvanceToContentOnElement()
	{
		if (NodeType != XmlNodeType.Attribute)
		{
			MoveToContent();
		}
	}

	public override void Close()
	{
		_xmlReader.Close();
		_mimeReader.Close();
		OnXmlDictionaryReaderClose onClose = _onClose;
		_onClose = null;
		if (onClose == null)
		{
			return;
		}
		try
		{
			onClose(this);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	public override string GetAttribute(int index)
	{
		return _xmlReader.GetAttribute(index);
	}

	public override string GetAttribute(string name)
	{
		return _xmlReader.GetAttribute(name);
	}

	public override string GetAttribute(string name, string ns)
	{
		return _xmlReader.GetAttribute(name, ns);
	}

	public override string GetAttribute(XmlDictionaryString localName, XmlDictionaryString ns)
	{
		return _xmlReader.GetAttribute(localName, ns);
	}

	public override bool IsLocalName(string localName)
	{
		return _xmlReader.IsLocalName(localName);
	}

	public override bool IsLocalName(XmlDictionaryString localName)
	{
		return _xmlReader.IsLocalName(localName);
	}

	public override bool IsNamespaceUri(string ns)
	{
		return _xmlReader.IsNamespaceUri(ns);
	}

	public override bool IsNamespaceUri(XmlDictionaryString ns)
	{
		return _xmlReader.IsNamespaceUri(ns);
	}

	public override bool IsStartElement()
	{
		return _xmlReader.IsStartElement();
	}

	public override bool IsStartElement(string localName)
	{
		return _xmlReader.IsStartElement(localName);
	}

	public override bool IsStartElement(string localName, string ns)
	{
		return _xmlReader.IsStartElement(localName, ns);
	}

	public override bool IsStartElement(XmlDictionaryString localName, XmlDictionaryString ns)
	{
		return _xmlReader.IsStartElement(localName, ns);
	}

	public override string LookupNamespace(string ns)
	{
		return _xmlReader.LookupNamespace(ns);
	}

	public override void MoveToAttribute(int index)
	{
		_xmlReader.MoveToAttribute(index);
	}

	public override bool MoveToAttribute(string name)
	{
		return _xmlReader.MoveToAttribute(name);
	}

	public override bool MoveToAttribute(string name, string ns)
	{
		return _xmlReader.MoveToAttribute(name, ns);
	}

	public override bool MoveToElement()
	{
		return _xmlReader.MoveToElement();
	}

	public override bool MoveToFirstAttribute()
	{
		return _xmlReader.MoveToFirstAttribute();
	}

	public override bool MoveToNextAttribute()
	{
		return _xmlReader.MoveToNextAttribute();
	}

	public override bool ReadAttributeValue()
	{
		return _xmlReader.ReadAttributeValue();
	}

	public override object ReadContentAs(Type returnType, IXmlNamespaceResolver namespaceResolver)
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAs(returnType, namespaceResolver);
	}

	public override byte[] ReadContentAsBase64()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsBase64();
	}

	public override int ReadValueAsBase64(byte[] buffer, int offset, int count)
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadValueAsBase64(buffer, offset, count);
	}

	public override int ReadContentAsBase64(byte[] buffer, int offset, int count)
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsBase64(buffer, offset, count);
	}

	public override int ReadElementContentAsBase64(byte[] buffer, int offset, int count)
	{
		if (!_readingBinaryElement)
		{
			if (IsEmptyElement)
			{
				Read();
				return 0;
			}
			ReadStartElement();
			_readingBinaryElement = true;
		}
		int num = ReadContentAsBase64(buffer, offset, count);
		if (num == 0)
		{
			ReadEndElement();
			_readingBinaryElement = false;
		}
		return num;
	}

	public override int ReadElementContentAsBinHex(byte[] buffer, int offset, int count)
	{
		if (!_readingBinaryElement)
		{
			if (IsEmptyElement)
			{
				Read();
				return 0;
			}
			ReadStartElement();
			_readingBinaryElement = true;
		}
		int num = ReadContentAsBinHex(buffer, offset, count);
		if (num == 0)
		{
			ReadEndElement();
			_readingBinaryElement = false;
		}
		return num;
	}

	public override int ReadContentAsBinHex(byte[] buffer, int offset, int count)
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsBinHex(buffer, offset, count);
	}

	public override bool ReadContentAsBoolean()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsBoolean();
	}

	public override int ReadContentAsChars(char[] chars, int index, int count)
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsChars(chars, index, count);
	}

	public override DateTime ReadContentAsDateTime()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsDateTime();
	}

	public override decimal ReadContentAsDecimal()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsDecimal();
	}

	public override double ReadContentAsDouble()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsDouble();
	}

	public override int ReadContentAsInt()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsInt();
	}

	public override long ReadContentAsLong()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsLong();
	}

	public override object ReadContentAsObject()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsObject();
	}

	public override float ReadContentAsFloat()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsFloat();
	}

	public override string ReadContentAsString()
	{
		AdvanceToContentOnElement();
		return _xmlReader.ReadContentAsString();
	}

	public override string ReadInnerXml()
	{
		return _xmlReader.ReadInnerXml();
	}

	public override string ReadOuterXml()
	{
		return _xmlReader.ReadOuterXml();
	}

	public override int ReadValueChunk(char[] buffer, int index, int count)
	{
		return _xmlReader.ReadValueChunk(buffer, index, count);
	}

	public override void ResolveEntity()
	{
		_xmlReader.ResolveEntity();
	}

	public override void Skip()
	{
		_xmlReader.Skip();
	}

	public bool HasLineInfo()
	{
		if (_xmlReader.ReadState == ReadState.Closed)
		{
			return false;
		}
		if (!(_xmlReader is IXmlLineInfo xmlLineInfo))
		{
			return false;
		}
		return xmlLineInfo.HasLineInfo();
	}
}

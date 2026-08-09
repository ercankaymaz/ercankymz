using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace System.Xml;

internal class XmlMtomWriter : XmlDictionaryWriter, IXmlMtomWriterInitializer
{
	private static class MimeBoundaryGenerator
	{
		private static long id;

		private static string prefix;

		static MimeBoundaryGenerator()
		{
			prefix = Guid.NewGuid().ToString() + "+id=";
		}

		internal static string Next()
		{
			long num = Interlocked.Increment(ref id);
			return string.Format(CultureInfo.InvariantCulture, "{0}{1}", prefix, num);
		}
	}

	private class MimePart
	{
		internal IList<MtomBinaryData> binaryData;

		internal string contentID;

		internal string contentType;

		internal string contentTransferEncoding;

		internal int sizeInBytes;

		internal MimePart(IList<MtomBinaryData> binaryData, string contentID, string contentType, string contentTransferEncoding, int sizeOfBufferedBinaryData, int maxSizeInBytes)
		{
			this.binaryData = binaryData;
			this.contentID = contentID;
			this.contentType = contentType ?? MtomGlobals.DefaultContentTypeForBinary;
			this.contentTransferEncoding = contentTransferEncoding;
			sizeInBytes = GetSize(contentID, contentType, contentTransferEncoding, sizeOfBufferedBinaryData, maxSizeInBytes);
		}

		private static int GetSize(string contentID, string contentType, string contentTransferEncoding, int sizeOfBufferedBinaryData, int maxSizeInBytes)
		{
			int num = ValidateSizeOfMessage(maxSizeInBytes, 0, MimeGlobals.CRLF.Length * 3);
			if (contentTransferEncoding != null)
			{
				num += ValidateSizeOfMessage(maxSizeInBytes, num, MimeWriter.GetHeaderSize(MimeGlobals.ContentTransferEncodingHeader, contentTransferEncoding, maxSizeInBytes));
			}
			if (contentType != null)
			{
				num += ValidateSizeOfMessage(maxSizeInBytes, num, MimeWriter.GetHeaderSize(MimeGlobals.ContentTypeHeader, contentType, maxSizeInBytes));
			}
			if (contentID != null)
			{
				num += ValidateSizeOfMessage(maxSizeInBytes, num, MimeWriter.GetHeaderSize(MimeGlobals.ContentIDHeader, contentID, maxSizeInBytes));
				num += ValidateSizeOfMessage(maxSizeInBytes, num, 2);
			}
			return num + ValidateSizeOfMessage(maxSizeInBytes, num, sizeOfBufferedBinaryData);
		}
	}

	private const int MaxInlinedBytes = 767;

	private int _maxSizeInBytes;

	private XmlDictionaryWriter _writer;

	private XmlDictionaryWriter _infosetWriter;

	private MimeWriter _mimeWriter;

	private Encoding _encoding;

	private bool _isUTF8;

	private string _contentID;

	private string _contentType;

	private string _initialContentTypeForRootPart;

	private string _initialContentTypeForMimeMessage;

	private MemoryStream _contentTypeStream;

	private List<MimePart> _mimeParts;

	private IList<MtomBinaryData> _binaryDataChunks;

	private int _depth;

	private int _totalSizeOfMimeParts;

	private int _sizeOfBufferedBinaryData;

	private char[] _chars;

	private byte[] _bytes;

	private bool _isClosed;

	private bool _ownsStream;

	private XmlDictionaryWriter Writer
	{
		get
		{
			if (!IsInitialized)
			{
				Initialize();
			}
			return _writer;
		}
	}

	private bool IsInitialized => _initialContentTypeForRootPart == null;

	public override XmlWriterSettings Settings => Writer.Settings;

	public override WriteState WriteState => Writer.WriteState;

	public override string XmlLang => Writer.XmlLang;

	public override XmlSpace XmlSpace => Writer.XmlSpace;

	public static XmlDictionaryWriter Create(Stream stream, Encoding encoding, int maxSizeInBytes, string startInfo)
	{
		return Create(stream, encoding, maxSizeInBytes, startInfo, null, null, writeMessageHeaders: true, ownsStream: true);
	}

	public static XmlDictionaryWriter Create(Stream stream, Encoding encoding, int maxSizeInBytes, string startInfo, string boundary, string startUri, bool writeMessageHeaders, bool ownsStream)
	{
		XmlMtomWriter xmlMtomWriter = new XmlMtomWriter();
		xmlMtomWriter.SetOutput(stream, encoding, maxSizeInBytes, startInfo, boundary, startUri, writeMessageHeaders, ownsStream);
		return xmlMtomWriter;
	}

	public void SetOutput(Stream stream, Encoding encoding, int maxSizeInBytes, string startInfo, string boundary, string startUri, bool writeMessageHeaders, bool ownsStream)
	{
		if (encoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("encoding");
		}
		if (maxSizeInBytes < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxSizeInBytes", System.SR.ValueMustBeNonNegative));
		}
		_maxSizeInBytes = maxSizeInBytes;
		_encoding = encoding;
		_isUTF8 = IsUTF8Encoding(encoding);
		Initialize(stream, startInfo, boundary, startUri, writeMessageHeaders, ownsStream);
	}

	private void Initialize(Stream stream, string startInfo, string boundary, string startUri, bool writeMessageHeaders, bool ownsStream)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		if (startInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("startInfo");
		}
		if (boundary == null)
		{
			boundary = GetBoundaryString();
		}
		if (startUri == null)
		{
			startUri = GenerateUriForMimePart(0);
		}
		if (!MailBnfHelper.IsValidMimeBoundary(boundary))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MtomBoundaryInvalid, boundary), "boundary"));
		}
		_ownsStream = ownsStream;
		_isClosed = false;
		_depth = 0;
		_totalSizeOfMimeParts = 0;
		_sizeOfBufferedBinaryData = 0;
		_binaryDataChunks = null;
		_contentType = null;
		_contentTypeStream = null;
		_contentID = startUri;
		if (_mimeParts != null)
		{
			_mimeParts.Clear();
		}
		_mimeWriter = new MimeWriter(stream, boundary);
		_initialContentTypeForRootPart = GetContentTypeForRootMimePart(_encoding, startInfo);
		if (writeMessageHeaders)
		{
			_initialContentTypeForMimeMessage = GetContentTypeForMimeMessage(boundary, startUri, startInfo);
		}
	}

	private void Initialize()
	{
		if (_isClosed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.XmlWriterClosed));
		}
		if (_initialContentTypeForRootPart != null)
		{
			if (_initialContentTypeForMimeMessage != null)
			{
				_mimeWriter.StartPreface();
				_mimeWriter.WriteHeader(MimeGlobals.MimeVersionHeader, MimeGlobals.DefaultVersion);
				_mimeWriter.WriteHeader(MimeGlobals.ContentTypeHeader, _initialContentTypeForMimeMessage);
				_initialContentTypeForMimeMessage = null;
			}
			WriteMimeHeaders(_contentID, _initialContentTypeForRootPart, _isUTF8 ? MimeGlobals.Encoding8bit : MimeGlobals.EncodingBinary);
			Stream contentStream = _mimeWriter.GetContentStream();
			if (!(_writer is IXmlTextWriterInitializer xmlTextWriterInitializer))
			{
				_writer = XmlDictionaryWriter.CreateTextWriter(contentStream, _encoding, _ownsStream);
			}
			else
			{
				xmlTextWriterInitializer.SetOutput(contentStream, _encoding, _ownsStream);
			}
			_contentID = null;
			_initialContentTypeForRootPart = null;
		}
	}

	private static string GetBoundaryString()
	{
		return MimeBoundaryGenerator.Next();
	}

	internal static bool IsUTF8Encoding(Encoding encoding)
	{
		return encoding.WebName == "utf-8";
	}

	private static string GetContentTypeForMimeMessage(string boundary, string startUri, string startInfo)
	{
		StringBuilder stringBuilder = new StringBuilder(string.Format(CultureInfo.InvariantCulture, "{0}/{1};{2}=\"{3}\";{4}=\"{5}\"", MtomGlobals.MediaType, MtomGlobals.MediaSubtype, MtomGlobals.TypeParam, MtomGlobals.XopType, MtomGlobals.BoundaryParam, boundary));
		if (startUri != null && startUri.Length > 0)
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, ";{0}=\"<{1}>\"", MtomGlobals.StartParam, startUri);
		}
		if (startInfo != null && startInfo.Length > 0)
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, ";{0}=\"{1}\"", MtomGlobals.StartInfoParam, startInfo);
		}
		return stringBuilder.ToString();
	}

	private static string GetContentTypeForRootMimePart(Encoding encoding, string startInfo)
	{
		string text = string.Format(CultureInfo.InvariantCulture, "{0};{1}={2}", MtomGlobals.XopType, MtomGlobals.CharsetParam, CharSet(encoding));
		if (startInfo != null)
		{
			text = string.Format(CultureInfo.InvariantCulture, "{0};{1}=\"{2}\"", text, MtomGlobals.TypeParam, startInfo);
		}
		return text;
	}

	private static string CharSet(Encoding enc)
	{
		string webName = enc.WebName;
		if (string.Compare(webName, Encoding.UTF8.WebName, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return webName;
		}
		if (string.Compare(webName, Encoding.Unicode.WebName, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return "utf-16LE";
		}
		if (string.Compare(webName, Encoding.BigEndianUnicode.WebName, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return "utf-16BE";
		}
		return webName;
	}

	public override void WriteStartElement(string prefix, string localName, string ns)
	{
		WriteBase64InlineIfPresent();
		ThrowIfElementIsXOPInclude(prefix, localName, ns);
		Writer.WriteStartElement(prefix, localName, ns);
		_depth++;
	}

	public override async Task WriteStartElementAsync(string prefix, string localName, string ns)
	{
		await WriteBase64InlineIfPresentAsync();
		ThrowIfElementIsXOPInclude(prefix, localName, ns);
		await Writer.WriteStartElementAsync(prefix, localName, ns);
		_depth++;
	}

	public override void WriteStartElement(string prefix, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		WriteBase64InlineIfPresent();
		ThrowIfElementIsXOPInclude(prefix, localName.Value, ns?.Value);
		Writer.WriteStartElement(prefix, localName, ns);
		_depth++;
	}

	private void ThrowIfElementIsXOPInclude(string prefix, string localName, string ns)
	{
		if (ns == null)
		{
			string text = Writer.LookupPrefix(MtomGlobals.XopIncludeNamespace);
			if (text != null && text == prefix)
			{
				ns = MtomGlobals.XopIncludeNamespace;
			}
		}
		if (localName == MtomGlobals.XopIncludeLocalName && ns == MtomGlobals.XopIncludeNamespace)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomDataMustNotContainXopInclude, MtomGlobals.XopIncludeLocalName, MtomGlobals.XopIncludeNamespace)));
		}
	}

	public override void WriteEndElement()
	{
		WriteXOPInclude();
		Writer.WriteEndElement();
		_depth--;
		WriteXOPBinaryParts();
	}

	public override async Task WriteEndElementAsync()
	{
		await WriteXOPIncludeAsync();
		await Writer.WriteEndElementAsync();
		_depth--;
		await WriteXOPBinaryPartsAsync();
	}

	public override void WriteFullEndElement()
	{
		WriteXOPInclude();
		Writer.WriteFullEndElement();
		_depth--;
		WriteXOPBinaryParts();
	}

	public override void WriteValue(IStreamProvider value)
	{
		if (value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
		if (Writer.WriteState == WriteState.Element)
		{
			if (_binaryDataChunks == null)
			{
				_binaryDataChunks = new List<MtomBinaryData>();
				_contentID = GenerateUriForMimePart((_mimeParts == null) ? 1 : (_mimeParts.Count + 1));
			}
			_binaryDataChunks.Add(new MtomBinaryData(value));
		}
		else
		{
			Writer.WriteValue(value);
		}
	}

	public override void WriteBase64(byte[] buffer, int index, int count)
	{
		if (Writer.WriteState == WriteState.Element)
		{
			if (buffer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("buffer"));
			}
			if (index < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", System.SR.ValueMustBeNonNegative));
			}
			if (count < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
			}
			if (count > buffer.Length - index)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, buffer.Length - index)));
			}
			if (_binaryDataChunks == null)
			{
				_binaryDataChunks = new List<MtomBinaryData>();
				_contentID = GenerateUriForMimePart((_mimeParts == null) ? 1 : (_mimeParts.Count + 1));
			}
			int num = ValidateSizeOfMessage(_maxSizeInBytes, 0, _totalSizeOfMimeParts);
			num += ValidateSizeOfMessage(_maxSizeInBytes, num, _sizeOfBufferedBinaryData);
			num += ValidateSizeOfMessage(_maxSizeInBytes, num, count);
			_sizeOfBufferedBinaryData += count;
			_binaryDataChunks.Add(new MtomBinaryData(buffer, index, count));
		}
		else
		{
			Writer.WriteBase64(buffer, index, count);
		}
	}

	internal static int ValidateSizeOfMessage(int maxSize, int offset, int size)
	{
		if (size > maxSize - offset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.MtomExceededMaxSizeInBytes, maxSize)));
		}
		return size;
	}

	private void WriteBase64InlineIfPresent()
	{
		if (_binaryDataChunks != null)
		{
			WriteBase64Inline();
		}
	}

	private Task WriteBase64InlineIfPresentAsync()
	{
		if (_binaryDataChunks != null)
		{
			return WriteBase64InlineAsync();
		}
		return Task.CompletedTask;
	}

	private void WriteBase64Inline()
	{
		foreach (MtomBinaryData binaryDataChunk in _binaryDataChunks)
		{
			if (binaryDataChunk.type == MtomBinaryDataType.Provider)
			{
				Writer.WriteValue(binaryDataChunk.provider);
			}
			else
			{
				Writer.WriteBase64(binaryDataChunk.chunk, 0, binaryDataChunk.chunk.Length);
			}
		}
		_sizeOfBufferedBinaryData = 0;
		_binaryDataChunks = null;
		_contentType = null;
		_contentID = null;
	}

	private async Task WriteBase64InlineAsync()
	{
		foreach (MtomBinaryData binaryDataChunk in _binaryDataChunks)
		{
			if (binaryDataChunk.type == MtomBinaryDataType.Provider)
			{
				await Writer.WriteValueAsync(binaryDataChunk.provider);
			}
			else
			{
				await Writer.WriteBase64Async(binaryDataChunk.chunk, 0, binaryDataChunk.chunk.Length);
			}
		}
		_sizeOfBufferedBinaryData = 0;
		_binaryDataChunks = null;
		_contentType = null;
		_contentID = null;
	}

	private void WriteXOPInclude()
	{
		if (_binaryDataChunks == null)
		{
			return;
		}
		bool flag = true;
		long num = 0L;
		foreach (MtomBinaryData binaryDataChunk in _binaryDataChunks)
		{
			long length = binaryDataChunk.Length;
			if (length < 0 || length > 767 - num)
			{
				flag = false;
				break;
			}
			num += length;
		}
		if (flag)
		{
			WriteBase64Inline();
			return;
		}
		if (_mimeParts == null)
		{
			_mimeParts = new List<MimePart>();
		}
		MimePart mimePart = new MimePart(_binaryDataChunks, _contentID, _contentType, MimeGlobals.EncodingBinary, _sizeOfBufferedBinaryData, _maxSizeInBytes);
		_mimeParts.Add(mimePart);
		_totalSizeOfMimeParts += ValidateSizeOfMessage(_maxSizeInBytes, _totalSizeOfMimeParts, mimePart.sizeInBytes);
		_totalSizeOfMimeParts += ValidateSizeOfMessage(_maxSizeInBytes, _totalSizeOfMimeParts, _mimeWriter.GetBoundarySize());
		Writer.WriteStartElement(MtomGlobals.XopIncludePrefix, MtomGlobals.XopIncludeLocalName, MtomGlobals.XopIncludeNamespace);
		Writer.WriteStartAttribute(MtomGlobals.XopIncludeHrefLocalName, MtomGlobals.XopIncludeHrefNamespace);
		Writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0}{1}", MimeGlobals.ContentIDScheme, _contentID));
		Writer.WriteEndAttribute();
		Writer.WriteEndElement();
		_binaryDataChunks = null;
		_sizeOfBufferedBinaryData = 0;
		_contentType = null;
		_contentID = null;
	}

	private async Task WriteXOPIncludeAsync()
	{
		if (_binaryDataChunks == null)
		{
			return;
		}
		bool flag = true;
		long num = 0L;
		foreach (MtomBinaryData binaryDataChunk in _binaryDataChunks)
		{
			long length = binaryDataChunk.Length;
			if (length < 0 || length > 767 - num)
			{
				flag = false;
				break;
			}
			num += length;
		}
		if (flag)
		{
			await WriteBase64InlineAsync();
			return;
		}
		if (_mimeParts == null)
		{
			_mimeParts = new List<MimePart>();
		}
		MimePart mimePart = new MimePart(_binaryDataChunks, _contentID, _contentType, MimeGlobals.EncodingBinary, _sizeOfBufferedBinaryData, _maxSizeInBytes);
		_mimeParts.Add(mimePart);
		_totalSizeOfMimeParts += ValidateSizeOfMessage(_maxSizeInBytes, _totalSizeOfMimeParts, mimePart.sizeInBytes);
		_totalSizeOfMimeParts += ValidateSizeOfMessage(_maxSizeInBytes, _totalSizeOfMimeParts, _mimeWriter.GetBoundarySize());
		await Writer.WriteStartElementAsync(MtomGlobals.XopIncludePrefix, MtomGlobals.XopIncludeLocalName, MtomGlobals.XopIncludeNamespace);
		Writer.WriteStartAttribute(MtomGlobals.XopIncludeHrefLocalName, MtomGlobals.XopIncludeHrefNamespace);
		Writer.WriteString(string.Format(CultureInfo.InvariantCulture, "{0}{1}", MimeGlobals.ContentIDScheme, _contentID));
		Writer.WriteEndAttribute();
		await Writer.WriteEndElementAsync();
		_binaryDataChunks = null;
		_sizeOfBufferedBinaryData = 0;
		_contentType = null;
		_contentID = null;
	}

	public static string GenerateUriForMimePart(int index)
	{
		return string.Format(CultureInfo.InvariantCulture, "http://tempuri.org/{0}/{1}", index, DateTime.Now.Ticks);
	}

	private void WriteXOPBinaryParts()
	{
		if (_depth > 0 || _mimeWriter.WriteState == MimeWriterState.Closed)
		{
			return;
		}
		if (Writer.WriteState != WriteState.Closed)
		{
			Writer.Flush();
		}
		if (_mimeParts != null)
		{
			foreach (MimePart mimePart in _mimeParts)
			{
				WriteMimeHeaders(mimePart.contentID, mimePart.contentType, mimePart.contentTransferEncoding);
				Stream contentStream = _mimeWriter.GetContentStream();
				int num = 256;
				int num2 = 0;
				byte[] buffer = new byte[num];
				Stream stream = null;
				foreach (MtomBinaryData binaryDatum in mimePart.binaryData)
				{
					if (binaryDatum.type == MtomBinaryDataType.Provider)
					{
						stream = binaryDatum.provider.GetStream();
						if (stream == null)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.XmlInvalidStream));
						}
						while (true)
						{
							num2 = stream.Read(buffer, 0, num);
							if (num2 <= 0)
							{
								break;
							}
							contentStream.Write(buffer, 0, num2);
							if (num < 65536 && num2 == num)
							{
								num *= 16;
								buffer = new byte[num];
							}
						}
						binaryDatum.provider.ReleaseStream(stream);
					}
					else
					{
						contentStream.Write(binaryDatum.chunk, 0, binaryDatum.chunk.Length);
					}
				}
			}
			_mimeParts.Clear();
		}
		_mimeWriter.Close();
	}

	private async Task WriteXOPBinaryPartsAsync()
	{
		if (_depth > 0 || _mimeWriter.WriteState == MimeWriterState.Closed)
		{
			return;
		}
		if (Writer.WriteState != WriteState.Closed)
		{
			await Writer.FlushAsync();
		}
		if (_mimeParts != null)
		{
			foreach (MimePart part in _mimeParts)
			{
				await WriteMimeHeadersAsync(part.contentID, part.contentType, part.contentTransferEncoding);
				Stream stream = await _mimeWriter.GetContentStreamAsync();
				int num = 256;
				byte[] buffer = new byte[num];
				foreach (MtomBinaryData binaryDatum in part.binaryData)
				{
					if (binaryDatum.type == MtomBinaryDataType.Provider)
					{
						Stream stream2 = binaryDatum.provider.GetStream();
						if (stream2 == null)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.XmlInvalidStream));
						}
						while (true)
						{
							int num2 = stream2.Read(buffer, 0, num);
							if (num2 <= 0)
							{
								break;
							}
							stream.Write(buffer, 0, num2);
							if (num < 65536 && num2 == num)
							{
								num *= 16;
								buffer = new byte[num];
							}
						}
						binaryDatum.provider.ReleaseStream(stream2);
					}
					else
					{
						stream.Write(binaryDatum.chunk, 0, binaryDatum.chunk.Length);
					}
				}
			}
			_mimeParts.Clear();
		}
		await _mimeWriter.CloseAsync();
	}

	private void WriteMimeHeaders(string contentID, string contentType, string contentTransferEncoding)
	{
		_mimeWriter.StartPart();
		if (contentID != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentIDHeader, string.Format(CultureInfo.InvariantCulture, "<{0}>", contentID));
		}
		if (contentTransferEncoding != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentTransferEncodingHeader, contentTransferEncoding);
		}
		if (contentType != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentTypeHeader, contentType);
		}
	}

	private async Task WriteMimeHeadersAsync(string contentID, string contentType, string contentTransferEncoding)
	{
		await _mimeWriter.StartPartAsync();
		if (contentID != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentIDHeader, string.Format(CultureInfo.InvariantCulture, "<{0}>", contentID));
		}
		if (contentTransferEncoding != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentTransferEncodingHeader, contentTransferEncoding);
		}
		if (contentType != null)
		{
			_mimeWriter.WriteHeader(MimeGlobals.ContentTypeHeader, contentType);
		}
	}

	public override void Close()
	{
		if (_isClosed)
		{
			return;
		}
		_isClosed = true;
		if (IsInitialized)
		{
			WriteXOPInclude();
			if (Writer.WriteState == WriteState.Element || Writer.WriteState == WriteState.Attribute || Writer.WriteState == WriteState.Content)
			{
				Writer.WriteEndDocument();
			}
			Writer.Flush();
			_depth = 0;
			WriteXOPBinaryParts();
			Writer.Close();
		}
	}

	private void CheckIfStartContentTypeAttribute(string localName, string ns)
	{
		if (localName != null && localName == MtomGlobals.MimeContentTypeLocalName && ns != null && (ns == MtomGlobals.MimeContentTypeNamespace200406 || ns == MtomGlobals.MimeContentTypeNamespace200505))
		{
			_contentTypeStream = new MemoryStream();
			_infosetWriter = Writer;
			_writer = XmlDictionaryWriter.CreateBinaryWriter(_contentTypeStream);
			Writer.WriteStartElement("Wrapper");
			Writer.WriteStartAttribute(localName, ns);
		}
	}

	private void CheckIfEndContentTypeAttribute()
	{
		if (_contentTypeStream == null)
		{
			return;
		}
		Writer.WriteEndAttribute();
		Writer.WriteEndElement();
		Writer.Flush();
		_contentTypeStream.Position = 0L;
		XmlReader xmlReader = XmlDictionaryReader.CreateBinaryReader(_contentTypeStream, null, XmlDictionaryReaderQuotas.Max, null, null);
		while (xmlReader.Read())
		{
			if (xmlReader.IsStartElement("Wrapper"))
			{
				_contentType = xmlReader.GetAttribute(MtomGlobals.MimeContentTypeLocalName, MtomGlobals.MimeContentTypeNamespace200406);
				if (_contentType == null)
				{
					_contentType = xmlReader.GetAttribute(MtomGlobals.MimeContentTypeLocalName, MtomGlobals.MimeContentTypeNamespace200505);
				}
				break;
			}
		}
		_writer = _infosetWriter;
		_infosetWriter = null;
		_contentTypeStream = null;
		if (_contentType != null)
		{
			Writer.WriteString(_contentType);
		}
	}

	public override void Flush()
	{
		if (IsInitialized)
		{
			Writer.Flush();
		}
	}

	public override Task FlushAsync()
	{
		if (IsInitialized)
		{
			return Writer.FlushAsync();
		}
		return Task.CompletedTask;
	}

	public override string LookupPrefix(string ns)
	{
		return Writer.LookupPrefix(ns);
	}

	public override void WriteAttributes(XmlReader reader, bool defattr)
	{
		Writer.WriteAttributes(reader, defattr);
	}

	public override void WriteBinHex(byte[] buffer, int index, int count)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteBinHex(buffer, index, count);
	}

	public override void WriteCData(string text)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteCData(text);
	}

	public override void WriteCharEntity(char ch)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteCharEntity(ch);
	}

	public override void WriteChars(char[] buffer, int index, int count)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteChars(buffer, index, count);
	}

	public override void WriteComment(string text)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed)
		{
			WriteBase64InlineIfPresent();
			Writer.WriteComment(text);
		}
	}

	public override void WriteDocType(string name, string pubid, string sysid, string subset)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteDocType(name, pubid, sysid, subset);
	}

	public override void WriteEndAttribute()
	{
		CheckIfEndContentTypeAttribute();
		Writer.WriteEndAttribute();
	}

	public override void WriteEndDocument()
	{
		WriteXOPInclude();
		Writer.WriteEndDocument();
		_depth = 0;
		WriteXOPBinaryParts();
	}

	public override void WriteEntityRef(string name)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteEntityRef(name);
	}

	public override void WriteName(string name)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteName(name);
	}

	public override void WriteNmToken(string name)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteNmToken(name);
	}

	protected override void WriteTextNode(XmlDictionaryReader reader, bool attribute)
	{
		Type valueType = reader.ValueType;
		if (valueType == typeof(string))
		{
			if (reader.CanReadValueChunk)
			{
				if (_chars == null)
				{
					_chars = new char[256];
				}
				int count;
				while ((count = reader.ReadValueChunk(_chars, 0, _chars.Length)) > 0)
				{
					WriteChars(_chars, 0, count);
				}
			}
			else
			{
				WriteString(reader.Value);
			}
			if (!attribute)
			{
				reader.Read();
			}
		}
		else if (valueType == typeof(byte[]))
		{
			if (reader.CanReadBinaryContent)
			{
				if (_bytes == null)
				{
					_bytes = new byte[384];
				}
				int count2;
				while ((count2 = reader.ReadValueAsBase64(_bytes, 0, _bytes.Length)) > 0)
				{
					WriteBase64(_bytes, 0, count2);
				}
			}
			else
			{
				WriteString(reader.Value);
			}
			if (!attribute)
			{
				reader.Read();
			}
		}
		else
		{
			base.WriteTextNode(reader, attribute);
		}
	}

	public override void WriteNode(XPathNavigator navigator, bool defattr)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteNode(navigator, defattr);
	}

	public override void WriteProcessingInstruction(string name, string text)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteProcessingInstruction(name, text);
	}

	public override void WriteQualifiedName(string localName, string namespaceUri)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteQualifiedName(localName, namespaceUri);
	}

	public override void WriteRaw(char[] buffer, int index, int count)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteRaw(buffer, index, count);
	}

	public override void WriteRaw(string data)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteRaw(data);
	}

	public override void WriteStartAttribute(string prefix, string localName, string ns)
	{
		Writer.WriteStartAttribute(prefix, localName, ns);
		CheckIfStartContentTypeAttribute(localName, ns);
	}

	public override void WriteStartAttribute(string prefix, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		Writer.WriteStartAttribute(prefix, localName, ns);
		if (localName != null && ns != null)
		{
			CheckIfStartContentTypeAttribute(localName.Value, ns.Value);
		}
	}

	public override void WriteStartDocument()
	{
		Writer.WriteStartDocument();
	}

	public override void WriteStartDocument(bool standalone)
	{
		Writer.WriteStartDocument(standalone);
	}

	public override void WriteString(string text)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed || !System.Xml.XmlConverter.IsWhitespace(text))
		{
			WriteBase64InlineIfPresent();
			Writer.WriteString(text);
		}
	}

	public override void WriteString(XmlDictionaryString value)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed || !System.Xml.XmlConverter.IsWhitespace(value.Value))
		{
			WriteBase64InlineIfPresent();
			Writer.WriteString(value);
		}
	}

	public override void WriteSurrogateCharEntity(char lowChar, char highChar)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteSurrogateCharEntity(lowChar, highChar);
	}

	public override void WriteWhitespace(string whitespace)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed)
		{
			WriteBase64InlineIfPresent();
			Writer.WriteWhitespace(whitespace);
		}
	}

	public override void WriteValue(object value)
	{
		if (value is IStreamProvider value2)
		{
			WriteValue(value2);
			return;
		}
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(string value)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed || !System.Xml.XmlConverter.IsWhitespace(value))
		{
			WriteBase64InlineIfPresent();
			Writer.WriteValue(value);
		}
	}

	public override void WriteValue(bool value)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(DateTime value)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(double value)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(int value)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(long value)
	{
		WriteBase64InlineIfPresent();
		Writer.WriteValue(value);
	}

	public override void WriteValue(XmlDictionaryString value)
	{
		if (_depth != 0 || _mimeWriter.WriteState != MimeWriterState.Closed || !System.Xml.XmlConverter.IsWhitespace(value.Value))
		{
			WriteBase64InlineIfPresent();
			Writer.WriteValue(value);
		}
	}

	public override void WriteXmlnsAttribute(string prefix, string ns)
	{
		Writer.WriteXmlnsAttribute(prefix, ns);
	}

	public override void WriteXmlnsAttribute(string prefix, XmlDictionaryString ns)
	{
		Writer.WriteXmlnsAttribute(prefix, ns);
	}
}

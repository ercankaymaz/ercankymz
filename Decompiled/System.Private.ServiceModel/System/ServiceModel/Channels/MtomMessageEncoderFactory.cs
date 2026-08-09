using System.Globalization;
using System.IO;
using System.Runtime;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class MtomMessageEncoderFactory : MessageEncoderFactory
{
	private MessageVersion _messageVersion;

	private Encoding _writeEncoding;

	private int _maxReadPoolSize;

	private int _maxWritePoolSize;

	private int _maxBufferSize;

	private XmlDictionaryReaderQuotas _readerQuotas;

	private const int MaxPooledXmlReadersPerMessage = 2;

	private object _thisLock;

	private OnXmlDictionaryReaderClose _onStreamedReaderClose;

	private volatile SynchronizedPool<XmlDictionaryWriter> _streamedWriterPool;

	private volatile SynchronizedPool<XmlDictionaryReader> _streamedReaderPool;

	private volatile SynchronizedPool<MtomMessageEncoder.MtomBufferedMessageData> _bufferedReaderPool;

	private volatile SynchronizedPool<MtomMessageEncoder.MtomBufferedMessageWriter> _bufferedWriterPool;

	private volatile SynchronizedPool<RecycledMessageState> _recycledStatePool;

	public override MessageEncoder Encoder => new MtomMessageEncoder(_messageVersion, _writeEncoding, _maxReadPoolSize, _maxWritePoolSize, _maxBufferSize, _readerQuotas, this);

	public override MessageVersion MessageVersion => _messageVersion;

	public int MaxWritePoolSize => _maxWritePoolSize;

	public int MaxReadPoolSize => _maxReadPoolSize;

	public XmlDictionaryReaderQuotas ReaderQuotas => _readerQuotas;

	public int MaxBufferSize => _maxBufferSize;

	internal TextMessageEncoderFactory.ContentEncoding[] ContentEncodingMap { get; }

	internal SynchronizedPool<RecycledMessageState> RecycledStatePool
	{
		get
		{
			if (_recycledStatePool == null)
			{
				lock (_thisLock)
				{
					if (_recycledStatePool == null)
					{
						_recycledStatePool = new SynchronizedPool<RecycledMessageState>(MaxReadPoolSize);
					}
				}
			}
			return _recycledStatePool;
		}
	}

	public MtomMessageEncoderFactory(MessageVersion version, Encoding writeEncoding, int maxReadPoolSize, int maxWritePoolSize, int maxBufferSize, XmlDictionaryReaderQuotas quotas)
	{
		_messageVersion = version;
		_writeEncoding = writeEncoding;
		_maxReadPoolSize = maxReadPoolSize;
		_maxWritePoolSize = maxWritePoolSize;
		_maxBufferSize = maxBufferSize;
		_readerQuotas = quotas;
		_thisLock = new object();
		_onStreamedReaderClose = ReturnStreamedReader;
		if (version.Envelope == EnvelopeVersion.Soap12)
		{
			ContentEncodingMap = TextMessageEncoderFactory.Soap12Content;
			return;
		}
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			ContentEncodingMap = TextMessageEncoderFactory.Soap11Content;
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid MessageVersion")));
	}

	internal XmlDictionaryWriter TakeStreamedWriter(Stream stream, string startInfo, string boundary, string startUri, bool writeMessageHeaders)
	{
		if (_streamedWriterPool == null)
		{
			lock (_thisLock)
			{
				if (_streamedWriterPool == null)
				{
					_streamedWriterPool = new SynchronizedPool<XmlDictionaryWriter>(MaxWritePoolSize);
				}
			}
		}
		XmlDictionaryWriter xmlDictionaryWriter = _streamedWriterPool.Take();
		if (xmlDictionaryWriter == null)
		{
			xmlDictionaryWriter = XmlMtomWriter.Create(stream, _writeEncoding, int.MaxValue, startInfo, boundary, startUri, writeMessageHeaders, ownsStream: false);
			if (WcfEventSource.Instance.WritePoolMissIsEnabled())
			{
				WcfEventSource.Instance.WritePoolMiss(xmlDictionaryWriter.GetType().Name);
			}
		}
		else
		{
			((IXmlMtomWriterInitializer)xmlDictionaryWriter).SetOutput(stream, _writeEncoding, int.MaxValue, startInfo, boundary, startUri, writeMessageHeaders, ownsStream: false);
		}
		return xmlDictionaryWriter;
	}

	internal void ReturnStreamedWriter(XmlDictionaryWriter xmlWriter)
	{
		xmlWriter.Close();
		_streamedWriterPool.Return(xmlWriter);
	}

	internal MtomMessageEncoder.MtomBufferedMessageWriter TakeBufferedWriter(MtomMessageEncoder messageEncoder)
	{
		if (_bufferedWriterPool == null)
		{
			lock (_thisLock)
			{
				if (_bufferedWriterPool == null)
				{
					_bufferedWriterPool = new SynchronizedPool<MtomMessageEncoder.MtomBufferedMessageWriter>(MaxWritePoolSize);
				}
			}
		}
		MtomMessageEncoder.MtomBufferedMessageWriter mtomBufferedMessageWriter = _bufferedWriterPool.Take();
		if (mtomBufferedMessageWriter == null)
		{
			mtomBufferedMessageWriter = new MtomMessageEncoder.MtomBufferedMessageWriter(messageEncoder);
			if (WcfEventSource.Instance.WritePoolMissIsEnabled())
			{
				WcfEventSource.Instance.WritePoolMiss(mtomBufferedMessageWriter.GetType().Name);
			}
		}
		return mtomBufferedMessageWriter;
	}

	internal void ReturnMessageWriter(MtomMessageEncoder.MtomBufferedMessageWriter messageWriter)
	{
		_bufferedWriterPool.Return(messageWriter);
	}

	internal MtomMessageEncoder.MtomBufferedMessageData TakeBufferedReader(MtomMessageEncoder messageEncoder)
	{
		if (_bufferedReaderPool == null)
		{
			lock (_thisLock)
			{
				if (_bufferedReaderPool == null)
				{
					_bufferedReaderPool = new SynchronizedPool<MtomMessageEncoder.MtomBufferedMessageData>(MaxReadPoolSize);
				}
			}
		}
		MtomMessageEncoder.MtomBufferedMessageData mtomBufferedMessageData = _bufferedReaderPool.Take();
		if (mtomBufferedMessageData == null)
		{
			mtomBufferedMessageData = new MtomMessageEncoder.MtomBufferedMessageData(messageEncoder, 2);
			if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
			{
				WcfEventSource.Instance.ReadPoolMiss(mtomBufferedMessageData.GetType().Name);
			}
		}
		return mtomBufferedMessageData;
	}

	internal void ReturnBufferedData(MtomMessageEncoder.MtomBufferedMessageData messageData)
	{
		_bufferedReaderPool.Return(messageData);
	}

	internal XmlReader TakeStreamedReader(Stream stream, string contentType, bool isMtomContentType)
	{
		if (_streamedReaderPool == null)
		{
			lock (_thisLock)
			{
				if (_streamedReaderPool == null)
				{
					_streamedReaderPool = new SynchronizedPool<XmlDictionaryReader>(MaxReadPoolSize);
				}
			}
		}
		XmlDictionaryReader xmlDictionaryReader = _streamedReaderPool.Take();
		try
		{
			if (contentType == null || isMtomContentType)
			{
				if (xmlDictionaryReader != null && xmlDictionaryReader is IXmlMtomReaderInitializer)
				{
					((IXmlMtomReaderInitializer)xmlDictionaryReader).SetInput(stream, GetSupportedEncodings(), contentType, ReaderQuotas, MaxBufferSize, _onStreamedReaderClose);
				}
				else
				{
					xmlDictionaryReader = XmlMtomReader.Create(stream, GetSupportedEncodings(), contentType, ReaderQuotas, MaxBufferSize, _onStreamedReaderClose);
					if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
					{
						WcfEventSource.Instance.ReadPoolMiss(xmlDictionaryReader.GetType().Name);
					}
				}
			}
			else if (xmlDictionaryReader != null && xmlDictionaryReader is IXmlTextReaderInitializer)
			{
				((IXmlTextReaderInitializer)xmlDictionaryReader).SetInput(stream, TextMessageEncoderFactory.GetEncodingFromContentType(contentType, ContentEncodingMap), ReaderQuotas, _onStreamedReaderClose);
			}
			else
			{
				xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(stream, TextMessageEncoderFactory.GetEncodingFromContentType(contentType, ContentEncodingMap), ReaderQuotas, _onStreamedReaderClose);
				if (WcfEventSource.Instance.ReadPoolMissIsEnabled())
				{
					WcfEventSource.Instance.ReadPoolMiss(xmlDictionaryReader.GetType().Name);
				}
			}
		}
		catch (FormatException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorCreatingMtomReader, innerException));
		}
		catch (XmlException innerException2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorCreatingMtomReader, innerException2));
		}
		return xmlDictionaryReader;
	}

	internal void ReturnStreamedReader(XmlDictionaryReader xmlReader)
	{
		_streamedReaderPool.Return(xmlReader);
	}

	public static Encoding[] GetSupportedEncodings()
	{
		Encoding[] supportedEncodings = TextEncoderDefaults.SupportedEncodings;
		Encoding[] array = new Encoding[supportedEncodings.Length];
		Array.Copy(supportedEncodings, array, supportedEncodings.Length);
		return array;
	}
}

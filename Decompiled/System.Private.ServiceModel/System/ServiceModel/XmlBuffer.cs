using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

internal class XmlBuffer
{
	private enum BufferState
	{
		Created,
		Writing,
		Reading
	}

	internal struct Section(int offset, int size, XmlDictionaryReaderQuotas quotas)
	{
		private int _size = size;

		public int Offset { get; } = offset;

		public int Size => _size;

		public XmlDictionaryReaderQuotas Quotas { get; } = quotas;
	}

	private List<Section> _sections;

	private byte[] _buffer;

	private int _offset;

	private BufferedOutputStream _stream;

	private BufferState _bufferState;

	private XmlDictionaryWriter _writer;

	private XmlDictionaryReaderQuotas _quotas;

	public int BufferSize => _buffer.Length;

	public int SectionCount => _sections.Count;

	public XmlBuffer(int maxBufferSize)
	{
		if (maxBufferSize < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, System.SR.ValueMustBeNonNegative));
		}
		int initialSize = Math.Min(512, maxBufferSize);
		_stream = new BufferManagerOutputStream(System.SR.XmlBufferQuotaExceeded, initialSize, maxBufferSize, BufferManager.CreateBufferManager(0L, int.MaxValue));
		_sections = new List<Section>(1);
	}

	public XmlDictionaryWriter OpenSection(XmlDictionaryReaderQuotas quotas)
	{
		if (_bufferState != BufferState.Created)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidStateException());
		}
		_bufferState = BufferState.Writing;
		_quotas = new XmlDictionaryReaderQuotas();
		quotas.CopyTo(_quotas);
		if (_writer != null)
		{
			XmlDictionaryWriter writer = _writer;
			writer.Dispose();
			_writer = null;
		}
		_writer = XmlDictionaryWriter.CreateBinaryWriter(_stream, XD.Dictionary, null, ownsStream: true);
		return _writer;
	}

	public void CloseSection()
	{
		if (_bufferState != BufferState.Writing)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidStateException());
		}
		_writer.Dispose();
		_writer = null;
		_bufferState = BufferState.Created;
		int num = (int)_stream.Length - _offset;
		_sections.Add(new Section(_offset, num, _quotas));
		_offset += num;
	}

	public void Close()
	{
		if (_bufferState != BufferState.Created)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidStateException());
		}
		_bufferState = BufferState.Reading;
		_buffer = _stream.ToArray(out var _);
		_writer = null;
		_stream = null;
	}

	private Exception CreateInvalidStateException()
	{
		return new InvalidOperationException(System.SR.XmlBufferInInvalidState);
	}

	public XmlDictionaryReader GetReader(int sectionIndex)
	{
		if (_bufferState != BufferState.Reading)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidStateException());
		}
		Section section = _sections[sectionIndex];
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateBinaryReader(_buffer, section.Offset, section.Size, XD.Dictionary, section.Quotas);
		xmlDictionaryReader.MoveToContent();
		return xmlDictionaryReader;
	}

	public void WriteTo(int sectionIndex, XmlWriter writer)
	{
		if (_bufferState != BufferState.Reading)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidStateException());
		}
		XmlDictionaryReader reader = GetReader(sectionIndex);
		try
		{
			writer.WriteNode(reader, defattr: false);
		}
		finally
		{
			reader.Dispose();
		}
	}
}

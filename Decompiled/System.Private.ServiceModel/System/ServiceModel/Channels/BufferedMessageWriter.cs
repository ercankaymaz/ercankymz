using System.IO;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class BufferedMessageWriter
{
	private int[] _sizeHistory;

	private int _sizeHistoryIndex;

	private const int sizeHistoryCount = 4;

	private const int expectedSizeVariance = 256;

	private BufferManagerOutputStream _stream;

	public BufferedMessageWriter()
	{
		_stream = new BufferManagerOutputStream(System.SR.MaxSentMessageSizeExceeded);
		InitMessagePredicter();
	}

	protected abstract XmlDictionaryWriter TakeXmlWriter(Stream stream);

	protected abstract void ReturnXmlWriter(XmlDictionaryWriter writer);

	public ArraySegment<byte> WriteMessage(Message message, BufferManager bufferManager, int initialOffset, int maxSizeQuota)
	{
		int num = ((maxSizeQuota > int.MaxValue - initialOffset) ? int.MaxValue : (maxSizeQuota + initialOffset));
		int num2 = PredictMessageSize();
		if (num2 > num)
		{
			num2 = num;
		}
		else if (num2 < initialOffset)
		{
			num2 = initialOffset;
		}
		try
		{
			_stream.Init(num2, maxSizeQuota, num, bufferManager);
			_stream.Skip(initialOffset);
			XmlDictionaryWriter xmlDictionaryWriter = TakeXmlWriter(_stream);
			OnWriteStartMessage(xmlDictionaryWriter);
			message.WriteMessage(xmlDictionaryWriter);
			OnWriteEndMessage(xmlDictionaryWriter);
			xmlDictionaryWriter.Flush();
			ReturnXmlWriter(xmlDictionaryWriter);
			int bufferSize;
			byte[] array = _stream.ToArray(out bufferSize);
			RecordActualMessageSize(bufferSize);
			return new ArraySegment<byte>(array, initialOffset, bufferSize - initialOffset);
		}
		finally
		{
			_stream.Clear();
		}
	}

	protected virtual void OnWriteStartMessage(XmlDictionaryWriter writer)
	{
	}

	protected virtual void OnWriteEndMessage(XmlDictionaryWriter writer)
	{
	}

	private void InitMessagePredicter()
	{
		_sizeHistory = new int[4];
		for (int i = 0; i < 4; i++)
		{
			_sizeHistory[i] = 256;
		}
	}

	private int PredictMessageSize()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (_sizeHistory[i] > num)
			{
				num = _sizeHistory[i];
			}
		}
		return num + 256;
	}

	private void RecordActualMessageSize(int size)
	{
		_sizeHistory[_sizeHistoryIndex] = size;
		_sizeHistoryIndex = (_sizeHistoryIndex + 1) % 4;
	}
}

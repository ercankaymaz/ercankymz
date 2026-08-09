using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ArraySegmentStream : MemoryStream
{
	private int m_bufferIndex;

	private ArraySegment<byte> m_currentBuffer;

	private int m_currentPosition;

	private BufferCollection m_buffers;

	private BufferManager m_bufferManager;

	private int m_start;

	private int m_count;

	private int m_bufferSize;

	private int m_endOfLastBuffer;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => true;

	public override long Length => GetAbsoluteLength();

	public override long Position
	{
		get
		{
			return GetAbsolutePosition();
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public ArraySegmentStream(BufferCollection buffers)
	{
		m_buffers = buffers;
		m_endOfLastBuffer = 0;
		if (m_buffers.Count > 0)
		{
			m_endOfLastBuffer = m_buffers[m_buffers.Count - 1].Count;
		}
		SetCurrentBuffer(0);
	}

	public ArraySegmentStream(BufferManager bufferManager, int bufferSize, int start, int count)
	{
		m_buffers = new BufferCollection();
		m_bufferManager = bufferManager;
		m_bufferSize = bufferSize;
		m_start = start;
		m_count = count;
		m_endOfLastBuffer = 0;
		SetCurrentBuffer(0);
	}

	public BufferCollection GetBuffers(string owner)
	{
		BufferCollection bufferCollection = new BufferCollection(m_buffers.Count);
		for (int i = 0; i < m_buffers.Count; i++)
		{
			m_bufferManager.TransferBuffer(m_buffers[i].Array, owner);
			bufferCollection.Add(new ArraySegment<byte>(m_buffers[i].Array, m_buffers[i].Offset, GetBufferCount(i)));
		}
		m_buffers.Clear();
		return bufferCollection;
	}

	public override void Flush()
	{
	}

	public override int ReadByte()
	{
		while (true)
		{
			if (m_currentBuffer.Array == null)
			{
				return -1;
			}
			if (GetBufferCount(m_bufferIndex) - m_currentPosition > 0)
			{
				break;
			}
			SetCurrentBuffer(m_bufferIndex + 1);
		}
		return m_currentBuffer.Array[m_currentBuffer.Offset + m_currentPosition++];
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = 0;
		while (count > 0)
		{
			if (m_currentBuffer.Array == null)
			{
				return num;
			}
			int num2 = GetBufferCount(m_bufferIndex) - m_currentPosition;
			if (num2 > count)
			{
				Array.Copy(m_currentBuffer.Array, m_currentPosition + m_currentBuffer.Offset, buffer, offset, count);
				num += count;
				m_currentPosition += count;
				return num;
			}
			Array.Copy(m_currentBuffer.Array, m_currentPosition + m_currentBuffer.Offset, buffer, offset, num2);
			num += num2;
			offset += num2;
			count -= num2;
			SetCurrentBuffer(m_bufferIndex + 1);
		}
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		switch (origin)
		{
		case SeekOrigin.Current:
			offset += GetAbsolutePosition();
			break;
		case SeekOrigin.End:
			offset += GetAbsoluteLength();
			break;
		}
		if (offset < 0)
		{
			throw new IOException("Cannot seek beyond the beginning of the stream.");
		}
		int num = (int)offset;
		if (num >= GetAbsolutePosition())
		{
			CheckEndOfStream();
		}
		for (int i = 0; i < m_buffers.Count; i++)
		{
			int bufferCount = GetBufferCount(i);
			if (offset <= bufferCount)
			{
				SetCurrentBuffer(i);
				m_currentPosition = (int)offset;
				return num;
			}
			offset -= bufferCount;
		}
		throw new IOException("Cannot seek beyond the end of the stream.");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void WriteByte(byte value)
	{
		while (true)
		{
			CheckEndOfStream();
			if (m_currentBuffer.Count - m_currentPosition >= 1)
			{
				break;
			}
			SetCurrentBuffer(m_bufferIndex + 1);
		}
		m_currentBuffer.Array[m_currentBuffer.Offset + m_currentPosition] = value;
		m_currentPosition++;
		if (m_bufferIndex == m_buffers.Count - 1 && m_endOfLastBuffer < m_currentPosition)
		{
			m_endOfLastBuffer = m_currentPosition;
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		while (count > 0)
		{
			CheckEndOfStream();
			int num = m_currentBuffer.Count - m_currentPosition;
			if (num >= count)
			{
				Array.Copy(buffer, offset, m_currentBuffer.Array, m_currentPosition + m_currentBuffer.Offset, count);
				m_currentPosition += count;
				if (m_bufferIndex == m_buffers.Count - 1 && m_endOfLastBuffer < m_currentPosition)
				{
					m_endOfLastBuffer = m_currentPosition;
				}
				break;
			}
			Array.Copy(buffer, offset, m_currentBuffer.Array, m_currentPosition + m_currentBuffer.Offset, num);
			offset += num;
			count -= num;
			SetCurrentBuffer(m_bufferIndex + 1);
		}
	}

	public override byte[] ToArray()
	{
		int absoluteLength = GetAbsoluteLength();
		if (absoluteLength == 0)
		{
			return Array.Empty<byte>();
		}
		byte[] array = new byte[absoluteLength];
		int num = 0;
		for (int i = 0; i < m_buffers.Count; i++)
		{
			int bufferCount = GetBufferCount(i);
			Array.Copy(m_buffers[i].Array, m_buffers[i].Offset, array, num, bufferCount);
			num += bufferCount;
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void SetCurrentBuffer(int index)
	{
		if (index < 0 || index >= m_buffers.Count)
		{
			m_currentBuffer = default(ArraySegment<byte>);
			m_currentPosition = 0;
		}
		else
		{
			m_bufferIndex = index;
			m_currentBuffer = m_buffers[index];
			m_currentPosition = 0;
		}
	}

	private int GetAbsoluteLength()
	{
		int num = 0;
		for (int i = 0; i < m_buffers.Count; i++)
		{
			num += GetBufferCount(i);
		}
		return num;
	}

	private int GetAbsolutePosition()
	{
		if (m_currentBuffer.Array == null)
		{
			return GetAbsoluteLength();
		}
		int num = 0;
		for (int i = 0; i < m_bufferIndex; i++)
		{
			num += GetBufferCount(i);
		}
		return num + m_currentPosition;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int GetBufferCount(int index)
	{
		if (index == m_buffers.Count - 1)
		{
			return m_endOfLastBuffer;
		}
		return m_buffers[index].Count;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckEndOfStream()
	{
		if (m_currentBuffer.Array == null)
		{
			if (m_bufferManager == null)
			{
				throw new IOException("Attempt to write past end of stream.");
			}
			byte[] array = m_bufferManager.TakeBuffer(m_bufferSize, "ArraySegmentStream.Write");
			m_buffers.Add(new ArraySegment<byte>(array, m_start, m_count));
			m_endOfLastBuffer = 0;
			SetCurrentBuffer(m_buffers.Count - 1);
		}
	}
}

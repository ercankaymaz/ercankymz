using System;
using System.IO;
using System.Text;
using QUT.GplexBuffers;

namespace Xbim.IO.Parser;

public class XbimScanBuffer : ScanBuff
{
	private Stream _stream;

	private byte[] _buffer = new byte[32768];

	private byte[] _prevBuffer = new byte[32768];

	private long _bufferOffset;

	private long _bufferPosition;

	private long _prevBufferPosition;

	private Encoding _encoding = Encoding.ASCII;

	private const byte hash = 35;

	private const byte zero = 48;

	private const byte markOffset = 5;

	private int[] _magnitudes = new int[10] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };

	public override long Pos
	{
		get
		{
			return _bufferOffset + _bufferPosition;
		}
		set
		{
			_bufferPosition = value - _bufferOffset;
		}
	}

	public XbimScanBuffer(Stream stream)
	{
		_stream = stream;
	}

	public override string GetString(long begin, long limit)
	{
		byte[] subArray = GetSubArray(begin, limit);
		return _encoding.GetString(subArray);
	}

	public int GetLabel(int begin, int limit)
	{
		byte[] subArray = GetSubArray(begin, limit);
		int num = 0;
		int num2 = 0;
		for (int num3 = subArray.Length - 1; num3 > 0; num3--)
		{
			int num4 = subArray[num3] - 48;
			num += num4 * _magnitudes[num2++];
		}
		return num;
	}

	private byte[] GetSubArray(long begin, long limit)
	{
		int num = (int)(begin - _bufferOffset);
		int num2 = (int)(limit - begin);
		byte[] array = new byte[num2];
		if (num > 0)
		{
			Array.ConstrainedCopy(_buffer, num, array, 0, num2);
			return array;
		}
		int sourceIndex = (int)(_prevBufferPosition + num);
		int num3 = Math.Abs(num);
		Array.ConstrainedCopy(_prevBuffer, sourceIndex, array, 0, num3);
		num2 += num;
		num = 0;
		Array.ConstrainedCopy(_buffer, num, array, num3, num2);
		return array;
	}

	public override int Read()
	{
		if (Pos < _stream.Position)
		{
			if (_bufferPosition > 0)
			{
				return _buffer[_bufferPosition++];
			}
			long num = _prevBufferPosition + _bufferPosition;
			_bufferPosition++;
			return _prevBuffer[num];
		}
		int num2 = _stream.ReadByte();
		if (_bufferPosition == _buffer.Length)
		{
			Array.Resize(ref _buffer, _buffer.Length * 2);
		}
		if (num2 > -1)
		{
			_buffer[_bufferPosition++] = (byte)num2;
		}
		return num2;
	}

	public override void Mark()
	{
		if (_bufferPosition >= 5)
		{
			byte[] prevBuffer = _prevBuffer;
			_prevBuffer = _buffer;
			_buffer = prevBuffer;
			_bufferOffset += _bufferPosition - 5;
			_prevBufferPosition = _bufferPosition - 5;
			_bufferPosition = 5L;
			for (int i = 0; i < 5; i++)
			{
				_buffer[i] = _prevBuffer[_prevBufferPosition + i];
			}
		}
	}
}

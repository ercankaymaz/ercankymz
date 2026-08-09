#define DEBUG
using System;
using System.Diagnostics;
using System.IO;

namespace PdfSharp.Drawing;

internal class StreamReaderHelper
{
	private readonly Stream _stream;

	private int _currentOffset;

	private readonly byte[] _data;

	private readonly int _length;

	public Stream OriginalStream => _stream;

	internal int CurrentOffset
	{
		get
		{
			return _currentOffset;
		}
		set
		{
			_currentOffset = value;
		}
	}

	public byte[] Data => _data;

	public int Length => _length;

	internal StreamReaderHelper(Stream stream)
	{
		_stream = stream;
		_stream.Position = 0L;
		if (_stream.Length > int.MaxValue)
		{
			throw new ArgumentException("Stream is too large.", "stream");
		}
		_length = (int)_stream.Length;
		_data = new byte[_length];
		_stream.Read(_data, 0, _length);
	}

	internal byte GetByte(int offset)
	{
		if (_currentOffset + offset >= _length)
		{
			Debug.Assert(condition: false);
			return 0;
		}
		return _data[_currentOffset + offset];
	}

	internal ushort GetWord(int offset, bool bigEndian)
	{
		return (ushort)(bigEndian ? (GetByte(offset) * 256 + GetByte(offset + 1)) : (GetByte(offset) + GetByte(offset + 1) * 256));
	}

	internal uint GetDWord(int offset, bool bigEndian)
	{
		return (uint)(bigEndian ? (GetWord(offset, bigEndian: true) * 65536 + GetWord(offset + 2, bigEndian: true)) : (GetWord(offset, bigEndian: false) + GetWord(offset + 2, bigEndian: false) * 65536));
	}

	private static void CopyStream(Stream input, Stream output)
	{
		byte[] array = new byte[65536];
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			output.Write(array, 0, count);
		}
	}

	public void Reset()
	{
		_currentOffset = 0;
	}
}

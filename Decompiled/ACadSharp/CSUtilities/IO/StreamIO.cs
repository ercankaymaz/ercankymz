using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSUtilities.Converters;

namespace CSUtilities.IO;

internal class StreamIO : IDisposable
{
	protected Stream _stream;

	public virtual long Position
	{
		get
		{
			return _stream.Position;
		}
		set
		{
			_stream.Position = value;
		}
	}

	public virtual long Length => _stream.Length;

	public Encoding Encoding { get; set; } = Encoding.Default;

	public IEndianConverter EndianConverter { get; set; } = new DefaultEndianConverter();

	public Stream Stream => _stream;

	public StreamIO(string filename)
		: this(filename, FileMode.Open, FileAccess.ReadWrite)
	{
	}

	public StreamIO(string filename, FileMode mode, FileAccess access)
	{
		_stream = File.Open(filename, mode, access);
	}

	public StreamIO(Stream stream, bool createCopy, bool resetPosition)
	{
		long position = stream.Position;
		if (!stream.CanSeek || createCopy)
		{
			stream.Position = 0L;
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			_stream = new MemoryStream(array);
			stream.Position = position;
		}
		else
		{
			_stream = stream;
		}
		if (resetPosition)
		{
			_stream.Position = 0L;
		}
	}

	public StreamIO(Stream stream, bool createCopy)
		: this(stream, createCopy, resetPosition: false)
	{
	}

	public StreamIO(Stream stream)
		: this(stream, createCopy: false, resetPosition: false)
	{
	}

	public StreamIO(byte[] arr)
		: this(new MemoryStream(arr))
	{
	}

	public byte[] GetBytes(int offset, int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("Length cannot be negative.");
		}
		long position = Position;
		Position = offset;
		byte[] result = ReadBytes(length);
		Position = position;
		return result;
	}

	public async Task<byte[]> GetBytesAsync(int offset, int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("Length cannot be negative.");
		}
		long save = Position;
		Position = offset;
		byte[] result = await ReadBytesAsync(length);
		Position = save;
		return result;
	}

	public byte LookByte()
	{
		return LookBytes(1)[0];
	}

	public byte[] LookBytes(int count)
	{
		byte[] result = ReadBytes(count);
		Position -= count;
		return result;
	}

	public virtual byte ReadByte()
	{
		byte[] array = new byte[1];
		if (_stream.Read(array, 0, 1) != 1)
		{
			throw new EndOfStreamException();
		}
		return array[0];
	}

	public virtual async Task<byte> ReadByteAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		byte[] arr = new byte[1];
		if (await _stream.ReadAsync(arr, 0, 1, cancellationToken) != 1)
		{
			throw new EndOfStreamException();
		}
		return arr[0];
	}

	public char ReadChar()
	{
		return (char)ReadByte();
	}

	public virtual byte[] ReadBytes(int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("Length cannot be negative.");
		}
		byte[] array = new byte[length];
		if (_stream.Read(array, 0, length) < length)
		{
			throw new EndOfStreamException();
		}
		return array;
	}

	public virtual async Task<byte[]> ReadBytesAsync(int length, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("Length cannot be negative.");
		}
		byte[] buffer = new byte[length];
		if (await _stream.ReadAsync(buffer, 0, length, cancellationToken) < length)
		{
			throw new EndOfStreamException();
		}
		return buffer;
	}

	public string ReadUntil(char match)
	{
		string text = string.Empty;
		char c;
		do
		{
			c = ReadChar();
			text += c;
		}
		while (match != c);
		return text;
	}

	public short ReadShort()
	{
		return ReadShort<DefaultEndianConverter>();
	}

	public short ReadShort<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(2);
		return val.ToInt16(arr);
	}

	public ushort ReadUShort()
	{
		return ReadUShort<DefaultEndianConverter>();
	}

	public ushort ReadUShort<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(2);
		return val.ToUInt16(arr);
	}

	public int ReadInt()
	{
		return ReadInt<DefaultEndianConverter>();
	}

	public int ReadInt<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(4);
		return val.ToInt32(arr);
	}

	public uint ReadUInt()
	{
		return ReadUInt<DefaultEndianConverter>();
	}

	public uint ReadUInt<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(4);
		return val.ToUInt32(arr);
	}

	public float ReadSingle()
	{
		return ReadSingle<DefaultEndianConverter>();
	}

	public float ReadSingle<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(4);
		return val.ToSingle(arr);
	}

	public double ReadDouble()
	{
		return ReadDouble<DefaultEndianConverter>();
	}

	public double ReadDouble<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(8);
		return val.ToDouble(arr);
	}

	public long ReadLong()
	{
		return ReadLong<DefaultEndianConverter>();
	}

	public long ReadLong<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(8);
		return val.ToInt64(arr);
	}

	public ulong ReadULong()
	{
		return ReadULong<DefaultEndianConverter>();
	}

	public ulong ReadULong<T>() where T : IEndianConverter, new()
	{
		T val = new T();
		byte[] arr = ReadBytes(8);
		return val.ToUInt64(arr);
	}

	public string ReadString(int length)
	{
		return ReadString(length, Encoding);
	}

	public string ReadString(int length, Encoding encoding)
	{
		if (length == 0)
		{
			return string.Empty;
		}
		byte[] bytes = ReadBytes(length);
		return encoding.GetString(bytes);
	}

	public void Write<T>(T value) where T : struct
	{
		Write(value, new DefaultEndianConverter());
	}

	public void Write<T, E>(T value) where T : struct where E : IEndianConverter, new()
	{
		Write(value, new E());
	}

	public void Write<T>(T value, IEndianConverter converter) where T : struct
	{
		byte[] bytes = converter.GetBytes(value);
		_stream.Write(bytes, 0, bytes.Length);
	}

	public virtual void WriteBytes(byte[] buffer)
	{
		_stream.Write(buffer, 0, buffer.Length);
	}

	public virtual void WriteBytes(byte[] buffer, int offset, int count)
	{
		_stream.Write(buffer, offset, count);
	}

	public void Write(string value)
	{
		Write(value, Encoding);
	}

	public void Write(string value, Encoding encoding)
	{
		byte[] bytes = encoding.GetBytes(value);
		_stream.Write(bytes, 0, bytes.Length);
	}

	public void Dispose()
	{
		_stream.Dispose();
	}
}

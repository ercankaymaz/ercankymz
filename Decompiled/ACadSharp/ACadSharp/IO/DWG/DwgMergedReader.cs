using System;
using System.IO;
using System.Text;
using CSMath;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgMergedReader : IDwgStreamReader
{
	private IDwgStreamReader _mainReader;

	private IDwgStreamReader _textReader;

	private IDwgStreamReader _handleReader;

	public Encoding Encoding
	{
		get
		{
			return _mainReader.Encoding;
		}
		set
		{
			_mainReader.Encoding = value;
			_textReader.Encoding = value;
			_handleReader.Encoding = value;
		}
	}

	public Stream Stream
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public int BitShift
	{
		get
		{
			throw new InvalidOperationException();
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public long Position
	{
		get
		{
			return _mainReader.Position;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public bool IsEmpty { get; }

	public DwgMergedReader(IDwgStreamReader manReader, IDwgStreamReader textReader, IDwgStreamReader handleReader)
	{
		_mainReader = manReader;
		_textReader = textReader;
		_handleReader = handleReader;
	}

	public void Advance(int offset)
	{
		_mainReader.Advance(offset);
	}

	public void AdvanceByte()
	{
		throw new InvalidOperationException();
	}

	public ulong HandleReference()
	{
		return _handleReader.HandleReference();
	}

	public ulong HandleReference(ulong referenceHandle)
	{
		return _handleReader.HandleReference(referenceHandle);
	}

	public ulong HandleReference(ulong referenceHandle, out DwgReferenceType reference)
	{
		return _handleReader.HandleReference(referenceHandle, out reference);
	}

	public long PositionInBits()
	{
		return _mainReader.PositionInBits();
	}

	public byte Read2Bits()
	{
		return _mainReader.Read2Bits();
	}

	public XY Read2RawDouble()
	{
		return _mainReader.Read2RawDouble();
	}

	public XYZ Read3RawDouble()
	{
		return _mainReader.Read3RawDouble();
	}

	public XYZ Read3BitDouble()
	{
		return _mainReader.Read3BitDouble();
	}

	public bool ReadBit()
	{
		return _mainReader.ReadBit();
	}

	public short ReadBitAsShort()
	{
		return _mainReader.ReadBitAsShort();
	}

	public double ReadBitDouble()
	{
		return _mainReader.ReadBitDouble();
	}

	public XY Read2BitDouble()
	{
		return _mainReader.Read2BitDouble();
	}

	public int ReadBitLong()
	{
		return _mainReader.ReadBitLong();
	}

	public long ReadBitLongLong()
	{
		return _mainReader.ReadBitLongLong();
	}

	public short ReadBitShort()
	{
		return _mainReader.ReadBitShort();
	}

	public bool ReadBitShortAsBool()
	{
		return _mainReader.ReadBitShortAsBool();
	}

	public byte ReadByte()
	{
		return _mainReader.ReadByte();
	}

	public byte[] ReadBytes(int length)
	{
		return _mainReader.ReadBytes(length);
	}

	public XY Read2BitDoubleWithDefault(XY defValues)
	{
		return _mainReader.Read2BitDoubleWithDefault(defValues);
	}

	public XYZ Read3BitDoubleWithDefault(XYZ defValues)
	{
		return _mainReader.Read3BitDoubleWithDefault(defValues);
	}

	public Color ReadCmColor(bool useTextStream = false)
	{
		if (!(_mainReader is DwgStreamReaderAC18) && !useTextStream)
		{
			return _mainReader.ReadCmColor();
		}
		Color color = default(Color);
		ReadBitShort();
		uint num = (uint)ReadBitLong();
		byte[] bytes = LittleEndianConverter.Instance.GetBytes(num);
		color = ((num == 3221225472u) ? Color.ByLayer : (((num & 0x1000000) == 0) ? new Color(bytes[2], bytes[1], bytes[0]) : new Color(bytes[0])));
		byte num2 = ReadByte();
		_ = string.Empty;
		if ((num2 & 1) == 1)
		{
			ReadVariableText();
		}
		_ = string.Empty;
		if ((num2 & 2) == 2)
		{
			ReadVariableText();
		}
		return color;
	}

	public Color ReadEnColor(out Transparency transparency, out bool flag)
	{
		return _mainReader.ReadEnColor(out transparency, out flag);
	}

	public DateTime Read8BitJulianDate()
	{
		throw new NotImplementedException();
	}

	public DateTime ReadDateTime()
	{
		return _mainReader.ReadDateTime();
	}

	public double ReadDouble()
	{
		throw new NotImplementedException();
	}

	public int ReadInt()
	{
		throw new NotImplementedException();
	}

	public ulong ReadModularChar()
	{
		throw new NotImplementedException();
	}

	public long ReadSignedModularChar()
	{
		throw new NotImplementedException();
	}

	public int ReadModularShort()
	{
		throw new NotImplementedException();
	}

	public Color ReadColorByIndex()
	{
		return new Color((byte)ReadBitShort());
	}

	public ObjectType ReadObjectType()
	{
		throw new NotImplementedException();
	}

	public XYZ ReadBitExtrusion()
	{
		return _mainReader.ReadBitExtrusion();
	}

	public double ReadBitDoubleWithDefault(double def)
	{
		return _mainReader.ReadBitDoubleWithDefault(def);
	}

	public double ReadBitThickness()
	{
		return _mainReader.ReadBitThickness();
	}

	public char ReadRawChar()
	{
		return _mainReader.ReadRawChar();
	}

	public long ReadRawLong()
	{
		return _mainReader.ReadRawLong();
	}

	public ulong ReadRawULong()
	{
		return _mainReader.ReadRawULong();
	}

	public byte[] ReadSentinel()
	{
		return _mainReader.ReadSentinel();
	}

	public short ReadShort()
	{
		return _mainReader.ReadShort();
	}

	public short ReadShort<T>() where T : IEndianConverter, new()
	{
		throw new NotImplementedException();
	}

	public string ReadTextUnicode()
	{
		if (_textReader.IsEmpty)
		{
			return string.Empty;
		}
		return _textReader.ReadTextUnicode();
	}

	public TimeSpan ReadTimeSpan()
	{
		return _mainReader.ReadTimeSpan();
	}

	public uint ReadUInt()
	{
		throw new NotImplementedException();
	}

	public string ReadVariableText()
	{
		if (_textReader.IsEmpty)
		{
			return string.Empty;
		}
		return _textReader.ReadVariableText();
	}

	public ushort ResetShift()
	{
		return _mainReader.ResetShift();
	}

	public void SetPositionInBits(long positon)
	{
		_mainReader.SetPositionInBits(positon);
	}

	public long SetPositionByFlag(long position)
	{
		throw new InvalidOperationException();
	}
}

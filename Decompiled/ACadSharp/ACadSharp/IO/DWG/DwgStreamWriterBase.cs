using System;
using System.IO;
using System.Text;
using CSMath;
using CSUtilities.Converters;
using CSUtilities.IO;

namespace ACadSharp.IO.DWG;

internal abstract class DwgStreamWriterBase : StreamIO, IDwgStreamWriter
{
	private byte _lastByte;

	public IDwgStreamWriter Main => this;

	public long PositionInBits => Position * 8 + BitShift;

	public long SavedPositionInBits { get; }

	public int BitShift { get; private set; }

	public DwgStreamWriterBase(Stream stream, Encoding encoding)
		: base(stream)
	{
		base.Encoding = encoding;
	}

	public static IDwgStreamWriter GetStreamWriter(ACadVersion version, Stream stream, Encoding encoding)
	{
		switch (version)
		{
		case ACadVersion.Unknown:
			throw new Exception();
		case ACadVersion.MC0_0:
		case ACadVersion.AC1_2:
		case ACadVersion.AC1_4:
		case ACadVersion.AC1_50:
		case ACadVersion.AC2_10:
		case ACadVersion.AC1002:
		case ACadVersion.AC1003:
		case ACadVersion.AC1004:
		case ACadVersion.AC1006:
		case ACadVersion.AC1009:
			throw new NotSupportedException($"Dwg version not supported: {version}");
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
			return new DwgStreamWriterAC12(stream, encoding);
		case ACadVersion.AC1015:
			return new DwgStreamWriterAC15(stream, encoding);
		case ACadVersion.AC1018:
			return new DwgStreamWriterAC18(stream, encoding);
		case ACadVersion.AC1021:
			return new DwgStreamWriterAC21(stream, encoding);
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			return new DwgStreamWriterAC24(stream, encoding);
		default:
			throw new NotSupportedException($"Dwg version not supported: {version}");
		}
	}

	public static IDwgStreamWriter GetMergedWriter(ACadVersion version, Stream stream, Encoding encoding)
	{
		switch (version)
		{
		case ACadVersion.Unknown:
			throw new Exception();
		case ACadVersion.MC0_0:
		case ACadVersion.AC1_2:
		case ACadVersion.AC1_4:
		case ACadVersion.AC1_50:
		case ACadVersion.AC2_10:
		case ACadVersion.AC1002:
		case ACadVersion.AC1003:
		case ACadVersion.AC1004:
		case ACadVersion.AC1006:
		case ACadVersion.AC1009:
			throw new NotSupportedException($"Dwg version not supported: {version}");
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
			return new DwgmMergedStreamWriterAC14(stream, new DwgStreamWriterAC12(stream, encoding), new DwgStreamWriterAC12(new MemoryStream(), encoding));
		case ACadVersion.AC1015:
			return new DwgmMergedStreamWriterAC14(stream, new DwgStreamWriterAC15(stream, encoding), new DwgStreamWriterAC15(new MemoryStream(), encoding));
		case ACadVersion.AC1018:
			return new DwgmMergedStreamWriterAC14(stream, new DwgStreamWriterAC18(stream, encoding), new DwgStreamWriterAC18(new MemoryStream(), encoding));
		case ACadVersion.AC1021:
			return new DwgMergedStreamWriter(stream, new DwgStreamWriterAC21(stream, encoding), new DwgStreamWriterAC21(new MemoryStream(), encoding), new DwgStreamWriterAC21(new MemoryStream(), encoding));
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			return new DwgMergedStreamWriter(stream, new DwgStreamWriterAC24(stream, encoding), new DwgStreamWriterAC24(new MemoryStream(), encoding), new DwgStreamWriterAC24(new MemoryStream(), encoding));
		default:
			throw new NotSupportedException($"Dwg version not supported: {version}");
		}
	}

	public void WriteInt(int value)
	{
		Write(value, LittleEndianConverter.Instance);
	}

	public virtual void WriteObjectType(short value)
	{
		WriteBitShort(value);
	}

	public void WriteObjectType(ObjectType value)
	{
		WriteObjectType((short)value);
	}

	public void WriteRawLong(long value)
	{
		WriteBytes(LittleEndianConverter.Instance.GetBytes((int)value));
	}

	public override void WriteBytes(byte[] arr)
	{
		if (BitShift == 0)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				base.Stream.WriteByte(arr[i]);
			}
			return;
		}
		int num = 8 - BitShift;
		foreach (byte b in arr)
		{
			base.Stream.WriteByte((byte)(_lastByte | (b >> BitShift)));
			_lastByte = (byte)(b << num);
		}
	}

	public new void WriteBytes(byte[] arr, int initialIndex, int length)
	{
		if (BitShift == 0)
		{
			int num = 0;
			int num2 = initialIndex;
			while (num < length)
			{
				_stream.WriteByte(arr[num2]);
				num++;
				num2++;
			}
			return;
		}
		int num3 = 8 - BitShift;
		int num4 = 0;
		int num5 = initialIndex;
		while (num4 < length)
		{
			byte b = arr[num5];
			_stream.WriteByte((byte)(_lastByte | (b >> BitShift)));
			_lastByte = (byte)(b << num3);
			num4++;
			num5++;
		}
	}

	public void WriteBitShort(short value)
	{
		if (value == 0)
		{
			Write2Bits(2);
		}
		else if (value > 0 && value < 256)
		{
			Write2Bits(1);
			WriteByte((byte)value);
		}
		else if (value == 256)
		{
			Write2Bits(3);
		}
		else
		{
			Write2Bits(0);
			WriteByte((byte)value);
			WriteByte((byte)(value >> 8));
		}
	}

	public void WriteBitDouble(double value)
	{
		if (value == 0.0)
		{
			Write2Bits(2);
			return;
		}
		if (value == 1.0)
		{
			Write2Bits(1);
			return;
		}
		Write2Bits(0);
		WriteBytes(LittleEndianConverter.Instance.GetBytes(value));
	}

	public void WriteBitLong(int value)
	{
		if (value == 0)
		{
			Write2Bits(2);
			return;
		}
		if (value > 0 && value < 256)
		{
			Write2Bits(1);
			WriteByte((byte)value);
			return;
		}
		Write2Bits(0);
		WriteByte((byte)value);
		WriteByte((byte)(value >> 8));
		WriteByte((byte)(value >> 16));
		WriteByte((byte)(value >> 24));
	}

	public void WriteBitLongLong(long value)
	{
		byte b = 0;
		ulong num = (ulong)value;
		while (num != 0L)
		{
			num >>= 8;
			b++;
		}
		write3Bits(b);
		num = (ulong)value;
		for (int i = 0; i < b; i++)
		{
			WriteByte((byte)(num & 0xFF));
			num >>= 8;
		}
	}

	public virtual void WriteVariableText(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			WriteBitShort(0);
			return;
		}
		byte[] bytes = base.Encoding.GetBytes(value);
		WriteBitShort((short)bytes.Length);
		WriteBytes(bytes);
	}

	public virtual void WriteTextUnicode(string value)
	{
		byte[] bytes = base.Encoding.GetBytes(string.IsNullOrEmpty(value) ? string.Empty : value);
		WriteRawShort((ushort)(bytes.Length + 1));
		_stream.Write(bytes, 0, bytes.Length);
		_stream.WriteByte(0);
	}

	public void Write2Bits(byte value)
	{
		if (BitShift < 6)
		{
			_lastByte |= (byte)(value << 6 - BitShift);
			BitShift += 2;
		}
		else if (BitShift == 6)
		{
			_lastByte |= value;
			base.Stream.WriteByte(_lastByte);
			resetShift();
		}
		else
		{
			_lastByte |= (byte)(value >> 1);
			base.Stream.WriteByte(_lastByte);
			_lastByte = (byte)(value << 7);
			BitShift = 1;
		}
	}

	public void WriteBit(bool value)
	{
		if (BitShift < 7)
		{
			if (value)
			{
				_lastByte |= (byte)(1 << 7 - BitShift);
			}
			BitShift++;
			return;
		}
		if (value)
		{
			_lastByte |= 1;
		}
		base.Stream.WriteByte(_lastByte);
		resetShift();
	}

	public void WriteByte(byte value)
	{
		if (BitShift == 0)
		{
			base.Stream.WriteByte(value);
			return;
		}
		int num = 8 - BitShift;
		base.Stream.WriteByte((byte)(_lastByte | (value >> BitShift)));
		_lastByte = (byte)(value << num);
	}

	private void resetShift()
	{
		BitShift = 0;
		_lastByte = 0;
	}

	public void WriteDateTime(DateTime value)
	{
		CadUtils.DateToJulian(value, out var jdate, out var miliseconds);
		WriteBitLong(jdate);
		WriteBitLong(miliseconds);
	}

	public void WriteTimeSpan(TimeSpan value)
	{
		WriteBitLong(value.Days);
		WriteBitLong(value.Milliseconds);
	}

	public void Write8BitJulianDate(DateTime value)
	{
		CadUtils.DateToJulian(value, out var jdate, out var miliseconds);
		WriteRawLong(jdate);
		WriteRawLong(miliseconds);
	}

	public virtual void WriteCmColor(Color value)
	{
		short num = 0;
		num = ((!value.IsTrueColor) ? value.Index : value.GetApproxIndex());
		WriteBitShort(num);
	}

	public virtual void WriteEnColor(Color color, Transparency transparency)
	{
		WriteCmColor(color);
	}

	public virtual void WriteEnColor(Color color, Transparency transparency, bool isBookColor)
	{
		WriteCmColor(color);
	}

	public void Write2BitDouble(XY value)
	{
		WriteBitDouble(value.X);
		WriteBitDouble(value.Y);
	}

	public void Write3BitDouble(XYZ value)
	{
		WriteBitDouble(value.X);
		WriteBitDouble(value.Y);
		WriteBitDouble(value.Z);
	}

	public void Write2RawDouble(XY value)
	{
		WriteRawDouble(value.X);
		WriteRawDouble(value.Y);
	}

	public void WriteRawShort(short value)
	{
		WriteBytes(LittleEndianConverter.Instance.GetBytes(value));
	}

	public void WriteRawShort(ushort value)
	{
		WriteBytes(LittleEndianConverter.Instance.GetBytes(value));
	}

	public void WriteRawDouble(double value)
	{
		WriteBytes(LittleEndianConverter.Instance.GetBytes(value));
	}

	public void HandleReference(IHandledCadObject cadObject)
	{
		HandleReference(DwgReferenceType.Undefined, cadObject);
	}

	public void HandleReference(DwgReferenceType type, IHandledCadObject cadObject)
	{
		if (cadObject == null)
		{
			HandleReference(type, 0uL);
		}
		else
		{
			HandleReference(type, cadObject.Handle);
		}
	}

	public void HandleReference(ulong handle)
	{
		HandleReference(DwgReferenceType.Undefined, handle);
	}

	public void HandleReference(DwgReferenceType type, ulong handle)
	{
		byte b = (byte)((int)type << 4);
		if (handle == 0L)
		{
			WriteByte(b);
		}
		else if (handle < 256)
		{
			WriteByte((byte)(b | 1));
			WriteByte((byte)handle);
		}
		else if (handle < 65536)
		{
			WriteByte((byte)(b | 2));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else if (handle < 16777216)
		{
			WriteByte((byte)(b | 3));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else if (handle < 4294967296L)
		{
			WriteByte((byte)(b | 4));
			WriteByte((byte)(handle >> 24));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else if (handle < 1099511627776L)
		{
			WriteByte((byte)(b | 5));
			WriteByte((byte)(handle >> 32));
			WriteByte((byte)(handle >> 24));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else if (handle < 281474976710656L)
		{
			WriteByte((byte)(b | 6));
			WriteByte((byte)(handle >> 40));
			WriteByte((byte)(handle >> 32));
			WriteByte((byte)(handle >> 24));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else if (handle < 72057594037927936L)
		{
			WriteByte((byte)(b | 7));
			WriteByte((byte)(handle >> 48));
			WriteByte((byte)(handle >> 40));
			WriteByte((byte)(handle >> 32));
			WriteByte((byte)(handle >> 24));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
		else
		{
			WriteByte((byte)(b | 8));
			WriteByte((byte)(handle >> 56));
			WriteByte((byte)(handle >> 48));
			WriteByte((byte)(handle >> 40));
			WriteByte((byte)(handle >> 32));
			WriteByte((byte)(handle >> 24));
			WriteByte((byte)(handle >> 16));
			WriteByte((byte)(handle >> 8));
			WriteByte((byte)handle);
		}
	}

	public void WriteSpearShift()
	{
		if (BitShift > 0)
		{
			for (int i = BitShift; i < 8; i++)
			{
				WriteBit(value: false);
			}
		}
	}

	public virtual void WriteBitThickness(double thickness)
	{
		WriteBitDouble(thickness);
	}

	public virtual void WriteBitExtrusion(XYZ normal)
	{
		Write3BitDouble(normal);
	}

	public void Write2BitDoubleWithDefault(XY def, XY value)
	{
		WriteBitDoubleWithDefault(def.X, value.X);
		WriteBitDoubleWithDefault(def.Y, value.Y);
	}

	public void Write3BitDoubleWithDefault(XYZ def, XYZ value)
	{
		WriteBitDoubleWithDefault(def.X, value.X);
		WriteBitDoubleWithDefault(def.Y, value.Y);
		WriteBitDoubleWithDefault(def.Z, value.Z);
	}

	public void WriteBitDoubleWithDefault(double def, double value)
	{
		if (def == value)
		{
			Write2Bits(0);
			return;
		}
		byte[] bytes = LittleEndianConverter.Instance.GetBytes(def);
		byte[] bytes2 = LittleEndianConverter.Instance.GetBytes(value);
		int num = 0;
		int num2 = 7;
		while (num2 >= 0 && bytes[num2] == bytes2[num2])
		{
			num++;
			num2--;
		}
		if (num >= 4)
		{
			Write2Bits(1);
			WriteBytes(bytes, 0, 4);
		}
		else if (num >= 2)
		{
			Write2Bits(2);
			WriteByte(bytes[4]);
			WriteByte(bytes[5]);
			WriteByte(bytes[0]);
			WriteByte(bytes[1]);
			WriteByte(bytes[2]);
			WriteByte(bytes[3]);
		}
		else
		{
			Write2Bits(3);
			WriteBytes(bytes);
		}
	}

	public void ResetStream()
	{
		_stream.Position = 0L;
		resetShift();
		_stream.SetLength(0L);
	}

	public void SavePositonForSize()
	{
		WriteRawLong(0L);
	}

	public void SetPositionByFlag(long pos)
	{
		if (pos >= 32768)
		{
			if (pos >= 1073741824)
			{
				WriteBytes(LittleEndianConverter.Instance.GetBytes((ushort)((pos >> 30) & 0xFFFF)));
				WriteBytes(LittleEndianConverter.Instance.GetBytes((ushort)(((pos >> 15) & 0x7FFF) | 0x8000)));
			}
			else
			{
				WriteBytes(LittleEndianConverter.Instance.GetBytes((ushort)((pos >> 15) & 0xFFFF)));
			}
			WriteBytes(LittleEndianConverter.Instance.GetBytes((ushort)((pos & 0x7FFF) | 0x8000)));
		}
		else
		{
			WriteBytes(LittleEndianConverter.Instance.GetBytes((ushort)pos));
		}
	}

	public void SetPositionInBits(long posInBits)
	{
		long position = posInBits / 8;
		BitShift = (int)(posInBits % 8);
		_stream.Position = position;
		if (BitShift > 0)
		{
			int num = _stream.ReadByte();
			if (num < 0)
			{
				throw new EndOfStreamException();
			}
			_lastByte = (byte)num;
		}
		else
		{
			_lastByte = 0;
		}
		_stream.Position = position;
	}

	public void WriteShiftValue()
	{
		if (BitShift > 0)
		{
			long position = _stream.Position;
			int num = _stream.ReadByte();
			byte value = (byte)(_lastByte | ((byte)num & (255 >> BitShift)));
			_stream.Position = position;
			_stream.WriteByte(value);
		}
	}

	private void write3Bits(byte value)
	{
		WriteBit((value & 4) != 0);
		WriteBit((value & 2) != 0);
		WriteBit((value & 1) != 0);
	}
}

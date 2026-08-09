using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACadSharp.Exceptions;
using CSMath;
using CSUtilities.Converters;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO.DWG;

internal abstract class DwgStreamReaderBase : StreamIO, IDwgStreamReader
{
	protected byte _lastByte;

	public int BitShift { get; set; }

	public override long Position
	{
		get
		{
			return _stream.Position;
		}
		set
		{
			_stream.Position = value;
			BitShift = 0;
		}
	}

	public bool IsEmpty { get; private set; }

	public DwgStreamReaderBase(Stream stream, bool resetPosition)
		: base(stream, resetPosition)
	{
	}

	public static IDwgStreamReader GetStreamHandler(ACadVersion version, Stream stream, Encoding encoding = null, bool resetPositon = false)
	{
		IDwgStreamReader dwgStreamReader = null;
		switch (version)
		{
		case ACadVersion.Unknown:
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
			throw new CadNotSupportedException(version);
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
			dwgStreamReader = new DwgStreamReaderAC12(stream, resetPositon);
			break;
		case ACadVersion.AC1015:
			dwgStreamReader = new DwgStreamReaderAC15(stream, resetPositon);
			break;
		case ACadVersion.AC1018:
			dwgStreamReader = new DwgStreamReaderAC18(stream, resetPositon);
			break;
		case ACadVersion.AC1021:
			dwgStreamReader = new DwgStreamReaderAC21(stream, resetPositon);
			break;
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			dwgStreamReader = new DwgStreamReaderAC24(stream, resetPositon);
			break;
		default:
			throw new CadNotSupportedException();
		}
		if (encoding != null)
		{
			dwgStreamReader.Encoding = encoding;
		}
		return dwgStreamReader;
	}

	public override byte ReadByte()
	{
		if (BitShift == 0)
		{
			_lastByte = base.ReadByte();
			return _lastByte;
		}
		byte num = (byte)(_lastByte << BitShift);
		_lastByte = base.ReadByte();
		return (byte)(num | (byte)(_lastByte >>> 8 - BitShift));
	}

	public override byte[] ReadBytes(int length)
	{
		byte[] array = new byte[length];
		applyShiftToArr(length, array);
		return array;
	}

	public long SetPositionByFlag(long position)
	{
		SetPositionInBits(position);
		bool num = ReadBit();
		long num2 = position;
		if (num)
		{
			applyFlagToPosition(position, out var length, out var strDataSize);
			num2 = length - strDataSize;
			SetPositionInBits(num2);
		}
		else
		{
			IsEmpty = true;
			Position = base.Stream.Length;
		}
		return num2;
	}

	public bool ReadBit()
	{
		if (BitShift == 0)
		{
			AdvanceByte();
			bool result = (_lastByte & 0x80) == 128;
			BitShift = 1;
			return result;
		}
		bool result2 = ((_lastByte << BitShift) & 0x80) == 128;
		int bitShift = BitShift + 1;
		BitShift = bitShift;
		BitShift &= 7;
		return result2;
	}

	public short ReadBitAsShort()
	{
		return ReadBit() ? ((short)1) : ((short)0);
	}

	public byte Read2Bits()
	{
		byte result;
		if (BitShift == 0)
		{
			AdvanceByte();
			result = (byte)((uint)_lastByte >> 6);
			BitShift = 2;
		}
		else if (BitShift == 7)
		{
			byte num = (byte)((_lastByte << 1) & 2);
			AdvanceByte();
			result = (byte)(num | (byte)(_lastByte >>> 7));
			BitShift = 1;
		}
		else
		{
			result = (byte)((_lastByte >> 6 - BitShift) & 3);
			int bitShift = BitShift + 1;
			BitShift = bitShift;
			bitShift = BitShift + 1;
			BitShift = bitShift;
			BitShift &= 7;
		}
		return result;
	}

	public short ReadBitShort()
	{
		switch (Read2Bits())
		{
		case 0:
			return ReadShort<LittleEndianConverter>();
		case 1:
			if (BitShift == 0)
			{
				AdvanceByte();
				return _lastByte;
			}
			return applyShiftToLasByte();
		case 2:
			return 0;
		case 3:
			return 256;
		default:
			throw throwException("ReadBitShort");
		}
	}

	public bool ReadBitShortAsBool()
	{
		return ReadBitShort() != 0;
	}

	public int ReadBitLong()
	{
		switch (Read2Bits())
		{
		case 0:
			return ReadInt<LittleEndianConverter>();
		case 1:
			if (BitShift == 0)
			{
				AdvanceByte();
				return _lastByte;
			}
			return applyShiftToLasByte();
		case 2:
			return 0;
		default:
			throw new Exception("Failed to read ReadBitLong");
		}
	}

	public long ReadBitLongLong()
	{
		ulong num = 0uL;
		byte b = read3bits();
		for (int i = 0; i < b; i++)
		{
			ulong num2 = ReadByte();
			num += num2 << (i << 3);
		}
		return (long)num;
	}

	public double ReadBitDouble()
	{
		return Read2Bits() switch
		{
			0 => ReadDouble<LittleEndianConverter>(), 
			1 => 1.0, 
			2 => 0.0, 
			_ => throw throwException("ReadBitDouble"), 
		};
	}

	public XY Read2BitDouble()
	{
		return new XY(ReadBitDouble(), ReadBitDouble());
	}

	public XYZ Read3BitDouble()
	{
		return new XYZ(ReadBitDouble(), ReadBitDouble(), ReadBitDouble());
	}

	public char ReadRawChar()
	{
		return (char)ReadByte();
	}

	public long ReadRawLong()
	{
		return ReadInt<LittleEndianConverter>();
	}

	public ulong ReadRawULong()
	{
		return ReadULong<LittleEndianConverter>();
	}

	public XY Read2RawDouble()
	{
		return new XY(ReadDouble(), ReadDouble());
	}

	public XYZ Read3RawDouble()
	{
		return new XYZ(ReadDouble(), ReadDouble(), ReadDouble());
	}

	public ulong ReadModularChar()
	{
		int num = 0;
		byte num2 = ReadByte();
		ulong num3 = (ulong)(num2 & 0x7F);
		if ((num2 & 0x80) != 0)
		{
			byte b;
			do
			{
				num += 7;
				b = ReadByte();
				num3 |= (ulong)((long)(b & 0x7F) << num);
			}
			while ((b & 0x80) != 0);
		}
		return num3;
	}

	public long ReadSignedModularChar()
	{
		long num;
		if (BitShift == 0)
		{
			AdvanceByte();
			if ((_lastByte & 0x80) == 0)
			{
				num = _lastByte & 0x3F;
				if ((long)(_lastByte & 0x40) > 0L)
				{
					num = -num;
				}
			}
			else
			{
				int num2 = 0;
				long num3 = _lastByte & 0x7F;
				while (true)
				{
					num2 += 7;
					AdvanceByte();
					if ((_lastByte & 0x80) == 0)
					{
						break;
					}
					num3 |= (long)(_lastByte & 0x7F) << num2;
				}
				num = num3 | ((long)(_lastByte & 0x3F) << num2);
				if ((long)(_lastByte & 0x40) > 0L)
				{
					num = -num;
				}
			}
		}
		else
		{
			byte b = applyShiftToLasByte();
			if ((b & 0x80) == 0)
			{
				num = b & 0x3F;
				if ((long)(b & 0x40) > 0L)
				{
					num = -num;
				}
			}
			else
			{
				int num4 = 0;
				int num5 = b & 0x7F;
				byte b2;
				while (true)
				{
					num4 += 7;
					b2 = applyShiftToLasByte();
					if ((b2 & 0x80) == 0)
					{
						break;
					}
					num5 |= (b2 & 0x7F) << num4;
				}
				num = num5 | ((b2 & 0x3F) << num4);
				if ((long)(b2 & 0x40) > 0L)
				{
					num = -num;
				}
			}
		}
		return num;
	}

	public int ReadModularShort()
	{
		int num = 15;
		byte b = ReadByte();
		byte b2 = ReadByte();
		bool flag = (b2 & 0x80) == 0;
		int num2 = b | ((b2 & 0x7F) << 8);
		while (!flag)
		{
			b = ReadByte();
			b2 = ReadByte();
			flag = (b2 & 0x80) == 0;
			num2 |= b << num;
			num += 8;
			num2 |= (b2 & 0x7F) << num;
			num += 7;
		}
		return num2;
	}

	public ulong HandleReference()
	{
		DwgReferenceType reference;
		return HandleReference(0uL, out reference);
	}

	public ulong HandleReference(ulong referenceHandle)
	{
		DwgReferenceType reference;
		return HandleReference(referenceHandle, out reference);
	}

	public ulong HandleReference(ulong referenceHandle, out DwgReferenceType reference)
	{
		byte num = ReadByte();
		byte b = (byte)((uint)num >> 4);
		int length = num & 0xF;
		reference = (DwgReferenceType)(b & 3);
		if (b <= 5)
		{
			return readHandle(length);
		}
		switch (b)
		{
		case 6:
			return ++referenceHandle;
		case 8:
			return --referenceHandle;
		case 10:
		{
			ulong num3 = readHandle(length);
			return referenceHandle + num3;
		}
		case 12:
		{
			ulong num2 = readHandle(length);
			return referenceHandle - num2;
		}
		default:
			throw new DwgException($"[HandleReference] invalid reference code with value: {b}");
		}
	}

	private ulong readHandle(int length)
	{
		byte[] array = new byte[length];
		byte[] array2 = new byte[8];
		if (base.Stream.Read(array, 0, length) < length)
		{
			throw new EndOfStreamException();
		}
		if (BitShift == 0)
		{
			for (int i = 0; i < length; i++)
			{
				array2[length - 1 - i] = array[i];
			}
		}
		else
		{
			int num = 8 - BitShift;
			for (int j = 0; j < length; j++)
			{
				byte num2 = (byte)(_lastByte << BitShift);
				_lastByte = array[j];
				byte b = (byte)(num2 | (byte)(_lastByte >>> num));
				array2[length - 1 - j] = b;
			}
		}
		for (int k = length; k < 8; k++)
		{
			array2[k] = 0;
		}
		return LittleEndianConverter.Instance.ToUInt64(array2);
	}

	public virtual string ReadTextUnicode()
	{
		int num = ReadShort();
		int code = ReadByte();
		if (num == 0)
		{
			return string.Empty;
		}
		return ReadString(num, TextEncoding.GetListedEncoding((CodePage)code));
	}

	public virtual string ReadVariableText()
	{
		short num = ReadBitShort();
		if (num > 0)
		{
			return ReadString(num, base.Encoding).Replace("\0", "");
		}
		return string.Empty;
	}

	public byte[] ReadSentinel()
	{
		return ReadBytes(16);
	}

	public XY Read2BitDoubleWithDefault(XY defValues)
	{
		return new XY(ReadBitDoubleWithDefault(defValues.X), ReadBitDoubleWithDefault(defValues.Y));
	}

	public XYZ Read3BitDoubleWithDefault(XYZ defValues)
	{
		return new XYZ(ReadBitDoubleWithDefault(defValues.X), ReadBitDoubleWithDefault(defValues.Y), ReadBitDoubleWithDefault(defValues.Z));
	}

	public virtual Color ReadCmColor(bool useTextStream = false)
	{
		return new Color(ReadBitShort());
	}

	public virtual Color ReadEnColor(out Transparency transparency, out bool flag)
	{
		flag = false;
		short index = ReadBitShort();
		transparency = Transparency.ByLayer;
		return new Color(index);
	}

	public Color ReadColorByIndex()
	{
		return new Color(ReadBitShort());
	}

	public virtual ObjectType ReadObjectType()
	{
		return (ObjectType)ReadBitShort();
	}

	public virtual XYZ ReadBitExtrusion()
	{
		return Read3BitDouble();
	}

	public double ReadBitDoubleWithDefault(double def)
	{
		byte[] bytes = LittleEndianConverter.Instance.GetBytes(def);
		switch (Read2Bits())
		{
		case 0:
			return def;
		case 1:
			if (BitShift == 0)
			{
				AdvanceByte();
				bytes[0] = _lastByte;
				AdvanceByte();
				bytes[1] = _lastByte;
				AdvanceByte();
				bytes[2] = _lastByte;
				AdvanceByte();
				bytes[3] = _lastByte;
			}
			else
			{
				int num = 8 - BitShift;
				bytes[0] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[0] |= (byte)(_lastByte >>> num);
				bytes[1] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[1] |= (byte)(_lastByte >>> num);
				bytes[2] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[2] |= (byte)(_lastByte >>> num);
				bytes[3] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[3] |= (byte)(_lastByte >>> num);
			}
			return LittleEndianConverter.Instance.ToDouble(bytes);
		case 2:
			if (BitShift == 0)
			{
				AdvanceByte();
				bytes[4] = _lastByte;
				AdvanceByte();
				bytes[5] = _lastByte;
				AdvanceByte();
				bytes[0] = _lastByte;
				AdvanceByte();
				bytes[1] = _lastByte;
				AdvanceByte();
				bytes[2] = _lastByte;
				AdvanceByte();
				bytes[3] = _lastByte;
			}
			else
			{
				bytes[4] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[4] |= (byte)(_lastByte >>> 8 - BitShift);
				bytes[5] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[5] |= (byte)(_lastByte >>> 8 - BitShift);
				bytes[0] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[0] |= (byte)(_lastByte >>> 8 - BitShift);
				bytes[1] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[1] |= (byte)(_lastByte >>> 8 - BitShift);
				bytes[2] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[2] |= (byte)(_lastByte >>> 8 - BitShift);
				bytes[3] = (byte)(_lastByte << BitShift);
				AdvanceByte();
				bytes[3] |= (byte)(_lastByte >>> 8 - BitShift);
			}
			return LittleEndianConverter.Instance.ToDouble(bytes);
		case 3:
			return ReadDouble();
		default:
			throw throwException("ReadBitDoubleWithDefault");
		}
	}

	public virtual double ReadBitThickness()
	{
		return ReadBitDouble();
	}

	public DateTime Read8BitJulianDate()
	{
		return julianToDate(ReadInt(), ReadInt());
	}

	public DateTime ReadDateTime()
	{
		return julianToDate(ReadBitLong(), ReadBitLong());
	}

	public TimeSpan ReadTimeSpan()
	{
		long num = ReadBitLong();
		long num2 = ReadBitLong();
		if (num < 0 || (double)num > TimeSpan.MaxValue.TotalHours || num2 < 0 || (double)num2 > TimeSpan.MaxValue.TotalMilliseconds)
		{
			return TimeSpan.FromHours(0.0) + TimeSpan.FromMilliseconds(0.0);
		}
		return TimeSpan.FromHours(num) + TimeSpan.FromMilliseconds(num2);
	}

	public long PositionInBits()
	{
		long num = base.Stream.Position * 8;
		if (BitShift != 0)
		{
			num += BitShift - 8;
		}
		return num;
	}

	public void SetPositionInBits(long position)
	{
		Position = position >> 3;
		BitShift = (int)(position & 7);
		if (BitShift != 0)
		{
			AdvanceByte();
		}
	}

	public void AdvanceByte()
	{
		_lastByte = base.ReadByte();
	}

	public void Advance(int offset)
	{
		if (offset > 1)
		{
			base.Stream.Position += offset - 1;
		}
		ReadByte();
	}

	public ushort ResetShift()
	{
		if (BitShift != 0)
		{
			BitShift = 0;
		}
		AdvanceByte();
		byte lastByte = _lastByte;
		AdvanceByte();
		return (ushort)(lastByte | (ushort)(_lastByte << 8));
	}

	protected void applyFlagToPosition(long lastPos, out long length, out long strDataSize)
	{
		length = lastPos - 16;
		SetPositionInBits(length);
		strDataSize = ReadUShort();
		if ((strDataSize & 0x8000) != 0)
		{
			length -= 16L;
			SetPositionInBits(length);
			strDataSize &= 32767L;
			int num = ReadUShort();
			strDataSize += (num & 0xFFFF) << 15;
		}
	}

	protected byte applyShiftToLasByte()
	{
		byte num = (byte)(_lastByte << BitShift);
		AdvanceByte();
		return (byte)(num | (byte)(_lastByte >>> 8 - BitShift));
	}

	protected DwgException throwException([CallerMemberName] string callerName = null)
	{
		return new DwgException("Failed to read " + callerName);
	}

	private void applyShiftToArr(int length, byte[] arr)
	{
		if (base.Stream.Read(arr, 0, length) != length)
		{
			throw new EndOfStreamException();
		}
		if (BitShift != 0)
		{
			int num = 8 - BitShift;
			for (int i = 0; i < length; i++)
			{
				byte num2 = (byte)(_lastByte << BitShift);
				_lastByte = arr[i];
				byte b = (byte)(num2 | (byte)(_lastByte >>> num));
				arr[i] = b;
			}
		}
	}

	private byte read3bits()
	{
		byte b = 0;
		if (ReadBit())
		{
			b = 1;
		}
		byte b2 = (byte)(b << 1);
		if (ReadBit())
		{
			b2 |= 1;
		}
		byte b3 = (byte)(b2 << 1);
		if (ReadBit())
		{
			b3 |= 1;
		}
		return b3;
	}

	private DateTime julianToDate(int jdate, int miliseconds)
	{
		double value = ((double)jdate - 2440587.5) * 86400.0;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
		try
		{
			dateTime = dateTime.AddSeconds(value).ToLocalTime();
		}
		catch (Exception)
		{
			dateTime = DateTime.MinValue;
		}
		return dateTime.AddMilliseconds(miliseconds);
	}
}

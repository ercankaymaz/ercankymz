using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACadSharp.IO.DWG;

internal class DwgHandleWriter : DwgSectionIO
{
	private MemoryStream _stream;

	private Dictionary<ulong, long> _handleMap;

	public override string SectionName => "AcDb:Handles";

	public DwgHandleWriter(ACadVersion version, MemoryStream stream, Dictionary<ulong, long> map)
		: base(version)
	{
		_stream = stream;
		_handleMap = new Dictionary<ulong, long>();
		foreach (KeyValuePair<ulong, long> item in map.OrderBy((KeyValuePair<ulong, long> o) => o.Key))
		{
			_handleMap.Add(item.Key, item.Value);
		}
	}

	public void Write(int sectionOffset = 0)
	{
		byte[] array = new byte[10];
		byte[] array2 = new byte[5];
		ulong num = 0uL;
		long num2 = 0L;
		long position = _stream.Position;
		_stream.WriteByte(0);
		_stream.WriteByte(0);
		foreach (KeyValuePair<ulong, long> item in _handleMap)
		{
			ulong value = item.Key - num;
			long num3 = item.Value + sectionOffset;
			long num4 = num3 - num2;
			int num5 = modularShortToValue(value, array);
			int num6 = signedModularShortToValue((int)num4, array2);
			if (_stream.Position - position + (num5 + num6) > 2032)
			{
				processPosition(position);
				num = 0uL;
				num2 = 0L;
				position = _stream.Position;
				_stream.WriteByte(0);
				_stream.WriteByte(0);
				num = 0uL;
				num2 = 0L;
				value = item.Key - num;
				if (value == 0L)
				{
					throw new Exception();
				}
				num4 = num3 - num2;
				num5 = modularShortToValue(value, array);
				num6 = signedModularShortToValue((int)num4, array2);
			}
			_stream.Write(array, 0, num5);
			_stream.Write(array2, 0, num6);
			num = item.Key;
			num2 = num3;
		}
		processPosition(position);
		position = _stream.Position;
		_stream.WriteByte(0);
		_stream.WriteByte(0);
		processPosition(position);
	}

	private int modularShortToValue(ulong value, byte[] arr)
	{
		int num = 0;
		while (value >= 128)
		{
			arr[num] = (byte)((value & 0x7F) | 0x80);
			num++;
			value >>= 7;
		}
		arr[num] = (byte)value;
		return num + 1;
	}

	private int signedModularShortToValue(int value, byte[] arr)
	{
		int num = 0;
		if (value < 0)
		{
			for (value = -value; value >= 64; value >>= 7)
			{
				arr[num] = (byte)((value & 0x7F) | 0x80);
				num++;
			}
			arr[num] = (byte)(value | 0x40);
			return num + 1;
		}
		while (value >= 64)
		{
			arr[num] = (byte)((value & 0x7F) | 0x80);
			num++;
			value >>= 7;
		}
		arr[num] = (byte)value;
		return num + 1;
	}

	private void processPosition(long pos)
	{
		ushort num = (ushort)(_stream.Position - pos);
		long position = _stream.Position;
		_stream.Position = pos;
		_stream.WriteByte((byte)(num >> 8));
		_stream.WriteByte((byte)(num & 0xFF));
		_stream.Position = position;
		ushort cRCValue = CRC8StreamHandler.GetCRCValue(49345, _stream.GetBuffer(), pos, _stream.Length - pos);
		_stream.WriteByte((byte)(cRCValue >> 8));
		_stream.WriteByte((byte)(cRCValue & 0xFF));
	}
}

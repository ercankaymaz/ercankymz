using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buComm.ModbusTCP;

public class ModbusCommands
{
	private static string m__0001;

	private static string _0002;

	public Master ModbusMaster = null;

	public string IPAddress = _0019(107395823);

	public ushort Port = 502;

	public string ReadWriteMode = _0019(107397175);

	public string ModeValue = _0019(107397175);

	[NonSerialized]
	internal static GetString _0019;

	public ModbusCommands()
	{
		if ((buSystem.strIDScale != _0019(107395170)) | (buSystem.strTest != _0019(107395613)) | (buSystem.valCheckFactor != 97245796635758.77) | (buSystem.valMidPointConstant != -598745789953.8955) | (buSystem.a1 != ModbusCommands.m__0001) | (buSystem.a2 != _0002))
		{
			throw new RegisterException(_0019(107395468));
		}
	}

	public void Connect()
	{
		ModbusMaster = new Master(IPAddress, Port);
		ModbusMaster.OnResponseData += _0001;
		ModbusMaster.OnException += _0001;
	}

	public void Disconnect()
	{
		if (0 == 0)
		{
			bool num = ModbusMaster != null;
			do
			{
				if (0 == 0)
				{
					bool flag = num;
					num = flag;
				}
			}
			while (false);
			if (!num)
			{
				return;
			}
		}
		do
		{
			ModbusMaster.Dispose();
			ModbusMaster = null;
		}
		while (-1 == 0);
	}

	private void _0001(ushort P_0, byte P_1, byte P_2, byte[] P_3)
	{
		ushort num = P_0;
		while (true)
		{
			ushort num2 = num;
			while (true)
			{
				ushort num3 = num2;
				num = num3;
				if (false)
				{
					break;
				}
				switch (num)
				{
				default:
					return;
				case 1:
					return;
				case 2:
					return;
				case 3:
					if (false)
					{
					}
					return;
				case 4:
					if (false)
					{
					}
					return;
				case 5:
					break;
				case 6:
					return;
				case 7:
					return;
				case 8:
					return;
				}
				if (false)
				{
					continue;
				}
				return;
			}
		}
	}

	private void _0001(ushort P_0, byte P_1, byte P_2, byte P_3)
	{
		byte num;
		int num2;
		string text;
		if (6u != 0)
		{
			text = _0019(107395479);
			byte b = P_3;
			byte b2 = b;
			num = b2;
			num2 = 1;
			while (true)
			{
				switch (num - num2)
				{
				case 0:
					text = global::_0002._0003(text, _0019(107395450));
					goto IL_019e;
				case 1:
					text = global::_0002._0003(text, _0019(107395393));
					goto IL_019e;
				case 2:
					break;
				case 3:
					text = global::_0002._0003(text, _0019(107394823));
					goto IL_019e;
				case 4:
					text = global::_0002._0003(text, _0019(107394794));
					goto IL_019e;
				case 9:
					text = global::_0002._0003(text, _0019(107394809));
					goto IL_019e;
				case 5:
				case 6:
				case 7:
				case 8:
					goto IL_019e;
				default:
					goto IL_0309;
				}
				break;
				IL_0309:
				num = b2;
				num2 = 253;
				if (num2 == 0)
				{
					continue;
				}
				goto IL_0072;
			}
			goto IL_00cd;
		}
		goto IL_019e;
		IL_0072:
		switch (num - num2)
		{
		case 2:
			text = global::_0002._0003(text, _0019(107394772));
			break;
		case 1:
			text = global::_0002._0003(text, _0019(107394747));
			break;
		case 0:
			text = global::_0002._0003(text, _0019(107394718));
			break;
		}
		goto IL_019e;
		IL_00cd:
		text = global::_0002._0003(text, _0019(107394852));
		goto IL_019e;
		IL_019e:
		if (3u != 0)
		{
			text = global::_0019._0095(new string[9]
			{
				text,
				_0019(107394665),
				P_0.ToString(),
				_0019(107394684),
				P_1.ToString(),
				_0019(107394671),
				P_2.ToString(),
				_0019(107394650),
				P_3.ToString()
			});
			text = global::_0019._0095(new string[10]
			{
				text,
				_0019(107395109),
				Master.localAdress.ToString(),
				_0019(107395124),
				ReadWriteMode,
				Master.localAdress.ToString(),
				_0019(107395124),
				ReadWriteMode,
				_0019(107395079),
				ModeValue
			});
			_0015_0002._009C_0002(text, _0019(107395094));
			return;
		}
		goto IL_00cd;
	}

	public void ChangeBytesForWrite(ref byte[] by)
	{
		byte[] array = new byte[by.Length];
		nint num = (nint)array.LongLength;
		while (true)
		{
			nint num2 = (((int)num == 2) ? 1 : 0);
			while (true)
			{
				bool flag = (byte)num2 != 0;
				num = (flag ? 1 : 0);
				if (5 == 0)
				{
					break;
				}
				if (flag)
				{
					array[0] = by[1];
					array[1] = by[0];
				}
				int num3 = ((array.Length == 4) ? 1 : 0);
				while (true)
				{
					bool flag2 = (byte)num3 != 0;
					bool num4 = flag2;
					if (8u != 0)
					{
						if (num4)
						{
							array[0] = by[3];
							array[1] = by[2];
							array[2] = by[1];
							array[3] = by[0];
						}
						if (6u != 0)
						{
							if (array.Length == 6)
							{
								goto IL_0088;
							}
							goto IL_00b9;
						}
						goto IL_00e1;
					}
					goto IL_0133;
					IL_0105:
					int num5 = 0;
					goto IL_0127;
					IL_0127:
					num4 = num5 <= array.Length - 1;
					goto IL_0133;
					IL_0088:
					array[0] = by[5];
					array[1] = by[4];
					array[2] = by[3];
					array[3] = by[2];
					if (false)
					{
						goto IL_010a;
					}
					array[4] = by[1];
					if (7u != 0)
					{
						array[5] = by[0];
						goto IL_00b9;
					}
					goto IL_0127;
					IL_00e1:
					array[3] = by[4];
					array[4] = by[3];
					array[5] = by[2];
					array[6] = by[1];
					array[7] = by[0];
					goto IL_0105;
					IL_0133:
					if (!num4)
					{
						return;
					}
					goto IL_010a;
					IL_010a:
					by[num5] = array[num5];
					if (false)
					{
						goto IL_0088;
					}
					num3 = num5;
					if (false)
					{
						continue;
					}
					num5 = num3 + 1;
					goto IL_0127;
					IL_00b9:
					num2 = (nint)array.LongLength;
					if (5 == 0)
					{
						break;
					}
					if ((int)num2 == 8)
					{
						array[0] = by[7];
						array[1] = by[6];
						array[2] = by[5];
						goto IL_00e1;
					}
					goto IL_0105;
				}
			}
		}
	}

	public void ChangeBytesForRead(ref byte[] by)
	{
		byte[] array = new byte[by.Length];
		nint num = (nint)array.LongLength;
		while (true)
		{
			nint num2 = (((int)num == 2) ? 1 : 0);
			while (true)
			{
				bool flag = (byte)num2 != 0;
				num = (flag ? 1 : 0);
				if (5 == 0)
				{
					break;
				}
				if (flag)
				{
					array[0] = by[1];
					array[1] = by[0];
				}
				int num3 = ((array.Length == 4) ? 1 : 0);
				while (true)
				{
					bool flag2 = (byte)num3 != 0;
					bool num4 = flag2;
					if (8u != 0)
					{
						if (num4)
						{
							array[0] = by[1];
							array[1] = by[0];
							array[2] = by[3];
							array[3] = by[2];
						}
						if (6u != 0)
						{
							if (array.Length == 6)
							{
								goto IL_0088;
							}
							goto IL_00b9;
						}
						goto IL_00e1;
					}
					goto IL_0133;
					IL_0105:
					int num5 = 0;
					goto IL_0127;
					IL_0127:
					num4 = num5 <= array.Length - 1;
					goto IL_0133;
					IL_0088:
					array[0] = by[1];
					array[1] = by[0];
					array[2] = by[3];
					array[3] = by[2];
					if (false)
					{
						goto IL_010a;
					}
					array[4] = by[5];
					if (7u != 0)
					{
						array[5] = by[4];
						goto IL_00b9;
					}
					goto IL_0127;
					IL_00e1:
					array[3] = by[2];
					array[4] = by[5];
					array[5] = by[4];
					array[6] = by[7];
					array[7] = by[6];
					goto IL_0105;
					IL_0133:
					if (!num4)
					{
						return;
					}
					goto IL_010a;
					IL_010a:
					by[num5] = array[num5];
					if (false)
					{
						goto IL_0088;
					}
					num3 = num5;
					if (false)
					{
						continue;
					}
					num5 = num3 + 1;
					goto IL_0127;
					IL_00b9:
					num2 = (nint)array.LongLength;
					if (5 == 0)
					{
						break;
					}
					if ((int)num2 == 8)
					{
						array[0] = by[1];
						array[1] = by[0];
						array[2] = by[3];
						goto IL_00e1;
					}
					goto IL_0105;
				}
			}
		}
	}

	public void ReadHoldInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107395061);
		ModeValue = Value.ToString();
		ModbusMaster.ReadHoldingRegister((ushort)Mode, Unit, Address, 1, ref values);
		if (values.Length == 1)
		{
			Value = values[0];
		}
		if (values.Length == 2 && 0 == 0)
		{
			ChangeBytesForRead(ref values);
			Value = values[0] + 256 * values[1];
			if (Value > 32768)
			{
				Value -= 65536;
			}
		}
		_0016_0002._009D_0002(10);
	}

	public void ReadInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107395012);
		ModeValue = Value.ToString();
		ModbusMaster.ReadInputRegister((ushort)Mode, Unit, Address, 1, ref values);
		if (values.Length == 1)
		{
			Value = values[0];
		}
		if (values.Length == 2 && 0 == 0)
		{
			ChangeBytesForRead(ref values);
			Value = values[0] + 256 * values[1];
			if (Value > 32768)
			{
				Value -= 65536;
			}
		}
		_0016_0002._009D_0002(10);
	}

	public void ReadDInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
	{
		byte[] values;
		bool flag3;
		if (0 == 0)
		{
			values = null;
			ReadWriteMode = _0019(107395031);
			ModeValue = Value.ToString();
			ModbusMaster.ReadInputRegister((ushort)Mode, Unit, Address, 2, ref values);
			int num = values.Length;
			int num2;
			while (true)
			{
				IL_005c:
				num2 = 1;
				if (num2 == 0)
				{
					break;
				}
				bool flag = num == num2;
				while (true)
				{
					if (flag)
					{
						Value = values[0];
					}
					if (false)
					{
						break;
					}
					bool flag2 = values.Length == 2;
					num = (flag2 ? 1 : 0);
					if (4 == 0)
					{
						goto IL_005c;
					}
					if (num != 0)
					{
						ChangeBytesForRead(ref values);
						Value = values[0] + 256 * values[1];
						if (7u != 0)
						{
							num = Value;
							num2 = 32768;
							if (num2 == 0)
							{
								goto end_IL_005c;
							}
							if (num <= num2)
							{
								goto IL_00be;
							}
						}
						Value -= 65536;
						if (false)
						{
							continue;
						}
					}
					goto IL_00be;
					IL_00be:
					num = values.Length;
					num2 = 4;
					goto end_IL_005c;
				}
				goto IL_00d4;
				continue;
				end_IL_005c:
				break;
			}
			flag3 = num == num2;
		}
		if (flag3)
		{
			ChangeBytesForRead(ref values);
			goto IL_00d4;
		}
		goto IL_00e4;
		IL_00d4:
		Value = _009A._0082_0002(values, 0);
		goto IL_00e4;
		IL_00e4:
		_0016_0002._009D_0002(10);
	}

	public void ReadReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref float Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107394986);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadInputRegister((ushort)Mode, Unit, Address, 2, ref values);
			while (3u != 0)
			{
				nint num = (nint)values.LongLength;
				if (0 == 0)
				{
					num = (int)num;
				}
				bool num2 = num == 4;
				while (true)
				{
					bool flag = num2;
					if (3u != 0)
					{
						if (false)
						{
							return;
						}
						num2 = flag;
						if (false)
						{
							continue;
						}
						if (!num2)
						{
							goto IL_0089;
						}
						ChangeBytesForRead(ref values);
					}
					Value = _009B._0083_0002(values, 0);
					if (1 == 0)
					{
						break;
					}
					goto IL_0089;
					IL_0089:
					_0016_0002._009D_0002(10);
					return;
				}
			}
		}
	}

	public void ReadHoldReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref float Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107395005);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadHoldingRegister((ushort)Mode, Unit, Address, 2, ref values);
			while (3u != 0)
			{
				nint num = (nint)values.LongLength;
				if (0 == 0)
				{
					num = (int)num;
				}
				bool num2 = num == 4;
				while (true)
				{
					bool flag = num2;
					if (3u != 0)
					{
						if (false)
						{
							return;
						}
						num2 = flag;
						if (false)
						{
							continue;
						}
						if (!num2)
						{
							goto IL_0089;
						}
						ChangeBytesForRead(ref values);
					}
					Value = _009B._0083_0002(values, 0);
					if (1 == 0)
					{
						break;
					}
					goto IL_0089;
					IL_0089:
					_0016_0002._009D_0002(10);
					return;
				}
			}
		}
	}

	public void ReadReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107394986);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadInputRegister((ushort)Mode, Unit, Address, 2, ref values);
			if (0 == 0)
			{
				nint num = (nint)values.LongLength;
				if (8u != 0)
				{
					num = (((int)num == 4) ? 1 : 0);
				}
				if ((int)num == 0)
				{
					goto IL_007e;
				}
			}
			goto IL_0064;
			IL_0064:
			ChangeBytesForRead(ref values);
			Value = _009B._0083_0002(values, 0);
			goto IL_007e;
			IL_007e:
			while (7u != 0)
			{
				_0016_0002._009D_0002(10);
				if (5u != 0)
				{
					if (0 == 0)
					{
						return;
					}
					continue;
				}
				goto IL_0064;
			}
		}
	}

	public void ReadHoldReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107395005);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadHoldingRegister((ushort)Mode, Unit, Address, 2, ref values);
			if (0 == 0)
			{
				nint num = (nint)values.LongLength;
				if (8u != 0)
				{
					num = (((int)num == 4) ? 1 : 0);
				}
				if ((int)num == 0)
				{
					goto IL_007e;
				}
			}
			goto IL_0064;
			IL_0064:
			ChangeBytesForRead(ref values);
			Value = _009B._0083_0002(values, 0);
			goto IL_007e;
			IL_007e:
			while (7u != 0)
			{
				_0016_0002._009D_0002(10);
				if (5u != 0)
				{
					if (0 == 0)
					{
						return;
					}
					continue;
				}
				goto IL_0064;
			}
		}
	}

	public void ReadLReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107394956);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadInputRegister((ushort)Mode, Unit, Address, 4, ref values);
			while (3u != 0)
			{
				nint num = (nint)values.LongLength;
				if (0 == 0)
				{
					num = (int)num;
				}
				bool num2 = num == 8;
				while (true)
				{
					bool flag = num2;
					if (3u != 0)
					{
						if (false)
						{
							return;
						}
						num2 = flag;
						if (false)
						{
							continue;
						}
						if (!num2)
						{
							goto IL_0089;
						}
						ChangeBytesForRead(ref values);
					}
					Value = _009C._0084_0002(values, 0);
					if (1 == 0)
					{
						break;
					}
					goto IL_0089;
					IL_0089:
					_0016_0002._009D_0002(10);
					return;
				}
			}
		}
	}

	public void ReadHoldLReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
	{
		byte[] values = null;
		ReadWriteMode = _0019(107394943);
		ModeValue = Value.ToString();
		while (true)
		{
			ModbusMaster.ReadHoldingRegister((ushort)Mode, Unit, Address, 4, ref values);
			while (3u != 0)
			{
				nint num = (nint)values.LongLength;
				if (0 == 0)
				{
					num = (int)num;
				}
				bool num2 = num == 8;
				while (true)
				{
					bool flag = num2;
					if (3u != 0)
					{
						if (false)
						{
							return;
						}
						num2 = flag;
						if (false)
						{
							continue;
						}
						if (!num2)
						{
							goto IL_0089;
						}
						ChangeBytesForRead(ref values);
					}
					Value = _009C._0084_0002(values, 0);
					if (1 == 0)
					{
						break;
					}
					goto IL_0089;
					IL_0089:
					_0016_0002._009D_0002(10);
					return;
				}
			}
		}
	}

	public void WriteCoil(ModbusModeTypes Mode, byte Unit, ushort Address, bool Value)
	{
		while (true)
		{
			if (0 == 0)
			{
				if (4u != 0)
				{
					ReadWriteMode = _0019(107394922);
					if (6 == 0)
					{
						break;
					}
					ModeValue = Value.ToString();
					ModbusMaster.WriteSingleCoils((ushort)Mode, Unit, Address, Value);
				}
				goto IL_003e;
			}
			goto IL_004a;
			IL_003e:
			_0016_0002._009D_0002(10);
			goto IL_004a;
			IL_004a:
			if (1 == 0)
			{
				continue;
			}
			if (0 == 0)
			{
				break;
			}
			goto IL_003e;
		}
	}

	public void WriteInt(ModbusModeTypes Mode, byte Unit, ushort Address, int Value)
	{
		if (false || uint.MaxValue != 0)
		{
			goto IL_0060;
		}
		goto IL_006a;
		IL_006a:
		ModeValue = Value.ToString();
		if (false)
		{
			goto IL_0060;
		}
		short num = (short)Value;
		byte[] by = _0084._0002_0002(num);
		ChangeBytesForWrite(ref by);
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, by);
		_0016_0002._009D_0002(10);
		return;
		IL_0060:
		ReadWriteMode = _0019(107394941);
		goto IL_006a;
	}

	public void WriteDInt(ModbusModeTypes Mode, byte Unit, ushort Address, int Value)
	{
		if (0 == 0)
		{
			do
			{
				ReadWriteMode = _0019(107394928);
			}
			while (false);
			ModeValue = Value.ToString();
		}
		int num = Value;
		byte[] by = _0082._009F(num);
		ChangeBytesForWrite(ref by);
		byte[] values = new byte[2]
		{
			by[0],
			by[1]
		};
		int num2 = 2;
		byte[] values2;
		do
		{
			byte[] array = new byte[num2];
			array[0] = by[2];
			array[1] = by[3];
			values2 = array;
			num2 = Address + 1;
		}
		while (false);
		int num3 = num2;
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, values2);
		_0016_0002._009D_0002(10);
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values);
		_0016_0002._009D_0002(10);
	}

	public void WriteReal(ModbusModeTypes Mode, byte Unit, ushort Address, float Value)
	{
		ReadWriteMode = _0019(107394883);
		byte[] by;
		if (3u != 0)
		{
			ModeValue = Value.ToString();
			float num = Value;
			byte[] array = _0080._009D(num);
			if (7u != 0)
			{
				by = array;
			}
		}
		ChangeBytesForWrite(ref by);
		int num2 = 2;
		byte[] values = default(byte[]);
		byte[] values2 = default(byte[]);
		do
		{
			if (num2 != 0 && num2 != 0)
			{
				byte[] array2 = new byte[num2];
				array2[0] = by[0];
				array2[1] = by[1];
				values = array2;
				num2 = 2;
				if (num2 != 0 && num2 != 0)
				{
					byte[] array3 = new byte[num2];
					array3[0] = by[2];
					array3[1] = by[3];
					values2 = array3;
					num2 = Address + 1;
				}
			}
		}
		while (6 == 0);
		int num3 = num2;
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, values2);
		_0016_0002._009D_0002(10);
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values);
		_0016_0002._009D_0002(10);
	}

	public void WriteReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
	{
		ReadWriteMode = _0019(107394883);
		byte[] by;
		if (3u != 0)
		{
			ModeValue = Value.ToString();
			float num = (float)Value;
			byte[] array = _0080._009D(num);
			if (7u != 0)
			{
				by = array;
			}
		}
		ChangeBytesForWrite(ref by);
		int num2 = 2;
		byte[] values = default(byte[]);
		byte[] values2 = default(byte[]);
		do
		{
			if (num2 != 0 && num2 != 0)
			{
				byte[] array2 = new byte[num2];
				array2[0] = by[0];
				array2[1] = by[1];
				values = array2;
				num2 = 2;
				if (num2 != 0 && num2 != 0)
				{
					byte[] array3 = new byte[num2];
					array3[0] = by[2];
					array3[1] = by[3];
					values2 = array3;
					num2 = Address + 1;
				}
			}
		}
		while (6 == 0);
		int num3 = num2;
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, values2);
		_0016_0002._009D_0002(10);
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values);
		_0016_0002._009D_0002(10);
	}

	public void WriteLReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
	{
		ReadWriteMode = _0019(107394902);
		byte[] by;
		byte[] values;
		if (0 == 0)
		{
			ModeValue = Value.ToString();
			double num = Value;
			by = _001F._009B(num);
			ChangeBytesForWrite(ref by);
			values = new byte[2]
			{
				by[0],
				by[1]
			};
		}
		int num2 = 2;
		int num3;
		do
		{
			byte[] array = new byte[num2];
			array[0] = by[2];
			array[1] = by[3];
			byte[] values2 = array;
			do
			{
				byte[] values3 = new byte[2]
				{
					by[4],
					by[5]
				};
				byte[] values4 = new byte[2]
				{
					by[6],
					by[7]
				};
				num3 = Address + 1;
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, values4);
				_0016_0002._009D_0002(10);
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values3);
				_0016_0002._009D_0002(10);
				num3 = Address + 2;
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values2);
			}
			while (false);
			_0016_0002._009D_0002(10);
			num2 = Address + 3;
		}
		while (2 == 0);
		num3 = num2;
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values);
		_0016_0002._009D_0002(10);
	}

	public void WriteHoldLReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
	{
		ReadWriteMode = _0019(107394341);
		byte[] by;
		byte[] values;
		if (0 == 0)
		{
			ModeValue = Value.ToString();
			double num = Value;
			by = _001F._009B(num);
			ChangeBytesForWrite(ref by);
			values = new byte[2]
			{
				by[0],
				by[1]
			};
		}
		int num2 = 2;
		int num3;
		do
		{
			byte[] array = new byte[num2];
			array[0] = by[2];
			array[1] = by[3];
			byte[] values2 = array;
			do
			{
				byte[] values3 = new byte[2]
				{
					by[4],
					by[5]
				};
				byte[] values4 = new byte[2]
				{
					by[6],
					by[7]
				};
				num3 = Address + 1;
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, values4);
				_0016_0002._009D_0002(10);
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values3);
				_0016_0002._009D_0002(10);
				num3 = Address + 2;
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values2);
			}
			while (false);
			_0016_0002._009D_0002(10);
			num2 = Address + 3;
		}
		while (2 == 0);
		num3 = num2;
		ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, (ushort)num3, values);
		_0016_0002._009D_0002(10);
	}

	public void WriteByte(ModbusModeTypes Mode, byte Unit, ushort Address, byte Value)
	{
		if (0 == 0)
		{
		}
		if (false)
		{
			goto IL_0034;
		}
		ReadWriteMode = _0019(107394352);
		goto IL_0072;
		IL_0072:
		ModeValue = Value.ToString();
		byte b = Value;
		byte[] by = _0084._0002_0002(b);
		goto IL_0034;
		IL_0034:
		while (true)
		{
			if (7u != 0)
			{
				if (3 == 0)
				{
					break;
				}
				ChangeBytesForWrite(ref by);
				if (false)
				{
					continue;
				}
				ModbusMaster.WriteSingleRegister((ushort)Mode, Unit, Address, by);
			}
			_0016_0002._009D_0002(10);
			return;
		}
		goto IL_0072;
	}

	static ModbusCommands()
	{
		while (true)
		{
			Strings.CreateGetStringDelegate(typeof(ModbusCommands));
			while (true)
			{
				ModbusCommands.m__0001 = _0019(107394307);
				if (false)
				{
					break;
				}
				_0002 = _0019(107394210);
				if (0 == 0)
				{
					return;
				}
			}
		}
	}
}

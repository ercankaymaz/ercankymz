using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using _0005;

namespace buComm.ModbusTCP;

public class Master
{
	public delegate void ResponseData(ushort id, byte unit, byte function, byte[] data);

	public delegate void ExceptionData(ushort id, byte unit, byte function, byte exception);

	public const byte excIllegalFunction = 1;

	public const byte excIllegalDataAdr = 2;

	public const byte excIllegalDataVal = 3;

	public const byte excSlaveDeviceFailure = 4;

	public const byte excAck = 5;

	public const byte excSlaveIsBusy = 6;

	public const byte excGatePathUnavailable = 10;

	public const byte excExceptionNotConnected = 253;

	public const byte excExceptionConnectionLost = 254;

	public const byte excExceptionTimeout = byte.MaxValue;

	private static ushort m__0001;

	private static ushort m__0002;

	private static bool m__0001;

	public static ushort localAdress;

	internal Socket _0001;

	internal byte[] _0001 = new byte[2048];

	internal Socket _0002;

	internal byte[] _0002 = new byte[2048];

	[CompilerGenerated]
	private ResponseData m__0001;

	[CompilerGenerated]
	internal ExceptionData _0001;

	public ushort timeout
	{
		get
		{
			return Master.m__0001;
		}
		set
		{
			Master.m__0001 = value;
		}
	}

	public ushort refresh
	{
		get
		{
			return Master.m__0002;
		}
		set
		{
			Master.m__0002 = value;
		}
	}

	public bool connected => Master.m__0001;

	public event ResponseData OnResponseData
	{
		[CompilerGenerated]
		add
		{
			ResponseData responseData = this.m__0001;
			while (true)
			{
				ResponseData responseData2 = responseData;
				while (true)
				{
					ResponseData obj = (ResponseData)_0016._008F(responseData2, value);
					ResponseData value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					responseData = Interlocked.CompareExchange(ref this.m__0001, value2, responseData2);
					if ((object)responseData != responseData2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			ResponseData responseData = this.m__0001;
			while (true)
			{
				ResponseData responseData2 = responseData;
				while (true)
				{
					ResponseData obj = (ResponseData)_0016._0090(responseData2, value);
					ResponseData value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					responseData = Interlocked.CompareExchange(ref this.m__0001, value2, responseData2);
					if ((object)responseData != responseData2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event ExceptionData OnException
	{
		[CompilerGenerated]
		add
		{
			ExceptionData exceptionData = this._0001;
			while (true)
			{
				ExceptionData exceptionData2 = exceptionData;
				while (true)
				{
					ExceptionData obj = (ExceptionData)_0016._008F(exceptionData2, value);
					ExceptionData value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					exceptionData = Interlocked.CompareExchange(ref this._0001, value2, exceptionData2);
					if ((object)exceptionData != exceptionData2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			ExceptionData exceptionData = this._0001;
			while (true)
			{
				ExceptionData exceptionData2 = exceptionData;
				while (true)
				{
					ExceptionData obj = (ExceptionData)_0016._0090(exceptionData2, value);
					ExceptionData value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					exceptionData = Interlocked.CompareExchange(ref this._0001, value2, exceptionData2);
					if ((object)exceptionData != exceptionData2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public Master()
	{
	}

	public Master(string ip, ushort port)
	{
		connect(ip, port);
	}

	public void connect(string ip, ushort port)
	{
		IPAddress iPAddress = default(IPAddress);
		do
		{
			try
			{
				int num = ((!_0017_0002._009E_0002(ip, ref iPAddress)) ? 1 : 0);
				do
				{
					if (num != 0)
					{
						IPHostEntry iPHostEntry = _0018_0002._009F_0002(ip);
						ip = global::_0005._007E_0011(_0019_0002._007E_0001_0003(iPHostEntry)[0]);
						if (false)
						{
							goto IL_00bc;
						}
					}
					this._0001 = new Socket(_001A_0002._007E_0002_0003(_0092._001A_0002(ip)), SocketType.Stream, ProtocolType.Tcp);
					_001B_0002._007E_0003_0003(this._0001, new IPEndPoint(_0092._001A_0002(ip), port));
					_009F._007E_0088_0002(this._0001, SocketOptionLevel.Socket, SocketOptionName.SendTimeout, Master.m__0001);
					goto IL_00bc;
					IL_00bc:
					_009F._007E_0088_0002(this._0001, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Master.m__0001);
					_009F._007E_0088_0002(this._0001, SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
					this._0002 = new Socket(_001A_0002._007E_0002_0003(_0092._001A_0002(ip)), SocketType.Stream, ProtocolType.Tcp);
					_001B_0002._007E_0003_0003(this._0002, new IPEndPoint(_0092._001A_0002(ip), port));
					_009F._007E_0088_0002(this._0002, SocketOptionLevel.Socket, SocketOptionName.SendTimeout, Master.m__0001);
					_009F._007E_0088_0002(this._0002, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Master.m__0001);
					_009F._007E_0088_0002(this._0002, SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
					num = 1;
				}
				while (num == 0);
				Master.m__0001 = (byte)num != 0;
			}
			catch (IOException ex)
			{
				do
				{
					Master.m__0001 = false;
				}
				while (false);
				throw ex;
			}
		}
		while (false);
	}

	public void disconnect()
	{
		Dispose();
	}

	~Master()
	{
		do
		{
			if (false)
			{
				continue;
			}
			try
			{
				if (6 == 0)
				{
					continue;
				}
				do
				{
					if (0 == 0)
					{
						Dispose();
					}
				}
				while (3 == 0);
			}
			finally
			{
				_0011._0080(this);
			}
		}
		while (false);
	}

	public void Dispose()
	{
		if (this._0001 != null)
		{
			if (global::_0003._007E_0006(this._0001))
			{
				try
				{
					do
					{
						_001C_0002._007E_0005_0003(this._0001, SocketShutdown.Both);
					}
					while (2u != 0 && false);
				}
				catch
				{
				}
				_0011._007E_0081(this._0001);
			}
			this._0001 = null;
		}
		do
		{
			IL_007f:
			bool flag = this._0002 != null;
			bool num = flag;
			if (2 == 0)
			{
				goto IL_00a2;
			}
			if (num)
			{
				goto IL_008f;
			}
			continue;
			IL_00a2:
			if (num)
			{
				try
				{
					_001C_0002._007E_0005_0003(this._0002, SocketShutdown.Both);
				}
				catch
				{
				}
				_0011._007E_0081(this._0002);
				if (false)
				{
					goto IL_008f;
				}
			}
			this._0002 = null;
			if (6 == 0)
			{
				goto IL_007f;
			}
			continue;
			IL_008f:
			bool flag2 = global::_0003._007E_0006(this._0002);
			num = flag2;
			goto IL_00a2;
		}
		while (7 == 0);
	}

	public void ReadCoils(ushort id, byte unit, ushort startAddress, ushort numInputs)
	{
		while (true)
		{
			if (4 == 0)
			{
				continue;
			}
			localAdress = startAddress;
			if (8u != 0)
			{
				_0005._0004._0001(this, _0005._0004._0001(startAddress, id, numInputs, this, (byte)1, unit), id);
				while (3 == 0)
				{
				}
				if (0 == 0)
				{
					break;
				}
			}
		}
	}

	public void ReadCoils(ushort id, byte unit, ushort startAddress, ushort numInputs, ref byte[] values)
	{
		if (uint.MaxValue != 0 && ((8u != 0) ? true : false))
		{
			if (7 == 0)
			{
				return;
			}
			localAdress = startAddress;
		}
		values = _0005._0004._0001(_0005._0004._0001(startAddress, id, numInputs, this, (byte)1, unit), id, this);
	}

	public void ReadDiscreteInputs(ushort id, byte unit, ushort startAddress, ushort numInputs)
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				goto IL_0004;
			}
			goto IL_001a;
			IL_001a:
			if (false)
			{
				continue;
			}
			if (0 == 0)
			{
				break;
			}
			goto IL_0004;
			IL_0004:
			if (false)
			{
				continue;
			}
			_0005._0004._0001(this, _0005._0004._0001(startAddress, id, numInputs, this, (byte)2, unit), id);
			goto IL_001a;
		}
	}

	public void ReadDiscreteInputs(ushort id, byte unit, ushort startAddress, ushort numInputs, ref byte[] values)
	{
		if (uint.MaxValue != 0 && ((8u != 0) ? true : false))
		{
			if (7 == 0)
			{
				return;
			}
			localAdress = startAddress;
		}
		values = _0005._0004._0001(_0005._0004._0001(startAddress, id, numInputs, this, (byte)2, unit), id, this);
	}

	public void ReadHoldingRegister(ushort id, byte unit, ushort startAddress, ushort numInputs)
	{
		while (true)
		{
			if (4 == 0)
			{
				continue;
			}
			localAdress = startAddress;
			if (8u != 0)
			{
				_0005._0004._0001(this, _0005._0004._0001(startAddress, id, numInputs, this, (byte)3, unit), id);
				while (3 == 0)
				{
				}
				if (0 == 0)
				{
					break;
				}
			}
		}
	}

	public void ReadHoldingRegister(ushort id, byte unit, ushort startAddress, ushort numInputs, ref byte[] values)
	{
		if (uint.MaxValue != 0 && ((8u != 0) ? true : false))
		{
			if (7 == 0)
			{
				return;
			}
			localAdress = startAddress;
		}
		values = _0005._0004._0001(_0005._0004._0001(startAddress, id, numInputs, this, (byte)3, unit), id, this);
	}

	public void ReadInputRegister(ushort id, byte unit, ushort startAddress, ushort numInputs)
	{
		while (true)
		{
			if (4 == 0)
			{
				continue;
			}
			localAdress = startAddress;
			if (8u != 0)
			{
				_0005._0004._0001(this, _0005._0004._0001(startAddress, id, numInputs, this, (byte)4, unit), id);
				while (3 == 0)
				{
				}
				if (0 == 0)
				{
					break;
				}
			}
		}
	}

	public void ReadInputRegister(ushort id, byte unit, ushort startAddress, ushort numInputs, ref byte[] values)
	{
		if (uint.MaxValue != 0 && ((8u != 0) ? true : false))
		{
			if (7 == 0)
			{
				return;
			}
			localAdress = startAddress;
		}
		values = _0005._0004._0001(_0005._0004._0001(startAddress, id, numInputs, this, (byte)4, unit), id, this);
	}

	public void WriteSingleCoils(ushort id, byte unit, ushort startAddress, bool OnOff)
	{
		int num = startAddress;
		while (true)
		{
			localAdress = (ushort)num;
			byte[] array = _0005._0004._0001(this, id, unit, startAddress, (ushort)1, (ushort)1, (byte)5);
			bool flag;
			if (0 == 0)
			{
				num = (OnOff ? 1 : 0);
				if (false)
				{
					continue;
				}
				flag = (byte)num != 0;
				goto IL_0021;
			}
			goto IL_003f;
			IL_0037:
			_0005._0004._0001(this, array, id);
			goto IL_003f;
			IL_0043:
			if (true)
			{
				break;
			}
			goto IL_0037;
			IL_003f:
			if (false)
			{
				goto IL_0021;
			}
			goto IL_0043;
			IL_0021:
			if (flag)
			{
				array[10] = byte.MaxValue;
				if (6 == 0)
				{
					goto IL_0043;
				}
			}
			else
			{
				array[10] = 0;
			}
			goto IL_0037;
		}
	}

	public void WriteSingleCoils(ushort id, byte unit, ushort startAddress, bool OnOff, ref byte[] result)
	{
		byte[] array;
		while (true)
		{
			int num = startAddress;
			bool flag;
			if (0 == 0 && 0 == 0)
			{
				localAdress = (ushort)num;
				if (0 == 0)
				{
					array = _0005._0004._0001(this, id, unit, startAddress, (ushort)1, (ushort)1, (byte)5);
					flag = OnOff;
				}
				goto IL_0024;
			}
			goto IL_0028;
			IL_0024:
			if (false)
			{
				continue;
			}
			num = (flag ? 1 : 0);
			goto IL_0028;
			IL_0028:
			if (num != 0)
			{
				array[10] = byte.MaxValue;
				if (0 == 0)
				{
					break;
				}
				goto IL_0024;
			}
			array[10] = 0;
			break;
		}
		result = _0005._0004._0001(array, id, this);
	}

	public void WriteMultipleCoils(ushort id, byte unit, ushort startAddress, ushort numBits, byte[] values)
	{
		int num;
		if (false || uint.MaxValue != 0)
		{
			num = startAddress;
			if (6 == 0)
			{
				goto IL_005e;
			}
			localAdress = (ushort)num;
		}
		num = _001D_0002._0006_0003(values.Length);
		goto IL_005e;
		IL_005e:
		byte b = (byte)num;
		byte[] array = _0005._0004._0001(this, id, unit, startAddress, numBits, (ushort)(byte)(b + 2), (byte)15);
		_0095._001E_0002(values, 0, array, 13, b);
		_0005._0004._0001(this, array, id);
	}

	public void WriteMultipleCoils(ushort id, byte unit, ushort startAddress, ushort numBits, byte[] values, ref byte[] result)
	{
		int num = startAddress;
		while (true)
		{
			localAdress = (ushort)num;
			while (true)
			{
				num = _001D_0002._0006_0003(values.Length);
				if (false || 8 == 0)
				{
					break;
				}
				byte b = (byte)num;
				byte[] array = _0005._0004._0001(this, id, unit, startAddress, numBits, (ushort)(byte)(b + 2), (byte)15);
				do
				{
					if (0 == 0)
					{
						_0095._001E_0002(values, 0, array, 13, b);
					}
				}
				while (false);
				result = _0005._0004._0001(array, id, this);
				if (2u != 0)
				{
					return;
				}
			}
		}
	}

	public void WriteSingleRegister(ushort id, byte unit, ushort startAddress, byte[] values)
	{
		localAdress = startAddress;
		byte[] array = _0005._0004._0001(this, id, unit, startAddress, (ushort)1, (ushort)1, (byte)6);
		array[10] = values[0];
		if (6u != 0)
		{
			array[11] = values[1];
			_0005._0004._0001(this, array, id);
		}
	}

	public void WriteSingleRegister(ushort id, byte unit, ushort startAddress, byte[] values, ref byte[] result)
	{
		localAdress = startAddress;
		byte[] array = _0005._0004._0001(this, id, unit, startAddress, (ushort)1, (ushort)1, (byte)6);
		array[10] = values[0];
		array[11] = values[1];
		result = _0005._0004._0001(array, id, this);
	}

	public void WriteMultipleRegister(ushort id, byte unit, ushort startAddress, byte[] values)
	{
		int num = startAddress;
		if (uint.MaxValue != 0)
		{
			localAdress = (ushort)num;
			goto IL_000e;
		}
		goto IL_003b;
		IL_003b:
		int num2;
		ushort num3;
		if (num != 0)
		{
			num2 = num3;
			if (false)
			{
				goto IL_0029;
			}
			int num4 = num2 + 1;
			if (0 == 0)
			{
				num4 = (ushort)num4;
			}
			num3 = (ushort)num4;
		}
		if (false)
		{
			goto IL_00c7;
		}
		byte[] array = _0005._0004._0001(this, id, unit, startAddress, _0098._0080_0002(num3 / 2), _0098._0080_0002(num3 + 2), (byte)16);
		_0095._001E_0002(values, 0, array, 13, values.Length);
		if (6u != 0)
		{
			_0005._0004._0001(this, array, id);
			return;
		}
		goto IL_000e;
		IL_000e:
		num3 = _0098._0080_0002(values.Length);
		num2 = num3;
		goto IL_0029;
		IL_0029:
		int num5 = 2;
		if (num5 != 0)
		{
			num2 %= num5;
			num5 = 0;
		}
		bool flag = num2 > num5;
		goto IL_00c7;
		IL_00c7:
		num = (flag ? 1 : 0);
		goto IL_003b;
	}

	public void WriteMultipleRegister(ushort id, byte unit, ushort startAddress, byte[] values, ref byte[] result)
	{
		if (true)
		{
			localAdress = startAddress;
			goto IL_000e;
		}
		goto IL_00d1;
		IL_0052:
		ushort num;
		byte[] array = _0005._0004._0001(this, id, unit, startAddress, _0098._0080_0002(num / 2), _0098._0080_0002(num + 2), (byte)16);
		_0095._001E_0002(values, 0, array, 13, values.Length);
		result = _0005._0004._0001(array, id, this);
		if (8 == 0)
		{
			goto IL_00d1;
		}
		if (4u != 0)
		{
			return;
		}
		goto IL_000e;
		IL_000e:
		int num2 = _0098._0080_0002(values.Length);
		do
		{
			if (7u != 0)
			{
				num = (ushort)num2;
			}
			num2 = num;
		}
		while (1 == 0);
		int num3;
		int num4;
		if (0 == 0)
		{
			num3 = num2 % 2;
			num4 = 0;
			if (num4 != 0)
			{
				goto IL_004b;
			}
			bool flag = num3 > num4;
			num2 = (flag ? 1 : 0);
		}
		if (num2 == 0)
		{
			goto IL_0052;
		}
		goto IL_00d1;
		IL_00d1:
		num3 = num;
		num4 = 1;
		goto IL_004b;
		IL_004b:
		num = (ushort)(num3 + num4);
		goto IL_0052;
	}

	public void ReadWriteMultipleRegister(ushort id, byte unit, ushort startReadAddress, ushort numInputs, ushort startWriteAddress, byte[] values)
	{
		ushort num;
		if (0 == 0)
		{
			localAdress = startReadAddress;
			if (false)
			{
				goto IL_0068;
			}
			num = _0098._0080_0002(values.Length);
			goto IL_00a7;
		}
		goto IL_00b3;
		IL_004d:
		byte[] array = _0005._0004._0001(this, id, unit, startReadAddress, numInputs, startWriteAddress, _0098._0080_0002(num / 2));
		goto IL_0068;
		IL_00b3:
		bool flag;
		int num2;
		if (flag)
		{
			num2 = num;
			goto IL_0045;
		}
		goto IL_004d;
		IL_00a7:
		int num3 = num;
		int num4 = 2;
		if (num4 != 0)
		{
			num3 %= num4;
			num4 = 0;
		}
		num2 = ((num3 > num4) ? 1 : 0);
		if (false)
		{
			goto IL_0045;
		}
		flag = (byte)num2 != 0;
		goto IL_00b3;
		IL_0068:
		_0095._001E_0002(values, 0, array, 17, values.Length);
		if (-1 == 0)
		{
			goto IL_00a7;
		}
		_0005._0004._0001(this, array, id);
		return;
		IL_0045:
		if (0 == 0)
		{
			num2++;
		}
		num = (ushort)num2;
		goto IL_004d;
	}

	public void ReadWriteMultipleRegister(ushort id, byte unit, ushort startReadAddress, ushort numInputs, ushort startWriteAddress, byte[] values, ref byte[] result)
	{
		if (3u != 0)
		{
			goto IL_0083;
		}
		goto IL_00a0;
		IL_0083:
		int num = startReadAddress;
		goto IL_0006;
		IL_0006:
		localAdress = (ushort)num;
		if (6 == 0)
		{
			goto IL_0083;
		}
		ushort num2;
		if (3u != 0)
		{
			num2 = _0098._0080_0002(values.Length);
			goto IL_00a0;
		}
		goto IL_00ac;
		IL_0044:
		int num3;
		num2 = (ushort)num3;
		goto IL_0047;
		IL_0047:
		byte[] array = _0005._0004._0001(this, id, unit, startReadAddress, numInputs, startWriteAddress, _0098._0080_0002(num2 / 2));
		_0095._001E_0002(values, 0, array, 17, values.Length);
		result = _0005._0004._0001(array, id, this);
		return;
		IL_00a0:
		num3 = num2;
		int num4;
		if (5u != 0)
		{
			num4 = 2;
			goto IL_0030;
		}
		goto IL_0044;
		IL_00ac:
		bool flag;
		if (flag)
		{
			num3 = num2;
			num4 = 1;
			if (num4 == 0)
			{
				goto IL_0030;
			}
			num3 += num4;
			goto IL_0044;
		}
		goto IL_0047;
		IL_0030:
		num = num3 % num4;
		if (false)
		{
			goto IL_0006;
		}
		flag = num > 0;
		goto IL_00ac;
	}

	internal void _0001(IAsyncResult P_0)
	{
		if (!global::_0003._007E_0007(P_0))
		{
			_0005._0004._0001(this, ushort.MaxValue, byte.MaxValue, byte.MaxValue, (byte)100);
		}
	}

	internal void _0002(IAsyncResult P_0)
	{
		if (!global::_0003._007E_0007(P_0))
		{
			_0005._0004._0001(this, (ushort)255, byte.MaxValue, byte.MaxValue, (byte)254);
		}
		ushort num = _0005._0004._0001(_001E_0002._0007_0003(this._0001, 0));
		byte b = this._0001[6];
		byte b2 = this._0001[7];
		byte num2 = b2;
		int num3 = 5;
		while (true)
		{
			byte[] array;
			if (num2 >= num3)
			{
				num2 = b2;
				num3 = 23;
				if (num3 == 0)
				{
					continue;
				}
				if (num2 != num3)
				{
					if (0 == 0)
					{
						array = new byte[2];
						_0095._001E_0002(this._0001, 10, array, 0, 2);
						goto IL_00d4;
					}
					break;
				}
			}
			array = new byte[this._0001[8]];
			_0095._001E_0002(this._0001, 9, array, 0, this._0001[8]);
			goto IL_00d4;
			IL_00d4:
			if (b2 > 128)
			{
				b2 -= 128;
				_0005._0004._0001(this, num, b, b2, this._0001[8]);
			}
			else if (this.m__0001 != null)
			{
				this.m__0001(num, b, b2, array);
			}
			break;
		}
	}

	static Master()
	{
		Master.m__0001 = 500;
		Master.m__0002 = 10;
		Master.m__0001 = false;
		localAdress = 0;
	}
}

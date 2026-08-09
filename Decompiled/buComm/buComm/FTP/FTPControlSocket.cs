using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buComm.FTP;

public class FTPControlSocket
{
	public static IPHostEntry remoteHostEntry;

	internal bool _0001 = false;

	internal TextWriter _0001 = Console.Out;

	internal int _0001 = -1;

	internal Socket _0001 = null;

	internal StreamWriter _0001 = null;

	internal StreamReader _0001 = null;

	[NonSerialized]
	internal static GetString _008F;

	public FTPControlSocket(string remoteHost, int controlPort, StreamWriter log, int timeout)
	{
		if (FTPConnect.ftpConnectionProperties.UseRevolveDNS)
		{
			remoteHostEntry = Dns.GetHostEntry(remoteHost);
			IPAddress[] addressList = remoteHostEntry.AddressList;
			_0005._0004._0001(addressList[0], timeout, controlPort, log, this);
		}
		else
		{
			IPAddress iPAddress = IPAddress.Parse(FTPConnect.ftpConnectionProperties.IP);
			_0005._0004._0001(iPAddress, timeout, controlPort, log, this);
		}
	}

	public FTPControlSocket(IPAddress remoteAddr, int controlPort, StreamWriter log, int timeout)
	{
		_0005._0004._0001(remoteAddr, timeout, controlPort, log, this);
	}

	public void Logout()
	{
		if (0 == 0)
		{
			if (0 == 0)
			{
			}
			_0011._007E_0087(this._0001);
			this._0001 = null;
			goto IL_001e;
		}
		goto IL_0041;
		IL_001e:
		_0011 obj = _0011._007E_0088;
		StreamWriter streamWriter = this._0001;
		if (6u != 0)
		{
			obj(streamWriter);
		}
		if (2u != 0)
		{
		}
		_0011._007E_0086(this._0001);
		goto IL_0041;
		IL_0041:
		if (0 == 0)
		{
			return;
		}
		goto IL_001e;
	}

	protected internal byte[] ToByteArray(ushort val)
	{
		return new byte[2]
		{
			(byte)(val >> 8),
			(byte)(val & 0xFF)
		};
	}

	internal Socket _0001()
	{
		string text = _0005._0004._0001(this, _008F(107393879));
		_0005._0004._0001(_008F(107393838), text, this);
		int num = _0088_0002._007E_0018_0003(text, '(');
		int num2 = _0088_0002._007E_0018_0003(text, ')');
		int num3;
		int num4;
		if (num < 0)
		{
			num3 = num2;
			num4 = 0;
			goto IL_0064;
		}
		goto IL_00a4;
		IL_00a4:
		IPEndPoint iPEndPoint2 = default(IPEndPoint);
		Socket socket2 = default(Socket);
		while (true)
		{
			IL_00a4_2:
			string text2 = _009E._007E_0087_0002(text, num + 1, num2 - (num + 1));
			int[] array = new int[6];
			int num5 = _000E._007E_0019(text2);
			int num6 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			int num7 = 0;
			while (true)
			{
				if (num7 < num5)
				{
					num3 = num6;
					num4 = 6;
					if (num4 == 0)
					{
						break;
					}
					if (num3 <= num4)
					{
						goto IL_00df;
					}
				}
				string text3 = _0019._0095(new string[7]
				{
					array[0].ToString(),
					_008F(107393823),
					array[1].ToString(),
					_008F(107393823),
					array[2].ToString(),
					_008F(107393823),
					array[3].ToString()
				});
				int port = (array[4] << 8) + array[5];
				Socket result;
				if (FTPConnect.ftpConnectionProperties.UseRevolveDNS)
				{
					if (false)
					{
						goto IL_03a9;
					}
					bool num8 = remoteHostEntry == null;
					do
					{
						bool flag = num8;
						num8 = flag;
					}
					while (false);
					if (num8)
					{
						remoteHostEntry = _0018_0002._009F_0002(text3);
						if (6 == 0)
						{
							goto IL_00a4_2;
						}
						if (1 == 0)
						{
							goto IL_03b7;
						}
					}
					IPEndPoint iPEndPoint = new IPEndPoint(_0019_0002._007E_0001_0003(remoteHostEntry)[0], port);
					Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					_0005._0004._0001(this, socket, this._0001);
					_001B_0002._007E_0003_0003(socket, iPEndPoint);
					result = socket;
					if (4 == 0)
					{
						goto IL_00df;
					}
					goto IL_03cd;
				}
				IPAddress address = _0092._001A_0002(FTPConnect.ftpConnectionProperties.IP);
				iPEndPoint2 = new IPEndPoint(address, port);
				int num9 = 2;
				goto IL_039a;
				IL_0163:
				try
				{
					array[num6++] = _008C_0002._001E_0003(global::_0005._007E_0011(stringBuilder));
					_0091._007E_0018_0002(stringBuilder, 0);
				}
				catch (FormatException ex)
				{
					_0082_0002._0013_0003(_0002._0003(_008F(107393856), text), _008F(107394600), global::_0005._007E_0012(_0081_0002._0012_0003()));
					global::_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _0002._0003(_008F(107393856), text));
				}
				goto IL_0223;
				IL_00df:
				char c = _0089_0002._007E_001A_0003(text2, num7);
				if (_008A_0002._001C_0003(c))
				{
					_008B_0002._007E_001D_0003(stringBuilder, c);
				}
				else
				{
					bool flag2 = c != ',';
					num9 = (flag2 ? 1 : 0);
					if (false)
					{
						goto IL_039a;
					}
					if (num9 != 0)
					{
						throw new FTPException(_0002._0003(_008F(107393856), text));
					}
				}
				if (c != ',')
				{
					num9 = num7 + 1;
					goto IL_0152;
				}
				goto IL_0163;
				IL_039a:
				if (num9 == 0)
				{
					goto IL_0152;
				}
				socket2 = new Socket((AddressFamily)num9, SocketType.Stream, ProtocolType.Tcp);
				goto IL_03a9;
				IL_03a9:
				_0005._0004._0001(this, socket2, this._0001);
				goto IL_03b7;
				IL_03cd:
				return result;
				IL_0152:
				if (num9 != num5)
				{
					goto IL_0223;
				}
				goto IL_0163;
				IL_0223:
				num7++;
				continue;
				IL_03b7:
				_001B_0002._007E_0003_0003(socket2, iPEndPoint2);
				result = socket2;
				goto IL_03cd;
			}
			break;
		}
		goto IL_0064;
		IL_0064:
		if (num3 < num4)
		{
			num = _008C._007E_0011_0002(global::_0005._007E_0014(text), _008F(107393833)) + 4;
			num2 = _000E._007E_0019(text);
		}
		goto IL_00a4;
	}

	static FTPControlSocket()
	{
		Strings.CreateGetStringDelegate(typeof(FTPControlSocket));
	}
}

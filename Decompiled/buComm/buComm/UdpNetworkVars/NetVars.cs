using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buComm.UdpNetworkVars;

public class NetVars
{
	private int _0001 = 1;

	private int _0002 = 1202;

	private int _0003 = 0;

	internal List<CDataTypeCollection> _0001 = new List<CDataTypeCollection>();

	private string _0001 = _0081(107395215);

	private ArrayList _0001 = new ArrayList();

	private ushort _0001 = 0;

	private UdpClient _0001;

	private IPEndPoint _0001;

	private CTelegram _0001;

	[NonSerialized]
	internal static GetString _0081;

	public int CobID
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
		}
	}

	public int Port
	{
		get
		{
			return _0002;
		}
		set
		{
			_0002 = value;
		}
	}

	public string IPAdress
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
		}
	}

	public List<CDataTypeCollection> dataTypeCollection
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
			_0003 = dataTypeCollection.Count;
		}
	}

	public CTelegram CTelegramReceive => _0001;

	public int NumberOfTags
	{
		get
		{
			return _0003;
		}
		set
		{
			_0003 = value;
		}
	}

	public void disconnect()
	{
		while (true)
		{
			bool num = this._0001 == null;
			do
			{
				if (2u != 0)
				{
					bool flag;
					if (7u != 0)
					{
						flag = num;
					}
					num = flag;
				}
			}
			while (false);
			if (!num)
			{
				goto IL_001e;
			}
			if (false)
			{
				continue;
			}
			goto IL_002d;
			IL_002d:
			if (8u != 0)
			{
				break;
			}
			goto IL_001e;
			IL_001e:
			_0011._007E_001F(this._0001);
			goto IL_002d;
		}
	}

	public void connect()
	{
		while (true)
		{
			if (2u != 0)
			{
				goto IL_0004;
			}
			goto IL_0058;
			IL_0058:
			if (0 == 0)
			{
				break;
			}
			goto IL_0004;
			IL_0004:
			if (4u != 0)
			{
				this._0001 = new UdpClient(_0002);
				if (6 == 0)
				{
					goto IL_0058;
				}
				_0091._007E_0017_0002(_0090._007E_0015_0002(this._0001), 15000);
			}
			if (-1 == 0)
			{
				continue;
			}
			this._0001 = new IPEndPoint(_0092._001A_0002(this._0001), _0002);
			goto IL_0058;
		}
	}

	public ArrayList ReadValues()
	{
		_0003 = this._0001.Count;
		DateTime dateTime = _0093._001B_0002();
		byte[] array = new byte[12];
		bool flag = false;
		bool flag2 = true;
		int num = 0;
		this._0001 = new ArrayList();
		if (this._0001 == null)
		{
			connect();
		}
		while (true)
		{
			bool num2 = array[8] != this._0001 || array == null || flag2;
			int num3 = ((!flag) ? 1 : 0);
			if (false)
			{
				goto IL_0329;
			}
			int num4 = (num2 ? 1 : 0) | num3;
			int num5 = _000E._007E_001A(this._0001);
			goto IL_0812;
			IL_0396:
			bool num6;
			CDataTypeCollection cDataTypeCollection;
			int num7;
			int num8;
			int num9;
			checked
			{
				if (num6 != 0)
				{
					cDataTypeCollection = this._0001[_000E._007E_001A(this._0001)];
					if (cDataTypeCollection.DataTypes == DataTypes.booltype)
					{
						_0097._007E_007F_0002(this._0001, _0096._001F_0002(array[num7]));
						num4 = num7;
						num5 = 1;
						if (num5 == 0)
						{
							goto IL_0812;
						}
						num7 = num4 + num5;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.bytetype)
					{
						_0097._007E_007F_0002(this._0001, array[num7]);
						num7++;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.wordtype)
					{
						_0097._007E_007F_0002(this._0001, _0098._0080_0002(array[num7] | (array[num7 + 1] << 8)));
						num7 += 2;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.dwordtype)
					{
						unchecked
						{
							_0097._007E_007F_0002(this._0001, (uint)checked(array[num7] | (array[num7 + 1] << 8) | (array[num7 + 2] << 16) | (array[num7 + 3] << 24)));
						}
						num7 += 4;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.sinttype)
					{
						_0097._007E_007F_0002(this._0001, (sbyte)array[num7]);
						num8 = num7;
						num9 = 1;
						if (num9 == 0)
						{
							goto IL_07a7;
						}
						num7 = num8 + num9;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.usintType)
					{
						goto IL_0518;
					}
					goto IL_053c;
				}
			}
			int num10 = num10 + 1;
			goto IL_079a;
			IL_0329:
			if ((num2 && num3 != 0) & (array[8] == this._0001))
			{
				flag = false;
				_0011._007E_007F(this._0001);
			}
			if (array[8] == this._0001 && flag)
			{
				num10 = 0;
				goto IL_079a;
			}
			goto IL_07b3;
			IL_053c:
			bool flag3 = cDataTypeCollection.DataTypes == DataTypes.inttype;
			bool num11 = flag3;
			checked
			{
				do
				{
					if (num11)
					{
						_0097._007E_007F_0002(this._0001, _0099._0081_0002(array, num7));
						num7 += 2;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.uinttype)
					{
						_0097._007E_007F_0002(this._0001, _0098._0080_0002(array[num7] | (array[num7 + 1] << 8)));
						num7 += 2;
					}
					if (cDataTypeCollection.DataTypes == DataTypes.udinttype)
					{
						unchecked
						{
							_0097._007E_007F_0002(this._0001, (uint)checked(array[num7] | (array[num7 + 1] << 8) | (array[num7 + 2] << 16) | (array[num7 + 3] << 24)));
						}
						num7 += 4;
					}
					num11 = cDataTypeCollection.DataTypes == DataTypes.dinttype;
				}
				while (8 == 0);
				if (num11)
				{
					_0097._007E_007F_0002(this._0001, _009A._0082_0002(array, num7));
					num7 += 4;
				}
				if (cDataTypeCollection.DataTypes == DataTypes.realtype)
				{
					_0097._007E_007F_0002(this._0001, _009B._0083_0002(array, num7));
					num7 += 4;
				}
				if (cDataTypeCollection.DataTypes == DataTypes.lrealtype)
				{
					_0097._007E_007F_0002(this._0001, _009C._0084_0002(array, num7));
					num7 += 8;
				}
				num6 = cDataTypeCollection.DataTypes == DataTypes.stringtype;
				if (false)
				{
					goto IL_0396;
				}
				if (num6)
				{
					string text = _009D._007E_0086_0002(_0017._0093(), array, num7, cDataTypeCollection.FieldLength);
					int num12 = _000E._007E_0019(text);
					for (int i = 0; i < _000E._007E_0019(text); i++)
					{
						if (array[num7 + i] == 0)
						{
							num12 = i;
							break;
						}
					}
					_0097._007E_007F_0002(this._0001, _009E._007E_0087_0002(text, 0, num12));
					num7 = num7 + cDataTypeCollection.FieldLength + 1;
				}
				num10++;
				goto IL_079a;
			}
			IL_07b3:
			ushort subIndex;
			if ((_0005._0004._0001(this, this._0001.Count) <= subIndex && flag) & (array[8] == this._0001))
			{
				flag2 = false;
			}
			continue;
			IL_0518:
			_0097._007E_007F_0002(this._0001, array[num7]);
			num7 = checked(num7 + 1);
			goto IL_053c;
			IL_079a:
			num8 = num10;
			num9 = _0001.Items;
			goto IL_07a7;
			IL_07a7:
			if (num8 < num9)
			{
				num6 = _000E._007E_001A(this._0001) <= this._0001.Count - 1;
				goto IL_0396;
			}
			goto IL_07b3;
			IL_0812:
			if (((uint)num4 | ((num5 != this._0001.Count) ? 1u : 0u)) == 0)
			{
				break;
			}
			checked
			{
				while (true)
				{
					long num13 = _0093._001B_0002().Ticks;
					long num14 = dateTime.Ticks;
					if (7u != 0)
					{
						num13 -= num14;
						num14 = 100000000L;
					}
					if (num13 > num14)
					{
						throw new Exception(_0081(107395784));
					}
					array = _0094._007E_001C_0002(this._0001, ref this._0001);
					num7 = 20;
					_0001 = new CTelegram();
					_0095._001D_0002(array, 0, _0001.Identity, 0, 4);
					uint[] array2 = new uint[1];
					ushort[] array3 = new ushort[1];
					byte[] array4 = new byte[1];
					if (6u != 0)
					{
						_0095._001D_0002(array, 4, array2, 0, 4);
						_0001.ID = array2[0];
						_0095._001D_0002(array, 8, array3, 0, 2);
						_0001.Index = array3[0];
						_0095._001D_0002(array, 10, array3, 0, 2);
						_0001.SubIndex = array3[0];
						subIndex = _0001.SubIndex;
						_0095._001D_0002(array, 12, array3, 0, 2);
						_0001.Items = array3[0];
						_0095._001D_0002(array, 14, array3, 0, 2);
						_0001.Length = array3[0];
						_0095._001D_0002(array, 16, array3, 0, 2);
						_0001.Counter = array3[0];
						_0095._001D_0002(array, 18, array4, 0, 1);
						_0001.Flags = array4[0];
						_0095._001D_0002(array, 19, array4, 0, 1);
						_0001.Checksum = array4[0];
						_0001.Data = new byte[array.Length - 20];
						_0095._001D_0002(array, 20, _0001.Data, 0, _0001.Data.Length);
						if (!((_0001.SubIndex == 0) & (array[8] == this._0001)))
						{
							break;
						}
					}
					flag = true;
					_0011._007E_007F(this._0001);
					if (0 == 0)
					{
						num = 0;
						break;
					}
				}
			}
			if ((checked(num + 1) != _0001.SubIndex && num != 0) & (array[8] == this._0001))
			{
				flag = false;
				if (false)
				{
					goto IL_0518;
				}
				_0011._007E_007F(this._0001);
			}
			if (this._0001 == _0001.Index)
			{
				num = _0001.SubIndex;
			}
			num2 = num != checked(_0005._0004._0001(this, _000E._007E_001A(this._0001)) + 1);
			num3 = num;
			goto IL_0329;
		}
		return this._0001;
	}

	public void SendValues()
	{
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		_009F._007E_0088_0002(socket, SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
		checked
		{
			int num = _0005._0004._0001(this, this._0001.Count) + 1;
			int num2 = 0;
			int num3 = 0;
			_0003 = this._0001.Count;
			CTelegram cTelegram = new CTelegram();
			IPEndPoint iPEndPoint = new IPEndPoint(_0092._001A_0002(this._0001), _0002);
			_0001_0002._007E_0089_0002(socket, true);
			int num4 = 0;
			byte[] array = default(byte[]);
			uint[] array2 = default(uint[]);
			int[] array3 = default(int[]);
			ushort[] array4 = default(ushort[]);
			short[] array5 = default(short[]);
			sbyte[] array7 = default(sbyte[]);
			float[] array8 = default(float[]);
			double[] array9 = default(double[]);
			int num8 = default(int);
			int num9 = default(int);
			byte[] array11 = default(byte[]);
			char[] array10 = default(char[]);
			int num13 = default(int);
			while (num4 < num)
			{
				int num5;
				unchecked
				{
					this._0001 = (ushort)((this._0001 < ushort.MaxValue) ? checked((ushort)(unchecked((uint)this._0001) + 1u)) : 0);
					num5 = 0;
				}
				num3++;
				int num6 = num5 + 1;
				while (true)
				{
					int num7;
					if ((_0005._0004._0001(this, num3) == num2) & (num3 != this._0001.Count))
					{
						num6++;
						num7 = num3;
						if (0 == 0)
						{
							num3 = num7 + 1;
							continue;
						}
					}
					else
					{
						if (_0005._0004._0001(this, num3) <= num2)
						{
							break;
						}
						num3--;
						num7 = num6 - 1;
					}
					num6 = num7;
					break;
				}
				if (8 == 0)
				{
					goto IL_0677;
				}
				array = new byte[20];
				array2 = new uint[1];
				array3 = new int[1];
				array4 = new ushort[1];
				array5 = new short[1];
				byte[] array6 = new byte[1];
				array7 = new sbyte[1];
				array8 = new float[1];
				array9 = new double[1];
				_0095._001D_0002(cTelegram.Identity, 0, array, 0, 4);
				array2[0] = cTelegram.ID;
				_0095._001D_0002(array2, 0, array, 4, 4);
				cTelegram.Index = (ushort)this._0001;
				if (false)
				{
					goto IL_040a;
				}
				array4[0] = cTelegram.Index;
				_0095._001D_0002(array4, 0, array, 8, 2);
				cTelegram.SubIndex = (ushort)num2;
				array4[0] = cTelegram.SubIndex;
				_0095._001D_0002(array4, 0, array, 10, 2);
				cTelegram.Items = (ushort)num6;
				array4[0] = cTelegram.Items;
				_0095._001D_0002(array4, 0, array, 12, 2);
				cTelegram.Counter = this._0001;
				array4[0] = cTelegram.Counter;
				_0095._001D_0002(array4, 0, array, 16, 2);
				array[18] = cTelegram.Flags;
				array[19] = cTelegram.Checksum;
				num8 = 0;
				num9 = 0;
				goto IL_081b;
				IL_040a:
				if (true)
				{
					goto IL_0812;
				}
				break;
				IL_0677:
				num8 += 4;
				goto IL_0812;
				IL_0812:
				num9++;
				goto IL_081b;
				IL_0570:
				int num10;
				int num11;
				num8 = num10 + num11;
				goto IL_0812;
				IL_081b:
				if (num9 < num6)
				{
					while (true)
					{
						int num14;
						nint num15;
						switch (this._0001[num9 + _0005._0004._0001(this, num3)].DataTypes)
						{
						case DataTypes.booltype:
							Array.Resize(ref array, array.Length + 1);
							array[20 + num8] = _0002_0002._008A_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							num8++;
							goto IL_0812;
						case DataTypes.bytetype:
							Array.Resize(ref array, array.Length + 1);
							array[20 + num8] = _0002_0002._008A_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							num8++;
							goto IL_0812;
						case DataTypes.wordtype:
							Array.Resize(ref array, array.Length + 2);
							array4[0] = _0003_0002._008B_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array4, 0, array, 20 + num8, 2);
							num8 += 2;
							goto IL_0812;
						case DataTypes.dwordtype:
							break;
						case DataTypes.sinttype:
							Array.Resize(ref array, array.Length + 1);
							array7[0] = _0005_0002._008D_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array7, 0, array, 20 + num8, 1);
							num8++;
							goto IL_0812;
						case DataTypes.usintType:
							if (true)
							{
								Array.Resize(ref array, array.Length + 1);
								array[20 + num8] = _0002_0002._008A_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
								num14 = num8;
								num15 = 1;
								if (1 == 0)
								{
									goto IL_07e3;
								}
								num8 = num14 + 1;
							}
							goto IL_0812;
						case DataTypes.inttype:
							Array.Resize(ref array, array.Length + 2);
							array5[0] = _0083._0001_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							if (1 == 0)
							{
								continue;
							}
							_0095._001D_0002(array5, 0, array, 20 + num8, 2);
							num8 += 2;
							goto IL_0812;
						case DataTypes.uinttype:
							Array.Resize(ref array, array.Length + 2);
							goto IL_052e;
						case DataTypes.dinttype:
							Array.Resize(ref array, array.Length + 4);
							array3[0] = global::_0081._009E(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array3, 0, array, 20 + num8, 4);
							num8 += 4;
							goto IL_0812;
						case DataTypes.udinttype:
							Array.Resize(ref array, array.Length + 4);
							array2[0] = _0004_0002._008C_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array2, 0, array, 20 + num8, 4);
							num8 += 4;
							goto IL_0812;
						case DataTypes.realtype:
							goto IL_062b;
						case DataTypes.lrealtype:
							Array.Resize(ref array, array.Length + 8);
							array9[0] = _001D._0099(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array9, 0, array, 20 + num8, 8);
							num8 += 8;
							if (false)
							{
								goto IL_052e;
							}
							goto IL_0812;
						case DataTypes.stringtype:
						{
							array10 = new char[this._0001[num9 + _0005._0004._0001(this, num3)].FieldLength + 1];
							array11 = new byte[this._0001[num9 + _0005._0004._0001(this, num3)].FieldLength + 1];
							array10 = _0006_0002._007E_008E_0002(_0088._0005_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue));
							int num12 = array10.Length;
							if (array10.Length <= this._0001[num9 + _0005._0004._0001(this, num3)].FieldLength)
							{
								Array.Resize(ref array10, this._0001[num9 + _0005._0004._0001(this, num3)].FieldLength + 1);
							}
							array10[num12] = '\0';
							Array.Resize(ref array, array.Length + array10.Length);
							num13 = 0;
							goto IL_07de;
						}
						default:
							goto IL_0812;
							IL_052e:
							array4[0] = _0003_0002._008B_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
							_0095._001D_0002(array4, 0, array, 20 + num8, 2);
							num10 = num8;
							num11 = 2;
							goto IL_0570;
							IL_07de:
							num14 = num13;
							num15 = unchecked((nint)array10.LongLength);
							goto IL_07e3;
							IL_07e3:
							if (num14 < unchecked((int)num15))
							{
								array11[num13] = (byte)array10[num13];
								num13++;
								goto IL_07de;
							}
							_0095._001D_0002(array11, 0, array, 20 + num8, array11.Length);
							num8 += array10.Length;
							goto IL_0812;
						}
						break;
					}
					Array.Resize(ref array, array.Length + 4);
					array2[0] = _0004_0002._008C_0002(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
					_0095._001D_0002(array2, 0, array, 20 + num8, 4);
					num8 += 4;
					goto IL_040a;
				}
				cTelegram.Length = (ushort)array.Length;
				array4[0] = cTelegram.Length;
				_0095._001D_0002(array4, 0, array, 14, 2);
				_0007_0002._007E_008F_0002(socket, array, iPEndPoint);
				num2++;
				num10 = num4;
				num11 = 1;
				if (num11 != 0)
				{
					num4 = num10 + num11;
					continue;
				}
				goto IL_0570;
				IL_062b:
				Array.Resize(ref array, array.Length + 4);
				array8[0] = (float)_001D._0099(this._0001[num9 + _0005._0004._0001(this, num3)].SendValue);
				_0095._001D_0002(array8, 0, array, 20 + num8, 4);
				goto IL_0677;
			}
		}
	}

	public void CreateGVLFile(string fileName)
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395699));
		XmlNode xmlNode;
		if (true)
		{
			xmlNode = xmlElement;
		}
		_000E_0002._007E_0091_0002(xmlDocument, xmlNode);
		XmlNode xmlNode2 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395694));
		string text = _0081(107395645);
		for (int i = 0; i < this._0001.Count; i = checked(i + 1))
		{
			text = ((this._0001[i].VariableName == null) ? _008E._0013_0002(text, _0081(107395655), i.ToString()) : _008E._0013_0002(text, _0081(107395660), this._0001[i].VariableName));
			switch (this._0001[i].DataTypes)
			{
			case DataTypes.booltype:
				text = global::_0002._0003(text, _0081(107396150));
				break;
			case DataTypes.bytetype:
				text = global::_0002._0003(text, _0081(107396137));
				break;
			case DataTypes.wordtype:
				text = global::_0002._0003(text, _0081(107396092));
				break;
			case DataTypes.dwordtype:
				text = global::_0002._0003(text, _0081(107396111));
				break;
			case DataTypes.sinttype:
				text = global::_0002._0003(text, _0081(107396066));
				break;
			case DataTypes.usintType:
				text = global::_0002._0003(text, _0081(107396085));
				break;
			case DataTypes.inttype:
				text = global::_0002._0003(text, _0081(107396072));
				break;
			case DataTypes.uinttype:
				text = global::_0002._0003(text, _0081(107396031));
				break;
			case DataTypes.dinttype:
				text = global::_0002._0003(text, _0081(107396050));
				break;
			case DataTypes.udinttype:
				text = global::_0002._0003(text, _0081(107396005));
				break;
			case DataTypes.realtype:
				text = global::_0002._0003(text, _0081(107395992));
				break;
			case DataTypes.lrealtype:
				text = global::_0002._0003(text, _0081(107396011));
				break;
			case DataTypes.stringtype:
				text = _000F_0002._0092_0002(text, _0081(107395966), this._0001[i].FieldLength.ToString(), _0081(107395985));
				break;
			}
		}
		string text2 = global::_0002._0003(text, _0081(107395980));
		XmlNode xmlNode3 = _0010_0002._007E_0093_0002(xmlDocument, text2);
		_000E_0002._007E_0091_0002(xmlNode2, xmlNode3);
		_000E_0002._007E_0091_0002(xmlNode, xmlNode2);
		XmlNode xmlNode4 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395935));
		XmlAttribute xmlAttribute = _0011_0002._007E_0094_0002(xmlDocument, _0081(107395946));
		_0012_0002._007E_0095_0002(xmlAttribute, _0081(107395901));
		_0014_0002._007E_009B_0002(_0013_0002._007E_009A_0002(xmlNode4), xmlAttribute);
		XmlNode xmlNode5 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395896));
		_0012_0002._007E_0096_0002(xmlNode5, this._0001.ToString());
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode5);
		XmlNode xmlNode6 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395363));
		_0012_0002._007E_0096_0002(xmlNode6, _0081(107395354));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode6);
		XmlNode xmlNode7 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395377));
		_0012_0002._007E_0096_0002(xmlNode7, _0081(107395332));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode7);
		XmlNode xmlNode8 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395323));
		_0012_0002._007E_0096_0002(xmlNode8, _0081(107395332));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode8);
		XmlNode xmlNode9 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395338));
		_0012_0002._007E_0096_0002(xmlNode9, _0081(107395354));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode9);
		XmlNode xmlNode10 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395313));
		_0012_0002._007E_0096_0002(xmlNode10, _0081(107395332));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode10);
		XmlNode xmlNode11 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395284));
		_0012_0002._007E_0096_0002(xmlNode11, _0081(107395332));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode11);
		XmlNode xmlNode12 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395223));
		_0012_0002._007E_0096_0002(xmlNode12, _0081(107395242));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode12);
		XmlNode xmlNode13 = _0008_0002._007E_0090_0002(xmlDocument, _0081(107395201));
		_0012_0002._007E_0096_0002(xmlNode13, _0081(107395192));
		_000E_0002._007E_0091_0002(xmlNode4, xmlNode13);
		_000E_0002._007E_0091_0002(xmlNode, xmlNode4);
		_0012_0002._007E_0097_0002(xmlDocument, fileName);
	}

	public static DataTypes ConvertIntToDataTypes(int dataTypes)
	{
		DataTypes result;
		do
		{
			int num = dataTypes;
			if (5u != 0)
			{
				int num2 = num;
				if (true)
				{
					switch (num2)
					{
					case 1:
						break;
					case 2:
						goto IL_0074;
					case 3:
						goto IL_007c;
					case 4:
						goto IL_0084;
					case 5:
						goto IL_008c;
					case 6:
						goto IL_0090;
					case 7:
						goto IL_009a;
					case 8:
						goto IL_009e;
					case 9:
						goto IL_00a2;
					case 10:
						goto IL_00a7;
					case 11:
						goto IL_00ac;
					case 12:
						goto IL_00b4;
					case 13:
						goto IL_00b9;
					default:
						goto IL_00be;
					}
					result = DataTypes.booltype;
					if (false)
					{
					}
				}
				break;
			}
			goto IL_009f;
			IL_007c:
			result = DataTypes.wordtype;
			break;
			IL_0074:
			result = DataTypes.bytetype;
			break;
			IL_00be:
			num = 1;
			if (num != 0)
			{
				result = (DataTypes)num;
				break;
			}
			goto IL_009f;
			IL_009f:
			result = (DataTypes)num;
			break;
			IL_00b9:
			result = DataTypes.stringtype;
			break;
			IL_00b4:
			result = DataTypes.lrealtype;
			break;
			IL_00ac:
			result = DataTypes.realtype;
			if (4 == 0)
			{
			}
			break;
			IL_00a7:
			result = DataTypes.udinttype;
			break;
			IL_00a2:
			result = DataTypes.dinttype;
			break;
			IL_009e:
			num = 8;
			goto IL_009f;
			IL_009a:
			result = DataTypes.inttype;
			break;
			IL_0090:
			result = DataTypes.usintType;
			continue;
			IL_008c:
			result = DataTypes.sinttype;
			break;
			IL_0084:
			result = DataTypes.dwordtype;
			break;
		}
		while (6 == 0);
		return result;
	}

	static NetVars()
	{
		Strings.CreateGetStringDelegate(typeof(NetVars));
	}
}

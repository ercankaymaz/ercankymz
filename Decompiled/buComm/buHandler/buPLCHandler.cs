using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buCore;

namespace buHandler;

public class buPLCHandler
{
	public delegate void PLCHandlerCommError(string Error);

	private static bool m__0001;

	public static string DeviceIP;

	public static string DeviceAddress;

	public static string DeviceName;

	public static bool isConnect;

	public static int ThreatCount;

	public static bool ThreadEnable;

	public static int ThreadWaitCount;

	[CompilerGenerated]
	private static PLCHandlerCommError m__0001;

	public static List<string> ErrorList;

	public static int PLCStatus;

	[NonSerialized]
	internal static GetString _0015;

	public static event PLCHandlerCommError CommError
	{
		[CompilerGenerated]
		add
		{
			if (1 == 0)
			{
				goto IL_002f;
			}
			PLCHandlerCommError pLCHandlerCommError = buPLCHandler.m__0001;
			goto IL_003a;
			IL_002f:
			PLCHandlerCommError pLCHandlerCommError2 = default(PLCHandlerCommError);
			if (((object)pLCHandlerCommError != pLCHandlerCommError2) ? true : false)
			{
				goto IL_003a;
			}
			return;
			IL_003a:
			pLCHandlerCommError2 = pLCHandlerCommError;
			PLCHandlerCommError value2 = (PLCHandlerCommError)_0016._008F(pLCHandlerCommError2, value);
			pLCHandlerCommError = Interlocked.CompareExchange(ref buPLCHandler.m__0001, value2, pLCHandlerCommError2);
			goto IL_002f;
		}
		[CompilerGenerated]
		remove
		{
			if (1 == 0)
			{
				goto IL_002f;
			}
			PLCHandlerCommError pLCHandlerCommError = buPLCHandler.m__0001;
			goto IL_003a;
			IL_002f:
			PLCHandlerCommError pLCHandlerCommError2 = default(PLCHandlerCommError);
			if (((object)pLCHandlerCommError != pLCHandlerCommError2) ? true : false)
			{
				goto IL_003a;
			}
			return;
			IL_003a:
			pLCHandlerCommError2 = pLCHandlerCommError;
			PLCHandlerCommError value2 = (PLCHandlerCommError)_0016._0090(pLCHandlerCommError2, value);
			pLCHandlerCommError = Interlocked.CompareExchange(ref buPLCHandler.m__0001, value2, pLCHandlerCommError2);
			goto IL_002f;
		}
	}

	public buPLCHandler()
	{
		if (!_0001(_0015(107396771)))
		{
			buPLCHandler.m__0001 = false;
			throw new RegisterException(_0015(107396771));
		}
		buPLCHandler.m__0001 = true;
	}

	internal static bool _0001(string P_0)
	{
		bool result;
		try
		{
			if (global::_0001._0001(buVector.AskMeResult, _0015(107396722)) | (buVector.AskMeValue != -5861345679435.912))
			{
				BinaryReader binaryReader;
				if (true)
				{
					binaryReader = null;
				}
				try
				{
					FileInfo fileInfo = new FileInfo(_0002._0003(AppPath.Base, _0015(107396633)));
					bool num = !global::_0003._007E_0004(fileInfo);
					if (8u != 0)
					{
						bool flag = num;
						num = flag;
					}
					if (num)
					{
						throw new RegisterException(P_0);
					}
					List<double> list;
					int num2;
					bool flag2;
					bool flag3;
					List<string> list4;
					List<string> list5;
					string text22;
					if (global::_0003._007E_0004(fileInfo))
					{
						list = new List<double>();
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						flag2 = false;
						num2 = 0;
						if (num2 == 0)
						{
							flag3 = (byte)num2 != 0;
							try
							{
								global::_0004._0008(_0015(107396648), _0015(107396639), _0015(107397102), _0015(107397129), 0.0, 0.0, false);
								FileStream input = new FileStream(global::_0005._007E_000E(fileInfo), FileMode.Open, FileAccess.Read, FileShare.None);
								binaryReader = new BinaryReader(input);
								int num3 = 0;
								string text = _0015(107397124);
								string text2 = _0015(107397124);
								string text3 = _0015(107397124);
								string text4 = _0015(107397124);
								string text5 = _0015(107397124);
								string text6 = _0015(107397124);
								string text7 = _0015(107397124);
								string text8 = _0015(107397124);
								string text9 = _0015(107397124);
								string text10 = _0015(107397124);
								string text11 = _0015(107397124);
								string text12 = _0015(107397124);
								string text13 = _0015(107397124);
								string text14 = _0015(107397124);
								float num4 = 0f;
								double num5 = 0.0;
								decimal num6 = default(decimal);
								int num7 = 0;
								int num8 = 0;
								while (true)
								{
									bool num9 = num8 < 755;
									while (true)
									{
										double num11;
										if (num9)
										{
											float num10 = _0006._007E_0015(binaryReader);
											num11 = num10;
											if (0 == 0)
											{
												num4 = num10;
												num8++;
												break;
											}
											goto IL_090c;
										}
										for (int i = 0; i < 1274; i++)
										{
											num5 = global::_0007._007E_0016(binaryReader);
										}
										for (int j = 0; j < 1498; j++)
										{
											num6 = _0008._007E_0017(binaryReader);
										}
										for (int k = 0; k < 5614; k++)
										{
											num5 = _000E._007E_0018(binaryReader);
										}
										int num12 = 0;
										while (true)
										{
											num9 = num12 < 4243;
											if (false)
											{
												break;
											}
											if (num9)
											{
												num4 = _0006._007E_0015(binaryReader);
												num12++;
												continue;
											}
											goto IL_0328;
										}
										continue;
										IL_0328:
										int num13 = 0;
										while (true)
										{
											if (num13 < 9867)
											{
												num5 = global::_0007._007E_0016(binaryReader);
											}
											else
											{
												for (int l = 0; l < 3886; l++)
												{
													num6 = _0008._007E_0017(binaryReader);
												}
												for (int m = 0; m < 5765; m++)
												{
													num5 = _000E._007E_0018(binaryReader);
												}
												num7 = _000E._007E_0018(binaryReader);
												list.Clear();
												list2.Clear();
												list3.Clear();
												int num14 = 0;
												while (true)
												{
													if (num14 <= num7 - 1)
													{
														double num15 = 0.0;
														num15 = global::_0007._007E_0016(binaryReader) / 65.87;
														list.Add(num15);
														int num16 = _000E._007E_0018(binaryReader);
														string text15 = _0015(107397124);
														for (int n = 0; n < num16; n++)
														{
															byte b = _000F._001C(global::_0007._007E_0016(binaryReader) / 46.8613);
															text15 = _0002._0003(text15, _0010._001D(b).ToString());
														}
														list2.Add(text15);
														num16 = _000E._007E_0018(binaryReader);
														if (false)
														{
															break;
														}
														string text16 = _0015(107397124);
														for (int num17 = 0; num17 < num16; num17++)
														{
															byte b2 = _000F._001C(global::_0007._007E_0016(binaryReader) / 86.3456);
															text16 = _0002._0003(text16, _0010._001D(b2).ToString());
														}
														list3.Add(text16);
														num14++;
														continue;
													}
													num3 = _000E._007E_0018(binaryReader);
													int num18 = 0;
													if (8 == 0)
													{
														goto IL_053e;
													}
													goto IL_058a;
													IL_058a:
													if (num18 >= num3)
													{
														break;
													}
													goto IL_053e;
													IL_053e:
													byte b3 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
													text = _0002._0003(text, _0010._001D(b3).ToString());
													num18++;
													goto IL_058a;
												}
												num3 = _000E._007E_0018(binaryReader);
												if (5u != 0)
												{
													break;
												}
											}
											num13++;
										}
										for (int num19 = 0; num19 < num3; num19++)
										{
											byte b4 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
											text2 = _0002._0003(text2, _0010._001D(b4).ToString());
										}
										int num20 = _000E._007E_0018(binaryReader);
										do
										{
											num3 = num20;
											for (int num21 = 0; num21 < num3; num21++)
											{
												byte b5 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
												text3 = _0002._0003(text3, _0010._001D(b5).ToString());
											}
											while (true)
											{
												num3 = _000E._007E_0018(binaryReader);
												int num22 = 0;
												while (0 == 0)
												{
													if (num22 >= num3)
													{
														goto end_IL_0670;
													}
													byte b6 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
													text4 = _0002._0003(text4, _0010._001D(b6).ToString());
													num22++;
												}
												continue;
												end_IL_0670:
												break;
											}
											num3 = _000E._007E_0018(binaryReader);
											for (int num23 = 0; num23 < num3; num23++)
											{
												byte b7 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
												text5 = _0002._0003(text5, _0010._001D(b7).ToString());
											}
											num20 = _000E._007E_0018(binaryReader);
										}
										while (false);
										num3 = num20;
										for (int num24 = 0; num24 < num3; num24++)
										{
											byte b8 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
											text6 = _0002._0003(text6, _0010._001D(b8).ToString());
										}
										num3 = _000E._007E_0018(binaryReader);
										for (int num25 = 0; num25 < num3; num25++)
										{
											byte b9 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
											text7 = _0002._0003(text7, _0010._001D(b9).ToString());
										}
										num3 = _000E._007E_0018(binaryReader);
										for (int num26 = 0; num26 < num3; num26++)
										{
											byte b10 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
											text8 = _0002._0003(text8, _0010._001D(b10).ToString());
										}
										num3 = _000E._007E_0018(binaryReader);
										for (int num27 = 0; num27 < num3; num27++)
										{
											byte b11 = _000F._001C(global::_0007._007E_0016(binaryReader) / 54.3685);
											text9 = _0002._0003(text9, _0010._001D(b11).ToString());
										}
										global::_0007._007E_0016(binaryReader);
										num11 = global::_0007._007E_0016(binaryReader);
										goto IL_090c;
										IL_090c:
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										num3 = _000E._007E_0018(binaryReader);
										for (int num28 = 0; num28 < num3; num28++)
										{
											byte b12 = _000F._001C(global::_0007._007E_0016(binaryReader) / 64.3685);
											text10 = _0002._0003(text10, _0010._001D(b12).ToString());
										}
										string text17 = text10;
										num3 = _000E._007E_0018(binaryReader);
										for (int num29 = 0; num29 < num3; num29++)
										{
											byte b13 = _000F._001C(global::_0007._007E_0016(binaryReader) / 64.3685);
											text11 = _0002._0003(text11, _0010._001D(b13).ToString());
										}
										string text18 = text11;
										num3 = _000E._007E_0018(binaryReader);
										for (int num30 = 0; num30 < num3; num30++)
										{
											byte b14 = _000F._001C(global::_0007._007E_0016(binaryReader) / 64.3685);
											text12 = _0002._0003(text12, _0010._001D(b14).ToString());
										}
										string text19 = text12;
										num3 = _000E._007E_0018(binaryReader);
										for (int num31 = 0; num31 < num3; num31++)
										{
											byte b15 = _000F._001C(global::_0007._007E_0016(binaryReader) / 64.3685);
											text13 = _0002._0003(text13, _0010._001D(b15).ToString());
										}
										string text20 = text13;
										num3 = _000E._007E_0018(binaryReader);
										for (int num32 = 0; num32 < num3; num32++)
										{
											byte b16 = _000F._001C(global::_0007._007E_0016(binaryReader) / 64.3685);
											text14 = _0002._0003(text14, _0010._001D(b16).ToString());
										}
										string text21 = text14;
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										flag2 = global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										bool flag4 = global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										flag3 = global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0003._007E_0005(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										global::_0007._007E_0016(binaryReader);
										_0011._007E_001E(binaryReader);
										global::_0004._0008(_0015(107396648), _0015(107397123), _0015(107397102), _0015(107397074), 0.0, 0.0, false);
										goto end_IL_026e;
									}
									continue;
									end_IL_026e:
									break;
								}
							}
							catch (Exception ex)
							{
								_0012._008B(global::_0005._007E_000F(ex));
								_0011._007E_001E(binaryReader);
								throw new RegisterException(P_0);
							}
							list4 = new List<string>();
							list5 = new List<string>();
							text22 = _0015(107397124);
							goto IL_0d23;
						}
						goto IL_0e7b;
					}
					throw new RegisterException(P_0);
					IL_0d23:
					_0013._008C(ref list4);
					global::_0004._0008(_0015(107396648), _0015(107397069), _0015(107397102), _0015(107397074), 0.0, 0.0, false);
					_0014._008D(ref list5);
					global::_0004._0008(_0015(107396648), _0015(107397084), _0015(107397102), _0015(107397074), 0.0, 0.0, false);
					global::_0015._008E(ref text22);
					global::_0004._0008(_0015(107396648), _0015(107397067), _0015(107397102), _0015(107397074), 0.0, 0.0, false);
					if (!flag2 && !flag3)
					{
						num2 = (_0005._0004._0001(P_0, list5, list, list4, text22) ? 1 : 0);
						goto IL_0e7b;
					}
					goto IL_0eec;
					IL_0e7b:
					bool flag5 = (byte)num2 != 0;
					global::_0004._0008(_0015(107396648), _0015(107397067), _0015(107397102), _0015(107397074), 0.0, 0.0, false);
					if (!flag5)
					{
						goto IL_0eec;
					}
					result = true;
					if (false)
					{
						goto IL_0d23;
					}
					goto end_IL_004c;
					IL_0eec:
					throw new RegisterException(P_0);
					end_IL_004c:;
				}
				catch (Exception)
				{
					throw new RegisterException(P_0);
				}
			}
			else
			{
				result = true;
			}
		}
		catch (Exception)
		{
			throw new RegisterException(P_0);
		}
		return result;
	}

	public unsafe static void ConnectPLC(bool ByIP)
	{
		//The blocks IL_00f7, IL_0113, IL_0124 are reachable both inside and outside the pinned region starting at IL_00dc. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0124, IL_012f, IL_0131 are reachable both inside and outside the pinned region starting at IL_0109. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (false)
		{
			_0005._0004._0001(ptr);
			if (6u != 0)
			{
				goto IL_0107;
			}
			byte* ptr2 = null;
			_0005._0004._0001(ptr2);
			goto IL_0131;
		}
		bool flag = !buPLCHandler.m__0001;
		int num;
		if (0 == 0)
		{
			if (flag)
			{
				_0012._008B(_0015(107397018));
				return;
			}
			if (!isConnect & buPLCHandler.m__0001)
			{
				num = 0;
				goto IL_01dc;
			}
			return;
		}
		return;
		IL_018a:
		int num2;
		if (num2 == 0 || num2 == 1)
		{
			isConnect = true;
			num2 = _0005._0004._0001();
		}
		else if (false)
		{
		}
		return;
		IL_0107:
		byte[] array;
		byte[] array2;
		byte[] array3;
		fixed (byte* ptr3 = array)
		{
			byte* ptr2 = ptr3;
			_0005._0004._0001(ptr2);
			array2 = array3;
		}
		goto IL_0134;
		IL_0131:
		array2 = array3;
		goto IL_0134;
		IL_0134:
		fixed (byte* ptr4 = array2)
		{
			_0005._0004._0001(ptr4);
		}
		num = _0005._0004._0001();
		if (false)
		{
			goto IL_01dc;
		}
		num2 = num;
		num2 = _0005._0004._0001();
		if (ByIP)
		{
			while (2 == 0)
			{
			}
			num2 = _0005._0004._0001();
		}
		else
		{
			num2 = _0005._0004._0001();
		}
		goto IL_018a;
		IL_01dc:
		num2 = num;
		array = _0018._007E_0094(_0017._0091(), global::_0005._007E_0010(DeviceIP));
		array3 = _0018._007E_0094(_0017._0091(), global::_0005._007E_0010(DeviceAddress));
		byte[] array4 = _0018._007E_0094(_0017._0091(), global::_0005._007E_0010(DeviceName));
		if (6u != 0)
		{
			fixed (byte* ptr = array4)
			{
				_0005._0004._0001(ptr);
				if (6 == 0)
				{
					byte* ptr2 = null;
					_0005._0004._0001(ptr2);
					goto IL_0131;
				}
			}
			goto IL_0107;
		}
		goto IL_018a;
	}

	public static void DisConnectPLC()
	{
		if (8 == 0)
		{
			return;
		}
		_0005._0004._0001();
		isConnect = false;
		try
		{
			do
			{
				if (2u != 0)
				{
				}
			}
			while (5 == 0);
		}
		catch
		{
		}
	}

	public static int GetState(ref int State)
	{
		try
		{
			State = _0005._0004._0001();
			return 1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static int ReadSymbolAll(ref List<string> SymbolNames)
	{
		SymbolNames.Clear();
		uint num = _0005._0004._0001();
		uint num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		if (false)
		{
			goto IL_0067;
		}
		int num3 = 0;
		goto IL_0071;
		IL_0046:
		string SymbolName;
		int num4 = SymbolName.Trim().Length;
		if (0 == 0)
		{
			bool flag = num4 > 0;
			while (flag)
			{
				if (4 == 0)
				{
					continue;
				}
				goto IL_005e;
			}
			goto IL_006c;
		}
		goto IL_007c;
		IL_006c:
		num3++;
		goto IL_0071;
		IL_005e:
		SymbolNames.Add(SymbolName);
		goto IL_0067;
		IL_0071:
		num4 = ((num3 <= num2 - 1) ? 1 : 0);
		goto IL_007c;
		IL_007c:
		bool flag2 = (byte)num4 != 0;
		int num5 = (flag2 ? 1 : 0);
		if (true)
		{
			if (num5 != 0)
			{
				SymbolName = _0015(107397124);
				ReadSymbolByIndex(num3, ref SymbolName);
				goto IL_0046;
			}
			num5 = 1;
		}
		int result = num5;
		if (4 == 0)
		{
			goto IL_0071;
		}
		return result;
		IL_0067:
		if (1 == 0)
		{
			goto IL_0046;
		}
		goto IL_006c;
	}

	public static int ReadSymbolAll(ref List<WatchItem> SymbolNames)
	{
		while (true)
		{
			SymbolNames.Clear();
			uint num = _0005._0004._0001();
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				if (false)
				{
					goto IL_007a;
				}
				int num4 = ((num3 > num - 1) ? 1 : 0);
				int num5 = 0;
				if (num5 != 0)
				{
					goto IL_00b8;
				}
				bool flag = num4 == num5;
				bool num6 = flag;
				WatchItem watchItem;
				if (2u != 0)
				{
					if (!num6)
					{
						return 1;
					}
					watchItem = new WatchItem();
					ReadSymbolByIndex(num2, ref watchItem.Name);
					goto IL_0042;
				}
				goto IL_0087;
				IL_00b2:
				if (0 == 0)
				{
					num4 = num2;
					num5 = 1;
					goto IL_00b8;
				}
				goto IL_009f;
				IL_0087:
				string[] array;
				if (num6)
				{
					watchItem.NameShort = array[array.Length - 1];
				}
				goto IL_009f;
				IL_0042:
				if (watchItem.Name.Trim().Length > 0)
				{
					array = null;
					array = watchItem.Name.Split('.');
					num3 = ((array != null) ? 1 : 0);
					goto IL_007a;
				}
				goto IL_00b2;
				IL_009f:
				if (5 == 0)
				{
					break;
				}
				if (7 == 0)
				{
					goto IL_0042;
				}
				SymbolNames.Add(watchItem);
				goto IL_00b2;
				IL_00b8:
				num2 = num4 + num5;
				continue;
				IL_007a:
				if (num3 != 0)
				{
					num6 = array.Length != 0;
					goto IL_0087;
				}
				goto IL_009f;
			}
		}
	}

	public unsafe static int ReadSymbolByIndex(int Index, ref string SymbolName)
	{
		//The blocks IL_0050 are reachable both inside and outside the pinned region starting at IL_0052. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			uint num = _0005._0004._0001();
			int num2 = Index;
			while (true)
			{
				bool num3 = num2 >= 0;
				long num4 = Index;
				int num5 = (int)num;
				do
				{
					num5--;
				}
				while (8 == 0);
				if (num3 && num4 <= (uint)num5)
				{
					byte[] array = new byte[255];
					byte[] array2;
					if (7u != 0)
					{
						array2 = array;
					}
					try
					{
						byte[] array3 = array2;
						while (true)
						{
							fixed (byte* ptr = array3)
							{
								int num6;
								do
								{
									num6 = 0;
								}
								while (false);
								uint num7 = _0005._0004._0001(Index, ptr, ref num6);
								string text;
								bool flag;
								if (num7 != 0)
								{
									text = _0019._0095(new string[5]
									{
										_0015(107397033),
										num7.ToString(),
										_0015(107396988),
										SymbolName,
										_0015(107396947)
									});
									ErrorList.Add(text);
									flag = buPLCHandler.m__0001 != null;
									goto IL_00fd;
								}
								goto IL_0114;
								IL_014a:
								int num8;
								byte[] array4;
								int num9;
								if (num8 < num6)
								{
									if (false)
									{
										goto IL_00fd;
									}
									if (4 == 0)
									{
										array3 = array2;
										continue;
									}
									array4[num9] = array2[num9];
									num9++;
									goto IL_0148;
								}
								SymbolName = _001A._007E_0096(_0017._0092(), array4);
								goto IL_016d;
								IL_0148:
								num8 = num9;
								goto IL_014a;
								IL_016d:
								return 1;
								IL_0114:
								if (num6 > 0)
								{
									array4 = new byte[num6];
									num9 = 0;
									goto IL_0148;
								}
								goto IL_016d;
								IL_00fd:
								num8 = (flag ? 1 : 0);
								if (true)
								{
									if (num8 != 0)
									{
										buPLCHandler.m__0001(text);
									}
									goto IL_0114;
								}
								goto IL_014a;
							}
						}
					}
					finally
					{
					}
				}
				if (0 == 0)
				{
					SymbolName = _0015(107397124);
					num2 = -1;
					if (num2 != 0)
					{
						return num2;
					}
					continue;
				}
				break;
			}
		}
		catch (Exception)
		{
			return -1;
		}
		int result;
		return result;
	}

	public static int ReadAnyValue(buHandleVariableType Var, ref object Value)
	{
		try
		{
			while (true)
			{
				int num;
				if (0 == 0)
				{
					if (_001C._0098(Var.VarType, _001B._0097(typeof(double).TypeHandle)))
					{
						double Value2 = 0.0;
						int result = ReadVariableLREAL(Var.VarName, ref Value2);
						Value = Value2;
						return result;
					}
					if (_001C._0098(Var.VarType, _001B._0097(typeof(float).TypeHandle)))
					{
						float Value3;
						if (0 == 0)
						{
							Value3 = 0f;
						}
						if (7u != 0)
						{
							int result2 = ReadVariableREAL(Var.VarName, ref Value3);
							Value = Value3;
							return result2;
						}
						continue;
					}
					bool flag = _001C._0098(Var.VarType, _001B._0097(typeof(int).TypeHandle));
					num = (flag ? 1 : 0);
					if (false)
					{
						goto IL_01a2;
					}
					if (num == 0)
					{
						int num3;
						if (_001C._0098(Var.VarType, _001B._0097(typeof(short).TypeHandle)))
						{
							int num2;
							if (3u != 0)
							{
								short Value4 = 0;
								num2 = ReadVariableINT(Var.VarName, ref Value4);
								Value = Value4;
							}
							num3 = num2;
						}
						else
						{
							bool flag2 = _001C._0098(Var.VarType, _001B._0097(typeof(bool).TypeHandle));
							num3 = (flag2 ? 1 : 0);
							if (5u != 0)
							{
								if (num3 == 0)
								{
									break;
								}
								bool Value5 = false;
								int num4 = ReadVariableBOOL(Var.VarName, ref Value5);
								Value = Value5;
								num = num4;
								goto IL_01a2;
							}
						}
						return num3;
					}
				}
				int Value6 = 0;
				int result3 = ReadVariableDINT(Var.VarName, ref Value6);
				Value = Value6;
				return result3;
				IL_01a2:
				return num;
			}
			return -1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableLREAL(List<string> VarName, ref List<double> Value)
	{
		try
		{
			string[] array = new string[VarName.Count];
			double[] array2 = new double[VarName.Count];
			int num = 8;
			while (true)
			{
				byte[] array3 = new byte[num * VarName.Count];
				Value.Clear();
				int num2 = 0;
				while (true)
				{
					num = num2;
					if (false)
					{
						break;
					}
					if (num <= VarName.Count - 1)
					{
						array[num2] = VarName[num2];
						Value.Add(0.0);
						num2++;
						continue;
					}
					fixed (double* ptr = array2)
					{
						fixed (byte* ptr2 = array3)
						{
							int num3 = _0005._0004._0001(array, VarName.Count, ptr, ptr2);
							if (num3 != 0)
							{
								string text = _0015(107396970) + num3 + _0015(107396988) + VarName[0] + _0015(107396947);
								ErrorList.Add(text);
								if (buPLCHandler.m__0001 != null)
								{
									buPLCHandler.m__0001(text);
								}
							}
							int num4 = 0;
							for (int i = 0; i <= array3.Length - 1; i += 8)
							{
								byte[] array4 = new byte[8]
								{
									array3[num4 * 8],
									array3[num4 * 8 + 1],
									array3[num4 * 8 + 2],
									array3[num4 * 8 + 3],
									array3[num4 * 8 + 4],
									array3[num4 * 8 + 5],
									array3[num4 * 8 + 6],
									array3[num4 * 8 + 7]
								};
								Value[num4] = _0005._0004._0001(array4);
								num4++;
							}
							return 1;
						}
					}
				}
			}
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableLREAL(ref List<VariableLREALDef> Vars)
	{
		if (0 == 0)
		{
			try
			{
				string[] array = new string[Vars.Count];
				double[] array2 = new double[Vars.Count];
				byte[] array3 = new byte[8 * Vars.Count];
				for (int i = 0; i <= Vars.Count - 1; i++)
				{
					array[i] = Vars[i].Name;
					Vars[i].Value = 0.0;
					if (8 == 0)
					{
						break;
					}
				}
				try
				{
					fixed (double[] array4 = array2)
					{
						nint num;
						double* ptr;
						if (array2 == null || array4.Length == 0)
						{
							num = 0;
							if (0 == 0)
							{
								ptr = (double*)num;
								goto IL_009c;
							}
						}
						else
						{
							num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
						}
						ptr = (double*)num;
						goto IL_009c;
						IL_009c:
						try
						{
							fixed (byte[] array5 = array3)
							{
								byte* ptr2 = default(byte*);
								if (array3 == null || array5.Length == 0)
								{
									nint num2 = 0;
									if (0 == 0)
									{
										ptr2 = (byte*)num2;
									}
								}
								else
								{
									ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array5[0]);
								}
								int num3 = _0005._0004._0001(array, Vars.Count, ptr, ptr2);
								int num4 = 0;
								if (num3 == 0)
								{
									goto IL_018f;
								}
								string text;
								if (2u != 0)
								{
									text = _0015(107396970) + num3 + _0015(107396988) + Vars[0].Name + _0015(107396947);
									ErrorList.Add(text);
									goto IL_016a;
								}
								goto IL_01aa;
								IL_016a:
								bool flag = buPLCHandler.m__0001 != null;
								int num5 = (flag ? 1 : 0);
								if (0 == 0)
								{
									if (num5 != 0)
									{
										buPLCHandler.m__0001(text);
									}
									goto IL_018f;
								}
								goto IL_0215;
								IL_0215:
								num4 = num5 + 1;
								int num6 = num6 + 8;
								goto IL_0220;
								IL_0220:
								if (false)
								{
									goto IL_016a;
								}
								bool num7 = num6 > array3.Length - 1;
								do
								{
									bool flag2 = !num7;
									num7 = flag2;
								}
								while (3 == 0);
								if (!num7)
								{
									return 1;
								}
								byte[] array6 = new byte[8]
								{
									array3[num4 * 8],
									0,
									0,
									0,
									0,
									0,
									0,
									0
								};
								goto IL_01aa;
								IL_01aa:
								array6[1] = array3[num4 * 8 + 1];
								array6[2] = array3[num4 * 8 + 2];
								array6[3] = array3[num4 * 8 + 3];
								array6[4] = array3[num4 * 8 + 4];
								array6[5] = array3[num4 * 8 + 5];
								array6[6] = array3[num4 * 8 + 6];
								array6[7] = array3[num4 * 8 + 7];
								Vars[num4].Value = _0005._0004._0001(array6);
								num5 = num4;
								goto IL_0215;
								IL_018f:
								num6 = 0;
								goto IL_0220;
							}
						}
						finally
						{
							array5 = null;
						}
					}
				}
				finally
				{
					do
					{
						array4 = null;
					}
					while (7 == 0);
				}
			}
			catch (Exception)
			{
				return -1;
			}
		}
		int result;
		return result;
	}

	public unsafe static int ReadVariableLREAL(string VarName, ref double Value)
	{
		//The blocks IL_003e are reachable both inside and outside the pinned region starting at IL_0021. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			string[] array = new string[1] { VarName };
			double[] array2 = new double[1];
			byte[] array3 = new byte[8];
			try
			{
				byte[] array5;
				int num2;
				nint num3;
				int num4 = default(int);
				_0019 obj;
				object obj2;
				if (4u != 0)
				{
					fixed (double[] array4 = array2)
					{
						nint num;
						double* ptr;
						if (array2 == null || array4.Length == 0)
						{
							num = 0;
							if (0 == 0)
							{
								ptr = (double*)num;
								goto IL_003e;
							}
						}
						else
						{
							num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
						}
						ptr = (double*)num;
						goto IL_003e;
						IL_003e:
						try
						{
							array5 = array3;
							fixed (byte[] array6 = array5)
							{
								byte* ptr2;
								if (array5 != null)
								{
									num2 = array6.Length;
									if (1 == 0)
									{
										goto IL_0090;
									}
									if (num2 != 0)
									{
										ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array6[0]);
										goto IL_0144;
									}
								}
								num3 = 0;
								if (7u != 0)
								{
									ptr2 = (byte*)num3;
								}
								goto IL_0144;
								IL_0144:
								num4 = _0005._0004._0001(array, 1, ptr, ptr2);
								bool flag = num4 != 0;
								num2 = (flag ? 1 : 0);
								goto IL_0090;
								IL_0090:
								if (num2 != 0)
								{
									obj = _0019._0095;
									obj2 = new string[5]
									{
										_0015(107396970),
										num4.ToString(),
										_0015(107396988),
										VarName,
										_0015(107396947)
									};
									string text = obj((string[])obj2);
									ErrorList.Add(text);
									if (buPLCHandler.m__0001 != null)
									{
										buPLCHandler.m__0001(text);
									}
								}
								Value = _0005._0004._0001(array3);
								return num4;
							}
						}
						finally
						{
							array6 = null;
						}
					}
				}
				try
				{
					array5 = array3;
					fixed (byte[] array6 = array5)
					{
						byte* ptr2;
						if (array5 != null)
						{
							num2 = array6.Length;
							if (1 == 0)
							{
								goto IL_0090_2;
							}
							if (num2 != 0)
							{
								ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array6[0]);
								goto IL_0144_2;
							}
						}
						num3 = 0;
						if (7u != 0)
						{
							ptr2 = (byte*)num3;
						}
						goto IL_0144_2;
						IL_0144_2:
						double* ptr;
						num4 = _0005._0004._0001(array, 1, ptr, ptr2);
						bool flag = num4 != 0;
						num2 = (flag ? 1 : 0);
						goto IL_0090_2;
						IL_0090_2:
						if (num2 != 0)
						{
							obj = _0019._0095;
							obj2 = new string[5]
							{
								_0015(107396970),
								num4.ToString(),
								_0015(107396988),
								VarName,
								_0015(107396947)
							};
							string text = obj((string[])obj2);
							ErrorList.Add(text);
							if (buPLCHandler.m__0001 != null)
							{
								buPLCHandler.m__0001(text);
							}
						}
						Value = _0005._0004._0001(array3);
						return num4;
					}
				}
				finally
				{
					array6 = null;
				}
			}
			finally
			{
				array4 = null;
			}
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396925),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				Value.ToString()
			}));
			return -1;
		}
	}

	public unsafe static int ReadVariableREAL(string VarName, ref float Value)
	{
		//The blocks IL_00a3, IL_010e, IL_0114, IL_0124, IL_017e are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			string[] array;
			if (0 == 0)
			{
				array = new string[1] { VarName };
			}
			float[] array2 = new float[1];
			byte[] array3 = new byte[4];
			try
			{
				float[] array4 = array2;
				fixed (float[] array5 = array4)
				{
					nint num;
					nint num2;
					if (array4 != null)
					{
						num = (nint)array5.LongLength;
						if (false)
						{
							goto IL_002f;
						}
						if ((int)num != 0)
						{
							num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array5[0]);
							goto IL_003f;
						}
					}
					num = 0;
					goto IL_002f;
					IL_002f:
					num2 = num;
					if (false)
					{
						goto IL_003f;
					}
					float* ptr = (float*)num2;
					goto IL_0041;
					IL_003f:
					ptr = (float*)num2;
					goto IL_0041;
					IL_0041:
					try
					{
						int num5;
						_0019 obj;
						object obj2;
						string text;
						int num4 = default(int);
						if (0 == 0)
						{
							fixed (byte[] array6 = array3)
							{
								nint num3;
								byte* ptr2;
								if (array3 == null || array6.Length == 0)
								{
									num3 = 0;
									if (8u != 0)
									{
										ptr2 = (byte*)num3;
										if (-1 == 0)
										{
											goto IL_0124;
										}
										goto IL_014b;
									}
								}
								else
								{
									num3 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array6[0]);
								}
								ptr2 = (byte*)num3;
								goto IL_014b;
								IL_0124:
								Value = array2[0];
								return num4;
								IL_014b:
								num4 = _0005._0004._0001(array, 1, ptr, ptr2);
								num5 = num4;
								if (0 == 0)
								{
									if (num5 == 0)
									{
										goto IL_0124;
									}
									obj = _0019._0095;
									obj2 = new string[5]
									{
										_0015(107396359),
										num4.ToString(),
										_0015(107396988),
										VarName,
										_0015(107396947)
									};
									text = obj((string[])obj2);
									ErrorList.Add(text);
									num5 = ((buPLCHandler.m__0001 != null) ? 1 : 0);
								}
								if (num5 != 0)
								{
									buPLCHandler.m__0001(text);
								}
								goto IL_0124;
							}
						}
						obj = _0019._0095;
						obj2 = new string[5]
						{
							_0015(107396359),
							num4.ToString(),
							_0015(107396988),
							VarName,
							_0015(107396947)
						};
						text = obj((string[])obj2);
						ErrorList.Add(text);
						num5 = ((buPLCHandler.m__0001 != null) ? 1 : 0);
						if (num5 != 0)
						{
							buPLCHandler.m__0001(text);
						}
						Value = array2[0];
						int num6 = num4;
						return num6;
					}
					finally
					{
						array6 = null;
					}
				}
			}
			finally
			{
				array5 = null;
			}
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableREAL(List<string> VarName, ref List<float> Value)
	{
		try
		{
			int num = VarName.Count;
			while (true)
			{
				string[] array = new string[num];
				int num2 = VarName.Count;
				float[] array2;
				byte[] array3;
				do
				{
					array2 = new float[num2];
					array3 = new byte[4 * VarName.Count];
					Value.Clear();
					num2 = 0;
				}
				while (num2 != 0);
				int num3 = num2;
				while (true)
				{
					bool flag = num3 <= VarName.Count - 1;
					num = (flag ? 1 : 0);
					if (6 == 0)
					{
						break;
					}
					if (num != 0)
					{
						array[num3] = VarName[num3];
						Value.Add(0f);
						num3++;
						continue;
					}
					fixed (float* ptr = array2)
					{
						try
						{
							fixed (byte[] array4 = array3)
							{
								byte* ptr2;
								if (array3 == null || array4.Length == 0)
								{
									do
									{
										ptr2 = null;
									}
									while (false);
									if (4u != 0)
									{
										goto IL_01d2;
									}
								}
								ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
								goto IL_01d2;
								IL_01d2:
								int num4 = _0005._0004._0001(array, VarName.Count, ptr, ptr2);
								while (true)
								{
									int num5 = ((num4 != 0) ? 1 : 0);
									while (true)
									{
										bool flag2 = (byte)num5 != 0;
										if (0 == 0)
										{
											if (!flag2)
											{
												goto IL_017e;
											}
											string text = _0015(107396359) + num4 + _0015(107396988) + VarName?.ToString() + _0015(107396947);
											ErrorList.Add(text);
											if (buPLCHandler.m__0001 != null)
											{
												buPLCHandler.m__0001(text);
											}
										}
										if (false)
										{
											break;
										}
										goto IL_017e;
										IL_017e:
										int num6 = 0;
										while (true)
										{
											if (num6 <= array2.Length - 1)
											{
												Value[num6] = array2[num6];
												num5 = num6;
												if (6 == 0)
												{
													break;
												}
												num6 = num5 + 1;
												continue;
											}
											return 1;
										}
									}
								}
							}
						}
						finally
						{
							array4 = null;
						}
					}
				}
			}
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableREAL(ref List<VariableREALDef> Vars)
	{
		//The blocks IL_0074 are reachable both inside and outside the pinned region starting at IL_0076. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			string[] array;
			int num;
			float[] array2;
			if (0 == 0)
			{
				array = new string[Vars.Count];
				array2 = new float[Vars.Count];
				num = 4 * Vars.Count;
				goto IL_0029;
			}
			goto IL_005e;
			IL_005e:
			int num2;
			byte[] array5;
			int num7 = default(int);
			while (true)
			{
				if (num2 <= Vars.Count - 1)
				{
					array[num2] = Vars[num2].Name;
					Vars[num2].Value = 0f;
					num = num2;
					if (8 == 0)
					{
						break;
					}
					num2 = num + 1;
					continue;
				}
				try
				{
					float[] array3 = array2;
					while (true)
					{
						fixed (float[] array4 = array3)
						{
							int num3;
							float* ptr;
							if (array3 != null)
							{
								num3 = array4.Length;
								if (false)
								{
									goto IL_0084;
								}
								if (num3 != 0)
								{
									ptr = (float*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
									goto IL_0094;
								}
							}
							num3 = 0;
							goto IL_0084;
							IL_0094:
							if (false)
							{
								array3 = array2;
								continue;
							}
							fixed (byte* ptr2 = array5)
							{
								int num4 = _0005._0004._0001(array, Vars.Count, ptr, ptr2);
								int num5;
								do
								{
									num5 = num4;
									num4 = num5;
								}
								while (false);
								if (num4 == 0)
								{
									goto IL_0186;
								}
								string text;
								bool num6;
								bool flag;
								while (true)
								{
									text = _0015(107396359) + num5 + _0015(107396988) + Vars[0].Name + _0015(107396947);
									ErrorList.Add(text);
									num6 = buPLCHandler.m__0001 != null;
									if (6 == 0)
									{
										break;
									}
									flag = num6;
									if (false)
									{
										continue;
									}
									goto IL_0172;
								}
								goto IL_01b1;
								IL_0172:
								if (flag)
								{
									buPLCHandler.m__0001(text);
								}
								goto IL_0186;
								IL_01a5:
								num6 = num7 <= array2.Length - 1;
								goto IL_01b1;
								IL_0186:
								num7 = 0;
								goto IL_01a5;
								IL_01b1:
								if (num6)
								{
									Vars[num7].Value = array2[num7];
									num7++;
									goto IL_01a5;
								}
								return 1;
							}
							IL_0084:
							ptr = (float*)(uint)num3;
							goto IL_0094;
						}
					}
				}
				finally
				{
					array4 = null;
				}
			}
			goto IL_0029;
			IL_0029:
			array5 = new byte[num];
			num2 = 0;
			goto IL_005e;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static int ReadVariable(string VarName, ref object Value, VariableType Type)
	{
		int num;
		bool Value2 = default(bool);
		int num5;
		if (0 == 0)
		{
			if (Type == VariableType.Bool)
			{
				num = 0;
				if (num == 0)
				{
					Value2 = (byte)num != 0;
					num = ReadVariableBOOL(VarName, ref Value2);
				}
				goto IL_0031;
			}
			if (Type == VariableType.INT)
			{
				int Value3 = 0;
				int num2 = ReadVariableINT(VarName, ref Value3);
				Value = Value3;
				return 1;
			}
			if (Type == VariableType.DINT)
			{
				int Value4 = 0;
				int num3 = ReadVariableDINT(VarName, ref Value4);
				Value = Value4;
				return 1;
			}
			bool flag;
			if (Type == VariableType.REAL)
			{
				if (4u != 0)
				{
					if (0 == 0)
					{
						float Value5 = 0f;
						int num4 = ReadVariableREAL(VarName, ref Value5);
						Value = Value5;
						return 1;
					}
					goto IL_0127;
				}
			}
			else
			{
				flag = Type == VariableType.LREAL;
			}
			num5 = (flag ? 1 : 0);
			goto IL_00e0;
		}
		int result;
		return result;
		IL_00e0:
		if (num5 != 0)
		{
			double Value6 = 0.0;
			num = ReadVariableLREAL(VarName, ref Value6);
			if (0 == 0)
			{
				int num6 = num;
				Value = Value6;
				return 1;
			}
			goto IL_0031;
		}
		bool flag2 = Type == VariableType.STRING;
		num = (flag2 ? 1 : 0);
		goto IL_0113;
		IL_0127:
		string Value7;
		int num7 = ReadVariableSTRING(VarName, ref Value7);
		Value = Value7;
		return 1;
		IL_0031:
		if (8u != 0)
		{
			int num8 = num;
			Value = Value2;
			num5 = 1;
			if (num5 != 0)
			{
				return num5;
			}
			goto IL_00e0;
		}
		goto IL_0113;
		IL_0113:
		if (num != 0)
		{
			Value7 = _0015(107397124);
			goto IL_0127;
		}
		return -1;
	}

	public unsafe static int ReadVariableSTRING(string VarName, ref string Value)
	{
		try
		{
			string[] array = new string[1] { VarName };
			byte[] array2 = new byte[255];
			fixed (byte* ptr = array2)
			{
				int num = _0005._0004._0001(array, ptr);
				int num2 = 0;
				int num3 = num;
				int num4 = 0;
				string text = default(string);
				int num5 = default(int);
				byte[] array3 = default(byte[]);
				while (true)
				{
					if ((uint)num3 > (uint)num4)
					{
						text = _0019._0095(new string[5]
						{
							_0015(107396282),
							num.ToString(),
							_0015(107396988),
							VarName,
							_0015(107396947)
						});
						goto IL_00c1;
					}
					goto IL_00f2;
					IL_0153:
					bool flag = num5 < num2;
					if (false)
					{
						goto IL_0101;
					}
					if (!flag)
					{
						break;
					}
					goto IL_013c;
					IL_00f2:
					int num6 = 0;
					goto IL_011c;
					IL_011c:
					if (1 == 0)
					{
						goto IL_010d;
					}
					bool flag2;
					if (num6 < 255)
					{
						flag2 = array2[num6] == 0;
						goto IL_0101;
					}
					array3 = new byte[num2];
					num5 = 0;
					goto IL_0153;
					IL_0115:
					num6++;
					goto IL_011c;
					IL_0109:
					num2 = num6;
					goto IL_010d;
					IL_013c:
					array3[num5] = array2[num5];
					num3 = num5;
					num4 = 1;
					if (num4 == 0)
					{
						continue;
					}
					num5 = num3 + num4;
					goto IL_0153;
					IL_0101:
					if (4 == 0)
					{
						goto IL_00c1;
					}
					if (flag2)
					{
						goto IL_0109;
					}
					goto IL_0115;
					IL_010d:
					num6 = 1000;
					goto IL_0115;
					IL_00c1:
					ErrorList.Add(text);
					if (0 == 0)
					{
						if (buPLCHandler.m__0001 != null)
						{
							if (1 == 0)
							{
								goto IL_013c;
							}
							buPLCHandler.m__0001(text);
						}
						goto IL_00f2;
					}
					goto IL_0109;
				}
				Value = _001A._007E_0096(_0017._0092(), array3);
				return num;
			}
		}
		catch (Exception)
		{
			if (4u != 0)
			{
			}
			return -1;
		}
	}

	public unsafe static int ReadVariableINT(string VarName, ref short Value)
	{
		int result;
		try
		{
			string[] array = new string[1] { VarName };
			short[] array2 = new short[1];
			try
			{
				fixed (short[] array3 = array2)
				{
					short* ptr = default(short*);
					if (array2 == null || array3.Length == 0)
					{
						if (uint.MaxValue != 0)
						{
							ptr = null;
						}
						goto IL_0042;
					}
					goto IL_011a;
					IL_011a:
					void* num = System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
					if (0 == 0)
					{
						ptr = (short*)num;
					}
					goto IL_0042;
					IL_006f:
					int num2 = default(int);
					string text = _0019._0095(new string[5]
					{
						_0015(107396237),
						num2.ToString(),
						_0015(107396988),
						VarName,
						_0015(107396947)
					});
					if (5 == 0)
					{
						goto IL_011a;
					}
					ErrorList.Add(text);
					goto IL_00d8;
					IL_00fd:
					Value = array2[0];
					result = num2;
					if (5 == 0)
					{
						goto IL_006f;
					}
					goto end_IL_0018;
					IL_0042:
					if (8 == 0)
					{
						goto IL_00d8;
					}
					num2 = _0005._0004._0001(array, 1, ptr);
					goto IL_0143;
					IL_00d8:
					if (buPLCHandler.m__0001 != null)
					{
						buPLCHandler.m__0001(text);
					}
					if (0 == 0)
					{
						goto IL_00fd;
					}
					goto IL_0143;
					IL_0143:
					if (num2 != 0)
					{
						goto IL_006f;
					}
					goto IL_00fd;
					end_IL_0018:;
				}
			}
			finally
			{
				array3 = null;
			}
		}
		catch (Exception)
		{
			do
			{
				result = -1;
			}
			while (false);
		}
		return result;
	}

	public unsafe static int ReadVariableINT(string VarName, ref int Value)
	{
		int result;
		try
		{
			string[] array = new string[1] { VarName };
			short[] array2 = new short[1];
			try
			{
				fixed (short[] array3 = array2)
				{
					short* ptr = default(short*);
					if (array2 == null || array3.Length == 0)
					{
						if (uint.MaxValue != 0)
						{
							ptr = null;
						}
						goto IL_0042;
					}
					goto IL_011a;
					IL_011a:
					void* num = System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
					if (0 == 0)
					{
						ptr = (short*)num;
					}
					goto IL_0042;
					IL_006f:
					int num2 = default(int);
					string text = _0019._0095(new string[5]
					{
						_0015(107396237),
						num2.ToString(),
						_0015(107396988),
						VarName,
						_0015(107396947)
					});
					if (5 == 0)
					{
						goto IL_011a;
					}
					ErrorList.Add(text);
					goto IL_00d8;
					IL_00fd:
					Value = array2[0];
					result = num2;
					if (5 == 0)
					{
						goto IL_006f;
					}
					goto end_IL_0018;
					IL_0042:
					if (8 == 0)
					{
						goto IL_00d8;
					}
					num2 = _0005._0004._0001(array, 1, ptr);
					goto IL_0143;
					IL_00d8:
					if (buPLCHandler.m__0001 != null)
					{
						buPLCHandler.m__0001(text);
					}
					if (0 == 0)
					{
						goto IL_00fd;
					}
					goto IL_0143;
					IL_0143:
					if (num2 != 0)
					{
						goto IL_006f;
					}
					goto IL_00fd;
					end_IL_0018:;
				}
			}
			finally
			{
				array3 = null;
			}
		}
		catch (Exception)
		{
			do
			{
				result = -1;
			}
			while (false);
		}
		return result;
	}

	public unsafe static int ReadVariableDINT(string VarName, ref int Value)
	{
		int result;
		try
		{
			string[] array = new string[1] { VarName };
			int[] array2 = new int[1];
			try
			{
				fixed (int[] array3 = array2)
				{
					int* ptr = default(int*);
					if (array2 == null || array3.Length == 0)
					{
						if (uint.MaxValue != 0)
						{
							ptr = null;
						}
						goto IL_0042;
					}
					goto IL_011a;
					IL_011a:
					void* num = System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
					if (0 == 0)
					{
						ptr = (int*)num;
					}
					goto IL_0042;
					IL_006f:
					int num2 = default(int);
					string text = _0019._0095(new string[5]
					{
						_0015(107396228),
						num2.ToString(),
						_0015(107396988),
						VarName,
						_0015(107396947)
					});
					if (5 == 0)
					{
						goto IL_011a;
					}
					ErrorList.Add(text);
					goto IL_00d8;
					IL_00fd:
					Value = array2[0];
					result = num2;
					if (5 == 0)
					{
						goto IL_006f;
					}
					goto end_IL_0018;
					IL_0042:
					if (8 == 0)
					{
						goto IL_00d8;
					}
					num2 = _0005._0004._0001(array, 1, ptr);
					goto IL_0143;
					IL_00d8:
					if (buPLCHandler.m__0001 != null)
					{
						buPLCHandler.m__0001(text);
					}
					if (0 == 0)
					{
						goto IL_00fd;
					}
					goto IL_0143;
					IL_0143:
					if (num2 != 0)
					{
						goto IL_006f;
					}
					goto IL_00fd;
					end_IL_0018:;
				}
			}
			finally
			{
				array3 = null;
			}
		}
		catch (Exception)
		{
			do
			{
				result = -1;
			}
			while (false);
		}
		return result;
	}

	public unsafe static int ReadMultiVariableDINT(List<string> VarName, ref List<int> Value)
	{
		try
		{
			string[] array = new string[VarName.Count];
			int[] array2;
			byte[] array3;
			if (0 == 0)
			{
				int num = VarName.Count;
				while (true)
				{
					int num2;
					if (0 == 0)
					{
						array2 = new int[num];
						array3 = new byte[4 * VarName.Count];
						Value.Clear();
						num2 = 0;
						goto IL_0057;
					}
					goto IL_0065;
					IL_0057:
					int num3 = num2;
					int num4 = VarName.Count;
					do
					{
						num4--;
					}
					while (false);
					num = ((num3 > num4) ? 1 : 0);
					goto IL_0065;
					IL_0065:
					if (num != 0)
					{
						break;
					}
					array[num2] = VarName[num2];
					Value.Add(0);
					num = num2 + 1;
					if (1 == 0)
					{
						continue;
					}
					num2 = num;
					goto IL_0057;
				}
			}
			fixed (int* ptr = array2)
			{
				try
				{
					fixed (byte[] array4 = array3)
					{
						int num5;
						if (array3 == null || array4.Length == 0)
						{
							num5 = 0;
							goto IL_009d;
						}
						byte* ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
						goto IL_01c4;
						IL_01c4:
						int num6 = _0005._0004._0001(array, VarName.Count, ptr, ptr2);
						string text;
						bool flag;
						if (num6 != 0)
						{
							text = _0015(107396228) + num6 + _0015(107396988) + VarName[0] + _0015(107396947);
							ErrorList.Add(text);
							flag = buPLCHandler.m__0001 != null;
							goto IL_0156;
						}
						goto IL_016a;
						IL_016a:
						if (0 == 0)
						{
							int num7 = 0;
							while (true)
							{
								bool flag2 = num7 <= array2.Length - 1;
								num5 = (flag2 ? 1 : 0);
								if (5 == 0)
								{
									break;
								}
								if (3u != 0)
								{
									if (num5 != 0)
									{
										Value[num7] = array2[num7];
										num7++;
										continue;
									}
									num5 = 1;
								}
								return num5;
							}
							goto IL_009d;
						}
						goto IL_0156;
						IL_0156:
						if (flag)
						{
							buPLCHandler.m__0001(text);
						}
						goto IL_016a;
						IL_009d:
						nint num8 = (nint)(uint)num5;
						if (2u != 0)
						{
							ptr2 = (byte*)num8;
						}
						goto IL_01c4;
					}
				}
				finally
				{
					array4 = null;
				}
			}
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableDINT(ref List<VariableDINTDef> Vars)
	{
		//The blocks IL_0070 are reachable both inside and outside the pinned region starting at IL_0072. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			string[] array;
			int num;
			int[] array2;
			if (0 == 0)
			{
				array = new string[Vars.Count];
				array2 = new int[Vars.Count];
				num = 4 * Vars.Count;
				goto IL_0029;
			}
			goto IL_005a;
			IL_005a:
			int num2;
			byte[] array5;
			int num7 = default(int);
			while (true)
			{
				if (num2 <= Vars.Count - 1)
				{
					array[num2] = Vars[num2].Name;
					Vars[num2].Value = 0;
					num = num2;
					if (8 == 0)
					{
						break;
					}
					num2 = num + 1;
					continue;
				}
				try
				{
					int[] array3 = array2;
					while (true)
					{
						fixed (int[] array4 = array3)
						{
							int num3;
							int* ptr;
							if (array3 != null)
							{
								num3 = array4.Length;
								if (false)
								{
									goto IL_0080;
								}
								if (num3 != 0)
								{
									ptr = (int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
									goto IL_0090;
								}
							}
							num3 = 0;
							goto IL_0080;
							IL_0090:
							if (false)
							{
								array3 = array2;
								continue;
							}
							fixed (byte* ptr2 = array5)
							{
								int num4 = _0005._0004._0001(array, Vars.Count, ptr, ptr2);
								int num5;
								do
								{
									num5 = num4;
									num4 = num5;
								}
								while (false);
								if (num4 == 0)
								{
									goto IL_0182;
								}
								string text;
								bool num6;
								bool flag;
								while (true)
								{
									text = _0015(107396228) + num5 + _0015(107396988) + Vars[0].Name + _0015(107396947);
									ErrorList.Add(text);
									num6 = buPLCHandler.m__0001 != null;
									if (6 == 0)
									{
										break;
									}
									flag = num6;
									if (false)
									{
										continue;
									}
									goto IL_016e;
								}
								goto IL_01ad;
								IL_016e:
								if (flag)
								{
									buPLCHandler.m__0001(text);
								}
								goto IL_0182;
								IL_01a1:
								num6 = num7 <= array2.Length - 1;
								goto IL_01ad;
								IL_0182:
								num7 = 0;
								goto IL_01a1;
								IL_01ad:
								if (num6)
								{
									Vars[num7].Value = array2[num7];
									num7++;
									goto IL_01a1;
								}
								return 1;
							}
							IL_0080:
							ptr = (int*)(uint)num3;
							goto IL_0090;
						}
					}
				}
				finally
				{
					array4 = null;
				}
			}
			goto IL_0029;
			IL_0029:
			array5 = new byte[num];
			num2 = 0;
			goto IL_005a;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadVariableBOOL(string VarName, ref bool Value)
	{
		int result;
		try
		{
			string[] array = new string[1] { VarName };
			bool[] array2 = new bool[1];
			try
			{
				fixed (bool[] array3 = array2)
				{
					bool* ptr = default(bool*);
					if (array2 == null || array3.Length == 0)
					{
						if (uint.MaxValue != 0)
						{
							ptr = null;
						}
						goto IL_0042;
					}
					goto IL_011a;
					IL_011a:
					void* num = System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
					if (0 == 0)
					{
						ptr = (bool*)num;
					}
					goto IL_0042;
					IL_006f:
					int num2 = default(int);
					string text = _0019._0095(new string[5]
					{
						_0015(107396147),
						num2.ToString(),
						_0015(107396988),
						VarName,
						_0015(107396947)
					});
					if (5 == 0)
					{
						goto IL_011a;
					}
					ErrorList.Add(text);
					goto IL_00d8;
					IL_00fd:
					Value = array2[0];
					result = num2;
					if (5 == 0)
					{
						goto IL_006f;
					}
					goto end_IL_0018;
					IL_0042:
					if (8 == 0)
					{
						goto IL_00d8;
					}
					num2 = _0005._0004._0001(array, 1, ptr);
					goto IL_0143;
					IL_00d8:
					if (buPLCHandler.m__0001 != null)
					{
						buPLCHandler.m__0001(text);
					}
					if (0 == 0)
					{
						goto IL_00fd;
					}
					goto IL_0143;
					IL_0143:
					if (num2 != 0)
					{
						goto IL_006f;
					}
					goto IL_00fd;
					end_IL_0018:;
				}
			}
			finally
			{
				array3 = null;
			}
		}
		catch (Exception)
		{
			do
			{
				result = -1;
			}
			while (false);
		}
		return result;
	}

	public unsafe static int ReadMultiVariableBOOL(List<string> VarName, ref List<bool> Value)
	{
		//The blocks IL_0082 are reachable both inside and outside the pinned region starting at IL_0066. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			string[] array = new string[VarName.Count];
			byte[] array2 = new byte[VarName.Count];
			byte[] array3 = new byte[VarName.Count];
			Value.Clear();
			for (int i = 0; i <= VarName.Count - 1; i++)
			{
				array[i] = VarName[i];
				Value.Add(item: false);
			}
			try
			{
				byte[] array4;
				int num;
				int num3;
				int num4;
				int num6;
				string[] array6;
				byte* ptr2;
				if (0 == 0)
				{
					fixed (byte* ptr = array2)
					{
						ptr2 = ptr;
						try
						{
							array4 = array3;
							fixed (byte[] array5 = array4)
							{
								if (array4 != null)
								{
									num = array5.Length;
									goto IL_008f;
								}
								goto IL_0091;
								IL_01a2:
								int num2 = default(int);
								num = ((num2 > array2.Length - 1) ? 1 : 0);
								if (false)
								{
									goto IL_008f;
								}
								if (num != 0)
								{
									return 1;
								}
								num3 = ((array2[num2] < 1) ? 1 : 0);
								num4 = 0;
								goto IL_0177;
								IL_008f:
								if (num == 0)
								{
									goto IL_0091;
								}
								byte* ptr3 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array5[0]);
								goto IL_01db;
								IL_0177:
								if (num3 == num4)
								{
									Value[num2] = true;
								}
								else
								{
									Value[num2] = false;
								}
								num2++;
								goto IL_01a2;
								IL_0091:
								ptr3 = null;
								goto IL_01db;
								IL_01db:
								int num5 = _0005._0004._0001(array, VarName.Count, ptr2, ptr3);
								num3 = num5;
								num4 = 0;
								if (num4 != 0)
								{
									goto IL_0177;
								}
								bool flag = (uint)num3 > (uint)num4;
								num6 = (flag ? 1 : 0);
								while (num6 != 0)
								{
									num6 = 5;
									if (num6 != 0)
									{
										array6 = new string[num6];
										array6[0] = _0015(107396134);
										array6[1] = num5.ToString();
										array6[2] = _0015(107396988);
										array6[3] = VarName[0];
										array6[4] = _0015(107396947);
										string text = string.Concat(array6);
										ErrorList.Add(text);
										while (buPLCHandler.m__0001 != null)
										{
											buPLCHandler.m__0001(text);
											if (0 == 0)
											{
												break;
											}
										}
										break;
									}
								}
								num2 = 0;
								goto IL_01a2;
							}
						}
						finally
						{
							array5 = null;
						}
					}
				}
				ptr2 = null;
				try
				{
					array4 = array3;
					fixed (byte[] array5 = array4)
					{
						if (array4 != null)
						{
							num = array5.Length;
							goto IL_008f_2;
						}
						goto IL_0091_2;
						IL_01a2_2:
						int num2;
						num = ((num2 > array2.Length - 1) ? 1 : 0);
						if (false)
						{
							goto IL_008f_2;
						}
						if (num == 0)
						{
							num3 = ((array2[num2] < 1) ? 1 : 0);
							num4 = 0;
							goto IL_0177_2;
						}
						int num7 = 1;
						return num7;
						IL_008f_2:
						if (num == 0)
						{
							goto IL_0091_2;
						}
						byte* ptr3 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array5[0]);
						goto IL_01db_2;
						IL_0177_2:
						if (num3 == num4)
						{
							Value[num2] = true;
						}
						else
						{
							Value[num2] = false;
						}
						num2++;
						goto IL_01a2_2;
						IL_0091_2:
						ptr3 = null;
						goto IL_01db_2;
						IL_01db_2:
						int num5 = _0005._0004._0001(array, VarName.Count, ptr2, ptr3);
						num3 = num5;
						num4 = 0;
						if (num4 != 0)
						{
							goto IL_0177_2;
						}
						bool flag = (uint)num3 > (uint)num4;
						num6 = (flag ? 1 : 0);
						while (num6 != 0)
						{
							num6 = 5;
							if (num6 == 0)
							{
								continue;
							}
							array6 = new string[num6];
							array6[0] = _0015(107396134);
							array6[1] = num5.ToString();
							array6[2] = _0015(107396988);
							array6[3] = VarName[0];
							array6[4] = _0015(107396947);
							string text = string.Concat(array6);
							ErrorList.Add(text);
							while (buPLCHandler.m__0001 != null)
							{
								buPLCHandler.m__0001(text);
								if (0 == 0)
								{
									break;
								}
							}
							break;
						}
						num2 = 0;
						goto IL_01a2_2;
					}
				}
				finally
				{
					array5 = null;
				}
			}
			finally
			{
			}
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public unsafe static int ReadMultiVariableBOOL(ref List<VariableBOOLDef> Vars)
	{
		try
		{
			int num;
			if (0 == 0)
			{
				num = Vars.Count;
				goto IL_000d;
			}
			goto IL_0032;
			IL_0032:
			string[] array;
			int num2;
			array[num2] = Vars[num2].Name;
			Vars[num2].Value = false;
			num = num2 + 1;
			if (0 == 0)
			{
				if (false)
				{
					goto IL_000d;
				}
				num2 = num;
				goto IL_005b;
			}
			goto IL_005c;
			IL_000d:
			array = new string[num];
			byte[] array2 = new byte[Vars.Count];
			byte[] array3 = new byte[Vars.Count];
			num2 = 0;
			goto IL_005b;
			IL_005b:
			num = num2;
			goto IL_005c;
			IL_005c:
			if (num > Vars.Count - 1)
			{
				fixed (byte* ptr = array2)
				{
					try
					{
						fixed (byte[] array4 = array3)
						{
							nint num3;
							if (array3 != null)
							{
								num3 = (nint)array4.LongLength;
								goto IL_009b;
							}
							goto IL_00a4;
							IL_0177:
							int num4 = 0;
							goto IL_01c4;
							IL_009b:
							int num5 = (int)num3;
							if (5 == 0)
							{
								goto IL_01c0;
							}
							if (num5 == 0)
							{
								goto IL_00a4;
							}
							byte* ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array4[0]);
							goto IL_01fd;
							IL_01bd:
							num5 = num4;
							goto IL_01c0;
							IL_01c0:
							num4 = num5 + 1;
							goto IL_01c4;
							IL_00a4:
							ptr2 = null;
							goto IL_01fd;
							IL_01fd:
							int num6 = _0005._0004._0001(array, Vars.Count, ptr, ptr2);
							bool flag = num6 != 0;
							bool num7 = flag;
							goto IL_00e9;
							IL_00e9:
							string text;
							if (num7)
							{
								text = _0015(107396134) + num6 + _0015(107396988) + Vars[0].Name + _0015(107396947);
								ErrorList.Add(text);
								goto IL_0158;
							}
							goto IL_0177;
							IL_01c4:
							bool flag2 = num4 <= array2.Length - 1;
							num7 = flag2;
							if (false)
							{
								goto IL_00e9;
							}
							if (!num7)
							{
								return 1;
							}
							bool num8 = array2[num4] >= 1;
							num3 = (num8 ? 1 : 0);
							if (7 == 0)
							{
								goto IL_009b;
							}
							bool flag3 = num8;
							while (flag3)
							{
								if (false)
								{
									continue;
								}
								goto IL_0196;
							}
							Vars[num4].Value = false;
							goto IL_01bd;
							IL_0158:
							if (buPLCHandler.m__0001 != null)
							{
								buPLCHandler.m__0001(text);
							}
							goto IL_0177;
							IL_0196:
							Vars[num4].Value = true;
							if (false)
							{
								goto IL_0158;
							}
							goto IL_01bd;
						}
					}
					finally
					{
						array4 = null;
					}
				}
			}
			goto IL_0032;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static int WriteVariableLREAL(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _001F._009B(_001E._009A(_001D._0099(Value), 5));
			uint num;
			int num2;
			if (0 == 0)
			{
				num = SetPLCvalue(pszName, data);
				num2 = (int)num;
				if (false)
				{
					goto IL_00e3;
				}
				if (num2 == 0)
				{
					goto IL_00f5;
				}
			}
			string text = _0019._0095(new string[6]
			{
				_0015(107396925),
				num.ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			});
			ErrorList.Add(text);
			bool flag = buPLCHandler.m__0001 != null;
			num2 = (flag ? 1 : 0);
			goto IL_00e3;
			IL_00e3:
			if (num2 != 0)
			{
				buPLCHandler.m__0001(text);
			}
			goto IL_00f5;
			IL_00f5:
			return (int)num;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396925),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariableREAL(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _0080._009D(_007F._009C(Value));
			int num = (int)SetPLCvalue(pszName, data);
			uint num2;
			while (true)
			{
				num2 = (uint)num;
				if (num2 == 0)
				{
					break;
				}
				string text = _0019._0095(new string[6]
				{
					_0015(107396565),
					num2.ToString(),
					_0015(107396988),
					VarName,
					_0015(107396336),
					global::_0005._007E_0011(Value)
				});
				ErrorList.Add(text);
				bool flag = buPLCHandler.m__0001 != null;
				num = (flag ? 1 : 0);
				if (7u != 0)
				{
					if (num != 0)
					{
						buPLCHandler.m__0001(text);
					}
					break;
				}
			}
			return (int)num2;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396565),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariableDINT(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _0082._009F(_0081._009E(Value));
			int num = (int)SetPLCvalue(pszName, data);
			uint num2;
			while (true)
			{
				num2 = (uint)num;
				if (num2 == 0)
				{
					break;
				}
				string text = _0019._0095(new string[6]
				{
					_0015(107396552),
					num2.ToString(),
					_0015(107396988),
					VarName,
					_0015(107396336),
					global::_0005._007E_0011(Value)
				});
				ErrorList.Add(text);
				bool flag = buPLCHandler.m__0001 != null;
				num = (flag ? 1 : 0);
				if (7u != 0)
				{
					if (num != 0)
					{
						buPLCHandler.m__0001(text);
					}
					break;
				}
			}
			return (int)num2;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396552),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariableINT(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _0084._0002_0002(_0083._0001_0002(Value));
			int num = (int)SetPLCvalue(pszName, data);
			uint num2;
			while (true)
			{
				num2 = (uint)num;
				if (num2 == 0)
				{
					break;
				}
				string text = _0019._0095(new string[6]
				{
					_0015(107396475),
					num2.ToString(),
					_0015(107396988),
					VarName,
					_0015(107396336),
					global::_0005._007E_0011(Value)
				});
				ErrorList.Add(text);
				bool flag = buPLCHandler.m__0001 != null;
				num = (flag ? 1 : 0);
				if (7u != 0)
				{
					if (num != 0)
					{
						buPLCHandler.m__0001(text);
					}
					break;
				}
			}
			return (int)num2;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396475),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariableBOOL(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _0087._0004_0002(_0086._0003_0002(Value));
			int num = (int)SetPLCvalue(pszName, data);
			uint num2;
			while (true)
			{
				num2 = (uint)num;
				if (num2 == 0)
				{
					break;
				}
				string text = _0019._0095(new string[6]
				{
					_0015(107396430),
					num2.ToString(),
					_0015(107396988),
					VarName,
					_0015(107396336),
					global::_0005._007E_0011(Value)
				});
				ErrorList.Add(text);
				bool flag = buPLCHandler.m__0001 != null;
				num = (flag ? 1 : 0);
				if (7u != 0)
				{
					if (num != 0)
					{
						buPLCHandler.m__0001(text);
					}
					break;
				}
			}
			return (int)num2;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396430),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariableSTRING(string VarName, object Value)
	{
		try
		{
			byte[] pszName = _0018._007E_0094(_0017._0092(), VarName);
			byte[] data = _0018._007E_0094(_0017._0092(), _0088._0005_0002(Value));
			int num = (int)SetPLCvalue(pszName, data);
			uint num2;
			string text = default(string);
			if (8u != 0)
			{
				num2 = (uint)num;
				num = (int)num2;
				if (8u != 0)
				{
					bool flag = num != 0;
					if (true)
					{
						if (0 == 0)
						{
							if (!flag)
							{
								goto IL_0109;
							}
							if (5 == 0)
							{
								goto IL_00f9;
							}
						}
						text = _0019._0095(new string[6]
						{
							_0015(107396417),
							num2.ToString(),
							_0015(107396988),
							VarName,
							_0015(107396336),
							global::_0005._007E_0011(Value)
						});
						ErrorList.Add(text);
						num = ((buPLCHandler.m__0001 != null) ? 1 : 0);
						goto IL_00f0;
					}
					goto IL_0109;
				}
			}
			goto IL_00f4;
			IL_00f9:
			buPLCHandler.m__0001(text);
			goto IL_0109;
			IL_00f4:
			if (false)
			{
				goto IL_00f0;
			}
			if (num != 0)
			{
				goto IL_00f9;
			}
			goto IL_0109;
			IL_00f0:
			bool flag2 = (byte)num != 0;
			num = (flag2 ? 1 : 0);
			goto IL_00f4;
			IL_0109:
			return (int)num2;
		}
		catch (Exception)
		{
			ErrorList.Add(_0019._0095(new string[6]
			{
				_0015(107396417),
				(-1).ToString(),
				_0015(107396988),
				VarName,
				_0015(107396336),
				global::_0005._007E_0011(Value)
			}));
			return -1;
		}
	}

	public static int WriteVariable(string VarName, object Value)
	{
		try
		{
			int result;
			while (true)
			{
				result = -1;
				if (_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(double).TypeHandle)))
				{
					result = WriteVariableLREAL(VarName, Value);
					if (8 == 0)
					{
						goto IL_00c1;
					}
				}
				if (_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(float).TypeHandle)))
				{
					result = WriteVariableREAL(VarName, Value);
					if (2 == 0)
					{
						goto IL_0156;
					}
				}
				if (-1 == 0)
				{
					continue;
				}
				if (_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(short).TypeHandle)))
				{
					result = WriteVariableINT(VarName, Value);
				}
				goto IL_00c1;
				IL_00c1:
				if (_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(int).TypeHandle)))
				{
					if (5 == 0)
					{
						break;
					}
					result = WriteVariableDINT(VarName, Value);
				}
				if (_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(bool).TypeHandle)))
				{
					result = WriteVariableBOOL(VarName, Value);
				}
				if (!_001C._0098(_0089._007E_0006_0002(Value), _001B._0097(typeof(string).TypeHandle)))
				{
					break;
				}
				goto IL_0156;
				IL_0156:
				result = WriteVariableSTRING(VarName, Value);
				break;
			}
			return result;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static int WriteVariable(string VarName, object Value, Type VarType)
	{
		int result;
		do
		{
			try
			{
				int num = -1;
				if (_001C._0098(VarType, _001B._0097(typeof(double).TypeHandle)))
				{
					num = WriteVariableLREAL(VarName, Value);
				}
				if (4u != 0)
				{
					if (_001C._0098(VarType, _001B._0097(typeof(float).TypeHandle)))
					{
						goto IL_0068;
					}
					goto IL_0072;
				}
				goto IL_00f4;
				IL_00c7:
				bool flag = _001C._0098(VarType, _001B._0097(typeof(bool).TypeHandle));
				int num2 = (flag ? 1 : 0);
				if (false)
				{
					goto IL_00c5;
				}
				if (num2 != 0)
				{
					num = WriteVariableBOOL(VarName, Value);
				}
				goto IL_00f4;
				IL_00f4:
				result = num;
				goto end_IL_0001;
				IL_00c5:
				num = num2;
				goto IL_00c7;
				IL_0068:
				num = WriteVariableREAL(VarName, Value);
				goto IL_0072;
				IL_0072:
				if (-1 == 0)
				{
					goto IL_0068;
				}
				if (_001C._0098(VarType, _001B._0097(typeof(short).TypeHandle)))
				{
					num = WriteVariableINT(VarName, Value);
				}
				if (_001C._0098(VarType, _001B._0097(typeof(int).TypeHandle)))
				{
					num2 = WriteVariableDINT(VarName, Value);
					goto IL_00c5;
				}
				goto IL_00c7;
				end_IL_0001:;
			}
			catch (Exception)
			{
				result = -1;
			}
		}
		while (8 == 0);
		return result;
	}

	public static int WriteVariable(string VarName, object Value, VariableType VarType)
	{
		int result;
		do
		{
			if (false)
			{
				continue;
			}
			try
			{
				int num;
				while (true)
				{
					bool num2;
					if (0 == 0)
					{
						num = -1;
						num2 = VarType == VariableType.LREAL;
						while (true)
						{
							if (num2)
							{
								num = WriteVariableLREAL(VarName, Value);
								if (false)
								{
									break;
								}
							}
							if (VarType == VariableType.REAL)
							{
								num = WriteVariableREAL(VarName, Value);
							}
							if (VarType == VariableType.INT)
							{
								num = WriteVariableINT(VarName, Value);
							}
							bool flag = VarType == VariableType.DINT;
							num2 = flag;
							if (false)
							{
								continue;
							}
							goto IL_0074;
						}
					}
					goto IL_0091;
					IL_0074:
					if (num2)
					{
						num = WriteVariableDINT(VarName, Value);
					}
					bool flag2 = VarType == VariableType.Bool;
					if (8 == 0)
					{
						continue;
					}
					if (!flag2)
					{
						break;
					}
					goto IL_0091;
					IL_0091:
					num = WriteVariableBOOL(VarName, Value);
					break;
				}
				if (VarType == VariableType.STRING)
				{
					num = WriteVariableSTRING(VarName, Value);
				}
				result = num;
			}
			catch (Exception)
			{
				result = -1;
			}
		}
		while (6 == 0);
		return result;
	}

	public unsafe static uint SetPLCvalue(byte[] pszName, byte[] data)
	{
		//The blocks IL_0000, IL_0003, IL_0033, IL_0036, IL_0037, IL_0039, IL_0053, IL_0069, IL_006f, IL_0075 are reachable both inside and outside the pinned region starting at IL_0007. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0033, IL_0036, IL_0037, IL_0039, IL_0053, IL_0069, IL_006f, IL_0075 are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		nint num;
		byte* ptr = default(byte*);
		byte* ptr2 = default(byte*);
		if (4u != 0)
		{
			byte[] array = pszName;
			while (true)
			{
				fixed (byte[] array2 = array)
				{
					if (array != null)
					{
						if (8 == 0)
						{
							goto IL_0075;
						}
						if (array2.Length != 0)
						{
							ptr = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[0]);
							goto IL_0027;
						}
					}
					if (false)
					{
						if (4u != 0)
						{
							array = pszName;
							continue;
						}
						num = (nint)array3.LongLength;
						if (4u != 0)
						{
							if (false)
							{
								goto IL_0053;
							}
							num = (int)num;
						}
						if (num == 0)
						{
							ptr2 = null;
						}
						else
						{
							ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
						}
						goto IL_0075;
					}
					ptr = null;
					goto IL_0027;
					IL_0075:
					num = (int)_0005._0004._0001(ptr, ptr2);
					goto IL_0053;
					IL_0053:
					return (uint)num;
					IL_0027:
					fixed (byte[] array3 = data)
					{
						if (data != null)
						{
							num = (nint)array3.LongLength;
							if (4u != 0)
							{
								if (false)
								{
									goto IL_0053_2;
								}
								num = (int)num;
							}
							if (num != 0)
							{
								ptr2 = (byte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]);
								goto IL_0075_2;
							}
						}
						ptr2 = null;
						goto IL_0075_2;
						IL_0053_2:
						return (uint)num;
						IL_0075_2:
						num = (int)_0005._0004._0001(ptr, ptr2);
						goto IL_0053_2;
					}
				}
			}
		}
		num = (nint)array3.LongLength;
		if (4u != 0)
		{
			if (false)
			{
				goto IL_0053_3;
			}
			num = (int)num;
		}
		ptr2 = (byte*)((num != 0) ? System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[0]) : null);
		num = (int)_0005._0004._0001(ptr, ptr2);
		goto IL_0053_3;
		IL_0053_3:
		return (uint)num;
	}

	public static int ClassToPLC(object Variable, string RootString, string AfterString = "")
	{
		int num = _008A._000E_0002();
		try
		{
			while (true)
			{
				IL_0011:
				if (!AppBool.Connected)
				{
					if (2u != 0)
					{
						return -1;
					}
					break;
				}
				if (Variable == null)
				{
					_0012._008B(_0015(107395824));
					return -1;
				}
				FieldInfo[] array = null;
				object obj = null;
				obj = Variable;
				while (true)
				{
					IL_0074:
					if (obj != null)
					{
						array = _008B._007E_000F_0002(_0089._007E_0006_0002(obj));
						if (array == null)
						{
							break;
						}
						for (int i = 0; i <= array.Length - 1; i++)
						{
							object obj2 = null;
							FieldInfo fieldInfo = array[i];
							string text = global::_0005._007E_0012(fieldInfo);
							string text2 = global::_0005._007E_0012(fieldInfo);
							int num2 = _008C._007E_0010_0002(global::_0005._007E_0011(_0089._007E_0007_0002(fieldInfo)), _0015(107395815));
							int num5;
							while (num2 < 0)
							{
								obj2 = _008D._007E_0012_0002(fieldInfo, obj);
								while (true)
								{
									if (_001C._0098(_0089._007E_0008_0002(_0089._007E_0007_0002(fieldInfo)), _001B._0097(typeof(Enum).TypeHandle)))
									{
										int num3 = _0081._009E(obj2);
										WriteVariableDINT(_008E._0013_0002(RootString, text, AfterString), num3);
									}
									num2 = (_001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(double).TypeHandle)) ? 1 : 0);
									if (false)
									{
										break;
									}
									if (num2 != 0)
									{
										if (5 == 0)
										{
											goto IL_0074;
										}
										if (5 == 0)
										{
											continue;
										}
										double num4 = _001D._0099(obj2);
										num5 = WriteVariableLREAL(_008E._0013_0002(RootString, text, AfterString), num4);
									}
									goto IL_01e7;
								}
							}
							continue;
							IL_01e7:
							while (true)
							{
								IL_01e7_2:
								bool flag = _001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(float).TypeHandle));
								while (true)
								{
									if (flag)
									{
										float num6 = _007F._009C(obj2);
										WriteVariableREAL(_008E._0013_0002(RootString, text, AfterString), num6);
									}
									int num7 = (_001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(int).TypeHandle)) ? 1 : 0);
									if (-1 == 0)
									{
										break;
									}
									if (num7 != 0)
									{
										int num8 = _0081._009E(obj2);
										WriteVariableDINT(_008E._0013_0002(RootString, text, AfterString), num8);
									}
									if (4 == 0)
									{
										goto IL_0011;
									}
									num5 = (_001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(short).TypeHandle)) ? 1 : 0);
									if (false)
									{
										goto IL_01e7_2;
									}
									if (num5 != 0)
									{
										short num9 = _0083._0001_0002(obj2);
										WriteVariableINT(_008E._0013_0002(RootString, text, AfterString), num9);
									}
									if (_001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(bool).TypeHandle)))
									{
										bool flag2 = _0086._0003_0002(obj2);
										WriteVariableBOOL(_008E._0013_0002(RootString, text, AfterString), flag2);
									}
									if (!_001C._0098(_0089._007E_0006_0002(obj2), _001B._0097(typeof(string).TypeHandle)))
									{
										break;
									}
									string text3 = _0088._0005_0002(obj2);
									if (0 == 0)
									{
										if (_000E._007E_0019(text3) > 0)
										{
											num7 = WriteVariableSTRING(_008E._0013_0002(RootString, text, AfterString), text3);
										}
										break;
									}
								}
								break;
							}
						}
						break;
					}
					return -1;
				}
				break;
			}
			return 1;
		}
		catch (Exception ex)
		{
			string text4 = _0002._0003(_0015(107395806), global::_0005._007E_0011(Variable));
			_008F._0014_0002(ex, _0015(107395757), false, text4);
			return -1;
		}
	}

	static buPLCHandler()
	{
		Type typeFromHandle = typeof(buPLCHandler);
		if (0 == 0)
		{
			Strings.CreateGetStringDelegate(typeFromHandle);
		}
		buPLCHandler.m__0001 = false;
		DeviceIP = _0015(107395772);
		int num2;
		while (true)
		{
			DeviceAddress = _0015(107395751);
			DeviceName = _0015(107395746);
			int num = 0;
			if (num == 0)
			{
				isConnect = (byte)num != 0;
				ThreatCount = 0;
				num2 = 1;
				goto IL_0057;
			}
			goto IL_0060;
			IL_0057:
			ThreadEnable = (byte)num2 != 0;
			if (false)
			{
				continue;
			}
			num = 0;
			goto IL_0060;
			IL_0060:
			ThreadWaitCount = num;
			ErrorList = new List<string>();
			num2 = 0;
			if (num2 == 0)
			{
				break;
			}
			goto IL_0057;
		}
		PLCStatus = num2;
	}
}

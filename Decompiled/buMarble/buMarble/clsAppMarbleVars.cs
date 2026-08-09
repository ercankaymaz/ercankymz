using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Vision;
using buMotion;

namespace buMarble;

public class clsAppMarbleVars
{
	internal static bool _0001;

	public static MarbleCustomers customerType;

	public static clsAppMarble cmdMarble;

	public static clsAppMarbleMachineReport reportMachine;

	public static CodesysMachine cMachine;

	public static clsAppMarbleInterfaceVar varInterface;

	public static clsAppMarbleRuntimeVar varRuntime;

	public static clsAppMarbleOPVar varApp;

	public static clsAppMarbleFormVar varForms;

	public static F_MarbleToolSawMilling frmToolSawMilling;

	public static F_CameraLive FrmCameraLive;

	[NonSerialized]
	internal static GetString _007F;

	public clsAppMarbleVars()
	{
		if (!_0001(_007F(107396867)))
		{
			MessageBox.Show(_007F(107396867));
			throw new RegisterException(_007F(107396867));
		}
	}

	internal static bool _0001(string P_0)
	{
		bool result;
		try
		{
			if (global::_0001._0001(P_0, _007F(107396842)))
			{
				goto IL_002c;
			}
			if (global::_0001._0002(buVector.AskMeResult, _007F(107396785)) | (buVector.AskMeValue != -5861345679435.912))
			{
				BinaryReader binaryReader = null;
				try
				{
					FileInfo fileInfo = new FileInfo(global::_0002._0003(AppPath.Base, _007F(107396696)));
					if (!global::_0003._007E_0004(fileInfo))
					{
						throw new RegisterException(P_0);
					}
					if (!global::_0003._007E_0004(fileInfo))
					{
						throw new RegisterException(P_0);
					}
					List<double> list = new List<double>();
					List<string> list2 = new List<string>();
					List<string> list3 = new List<string>();
					bool flag = false;
					bool flag2 = false;
					try
					{
						global::_0004._0018(_007F(107396711), _007F(107396702), _007F(107396653), _007F(107396680), 0.0, 0.0, false);
						FileStream input = new FileStream(global::_0005._007E_0019(fileInfo), FileMode.Open, FileAccess.Read, FileShare.None);
						binaryReader = new BinaryReader(input);
						int num = 0;
						string text = _007F(107396675);
						string text2 = _007F(107396675);
						string text3 = _007F(107396675);
						string text4 = _007F(107396675);
						string text5 = _007F(107396675);
						string text6 = _007F(107396675);
						string text7 = _007F(107396675);
						string text8 = _007F(107396675);
						string text9 = _007F(107396675);
						string text10 = _007F(107396675);
						string text11 = _007F(107396675);
						string text12 = _007F(107396675);
						string text13 = _007F(107396675);
						string text14 = _007F(107396675);
						float num2 = 0f;
						double num3 = 0.0;
						decimal num4 = default(decimal);
						int num5 = 0;
						for (int i = 0; i < 755; i++)
						{
							num2 = global::_0006._007E_0092(binaryReader);
						}
						for (int j = 0; j < 1274; j++)
						{
							num3 = global::_0007._007E_0093(binaryReader);
						}
						for (int k = 0; k < 1498; k++)
						{
							num4 = global::_0008._007E_0098(binaryReader);
						}
						for (int l = 0; l < 5614; l++)
						{
							num3 = global::_000E._007E_0099(binaryReader);
						}
						for (int m = 0; m < 4243; m++)
						{
							num2 = global::_0006._007E_0092(binaryReader);
						}
						int num6 = 0;
						while (true)
						{
							int num7 = ((num6 < 9867) ? 1 : 0);
							int num8;
							if (0 == 0)
							{
								if (5 == 0)
								{
									goto IL_0359;
								}
								if (num7 != 0)
								{
									num3 = global::_0007._007E_0093(binaryReader);
									num7 = num6 + 1;
									goto IL_0359;
								}
								num8 = 0;
								goto IL_038d;
							}
							goto IL_0583;
							IL_053d:
							int num9;
							string text15;
							int num11;
							if (num9 <= num5 - 1)
							{
								double num10 = 0.0;
								num10 = global::_0007._007E_0093(binaryReader) / 65.87;
								list.Add(num10);
								num11 = global::_000E._007E_0099(binaryReader);
								text15 = _007F(107396675);
								int num12 = 0;
								while (5u != 0)
								{
									if (num12 < num11)
									{
										byte b = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 46.8613);
										text15 = global::_0002._0003(text15, global::_0010._0017_0002(b).ToString());
										num12++;
										continue;
									}
									goto IL_04a1;
								}
								goto IL_084a;
							}
							num = global::_000E._007E_0099(binaryReader);
							int num13 = 0;
							goto IL_05af;
							IL_052c:
							string text16;
							list3.Add(text16);
							num9++;
							goto IL_053d;
							IL_0396:
							bool num14;
							if (num14 != 0)
							{
								num4 = global::_0008._007E_0098(binaryReader);
								num8++;
								goto IL_038d;
							}
							for (int n = 0; n < 5765; n++)
							{
								num3 = global::_000E._007E_0099(binaryReader);
							}
							num5 = global::_000E._007E_0099(binaryReader);
							list.Clear();
							list2.Clear();
							list3.Clear();
							num9 = 0;
							goto IL_053d;
							IL_038d:
							num14 = num8 < 3886;
							goto IL_0396;
							IL_0359:
							num6 = num7;
							continue;
							IL_0583:
							byte b2 = (byte)num7;
							text = global::_0002._0003(text, global::_0010._0017_0002(b2).ToString());
							num13++;
							goto IL_05af;
							IL_05af:
							if (num13 < num)
							{
								num7 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								goto IL_0583;
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num15 = 0; num15 < num; num15++)
							{
								byte b3 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text2 = global::_0002._0003(text2, global::_0010._0017_0002(b3).ToString());
								if (false)
								{
									goto end_IL_035b;
								}
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num16 = 0; num16 < num; num16++)
							{
								byte b4 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text3 = global::_0002._0003(text3, global::_0010._0017_0002(b4).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num17 = 0; num17 < num; num17++)
							{
								byte b5 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text4 = global::_0002._0003(text4, global::_0010._0017_0002(b5).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num18 = 0; num18 < num; num18++)
							{
								byte b6 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text5 = global::_0002._0003(text5, global::_0010._0017_0002(b6).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num19 = 0; num19 < num; num19++)
							{
								byte b7 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text6 = global::_0002._0003(text6, global::_0010._0017_0002(b7).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num20 = 0; num20 < num; num20++)
							{
								byte b8 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text7 = global::_0002._0003(text7, global::_0010._0017_0002(b8).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							goto IL_084a;
							IL_0bb4:
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0003._007E_0005(binaryReader);
							global::_0003._007E_0005(binaryReader);
							flag = global::_0003._007E_0005(binaryReader);
							int num21 = (global::_0003._007E_0005(binaryReader) ? 1 : 0);
							if (false)
							{
								goto IL_04ca;
							}
							global::_0003._007E_0005(binaryReader);
							bool flag3 = global::_0003._007E_0005(binaryReader);
							global::_0003._007E_0005(binaryReader);
							flag2 = global::_0003._007E_0005(binaryReader);
							global::_0003._007E_0005(binaryReader);
							global::_0003._007E_0005(binaryReader);
							if (0 == 0)
							{
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0007._007E_0093(binaryReader);
								global::_0007._007E_0093(binaryReader);
								break;
							}
							goto IL_0a48;
							IL_04a1:
							list2.Add(text15);
							num11 = global::_000E._007E_0099(binaryReader);
							text16 = _007F(107396675);
							num21 = 0;
							goto IL_04ca;
							IL_084a:
							for (int num22 = 0; num22 < num; num22++)
							{
								byte b9 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text8 = global::_0002._0003(text8, global::_0010._0017_0002(b9).ToString());
							}
							num = global::_000E._007E_0099(binaryReader);
							for (int num23 = 0; num23 < num; num23++)
							{
								byte b10 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 54.3685);
								text9 = global::_0002._0003(text9, global::_0010._0017_0002(b10).ToString());
							}
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							global::_0007._007E_0093(binaryReader);
							double num24 = global::_0007._007E_0093(binaryReader);
							int num26;
							if (2u != 0)
							{
								global::_0007._007E_0093(binaryReader);
								num = global::_000E._007E_0099(binaryReader);
								for (int num25 = 0; num25 < num; num25++)
								{
									byte b11 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 64.3685);
									text10 = global::_0002._0003(text10, global::_0010._0017_0002(b11).ToString());
								}
								string text17 = text10;
								num = global::_000E._007E_0099(binaryReader);
								num26 = 0;
								goto IL_0a4f;
							}
							goto IL_0bb4;
							IL_0a48:
							num26++;
							goto IL_0a4f;
							IL_0a4f:
							if (num26 < num)
							{
								byte b12 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 64.3685);
								text11 = global::_0002._0003(text11, global::_0010._0017_0002(b12).ToString());
								goto IL_0a48;
							}
							string text18 = text11;
							num = global::_000E._007E_0099(binaryReader);
							for (int num27 = 0; num27 < num; num27++)
							{
								byte b13 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 64.3685);
								text12 = global::_0002._0003(text12, global::_0010._0017_0002(b13).ToString());
							}
							string text19 = text12;
							num = global::_000E._007E_0099(binaryReader);
							for (int num28 = 0; num28 < num; num28++)
							{
								byte b14 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 64.3685);
								text13 = global::_0002._0003(text13, global::_0010._0017_0002(b14).ToString());
							}
							string text20 = text13;
							num = global::_000E._007E_0099(binaryReader);
							for (int num29 = 0; num29 < num; num29++)
							{
								byte b15 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 64.3685);
								text14 = global::_0002._0003(text14, global::_0010._0017_0002(b15).ToString());
							}
							string text21 = text14;
							num24 = global::_0007._007E_0093(binaryReader);
							goto IL_0bb4;
							IL_04ca:
							int num30 = num21;
							while (true)
							{
								bool flag4 = num30 < num11;
								num14 = flag4;
								if (8 == 0)
								{
									break;
								}
								if (num14)
								{
									byte b16 = global::_000F._0016_0002(global::_0007._007E_0093(binaryReader) / 86.3456);
									text16 = global::_0002._0003(text16, global::_0010._0017_0002(b16).ToString());
									num30++;
									continue;
								}
								goto IL_052c;
							}
							goto IL_0396;
							continue;
							end_IL_035b:
							break;
						}
						global::_0007._007E_0093(binaryReader);
						global::_0011._007E_0018_0002(binaryReader);
						global::_0004._0018(_007F(107396711), _007F(107396674), _007F(107396653), _007F(107396625), 0.0, 0.0, false);
					}
					catch (Exception ex)
					{
						global::_0012._009A_0003(global::_0005._007E_001A(ex));
						global::_0011._007E_0018_0002(binaryReader);
						throw new RegisterException(P_0);
					}
					List<string> MacAddress = new List<string>();
					List<string> CpuAddress = new List<string>();
					string MBAddress = _007F(107396675);
					getMacAddress(ref MacAddress);
					global::_0004._0018(_007F(107396711), _007F(107396620), _007F(107396653), _007F(107396625), 0.0, 0.0, false);
					getCpuID(ref CpuAddress);
					global::_0004._0018(_007F(107396711), _007F(107397115), _007F(107396653), _007F(107396625), 0.0, 0.0, false);
					GetMotherBoardID(ref MBAddress);
					global::_0004._0018(_007F(107396711), _007F(107397130), _007F(107396653), _007F(107396625), 0.0, 0.0, false);
					if (!(!flag && !flag2))
					{
						goto IL_0f0d;
					}
					bool flag5 = _0005._0003._0001(MacAddress, MBAddress, list, CpuAddress, P_0);
					global::_0004._0018(_007F(107396711), _007F(107397130), _007F(107396653), _007F(107396625), 0.0, 0.0, false);
					bool num31 = flag5;
					if (0 == 0)
					{
						bool flag6 = num31;
						num31 = flag6;
					}
					if (!num31)
					{
						goto IL_0f0d;
					}
					clsAppMarbleVars._0001 = true;
					result = true;
					goto end_IL_0078;
					IL_0f0d:
					throw new RegisterException(P_0);
					end_IL_0078:;
				}
				catch (Exception)
				{
					throw new RegisterException(P_0);
				}
			}
			else
			{
				clsAppMarbleVars._0001 = true;
				result = true;
				if (6 == 0)
				{
					goto IL_002c;
				}
			}
			goto end_IL_0001;
			IL_002c:
			result = true;
			end_IL_0001:;
		}
		catch (Exception)
		{
			throw new RegisterException(P_0);
		}
		return result;
	}

	public static string getCpuID(ref List<string> CpuAddress)
	{
		string result;
		do
		{
			string text = _007F(107396675);
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_007F(107397081));
				ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
				foreach (ManagementObject item in managementObjectCollection)
				{
					if (3u != 0)
					{
						text = item[_007F(107397060)].ToString();
					}
					CpuAddress.Add(text);
				}
				result = text;
			}
			catch (Exception mSException)
			{
				if (0 == 0)
				{
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, _007F(107396675));
				}
				result = _007F(107396675);
			}
		}
		while (3 == 0);
		return result;
	}

	public static string GetMotherBoardID(ref string MBAddress)
	{
		MBAddress = _007F(107396675);
		ManagementScope managementScope = new ManagementScope(global::_0014._009F_0003(_007F(107397011), global::_0013._009D_0003(), _007F(107397006)));
		ManagementScope managementScope2;
		if (4u != 0)
		{
			managementScope2 = managementScope;
		}
		global::_0011._007E_0019_0002(managementScope2);
		ManagementObject managementObject = new ManagementObject(managementScope2, new ManagementPath(_007F(107397021)), new ObjectGetOptions());
		PropertyDataCollection.PropertyDataEnumerator propertyDataEnumerator = global::_0016._007E_0003_0004(global::_0015._007E_0002_0004(managementObject));
		try
		{
			while (true)
			{
				if (global::_0003._007E_0006(propertyDataEnumerator))
				{
					PropertyData propertyData = global::_0017._007E_0004_0004(propertyDataEnumerator);
					while (global::_0001._0001(global::_0005._007E_001B(propertyData), _007F(107396944)))
					{
						if (0 == 0)
						{
							MBAddress = global::_001A._000F_0004(_007F(107396959), global::_0005._007E_001B(propertyData), global::_0019._000E_0004(global::_0018._007E_0005_0004(propertyData)));
							break;
						}
					}
				}
				else if (0 == 0)
				{
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = propertyDataEnumerator as IDisposable;
			while (disposable != null)
			{
				if (0 == 0)
				{
					global::_0011._007E_001A_0002(disposable);
					break;
				}
			}
		}
		return _007F(107396675);
	}

	public static void getMacAddress(ref List<string> MacAddress)
	{
		try
		{
			MacAddress.Clear();
			NetworkInterface[] array = default(NetworkInterface[]);
			int num = default(int);
			if (8u != 0)
			{
				if (2 == 0)
				{
					goto IL_00e3;
				}
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				if (0 == 0)
				{
					array = allNetworkInterfaces;
				}
				num = 0;
			}
			goto IL_00a3;
			IL_009e:
			int num2 = num;
			goto IL_00a0;
			IL_00a0:
			num = num2 + 1;
			goto IL_00a3;
			IL_0093:
			string text;
			MacAddress.Add(text);
			goto IL_009e;
			IL_00e3:
			text = array[num].GetPhysicalAddress().ToString();
			int num3 = ((text.Length == 12) ? 1 : 0);
			int num4 = ((array[num].NetworkInterfaceType == NetworkInterfaceType.Ethernet) ? 1 : 0);
			int num5 = ((array[num].NetworkInterfaceType == NetworkInterfaceType.Wireless80211) ? 1 : 0);
			if (uint.MaxValue != 0)
			{
				bool flag = (byte)(num3 & (num4 | num5)) != 0;
				num2 = (flag ? 1 : 0);
				if (0 == 0)
				{
					if (num2 != 0 && text.Substring(0, 4) != _007F(107396910))
					{
						goto IL_0093;
					}
					goto IL_009e;
				}
				goto IL_00a0;
			}
			goto IL_00a8;
			IL_00a3:
			num3 = num;
			num4 = array.Length;
			goto IL_00a7;
			IL_00a7:
			num5 = 1;
			goto IL_00a8;
			IL_00a8:
			num3 = ((num3 > num4 - num5) ? 1 : 0);
			num4 = 0;
			if (num4 != 0)
			{
				goto IL_00a7;
			}
			if (num3 == num4)
			{
				if (false)
				{
					goto IL_0093;
				}
				goto IL_00e3;
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, _007F(107396675));
		}
	}

	public static string getHddID(ref List<string> HddAddress)
	{
		try
		{
			do
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(_007F(107396933));
				HddAddress.Clear();
				using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
				while (true)
				{
					if (false)
					{
						goto IL_0092;
					}
					ManagementObject managementObject;
					if (managementObjectEnumerator.MoveNext())
					{
						managementObject = (ManagementObject)managementObjectEnumerator.Current;
						goto IL_004b;
					}
					goto IL_00a1;
					IL_00a1:
					if (0 == 0)
					{
						break;
					}
					goto IL_004b;
					IL_0092:
					if (2 == 0)
					{
					}
					continue;
					IL_004b:
					if (managementObject[_007F(107396944)] != null)
					{
						string item = managementObject[_007F(107396944)].ToString();
						if (8 == 0)
						{
							goto IL_00a1;
						}
						HddAddress.Add(item);
					}
					goto IL_0092;
				}
			}
			while (4 == 0);
			return _007F(107396675);
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, _007F(107396675));
			while (false)
			{
			}
			return _007F(107396675);
		}
	}

	public static string getDisplayID(ref List<string> DisplayAddress)
	{
		string result;
		try
		{
			DisplayAddress.Clear();
			while (true)
			{
				if (0 == 0)
				{
					DisplayAddress.Add(_007F(107396344));
					if (1 == 0)
					{
						continue;
					}
					if (-1 == 0)
					{
						break;
					}
					DisplayAddress.Add(_007F(107396355));
				}
				DisplayAddress.Add(_007F(107396302));
				break;
			}
			result = _007F(107396675);
			return result;
		}
		catch (Exception mSException)
		{
			if (0 == 0)
			{
				goto IL_00a2;
			}
			goto IL_00c5;
			IL_00a2:
			if (3u != 0)
			{
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, _007F(107396675));
				goto IL_00c5;
			}
			goto end_IL_009d;
			IL_00c5:
			if (2u != 0)
			{
				return _007F(107396675);
			}
			goto IL_00a2;
			end_IL_009d:;
		}
		return result;
	}

	public void Init()
	{
		cmdMarble = new clsAppMarble();
	}

	static clsAppMarbleVars()
	{
		Strings.CreateGetStringDelegate(typeof(clsAppMarbleVars));
		int num = 0;
		if (num == 0)
		{
			clsAppMarbleVars._0001 = (byte)num != 0;
			num = 1;
		}
		customerType = (MarbleCustomers)num;
		if (0 == 0)
		{
			cmdMarble = null;
			if (0 == 0)
			{
				reportMachine = null;
			}
			if (false)
			{
				return;
			}
			if (8 == 0)
			{
				goto IL_009c;
			}
			cMachine = new CodesysMachine();
			varInterface = new clsAppMarbleInterfaceVar();
		}
		varRuntime = new clsAppMarbleRuntimeVar();
		varApp = new clsAppMarbleOPVar();
		varForms = new clsAppMarbleFormVar();
		goto IL_009c;
		IL_009c:
		frmToolSawMilling = new F_MarbleToolSawMilling();
		FrmCameraLive = new F_CameraLive();
	}
}

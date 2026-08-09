using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;

namespace Basler.Pylon;

internal class TestHelper
{
	public static int VersionBuild => 19268;

	public static int VersionSubminor => 1;

	public static int VersionMinor => 2;

	public static int VersionMajor => 7;

	public unsafe static int GEnumerateDevicesAndGetCount(string deviceType)
	{
		AutoInitRelease autoInitRelease = null;
		uint num = 0u;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		int result;
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out CDeviceInfo cDeviceInfo);
			global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bctor_007D(&cDeviceInfo);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &deviceType);
				try
				{
					global::_003CModule_003E.Pylon_002ECDeviceInfo_002ESetDeviceClass(&cDeviceInfo, &gcstring2);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out DeviceInfoList deviceInfoList);
					global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bctor_007D(&deviceInfoList);
					try
					{
						((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, CDeviceInfo*, void>)(int)(*(uint*)(*(int*)(&deviceInfoList) + 88)))((nint)(&deviceInfoList), &cDeviceInfo);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out DeviceInfoList deviceInfoList2);
						global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bctor_007D(&deviceInfoList2);
						try
						{
							CTlFactory* ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance();
							result = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, DeviceInfoList*, DeviceInfoList*, byte, int>)(int)(*(uint*)(int)(*(uint*)ptr)))((nint)ptr, &deviceInfoList2, &deviceInfoList, 0);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DeviceInfoList*, void>)(&global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D), &deviceInfoList2);
							throw;
						}
						global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D(&deviceInfoList2);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DeviceInfoList*, void>)(&global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D), &deviceInfoList);
						throw;
					}
					global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D(&deviceInfoList);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CDeviceInfo*, void>)(&global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bdtor_007D), &cDeviceInfo);
				throw;
			}
			global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bdtor_007D(&cDeviceInfo);
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return result;
	}

	public unsafe static int GEnumerateDevicesAndGetCount()
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		int result;
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DeviceInfoList deviceInfoList);
			global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bctor_007D(&deviceInfoList);
			try
			{
				CTlFactory* ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance();
				result = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, DeviceInfoList*, byte, int>)(int)(*(uint*)(*(int*)ptr + 4)))((nint)ptr, &deviceInfoList, 0);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DeviceInfoList*, void>)(&global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D), &deviceInfoList);
				throw;
			}
			global::_003CModule_003E.Pylon_002EDeviceInfoList_002E_007Bdtor_007D(&deviceInfoList);
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return result;
	}

	public unsafe static int GEnumerateTLsAndGetCount()
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		int result;
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TlInfoList tlInfoList);
			global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bctor_007D(&tlInfoList);
			try
			{
				result = global::_003CModule_003E.Pylon_002ECTlFactory_002EEnumerateTls(global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance(), &tlInfoList);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<TlInfoList*, void>)(&global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bdtor_007D), &tlInfoList);
				throw;
			}
			global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bdtor_007D(&tlInfoList);
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return result;
	}

	public unsafe static ICameraInfo CreateCameraInfo(string[] kvps)
	{
		uint num = 0u;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out CDeviceInfo cDeviceInfo);
		CreateFromKvps_003CPylon_003A_003ACDeviceInfo_003E(&cDeviceInfo, kvps);
		ICameraInfo result;
		try
		{
			result = new CCameraInfoImpl(&cDeviceInfo);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CDeviceInfo*, void>)(&global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bdtor_007D), &cDeviceInfo);
			throw;
		}
		global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bdtor_007D(&cDeviceInfo);
		return result;
	}

	public unsafe static ITransportLayerInfo CreateTranportLayerInfo(string[] kvps)
	{
		uint num = 0u;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out CTlInfo cTlInfo);
		CreateFromKvps_003CPylon_003A_003ACTlInfo_003E(&cTlInfo, kvps);
		ITransportLayerInfo result;
		try
		{
			CTlInfo* ptr = (CTlInfo*)global::_003CModule_003E.@new(8u);
			CTlInfo* pInfo;
			try
			{
				if (ptr != null)
				{
					global::_003CModule_003E.Pylon_002ECTlInfo_002E_007Bctor_007D(ptr, &cTlInfo);
					*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCTlInfo_0040Pylon_0040_00406B_0040);
					pInfo = ptr;
				}
				else
				{
					pInfo = null;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 8u);
				throw;
			}
			result = new CTransportLayerInfoImpl((CInfoBase*)pInfo);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CTlInfo*, void>)(&global::_003CModule_003E.Pylon_002ECTlInfo_002E_007Bdtor_007D), &cTlInfo);
			throw;
		}
		global::_003CModule_003E.Pylon_002ECTlInfo_002E_007Bdtor_007D(&cTlInfo);
		return result;
	}

	public unsafe static string StringMarshalRoundTrip(string systemString)
	{
		uint num = 0u;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &systemString);
		string result;
		try
		{
			result = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(&gcstring2);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return result;
	}

	public unsafe static byte[] GetMarshalledStringAsArray(string systemString)
	{
		uint num = 0u;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &systemString);
		byte[] array;
		try
		{
			int num2 = (int)((((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint>)(int)(*(uint*)(*(int*)(&gcstring2) + 72)))((nint)(&gcstring2)) + 1) & 0x7FFFFFFF);
			array = new byte[num2];
			IntPtr source = new IntPtr(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring2) + 44)))((nint)(&gcstring2)));
			Marshal.Copy(source, array, 0, num2);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return array;
	}

	private unsafe static CDeviceInfo* CreateFromKvps_003CPylon_003A_003ACDeviceInfo_003E(CDeviceInfo* P_0, string[] kvps)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num);
		try
		{
			string text = null;
			num = 0u;
			global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bctor_007D(P_0);
			num = 1u;
			int num2 = 0;
			if (0 < (nint)kvps.LongLength - 1)
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
				do
				{
					text = kvps[num2];
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
					try
					{
						text = kvps[num2 + 1];
						global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &text);
						try
						{
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, gcstring*, CDeviceInfo*>)(int)(*(uint*)(*(int*)P_0 + 12)))((nint)P_0, &gcstring2, &gcstring3);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					num2 += 2;
				}
				while (num2 < (nint)kvps.LongLength - 1);
			}
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CDeviceInfo*, void>)(&global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	private unsafe static CTlInfo* CreateFromKvps_003CPylon_003A_003ACTlInfo_003E(CTlInfo* P_0, string[] kvps)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num);
		try
		{
			string text = null;
			num = 0u;
			global::_003CModule_003E.Pylon_002ECTlInfo_002E_007Bctor_007D(P_0);
			num = 1u;
			int num2 = 0;
			if (0 < (nint)kvps.LongLength - 1)
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
				do
				{
					text = kvps[num2];
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
					try
					{
						text = kvps[num2 + 1];
						global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &text);
						try
						{
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, gcstring*, IProperties*>)(int)(*(uint*)(*(int*)P_0 + 12)))((nint)P_0, &gcstring2, &gcstring3);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					num2 += 2;
				}
				while (num2 < (nint)kvps.LongLength - 1);
			}
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CTlInfo*, void>)(&global::_003CModule_003E.Pylon_002ECTlInfo_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}
}

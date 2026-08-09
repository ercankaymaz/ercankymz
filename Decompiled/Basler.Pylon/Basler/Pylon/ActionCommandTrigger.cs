using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using _003FA0xe82174f0;
using GenICam_3_1_Basler_pylon;
using Pylon;
using std;

namespace Basler.Pylon;

public class ActionCommandTrigger
{
	private string m_broadcastAddress;

	private int m_actionId;

	private int m_deviceKey;

	private int m_groupMask;

	private int m_groupKey;

	private bool m_isConfigured = false;

	public int GroupMask => m_groupMask;

	public int GroupKey => m_groupKey;

	public int DeviceKey => m_deviceKey;

	public int ActionId => m_actionId;

	public string BroadcastAddress => m_broadcastAddress;

	public ActionCommandTrigger()
	{
		ResetSettings();
	}

	public unsafe static long GetNow(ICamera camera)
	{
		//Discarded unreachable code: IL_0142
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		long value;
		try
		{
			autoInitRelease = autoInitRelease2;
			if (camera == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			if (!camera.IsOpen)
			{
				string arg = camera.CameraInfo[CameraInfoKey.FriendlyName].ToString();
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"The camera {arg} must be open.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			if (!camera.Parameters.Contains("GevTimestampControlLatch"))
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("The camera must support the \"GevTimestampControlLatch\" feature.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			if (!camera.Parameters.Contains("GevTimestampValue"))
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("The camera must support the \"GevTimestampValue\" feature.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			IntegerName name = (IntegerName)"GevTimestampValue";
			if (!camera.Parameters[name].IsReadable)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("The \"GevTimestampValue\" camera parameter must be readable.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			CommandName name2 = (CommandName)"GevTimestampControlLatch";
			camera.Parameters[name2].Execute();
			IntegerName name3 = (IntegerName)"GevTimestampValue";
			value = camera.Parameters[name3].GetValue();
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return value;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static bool Issue(int deviceKey, int groupKey, int groupMask, string broadcastAddress, int timeoutMs, ActionCommandResult[] results)
	{
		//Discarded unreachable code: IL_0881
		AutoInitRelease autoInitRelease = null;
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		byte b = 0;
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr14);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr15);
			try
			{
				if (results == null)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("results"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				if (results.Length == 0)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Array must not be empty.", "results"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				if (broadcastAddress == null || string.Empty != null)
				{
					broadcastAddress = "255.255.255.255";
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0L_0040JJBMFOCK_0040BaslerGigE_0040));
				ITransportLayer* ptr;
				try
				{
					ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance(), &gcstring2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AutoTlReleaser autoTlReleaser);
				*(int*)(&autoTlReleaser) = (int)ptr;
				bool flag;
				try
				{
					IGigETransportLayer* ptr2 = (IGigETransportLayer*)global::_003CModule_003E.__RTDynamicCast(ptr, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUITransportLayer_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIGigETransportLayer_0040Pylon_0040_0040_00408), 0);
					if (ptr2 != null)
					{
						uint num2 = (uint)results.Length;
						uint num3 = num2;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E obj);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out allocator_003CPylon_003A_003AGigEActionCommandResult_003E allocator_003CPylon_003A_003AGigEActionCommandResult_003E2);
						global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bctor_007D(&obj, num3, global::_003CModule_003E.std_002Eallocator_003CPylon_003A_003AGigEActionCommandResult_003E_002E_007Bctor_007D(&allocator_003CPylon_003A_003AGigEActionCommandResult_003E2));
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
							gcstring* ptr3 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &broadcastAddress);
							try
							{
								flag = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, uint, uint, gcstring*, uint, uint*, GigEActionCommandResult*, byte>)(int)(*(uint*)(*(int*)ptr2 + 84)))((nint)ptr2, (uint)deviceKey, (uint)groupKey, (uint)groupMask, ptr3, (uint)timeoutMs, &num3, global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002Edata(&obj)) != 0;
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
								throw;
							}
							global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
							for (int i = 0; i < (int)num3; i++)
							{
								if (results[i] == null)
								{
									results[i] = new ActionCommandResult();
								}
								GigEActionCommandResult* ptr4 = (GigEActionCommandResult*)((byte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)i) + 16);
								results[i].ActionCommandStatus = *(int*)ptr4;
								results[i].CameraAddress = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E((sbyte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)i));
							}
							for (int j = (int)num3; j < (int)num2; j++)
							{
								if (results[j] == null)
								{
									results[j] = new ActionCommandResult();
								}
								GigEActionCommandResult* ptr5 = (GigEActionCommandResult*)((byte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)j) + 16);
								results[j].ActionCommandStatus = *(int*)ptr5;
								results[j].CameraAddress = "";
							}
							bool flag2 = flag;
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bdtor_007D), &obj);
							throw;
						}
						global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bdtor_007D(&obj);
						goto IL_01f4;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				try
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException("The GigE transport layer must be available for issuing action commands."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				IL_01f4:
				global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D(&autoTlReleaser);
				b = 1;
				((IDisposable)autoInitRelease).Dispose();
				return flag;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex.Source = "ActionCommandTrigger";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex2.Source = "ActionCommandTrigger";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex3.Source = "ActionCommandTrigger";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex4.Source = "ActionCommandTrigger";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex5.Source = "ActionCommandTrigger";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex6.Source = "ActionCommandTrigger";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex7.Source = "ActionCommandTrigger";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr13;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex8.Source = "ActionCommandTrigger";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr14;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex9.Source = "ActionCommandTrigger";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr15) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr15;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "ActionCommandTrigger";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "ActionCommandTrigger";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)autoInitRelease).Dispose();
			}
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return false;
	}

	public unsafe static void Issue(int deviceKey, int groupKey, int groupMask, string broadcastAddress)
	{
		AutoInitRelease autoInitRelease = null;
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr13);
			try
			{
				if (broadcastAddress == null || string.Empty != null)
				{
					broadcastAddress = "255.255.255.255";
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0L_0040JJBMFOCK_0040BaslerGigE_0040));
				ITransportLayer* ptr;
				try
				{
					ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance(), &gcstring2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AutoTlReleaser autoTlReleaser);
				*(int*)(&autoTlReleaser) = (int)ptr;
				try
				{
					IGigETransportLayer* ptr2 = (IGigETransportLayer*)global::_003CModule_003E.__RTDynamicCast(ptr, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUITransportLayer_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIGigETransportLayer_0040Pylon_0040_0040_00408), 0);
					if (ptr2 != null)
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* ptr3 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &broadcastAddress);
						try
						{
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, uint, uint, gcstring*, uint, uint*, GigEActionCommandResult*, byte>)(int)(*(uint*)(*(int*)ptr2 + 84)))((nint)ptr2, (uint)deviceKey, (uint)groupKey, (uint)groupMask, ptr3, 0u, null, null);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						goto IL_00e3;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				try
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException("The GigE transport layer must be available for issuing action commands."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				IL_00e3:
				global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D(&autoTlReleaser);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr4;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex.Source = "ActionCommandTrigger";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr5;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex2.Source = "ActionCommandTrigger";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex3.Source = "ActionCommandTrigger";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex4.Source = "ActionCommandTrigger";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex5.Source = "ActionCommandTrigger";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex6.Source = "ActionCommandTrigger";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex7.Source = "ActionCommandTrigger";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex8.Source = "ActionCommandTrigger";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex9.Source = "ActionCommandTrigger";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr13;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "ActionCommandTrigger";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "ActionCommandTrigger";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
	}

	public unsafe void Issue()
	{
		if (!m_isConfigured)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("The action can't be performed if no cameras have been configured."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
		}
		Issue(m_deviceKey, m_groupKey, m_groupMask, m_broadcastAddress);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static bool Schedule(int deviceKey, int groupKey, int groupMask, long actiontimeNs, string broadcastAddress, int timeoutMs, ActionCommandResult[] results)
	{
		//Discarded unreachable code: IL_0883
		AutoInitRelease autoInitRelease = null;
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		byte b = 0;
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr14);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr15);
			try
			{
				if (results == null)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("results"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				if (results.Length == 0)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Array must not be empty.", "results"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				if (broadcastAddress == null || string.Empty != null)
				{
					broadcastAddress = "255.255.255.255";
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0L_0040JJBMFOCK_0040BaslerGigE_0040));
				ITransportLayer* ptr;
				try
				{
					ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance(), &gcstring2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AutoTlReleaser autoTlReleaser);
				*(int*)(&autoTlReleaser) = (int)ptr;
				bool flag;
				try
				{
					IGigETransportLayer* ptr2 = (IGigETransportLayer*)global::_003CModule_003E.__RTDynamicCast(ptr, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUITransportLayer_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIGigETransportLayer_0040Pylon_0040_0040_00408), 0);
					if (ptr2 != null)
					{
						uint num2 = (uint)results.Length;
						uint num3 = num2;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E obj);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out allocator_003CPylon_003A_003AGigEActionCommandResult_003E allocator_003CPylon_003A_003AGigEActionCommandResult_003E2);
						global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bctor_007D(&obj, num3, global::_003CModule_003E.std_002Eallocator_003CPylon_003A_003AGigEActionCommandResult_003E_002E_007Bctor_007D(&allocator_003CPylon_003A_003AGigEActionCommandResult_003E2));
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
							gcstring* ptr3 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &broadcastAddress);
							try
							{
								flag = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, uint, uint, ulong, gcstring*, uint, uint*, GigEActionCommandResult*, byte>)(int)(*(uint*)(*(int*)ptr2 + 88)))((nint)ptr2, (uint)deviceKey, (uint)groupKey, (uint)groupMask, (ulong)actiontimeNs, ptr3, (uint)timeoutMs, &num3, global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002Edata(&obj)) != 0;
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
								throw;
							}
							global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
							for (int i = 0; i < (int)num3; i++)
							{
								if (results[i] == null)
								{
									results[i] = new ActionCommandResult();
								}
								GigEActionCommandResult* ptr4 = (GigEActionCommandResult*)((byte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)i) + 16);
								results[i].ActionCommandStatus = *(int*)ptr4;
								results[i].CameraAddress = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E((sbyte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)i));
							}
							for (int j = (int)num3; j < (int)num2; j++)
							{
								if (results[j] == null)
								{
									results[j] = new ActionCommandResult();
								}
								GigEActionCommandResult* ptr5 = (GigEActionCommandResult*)((byte*)global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(&obj, (uint)j) + 16);
								results[j].ActionCommandStatus = *(int*)ptr5;
								results[j].CameraAddress = "";
							}
							bool flag2 = flag;
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bdtor_007D), &obj);
							throw;
						}
						global::_003CModule_003E.std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bdtor_007D(&obj);
						goto IL_01f6;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				try
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException("The GigE transport layer must be available for issuing action commands."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				IL_01f6:
				global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D(&autoTlReleaser);
				b = 1;
				((IDisposable)autoInitRelease).Dispose();
				return flag;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex.Source = "ActionCommandTrigger";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex2.Source = "ActionCommandTrigger";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex3.Source = "ActionCommandTrigger";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex4.Source = "ActionCommandTrigger";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex5.Source = "ActionCommandTrigger";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex6.Source = "ActionCommandTrigger";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex7.Source = "ActionCommandTrigger";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr13;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex8.Source = "ActionCommandTrigger";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr14;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex9.Source = "ActionCommandTrigger";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr15) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr15;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "ActionCommandTrigger";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "ActionCommandTrigger";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)autoInitRelease).Dispose();
			}
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return false;
	}

	public unsafe static void Schedule(int deviceKey, int groupKey, int groupMask, long actiontimeNs, string broadcastAddress)
	{
		AutoInitRelease autoInitRelease = null;
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr13);
			try
			{
				if (broadcastAddress == null || string.Empty != null)
				{
					broadcastAddress = "255.255.255.255";
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0L_0040JJBMFOCK_0040BaslerGigE_0040));
				ITransportLayer* ptr;
				try
				{
					ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance(), &gcstring2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AutoTlReleaser autoTlReleaser);
				*(int*)(&autoTlReleaser) = (int)ptr;
				try
				{
					IGigETransportLayer* ptr2 = (IGigETransportLayer*)global::_003CModule_003E.__RTDynamicCast(ptr, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUITransportLayer_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIGigETransportLayer_0040Pylon_0040_0040_00408), 0);
					if (ptr2 != null)
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* ptr3 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &broadcastAddress);
						try
						{
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, uint, uint, ulong, gcstring*, uint, uint*, GigEActionCommandResult*, byte>)(int)(*(uint*)(*(int*)ptr2 + 88)))((nint)ptr2, (uint)deviceKey, (uint)groupKey, (uint)groupMask, (ulong)actiontimeNs, ptr3, 0u, null, null);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						goto IL_00e5;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				try
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException("The GigE transport layer must be available for issuing action commands."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<AutoTlReleaser*, void>)(&global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D), &autoTlReleaser);
					throw;
				}
				IL_00e5:
				global::_003CModule_003E._003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D(&autoTlReleaser);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr4;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex.Source = "ActionCommandTrigger";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr5;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex2.Source = "ActionCommandTrigger";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex3.Source = "ActionCommandTrigger";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex4.Source = "ActionCommandTrigger";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex5.Source = "ActionCommandTrigger";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex6.Source = "ActionCommandTrigger";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex7.Source = "ActionCommandTrigger";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex8.Source = "ActionCommandTrigger";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex9.Source = "ActionCommandTrigger";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr13;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "ActionCommandTrigger";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "ActionCommandTrigger";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
	}

	public unsafe void Schedule(long actiontimeNs)
	{
		if (!m_isConfigured)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("The action can't be performed if no cameras have been configured."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
		}
		Schedule(m_deviceKey, m_groupKey, m_groupMask, actiontimeNs, m_broadcastAddress);
	}

	public void Configure(ICamera[] cameras, int deviceKey, int actionId, int groupKey, int groupMask)
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			ResetSettings();
			CheckPreconditonCamerasOpen(cameras);
			CheckPreconditonForActionConfigure(cameras, actionId);
			CalculateBroadcastAddress(cameras);
			int num = 0;
			if (0 < (nint)cameras.LongLength)
			{
				long value = actionId;
				long value2 = deviceKey;
				long value3 = groupMask;
				long value4 = groupKey;
				do
				{
					ICamera camera = cameras[num];
					IntegerName name = (IntegerName)"ActionSelector";
					camera.Parameters[name].SetValue(value);
					IntegerName name2 = (IntegerName)"ActionDeviceKey";
					camera.Parameters[name2].SetValue(value2);
					IntegerName name3 = (IntegerName)"ActionGroupMask";
					camera.Parameters[name3].SetValue(value3);
					IntegerName name4 = (IntegerName)"ActionGroupKey";
					camera.Parameters[name4].SetValue(value4);
					num++;
				}
				while (num < (nint)cameras.LongLength);
			}
			m_actionId = actionId;
			m_deviceKey = deviceKey;
			m_groupKey = groupKey;
			m_groupMask = groupMask;
			m_isConfigured = true;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
	}

	public void Configure(ICamera[] cameras)
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			ResetSettings();
			CheckPreconditonCamerasOpen(cameras);
			CheckPreconditonForActionConfigure(cameras, 0);
			CheckPreconditonForTriggerConfigure(cameras);
			CalculateBroadcastAddress(cameras);
			for (int i = 0; i < (nint)cameras.LongLength; i++)
			{
				ICamera camera = cameras[i];
				IntegerName name = (IntegerName)"ActionSelector";
				IIntegerParameter integerParameter = camera.Parameters[name];
				integerParameter.SetValue(m_actionId = (int)integerParameter.GetMinimum());
				IntegerName name2 = (IntegerName)"ActionDeviceKey";
				camera.Parameters[name2].SetValue(m_deviceKey);
				IntegerName name3 = (IntegerName)"ActionGroupMask";
				camera.Parameters[name3].SetValue(m_groupMask);
				IntegerName name4 = (IntegerName)"ActionGroupKey";
				camera.Parameters[name4].SetValue(m_groupKey);
				EnumName name5 = (EnumName)"TriggerSelector";
				IEnumParameter enumParameter = camera.Parameters[name5];
				EnumName name6 = (EnumName)"TriggerMode";
				IEnumParameter enumParameter2 = camera.Parameters[name6];
				EnumName name7 = (EnumName)"TriggerSource";
				IEnumParameter enumParameter3 = camera.Parameters[name7];
				EnumName name8 = (EnumName)"AcquisitionMode";
				IEnumParameter enumParameter4 = camera.Parameters[name8];
				string text = "FrameStart";
				string value = "Action" + integerParameter.ToString();
				foreach (string item in enumParameter)
				{
					enumParameter.SetValue(item);
					if (text.Equals(item))
					{
						enumParameter2.SetValue("On");
						enumParameter3.SetValue(value);
					}
					else
					{
						enumParameter2.SetValue("Off");
					}
				}
				enumParameter4.SetValue("Continuous");
			}
			m_isConfigured = true;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
	}

	private void ResetSettings()
	{
		Random random = new Random();
		m_isConfigured = false;
		m_deviceKey = random.Next(10000000, 50000000);
		m_groupKey = random.Next(50000001, 90000000);
		m_groupMask = int.MaxValue;
		m_actionId = 1;
		m_broadcastAddress = null;
	}

	internal unsafe void CheckPreconditonCamerasOpen(ICamera[] cameras)
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			if (cameras == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			int num = cameras.Length;
			if (num == 0)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Configuring an empty set of cameras isn't possible.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
			}
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					ICamera camera = cameras[num2];
					if (camera != null)
					{
						if (camera.IsOpen)
						{
							num2++;
							continue;
						}
						string arg = camera.CameraInfo[CameraInfoKey.FriendlyName].ToString();
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"The camera {arg} must be open.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
					}
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				while (num2 < (nint)cameras.LongLength);
			}
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
	}

	internal unsafe void CheckPreconditonForTriggerConfigure(ICamera[] cameras)
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			int num = 0;
			if (0 < (nint)cameras.LongLength)
			{
				do
				{
					ICamera camera = cameras[num];
					string key = "FriendlyName";
					string arg = camera.CameraInfo[key].ToString();
					int num2 = ((camera.Parameters.Contains("TriggerSelector") && camera.Parameters.Contains("TriggerMode") && camera.Parameters.Contains("TriggerSource") && camera.Parameters.Contains("AcquisitionMode")) ? 1 : 0);
					if ((byte)num2 != 0)
					{
						EnumName name = (EnumName)"TriggerSelector";
						IEnumParameter enumParameter = camera.Parameters[name];
						EnumName name2 = (EnumName)"TriggerMode";
						IEnumParameter enumParameter2 = camera.Parameters[name2];
						EnumName name3 = (EnumName)"TriggerSource";
						IEnumParameter enumParameter3 = camera.Parameters[name3];
						EnumName name4 = (EnumName)"AcquisitionMode";
						IEnumParameter enumParameter4 = camera.Parameters[name4];
						int num3 = ((enumParameter.IsWritable && enumParameter2.IsWritable && enumParameter3.IsWritable) ? 1 : 0);
						if ((byte)num3 != 0)
						{
							if (enumParameter4.IsWritable)
							{
								string value = "FrameStart";
								if (enumParameter.CanSetValue(value))
								{
									num++;
									continue;
								}
								throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"Camera {arg} must be support \"FrameStart\".", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
							}
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"Acquisition mode must be writable for camera {arg}.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
						}
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"Trigger parameter must be writable for camera {arg}.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
					}
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"The camera {arg} must support the trigger mode.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				while (num < (nint)cameras.LongLength);
			}
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
	}

	internal unsafe void CheckPreconditonForActionConfigure(ICamera[] cameras, int actionId)
	{
		AutoInitRelease autoInitRelease = null;
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			int num = 0;
			if (0 < (nint)cameras.LongLength)
			{
				do
				{
					ICamera camera = cameras[num];
					string key = "FriendlyName";
					string text = camera.CameraInfo[key].ToString();
					int num2 = ((camera.Parameters.Contains("ActionSelector") && camera.Parameters.Contains("ActionDeviceKey") && camera.Parameters.Contains("ActionGroupKey") && camera.Parameters.Contains("ActionGroupMask")) ? 1 : 0);
					if ((byte)num2 != 0)
					{
						IntegerName name = (IntegerName)"ActionSelector";
						IIntegerParameter integerParameter = camera.Parameters[name];
						IntegerName name2 = (IntegerName)"ActionDeviceKey";
						IIntegerParameter integerParameter2 = camera.Parameters[name2];
						IntegerName name3 = (IntegerName)"ActionGroupMask";
						IIntegerParameter integerParameter3 = camera.Parameters[name3];
						IntegerName name4 = (IntegerName)"ActionGroupKey";
						IIntegerParameter integerParameter4 = camera.Parameters[name4];
						if (integerParameter.GetMaximum() < actionId)
						{
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException($"The action command configuration with id {actionId} for camera {text} doesn't exist.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
						}
						int num3 = ((integerParameter.IsWritable && integerParameter2.IsWritable && integerParameter3.IsWritable && integerParameter4.IsWritable) ? 1 : 0);
						if ((byte)num3 != 0)
						{
							num++;
							continue;
						}
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException($"Action command features must be writable for camera {text}."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
					}
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException($"The camera {text} must support action commands.", "cameras"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040));
				}
				while (num < (nint)cameras.LongLength);
			}
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
	}

	internal void CalculateBroadcastAddress(ICamera[] cameras)
	{
		uint num = 0u;
		int num2 = 0;
		if (0 < (nint)cameras.LongLength)
		{
			do
			{
				ICamera camera = cameras[num2];
				string key = "IpAddress";
				uint num3 = (uint)BitConverter.ToInt32(IPAddress.Parse(camera.CameraInfo[key].ToString()).GetAddressBytes(), 0);
				string key2 = "SubnetMask";
				uint num4 = (uint)(~BitConverter.ToInt32(IPAddress.Parse(camera.CameraInfo[key2].ToString()).GetAddressBytes(), 0)) | num3;
				if (num == 0)
				{
					num = num4;
				}
				else if (num != num4)
				{
					num = uint.MaxValue;
					break;
				}
				num2++;
			}
			while (num2 < (nint)cameras.LongLength);
		}
		IPAddress iPAddress = new IPAddress(BitConverter.GetBytes(num));
		m_broadcastAddress = iPAddress.ToString();
	}
}

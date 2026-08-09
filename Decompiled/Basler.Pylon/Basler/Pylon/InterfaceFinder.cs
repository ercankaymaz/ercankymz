using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;
using bclog;
using std;

namespace Basler.Pylon;

public static class InterfaceFinder
{
	public unsafe static List<IInterfaceInfo> Enumerate(string deviceType)
	{
		//Discarded unreachable code: IL_0756
		AutoInitRelease autoInitRelease = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (deviceType == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("deviceType"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CA_0040ENPBIIMI_0040_003F_0024AAI_003F_0024AAn_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAf_003F_0024AAa_003F_0024AAc_003F_0024AAe_003F_0024AAF_003F_0024AAi_003F_0024AAn_003F_0024AAd_003F_0024AAe_003F_0024AAr_0040));
		}
		List<IInterfaceInfo> list = new List<IInterfaceInfo>();
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr14);
			try
			{
				CTlFactory* ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance();
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &deviceType);
				ITransportLayer* ptr3;
				try
				{
					ptr3 = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(ptr, ptr2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				if (null != ptr3)
				{
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out InterfaceInfoList interfaceInfoList);
						global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bctor_007D(&interfaceInfoList);
						try
						{
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, InterfaceInfoList*, byte, int>)(int)(*(uint*)(*(int*)ptr3 + 48)))((nint)ptr3, &interfaceInfoList, 0);
							InterfaceInfoList* ptr4 = &interfaceInfoList;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
							int num2 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 40)))((nint)(&interfaceInfoList), &iterator);
							System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2);
							// IL cpblk instruction
							System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator2, num2, 4);
							System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3);
							int num3 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 52)))((nint)(&interfaceInfoList), &iterator3);
							System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4);
							// IL cpblk instruction
							System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator4, num3, 4);
							while (global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator2), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator4)))
							{
								CInterfaceInfoImpl item = new CInterfaceInfoImpl(global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator2));
								list.Add(item);
								global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator2);
							}
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<InterfaceInfoList*, void>)(&global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bdtor_007D), &interfaceInfoList);
							throw;
						}
						global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bdtor_007D(&interfaceInfoList);
					}
					finally
					{
						global::_003CModule_003E.Pylon_002ECTlFactory_002EReleaseTl(ptr, ptr3);
					}
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr5;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						Exception ex;
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						ex.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						Exception ex2;
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex2.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex3;
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex3.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex4;
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex4.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex5;
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex5.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex6;
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex6.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex7;
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex7.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex8;
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex8.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr13;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex9;
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex9.Source = "InterfaceFinder";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr14;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "InterfaceFinder";
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
						Exception ex12 = new Exception("Unknown exception");
						ex12.Source = "InterfaceFinder";
						throw ex12;
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
			((IDisposable)autoInitRelease).Dispose();
			throw;
		}
		((IDisposable)autoInitRelease).Dispose();
		return list;
	}

	public unsafe static List<IInterfaceInfo> Enumerate()
	{
		//Discarded unreachable code: IL_09cb
		AutoInitRelease autoInitRelease = null;
		uint num = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num2 = (int)stackalloc byte[(int)(num << 1)];
		List<IInterfaceInfo> list = new List<IInterfaceInfo>();
		AutoInitRelease autoInitRelease2 = new AutoInitRelease();
		try
		{
			autoInitRelease = autoInitRelease2;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out int num3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr14);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr15);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr16);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr17);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr18);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr19);
			try
			{
				num3 = (int)num + num2;
				CTlFactory* ptr = global::_003CModule_003E.Pylon_002ECTlFactory_002EGetInstance();
				System.Runtime.CompilerServices.Unsafe.SkipInit(out TlInfoList tlInfoList);
				global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bctor_007D(&tlInfoList);
				try
				{
					global::_003CModule_003E.Pylon_002ECTlFactory_002EEnumerateTls(ptr, &tlInfoList);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out InterfaceInfoList interfaceInfoList);
					global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bctor_007D(&interfaceInfoList);
					try
					{
						TlInfoList* ptr2 = &tlInfoList;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACTlInfo_003E.iterator iterator);
						int num4 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACTlInfo_003E.iterator*, TList_003CPylon_003A_003ACTlInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&tlInfoList) + 40)))((nint)(&tlInfoList), &iterator);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACTlInfo_003E.iterator iterator2);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator2, num4, 4);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACTlInfo_003E.iterator iterator3);
						int num5 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACTlInfo_003E.iterator*, TList_003CPylon_003A_003ACTlInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&tlInfoList) + 52)))((nint)(&tlInfoList), &iterator3);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACTlInfo_003E.iterator iterator4);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator4, num5, 4);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr7);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr8);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out uint exceptionCode);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num6);
						while (global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACTlInfo_003E.const_iterator*)(&iterator2), (TList_003CPylon_003A_003ACTlInfo_003E.const_iterator*)(&iterator4)))
						{
							CTlInfo* ptr3 = global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Eiterator_002E_002A(&iterator2);
							ITransportLayer* ptr4 = global::_003CModule_003E.Pylon_002ECTlFactory_002ECreateTl(ptr, ptr3);
							if (null != ptr4)
							{
								try
								{
									((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, InterfaceInfoList*, byte, int>)(int)(*(uint*)(*(int*)ptr4 + 48)))((nint)ptr4, &interfaceInfoList, 1);
								}
								catch (Exception ex)
								{
									string source = ex.Source;
									string message = ex.Message;
									gcstring* ptr5 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &source);
									try
									{
										gcstring* ptr6 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
										try
										{
											global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInterfaceCatID(), (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0HA_0040POIDNMJJ_0040System_003F4Exception_003F5caught_003F5while_003F5e_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr6 + 44)))((nint)ptr6), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr5 + 44)))((nint)ptr5)));
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
								}
								catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
								{
									num6 = 0u;
									global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
									try
									{
										try
										{
											uint num7 = global::_003CModule_003E.Basler_002EPylon_002EGetInterfaceCatID();
											GenericException* intPtr = ptr7;
											global::_003CModule_003E.bclog_002ELogTrace(num7, (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0GC_0040EKODEHPE_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
											goto end_IL_0171;
										}
										catch when (((Func<bool>)delegate
										{
											// Could not convert BlockContainer to single expression
											num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
											return (byte)num6 != 0;
										}).Invoke())
										{
										}
										if (num6 != 0)
										{
											throw;
										}
										end_IL_0171:;
									}
									finally
									{
										global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num6);
									}
								}
								catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr8) != 0)
								{
									num6 = 0u;
									global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
									try
									{
										try
										{
											uint num8 = global::_003CModule_003E.Basler_002EPylon_002EGetInterfaceCatID();
											exception* intPtr2 = ptr8;
											global::_003CModule_003E.bclog_002ELogTrace(num8, (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FK_0040FHHPGHB_0040Exception_003F5caught_003F5while_003F5enumerat_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
											goto end_IL_01e3;
										}
										catch when (((Func<bool>)delegate
										{
											// Could not convert BlockContainer to single expression
											num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
											return (byte)num6 != 0;
										}).Invoke())
										{
										}
										if (num6 != 0)
										{
											throw;
										}
										end_IL_01e3:;
									}
									finally
									{
										global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num6);
									}
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									exceptionCode = (uint)Marshal.GetExceptionCode();
									return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
								}).Invoke())
								{
									num6 = 0u;
									global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
									try
									{
										try
										{
											global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInterfaceCatID(), (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FH_0040NOEPHMEN_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
											goto end_IL_0252;
										}
										catch when (((Func<bool>)delegate
										{
											// Could not convert BlockContainer to single expression
											num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
											return (byte)num6 != 0;
										}).Invoke())
										{
										}
										if (num6 != 0)
										{
											throw;
										}
										end_IL_0252:;
									}
									finally
									{
										global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num6);
									}
								}
								finally
								{
									global::_003CModule_003E.Pylon_002ECTlFactory_002EReleaseTl(ptr, ptr4);
								}
							}
							global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Eiterator_002E_002B_002B(&iterator2);
						}
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator5);
						TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator last = *((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 52)))((nint)(&interfaceInfoList), &iterator5);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator6);
						TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator first = *((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 40)))((nint)(&interfaceInfoList), &iterator6);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out less_003Cvoid_003E pred);
						global::_003CModule_003E.std_002Esort_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(first, last, pred);
						InterfaceInfoList* ptr9 = &interfaceInfoList;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator7);
						int num9 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 40)))((nint)(&interfaceInfoList), &iterator7);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator8);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator8, num9, 4);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator9);
						int num10 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*>)(int)(*(uint*)(*(int*)(&interfaceInfoList) + 52)))((nint)(&interfaceInfoList), &iterator9);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator10);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref iterator10, num10, 4);
						while (global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator8), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator10)))
						{
							CInterfaceInfoImpl item = new CInterfaceInfoImpl(global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator8));
							list.Add(item);
							global::_003CModule_003E.Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator8);
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<InterfaceInfoList*, void>)(&global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bdtor_007D), &interfaceInfoList);
						throw;
					}
					global::_003CModule_003E.Pylon_002EInterfaceInfoList_002E_007Bdtor_007D(&interfaceInfoList);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<TlInfoList*, void>)(&global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bdtor_007D), &tlInfoList);
					throw;
				}
				global::_003CModule_003E.Pylon_002ETlInfoList_002E_007Bdtor_007D(&tlInfoList);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						InvalidArgumentException* intPtr3 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex2;
						try
						{
							ex2 = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex2.Source = "InterfaceFinder";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						OutOfRangeException* intPtr4 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex3;
						try
						{
							ex3 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex3.Source = "InterfaceFinder";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						AccessException* intPtr5 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex4;
						try
						{
							ex4 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex4.Source = "InterfaceFinder";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr6 = ptr13;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex5;
						try
						{
							ex5 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex5.Source = "InterfaceFinder";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						LogicalErrorException* intPtr7 = ptr14;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex6;
						try
						{
							ex6 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex6.Source = "InterfaceFinder";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr15) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						BadAllocException* intPtr8 = ptr15;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex7;
						try
						{
							ex7 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex7.Source = "InterfaceFinder";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr16) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						RuntimeException* intPtr9 = ptr16;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex8;
						try
						{
							ex8 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex8.Source = "InterfaceFinder";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr17) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						DynamicCastException* intPtr10 = ptr17;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 12)))((nint)intPtr10));
						Exception ex9;
						try
						{
							ex9 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex9.Source = "InterfaceFinder";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr18) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						GenericException* intPtr11 = ptr18;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 12)))((nint)intPtr11));
						Exception ex10;
						try
						{
							ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex10.Source = "InterfaceFinder";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr19) != 0)
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						exception* intPtr12 = ptr19;
						Exception ex11 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr12 + 4)))((nint)intPtr12)));
						ex11.Source = "InterfaceFinder";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode2 = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num11 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						Exception ex13 = new Exception("Unknown exception");
						ex13.Source = "InterfaceFinder";
						throw ex13;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num11 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num11 != 0;
					}).Invoke())
					{
					}
					if (num11 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num11);
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
		return list;
	}
}

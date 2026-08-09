using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;
using bclog;
using std;

namespace Basler.Pylon;

internal class InfoImpl : IInfo
{
	protected unsafe CInfoBase* m_pInfo_nat;

	public unsafe virtual string this[string key]
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			if (key == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("key"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
			}
			if (m_pInfo_nat != null)
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr3);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr4);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr5);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr6);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr7);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr8);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr9);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr10);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr11);
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
					string result;
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &key);
						bool flag;
						try
						{
							CInfoBase* pInfo_nat = m_pInfo_nat;
							flag = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, gcstring*, byte>)(int)(*(uint*)(*(int*)pInfo_nat + 8)))((nint)pInfo_nat, ptr, &gcstring2) != 0;
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						if (flag)
						{
							result = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(&gcstring2);
							goto IL_0095;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					goto end_IL_0031;
					IL_0095:
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					return result;
					end_IL_0031:;
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							InvalidArgumentException* intPtr = ptr2;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
							gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
							Exception ex;
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
							ex.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							OutOfRangeException* intPtr2 = ptr3;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
							gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
							Exception ex2;
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
							ex2.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							AccessException* intPtr3 = ptr4;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
							gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
							Exception ex3;
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
							ex3.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr5;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
							gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
							Exception ex4;
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
							ex4.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							LogicalErrorException* intPtr5 = ptr6;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
							gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
							Exception ex5;
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
							ex5.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							BadAllocException* intPtr6 = ptr7;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
							gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
							Exception ex6;
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
							ex6.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							RuntimeException* intPtr7 = ptr8;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
							gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
							Exception ex7;
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
							ex7.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							DynamicCastException* intPtr8 = ptr9;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
							gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
							Exception ex8;
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
							ex8.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							GenericException* intPtr9 = ptr10;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
							gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
							Exception ex9;
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
							ex9.Source = "InfoBase";
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
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr11) != 0)
				{
					uint num2 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							exception* intPtr10 = ptr11;
							Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
							ex10.Source = "InfoBase";
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
							Exception ex12 = new Exception("Unknown exception");
							ex12.Source = "InfoBase";
							throw ex12;
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
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException($"The key {key} is not available in info properties."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
		}
	}

	public unsafe InfoImpl(CInfoBase* pInfo)
	{
		m_pInfo_nat = pInfo;
		base._002Ector();
		if (null == m_pInfo_nat)
		{
			global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)512, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0BN_0040LBJBJLEA_0040Native_003F5info_003F5is_003F5not_003F5provided_003F4_0040), __arglist());
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("pInfo"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
		}
	}

	private unsafe void _0021InfoImpl()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (m_pInfo_nat == null)
		{
			return;
		}
		try
		{
			CDeviceInfo* ptr = (CDeviceInfo*)global::_003CModule_003E.__RTDynamicCast(m_pInfo_nat, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCDeviceInfo_0040Pylon_0040_0040_00408), 0);
			if (ptr != null)
			{
				m_pInfo_nat = null;
				CDeviceInfo* ptr2 = ptr;
				CDeviceInfo* ptr3 = ptr;
				void* ptr4 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(*(int*)ptr + 24)))((nint)ptr, 1u);
			}
			CInterfaceInfo* ptr5 = (CInterfaceInfo*)global::_003CModule_003E.__RTDynamicCast(m_pInfo_nat, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInterfaceInfo_0040Pylon_0040_0040_00408), 0);
			if (ptr5 != null)
			{
				m_pInfo_nat = null;
				CInterfaceInfo* ptr6 = ptr5;
				CInterfaceInfo* ptr7 = ptr5;
				void* ptr8 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(*(int*)ptr5 + 24)))((nint)ptr5, 1u);
			}
			CTlInfo* ptr9 = (CTlInfo*)global::_003CModule_003E.__RTDynamicCast(m_pInfo_nat, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCTlInfo_0040Pylon_0040_0040_00408), 0);
			if (ptr9 != null)
			{
				m_pInfo_nat = null;
				CTlInfo* ptr10 = ptr9;
				CTlInfo* ptr11 = ptr9;
				void* ptr12 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(*(int*)ptr9 + 24)))((nint)ptr9, 1u);
			}
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
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)512, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DP_0040DCKNGMKK_0040Unknown_003F5exception_003F5when_003F5destroyi_0040), __arglist());
					return;
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

	public unsafe virtual IEnumerator<KeyValuePair<string, string>> GetEnumerator()
	{
		return new InfoBaseEnumerator(this, m_pInfo_nat);
	}

	public unsafe virtual IEnumerator GetEnumerator2()
	{
		return new InfoBaseEnumerator(this, m_pInfo_nat);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator2
		return this.GetEnumerator2();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool ContainsKey(string key)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (key == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("key"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
		}
		if (m_pInfo_nat != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr11);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &key);
				bool flag;
				try
				{
					CInfoBase* pInfo_nat = m_pInfo_nat;
					flag = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte>)(int)(*(uint*)(*(int*)pInfo_nat + 4)))((nint)pInfo_nat, ptr) != 0;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				if (flag)
				{
					return true;
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr2;
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
						ex.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr3;
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
						ex2.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr4;
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
						ex3.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr5;
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
						ex4.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr6;
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
						ex5.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr7;
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
						ex6.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr8;
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
						ex7.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr9;
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
						ex8.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr10;
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
						ex9.Source = "InfoBase";
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr11;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "InfoBase";
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
						Exception ex12 = new Exception("Unknown exception");
						ex12.Source = "InfoBase";
						throw ex12;
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
		return false;
	}

	public virtual string GetValueOrDefault(string key, string defaultValue)
	{
		if (ContainsKey(key))
		{
			return this[key];
		}
		return defaultValue;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (!A_0)
		{
			try
			{
				_0021InfoImpl();
			}
			finally
			{
				base.Finalize();
			}
		}
	}

	~InfoImpl()
	{
		Dispose(A_0: false);
	}
}

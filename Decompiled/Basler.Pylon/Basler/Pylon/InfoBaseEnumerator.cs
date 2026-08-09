using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;
using bclog;
using std;

namespace Basler.Pylon;

internal class InfoBaseEnumerator : IEnumerator<KeyValuePair<string, string>>
{
	public InfoImpl m_infoImplRef;

	public unsafe CInfoBase* m_pInfoBase_nat;

	public unsafe gcstring_vector* m_pKeyList_nat;

	public int m_currentIndex;

	public int m_maxIndex;

	public virtual object Current2 => Current;

	public unsafe virtual KeyValuePair<string, string> Current
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			if (m_pKeyList_nat != null && m_pInfoBase_nat != null)
			{
				int currentIndex = m_currentIndex;
				if (currentIndex > -1 && currentIndex <= m_maxIndex)
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
						gcstring_vector* pKeyList_nat = m_pKeyList_nat;
						gcstring* ptr = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, gcstring*>)(int)(*(uint*)(*(int*)pKeyList_nat + 28)))((nint)pKeyList_nat, (uint)m_currentIndex);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
						KeyValuePair<string, string> result;
						try
						{
							CInfoBase* pInfoBase_nat = m_pInfoBase_nat;
							if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, gcstring*, byte>)(int)(*(uint*)(*(int*)pInfoBase_nat + 8)))((nint)pInfoBase_nat, ptr, &gcstring2) != 0)
							{
								KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(ptr), global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(&gcstring2));
								result = keyValuePair;
								goto IL_00a4;
							}
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0CC_0040PAGJOKLO_0040Key_003F5_003F8_003F_0024CFhs_003F8_003F5not_003F5found_003F5in_003F5collecti_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException($"Key '{(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(ptr))}' not found in collection."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						IL_00a4:
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
						return result;
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
					System.Runtime.CompilerServices.Unsafe.SkipInit(out KeyValuePair<string, string> result2);
					return result2;
				}
				global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DE_0040EMHLLLC_0040Element_003F5is_003F5undefined_003F4_003F5Move_003F5inde_0040), __arglist());
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Element is undefined. Move index to valid position."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
			}
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_003E(new ObjectDisposedException("InfoBaseEnumerator", "Enumerator already disposed."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
		}
	}

	public unsafe InfoBaseEnumerator(InfoImpl InfoImplRef, CInfoBase* pInfoBase_nat)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		m_infoImplRef = InfoImplRef;
		m_pInfoBase_nat = pInfoBase_nat;
		m_pKeyList_nat = null;
		m_currentIndex = -1;
		m_maxIndex = -1;
		base._002Ector();
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
		if (m_pInfoBase_nat != null)
		{
			try
			{
				gcstring_vector* ptr = (gcstring_vector*)global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_vector_002Enew(8u);
				gcstring_vector* ptr2;
				try
				{
					if (ptr != null)
					{
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_vector_002E_007Bctor_007D(ptr);
						*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_Sgcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00406B_0040);
						ptr2 = ptr;
					}
					else
					{
						ptr2 = null;
					}
					gcstring_vector* ptr3 = ptr2;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDelDtor((delegate*<void*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_vector_002Edelete), (void*)ptr);
					throw;
				}
				m_pKeyList_nat = ptr2;
				CInfoBase* pInfoBase_nat2 = m_pInfoBase_nat;
				m_maxIndex = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring_vector*, int>)(int)(*(uint*)(int)(*(uint*)pInfoBase_nat2)))((nint)pInfoBase_nat2, ptr2) - 1;
				return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						Exception ex;
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						Exception ex2;
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex3;
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex4;
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex5;
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex6;
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex7;
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex8;
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
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
					return;
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
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex9;
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
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
					return;
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
						throw new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)))
						{
							Source = "InfoBase"
						};
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
					return;
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
						throw new Exception("Unknown exception")
						{
							Source = "InfoBase"
						};
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
		}
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("pInfoBase_nat"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040));
	}

	private void _007EInfoBaseEnumerator()
	{
		_0021InfoBaseEnumerator();
	}

	private unsafe void _0021InfoBaseEnumerator()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (m_pKeyList_nat == null)
		{
			return;
		}
		try
		{
			gcstring_vector* pKeyList_nat = m_pKeyList_nat;
			m_pKeyList_nat = null;
			m_pInfoBase_nat = null;
			m_infoImplRef = null;
			m_maxIndex = -1;
			m_currentIndex = -1;
			gcstring_vector* ptr = pKeyList_nat;
			gcstring_vector* ptr2 = pKeyList_nat;
			if (pKeyList_nat != null)
			{
				void* ptr3 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)pKeyList_nat)))((nint)pKeyList_nat, 1u);
			}
			else
			{
				void* ptr3 = null;
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
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)512, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DH_0040PBHIFLIC_0040Unknown_003F5exception_003F5when_003F5destroyi_0040), __arglist());
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

	[return: MarshalAs(UnmanagedType.U1)]
	public virtual bool MoveNext()
	{
		int currentIndex = m_currentIndex;
		if (currentIndex >= m_maxIndex)
		{
			return false;
		}
		m_currentIndex = currentIndex + 1;
		return true;
	}

	public virtual void Reset()
	{
		m_currentIndex = -1;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021InfoBaseEnumerator();
			return;
		}
		try
		{
			_0021InfoBaseEnumerator();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}

	~InfoBaseEnumerator()
	{
		Dispose(A_0: false);
	}
}

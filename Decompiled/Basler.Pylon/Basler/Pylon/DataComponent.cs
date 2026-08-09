using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;
using std;

namespace Basler.Pylon;

internal class DataComponent : IDataComponent
{
	private unsafe CPylonDataComponent* m_pComponent;

	private unsafe CGrabResultPtr* m_pPtrGrabResult;

	private object m_pixelDataCache;

	public virtual ImageOrientation Orientation => ImageOrientation.TopDown;

	public unsafe virtual long Timestamp
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (long)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetTimeStamp(pComponent);
		}
	}

	public unsafe virtual IntPtr PixelDataPointer
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				return IntPtr.Zero;
			}
			if (global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EIsValid(pComponent) && IsGrabResultPtrValid())
			{
				int offset = (int)((byte*)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetData(m_pComponent) - (nuint)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBuffer(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult)));
				NativeBufferContext* ptr = (NativeBufferContext*)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBufferContext(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
				if (null != ptr)
				{
					return IntPtr.Add((IntPtr)global::_003CModule_003E.gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002EP_0024AA__ZVIntPtr_0040System_0040_0040((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)ptr + 8)), offset);
				}
			}
			return IntPtr.Zero;
		}
	}

	public unsafe virtual object PixelData
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				return null;
			}
			object pixelDataCache = m_pixelDataCache;
			if (pixelDataCache != null)
			{
				return pixelDataCache;
			}
			if (global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EIsValid(pComponent))
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr3);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr4);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr5);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr6);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr7);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr8);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr9);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr10);
				try
				{
					uint num2 = global::_003CModule_003E.Pylon_002EBitPerPixel(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetPixelType(m_pComponent));
					uint num3 = global::_003CModule_003E.Pylon_002ESamplesPerPixel(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetPixelType(m_pComponent));
					uint num4 = num2 / num3;
					switch (global::_003CModule_003E.Pylon_002EIsPacked(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetPixelType(m_pComponent)) ? 8 : num4)
					{
					case 10u:
					case 12u:
					case 14u:
					case 16u:
						m_pixelDataCache = global::_003CModule_003E.Basler_002EPylon_002EAllocAndCopy_003Cunsigned_0020short_003E(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetData(m_pComponent), global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetDataSize(m_pComponent));
						break;
					case 32u:
						m_pixelDataCache = global::_003CModule_003E.Basler_002EPylon_002EAllocAndCopy_003Cfloat_003E(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetData(m_pComponent), global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetDataSize(m_pComponent));
						break;
					case 64u:
						m_pixelDataCache = global::_003CModule_003E.Basler_002EPylon_002EAllocAndCopy_003Cdouble_003E(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetData(m_pComponent), global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetDataSize(m_pComponent));
						break;
					default:
						m_pixelDataCache = global::_003CModule_003E.Basler_002EPylon_002EAllocAndCopy_003Cunsigned_0020char_003E(global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetData(m_pComponent), global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetDataSize(m_pComponent));
						break;
					}
					return m_pixelDataCache;
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							InvalidArgumentException* intPtr = ptr;
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
							ex.Source = "DataComponent";
							throw ex;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							OutOfRangeException* intPtr2 = ptr2;
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
							ex2.Source = "DataComponent";
							throw ex2;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							AccessException* intPtr3 = ptr3;
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
							ex3.Source = "DataComponent";
							throw ex3;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr4;
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
							ex4.Source = "DataComponent";
							throw ex4;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							LogicalErrorException* intPtr5 = ptr5;
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
							ex5.Source = "DataComponent";
							throw ex5;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							BadAllocException* intPtr6 = ptr6;
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
							ex6.Source = "DataComponent";
							throw ex6;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							RuntimeException* intPtr7 = ptr7;
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
							ex7.Source = "DataComponent";
							throw ex7;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							DynamicCastException* intPtr8 = ptr8;
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
							ex8.Source = "DataComponent";
							throw ex8;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							GenericException* intPtr9 = ptr9;
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
							ex9.Source = "DataComponent";
							throw ex9;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							exception* intPtr10 = ptr10;
							Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
							ex10.Source = "DataComponent";
							throw ex10;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
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
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							Exception ex12 = new Exception("Unknown exception");
							ex12.Source = "DataComponent";
							throw ex12;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num5 != 0;
						}).Invoke())
						{
						}
						if (num5 != 0)
						{
							throw;
						}
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
					}
				}
			}
			return null;
		}
	}

	public unsafe virtual int PaddingX
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			uint num = global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetPaddingX(pComponent);
			if (num > int.MaxValue)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("PaddingX is out of range"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (int)num;
		}
	}

	public unsafe virtual int OffsetY
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetOffsetY(pComponent);
		}
	}

	public unsafe virtual int OffsetX
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetOffsetX(pComponent);
		}
	}

	public unsafe virtual int Height
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetHeight(pComponent);
		}
	}

	public unsafe virtual int Width
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetWidth(pComponent);
		}
	}

	public unsafe virtual PixelType PixelTypeValue
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			int result = -1;
			if (global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EIsValid(pComponent))
			{
				result = (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetPixelType(m_pComponent);
			}
			return (PixelType)result;
		}
	}

	public unsafe virtual ComponentType ComponentTypeValue
	{
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			int result = 0;
			if (global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EIsValid(pComponent))
			{
				result = (int)global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EGetComponentType(m_pComponent);
			}
			return (ComponentType)result;
		}
	}

	public unsafe virtual bool IsValid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			CPylonDataComponent* pComponent = m_pComponent;
			if (pComponent == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Component is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040));
			}
			return global::_003CModule_003E.Pylon_002ECPylonDataComponent_002EIsValid(pComponent);
		}
	}

	private unsafe DataComponent(DataComponent rhs)
	{
		CPylonDataComponent* ptr = (CPylonDataComponent*)global::_003CModule_003E.@new(4u);
		CPylonDataComponent* pComponent;
		try
		{
			pComponent = ((ptr == null) ? null : global::_003CModule_003E.Pylon_002ECPylonDataComponent_002E_007Bctor_007D(ptr, rhs.m_pComponent));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr, 4u);
			throw;
		}
		m_pComponent = pComponent;
		m_pPtrGrabResult = rhs.m_pPtrGrabResult;
		m_pixelDataCache = rhs.m_pixelDataCache;
		base._002Ector();
		global::_003CModule_003E.CPylonLibraryNative_002EInit(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
	}

	public unsafe DataComponent(CPylonDataComponent* ptr, CGrabResultPtr* res)
	{
		CPylonDataComponent* ptr2 = (CPylonDataComponent*)global::_003CModule_003E.@new(4u);
		CPylonDataComponent* pComponent;
		try
		{
			pComponent = ((ptr2 == null) ? null : global::_003CModule_003E.Pylon_002ECPylonDataComponent_002E_007Bctor_007D(ptr2, ptr));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr2, 4u);
			throw;
		}
		m_pComponent = pComponent;
		m_pPtrGrabResult = res;
		base._002Ector();
		global::_003CModule_003E.CPylonLibraryNative_002EInit(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
	}

	private void _007EDataComponent()
	{
		_0021DataComponent();
	}

	private unsafe void _0021DataComponent()
	{
		CPylonDataComponent* pComponent = m_pComponent;
		if (pComponent != null)
		{
			CPylonDataComponent* ptr = pComponent;
			m_pComponent = null;
			if (ptr != null)
			{
				global::_003CModule_003E.Pylon_002ECPylonDataComponent_002E_007Bdtor_007D(ptr);
				global::_003CModule_003E.delete(ptr, 4u);
			}
			global::_003CModule_003E.CPylonLibraryNative_002ERelease(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private unsafe bool IsGrabResultPtrValid()
	{
		CGrabResultPtr* pPtrGrabResult = m_pPtrGrabResult;
		if (pPtrGrabResult != null && global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002E_N(pPtrGrabResult))
		{
			return true;
		}
		return false;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021DataComponent();
			return;
		}
		try
		{
			_0021DataComponent();
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

	~DataComponent()
	{
		Dispose(A_0: false);
	}
}

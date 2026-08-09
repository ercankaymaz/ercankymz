using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using _003CCppImplementationDetails_003E;
using GenICam_3_1_Basler_pylon;
using Pylon;
using std;

namespace Basler.Pylon;

public class AviVideoWriter : IVideoWriter
{
	private unsafe CAviWriter* m_pAviWriter_nat;

	public unsafe long ImageDataBytesWritten
	{
		get
		{
			CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
			return ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint>)(int)(*(uint*)(*(int*)pAviWriter_nat + 36)))((nint)pAviWriter_nat);
		}
	}

	public unsafe virtual bool IsOpen
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
			return ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)pAviWriter_nat + 8)))((nint)pAviWriter_nat) != 0;
		}
	}

	public unsafe AviVideoWriter()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		m_pAviWriter_nat = null;
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
		try
		{
			CAviWriter* ptr = (CAviWriter*)global::_003CModule_003E.@new(8u);
			CAviWriter* ptr2;
			try
			{
				if (ptr != null)
				{
					global::_003CModule_003E.Pylon_002ECAviWriter_002E_007Bctor_007D(ptr);
					*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCAviWriter_0040Pylon_0040_00406B_0040);
					ptr2 = ptr;
				}
				else
				{
					ptr2 = null;
				}
				CAviWriter* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 8u);
				throw;
			}
			m_pAviWriter_nat = ptr2;
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
					ex.Source = "AviVideoWriter";
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
					ex2.Source = "AviVideoWriter";
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
					ex3.Source = "AviVideoWriter";
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
					ex4.Source = "AviVideoWriter";
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
					ex5.Source = "AviVideoWriter";
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
					ex6.Source = "AviVideoWriter";
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
					ex7.Source = "AviVideoWriter";
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
					ex8.Source = "AviVideoWriter";
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
					ex9.Source = "AviVideoWriter";
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
					throw new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)))
					{
						Source = "AviVideoWriter"
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
						Source = "AviVideoWriter"
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
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
	}

	private unsafe void _007EAviVideoWriter()
	{
		CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
		if (pAviWriter_nat != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)pAviWriter_nat)))((nint)pAviWriter_nat, 1u);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool Create(string filename, double playbackFramesPerSecond, PixelType pixelType, int width, int height, ImageOrientation orientation, string fccHandler, int quality, int bytesPerSecond, int autoKeyFrameInsertionRate, ref byte[] compressionParams, [MarshalAs(UnmanagedType.U1)] bool showDialog, IntPtr hParentWindow)
	{
		//Discarded unreachable code: IL_0b3e
		ScopedBufferFixation scopedBufferFixation = null;
		ScopedBufferFixation scopedBufferFixation2 = null;
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out SAviCompressionOptions sAviCompressionOptions);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E obj);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E obj2);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out EPixelType ePixelType);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num4);
			global::_003CModule_003E._003FA0xcad5cde4_002EVerifyAndConvertInputParameter(filename, &gcstring2, playbackFramesPerSecond, pixelType, &ePixelType, width, &num3, height, &num4);
			if (fccHandler.Length > 4)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "fccHandler"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
			}
			if ((uint)quality <= 10000u)
			{
				if (bytesPerSecond < 0)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "bytesPerSecond"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
				}
				if (autoKeyFrameInsertionRate <= 0)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "autoKeyFrameInsertionRate"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
				}
				byte[] array = compressionParams;
				if (array != null && (nint)array.LongLength > 0 && array.Rank > 1)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Array must be one of rank 1.", "compressionParams"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
				}
				*(int*)(&sAviCompressionOptions) = 0;
				System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 4)) = 0;
				System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 5)) = 0;
				// IL initblk instruction
				System.Runtime.CompilerServices.Unsafe.InitBlock(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 12), 0, 44);
				System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 8)) = autoKeyFrameInsertionRate;
				*(int*)(&sAviCompressionOptions) = (int)hParentWindow.ToPointer();
				System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 4)) = showDialog;
				global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_003E(&obj, null);
				try
				{
					global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_003E(&obj2, null);
					try
					{
						byte[] array2 = compressionParams;
						if (array2 != null && array2.LongLength >= 52)
						{
							ScopedBufferFixation scopedBufferFixation3 = new ScopedBufferFixation(compressionParams);
							try
							{
								scopedBufferFixation = scopedBufferFixation3;
								ulong* ptr = (ulong*)scopedBufferFixation.PointerToBuffer.ToPointer();
								if (*ptr != 72340172838076673L)
								{
									throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Invalid value.", "compressionParams"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
								}
								AVICOMPRESSOPTIONS* ptr2 = (AVICOMPRESSOPTIONS*)(ptr + 1);
								byte* ptr3 = (int)compressionParams.LongLength + (byte*)ptr;
								// IL cpblk instruction
								System.Runtime.CompilerServices.Unsafe.CopyBlock(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 12), ptr2, 44);
								byte* ptr4 = (byte*)ptr2 + 44;
								if (((int*)ptr2)[8] != 0)
								{
									uint num5 = ((uint*)ptr2)[9];
									if (num5 != 0 && (nuint)(int)num5 <= (nuint)(ptr3 - (nuint)ptr4))
									{
										byte* ptr5 = (byte*)global::_003CModule_003E.new_005B_005D(num5);
										System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E obj3);
										unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* ptr6 = global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cunsigned_0020char_0020_002A_002Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_002Cvoid_003E(&obj3, ptr5);
										try
										{
											global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_003D(&obj, ptr6);
										}
										catch
										{
											//try-fault
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj3);
											throw;
										}
										global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj3);
										// IL cpblk instruction
										System.Runtime.CompilerServices.Unsafe.CopyBlock(global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002Eget(&obj), ptr4, ((int*)ptr2)[9]);
										ptr4 = ((int*)ptr2)[9] + ptr4;
										System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 44)) = (int)global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002Eget(&obj);
									}
								}
								if (((int*)ptr2)[6] != 0)
								{
									uint num6 = ((uint*)ptr2)[7];
									if (num6 != 0 && (nuint)(int)num6 <= (nuint)(ptr3 - (nuint)ptr4))
									{
										byte* ptr7 = (byte*)global::_003CModule_003E.new_005B_005D(num6);
										System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E obj4);
										unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* ptr8 = global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cunsigned_0020char_0020_002A_002Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_002Cvoid_003E(&obj4, ptr7);
										try
										{
											global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_003D(&obj2, ptr8);
										}
										catch
										{
											//try-fault
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj4);
											throw;
										}
										global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj4);
										// IL cpblk instruction
										System.Runtime.CompilerServices.Unsafe.CopyBlock(global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002Eget(&obj2), ptr4, ((int*)ptr2)[7]);
										System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 36)) = (int)global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002Eget(&obj2);
									}
								}
								System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 32)) |= 8;
							}
							catch
							{
								//try-fault
								((IDisposable)scopedBufferFixation).Dispose();
								throw;
							}
							((IDisposable)scopedBufferFixation).Dispose();
						}
						else
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out _0024ArrayType_0024_0024_0024BY03D _0024ArrayType_0024_0024_0024BY03D2);
							// IL initblk instruction
							System.Runtime.CompilerServices.Unsafe.InitBlock(ref _0024ArrayType_0024_0024_0024BY03D2, 0, 4);
							IntPtr hglobal = Marshal.StringToHGlobalAnsi(fccHandler);
							sbyte* ptr9 = (sbyte*)(&_0024ArrayType_0024_0024_0024BY03D2);
							sbyte* ptr10 = (sbyte*)hglobal.ToPointer();
							do
							{
								sbyte b = *ptr10;
								if (b == 0 || b == 32)
								{
									break;
								}
								*ptr9 = b;
								ptr9++;
								ptr10++;
							}
							while (ptr9 < System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY03D2, 4)));
							Marshal.FreeHGlobal(hglobal);
							System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 16)) = ((((((byte)System.Runtime.CompilerServices.Unsafe.As<_0024ArrayType_0024_0024_0024BY03D, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY03D2, 3)) << 8) | (byte)System.Runtime.CompilerServices.Unsafe.As<_0024ArrayType_0024_0024_0024BY03D, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY03D2, 2))) << 8) | (byte)System.Runtime.CompilerServices.Unsafe.As<_0024ArrayType_0024_0024_0024BY03D, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY03D2, 1))) << 8) | (byte)(*(sbyte*)(&_0024ArrayType_0024_0024_0024BY03D2));
							System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 28)) = bytesPerSecond;
							System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 24)) = quality;
							int num7 = ((bytesPerSecond > 0) ? 2 : 4);
							System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 32)) = num7 | 8;
						}
						System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr11);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr12);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr13);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr14);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr15);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr16);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr17);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr18);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr19);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr20);
						try
						{
							CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
							((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, double, EPixelType, uint, uint, EImageOrientation, SAviCompressionOptions*, void>)(int)(*(uint*)(*(int*)pAviWriter_nat + 4)))((nint)pAviWriter_nat, &gcstring2, playbackFramesPerSecond, ePixelType, num3, num4, (EImageOrientation)orientation, &sAviCompressionOptions);
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									InvalidArgumentException* intPtr = ptr11;
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
									ex.Source = "AviVideoWriter";
									throw ex;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									OutOfRangeException* intPtr2 = ptr12;
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
									ex2.Source = "AviVideoWriter";
									throw ex2;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									AccessException* intPtr3 = ptr13;
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
									ex3.Source = "AviVideoWriter";
									throw ex3;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr14;
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
									ex4.Source = "AviVideoWriter";
									throw ex4;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr15) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									LogicalErrorException* intPtr5 = ptr15;
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
									ex5.Source = "AviVideoWriter";
									throw ex5;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr16) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									BadAllocException* intPtr6 = ptr16;
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
									ex6.Source = "AviVideoWriter";
									throw ex6;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr17) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									RuntimeException* intPtr7 = ptr17;
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
									ex7.Source = "AviVideoWriter";
									throw ex7;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr18) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									DynamicCastException* intPtr8 = ptr18;
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
									ex8.Source = "AviVideoWriter";
									throw ex8;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr19) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									GenericException* intPtr9 = ptr19;
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
									ex9.Source = "AviVideoWriter";
									throw ex9;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr20) != 0)
						{
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									exception* intPtr10 = ptr20;
									Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
									ex10.Source = "AviVideoWriter";
									throw ex10;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
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
							uint num8 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
							try
							{
								try
								{
									Exception ex12 = new Exception("Unknown exception");
									ex12.Source = "AviVideoWriter";
									throw ex12;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num8 != 0;
								}).Invoke())
								{
								}
								if (num8 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num8);
							}
						}
						if (System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 4)) && System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, byte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 5)) == 0)
						{
							goto IL_09a7;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj2);
						throw;
					}
					goto end_IL_010b;
					IL_09a7:
					global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj2);
					goto IL_09be;
					end_IL_010b:;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				goto IL_09df;
			}
			goto end_IL_0019;
			IL_09be:
			global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj);
			goto IL_09d5;
			end_IL_0019:;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		try
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "quality"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		IL_09df:
		try
		{
			try
			{
				try
				{
					byte[] array3 = compressionParams;
					if (array3 != null)
					{
						int num9 = System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 48)) + System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 40)) + 64;
						if ((nint)array3.LongLength != num9)
						{
							Array.Resize(ref compressionParams, num9);
						}
						ScopedBufferFixation scopedBufferFixation4 = new ScopedBufferFixation(compressionParams);
						try
						{
							scopedBufferFixation2 = scopedBufferFixation4;
							ulong* ptr21 = (ulong*)scopedBufferFixation2.PointerToBuffer.ToPointer();
							AVICOMPRESSOPTIONS* ptr22 = (AVICOMPRESSOPTIONS*)(ptr21 + 1);
							*ptr21 = 72340172838076673uL;
							// IL cpblk instruction
							System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr22, ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 12), 44);
							byte* ptr23 = (byte*)ptr22 + 44;
							if (System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 44)) != 0 && System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 48)) != 0)
							{
								// IL cpblk instruction
								System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr23, System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 44)), System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 48)));
								((int*)ptr22)[8] = 16580559;
								ptr23 = System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 48)) + ptr23;
							}
							if (System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 36)) != 0 && System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 40)) != 0)
							{
								// IL cpblk instruction
								System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr23, System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 36)), System.Runtime.CompilerServices.Unsafe.As<SAviCompressionOptions, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref sAviCompressionOptions, 40)));
								((int*)ptr22)[6] = 16580559;
							}
						}
						catch
						{
							//try-fault
							((IDisposable)scopedBufferFixation2).Dispose();
							throw;
						}
						((IDisposable)scopedBufferFixation2).Dispose();
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj2);
					throw;
				}
				global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj2);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D), &obj);
				throw;
			}
			global::_003CModule_003E.std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(&obj);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return true;
		IL_09d5:
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return false;
	}

	public unsafe virtual void Create(string filename, double playbackFramesPerSecond, ICamera camera)
	{
		string text = null;
		uint num = 0u;
		if (camera == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		if (!camera.IsOpen)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Camera must be open.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		IntegerName width = PLCamera.Width;
		long value = camera.Parameters[width].GetValue();
		IntegerName height = PLCamera.Height;
		long value2 = camera.Parameters[height].GetValue();
		if ((ulong)(value + -1L) <= 2147483646uL)
		{
			if ((ulong)(value2 + -1L) <= 2147483646uL)
			{
				EnumName name = PLCamera.PixelFormat;
				text = camera.Parameters[name].GetValue();
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
				try
				{
					PixelType pixelType = (PixelType)global::_003CModule_003E.Pylon_002ECPixelTypeMapper_002EGetPylonPixelTypeByName(&gcstring2);
					Create(filename, playbackFramesPerSecond, pixelType, (int)value, (int)value2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				return;
			}
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid height value.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid width value.", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
	}

	public unsafe virtual void Create(string filename, double playbackFramesPerSecond, PixelType pixelType, int width, int height)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out EPixelType ePixelType);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num4);
			global::_003CModule_003E._003FA0xcad5cde4_002EVerifyAndConvertInputParameter(filename, &gcstring2, playbackFramesPerSecond, pixelType, &ePixelType, width, &num3, height, &num4);
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
				CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, double, EPixelType, uint, uint, EImageOrientation, SAviCompressionOptions*, void>)(int)(*(uint*)(*(int*)pAviWriter_nat + 4)))((nint)pAviWriter_nat, &gcstring2, playbackFramesPerSecond, ePixelType, num3, num4, (EImageOrientation)1, null);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr;
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
						ex.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr2;
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
						ex2.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr3;
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
						ex3.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr4;
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
						ex4.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr5;
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
						ex5.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr6;
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
						ex6.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr7;
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
						ex7.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr8;
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
						ex8.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr9;
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
						ex9.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						exception* intPtr10 = ptr10;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
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
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						Exception ex12 = new Exception("Unknown exception");
						ex12.Source = "AviVideoWriter";
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		try
		{
			return;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
	}

	public unsafe virtual void Close()
	{
		CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
		((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)pAviWriter_nat + 12)))((nint)pAviWriter_nat);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool CanWriteWithoutConversion(PixelType pixelType, int width, int height, int paddingX, ImageOrientation orientation)
	{
		CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
		return ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, EPixelType, uint, uint, uint, EImageOrientation, byte>)(int)(*(uint*)(*(int*)pAviWriter_nat + 28)))((nint)pAviWriter_nat, (EPixelType)pixelType, (uint)width, (uint)height, (uint)paddingX, (EImageOrientation)orientation) != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool CanWriteWithoutConversion(IImage image)
	{
		CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
		return ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, EPixelType, uint, uint, uint, EImageOrientation, byte>)(int)(*(uint*)(*(int*)pAviWriter_nat + 28)))((nint)pAviWriter_nat, (EPixelType)image.PixelTypeValue, (uint)image.Width, (uint)image.Height, (uint)image.PaddingX, (EImageOrientation)image.Orientation) != 0;
	}

	public unsafe virtual void Write<T>(T[] pixelData, PixelType pixelType, int width, int height, int paddingX, ImageOrientation orientation)
	{
		ScopedBufferFixation scopedBufferFixation = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (!global::_003CModule_003E.Pylon_002ECImageFormatConverter_002EIsSupportedInputFormat((EPixelType)pixelType))
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Invalid value passed.", "pixeType"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
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
			ScopedBufferFixation scopedBufferFixation2 = new ScopedBufferFixation(pixelData, "AviVideoWriter", "pixelData");
			try
			{
				scopedBufferFixation = scopedBufferFixation2;
				IntPtr pointerToBuffer = scopedBufferFixation.PointerToBuffer;
				IntPtr intPtr = pointerToBuffer;
				CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void*, uint, EPixelType, uint, uint, uint, EImageOrientation, EKeyFrameSelection, void>)(int)(*(uint*)(*(int*)pAviWriter_nat + 16)))((nint)pAviWriter_nat, (void*)pointerToBuffer, scopedBufferFixation.BufferSize, (EPixelType)pixelType, (uint)width, (uint)height, (uint)paddingX, (EImageOrientation)orientation, (EKeyFrameSelection)2);
			}
			catch
			{
				//try-fault
				((IDisposable)scopedBufferFixation).Dispose();
				throw;
			}
			((IDisposable)scopedBufferFixation).Dispose();
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					InvalidArgumentException* intPtr2 = ptr;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
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
					ex.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					OutOfRangeException* intPtr3 = ptr2;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
					gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
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
					ex2.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					AccessException* intPtr4 = ptr3;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
					gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
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
					ex3.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					GenICam_3_1_Basler_pylon.TimeoutException* intPtr5 = ptr4;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
					gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
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
					ex4.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					LogicalErrorException* intPtr6 = ptr5;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
					gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
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
					ex5.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					BadAllocException* intPtr7 = ptr6;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
					gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
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
					ex6.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					RuntimeException* intPtr8 = ptr7;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
					gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
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
					ex7.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					DynamicCastException* intPtr9 = ptr8;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
					gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
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
					ex8.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					GenericException* intPtr10 = ptr9;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
					gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 12)))((nint)intPtr10));
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
					ex9.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					exception* intPtr11 = ptr10;
					Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 4)))((nint)intPtr11)));
					ex10.Source = "AviVideoWriter";
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
					ex12.Source = "AviVideoWriter";
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

	public unsafe virtual void Write(IImage image)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (image == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("image"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		if (!image.IsValid)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Invalid image.", "image"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		if (!global::_003CModule_003E.Pylon_002ECImageFormatConverter_002EIsSupportedInputFormat((EPixelType)image.PixelTypeValue))
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Invalid pixel type.", "image"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
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
			System.Runtime.CompilerServices.Unsafe.SkipInit(out CImageAdapter cImageAdapter);
			global::_003CModule_003E.Basler_002EPylon_002ECImageAdapter_002E_007Bctor_007D(&cImageAdapter, image, "AviVideoWriter", "image");
			try
			{
				CAviWriter* pAviWriter_nat = m_pAviWriter_nat;
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, global::Pylon.IImage*, EKeyFrameSelection, void>)(int)(*(uint*)(*(int*)pAviWriter_nat + 20)))((nint)pAviWriter_nat, (global::Pylon.IImage*)(&cImageAdapter), (EKeyFrameSelection)2);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CImageAdapter*, void>)(&global::_003CModule_003E.Basler_002EPylon_002ECImageAdapter_002E_007Bdtor_007D), &cImageAdapter);
				throw;
			}
			global::_003CModule_003E.Basler_002EPylon_002ECImageAdapter_002E_007Bdtor_007D(&cImageAdapter);
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
		{
			uint num2 = 0u;
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
					ex.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num2 = 0u;
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
					ex2.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
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
					ex3.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
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
					ex4.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
		{
			uint num2 = 0u;
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
					ex5.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num2 = 0u;
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
					ex6.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
		{
			uint num2 = 0u;
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
					ex7.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
		{
			uint num2 = 0u;
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
					ex8.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
		{
			uint num2 = 0u;
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
					ex9.Source = "AviVideoWriter";
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					exception* intPtr10 = ptr10;
					Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
					ex10.Source = "AviVideoWriter";
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
					ex12.Source = "AviVideoWriter";
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

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007EAviVideoWriter();
		}
		else
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}
}

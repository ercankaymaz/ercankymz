using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class OpticDiamondCutter : Cutter
{
	public unsafe OpticDiamondCutter(double length, double width, double height, RadiusType radiusType, double radius, double includedAngle, ClearanceType clearanceType, double clearanceAngle, double rakeAngle)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr5);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr6);
		try
		{
			ppinterface.OpticDiamondCutter* ptr = (ppinterface.OpticDiamondCutter*)global::_003CModule_003E.@new(8u);
			ppinterface.OpticDiamondCutter* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.ppinterface_002EOpticDiamondCutter_002E_007Bctor_007D(ptr, length, width, height, (ppinterface.RadiusType)radiusType, radius, includedAngle, (ppinterface.ClearanceType)clearanceType, clearanceAngle, rakeAngle));
				ppinterface.OpticDiamondCutter* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 8u);
				throw;
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2);
			shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E* other = global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E_002E_007Bctor_007D_003Cclass_0020ppinterface_003A_003AOpticDiamondCutter_002C0_003E(&shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2, ptr2);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ACutter_003E shared_ptr_003Cppinterface_003A_003ACutter_003E2);
				shared_ptr_003Cppinterface_003A_003ACutter_003E* ptr4 = global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003ACutter_002Cclass_0020ppinterface_003A_003AOpticDiamondCutter_003E(&shared_ptr_003Cppinterface_003A_003ACutter_003E2, other);
				try
				{
					base._002Ector(ptr4);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACutter_003E2);
					throw;
				}
				try
				{
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)));
					}
				}
				catch
				{
					//try-fault
					base.Dispose(A_0: true);
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				base.Dispose(A_0: true);
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr5) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr5;
					throw new PostingCancelledException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 4)))((nint)intPtr)));
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					exception* intPtr2 = ptr6;
					throw new ApplicationException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
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
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					throw new ApplicationException("Unknown Exception occurred.");
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
			}
		}
		GC.KeepAlive(this);
	}

	public unsafe OpticDiamondCutter()
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2);
			shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E* other = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003AOpticDiamondCutter_003E(&shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ACutter_003E shared_ptr_003Cppinterface_003A_003ACutter_003E2);
				shared_ptr_003Cppinterface_003A_003ACutter_003E* ptr = global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003ACutter_002Cclass_0020ppinterface_003A_003AOpticDiamondCutter_003E(&shared_ptr_003Cppinterface_003A_003ACutter_003E2, other);
				try
				{
					base._002Ector(ptr);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACutter_003E2);
					throw;
				}
				try
				{
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)));
					}
				}
				catch
				{
					//try-fault
					base.Dispose(A_0: true);
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				base.Dispose(A_0: true);
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr2;
					throw new PostingCancelledException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 4)))((nint)intPtr)));
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					exception* intPtr2 = ptr3;
					throw new ApplicationException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
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
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					throw new ApplicationException("Unknown Exception occurred.");
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
			}
		}
		GC.KeepAlive(this);
	}

	internal unsafe shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E* P_0)
	{
		uint num = 0u;
		global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003AOpticDiamondCutter_002Cclass_0020ppinterface_003A_003ACutter_003E(P_0, m_native.GetPtr());
		try
		{
			num = 1u;
			GC.KeepAlive(this);
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public abstract class ProgressHandler : IDisposable
{
	private protected readonly SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E m_native;

	internal unsafe ProgressHandler(shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* ptr)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E native = new SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E(ptr);
			try
			{
				m_native = native;
				base._002Ector();
			}
			catch
			{
				//try-fault
				((IDisposable)m_native).Dispose();
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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
					throw new ApplicationException("Unknown Exception occurred.");
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
		GC.KeepAlive(this);
	}

	public unsafe ProgressHandler()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
		try
		{
			NativeProgressHandler* ptr = (NativeProgressHandler*)global::_003CModule_003E.@new(12u);
			NativeProgressHandler* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.ModuleWorks_002EPPInterface_002ENativeProgressHandler_002E_007Bctor_007D(ptr, OnUpdateProgress));
				NativeProgressHandler* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 12u);
				throw;
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E2);
			shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* native_ptr = global::_003CModule_003E.std_002Eshared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E_002E_007Bctor_007D_003Cclass_0020ModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_002C0_003E(&shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E2, ptr2);
			try
			{
				SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E native = new SharedPointer_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E(native_ptr);
				try
				{
					m_native = native;
				}
				catch
				{
					//try-fault
					((IDisposable)m_native).Dispose();
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E_002E_007Bdtor_007D), &shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E2, 4)));
				}
				base._002Ector();
			}
			catch
			{
				//try-fault
				((IDisposable)m_native).Dispose();
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr4;
					throw new PostingCancelledException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 4)))((nint)intPtr)));
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr5) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					exception* intPtr2 = ptr5;
					throw new ApplicationException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
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
					throw new ApplicationException("Unknown Exception occurred.");
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
		GC.KeepAlive(this);
	}

	internal unsafe shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* GetNativePtr(shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* P_0)
	{
		uint num = 0u;
		shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* ptr = m_native.GetPtr();
		*(int*)P_0 = 0;
		shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E* ptr2 = (shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E*)((byte*)P_0 + 4);
		*(int*)ptr2 = 0;
		uint num2 = ((uint*)ptr)[1];
		if (num2 != 0)
		{
			Interlocked.Increment(ref *(int*)(num2 + 4));
		}
		*(int*)P_0 = *(int*)ptr;
		*(int*)ptr2 = ((int*)ptr)[1];
		try
		{
			num = 1u;
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003CModuleWorks_003A_003APPInterface_003A_003ANativeProgressHandler_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	public abstract void UpdateProgress(IDictionary<string, int> progressTree);

	private unsafe void OnUpdateProgress(map_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E* progressTree)
	{
		Dictionary<string, int> dictionary = null;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out map_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E obj);
		map_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E* ptr = &obj;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out allocator_003Cstd_003A_003A_Tree_node_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_002Cvoid_0020_002A_003E_0020_003E obj2);
		global::_003CModule_003E.std_002E_Tree_003Cstd_003A_003A_Tmap_traits_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_002C0_003E_0020_003E_002E_007Bctor_007D_003Cclass_0020std_003A_003Aallocator_003Cstruct_0020std_003A_003A_Tree_node_003Cstruct_0020std_003A_003Apair_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_002Cvoid_0020_002A_003E_0020_003E_0020_003E((_Tree_003Cstd_003A_003A_Tmap_traits_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_002C0_003E_0020_003E*)(&obj), (_Tree_003Cstd_003A_003A_Tmap_traits_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_002C0_003E_0020_003E*)progressTree, &obj2);
		map_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E* pThis = &obj;
		Dictionary<string, int> progressTree2;
		try
		{
			dictionary = null;
			global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert(ref dictionary, &obj);
			progressTree2 = dictionary;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<map_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Emap_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Cint_002Cstd_003A_003Aless_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002Cstd_003A_003Aallocator_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E_002E_007Bdtor_007D), pThis);
			throw;
		}
		global::_003CModule_003E.std_002E_Tree_val_003Cstd_003A_003A_Tree_simple_types_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E_002E_Erase_head_003Cclass_0020std_003A_003Aallocator_003Cstruct_0020std_003A_003A_Tree_node_003Cstruct_0020std_003A_003Apair_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_002Cvoid_0020_002A_003E_0020_003E_0020_003E((_Tree_val_003Cstd_003A_003A_Tree_simple_types_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_0020_003E_0020_003E*)(&obj), (allocator_003Cstd_003A_003A_Tree_node_003Cstd_003A_003Apair_003Cstd_003A_003Abasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020const_0020_002Cint_003E_002Cvoid_0020_002A_003E_0020_003E*)(&obj));
		UpdateProgress(progressTree2);
		GC.KeepAlive(this);
	}

	public void _007EProgressHandler()
	{
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				return;
			}
			finally
			{
				((IDisposable)m_native).Dispose();
			}
		}
		base.Finalize();
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}
}

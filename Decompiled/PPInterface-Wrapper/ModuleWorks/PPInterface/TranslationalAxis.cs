using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class TranslationalAxis : Axis
{
	internal unsafe TranslationalAxis(shared_ptr_003Cppinterface_003A_003AAxis_003E* ptr)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			base._002Ector(ptr);
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

	public unsafe TranslationalAxis(string uid, Vectord orientation, double hardMin, double hardMax)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr9);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr10);
		try
		{
			ppinterface.TranslationalAxis* ptr = (ppinterface.TranslationalAxis*)global::_003CModule_003E.@new(8u);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
			ppinterface.TranslationalAxis* ptr5;
			try
			{
				if (ptr != null)
				{
					shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr = orientation.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E2);
					shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr2 = nativePtr;
					try
					{
						num = 1u;
						ppinterface.Vectord* ptr3 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr);
						basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr4 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, uid);
						try
						{
							num = 3u;
							ptr5 = global::_003CModule_003E.ppinterface_002ETranslationalAxis_002E_007Bctor_007D(ptr, ptr4, ptr3, hardMin, hardMax);
						}
						catch
						{
							//try-fault
							if ((num & 2) != 0)
							{
								num &= 0xFFFFFFFDu;
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
							}
							throw;
						}
					}
					catch
					{
						//try-fault
						if ((num & 1) != 0)
						{
							num &= 0xFFFFFFFEu;
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
						}
						throw;
					}
				}
				else
				{
					ptr5 = null;
				}
				try
				{
					try
					{
						ppinterface.TranslationalAxis* ptr6 = ptr5;
					}
					catch
					{
						//try-fault
						if ((num & 2) != 0)
						{
							num &= 0xFFFFFFFDu;
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
						}
						throw;
					}
				}
				catch
				{
					//try-fault
					if ((num & 1) != 0)
					{
						num &= 0xFFFFFFFEu;
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
					}
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 8u);
				throw;
			}
			try
			{
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E2);
					shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E* ptr7 = global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E_002E_007Bctor_007D_003Cclass_0020ppinterface_003A_003ATranslationalAxis_002C0_003E(&shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E2, ptr5);
					shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E* ptr8 = ptr7;
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAxis_003E shared_ptr_003Cppinterface_003A_003AAxis_003E2);
						*(int*)(&shared_ptr_003Cppinterface_003A_003AAxis_003E2) = 0;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAxis_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAxis_003E2, 4)) = 0;
						*(int*)(&shared_ptr_003Cppinterface_003A_003AAxis_003E2) = *(int*)ptr7;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAxis_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAxis_003E2, 4)) = ((int*)ptr7)[1];
						*(int*)ptr7 = 0;
						((int*)ptr7)[1] = 0;
						try
						{
							base._002Ector(&shared_ptr_003Cppinterface_003A_003AAxis_003E2);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAxis_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAxis_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAxis_003E2);
							throw;
						}
						try
						{
							if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAxis_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAxis_003E2, 4)) != 0)
							{
								global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAxis_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAxis_003E2, 4)));
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
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E2);
						throw;
					}
					try
					{
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E2, 4)));
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
					if ((num & 2) != 0)
					{
						num &= 0xFFFFFFFDu;
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
					}
					throw;
				}
				try
				{
					if ((num & 2) != 0)
					{
						num &= 0xFFFFFFFDu;
						try
						{
							global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(&obj);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
							throw;
						}
					}
					try
					{
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
						throw;
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
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
				}
				throw;
			}
			try
			{
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E2, 4)));
					}
				}
			}
			catch
			{
				//try-fault
				base.Dispose(A_0: true);
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr9) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr9;
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					exception* intPtr2 = ptr10;
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

	internal unsafe shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E* P_0)
	{
		uint num = 0u;
		global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003ATranslationalAxis_002Cclass_0020ppinterface_003A_003AAxis_003E(P_0, m_native.GetPtr());
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}
}

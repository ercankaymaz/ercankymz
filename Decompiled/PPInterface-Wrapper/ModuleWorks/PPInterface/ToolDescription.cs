using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class ToolDescription : IDisposable
{
	private protected readonly SharedPointer_003Cppinterface_003A_003AToolDescription_003E m_native;

	public unsafe virtual AdditionalData AdditionalData
	{
		get
		{
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				AdditionalData additionalData;
				try
				{
					ppinterface.AdditionalData* ptr2 = global::_003CModule_003E.ppinterface_002EToolDescription_002EGetAdditionalData((ppinterface.ToolDescription*)(int)(*(uint*)nativePtr));
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E3);
					shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr2 = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E3);
					try
					{
						shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr3 = nativePtr2;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
						*(int*)(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2) = 0;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) = 0;
						*(int*)(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2) = (int)ptr2;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) = ((int*)nativePtr2)[1];
						*(int*)nativePtr2 = 0;
						((int*)nativePtr2)[1] = 0;
						try
						{
							additionalData = new AdditionalData(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
							throw;
						}
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)));
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E3);
						throw;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E3, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E3, 4)));
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
				}
				AdditionalData additionalData2 = additionalData;
				GC.KeepAlive(this);
				return additionalData;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
			return null;
		}
		set
		{
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr6);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				try
				{
					ppinterface.ToolDescription* ptr2 = (ppinterface.ToolDescription*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
					shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* nativePtr2 = value.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
					shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr3 = nativePtr2;
					try
					{
						ppinterface.AdditionalData* ptr4 = (ppinterface.AdditionalData*)(int)(*(uint*)nativePtr2);
						global::_003CModule_003E.ppinterface_002EToolDescription_002ESetAdditionalData(ptr2, ptr4);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
						throw;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)));
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
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
		}
	}

	public unsafe virtual string ToolAssemblyNumber
	{
		get
		{
			string text = null;
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
				basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis = &obj;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				string text2;
				try
				{
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* right = global::_003CModule_003E.ppinterface_002EToolDescription_002EGetToolAssemblyNumber((ppinterface.ToolDescription*)(int)(*(uint*)nativePtr));
					System.Runtime.CompilerServices.Unsafe.SkipInit(out _One_then_variadic_args_t one_then_variadic_args_t2);
					_One_then_variadic_args_t one_then_variadic_args_t = one_then_variadic_args_t2;
					*(int*)(&obj) = 0;
					try
					{
						System.Runtime.CompilerServices.Unsafe.As<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16)) = 0;
						System.Runtime.CompilerServices.Unsafe.As<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 20)) = 0;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty*, void>)(&global::_003CModule_003E.std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D), pThis);
						throw;
					}
					try
					{
						_Fake_allocator* ptr2 = (_Fake_allocator*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E.std_002E_Fake_alloc);
						global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Construct_lv_contents(&obj, right);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis);
						throw;
					}
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis2 = &obj;
					try
					{
						text = null;
						global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert(ref text, &obj);
						text2 = text;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), pThis2);
						throw;
					}
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(&obj);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis2);
						throw;
					}
					string text3 = text2;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
				}
				string text4 = text2;
				GC.KeepAlive(this);
				return text2;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						ppinterface.PostingCancelledException* intPtr = ptr3;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						exception* intPtr2 = ptr4;
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
			return null;
		}
		set
		{
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				try
				{
					ppinterface.ToolDescription* ptr2 = (ppinterface.ToolDescription*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr3 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, value);
					try
					{
						global::_003CModule_003E.ppinterface_002EToolDescription_002ESetToolAssemblyNumber(ptr2, ptr3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
						throw;
					}
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
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
		}
	}

	public unsafe virtual string ToolName
	{
		get
		{
			string text = null;
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
				basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis = &obj;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				string text2;
				try
				{
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* right = global::_003CModule_003E.ppinterface_002EToolDescription_002EGetToolName((ppinterface.ToolDescription*)(int)(*(uint*)nativePtr));
					System.Runtime.CompilerServices.Unsafe.SkipInit(out _One_then_variadic_args_t one_then_variadic_args_t2);
					_One_then_variadic_args_t one_then_variadic_args_t = one_then_variadic_args_t2;
					*(int*)(&obj) = 0;
					try
					{
						System.Runtime.CompilerServices.Unsafe.As<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16)) = 0;
						System.Runtime.CompilerServices.Unsafe.As<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 20)) = 0;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty*, void>)(&global::_003CModule_003E.std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D), pThis);
						throw;
					}
					try
					{
						_Fake_allocator* ptr2 = (_Fake_allocator*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E.std_002E_Fake_alloc);
						global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Construct_lv_contents(&obj, right);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis);
						throw;
					}
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis2 = &obj;
					try
					{
						text = null;
						global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert(ref text, &obj);
						text2 = text;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), pThis2);
						throw;
					}
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(&obj);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis2);
						throw;
					}
					string text3 = text2;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
				}
				string text4 = text2;
				GC.KeepAlive(this);
				return text2;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						ppinterface.PostingCancelledException* intPtr = ptr3;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						exception* intPtr2 = ptr4;
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
			return null;
		}
		set
		{
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = nativePtr;
				try
				{
					ppinterface.ToolDescription* ptr2 = (ppinterface.ToolDescription*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr3 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, value);
					try
					{
						global::_003CModule_003E.ppinterface_002EToolDescription_002ESetToolName(ptr2, ptr3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
						throw;
					}
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
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
		}
	}

	internal unsafe ToolDescription(shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			SharedPointer_003Cppinterface_003A_003AToolDescription_003E native = new SharedPointer_003Cppinterface_003A_003AToolDescription_003E(ptr);
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

	public unsafe ToolDescription(ToolType toolType, Cutter cutter, Arbor arbor, Holder holder, double toolLength, string toolName, string toolAssemblyNumber, AdditionalData additionalData)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr12);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr13);
		try
		{
			ppinterface.ToolDescription* ptr = (ppinterface.ToolDescription*)global::_003CModule_003E.@new(4u);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AHolder_003E shared_ptr_003Cppinterface_003A_003AHolder_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AArbor_003E shared_ptr_003Cppinterface_003A_003AArbor_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ACutter_003E shared_ptr_003Cppinterface_003A_003ACutter_003E2);
			ppinterface.ToolDescription* ptr10;
			try
			{
				if (ptr != null)
				{
					shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* nativePtr = additionalData.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
					shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr2 = nativePtr;
					try
					{
						num = 1u;
						ppinterface.AdditionalData* ptr3 = (ppinterface.AdditionalData*)(int)(*(uint*)nativePtr);
						basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr4 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, toolAssemblyNumber);
						try
						{
							num = 3u;
							basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr5 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj2, toolName);
							try
							{
								num = 7u;
								shared_ptr_003Cppinterface_003A_003AHolder_003E* nativePtr2 = holder.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AHolder_003E2);
								shared_ptr_003Cppinterface_003A_003AHolder_003E* ptr6 = nativePtr2;
								try
								{
									num = 15u;
									ppinterface.Holder* ptr7 = (ppinterface.Holder*)(int)(*(uint*)nativePtr2);
									shared_ptr_003Cppinterface_003A_003AArbor_003E* nativePtr3 = arbor.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AArbor_003E2);
									shared_ptr_003Cppinterface_003A_003AArbor_003E* ptr8 = nativePtr3;
									try
									{
										num = 31u;
										ppinterface.Arbor* ptr9 = (ppinterface.Arbor*)(int)(*(uint*)nativePtr3);
										shared_ptr_003Cppinterface_003A_003ACutter_003E* nativePtr4 = cutter.GetNativePtr(&shared_ptr_003Cppinterface_003A_003ACutter_003E2);
										try
										{
											num = 63u;
											ptr10 = global::_003CModule_003E.ppinterface_002EToolDescription_002E_007Bctor_007D(ptr, (ppinterface.ToolType)toolType, nativePtr4, ptr9, ptr7, toolLength, ptr5, ptr4, ptr3);
										}
										catch
										{
											//try-fault
											if ((num & 0x20) != 0)
											{
												num &= 0xFFFFFFDFu;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACutter_003E2);
											}
											throw;
										}
									}
									catch
									{
										//try-fault
										if ((num & 0x10) != 0)
										{
											num &= 0xFFFFFFEFu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AArbor_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AArbor_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AArbor_003E2);
										}
										throw;
									}
								}
								catch
								{
									//try-fault
									if ((num & 8) != 0)
									{
										num &= 0xFFFFFFF7u;
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AHolder_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AHolder_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AHolder_003E2);
									}
									throw;
								}
							}
							catch
							{
								//try-fault
								if ((num & 4) != 0)
								{
									num &= 0xFFFFFFFBu;
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj2);
								}
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
					}
					catch
					{
						//try-fault
						if ((num & 1) != 0)
						{
							num &= 0xFFFFFFFEu;
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
						}
						throw;
					}
				}
				else
				{
					ptr10 = null;
				}
				try
				{
					try
					{
						try
						{
							try
							{
								try
								{
									try
									{
										ppinterface.ToolDescription* ptr11 = ptr10;
									}
									catch
									{
										//try-fault
										if ((num & 0x20) != 0)
										{
											num &= 0xFFFFFFDFu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACutter_003E2);
										}
										throw;
									}
								}
								catch
								{
									//try-fault
									if ((num & 0x10) != 0)
									{
										num &= 0xFFFFFFEFu;
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AArbor_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AArbor_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AArbor_003E2);
									}
									throw;
								}
							}
							catch
							{
								//try-fault
								if ((num & 8) != 0)
								{
									num &= 0xFFFFFFF7u;
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AHolder_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AHolder_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AHolder_003E2);
								}
								throw;
							}
						}
						catch
						{
							//try-fault
							if ((num & 4) != 0)
							{
								num &= 0xFFFFFFFBu;
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj2);
							}
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
				}
				catch
				{
					//try-fault
					if ((num & 1) != 0)
					{
						num &= 0xFFFFFFFEu;
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
					}
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 4u);
				throw;
			}
			try
			{
				try
				{
					try
					{
						try
						{
							try
							{
								try
								{
									System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
									shared_ptr_003Cppinterface_003A_003AToolDescription_003E* native_ptr = global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bctor_007D_003Cclass_0020ppinterface_003A_003AToolDescription_002C0_003E(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, ptr10);
									try
									{
										SharedPointer_003Cppinterface_003A_003AToolDescription_003E native = new SharedPointer_003Cppinterface_003A_003AToolDescription_003E(native_ptr);
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
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
										throw;
									}
									try
									{
										if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
										{
											global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
										}
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
									if ((num & 0x20) != 0)
									{
										num &= 0xFFFFFFDFu;
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACutter_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACutter_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACutter_003E2);
									}
									throw;
								}
								try
								{
									if ((num & 0x20) != 0)
									{
										num &= 0xFFFFFFDFu;
										if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)) != 0)
										{
											global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACutter_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACutter_003E2, 4)));
										}
									}
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
								if ((num & 0x10) != 0)
								{
									num &= 0xFFFFFFEFu;
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AArbor_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AArbor_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AArbor_003E2);
								}
								throw;
							}
							try
							{
								if ((num & 0x10) != 0)
								{
									num &= 0xFFFFFFEFu;
									if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AArbor_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AArbor_003E2, 4)) != 0)
									{
										global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AArbor_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AArbor_003E2, 4)));
									}
								}
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
							if ((num & 8) != 0)
							{
								num &= 0xFFFFFFF7u;
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AHolder_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AHolder_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AHolder_003E2);
							}
							throw;
						}
						try
						{
							if ((num & 8) != 0)
							{
								num &= 0xFFFFFFF7u;
								if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AHolder_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AHolder_003E2, 4)) != 0)
								{
									global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AHolder_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AHolder_003E2, 4)));
								}
							}
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
						if ((num & 4) != 0)
						{
							num &= 0xFFFFFFFBu;
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj2);
						}
						throw;
					}
					try
					{
						if ((num & 4) != 0)
						{
							num &= 0xFFFFFFFBu;
							try
							{
								global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(&obj2);
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj2);
								throw;
							}
						}
						try
						{
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj2);
							throw;
						}
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
					((IDisposable)m_native).Dispose();
					throw;
				}
			}
			catch
			{
				//try-fault
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
				}
				throw;
			}
			try
			{
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)));
					}
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr12) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr12;
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr13) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					exception* intPtr2 = ptr13;
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

	public unsafe ToolDescription()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr2);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
			shared_ptr_003Cppinterface_003A_003AToolDescription_003E* native_ptr = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003AToolDescription_003E(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
			try
			{
				SharedPointer_003Cppinterface_003A_003AToolDescription_003E native = new SharedPointer_003Cppinterface_003A_003AToolDescription_003E(native_ptr);
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)));
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr;
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					exception* intPtr2 = ptr2;
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

	internal unsafe shared_ptr_003Cppinterface_003A_003AToolDescription_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AToolDescription_003E* P_0)
	{
		uint num = 0u;
		shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr = m_native.GetPtr();
		*(int*)P_0 = 0;
		shared_ptr_003Cppinterface_003A_003AToolDescription_003E* ptr2 = (shared_ptr_003Cppinterface_003A_003AToolDescription_003E*)((byte*)P_0 + 4);
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AToolDescription_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AToolDescription_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	public void _007EToolDescription()
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

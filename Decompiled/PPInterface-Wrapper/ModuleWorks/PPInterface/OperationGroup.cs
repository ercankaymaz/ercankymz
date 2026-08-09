using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class OperationGroup : OperationNode
{
	public unsafe OperationGroup(string name, string id, AdditionalData addData)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
			shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* nativePtr = addData.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
			shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr = nativePtr;
			try
			{
				ppinterface.AdditionalData* _003C_Args_2_003E = (ppinterface.AdditionalData*)(int)(*(uint*)nativePtr);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
				basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* _003C_Args_1_003E = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, id);
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj2);
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* _003C_Args_0_003E = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj2, name);
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationGroup_003E shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
						shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr2 = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003AOperationGroup_002Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020ppinterface_003A_003AAdditionalData_0020_0026_003E(&shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, _003C_Args_0_003E, _003C_Args_1_003E, _003C_Args_2_003E);
						shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr3 = ptr2;
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
							*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = 0;
							System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = 0;
							*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = *(int*)ptr2;
							System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = ((int*)ptr2)[1];
							*(int*)ptr2 = 0;
							((int*)ptr2)[1] = 0;
							try
							{
								base._002Ector(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationNode_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationNode_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
								throw;
							}
							try
							{
								if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) != 0)
								{
									global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)));
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
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
							throw;
						}
						try
						{
							if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)) != 0)
							{
								global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)));
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
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj2);
						throw;
					}
					try
					{
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
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				try
				{
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
					base.Dispose(A_0: true);
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				base.Dispose(A_0: true);
				throw;
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
		GC.KeepAlive(this);
	}

	public unsafe OperationGroup(string name, string id)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
			basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* _003C_Args_1_003E = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, id);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj2);
				basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* _003C_Args_0_003E = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj2, name);
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationGroup_003E shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
					shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003AOperationGroup_002Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E(&shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, _003C_Args_0_003E, _003C_Args_1_003E);
					shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr2 = ptr;
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
						*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = 0;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = 0;
						*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = *(int*)ptr;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = ((int*)ptr)[1];
						*(int*)ptr = 0;
						((int*)ptr)[1] = 0;
						try
						{
							base._002Ector(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationNode_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationNode_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
							throw;
						}
						try
						{
							if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) != 0)
							{
								global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)));
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
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
						throw;
					}
					try
					{
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)));
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
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj2);
					throw;
				}
				try
				{
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
				throw;
			}
			try
			{
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
				base.Dispose(A_0: true);
				throw;
			}
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
		GC.KeepAlive(this);
	}

	public unsafe OperationGroup()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationGroup_003E shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003AOperationGroup_003E(&shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr2 = ptr;
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
				*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = 0;
				System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = 0;
				*(int*)(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2) = *(int*)ptr;
				System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) = ((int*)ptr)[1];
				*(int*)ptr = 0;
				((int*)ptr)[1] = 0;
				try
				{
					base._002Ector(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationNode_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationNode_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
					throw;
				}
				try
				{
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)));
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				base.Dispose(A_0: true);
				throw;
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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

	public unsafe void AddChild(OperationNode child)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationGroup_003E shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr = nativePtr;
			try
			{
				ppinterface.OperationGroup* ptr2 = (ppinterface.OperationGroup*)(int)(*(uint*)nativePtr);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
				shared_ptr_003Cppinterface_003A_003AOperationNode_003E* nativePtr2 = child.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
				try
				{
					global::_003CModule_003E.ppinterface_002EOperationGroup_002EaddChild(ptr2, nativePtr2);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationNode_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationNode_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationNode_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationNode_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
				throw;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)) != 0)
			{
				global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)));
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
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

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool HasChildren()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationGroup_003E shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
			shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* ptr = nativePtr;
			bool flag;
			try
			{
				flag = global::_003CModule_003E.ppinterface_002EOperationGroup_002EhasChildren((ppinterface.OperationGroup*)(int)(*(uint*)nativePtr));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2);
				throw;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)) != 0)
			{
				global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperationGroup_003E2, 4)));
			}
			bool flag2 = flag;
			GC.KeepAlive(this);
			return flag;
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
		return false;
	}

	internal unsafe shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AOperationGroup_003E* P_0)
	{
		uint num = 0u;
		global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003AOperationGroup_002Cclass_0020ppinterface_003A_003AOperationNode_003E(P_0, m_native.GetPtr());
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperationGroup_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperationGroup_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}
}

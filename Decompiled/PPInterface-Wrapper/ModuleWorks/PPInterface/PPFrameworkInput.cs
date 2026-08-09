using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class PPFrameworkInput : IDisposable
{
	private protected readonly SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E m_native;

	internal unsafe PPFrameworkInput(shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E native = new SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E(ptr);
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

	public unsafe PPFrameworkInput(OperationNode operationRootNode, CAMInformation cam_info, AdditionalData additional_data)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
			shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* nativePtr = additional_data.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
			shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr = nativePtr;
			try
			{
				ppinterface.AdditionalData* _003C_Args_2_003E = (ppinterface.AdditionalData*)(int)(*(uint*)nativePtr);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ACAMInformation_003E shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
				shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* nativePtr2 = cam_info.GetNativePtr(&shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
				shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* ptr2 = nativePtr2;
				try
				{
					ppinterface.CAMInformation* _003C_Args_1_003E = (ppinterface.CAMInformation*)(int)(*(uint*)nativePtr2);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
					shared_ptr_003Cppinterface_003A_003AOperationNode_003E* nativePtr3 = operationRootNode.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
						shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* native_ptr = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003APPFrameworkInput_002Cclass_0020std_003A_003Ashared_ptr_003Cclass_0020ppinterface_003A_003AOperationNode_003E_002Cclass_0020ppinterface_003A_003ACAMInformation_0020_0026_002Cclass_0020ppinterface_003A_003AAdditionalData_0020_0026_003E(&shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, nativePtr3, _003C_Args_1_003E, _003C_Args_2_003E);
						try
						{
							SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E native = new SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E(native_ptr);
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
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
							throw;
						}
						try
						{
							if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)) != 0)
							{
								global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)));
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
						((IDisposable)m_native).Dispose();
						throw;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACAMInformation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
					throw;
				}
				try
				{
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2, 4)));
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AAdditionalData_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AAdditionalData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2, 4)));
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

	public unsafe PPFrameworkInput(OperationNode operationRootNode, CAMInformation cam_info, AdditionalData additional_data, List<Machine> machines)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E obj);
			shared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E* _003C_Args_3_003E = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Ashared_ptr_003Cclass_0020std_003A_003Avector_003Cclass_0020ppinterface_003A_003AMachine_002Cclass_0020std_003A_003Aallocator_003Cclass_0020ppinterface_003A_003AMachine_003E_0020_003E_0020_003E_002Cclass_0020System_003A_003ACollections_003A_003AGeneric_003A_003AList_003Cclass_0020ModuleWorks_003A_003APPInterface_003A_003AMachine_0020_005E_003E_0020_005E_003E(&obj, machines);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AAdditionalData_003E shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
				shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* nativePtr = additional_data.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AAdditionalData_003E2);
				shared_ptr_003Cppinterface_003A_003AAdditionalData_003E* ptr = nativePtr;
				try
				{
					ppinterface.AdditionalData* _003C_Args_2_003E = (ppinterface.AdditionalData*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ACAMInformation_003E shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
					shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* nativePtr2 = cam_info.GetNativePtr(&shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
					shared_ptr_003Cppinterface_003A_003ACAMInformation_003E* ptr2 = nativePtr2;
					try
					{
						ppinterface.CAMInformation* _003C_Args_1_003E = (ppinterface.CAMInformation*)(int)(*(uint*)nativePtr2);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperationNode_003E shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
						shared_ptr_003Cppinterface_003A_003AOperationNode_003E* nativePtr3 = operationRootNode.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperationNode_003E2);
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
							shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* native_ptr = global::_003CModule_003E.std_002Emake_shared_003Cclass_0020ppinterface_003A_003APPFrameworkInput_002Cclass_0020std_003A_003Ashared_ptr_003Cclass_0020ppinterface_003A_003AOperationNode_003E_002Cclass_0020ppinterface_003A_003ACAMInformation_0020_0026_002Cclass_0020ppinterface_003A_003AAdditionalData_0020_0026_002Cclass_0020std_003A_003Ashared_ptr_003Cclass_0020std_003A_003Avector_003Cclass_0020ppinterface_003A_003AMachine_002Cclass_0020std_003A_003Aallocator_003Cclass_0020ppinterface_003A_003AMachine_003E_0020_003E_0020_003E_0020_003E(&shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, nativePtr3, _003C_Args_1_003E, _003C_Args_2_003E, _003C_Args_3_003E);
							try
							{
								SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E native = new SharedPointer_003Cppinterface_003A_003APPFrameworkInput_003E(native_ptr);
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
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
								throw;
							}
							try
							{
								if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)) != 0)
								{
									global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)));
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
							((IDisposable)m_native).Dispose();
							throw;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ACAMInformation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2);
						throw;
					}
					try
					{
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ACAMInformation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ACAMInformation_003E2, 4)));
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
					((IDisposable)m_native).Dispose();
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E_002E_007Bdtor_007D), &obj);
				throw;
			}
			try
			{
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cstd_003A_003Avector_003Cppinterface_003A_003AMachine_002Cstd_003A_003Aallocator_003Cppinterface_003A_003AMachine_003E_0020_003E_0020_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 4)));
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

	public unsafe static string GetDataVersion()
	{
		string text = null;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
		basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr = &obj;
		basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr2 = global::_003CModule_003E.ppinterface_002EPPFrameworkInput_002EGetDataVersion(&obj);
		string result;
		try
		{
			text = null;
			global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert(ref text, ptr2);
			result = text;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), ptr2);
			throw;
		}
		try
		{
			global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(ptr2);
			return result;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), ptr2);
			throw;
		}
	}

	public unsafe void AddMachineUniquely(Machine machine)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr5);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr6);
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
			shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
			shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr = nativePtr;
			try
			{
				ppinterface.PPFrameworkInput* ptr2 = (ppinterface.PPFrameworkInput*)(int)(*(uint*)nativePtr);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AMachine_003E shared_ptr_003Cppinterface_003A_003AMachine_003E2);
				shared_ptr_003Cppinterface_003A_003AMachine_003E* nativePtr2 = machine.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AMachine_003E2);
				shared_ptr_003Cppinterface_003A_003AMachine_003E* ptr3 = nativePtr2;
				try
				{
					ppinterface.Machine* ptr4 = (ppinterface.Machine*)(int)(*(uint*)nativePtr2);
					global::_003CModule_003E.ppinterface_002EPPFrameworkInput_002EaddMachineUniquely(ptr2, ptr4);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMachine_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMachine_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AMachine_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMachine_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMachine_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMachine_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMachine_003E2, 4)));
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2);
				throw;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)) != 0)
			{
				global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E2, 4)));
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

	internal unsafe shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* P_0)
	{
		uint num = 0u;
		shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr = m_native.GetPtr();
		*(int*)P_0 = 0;
		shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E* ptr2 = (shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*)((byte*)P_0 + 4);
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	public void _007EPPFrameworkInput()
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

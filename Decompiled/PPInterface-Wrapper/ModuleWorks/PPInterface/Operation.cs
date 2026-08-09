using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class Operation : OperationNode
{
	public unsafe virtual int MoveListSize
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				int num2;
				try
				{
					num2 = (int)global::_003CModule_003E.ppinterface_002EOperation_002EGetMoveListSize((ppinterface.Operation*)(int)(*(uint*)nativePtr));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				int num3 = num2;
				GC.KeepAlive(this);
				return num2;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr2) != 0)
			{
				uint num4 = 0u;
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
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num4 = 0u;
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
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
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
				uint num4 = 0u;
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
						num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num4 != 0;
					}).Invoke())
					{
					}
					if (num4 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num4);
				}
			}
			return 0;
		}
	}

	public unsafe virtual ToolDescription ToolDescription
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr5);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				ToolDescription toolDescription;
				try
				{
					ppinterface.ToolDescription* ptr2 = global::_003CModule_003E.ppinterface_002EOperation_002EGetToolDescription((ppinterface.Operation*)(int)(*(uint*)nativePtr));
					System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E3);
					shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr2 = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E3);
					try
					{
						shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr3 = nativePtr2;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AToolDescription_003E shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
						*(int*)(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2) = 0;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) = 0;
						*(int*)(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2) = (int)ptr2;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AToolDescription_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AToolDescription_003E2, 4)) = ((int*)nativePtr2)[1];
						*(int*)nativePtr2 = 0;
						((int*)nativePtr2)[1] = 0;
						try
						{
							toolDescription = new ToolDescription(&shared_ptr_003Cppinterface_003A_003AToolDescription_003E2);
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
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E3);
						throw;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E3, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E3, 4)));
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				ToolDescription toolDescription2 = toolDescription;
				GC.KeepAlive(this);
				return toolDescription;
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
			return null;
		}
	}

	public unsafe virtual List<SpindleSettings> SpindleSettingsList
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr7);
			try
			{
				List<SpindleSettings> list = new List<SpindleSettings>();
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				vector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E* ptr2;
				try
				{
					ptr2 = global::_003CModule_003E.ppinterface_002EOperation_002EGetSpindleSettingsList((ppinterface.Operation*)(int)(*(uint*)nativePtr));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E* ptr3 = (_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E*)ptr2;
				int num2 = *(int*)ptr2;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out _Vector_iterator_003Cstd_003A_003A_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E_0020_003E obj);
				*(int*)(&obj) = num2;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out _Vector_iterator_003Cstd_003A_003A_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E_0020_003E obj2);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E3);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2);
				while (true)
				{
					_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E* ptr4 = (_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E*)ptr2;
					int num3 = (*(int*)(&obj2) = ((int*)ptr2)[1]);
					if (!(*(int*)(&obj) != num3))
					{
						break;
					}
					int num4 = *(int*)(&obj);
					shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr2 = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E3);
					try
					{
						shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr5 = nativePtr2;
						*(int*)(&shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2) = 0;
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2, 4)) = 0;
						*(int*)(&shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2) = *(int*)(&obj);
						System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2, 4)) = ((int*)nativePtr2)[1];
						*(int*)nativePtr2 = 0;
						((int*)nativePtr2)[1] = 0;
						try
						{
							list.Add(new SpindleSettings(&shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003ASpindleSettings_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2);
							throw;
						}
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E2, 4)));
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E3);
						throw;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E3, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E3, 4)));
					}
					_Vector_iterator_003Cstd_003A_003A_Vector_val_003Cstd_003A_003A_Simple_types_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E_0020_003E obj3 = obj;
					*(int*)(&obj) += 4;
				}
				return list;
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ppinterface.PostingCancelledException* intPtr = ptr6;
						throw new PostingCancelledException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 4)))((nint)intPtr)));
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr2 = ptr7;
						throw new ApplicationException(global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020System_003A_003AString_0020_005E_002Cchar_0020const_0020_002A_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
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
						throw new ApplicationException("Unknown Exception occurred.");
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
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				try
				{
					ppinterface.Operation* ptr2 = (ppinterface.Operation*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out vector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E obj);
					vector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E* ptr3 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Avector_003Cclass_0020ppinterface_003A_003ASpindleSettings_002Cclass_0020std_003A_003Aallocator_003Cclass_0020ppinterface_003A_003ASpindleSettings_003E_0020_003E_002Cclass_0020System_003A_003ACollections_003A_003AGeneric_003A_003AList_003Cclass_0020ModuleWorks_003A_003APPInterface_003A_003ASpindleSettings_0020_005E_003E_0020_005E_003E(&obj, value);
					try
					{
						global::_003CModule_003E.ppinterface_002EOperation_002ESetSpindleSettingsList(ptr2, ptr3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E_002E_007Bdtor_007D), &obj);
						throw;
					}
					global::_003CModule_003E.std_002Evector_003Cppinterface_003A_003ASpindleSettings_002Cstd_003A_003Aallocator_003Cppinterface_003A_003ASpindleSettings_003E_0020_003E_002E_Tidy(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
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

	public unsafe virtual FeedrateMode FeedrateMode
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				FeedrateMode feedrateMode;
				try
				{
					feedrateMode = (FeedrateMode)global::_003CModule_003E.ppinterface_002EOperation_002EGetFeedrateMode((ppinterface.Operation*)(int)(*(uint*)nativePtr));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				FeedrateMode feedrateMode2 = feedrateMode;
				GC.KeepAlive(this);
				return feedrateMode;
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
			return FeedrateMode.InverseTime;
		}
		set
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				try
				{
					global::_003CModule_003E.ppinterface_002EOperation_002ESetFeedrateMode((ppinterface.Operation*)(int)(*(uint*)nativePtr), (ppinterface.FeedrateMode)value);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
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
		}
	}

	public unsafe virtual RTCPMode RTCPMode
	{
		get
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				RTCPMode rTCPMode;
				try
				{
					rTCPMode = (RTCPMode)global::_003CModule_003E.ppinterface_002EOperation_002EGetRTCPMode((ppinterface.Operation*)(int)(*(uint*)nativePtr));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				RTCPMode rTCPMode2 = rTCPMode;
				GC.KeepAlive(this);
				return rTCPMode;
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
			return RTCPMode.Disabled;
		}
		set
		{
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				try
				{
					global::_003CModule_003E.ppinterface_002EOperation_002ESetRTCPMode((ppinterface.Operation*)(int)(*(uint*)nativePtr), (ppinterface.RTCPMode)value);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
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
		}
	}

	public unsafe virtual string PostingSection
	{
		get
		{
			string text = null;
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
				basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis = &obj;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				string text2;
				try
				{
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* right = global::_003CModule_003E.ppinterface_002EOperation_002EGetPostingSection((ppinterface.Operation*)(int)(*(uint*)nativePtr));
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
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
				}
				string text4 = text2;
				GC.KeepAlive(this);
				return text2;
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
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AOperation_003E shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* nativePtr = GetNativePtr(&shared_ptr_003Cppinterface_003A_003AOperation_003E2);
				shared_ptr_003Cppinterface_003A_003AOperation_003E* ptr = nativePtr;
				try
				{
					ppinterface.Operation* ptr2 = (ppinterface.Operation*)(int)(*(uint*)nativePtr);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr3 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Abasic_string_003Cchar_002Cstruct_0020std_003A_003Achar_traits_003Cchar_003E_002Cclass_0020std_003A_003Aallocator_003Cchar_003E_0020_003E_002Cclass_0020System_003A_003AString_0020_005E_003E(&obj, value);
					try
					{
						global::_003CModule_003E.ppinterface_002EOperation_002ESetPostingSection(ptr2, ptr3);
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
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AOperation_003E2);
					throw;
				}
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)) != 0)
				{
					global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AOperation_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AOperation_003E2, 4)));
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

	internal unsafe Operation(shared_ptr_003Cppinterface_003A_003AOperationNode_003E* ptr)
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

	internal unsafe shared_ptr_003Cppinterface_003A_003AOperation_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AOperation_003E* P_0)
	{
		uint num = 0u;
		global::_003CModule_003E.std_002Estatic_pointer_cast_003Cclass_0020ppinterface_003A_003AOperation_002Cclass_0020ppinterface_003A_003AOperationNode_003E(P_0, m_native.GetPtr());
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AOperation_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AOperation_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}
}

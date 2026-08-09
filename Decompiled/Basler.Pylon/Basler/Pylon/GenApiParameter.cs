#define DEBUG
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GenApi_3_1_Basler_pylon;
using GenICam_3_1_Basler_pylon;
using bclog;
using std;

namespace Basler.Pylon;

[DebuggerDisplay("FullName = {FullName}, IsEmpty = {IsEmpty}")]
internal unsafe class GenApiParameter(string name, string wrapperName, ObjectState parentState) : IParameter
{
	protected unsafe INode* m_pNode = null;

	protected string m_name = name;

	protected string m_wrapperName = wrapperName;

	protected bool m_isValidParameter = false;

	protected ObjectState m_parentState = parentState;

	protected GenApiAdvancedParameterAccess m_advancedSettings = new GenApiAdvancedParameterAccess(parentState);

	protected object m_eventLock = new object();

	protected GenApiCallbackDelegate m_genApiCallbackDelegate;

	protected GCHandle m_genApiCallbackDelegateHandle;

	protected int m_genApiCallbackHandle = 0;

	protected readonly PylonNETEventHandler<ParameterChangedEventArgs> m_parameterChangedEvent = new PylonNETEventHandler<ParameterChangedEventArgs>();

	protected readonly PylonNETEventHandler<ParameterValueChangedEventArgs> m_parameterValueChanged = new PylonNETEventHandler<ParameterValueChangedEventArgs>();

	protected object m_previousValue;

	public virtual IAdvancedParameterAccess Advanced => m_advancedSettings;

	public virtual bool IsEmpty
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			byte condition = (byte)((m_isValidParameter || !IsReadable) ? 1 : 0);
			Debug.Assert(condition != 0, "Dummy parameter cannot be readable.");
			byte condition2 = (byte)((m_isValidParameter || !IsWritable) ? 1 : 0);
			Debug.Assert(condition2 != 0, "Dummy parameter cannot be writable.");
			return !m_isValidParameter;
		}
	}

	public unsafe virtual bool IsWritable
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			//Discarded unreachable code: IL_023c
			ScopedObjectStateLock scopedObjectStateLock = null;
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
			byte b = 0;
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
				try
				{
					RaiseExceptionIfDisposed();
					INode* pNode = m_pNode;
					nint num3;
					if (pNode == null)
					{
						num3 = 0;
					}
					else
					{
						num3 = (nint)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
					}
					bool flag = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIsWritable((IBase*)num3);
					bool flag2 = flag;
					b = 1;
					((IDisposable)scopedObjectStateLock).Dispose();
					return flag;
				}
				catch (Exception ex)
				{
					string source = ex.Source;
					string message = ex.Message;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &source);
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0GE_0040EOICKHBP_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							uint num5 = global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID();
							GenericException* intPtr = ptr3;
							global::_003CModule_003E.bclog_002ELogTrace(num5, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FG_0040BGPIIGHJ_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
							goto end_IL_010d;
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
						end_IL_010d:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							uint num6 = global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID();
							exception* intPtr2 = ptr4;
							global::_003CModule_003E.bclog_002ELogTrace(num6, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EO_0040CDCBPMGM_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
							goto end_IL_017f;
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
						end_IL_017f:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EL_0040CCAELOMM_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
							goto end_IL_01ee;
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
						end_IL_01ee:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
			}
			catch
			{
				//try-fault
				if (b == 0)
				{
					((IDisposable)scopedObjectStateLock).Dispose();
				}
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			return false;
		}
	}

	public unsafe virtual bool IsReadable
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			//Discarded unreachable code: IL_023c
			ScopedObjectStateLock scopedObjectStateLock = null;
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
			byte b = 0;
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
				try
				{
					RaiseExceptionIfDisposed();
					INode* pNode = m_pNode;
					nint num3;
					if (pNode == null)
					{
						num3 = 0;
					}
					else
					{
						num3 = (nint)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
					}
					bool flag = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIsReadable((IBase*)num3);
					bool flag2 = flag;
					b = 1;
					((IDisposable)scopedObjectStateLock).Dispose();
					return flag;
				}
				catch (Exception ex)
				{
					string source = ex.Source;
					string message = ex.Message;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &source);
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0GE_0040NFEIOINN_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							uint num5 = global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID();
							GenericException* intPtr = ptr3;
							global::_003CModule_003E.bclog_002ELogTrace(num5, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FG_0040JAAFGIBB_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
							goto end_IL_010d;
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
						end_IL_010d:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
				catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							uint num6 = global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID();
							exception* intPtr2 = ptr4;
							global::_003CModule_003E.bclog_002ELogTrace(num6, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EO_0040KFNMBCAE_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
							goto end_IL_017f;
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
						end_IL_017f:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EL_0040GEEPGEEA_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
							goto end_IL_01ee;
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
						end_IL_01ee:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
			}
			catch
			{
				//try-fault
				if (b == 0)
				{
					((IDisposable)scopedObjectStateLock).Dispose();
				}
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			return false;
		}
	}

	public virtual string FullName => "@" + m_wrapperName + "/" + m_name;

	public virtual string Name => m_name;

	[SpecialName]
	public virtual event EventHandler<ParameterValueChangedEventArgs> ParameterValueChanged
	{
		add
		{
			ScopedLock scopedLock = null;
			uint num = 0u;
			if (m_parameterValueChanged.Add(value) == 1 && IsReadable)
			{
				m_previousValue = GetValueAsObject();
			}
			ScopedLock scopedLock2 = new ScopedLock(m_eventLock);
			try
			{
				scopedLock = scopedLock2;
				if (m_genApiCallbackHandle == 0)
				{
					RegisterGenICamCallback();
				}
			}
			catch
			{
				//try-fault
				((IDisposable)scopedLock).Dispose();
				throw;
			}
			((IDisposable)scopedLock).Dispose();
		}
		remove
		{
			UnregisterGenICamCallbackConditional(1);
			m_parameterValueChanged.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<ParameterChangedEventArgs> ParameterChanged
	{
		add
		{
			ScopedLock scopedLock = null;
			uint num = 0u;
			m_parameterChangedEvent.Add(value);
			ScopedLock scopedLock2 = new ScopedLock(m_eventLock);
			try
			{
				scopedLock = scopedLock2;
				if (m_genApiCallbackHandle == 0)
				{
					RegisterGenICamCallback();
				}
			}
			catch
			{
				//try-fault
				((IDisposable)scopedLock).Dispose();
				throw;
			}
			((IDisposable)scopedLock).Dispose();
		}
		remove
		{
			UnregisterGenICamCallbackConditional(1);
			m_parameterChangedEvent.Remove(value);
		}
	}

	public virtual string ToString(IFormatProvider A_0)
	{
		return ToString();
	}

	public unsafe override string ToString()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
		byte b = 0;
		string result;
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			if (m_parentState.m_state == EObjectState.Disposed)
			{
				result = "<disposed>";
				goto IL_003f;
			}
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)scopedObjectStateLock).Dispose();
			}
			throw;
		}
		b = 0;
		string result2;
		try
		{
			if (IsEmpty)
			{
				result2 = "<not found>";
				goto IL_0067;
			}
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)scopedObjectStateLock).Dispose();
			}
			throw;
		}
		b = 0;
		string result3;
		try
		{
			if (IsReadable)
			{
				try
				{
					INode* pNode = m_pNode;
					IBase* ptr;
					if (pNode == null)
					{
						ptr = null;
					}
					else
					{
						ptr = (IBase*)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
					}
					System.Runtime.CompilerServices.Unsafe.SkipInit(out CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
					CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr2 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E, ptr);
					string text;
					try
					{
						IValue* ptr3 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(ptr2);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						int num2 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte, byte, gcstring*>)(int)(*(uint*)(*(int*)ptr3 + 4)))((nint)ptr3, &gcstring2, 0, 0);
						try
						{
							text = new string(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)num2 + 44)))((IntPtr)num2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D), &cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
						throw;
					}
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
					string text2 = text;
					b = 1;
					((IDisposable)scopedObjectStateLock).Dispose();
					return text;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num3 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							result3 = "<error>";
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num3 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num3 != 0;
						}).Invoke())
						{
							goto IL_015d;
						}
						goto end_IL_0142;
						IL_015d:
						if (num3 != 0)
						{
							throw;
						}
						goto IL_017b;
						end_IL_0142:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num3);
					}
				}
				goto IL_0183;
			}
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)scopedObjectStateLock).Dispose();
			}
			throw;
		}
		b = 0;
		string result4;
		try
		{
			result4 = "<not readable>";
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)scopedObjectStateLock).Dispose();
			}
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
		return result4;
		IL_003f:
		((IDisposable)scopedObjectStateLock).Dispose();
		return result;
		IL_0183:
		((IDisposable)scopedObjectStateLock).Dispose();
		return result3;
		IL_0067:
		((IDisposable)scopedObjectStateLock).Dispose();
		return result2;
		IL_017b:
		((IDisposable)scopedObjectStateLock).Dispose();
		b = 0;
		try
		{
			return null;
		}
		catch
		{
			//try-fault
			if (b == 0)
			{
				((IDisposable)scopedObjectStateLock).Dispose();
			}
			throw;
		}
	}

	public unsafe virtual void ParseAndSetValue(string val)
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			RaiseExceptionIfDisposed();
			RaiseExceptionIfNotWritable();
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr14);
			try
			{
				INode* pNode = m_pNode;
				IBase* ptr;
				if (pNode == null)
				{
					ptr = null;
				}
				else
				{
					ptr = (IBase*)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &val);
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
					CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr3 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E, ptr);
					try
					{
						IValue* ptr4 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(ptr3);
						((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte, void>)(int)(*(uint*)(*(int*)ptr4 + 8)))((nint)ptr4, ptr2, 1);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D), &cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
						throw;
					}
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr5;
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
						ex.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr6;
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
						ex2.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr7;
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
						ex3.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr8;
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
						ex4.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr9;
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
						ex5.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr10;
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
						ex6.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr11;
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
						ex7.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr12;
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
						ex8.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr13;
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
						ex9.Source = m_parentState.m_name;
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
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr14;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = m_parentState.m_name;
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
						ex12.Source = m_parentState.m_name;
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
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool Attach(INodeMap* pNodeMap)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
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
			return (byte)((AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AINode_003E(pNodeMap) != null) ? 1u : 0u) != 0;
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
					ex.Source = m_parentState.m_name;
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
					ex2.Source = m_parentState.m_name;
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
					ex3.Source = m_parentState.m_name;
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
					ex4.Source = m_parentState.m_name;
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
					ex5.Source = m_parentState.m_name;
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
					ex6.Source = m_parentState.m_name;
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
					ex7.Source = m_parentState.m_name;
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
					ex8.Source = m_parentState.m_name;
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
					ex9.Source = m_parentState.m_name;
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
					ex10.Source = m_parentState.m_name;
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
					ex12.Source = m_parentState.m_name;
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
		return false;
	}

	public static string GetParameterTypeDisplayname(int genapiInterfaceType)
	{
		return genapiInterfaceType switch
		{
			6 => "IStringParameter", 
			3 => "IBooleanParameter", 
			2 => "IIntegerParameter", 
			5 => "IFloatParameter", 
			4 => "ICommandParameter", 
			9 => "IEnumParameter", 
			11 => "IRawParameter", 
			7 => "IArrayParameter", 
			_ => "IParameter", 
		};
	}

	public static string GetParameterTypeDisplayname(string parameterTypeName)
	{
		string result = parameterTypeName;
		if (parameterTypeName.StartsWith("GenApi", StringComparison.Ordinal) && parameterTypeName.EndsWith("Parameter", StringComparison.Ordinal))
		{
			result = parameterTypeName.Replace("GenApi", "I");
		}
		return result;
	}

	public static string GetParameterTypeDisplayname(Type parameterType)
	{
		if (parameterType == null)
		{
			return "null";
		}
		return GetParameterTypeDisplayname(parameterType.Name);
	}

	protected unsafe virtual object GetValueAsObject()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		try
		{
			return ToString();
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
					return null;
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

	protected unsafe void RaiseExceptionIfNotReadable()
	{
		if (IsEmpty)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException($"The parameter {FullName} does not exist."), m_parentState.m_name);
		}
		INode* pNode = m_pNode;
		nint num;
		if (pNode == null)
		{
			num = 0;
		}
		else
		{
			num = (nint)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
		}
		if (!global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIsReadable((IBase*)num))
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException($"The parameter {FullName} is not readable."), m_parentState.m_name);
		}
	}

	protected unsafe void RaiseExceptionIfNotWritable()
	{
		if (IsEmpty)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException($"The parameter {FullName} does not exist."), m_parentState.m_name);
		}
		INode* pNode = m_pNode;
		nint num;
		if (pNode == null)
		{
			num = 0;
		}
		else
		{
			num = (nint)((byte*)pNode + *(int*)(((int*)pNode)[1] + 4) + 4);
		}
		if (!global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIsWritable((IBase*)num))
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException($"The parameter {FullName} is not writable."), m_parentState.m_name);
		}
	}

	protected void RaiseExceptionIfDisposed()
	{
		ObjectState parentState = m_parentState;
		if (parentState.m_state == EObjectState.Disposed)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ObjectDisposedException(m_parentState.m_name, $"The parent object of the parameter {FullName} has been disposed."), parentState.m_name);
		}
	}

	protected unsafe void RegisterGenICamCallback()
	{
		uint num = 0u;
		if (m_pNode == null)
		{
			return;
		}
		byte condition = ((m_genApiCallbackHandle == 0) ? ((byte)1) : ((byte)0));
		Debug.Assert(condition != 0, "There is already a callback registered. Unregister before registering a new one");
		byte condition2 = (byte)((m_pNode != null) ? 1 : 0);
		Debug.Assert(condition2 != 0);
		UnregisterGenICamCallback();
		GCHandle genApiCallbackDelegateHandle = GCHandle.Alloc(m_genApiCallbackDelegate = OnGenApiCallback);
		m_genApiCallbackDelegateHandle = genApiCallbackDelegateHandle;
		delegate* unmanaged[Stdcall, Stdcall]<INode*, void> delegate_002A = (delegate* unmanaged[Stdcall, Stdcall]<INode*, void>)Marshal.GetFunctionPointerForDelegate((Delegate)m_genApiCallbackDelegate).ToPointer();
		m_genApiCallbackHandle = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ERegister_003Cvoid_0020_0028__stdcall_002A_0029_0028struct_0020GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E(m_pNode, delegate_002A, (_ECallbackType)2);
		INode* pNode = m_pNode;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		sbyte* ptr;
		if (pNode != null)
		{
			int num2 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte, gcstring*>)(int)(*(uint*)(int)(*(uint*)pNode)))((nint)pNode, &gcstring2, 0);
			try
			{
				num = 1u;
				ptr = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)num2 + 44)))((IntPtr)num2);
			}
			catch
			{
				//try-fault
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				}
				throw;
			}
		}
		else
		{
			ptr = (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06HPGEIPLA_0040_003F_0024DMnull_003F_0024DO_0040);
		}
		try
		{
			global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)16, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EB_0040MLIPDIGG_0040Registered_003F5genapi_003F5callback_003F5for_003F5_0040), __arglist(ptr, (void*)m_genApiCallbackHandle, (void*)delegate_002A));
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			}
			throw;
		}
		if ((num & 1) != 0)
		{
			num &= 0xFFFFFFFEu;
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		}
	}

	protected unsafe void UnregisterGenICamCallback()
	{
		uint num = 0u;
		if (m_genApiCallbackHandle != 0)
		{
			INode* pNode = m_pNode;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			sbyte* ptr;
			if (pNode != null)
			{
				int num2 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte, gcstring*>)(int)(*(uint*)(int)(*(uint*)pNode)))((nint)pNode, &gcstring2, 0);
				try
				{
					num = 1u;
					ptr = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)num2 + 44)))((IntPtr)num2);
				}
				catch
				{
					//try-fault
					if ((num & 1) != 0)
					{
						num &= 0xFFFFFFFEu;
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					}
					throw;
				}
			}
			else
			{
				ptr = (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06HPGEIPLA_0040_003F_0024DMnull_003F_0024DO_0040);
			}
			try
			{
				global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)16, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DJ_0040JMFONCO_0040Unregistering_003F5genapi_003F5callback_003F5f_0040), __arglist(ptr, (void*)m_genApiCallbackHandle));
			}
			catch
			{
				//try-fault
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				}
				throw;
			}
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			}
			global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EDeregister(m_genApiCallbackHandle);
			m_genApiCallbackHandle = 0;
		}
		if (m_genApiCallbackDelegateHandle.IsAllocated)
		{
			m_genApiCallbackDelegateHandle.Free();
		}
		if (m_genApiCallbackDelegate != null)
		{
			m_genApiCallbackDelegate = null;
		}
	}

	protected unsafe void OnGenApiCallback(INode* pNode)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		try
		{
			byte condition = ((m_pNode == pNode) ? ((byte)1) : ((byte)0));
			Debug.Assert(condition != 0, "Invalid node passed to callback.");
			ParameterChangedEventArgs eventArgs = new ParameterChangedEventArgs(this);
			m_parameterChangedEvent.Raise(this, eventArgs, EventErrorHandling.Propagate);
			if (m_parameterValueChanged.Length <= 0 || !IsReadable)
			{
				return;
			}
			object valueAsObject = GetValueAsObject();
			object obj = null;
			ScopedLock scopedLock3 = new ScopedLock(m_eventLock);
			try
			{
				scopedLock = scopedLock3;
				obj = m_previousValue;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedLock).Dispose();
				throw;
			}
			((IDisposable)scopedLock).Dispose();
			byte condition2 = (byte)((valueAsObject == null || object.ReferenceEquals(obj.GetType(), valueAsObject.GetType())) ? 1 : 0);
			Debug.Assert(condition2 != 0, "Objects must be of same type");
			if (valueAsObject != null && obj != null && !obj.Equals(valueAsObject))
			{
				ParameterValueChangedEventArgs eventArgs2 = new ParameterValueChangedEventArgs(this, obj, valueAsObject);
				ScopedLock scopedLock4 = new ScopedLock(m_eventLock);
				try
				{
					scopedLock2 = scopedLock4;
					m_previousValue = valueAsObject;
				}
				catch
				{
					//try-fault
					((IDisposable)scopedLock2).Dispose();
					throw;
				}
				((IDisposable)scopedLock2).Dispose();
				m_parameterValueChanged.Raise(this, eventArgs2, EventErrorHandling.Propagate);
			}
		}
		catch (ArgumentOutOfRangeException ex)
		{
			string message = ex.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &message);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException ex2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EOutOfRangeException_002E_007Bctor_007D(&ex2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299);
				global::_003CModule_003E._CxxThrowException(&ex2, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
		}
		catch (ArgumentException ex3)
		{
			string message2 = ex3.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
			gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message2);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException ex4);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EInvalidArgumentException_002E_007Bctor_007D(&ex4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299);
				global::_003CModule_003E._CxxThrowException(&ex4, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
				throw;
			}
		}
		catch (System.TimeoutException ex5)
		{
			string message3 = ex5.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
			gcstring* ptr3 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring4, &message3);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException ex6);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002ETimeoutException_002E_007Bctor_007D(&ex6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr3 + 44)))((nint)ptr3), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299);
				global::_003CModule_003E._CxxThrowException(&ex6, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
				throw;
			}
		}
		catch (InvalidOperationException ex7)
		{
			string message4 = ex7.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
			gcstring* ptr4 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring5, &message4);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException ex8);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002ELogicalErrorException_002E_007Bctor_007D(&ex8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr4 + 44)))((nint)ptr4), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299);
				global::_003CModule_003E._CxxThrowException(&ex8, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
				throw;
			}
		}
		catch (OutOfMemoryException ex9)
		{
			string message5 = ex9.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
			gcstring* ptr5 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring6, &message5);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException ex10);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bctor_007D(&ex10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr5 + 44)))((nint)ptr5), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299);
				global::_003CModule_003E._CxxThrowException(&ex10, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
				throw;
			}
		}
		catch (Exception ex11)
		{
			string message6 = ex11.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
			gcstring* ptr6 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring7, &message6);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException ex12);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EGenericException_002E_007Bctor_007D(&ex12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr6 + 44)))((nint)ptr6), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299u);
				global::_003CModule_003E._CxxThrowException(&ex12, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI1_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
				throw;
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
					System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
					ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* ptr7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 299, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0BB_0040CDLLKKB_0040RuntimeException_0040));
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException ex13);
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002EReport(ptr7, &ex13, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0BC_0040EOODALEL_0040Unknown_003F5exception_0040), __arglist());
						global::_003CModule_003E._CxxThrowException(&ex13, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._TI2_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040));
						return;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
						throw;
					}
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

	protected void RaiseTypeMismatchException(int genapiInterfaceType)
	{
		string parameterTypeDisplayname = GetParameterTypeDisplayname(GetType());
		string parameterTypeDisplayname2 = GetParameterTypeDisplayname(genapiInterfaceType);
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentException($"The type of parameter {Name} does not match the requested type. (Found: {parameterTypeDisplayname2}; Requested: {parameterTypeDisplayname})", "name"), m_parentState.m_name);
	}

	protected unsafe void AttachToAdvancedParameters()
	{
		m_advancedSettings.Attach(m_pNode, m_isValidParameter);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	protected bool UnregisterGenICamCallbackConditional(int numHandlers)
	{
		ScopedLock scopedLock = null;
		uint num = 0u;
		ScopedLock scopedLock2 = new ScopedLock(m_eventLock);
		try
		{
			scopedLock = scopedLock2;
			if (m_genApiCallbackHandle != 0 && m_parameterValueChanged.Length + m_parameterChangedEvent.Length <= numHandlers)
			{
				UnregisterGenICamCallback();
				goto IL_0047;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_0047:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	protected unsafe IRegister* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIRegister_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IRegister* ptr3 = (IRegister*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIRegister_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe ICommand* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AICommand_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			ICommand* ptr3 = (ICommand*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUICommand_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IPort* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIPort_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IPort* ptr3 = (IPort*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIPort_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IBoolean* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIBoolean_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IBoolean* ptr3 = (IBoolean*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIBoolean_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IEnumeration* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIEnumeration_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IEnumeration* ptr3 = (IEnumeration*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIEnumeration_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IFloat* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIFloat_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IFloat* ptr3 = (IFloat*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIFloat_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IInteger* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIInteger_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IInteger* ptr3 = (IInteger*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIInteger_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe INode* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AINode_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr2;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}

	protected unsafe IString* AttachImpl_003CGenApi_3_1_Basler_pylon_003A_003AIString_003E(INodeMap* pNodeMap)
	{
		string text = null;
		uint num = 0u;
		if (pNodeMap != null)
		{
			text = m_name;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			INode* ptr2;
			try
			{
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 == null)
			{
				return null;
			}
			IString* ptr3 = (IString*)global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIString_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0);
			if (ptr3 == null)
			{
				int genapiInterfaceType = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2);
				RaiseTypeMismatchException(genapiInterfaceType);
			}
			if (m_pNode != null)
			{
				UnregisterGenICamCallback();
			}
			m_pNode = ptr2;
			m_isValidParameter = true;
			AttachToAdvancedParameters();
			return ptr3;
		}
		UnregisterGenICamCallback();
		m_pNode = null;
		m_isValidParameter = false;
		AttachToAdvancedParameters();
		return null;
	}
}

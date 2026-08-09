#define DEBUG
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using GenICam_3_1_Basler_pylon;
using bclog;

namespace Basler.Pylon;

internal class PylonNETEventHandler<T> where T : EventArgs
{
	protected EventHandler<T> m_eventHandler;

	public int Length
	{
		get
		{
			EventHandler<T> location = null;
			Interlocked.Exchange(ref location, m_eventHandler);
			return (int)((location != null) ? location.GetInvocationList().LongLength : 0);
		}
	}

	public int Add(EventHandler<T> handler)
	{
		EventHandler<T> eventHandler2;
		EventHandler<T> eventHandler3;
		do
		{
			EventHandler<T> eventHandler = m_eventHandler;
			eventHandler2 = eventHandler;
			eventHandler3 = (EventHandler<T>)Delegate.Combine(eventHandler, handler);
		}
		while (eventHandler2 != Interlocked.CompareExchange(ref m_eventHandler, eventHandler3, eventHandler2));
		return eventHandler3.GetInvocationList().Length;
	}

	public int Remove(EventHandler<T> handler)
	{
		EventHandler<T> eventHandler2;
		EventHandler<T> eventHandler3;
		do
		{
			EventHandler<T> eventHandler = m_eventHandler;
			eventHandler2 = eventHandler;
			eventHandler3 = (EventHandler<T>)Delegate.Remove(eventHandler, handler);
		}
		while (eventHandler2 != Interlocked.CompareExchange(ref m_eventHandler, eventHandler3, eventHandler2));
		return (int)((eventHandler3 != null) ? eventHandler3.GetInvocationList().LongLength : 0);
	}

	public int Raise(object sender, T eventArgs, EventErrorHandling eh)
	{
		switch (eh)
		{
		default:
			Debug.Assert(condition: false, "EventErrorHandling value bad.");
			return InternalRaisePropagate(sender, eventArgs);
		case EventErrorHandling.Propagate:
			return InternalRaisePropagate(sender, eventArgs);
		case EventErrorHandling.NoThrow:
			return InternalRaiseNoThrow(sender, eventArgs);
		}
	}

	private unsafe int InternalRaisePropagate(object sender, T eventArgs)
	{
		EventHandler<T> eventHandler = null;
		string text = null;
		string text2 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		try
		{
			eventHandler = null;
			Interlocked.Exchange(ref eventHandler, m_eventHandler);
			int result = 0;
			if (eventHandler != null)
			{
				Delegate[] invocationList = eventHandler.GetInvocationList();
				for (int i = 0; i < (nint)invocationList.LongLength; i++)
				{
					((EventHandler<T>)invocationList[i])(sender, eventArgs);
				}
				result = eventHandler.GetInvocationList().Length;
			}
			return result;
		}
		catch (Exception ex)
		{
			text = typeof(EventHandler<T>).ToString();
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
			try
			{
				string message = ex.Message;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
				global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
				try
				{
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetLibraryCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DO_0040DEPAAFCK_0040Exception_003F5caught_003F5in_003F5propagating_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring2) + 44)))((nint)(&gcstring2)), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring3) + 44)))((nint)(&gcstring3))));
					throw;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
					throw;
				}
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
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
					text2 = typeof(EventHandler<T>).ToString();
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring4, &text2);
					try
					{
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetLibraryCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DD_0040JBNJDNLE_0040Unknown_003F5exception_003F5occurred_003F5in_003F5e_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring4) + 44)))((nint)(&gcstring4))));
						global::_003CModule_003E._CxxThrowException(null, null);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
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
					goto IL_017a;
				}
				goto end_IL_0111;
				IL_017a:
				if (num2 != 0)
				{
					throw;
				}
				end_IL_0111:;
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		return 0;
	}

	private unsafe int InternalRaiseNoThrow(object sender, T eventArgs)
	{
		EventHandler<T> eventHandler = null;
		string text = null;
		string text2 = null;
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		eventHandler = null;
		Interlocked.Exchange(ref eventHandler, m_eventHandler);
		int result = 0;
		if (eventHandler != null)
		{
			Delegate[] invocationList = eventHandler.GetInvocationList();
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint exceptionCode);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
			for (int i = 0; i < (nint)invocationList.LongLength; i++)
			{
				EventHandler<T> eventHandler2 = (EventHandler<T>)invocationList[i];
				try
				{
					eventHandler2(sender, eventArgs);
				}
				catch (Exception ex)
				{
					text = typeof(EventHandler<T>).ToString();
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
					try
					{
						string message = ex.Message;
						global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
						try
						{
							global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetLibraryCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EO_0040JGFIJDKF_0040Exception_003F5caught_003F5and_003F5ignored_003F5in_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring2) + 44)))((nint)(&gcstring2)), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring3) + 44)))((nint)(&gcstring3))));
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
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					num3 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							text2 = typeof(EventHandler<T>).ToString();
							global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring4, &text2);
							try
							{
								global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetLibraryCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EN_0040KBDJLEMF_0040Unknown_003F5exception_003F5caught_003F5and_003F5ig_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring4) + 44)))((nint)(&gcstring4))));
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
								throw;
							}
							global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
							goto end_IL_0117;
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
						end_IL_0117:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
					}
				}
			}
			result = eventHandler.GetInvocationList().Length;
		}
		return result;
	}
}

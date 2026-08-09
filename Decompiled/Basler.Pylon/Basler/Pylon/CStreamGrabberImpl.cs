using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using Basler.Pylon.Internal;
using GenICam_3_1_Basler_pylon;
using Microsoft.Win32.SafeHandles;
using Pylon;
using bclog;
using std;

namespace Basler.Pylon;

internal class CStreamGrabberImpl : IStreamGrabber, IDisposable
{
	private object m_userData;

	private unsafe CInstantCamera* m_pInstantCamera;

	private BufferReleaser m_bufferReleaser;

	private IBufferFactory m_bufferFactory;

	private bool m_inRetrieveResultCall;

	private IGrabResult m_currentGrabResult;

	private ObjectState m_cameraState;

	private GenApiParameterCollection m_parameterCollection;

	private EventWaitHandle m_GrabResultReady;

	private EventWaitHandle m_GrabStopped;

	private readonly PylonNETEventHandler<ImageGrabbedEventArgs> m_ehImageGrabbed;

	private readonly PylonNETEventHandler<EventArgs> m_ehGrabStarting;

	private readonly PylonNETEventHandler<EventArgs> m_ehGrabStarted;

	private readonly PylonNETEventHandler<GrabStopEventArgs> m_ehGrabStopping;

	private readonly PylonNETEventHandler<GrabStopEventArgs> m_ehGrabStopped;

	private readonly PylonNETEventHandler<GrabStopEventArgs> m_ehGrabError;

	private GrabStopEventArgs m_grabStopEventArgsForNextRaise;

	public unsafe virtual IBufferFactory BufferFactory
	{
		get
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
			IBufferFactory bufferFactory;
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				bufferFactory = m_bufferFactory;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			return bufferFactory;
		}
		set
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				RaiseExceptionIfDisposed();
				if (value != m_bufferFactory)
				{
					goto IL_0040;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			goto IL_0766;
			IL_0766:
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
			IL_0040:
			try
			{
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
					CNativeBufferFactory* ptr = (CNativeBufferFactory*)global::_003CModule_003E.@new(16u);
					CNativeBufferFactory* ptr2;
					try
					{
						ptr2 = ((ptr == null) ? null : global::_003CModule_003E.Basler_002EPylon_002ECNativeBufferFactory_002E_007Bctor_007D(ptr, value, m_bufferReleaser));
						CNativeBufferFactory* ptr3 = ptr2;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.delete(ptr, 16u);
						throw;
					}
					System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E obj);
					global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_002C0_003E(&obj, ptr2);
					try
					{
						if (global::_003CModule_003E.std_002Eoperator_003D_003D_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E(null, &obj))
						{
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AOutOfMemoryException_002Cclass_0020System_003A_003AString_0020_005E_003E(new OutOfMemoryException("Could not allocate native buffer factory."), m_cameraState.m_name);
						}
						CInstantCamera* pInstantCamera = m_pInstantCamera;
						((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, global::Pylon.IBufferFactory*, ECleanup, void>)(int)(*(uint*)(*(int*)pInstantCamera + 148)))((nint)pInstantCamera, (global::Pylon.IBufferFactory*)global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Eget(&obj), (ECleanup)1);
						global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Erelease(&obj);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bdtor_007D), &obj);
						throw;
					}
					global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bdtor_007D(&obj);
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
							ex.Source = m_cameraState.m_name;
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
							ex2.Source = m_cameraState.m_name;
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
							ex3.Source = m_cameraState.m_name;
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
							ex4.Source = m_cameraState.m_name;
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
							ex5.Source = m_cameraState.m_name;
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
							ex6.Source = m_cameraState.m_name;
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
							ex7.Source = m_cameraState.m_name;
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
							ex8.Source = m_cameraState.m_name;
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
							ex9.Source = m_cameraState.m_name;
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
							Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
							ex10.Source = m_cameraState.m_name;
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
							ex12.Source = m_cameraState.m_name;
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
				m_bufferFactory = value;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			goto IL_0766;
		}
	}

	public virtual object UserData
	{
		get
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
			object userData;
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				userData = m_userData;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
			return userData;
		}
		set
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				RaiseExceptionIfDisposed();
				m_userData = value;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock).Dispose();
		}
	}

	public virtual WaitHandle GrabStopWaitHandle => m_GrabStopped;

	public virtual WaitHandle GrabResultWaitHandle => m_GrabResultReady;

	public unsafe virtual bool IsGrabbing
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			uint num = 0u;
			int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
			try
			{
				ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
				bool result;
				try
				{
					scopedObjectStateLock = scopedObjectStateLock2;
					CInstantCamera* pInstantCamera = m_pInstantCamera;
					if (pInstantCamera != null)
					{
						result = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)pInstantCamera + 56)))((nint)pInstantCamera) != 0;
						goto IL_0043;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)scopedObjectStateLock).Dispose();
					throw;
				}
				((IDisposable)scopedObjectStateLock).Dispose();
				goto end_IL_000d;
				IL_0043:
				((IDisposable)scopedObjectStateLock).Dispose();
				return result;
				end_IL_000d:;
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
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0GH_0040LOOIIPJD_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
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
				uint num3 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						uint num4 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
						GenericException* intPtr = ptr3;
						global::_003CModule_003E.bclog_002ELogTrace(num4, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FJ_0040ODBOBGHA_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
						goto end_IL_010b;
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
					end_IL_010b:;
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
						uint num5 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
						exception* intPtr2 = ptr4;
						global::_003CModule_003E.bclog_002ELogTrace(num5, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FB_0040NDCMIMNC_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
						goto end_IL_017d;
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
					end_IL_017d:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
				}
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
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EO_0040PLKMBHJD_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
						goto end_IL_01ec;
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
					end_IL_01ec:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num3);
				}
			}
			return false;
		}
	}

	public virtual IParameterCollection Parameters => m_parameterCollection;

	[SpecialName]
	public virtual event EventHandler<GrabStopEventArgs> GrabError
	{
		add
		{
			m_ehGrabError.Add(value);
		}
		remove
		{
			m_ehGrabError.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<GrabStopEventArgs> GrabStopped
	{
		add
		{
			m_ehGrabStopped.Add(value);
		}
		remove
		{
			m_ehGrabStopped.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<GrabStopEventArgs> GrabStopping
	{
		add
		{
			m_ehGrabStopping.Add(value);
		}
		remove
		{
			m_ehGrabStopping.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<EventArgs> GrabStarted
	{
		add
		{
			m_ehGrabStarted.Add(value);
		}
		remove
		{
			m_ehGrabStarted.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<EventArgs> GrabStarting
	{
		add
		{
			m_ehGrabStarting.Add(value);
		}
		remove
		{
			m_ehGrabStarting.Remove(value);
		}
	}

	[SpecialName]
	public virtual event EventHandler<ImageGrabbedEventArgs> ImageGrabbed
	{
		add
		{
			m_ehImageGrabbed.Add(value);
		}
		remove
		{
			m_ehImageGrabbed.Remove(value);
		}
	}

	public unsafe CStreamGrabberImpl(CInstantCamera* pInstantCamera, GenApiNodeMapWrapper nw, ObjectState cameraState)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		m_pInstantCamera = pInstantCamera;
		m_bufferReleaser = new BufferReleaser();
		m_inRetrieveResultCall = false;
		m_currentGrabResult = null;
		m_cameraState = cameraState;
		m_GrabResultReady = new EventWaitHandle(initialState: false, EventResetMode.ManualReset);
		m_GrabStopped = new EventWaitHandle(initialState: false, EventResetMode.ManualReset);
		m_ehImageGrabbed = new PylonNETEventHandler<ImageGrabbedEventArgs>();
		m_ehGrabStarting = new PylonNETEventHandler<EventArgs>();
		m_ehGrabStarted = new PylonNETEventHandler<EventArgs>();
		m_ehGrabStopping = new PylonNETEventHandler<GrabStopEventArgs>();
		m_ehGrabStopped = new PylonNETEventHandler<GrabStopEventArgs>();
		m_ehGrabError = new PylonNETEventHandler<GrabStopEventArgs>();
		base._002Ector();
		GenApiParameterCollection genApiParameterCollection = (m_parameterCollection = new GenApiParameterCollection(cameraState));
		string nodeMapName = "StreamGrabber0";
		genApiParameterCollection.AttachWrapper(nodeMapName, nw);
		CInstantCamera* pInstantCamera2 = m_pInstantCamera;
		IntPtr existingHandle = WaitObjectHelper.Duplicate(global::_003CModule_003E.Pylon_002EWaitObject_002E_002EPAX(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, WaitObject*>)(int)(*(uint*)(*(int*)pInstantCamera2 + 68)))((nint)pInstantCamera2)));
		m_GrabResultReady.SafeWaitHandle = new SafeWaitHandle(existingHandle, ownsHandle: true);
		CInstantCamera* pInstantCamera3 = m_pInstantCamera;
		CInstantCamera* intPtr = pInstantCamera3;
		IntPtr existingHandle2 = WaitObjectHelper.Duplicate(global::_003CModule_003E.Pylon_002EWaitObject_002E_002EPAX(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, WaitObject*>)(int)(*(uint*)(*(int*)intPtr + 72)))((nint)intPtr)));
		m_GrabStopped.SafeWaitHandle = new SafeWaitHandle(existingHandle2, ownsHandle: true);
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
			CNativeBufferFactory* ptr = (CNativeBufferFactory*)global::_003CModule_003E.@new(16u);
			CNativeBufferFactory* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.Basler_002EPylon_002ECNativeBufferFactory_002E_007Bctor_007D(ptr, null, m_bufferReleaser));
				CNativeBufferFactory* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16u);
				throw;
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E obj);
			global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_002C0_003E(&obj, ptr2);
			try
			{
				if (global::_003CModule_003E.std_002Eoperator_003D_003D_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E(null, &obj))
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AOutOfMemoryException_002Cclass_0020System_003A_003AString_0020_005E_003E(new OutOfMemoryException("Could not allocate native buffer factory."), m_cameraState.m_name);
				}
				pInstantCamera3 = m_pInstantCamera;
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, global::Pylon.IBufferFactory*, ECleanup, void>)(int)(*(uint*)(*(int*)pInstantCamera3 + 148)))((nint)pInstantCamera3, (global::Pylon.IBufferFactory*)global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Eget(&obj), (ECleanup)1);
				global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Erelease(&obj);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bdtor_007D), &obj);
				throw;
			}
			global::_003CModule_003E.std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bdtor_007D(&obj);
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					InvalidArgumentException* intPtr2 = ptr4;
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
					ex.Source = m_cameraState.m_name;
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
					OutOfRangeException* intPtr3 = ptr5;
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
					ex2.Source = m_cameraState.m_name;
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
					AccessException* intPtr4 = ptr6;
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
					ex3.Source = m_cameraState.m_name;
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
					GenICam_3_1_Basler_pylon.TimeoutException* intPtr5 = ptr7;
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
					ex4.Source = m_cameraState.m_name;
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
					LogicalErrorException* intPtr6 = ptr8;
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
					ex5.Source = m_cameraState.m_name;
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
					BadAllocException* intPtr7 = ptr9;
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
					ex6.Source = m_cameraState.m_name;
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
					RuntimeException* intPtr8 = ptr10;
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
					ex7.Source = m_cameraState.m_name;
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
					DynamicCastException* intPtr9 = ptr11;
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
					ex8.Source = m_cameraState.m_name;
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
					GenericException* intPtr10 = ptr12;
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
					ex9.Source = m_cameraState.m_name;
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
					exception* intPtr11 = ptr13;
					throw new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 4)))((nint)intPtr11)))
					{
						Source = m_cameraState.m_name
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
						Source = m_cameraState.m_name
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

	private void _007ECStreamGrabberImpl()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			_0021CStreamGrabberImpl();
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
	}

	private unsafe void _0021CStreamGrabberImpl()
	{
		if (m_pInstantCamera != null)
		{
			m_pInstantCamera = null;
			m_userData = null;
			((IDisposable)m_GrabResultReady)?.Dispose();
			m_GrabResultReady = null;
			((IDisposable)m_GrabStopped)?.Dispose();
			m_GrabStopped = null;
		}
	}

	public virtual void Start(long maxImages)
	{
		Start(maxImages, GrabStrategy.OneByOne, GrabLoop.ProvidedByUser);
	}

	public virtual void Start(long maxImages, GrabStrategy strategy, GrabLoop grabLoopType)
	{
		StartImpl(maxImages, useMaxImages: true, strategy, grabLoopType);
	}

	public virtual void Start(GrabStrategy strategy, GrabLoop grabLoopType)
	{
		StartImpl(0L, useMaxImages: false, strategy, grabLoopType);
	}

	public virtual void Start()
	{
		Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByUser);
	}

	private unsafe void StartImpl(long maxImages, [MarshalAs(UnmanagedType.U1)] bool useMaxImages, GrabStrategy strategy, GrabLoop grabLoopType)
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		ScopedObjectStateLock scopedObjectStateLock2 = null;
		ScopedObjectStateLock scopedObjectStateLock3 = null;
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		Exception ex12 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		ScopedObjectStateLock scopedObjectStateLock4 = new ScopedObjectStateLock(m_cameraState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock4;
			RaiseExceptionIfDisposed();
			m_cameraState.m_flagInUse = true;
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
			CInstantCamera* pInstantCamera = m_pInstantCamera;
			if (pInstantCamera != null)
			{
				IInstantCameraExtensions* intPtr = global::_003CModule_003E.Pylon_002ECInstantCamera_002EGetExtensionInterface(pInstantCamera);
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr);
			}
		}
		finally
		{
			ScopedObjectStateLock scopedObjectStateLock5 = new ScopedObjectStateLock(m_cameraState);
			try
			{
				scopedObjectStateLock2 = scopedObjectStateLock5;
				m_cameraState.m_flagInUse = false;
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock2).Dispose();
				throw;
			}
			((IDisposable)scopedObjectStateLock2).Dispose();
		}
		ScopedObjectStateLock scopedObjectStateLock6 = new ScopedObjectStateLock(m_cameraState);
		try
		{
			scopedObjectStateLock3 = scopedObjectStateLock6;
			RaiseExceptionIfDisposed();
			RaiseExceptionIfCameraNotOpen();
			RaiseExceptionIfAlreadyGrabbing();
			RaiseExceptionIfInUse();
			m_grabStopEventArgsForNextRaise = new GrabStopEventArgs();
			m_ehGrabStarting.Raise(this, EventArgs.Empty, EventErrorHandling.Propagate);
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
				if (useMaxImages)
				{
					if (maxImages <= 0)
					{
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentOutOfRangeException("The maxImages parameter must be greater than 0.", "maxImages"), m_cameraState.m_name);
					}
					if (maxImages > 4294967295L)
					{
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentOutOfRangeException($"The maxImages parameter must not be greater than {uint.MaxValue}.", "maxImages"), m_cameraState.m_name);
					}
					CInstantCamera* pInstantCamera2 = m_pInstantCamera;
					((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, EGrabStrategy, EGrabLoop, void>)(int)(*(uint*)(*(int*)pInstantCamera2 + 40)))((nint)pInstantCamera2, (uint)maxImages, (EGrabStrategy)strategy, (EGrabLoop)grabLoopType);
				}
				else
				{
					CInstantCamera* pInstantCamera2 = m_pInstantCamera;
					((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, EGrabStrategy, EGrabLoop, void>)(int)(*(uint*)(*(int*)pInstantCamera2 + 44)))((nint)pInstantCamera2, (EGrabStrategy)strategy, (EGrabLoop)grabLoopType);
				}
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
						ex.Source = m_cameraState.m_name;
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
						ex2.Source = m_cameraState.m_name;
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
						ex3.Source = m_cameraState.m_name;
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
						ex4.Source = m_cameraState.m_name;
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
						ex5.Source = m_cameraState.m_name;
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
						ex6.Source = m_cameraState.m_name;
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
						ex7.Source = m_cameraState.m_name;
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
						ex8.Source = m_cameraState.m_name;
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
						ex9.Source = m_cameraState.m_name;
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
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 4)))((nint)intPtr11)));
						ex10.Source = m_cameraState.m_name;
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
						ex11 = new Exception("Unknown exception");
						ex11.Source = m_cameraState.m_name;
						throw ex11;
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
			try
			{
				m_ehGrabStarted.Raise(this, EventArgs.Empty, EventErrorHandling.Propagate);
			}
			catch (Exception ex14)
			{
				m_grabStopEventArgsForNextRaise = new GrabStopEventArgs(GrabStopReason.GrabStartedEventException, $"{ex14.GetType().ToString()} exception occurred in the GrabStarted event handler. ({ex14.Message})");
				Stop();
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
						m_grabStopEventArgsForNextRaise = new GrabStopEventArgs(GrabStopReason.GrabStartedEventException, "Unknown exception occurred in the GrabStarted event handler.");
						Stop();
						global::_003CModule_003E._CxxThrowException(null, null);
						goto end_IL_0876;
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
					end_IL_0876:;
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
			((IDisposable)scopedObjectStateLock3).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock3).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock3).Dispose();
			throw;
		}
	}

	public unsafe virtual void Stop()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
		try
		{
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_cameraState);
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				CInstantCamera* pInstantCamera = m_pInstantCamera;
				if (pInstantCamera != null)
				{
					CInstantCamera* intPtr = pInstantCamera;
					if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)intPtr + 56)))((nint)intPtr) != 0)
					{
						pInstantCamera = m_pInstantCamera;
						CInstantCamera* intPtr2 = pInstantCamera;
						((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)intPtr2 + 52)))((nint)intPtr2);
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
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FM_0040IFGIBBLO_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
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
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					uint num4 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
					GenericException* intPtr3 = ptr3;
					global::_003CModule_003E.bclog_002ELogTrace(num4, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EO_0040GEMNJFBD_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3)));
					return;
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
					uint num5 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
					exception* intPtr4 = ptr4;
					global::_003CModule_003E.bclog_002ELogTrace(num5, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EG_0040FKAIAKLM_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 4)))((nint)intPtr4)));
					return;
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
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0ED_0040HNKDNPML_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
					return;
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

	public unsafe virtual IGrabResult RetrieveResult(int timeoutMs, TimeoutHandling timeoutHandling)
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		ScopedObjectStateLock scopedObjectStateLock2 = null;
		uint num = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num2 = (int)stackalloc byte[(int)(num << 1)];
		ScopedObjectStateLock scopedObjectStateLock3 = new ScopedObjectStateLock(m_cameraState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock3;
			RaiseExceptionIfDisposed();
			RaiseExceptionIfCameraNotOpen();
			RaiseExceptionIfInUse();
			m_cameraState.m_flagInUse = true;
			m_inRetrieveResultCall = true;
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
		IGrabResult grabResult = null;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out int num3);
		try
		{
			num3 = (int)num + num2;
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
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out CGrabResultPtr cGrabResultPtr);
					global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bctor_007D(&cGrabResultPtr);
					try
					{
						global::_003CModule_003E.Pylon_002ECInstantCamera_002ERetrieveResult(m_pInstantCamera, (uint)timeoutMs, &cGrabResultPtr, (ETimeoutHandling)timeoutHandling);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultPtr*, void>)(&global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bdtor_007D), &cGrabResultPtr);
						throw;
					}
					global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bdtor_007D(&cGrabResultPtr);
				}
				finally
				{
					ScopedObjectStateLock scopedObjectStateLock4 = new ScopedObjectStateLock(m_cameraState);
					try
					{
						scopedObjectStateLock2 = scopedObjectStateLock4;
						m_inRetrieveResultCall = false;
						grabResult = m_currentGrabResult;
						m_currentGrabResult = null;
						m_cameraState.m_flagInUse = false;
					}
					catch
					{
						//try-fault
						((IDisposable)scopedObjectStateLock2).Dispose();
						throw;
					}
					((IDisposable)scopedObjectStateLock2).Dispose();
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex.Source = m_cameraState.m_name;
						throw ex;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex2.Source = m_cameraState.m_name;
						throw ex2;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex3.Source = m_cameraState.m_name;
						throw ex3;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex4.Source = m_cameraState.m_name;
						throw ex4;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex5.Source = m_cameraState.m_name;
						throw ex5;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex6.Source = m_cameraState.m_name;
						throw ex6;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex7.Source = m_cameraState.m_name;
						throw ex7;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex8.Source = m_cameraState.m_name;
						throw ex8;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
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
						ex9.Source = m_cameraState.m_name;
						throw ex9;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num4 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						exception* intPtr10 = ptr10;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = m_cameraState.m_name;
						throw ex10;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
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
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						Exception ex12 = new Exception("Unknown exception");
						ex12.Source = m_cameraState.m_name;
						throw ex12;
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
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
				}
			}
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode2 = (uint)Marshal.GetExceptionCode();
			return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num5 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
			try
			{
				try
				{
					if (grabResult != null)
					{
						IGrabResult grabResult2 = grabResult;
						IDisposable disposable = grabResult;
						grabResult.Dispose();
					}
					global::_003CModule_003E._CxxThrowException(null, null);
					goto end_IL_0773;
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
				end_IL_0773:;
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
			}
		}
		return grabResult;
	}

	public virtual IGrabResult GrabOne(int timeoutMs)
	{
		return GrabOne(timeoutMs, TimeoutHandling.ThrowException);
	}

	public unsafe virtual IGrabResult GrabOne(int timeoutMs, TimeoutHandling timeoutHandling)
	{
		uint num = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num2 = (int)stackalloc byte[(int)(num << 1)];
		RaiseExceptionIfDisposed();
		IGrabResult grabResult = null;
		Start(1L, GrabStrategy.OneByOne, GrabLoop.ProvidedByUser);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out int num3);
		try
		{
			num3 = (int)num + num2;
			grabResult = RetrieveResult(timeoutMs, TimeoutHandling.Return);
			if (grabResult == null && IsGrabbing)
			{
				Stop();
				if (timeoutHandling == TimeoutHandling.ThrowException)
				{
					throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ATimeoutException_002Cclass_0020System_003A_003AString_0020_005E_003E(new System.TimeoutException("Grabbing timed out."), m_cameraState.m_name);
				}
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
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
			try
			{
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
					try
					{
						Stop();
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
								global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040NODGCMJN_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
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
						uint num5 = 0u;
						global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
						try
						{
							try
							{
								uint num6 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
								GenericException* intPtr = ptr3;
								global::_003CModule_003E.bclog_002ELogTrace(num6, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EP_0040OMJKMALN_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
								goto end_IL_0147;
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
							end_IL_0147:;
						}
						finally
						{
							global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
						}
					}
					catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
					{
						uint num5 = 0u;
						global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
						try
						{
							try
							{
								uint num7 = global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID();
								exception* intPtr2 = ptr4;
								global::_003CModule_003E.bclog_002ELogTrace(num7, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EH_0040KKMNLLFL_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
								goto end_IL_01b9;
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
							end_IL_01b9:;
						}
						finally
						{
							global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
						}
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						uint exceptionCode2 = (uint)Marshal.GetExceptionCode();
						return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
					}).Invoke())
					{
						uint num5 = 0u;
						global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
						try
						{
							try
							{
								global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetCameraCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EE_0040HMMLBML_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
								goto end_IL_0228;
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
							end_IL_0228:;
						}
						finally
						{
							global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
						}
					}
					global::_003CModule_003E._CxxThrowException(null, null);
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
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num4);
			}
		}
		return grabResult;
	}

	public void OnGrabStopping()
	{
		m_ehGrabStopping.Raise(this, m_grabStopEventArgsForNextRaise, EventErrorHandling.NoThrow);
	}

	public void OnGrabStopped()
	{
		m_ehGrabStopped.Raise(this, m_grabStopEventArgsForNextRaise, EventErrorHandling.NoThrow);
		m_grabStopEventArgsForNextRaise = new GrabStopEventArgs();
	}

	public unsafe void OnGrabError(sbyte* message)
	{
		m_grabStopEventArgsForNextRaise = new GrabStopEventArgs(GrabStopReason.GrabEngineError, new string(message));
	}

	public unsafe void OnImageGrabbedNative(CGrabResultPtr* grabResult)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize() << 1];
		GrabResult grabResult2 = null;
		try
		{
			grabResult2 = new GrabResult(grabResult, m_userData);
			m_ehImageGrabbed.Raise(this, new ImageGrabbedEventArgs(grabResult2), EventErrorHandling.Propagate);
		}
		catch (ArgumentOutOfRangeException ex)
		{
			string message = ex.Message;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &message);
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException ex2);
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EOutOfRangeException_002E_007Bctor_007D(&ex2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469);
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
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EInvalidArgumentException_002E_007Bctor_007D(&ex4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469);
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
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002ETimeoutException_002E_007Bctor_007D(&ex6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr3 + 44)))((nint)ptr3), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469);
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
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002ELogicalErrorException_002E_007Bctor_007D(&ex8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr4 + 44)))((nint)ptr4), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469);
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
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bctor_007D(&ex10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr5 + 44)))((nint)ptr5), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469);
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
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EGenericException_002E_007Bctor_007D(&ex12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr6 + 44)))((nint)ptr6), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469u);
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
					ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* ptr7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 469, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0BB_0040CDLLKKB_0040RuntimeException_0040));
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
		finally
		{
			if (m_inRetrieveResultCall)
			{
				m_currentGrabResult = grabResult2;
			}
			else
			{
				((IDisposable)grabResult2)?.Dispose();
			}
		}
	}

	private void RaiseExceptionIfDisposed()
	{
		ObjectState cameraState = m_cameraState;
		if (cameraState.m_state == EObjectState.Disposed)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ObjectDisposedException("StreamGrabber", "The camera object of this stream grabber has already been disposed."), cameraState.m_name);
		}
	}

	private void RaiseExceptionIfInUse()
	{
		ObjectState cameraState = m_cameraState;
		if (cameraState.m_flagInUse)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException("Action cannot be performed. The stream grabber is already in use."), cameraState.m_name);
		}
	}

	private unsafe void RaiseExceptionIfAlreadyGrabbing()
	{
		CInstantCamera* pInstantCamera = m_pInstantCamera;
		if (pInstantCamera != null)
		{
			if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)pInstantCamera + 56)))((nint)pInstantCamera) != 0)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException("The stream grabber is already grabbing."), m_cameraState.m_name);
			}
		}
	}

	private unsafe void RaiseExceptionIfNotGrabbing()
	{
		CInstantCamera* pInstantCamera = m_pInstantCamera;
		if (pInstantCamera != null)
		{
			if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)pInstantCamera + 56)))((nint)pInstantCamera) == 0)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException("Cannot retrieve a grab result. Grabbing has not been started."), m_cameraState.m_name);
			}
		}
	}

	private unsafe void RaiseExceptionIfCameraNotOpen()
	{
		CInstantCamera* pInstantCamera = m_pInstantCamera;
		if (pInstantCamera != null)
		{
			if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)pInstantCamera + 32)))((nint)pInstantCamera) == 0)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException("The connection to the camera must be open to operate the stream grabber."), m_cameraState.m_name);
			}
		}
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007ECStreamGrabberImpl();
			return;
		}
		try
		{
			_0021CStreamGrabberImpl();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}

	~CStreamGrabberImpl()
	{
		Dispose(A_0: false);
	}
}

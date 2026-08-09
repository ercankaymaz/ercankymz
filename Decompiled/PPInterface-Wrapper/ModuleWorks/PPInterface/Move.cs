using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using ppinterface;
using std;

namespace ModuleWorks.PPInterface;

public class Move : IDisposable
{
	private readonly SharedPointer_003Cppinterface_003A_003AMove_003E m_native;

	internal unsafe Move(shared_ptr_003Cppinterface_003A_003AMove_003E* ptr)
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr3);
		try
		{
			SharedPointer_003Cppinterface_003A_003AMove_003E native = new SharedPointer_003Cppinterface_003A_003AMove_003E(ptr);
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

	public unsafe Move(Vectord partPos, Vectord absMachPos, MoveType moveType, LinkType moveSubtype, double feedRate, [MarshalAs(UnmanagedType.U1)] bool isRapid, Vectord orientation, double spindleSpeed, ReadOnlyCollection<double> rotationAxisValues, [MarshalAs(UnmanagedType.U1)] bool isArc, Vectord arcCenterAbs, Vectord arcCenterRel, Vectord arcNormal, double radius, ArcMoveType arcType, double sweepAngle, double height, [MarshalAs(UnmanagedType.U1)] bool hasPotentialSurfaceContactPoint, Vectord potentialSurfaceContactPoint, Vectord potentialSurfaceContactPointOrientation, ArcMoveDirection arcDirection, MoveMarker marker)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ppinterface.PostingCancelledException* ptr21);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr22);
		try
		{
			ppinterface.Move* ptr = (ppinterface.Move*)global::_003CModule_003E.@new(4u);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AMoveMarker_003E shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out vector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E obj);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AVectord_003E shared_ptr_003Cppinterface_003A_003AVectord_003E9);
			ppinterface.Move* ptr19;
			try
			{
				if (ptr != null)
				{
					shared_ptr_003Cppinterface_003A_003AMoveMarker_003E* nativePtr = marker.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2);
					try
					{
						num = 1u;
						shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr2 = potentialSurfaceContactPointOrientation.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E2);
						shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr2 = nativePtr2;
						try
						{
							num = 3u;
							ppinterface.Vectord* ptr3 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr2);
							shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr3 = potentialSurfaceContactPoint.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E3);
							shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr4 = nativePtr3;
							try
							{
								num = 7u;
								ppinterface.Vectord* ptr5 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr3);
								shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr4 = arcNormal.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E4);
								shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr6 = nativePtr4;
								try
								{
									num = 15u;
									ppinterface.Vectord* ptr7 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr4);
									shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr5 = arcCenterRel.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E5);
									shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr8 = nativePtr5;
									try
									{
										num = 31u;
										ppinterface.Vectord* ptr9 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr5);
										shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr6 = arcCenterAbs.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E6);
										shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr10 = nativePtr6;
										try
										{
											num = 63u;
											ppinterface.Vectord* ptr11 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr6);
											vector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E* ptr12 = global::_003CModule_003E.ModuleWorks_002EPPInterface_002EConvert_003Cclass_0020std_003A_003Avector_003Cdouble_002Cclass_0020std_003A_003Aallocator_003Cdouble_003E_0020_003E_002Cclass_0020System_003A_003ACollections_003A_003AObjectModel_003A_003AReadOnlyCollection_003Cdouble_003E_0020_005E_003E(&obj, rotationAxisValues);
											try
											{
												num = 127u;
												shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr7 = orientation.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E7);
												shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr13 = nativePtr7;
												try
												{
													num = 255u;
													ppinterface.Vectord* ptr14 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr7);
													shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr8 = absMachPos.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E8);
													shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr15 = nativePtr8;
													try
													{
														num = 511u;
														ppinterface.Vectord* ptr16 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr8);
														shared_ptr_003Cppinterface_003A_003AVectord_003E* nativePtr9 = partPos.GetNativePtr(&shared_ptr_003Cppinterface_003A_003AVectord_003E9);
														shared_ptr_003Cppinterface_003A_003AVectord_003E* ptr17 = nativePtr9;
														try
														{
															num = 1023u;
															ppinterface.Vectord* ptr18 = (ppinterface.Vectord*)(int)(*(uint*)nativePtr9);
															ptr19 = global::_003CModule_003E.ppinterface_002EMove_002E_007Bctor_007D(ptr, ptr18, ptr16, (ppinterface.MoveType)moveType, (ppinterface.LinkType)moveSubtype, feedRate, isRapid, ptr14, spindleSpeed, ptr12, isArc, ptr11, ptr9, ptr7, radius, (ppinterface.ArcMoveType)arcType, sweepAngle, height, hasPotentialSurfaceContactPoint, ptr5, ptr3, (ppinterface.ArcMoveDirection)arcDirection, nativePtr);
														}
														catch
														{
															//try-fault
															if ((num & 0x200) != 0)
															{
																num &= 0xFFFFFDFFu;
																global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E9);
															}
															throw;
														}
													}
													catch
													{
														//try-fault
														if ((num & 0x100) != 0)
														{
															num &= 0xFFFFFEFFu;
															global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E8);
														}
														throw;
													}
												}
												catch
												{
													//try-fault
													if ((num & 0x80) != 0)
													{
														num &= 0xFFFFFF7Fu;
														global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E7);
													}
													throw;
												}
											}
											catch
											{
												//try-fault
												if ((num & 0x40) != 0)
												{
													num &= 0xFFFFFFBFu;
													global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E_002E_007Bdtor_007D), &obj);
												}
												throw;
											}
										}
										catch
										{
											//try-fault
											if ((num & 0x20) != 0)
											{
												num &= 0xFFFFFFDFu;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E6);
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
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E5);
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
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E4);
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
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E3);
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
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
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
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMoveMarker_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2);
						}
						throw;
					}
				}
				else
				{
					ptr19 = null;
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
										try
										{
											try
											{
												try
												{
													try
													{
														ppinterface.Move* ptr20 = ptr19;
													}
													catch
													{
														//try-fault
														if ((num & 0x200) != 0)
														{
															num &= 0xFFFFFDFFu;
															global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E9);
														}
														throw;
													}
												}
												catch
												{
													//try-fault
													if ((num & 0x100) != 0)
													{
														num &= 0xFFFFFEFFu;
														global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E8);
													}
													throw;
												}
											}
											catch
											{
												//try-fault
												if ((num & 0x80) != 0)
												{
													num &= 0xFFFFFF7Fu;
													global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E7);
												}
												throw;
											}
										}
										catch
										{
											//try-fault
											if ((num & 0x40) != 0)
											{
												num &= 0xFFFFFFBFu;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E_002E_007Bdtor_007D), &obj);
											}
											throw;
										}
									}
									catch
									{
										//try-fault
										if ((num & 0x20) != 0)
										{
											num &= 0xFFFFFFDFu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E6);
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
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E5);
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
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E4);
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
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E3);
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
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
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
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMoveMarker_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2);
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
									try
									{
										try
										{
											try
											{
												try
												{
													System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003Cppinterface_003A_003AMove_003E shared_ptr_003Cppinterface_003A_003AMove_003E2);
													shared_ptr_003Cppinterface_003A_003AMove_003E* native_ptr = global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMove_003E_002E_007Bctor_007D_003Cclass_0020ppinterface_003A_003AMove_002C0_003E(&shared_ptr_003Cppinterface_003A_003AMove_003E2, ptr19);
													try
													{
														SharedPointer_003Cppinterface_003A_003AMove_003E native = new SharedPointer_003Cppinterface_003A_003AMove_003E(native_ptr);
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
														global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMove_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMove_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AMove_003E2);
														throw;
													}
													try
													{
														if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMove_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMove_003E2, 4)) != 0)
														{
															global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMove_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMove_003E2, 4)));
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
													if ((num & 0x200) != 0)
													{
														num &= 0xFFFFFDFFu;
														global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E9);
													}
													throw;
												}
												try
												{
													if ((num & 0x200) != 0)
													{
														num &= 0xFFFFFDFFu;
														if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E9, 4)) != 0)
														{
															global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E9, 4)));
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
												if ((num & 0x100) != 0)
												{
													num &= 0xFFFFFEFFu;
													global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E8);
												}
												throw;
											}
											try
											{
												if ((num & 0x100) != 0)
												{
													num &= 0xFFFFFEFFu;
													if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E8, 4)) != 0)
													{
														global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E8, 4)));
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
											if ((num & 0x80) != 0)
											{
												num &= 0xFFFFFF7Fu;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E7);
											}
											throw;
										}
										try
										{
											if ((num & 0x80) != 0)
											{
												num &= 0xFFFFFF7Fu;
												if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E7, 4)) != 0)
												{
													global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E7, 4)));
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
										if ((num & 0x40) != 0)
										{
											num &= 0xFFFFFFBFu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<vector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Evector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E_002E_007Bdtor_007D), &obj);
										}
										throw;
									}
									try
									{
										if ((num & 0x40) != 0)
										{
											num &= 0xFFFFFFBFu;
											global::_003CModule_003E.std_002Evector_003Cdouble_002Cstd_003A_003Aallocator_003Cdouble_003E_0020_003E_002E_Tidy(&obj);
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
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E6);
									}
									throw;
								}
								try
								{
									if ((num & 0x20) != 0)
									{
										num &= 0xFFFFFFDFu;
										if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E6, 4)) != 0)
										{
											global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E6, 4)));
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
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E5);
								}
								throw;
							}
							try
							{
								if ((num & 0x10) != 0)
								{
									num &= 0xFFFFFFEFu;
									if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E5, 4)) != 0)
									{
										global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E5, 4)));
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
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E4);
							}
							throw;
						}
						try
						{
							if ((num & 8) != 0)
							{
								num &= 0xFFFFFFF7u;
								if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E4, 4)) != 0)
								{
									global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E4, 4)));
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
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E3);
						}
						throw;
					}
					try
					{
						if ((num & 4) != 0)
						{
							num &= 0xFFFFFFFBu;
							if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E3, 4)) != 0)
							{
								global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E3, 4)));
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
					if ((num & 2) != 0)
					{
						num &= 0xFFFFFFFDu;
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AVectord_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AVectord_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AVectord_003E2);
					}
					throw;
				}
				try
				{
					if ((num & 2) != 0)
					{
						num &= 0xFFFFFFFDu;
						if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E2, 4)) != 0)
						{
							global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AVectord_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AVectord_003E2, 4)));
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
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMoveMarker_003E_002E_007Bdtor_007D), &shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2);
				}
				throw;
			}
			try
			{
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2, 4)) != 0)
					{
						global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003Cppinterface_003A_003AMoveMarker_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003Cppinterface_003A_003AMoveMarker_003E2, 4)));
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVPostingCancelledException_0040ppinterface_0040_0040_00408), 9, &ptr21) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					ppinterface.PostingCancelledException* intPtr = ptr21;
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
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr22) != 0)
		{
			uint num3 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
			try
			{
				try
				{
					exception* intPtr2 = ptr22;
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

	internal unsafe shared_ptr_003Cppinterface_003A_003AMove_003E* GetNativePtr(shared_ptr_003Cppinterface_003A_003AMove_003E* P_0)
	{
		uint num = 0u;
		shared_ptr_003Cppinterface_003A_003AMove_003E* ptr = m_native.GetPtr();
		*(int*)P_0 = 0;
		shared_ptr_003Cppinterface_003A_003AMove_003E* ptr2 = (shared_ptr_003Cppinterface_003A_003AMove_003E*)((byte*)P_0 + 4);
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
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003Cppinterface_003A_003AMove_003E*, void>)(&global::_003CModule_003E.std_002Eshared_ptr_003Cppinterface_003A_003AMove_003E_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	public void _007EMove()
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

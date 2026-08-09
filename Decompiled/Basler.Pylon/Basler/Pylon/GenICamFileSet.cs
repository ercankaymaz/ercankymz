using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenApi_3_1_Basler_pylon;
using GenICam_3_1_Basler_pylon;
using std;

namespace Basler.Pylon;

public class GenICamFileSet : IDisposable
{
	protected struct NodeMapData
	{
		public unsafe CNodeMapRef* m_pNodeMapRef;
	}

	private Dictionary<string, NodeMapData> m_nodeMapData = new Dictionary<string, NodeMapData>();

	private ObjectState m_parentState;

	private GenApiParameterCollection m_parameterCollection;

	public IParameterCollection Parameters => m_parameterCollection;

	public GenICamFileSet()
	{
		(m_parentState = new ObjectState(this)).m_state = EObjectState.Open;
		m_parentState.m_name = "GenICamFile";
		m_parameterCollection = new GenApiParameterCollection(m_parentState);
	}

	private void _007EGenICamFileSet()
	{
		_0021GenICamFileSet();
	}

	private unsafe void _0021GenICamFileSet()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			if (m_parentState.m_state != EObjectState.Disposed)
			{
				Dictionary<string, NodeMapData>.Enumerator enumerator = m_nodeMapData.GetEnumerator();
				System.Runtime.CompilerServices.Unsafe.SkipInit(out uint exceptionCode);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num2);
				while (enumerator.MoveNext())
				{
					ValueType valueType = enumerator.Current;
					try
					{
						m_parameterCollection.AttachWrapper(((KeyValuePair<string, NodeMapData>)valueType).Key, null);
						CNodeMapRef* pNodeMapRef = ((KeyValuePair<string, NodeMapData>)valueType).Value.m_pNodeMapRef;
						CNodeMapRef* ptr = pNodeMapRef;
						if (pNodeMapRef != null)
						{
							void* ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(*(int*)pNodeMapRef + 4)))((nint)pNodeMapRef, 1u);
						}
						else
						{
							void* ptr2 = null;
						}
						NodeMapData value = ((KeyValuePair<string, NodeMapData>)valueType).Value;
						value.m_pNodeMapRef = null;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						exceptionCode = (uint)Marshal.GetExceptionCode();
						return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
					}).Invoke())
					{
						num2 = 0u;
						global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
						try
						{
							try
							{
								goto end_IL_00d6;
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
							end_IL_00d6:;
						}
						finally
						{
							global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
						}
					}
				}
				m_nodeMapData.Clear();
				m_parentState.m_state = EObjectState.Disposed;
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

	public virtual void LoadFromFile(string parameterCollectionPathName, string filename, string subTreeRootNodeName)
	{
		LoadImpl(parameterCollectionPathName, filename, subTreeRootNodeName, isFileName: true);
	}

	public virtual void LoadFromFile(string parameterCollectionPathName, string filename)
	{
		LoadImpl(parameterCollectionPathName, filename, null, isFileName: true);
	}

	public virtual void LoadFromString(string parameterCollectionPathName, string xmlContent, string subTreeRootNodeName)
	{
		LoadImpl(parameterCollectionPathName, xmlContent, subTreeRootNodeName, isFileName: false);
	}

	public virtual void LoadFromString(string parameterCollectionPathName, string xmlContent)
	{
		LoadImpl(parameterCollectionPathName, xmlContent, null, isFileName: false);
	}

	protected unsafe virtual void LoadImpl(string parameterCollectionPathName, string s, string subTreeRootNodeName, [MarshalAs(UnmanagedType.U1)] bool isFileName)
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		uint num = 0u;
		uint num2 = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num3 = (int)stackalloc byte[(int)(num2 << 1)];
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_parentState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			m_parameterCollection.RaiseExceptionIfIdentifyerBad(parameterCollectionPathName);
			NodeMapData value = default(NodeMapData);
			if (m_nodeMapData.TryGetValue(parameterCollectionPathName, out value))
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Path already in use.", "parameterCollectionPathName"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BI_0040LJIHCIPI_0040_003F_0024AAG_003F_0024AAe_003F_0024AAn_003F_0024AAI_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_0040));
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out int num4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr22);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr23);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr24);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr25);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr26);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr27);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr28);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr29);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr30);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr31);
			try
			{
				num4 = (int)num2 + num3;
				CNodeMapFactory* ptr = null;
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &s);
					try
					{
						if (isFileName)
						{
							CNodeMapFactory* ptr2 = (CNodeMapFactory*)global::_003CModule_003E.@new(8u);
							CNodeMapFactory* ptr3;
							try
							{
								if (ptr2 != null)
								{
									global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bctor_007D(ptr2, (EContentType_t)0, &gcstring2, (ECacheUsage_t)0, false);
									*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00406B_0040);
									ptr3 = ptr2;
								}
								else
								{
									ptr3 = null;
								}
								CNodeMapFactory* ptr4 = ptr3;
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.delete(ptr2, 8u);
								throw;
							}
							ptr = ptr3;
						}
						else
						{
							CNodeMapFactory* ptr5 = (CNodeMapFactory*)global::_003CModule_003E.@new(8u);
							CNodeMapFactory* ptr6;
							try
							{
								if (ptr5 != null)
								{
									global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bctor_007D(ptr5, &gcstring2, (ECacheUsage_t)0, false);
									*(int*)ptr5 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00406B_0040);
									ptr6 = ptr5;
								}
								else
								{
									ptr6 = null;
								}
								CNodeMapFactory* ptr7 = ptr6;
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.delete(ptr5, 8u);
								throw;
							}
							ptr = ptr6;
						}
						if (string.IsNullOrEmpty(subTreeRootNodeName))
						{
							CNodeMapRef* ptr8 = (CNodeMapRef*)global::_003CModule_003E.@new(84u);
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
							CNodeMapRef* ptr9;
							try
							{
								if (ptr8 != null)
								{
									global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06OIEJKIHP_0040Device_0040));
									try
									{
										num = 1u;
										global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06OIEJKIHP_0040Device_0040));
										try
										{
											num = 3u;
											ptr9 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapRef_002E_007Bctor_007D(ptr8, global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002ECreateNodeMap(ptr, &gcstring4, true), &gcstring3);
										}
										catch
										{
											//try-fault
											if ((num & 2) != 0)
											{
												num &= 0xFFFFFFFDu;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
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
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
										}
										throw;
									}
								}
								else
								{
									ptr9 = null;
								}
								try
								{
									try
									{
										CNodeMapRef* ptr10 = ptr9;
									}
									catch
									{
										//try-fault
										if ((num & 2) != 0)
										{
											num &= 0xFFFFFFFDu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
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
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
									}
									throw;
								}
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.delete(ptr8, 84u);
								throw;
							}
							try
							{
								try
								{
									value.m_pNodeMapRef = ptr9;
								}
								catch
								{
									//try-fault
									if ((num & 2) != 0)
									{
										num &= 0xFFFFFFFDu;
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
									}
									throw;
								}
								if ((num & 2) != 0)
								{
									num &= 0xFFFFFFFDu;
									global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
								}
							}
							catch
							{
								//try-fault
								if ((num & 1) != 0)
								{
									num &= 0xFFFFFFFEu;
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
								}
								throw;
							}
							if ((num & 1) != 0)
							{
								num &= 0xFFFFFFFEu;
								global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
							}
						}
						else
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
							global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring5, &subTreeRootNodeName);
							try
							{
								System.Runtime.CompilerServices.Unsafe.SkipInit(out CNodeMapFactory cNodeMapFactory);
								global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002EExtractSubtree(ptr, &cNodeMapFactory, &gcstring5, true);
								try
								{
									CNodeMapRef* ptr11 = (CNodeMapRef*)global::_003CModule_003E.@new(84u);
									System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
									System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
									CNodeMapRef* ptr12;
									try
									{
										if (ptr11 != null)
										{
											global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06OIEJKIHP_0040Device_0040));
											try
											{
												num = 4u;
												global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_06OIEJKIHP_0040Device_0040));
												try
												{
													num = 12u;
													ptr12 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapRef_002E_007Bctor_007D(ptr11, global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002ECreateNodeMap(&cNodeMapFactory, &gcstring7, true), &gcstring6);
												}
												catch
												{
													//try-fault
													if ((num & 8) != 0)
													{
														num &= 0xFFFFFFF7u;
														global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
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
													global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
												}
												throw;
											}
										}
										else
										{
											ptr12 = null;
										}
										try
										{
											try
											{
												CNodeMapRef* ptr13 = ptr12;
											}
											catch
											{
												//try-fault
												if ((num & 8) != 0)
												{
													num &= 0xFFFFFFF7u;
													global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
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
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
											}
											throw;
										}
									}
									catch
									{
										//try-fault
										global::_003CModule_003E.delete(ptr11, 84u);
										throw;
									}
									try
									{
										try
										{
											value.m_pNodeMapRef = ptr12;
										}
										catch
										{
											//try-fault
											if ((num & 8) != 0)
											{
												num &= 0xFFFFFFF7u;
												global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
											}
											throw;
										}
										if ((num & 8) != 0)
										{
											num &= 0xFFFFFFF7u;
											global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
										}
									}
									catch
									{
										//try-fault
										if ((num & 4) != 0)
										{
											num &= 0xFFFFFFFBu;
											global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
										}
										throw;
									}
									if ((num & 4) != 0)
									{
										num &= 0xFFFFFFFBu;
										global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
									}
								}
								catch
								{
									//try-fault
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CNodeMapFactory*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bdtor_007D), &cNodeMapFactory);
									throw;
								}
								global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bdtor_007D(&cNodeMapFactory);
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
								throw;
							}
							global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						}
						CNodeMapFactory* ptr14 = ptr;
						CNodeMapFactory* ptr15 = ptr;
						if (ptr != null)
						{
							void* ptr16 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)ptr)))((nint)ptr, 1u);
						}
						else
						{
							void* ptr16 = null;
						}
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
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num5 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
					try
					{
						try
						{
							CNodeMapRef* pNodeMapRef = value.m_pNodeMapRef;
							CNodeMapRef* ptr17 = pNodeMapRef;
							if (pNodeMapRef != null)
							{
								void* ptr18 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(*(int*)pNodeMapRef + 4)))((nint)pNodeMapRef, 1u);
							}
							else
							{
								void* ptr18 = null;
							}
							CNodeMapFactory* ptr19 = ptr;
							CNodeMapFactory* ptr20 = ptr;
							if (ptr != null)
							{
								void* ptr21 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)ptr)))((nint)ptr, 1u);
							}
							else
							{
								void* ptr21 = null;
							}
							global::_003CModule_003E._CxxThrowException(null, null);
							goto end_IL_03ec;
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
						end_IL_03ec:;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
					}
				}
				m_nodeMapData.Add(parameterCollectionPathName, value);
				m_parameterCollection.AnnounceWrapper(parameterCollectionPathName, needsParentOpen: false);
				m_parameterCollection.Attach(parameterCollectionPathName, (INodeMap*)(int)((uint*)value.m_pNodeMapRef)[1]);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr22) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr22;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						Exception ex;
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex.Source = "GenICamFile";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr23) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr23;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						Exception ex2;
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex2.Source = "GenICamFile";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr24) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr24;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex3;
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex3.Source = "GenICamFile";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr25) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr25;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex4;
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex4.Source = "GenICamFile";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr26) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr26;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex5;
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex5.Source = "GenICamFile";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr27) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr27;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring13);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring13, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex6;
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring13);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring13);
						ex6.Source = "GenICamFile";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr28) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr28;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring14);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring14, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex7;
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring14);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring14);
						ex7.Source = "GenICamFile";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr29) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr29;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring15);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring15, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex8;
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring15);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring15);
						ex8.Source = "GenICamFile";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr30) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr30;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring16);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring16, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex9;
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring16);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring16);
						ex9.Source = "GenICamFile";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr31) != 0)
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						exception* intPtr10 = ptr31;
						Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "GenICamFile";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode2 = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num6 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						Exception ex12 = new Exception("Unknown exception");
						ex12.Source = "GenICamFile";
						throw ex12;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num6 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num6 != 0;
					}).Invoke())
					{
					}
					if (num6 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num6);
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

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021GenICamFileSet();
			return;
		}
		try
		{
			_0021GenICamFileSet();
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

	~GenICamFileSet()
	{
		Dispose(A_0: false);
	}
}

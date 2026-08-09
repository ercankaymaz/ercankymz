using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GenApi_3_1_Basler_pylon;
using GenICam_3_1_Basler_pylon;
using bclog;

namespace Basler.Pylon;

internal unsafe class GenApiNodeMapWrapper(string wrapperName, [MarshalAs(UnmanagedType.U1)] bool needsCameraOpen, ObjectState parentState) : IEnumValueAdvancedParameterAccessSource
{
	private string m_wrapperName = wrapperName;

	private Dictionary<string, GenApiParameter> m_touchedParameters = new Dictionary<string, GenApiParameter>();

	private unsafe INodeMap* m_pNodeMap = null;

	private ObjectState m_parentState = parentState;

	private bool m_needsCameraOpen = needsCameraOpen;

	public unsafe void Attach(INodeMap* pNodeMap)
	{
		uint num = 0u;
		Dictionary<string, GenApiParameter>.Enumerator enumerator = m_touchedParameters.GetEnumerator();
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
		while (enumerator.MoveNext())
		{
			ValueType valueType = enumerator.Current;
			try
			{
				if (!((KeyValuePair<string, GenApiParameter>)valueType).Value.Attach(pNodeMap) && pNodeMap != null)
				{
					string text = ((KeyValuePair<string, GenApiParameter>)valueType).ToString();
					global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &text);
					try
					{
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DA_0040FNFHBBJE_0040Attaching_003F5node_003F5to_003F5parameter_003F5fai_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring2) + 44)))((nint)(&gcstring2))));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				}
			}
			catch (Exception)
			{
				string text2 = ((KeyValuePair<string, GenApiParameter>)valueType).ToString();
				global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &text2);
				try
				{
					global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetParameterCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0CG_0040DIIHKGJP_0040Attaching_003F5node_003F5map_003F5failed_003F_0024CB_003F5kvp_003F3_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)(&gcstring3) + 44)))((nint)(&gcstring3))));
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
			}
		}
		m_pNodeMap = pNodeMap;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithUnknownTypeInNodeMap(string parameterName)
	{
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		if (m_touchedParameters.ContainsKey(parameterName))
		{
			return true;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		int num2;
		if (m_pNodeMap != null)
		{
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			try
			{
				num = 1u;
				INodeMap* pNodeMap = m_pNodeMap;
				if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr) != null)
				{
					num2 = 1;
					goto IL_008d;
				}
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
		try
		{
			num2 = 0;
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
		goto IL_008d;
		IL_008d:
		byte b;
		try
		{
			b = (byte)num2;
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
		return (b != 0) ? true : false;
	}

	public unsafe IParameter LookUpWithUnknownTypeInNodeMap(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null)
			{
				return ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr2 + 108)))((nint)ptr2) switch
				{
					(_EInterfaceType)6 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(parameterName), 
					(_EInterfaceType)3 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(parameterName), 
					(_EInterfaceType)2 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(parameterName), 
					(_EInterfaceType)5 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(parameterName), 
					(_EInterfaceType)4 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(parameterName), 
					(_EInterfaceType)9 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiEnumParameter_003E(parameterName), 
					(_EInterfaceType)11 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiPortParameter_003E(parameterName), 
					(_EInterfaceType)7 => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(parameterName), 
					_ => CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiParameter_003E(parameterName), 
				};
			}
		}
		return CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiParameter_003E(parameterName);
	}

	public string GetWrapperName()
	{
		return m_wrapperName;
	}

	public unsafe virtual void Save(string filename)
	{
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(filename, "filename");
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &filename);
		try
		{
			global::_003CModule_003E.Pylon_002ECFeaturePersistence_002ESave(ptr, m_pNodeMap);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
	}

	public unsafe virtual void Load(string filename)
	{
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(filename, "filename");
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &filename);
		try
		{
			global::_003CModule_003E.Pylon_002ECFeaturePersistence_002ELoad(ptr, m_pNodeMap, true);
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
	}

	public unsafe virtual void TriggerUpdate()
	{
		RaiseExceptionIfCameraNotOpen();
		INodeMap* pNodeMap = m_pNodeMap;
		if (pNodeMap != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)pNodeMap + 8)))((nint)pNodeMap);
		}
	}

	public unsafe virtual void Poll(long elapsedTime)
	{
		RaiseExceptionIfCameraNotOpen();
		INodeMap* pNodeMap = m_pNodeMap;
		if (pNodeMap != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, long, void>)(int)(*(uint*)(*(int*)pNodeMap + 24)))((nint)pNodeMap, elapsedTime);
		}
	}

	public unsafe virtual IEnumerable<string> GetParameterRelationFromNodeMap(string name, ParameterRelation relation, [MarshalAs(UnmanagedType.U1)] bool filterInternalParameters)
	{
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(name, "name");
		System.Runtime.CompilerServices.Unsafe.SkipInit(out CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
		List<string> list;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
		IEnumerable<string> result;
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &name);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null)
			{
				if (ParameterRelation.ParameterIsCategoryOf == relation)
				{
					IBase* ptr3 = (IBase*)((byte*)ptr2 + *(int*)(((int*)ptr2)[1] + 4) + 4);
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E, ptr3);
					try
					{
						if (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002E_N(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E))
						{
							list = new List<string>();
							System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector value_vector2);
							global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bctor_007D(&value_vector2);
							try
							{
								ICategory* ptr4 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
								((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector*, void>)(int)(*(uint*)(int)(*(uint*)ptr4)))((nint)ptr4, &value_vector2);
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.iterator iterator);
								int num2 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector2) + 40)))((nint)(&value_vector2), &iterator);
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.const_iterator const_iterator);
								// IL cpblk instruction
								System.Runtime.CompilerServices.Unsafe.CopyBlock(ref const_iterator, num2, 4);
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.iterator iterator2);
								if (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_0021_003D(&const_iterator, (value_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector2) + 52)))((nint)(&value_vector2), &iterator2)))
								{
									do
									{
										if (filterInternalParameters)
										{
											int num3 = *(int*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002A(&const_iterator);
											INode* intPtr = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, INode*>)(int)(*(uint*)(int)(*(uint*)num3)))((IntPtr)num3);
											if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)intPtr + 112)))((nint)intPtr) == 0)
											{
												goto IL_0126;
											}
										}
										int num4 = *(int*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002A(&const_iterator);
										list.Add(buildPath(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, INode*>)(int)(*(uint*)(int)(*(uint*)num4)))((IntPtr)num4)));
										goto IL_0126;
										IL_0126:
										global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002B_002B(&const_iterator);
									}
									while (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_0021_003D(&const_iterator, (value_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector2) + 52)))((nint)(&value_vector2), &iterator2)));
								}
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<value_vector*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bdtor_007D), &value_vector2);
								throw;
							}
							global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bdtor_007D(&value_vector2);
							goto IL_016e;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D), &cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
						throw;
					}
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
				}
				else if (ParameterRelation.ParameterIsSelectedBy == relation || ParameterRelation.ParameterSelects == relation)
				{
					IBase* ptr5 = (IBase*)((byte*)ptr2 + *(int*)(((int*)ptr2)[1] + 4) + 4);
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E, ptr5);
					try
					{
						if (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002E_N(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E))
						{
							List<string> list2 = new List<string>();
							System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector value_vector3);
							global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bctor_007D(&value_vector3);
							try
							{
								if (ParameterRelation.ParameterSelects == relation)
								{
									ISelector* ptr6 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
									((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector*, void>)(int)(*(uint*)(*(int*)ptr6 + 4)))((nint)ptr6, &value_vector3);
								}
								else
								{
									ISelector* ptr7 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
									((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector*, void>)(int)(*(uint*)(*(int*)ptr7 + 8)))((nint)ptr7, &value_vector3);
								}
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.iterator iterator3);
								int num5 = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector3) + 40)))((nint)(&value_vector3), &iterator3);
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.const_iterator const_iterator2);
								// IL cpblk instruction
								System.Runtime.CompilerServices.Unsafe.CopyBlock(ref const_iterator2, num5, 4);
								System.Runtime.CompilerServices.Unsafe.SkipInit(out value_vector.iterator iterator4);
								if (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_0021_003D(&const_iterator2, (value_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector3) + 52)))((nint)(&value_vector3), &iterator4)))
								{
									do
									{
										if (filterInternalParameters)
										{
											int num6 = *(int*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002A(&const_iterator2);
											INode* intPtr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, INode*>)(int)(*(uint*)(int)(*(uint*)num6)))((IntPtr)num6);
											if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)intPtr2 + 112)))((nint)intPtr2) == 0)
											{
												goto IL_0267;
											}
										}
										int num7 = *(int*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002A(&const_iterator2);
										list2.Add(buildPath(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, INode*>)(int)(*(uint*)(int)(*(uint*)num7)))((IntPtr)num7)));
										goto IL_0267;
										IL_0267:
										global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002B_002B(&const_iterator2);
									}
									while (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_0021_003D(&const_iterator2, (value_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, value_vector.iterator*, value_vector.iterator*>)(int)(*(uint*)(*(int*)(&value_vector3) + 52)))((nint)(&value_vector3), &iterator4)));
								}
								result = ((list2.Count <= 0) ? Enumerable.Empty<string>() : list2);
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<value_vector*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bdtor_007D), &value_vector3);
								throw;
							}
							global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bdtor_007D(&value_vector3);
							goto IL_02c2;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D), &cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
						throw;
					}
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
				}
				return Enumerable.Empty<string>();
			}
		}
		return Enumerable.Empty<string>();
		IL_016e:
		global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
		return list;
		IL_02c2:
		global::_003CModule_003E.GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(&cPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E);
		return result;
	}

	public static IEnumerable<string> GetNullRelation()
	{
		return Enumerable.Empty<string>();
	}

	public unsafe virtual void GetParameterPaths(List<string> list)
	{
		if (null == m_pNodeMap)
		{
			return;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out node_vector node_vector2);
		global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002E_007Bctor_007D(&node_vector2);
		try
		{
			INodeMap* pNodeMap = m_pNodeMap;
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, node_vector*, void>)(int)(*(uint*)(int)(*(uint*)pNodeMap)))((nint)pNodeMap, &node_vector2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out node_vector.iterator iterator);
			int num = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, node_vector.iterator*, node_vector.iterator*>)(int)(*(uint*)(*(int*)(&node_vector2) + 40)))((nint)(&node_vector2), &iterator);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out node_vector.const_iterator const_iterator);
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ref const_iterator, num, 4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out node_vector.iterator iterator2);
			if (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_0021_003D(&const_iterator, (node_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, node_vector.iterator*, node_vector.iterator*>)(int)(*(uint*)(*(int*)(&node_vector2) + 52)))((nint)(&node_vector2), &iterator2)))
			{
				do
				{
					INode* ptr = (INode*)(int)(*(uint*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002A(&const_iterator));
					int num2 = *(int*)global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002A(&const_iterator);
					if (((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte>)(int)(*(uint*)(*(int*)num2 + 112)))((IntPtr)num2) != 0)
					{
						_EInterfaceType eInterfaceType = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _EInterfaceType>)(int)(*(uint*)(*(int*)ptr + 108)))((nint)ptr);
						if (eInterfaceType == (_EInterfaceType)3 || eInterfaceType == (_EInterfaceType)6 || eInterfaceType == (_EInterfaceType)2 || eInterfaceType == (_EInterfaceType)4 || eInterfaceType == (_EInterfaceType)9 || eInterfaceType == (_EInterfaceType)5 || eInterfaceType == (_EInterfaceType)11 || eInterfaceType == (_EInterfaceType)7)
						{
							INode** ptr2 = global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002A(&const_iterator);
							list.Add(buildPath((INode*)(int)(*(uint*)ptr2)));
						}
					}
					global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002B_002B(&const_iterator);
				}
				while (global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_0021_003D(&const_iterator, (node_vector.const_iterator*)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, node_vector.iterator*, node_vector.iterator*>)(int)(*(uint*)(*(int*)(&node_vector2) + 52)))((nint)(&node_vector2), &iterator2)));
			}
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<node_vector*, void>)(&global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002E_007Bdtor_007D), &node_vector2);
			throw;
		}
		global::_003CModule_003E.GenApi_3_1_Basler_pylon_002Enode_vector_002E_007Bdtor_007D(&node_vector2);
	}

	public virtual IAdvancedParameterAccess GetAdvancedValueProperties(string enumName, string valueName)
	{
		return LookUpWithUnknownTypeInNodeMap("EnumEntry_" + enumName + "_" + valueName).Advanced;
	}

	public unsafe INodeMap* GetNodeMap()
	{
		return m_pNodeMap;
	}

	public object GetLock()
	{
		return m_parentState;
	}

	private void AddEnumValueAdvancedParameterAccessSource(GenApiEnumParameter p)
	{
		p.EnumValueAdvancedParameterAccessSource = this;
	}

	private void RaiseExceptionIfCameraNotOpen()
	{
		if (m_needsCameraOpen)
		{
			ObjectState parentState = m_parentState;
			if (parentState.m_state != EObjectState.Open)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(new InvalidOperationException($"Parameter under {m_wrapperName} can only be accessed when the camera is open."), parentState.m_name);
			}
		}
	}

	private void RaiseExceptionIfArgumentNull(string arg, string name)
	{
		if (null == arg)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentNullException(name), m_parentState.m_name);
		}
	}

	private void RaiseTypeMismatchException(string parameterName, string requestedType, string typeInNodeMap)
	{
		requestedType = GenApiParameter.GetParameterTypeDisplayname(requestedType);
		typeInNodeMap = GenApiParameter.GetParameterTypeDisplayname(typeInNodeMap);
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentException($"The type of parameter {parameterName} does not match the requested type. (Found: {typeInNodeMap}; Requested: {requestedType})", "name"), m_parentState.m_name);
	}

	private unsafe string buildPath(INode* A_0)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		int num = (int)((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, byte, gcstring*>)(int)(*(uint*)(int)(*(uint*)A_0)))((nint)A_0, &gcstring2, 0);
		string result;
		try
		{
			result = "@" + m_wrapperName + "/" + new string(global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_002EPBD((gcstring*)num));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return result;
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(GenApiStringParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(GenApiBooleanParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(GenApiIntegerParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(GenApiFloatParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(GenApiCommandParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiPortParameter_003E(GenApiPortParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(GenApiArrayParameter A_0)
	{
	}

	private void AddEnumValueAdvancedParameterAccessSource_003CBasler_003A_003APylon_003A_003AGenApiParameter_003E(GenApiParameter A_0)
	{
	}

	private unsafe GenApiStringParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(string parameterName)
	{
		GenApiStringParameter genApiStringParameter = new GenApiStringParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiStringParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiStringParameter);
			return genApiStringParameter;
		}
		return genApiStringParameter;
	}

	private unsafe GenApiBooleanParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(string parameterName)
	{
		GenApiBooleanParameter genApiBooleanParameter = new GenApiBooleanParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiBooleanParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiBooleanParameter);
			return genApiBooleanParameter;
		}
		return genApiBooleanParameter;
	}

	private unsafe GenApiIntegerParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(string parameterName)
	{
		GenApiIntegerParameter genApiIntegerParameter = new GenApiIntegerParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiIntegerParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiIntegerParameter);
			return genApiIntegerParameter;
		}
		return genApiIntegerParameter;
	}

	private unsafe GenApiFloatParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(string parameterName)
	{
		GenApiFloatParameter genApiFloatParameter = new GenApiFloatParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiFloatParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiFloatParameter);
			return genApiFloatParameter;
		}
		return genApiFloatParameter;
	}

	private unsafe GenApiCommandParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(string parameterName)
	{
		GenApiCommandParameter genApiCommandParameter = new GenApiCommandParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiCommandParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiCommandParameter);
			return genApiCommandParameter;
		}
		return genApiCommandParameter;
	}

	private unsafe GenApiEnumParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiEnumParameter_003E(string parameterName)
	{
		GenApiEnumParameter genApiEnumParameter = new GenApiEnumParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiEnumParameter.Attach(m_pNodeMap))
		{
			genApiEnumParameter.EnumValueAdvancedParameterAccessSource = this;
			m_touchedParameters.Add(parameterName, genApiEnumParameter);
			return genApiEnumParameter;
		}
		genApiEnumParameter.EnumValueAdvancedParameterAccessSource = this;
		return genApiEnumParameter;
	}

	private unsafe GenApiPortParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiPortParameter_003E(string parameterName)
	{
		GenApiPortParameter genApiPortParameter = new GenApiPortParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiPortParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiPortParameter);
			return genApiPortParameter;
		}
		return genApiPortParameter;
	}

	private unsafe GenApiArrayParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(string parameterName)
	{
		GenApiArrayParameter genApiArrayParameter = new GenApiArrayParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiArrayParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiArrayParameter);
			return genApiArrayParameter;
		}
		return genApiArrayParameter;
	}

	private unsafe GenApiParameter CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = new GenApiParameter(parameterName, m_wrapperName, m_parentState);
		if (genApiParameter.Attach(m_pNodeMap))
		{
			m_touchedParameters.Add(parameterName, genApiParameter);
			return genApiParameter;
		}
		return genApiParameter;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiIntegerParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIInteger_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiFloatParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIFloat_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiEnumParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiEnumParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIEnumeration_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiCommandParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUICommand_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiStringParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIString_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiBooleanParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIBoolean_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool ContainsWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		uint num = 0u;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			return genApiParameter is GenApiArrayParameter;
		}
		if (m_pNodeMap != null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
			gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &parameterName);
			INode* ptr2;
			try
			{
				INodeMap* pNodeMap = m_pNodeMap;
				ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, INode*>)(int)(*(uint*)(*(int*)pNodeMap + 4)))((nint)pNodeMap, ptr);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			if (ptr2 != null && global::_003CModule_003E.__RTDynamicCast(ptr2, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAUIRegister_0040GenApi_3_1_Basler_pylon_0040_0040_00408), 0) != null)
			{
				return true;
			}
		}
		return false;
	}

	public GenApiIntegerParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiIntegerParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiIntegerParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiIntegerParameter genApiIntegerParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiIntegerParameter_003E(parameterName);
		if (genApiIntegerParameter != null)
		{
			return genApiIntegerParameter;
		}
		return null;
	}

	public GenApiFloatParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiFloatParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiFloatParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiFloatParameter genApiFloatParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiFloatParameter_003E(parameterName);
		if (genApiFloatParameter != null)
		{
			return genApiFloatParameter;
		}
		return null;
	}

	public GenApiEnumParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiEnumParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiEnumParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiEnumParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiEnumParameter genApiEnumParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiEnumParameter_003E(parameterName);
		if (genApiEnumParameter != null)
		{
			return genApiEnumParameter;
		}
		return null;
	}

	public GenApiCommandParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiCommandParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiCommandParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiCommandParameter genApiCommandParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiCommandParameter_003E(parameterName);
		if (genApiCommandParameter != null)
		{
			return genApiCommandParameter;
		}
		return null;
	}

	public GenApiStringParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiStringParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiStringParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiStringParameter genApiStringParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiStringParameter_003E(parameterName);
		if (genApiStringParameter != null)
		{
			return genApiStringParameter;
		}
		return null;
	}

	public GenApiBooleanParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiBooleanParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiBooleanParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiBooleanParameter genApiBooleanParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiBooleanParameter_003E(parameterName);
		if (genApiBooleanParameter != null)
		{
			return genApiBooleanParameter;
		}
		return null;
	}

	public GenApiArrayParameter LookUpWithKnownTypeInNodeMap_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(string parameterName)
	{
		GenApiParameter genApiParameter = null;
		RaiseExceptionIfCameraNotOpen();
		RaiseExceptionIfArgumentNull(parameterName, "parameterName");
		genApiParameter = null;
		if (m_touchedParameters.TryGetValue(parameterName, out genApiParameter))
		{
			if (genApiParameter is GenApiArrayParameter result)
			{
				return result;
			}
			RaiseTypeMismatchException(parameterName, typeof(GenApiArrayParameter).Name, genApiParameter.GetType().Name);
		}
		GenApiArrayParameter genApiArrayParameter = CreateAndAddToListIfNoDummy_003CBasler_003A_003APylon_003A_003AGenApiArrayParameter_003E(parameterName);
		if (genApiArrayParameter != null)
		{
			return genApiArrayParameter;
		}
		return null;
	}
}

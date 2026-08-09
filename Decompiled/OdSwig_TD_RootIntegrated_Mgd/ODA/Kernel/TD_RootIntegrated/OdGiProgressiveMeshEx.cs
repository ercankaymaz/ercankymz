using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshEx : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_1();

	public delegate void SwigDelegateOdGiProgressiveMeshEx_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_3(IntPtr pts, IntPtr faces);

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_4(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_5(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_6(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_7();

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_8();

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_9(uint arg0);

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_10();

	public delegate uint SwigDelegateOdGiProgressiveMeshEx_11();

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_12();

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_13(IntPtr pBuff, IntPtr pConverter, int version);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_14(IntPtr pBuff, IntPtr pConverter);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_15(IntPtr pBuff);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_16();

	public delegate void SwigDelegateOdGiProgressiveMeshEx_17(int nPoints, IntPtr points, int faceListSize, int faces);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_18(IntPtr pVertexData, IntPtr pFaceData, EdgeData pEdgeData);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_19(IntPtr pVertexData, IntPtr pFaceData);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_20(IntPtr pVertexData);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_21();

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_22(IntPtr pBuff, IntPtr pConverter, int version);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_23(IntPtr pBuff, IntPtr pConverter);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_24(IntPtr pBuff);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_25(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter, int version);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_26(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter);

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_27(IntPtr pBuff, IntPtr pDataExtractor);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_28();

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_29();

	public delegate void SwigDelegateOdGiProgressiveMeshEx_30(IntPtr arg0);

	public delegate void SwigDelegateOdGiProgressiveMeshEx_31(byte flags);

	public delegate byte SwigDelegateOdGiProgressiveMeshEx_32();

	public delegate void SwigDelegateOdGiProgressiveMeshEx_33(IntPtr pMesh);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshEx_34();

	public delegate bool SwigDelegateOdGiProgressiveMeshEx_35();

	public delegate ulong SwigDelegateOdGiProgressiveMeshEx_36();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiProgressiveMeshEx_0 swigDelegate0;

	private SwigDelegateOdGiProgressiveMeshEx_1 swigDelegate1;

	private SwigDelegateOdGiProgressiveMeshEx_2 swigDelegate2;

	private SwigDelegateOdGiProgressiveMeshEx_3 swigDelegate3;

	private SwigDelegateOdGiProgressiveMeshEx_4 swigDelegate4;

	private SwigDelegateOdGiProgressiveMeshEx_5 swigDelegate5;

	private SwigDelegateOdGiProgressiveMeshEx_6 swigDelegate6;

	private SwigDelegateOdGiProgressiveMeshEx_7 swigDelegate7;

	private SwigDelegateOdGiProgressiveMeshEx_8 swigDelegate8;

	private SwigDelegateOdGiProgressiveMeshEx_9 swigDelegate9;

	private SwigDelegateOdGiProgressiveMeshEx_10 swigDelegate10;

	private SwigDelegateOdGiProgressiveMeshEx_11 swigDelegate11;

	private SwigDelegateOdGiProgressiveMeshEx_12 swigDelegate12;

	private SwigDelegateOdGiProgressiveMeshEx_13 swigDelegate13;

	private SwigDelegateOdGiProgressiveMeshEx_14 swigDelegate14;

	private SwigDelegateOdGiProgressiveMeshEx_15 swigDelegate15;

	private SwigDelegateOdGiProgressiveMeshEx_16 swigDelegate16;

	private SwigDelegateOdGiProgressiveMeshEx_17 swigDelegate17;

	private SwigDelegateOdGiProgressiveMeshEx_18 swigDelegate18;

	private SwigDelegateOdGiProgressiveMeshEx_19 swigDelegate19;

	private SwigDelegateOdGiProgressiveMeshEx_20 swigDelegate20;

	private SwigDelegateOdGiProgressiveMeshEx_21 swigDelegate21;

	private SwigDelegateOdGiProgressiveMeshEx_22 swigDelegate22;

	private SwigDelegateOdGiProgressiveMeshEx_23 swigDelegate23;

	private SwigDelegateOdGiProgressiveMeshEx_24 swigDelegate24;

	private SwigDelegateOdGiProgressiveMeshEx_25 swigDelegate25;

	private SwigDelegateOdGiProgressiveMeshEx_26 swigDelegate26;

	private SwigDelegateOdGiProgressiveMeshEx_27 swigDelegate27;

	private SwigDelegateOdGiProgressiveMeshEx_28 swigDelegate28;

	private SwigDelegateOdGiProgressiveMeshEx_29 swigDelegate29;

	private SwigDelegateOdGiProgressiveMeshEx_30 swigDelegate30;

	private SwigDelegateOdGiProgressiveMeshEx_31 swigDelegate31;

	private SwigDelegateOdGiProgressiveMeshEx_32 swigDelegate32;

	private SwigDelegateOdGiProgressiveMeshEx_33 swigDelegate33;

	private SwigDelegateOdGiProgressiveMeshEx_34 swigDelegate34;

	private SwigDelegateOdGiProgressiveMeshEx_35 swigDelegate35;

	private SwigDelegateOdGiProgressiveMeshEx_36 swigDelegate36;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager),
		typeof(OdVectorOdInt32)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiProgressiveMeshVertexData),
		typeof(uint)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiProgressiveMeshFaceData),
		typeof(uint)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiProgressiveMeshEdgeData),
		typeof(uint)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[4]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(OdGiVertexData),
		typeof(OdGiFaceData),
		typeof(EdgeData)
	};

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdGiVertexData),
		typeof(OdGiFaceData)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdGiVertexData) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes25 = new Type[4]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes26 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor)
	};

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdGiProgressiveMeshGeneratorOptions) };

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdGiProgressiveMesh) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshEx(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshEx obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshEx(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiProgressiveMeshEx cast(OdRxObject pObj)
	{
		OdGiProgressiveMeshEx rXObject = Helpers.GetRXObject<OdGiProgressiveMeshEx>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_isASwigExplicitOdGiProgressiveMeshEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_queryXSwigExplicitOdGiProgressiveMeshEx(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiProgressiveMeshEx createObject()
	{
		OdGiProgressiveMeshEx rXObject = Helpers.GetRXObject<OdGiProgressiveMeshEx>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool obtainShell(OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager pts, OdVectorOdInt32 faces)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_obtainShell(swigCPtr, OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager.getCPtr(pts), OdVectorOdInt32.getCPtr(faces));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainVertexData(OdGiProgressiveMeshVertexData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_obtainVertexData(swigCPtr, OdGiProgressiveMeshVertexData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainFaceData(OdGiProgressiveMeshFaceData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_obtainFaceData(swigCPtr, OdGiProgressiveMeshFaceData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainEdgeData(OdGiProgressiveMeshEdgeData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_obtainEdgeData(swigCPtr, OdGiProgressiveMeshEdgeData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numLODs()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_numLODs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint currentLOD()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_currentLOD(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setLOD(uint arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_setLOD(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numFaces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_numFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numVertices()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_numVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d extents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_extents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_write__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_write__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_write__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isProgressiveMeshGenerated()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_isProgressiveMeshGenerated(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setupInitialShell(int nPoints, OdGePoint3d points, int faceListSize, int faces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_setupInitialShell(swigCPtr, nPoints, OdGePoint3d.getCPtr(points), faceListSize, faces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool buildProgressiveMesh(OdGiVertexData pVertexData, OdGiFaceData pFaceData, EdgeData pEdgeData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_buildProgressiveMesh__SWIG_0(swigCPtr, OdGiVertexData.getCPtr(pVertexData), OdGiFaceData.getCPtr(pFaceData), pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool buildProgressiveMesh(OdGiVertexData pVertexData, OdGiFaceData pFaceData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_buildProgressiveMesh__SWIG_1(swigCPtr, OdGiVertexData.getCPtr(pVertexData), OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool buildProgressiveMesh(OdGiVertexData pVertexData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_buildProgressiveMesh__SWIG_2(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool buildProgressiveMesh()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_buildProgressiveMesh__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readProgressiveMeshExFrom(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readProgressiveMeshExFrom__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readProgressiveMeshExFrom(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readProgressiveMeshExFrom__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readProgressiveMeshExFrom(OdStreamBuf pBuff)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readProgressiveMeshExFrom__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readPartialProgressiveMeshExFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readPartialProgressiveMeshExFrom__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readPartialProgressiveMeshExFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readPartialProgressiveMeshExFrom__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readPartialProgressiveMeshExFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_readPartialProgressiveMeshExFrom__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiProgressiveMeshGeneratorOptions options()
	{
		OdGiProgressiveMeshGeneratorOptions result = new OdGiProgressiveMeshGeneratorOptions(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_options__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOptions(OdGiProgressiveMeshGeneratorOptions arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_setOptions(swigCPtr, OdGiProgressiveMeshGeneratorOptions.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGenerationAbortFlags(byte flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_setGenerationAbortFlags(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte generationAbortFlags()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_generationAbortFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProgressiveMesh(OdGiProgressiveMesh pMesh)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_setProgressiveMesh(swigCPtr, OdGiProgressiveMesh.getCPtr(pMesh));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiProgressiveMesh progressiveMesh()
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_progressiveMesh(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong getObjectSize()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_getObjectSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiProgressiveMeshEx()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshEx(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProgressiveMeshEx) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("obtainShell", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodobtainShell;
		}
		if (SwigDerivedClassHasMethod("obtainVertexData", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodobtainVertexData;
		}
		if (SwigDerivedClassHasMethod("obtainFaceData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodobtainFaceData;
		}
		if (SwigDerivedClassHasMethod("obtainEdgeData", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodobtainEdgeData;
		}
		if (SwigDerivedClassHasMethod("numLODs", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodnumLODs;
		}
		if (SwigDerivedClassHasMethod("currentLOD", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcurrentLOD;
		}
		if (SwigDerivedClassHasMethod("setLOD", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetLOD;
		}
		if (SwigDerivedClassHasMethod("numFaces", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodnumFaces;
		}
		if (SwigDerivedClassHasMethod("numVertices", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodnumVertices;
		}
		if (SwigDerivedClassHasMethod("extents", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodextents;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodwrite__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodwrite__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodwrite__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("isProgressiveMeshGenerated", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisProgressiveMeshGenerated;
		}
		if (SwigDerivedClassHasMethod("setupInitialShell", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetupInitialShell;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodbuildProgressiveMesh__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodbuildProgressiveMesh__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodbuildProgressiveMesh__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodbuildProgressiveMesh__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("readProgressiveMeshExFrom", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readProgressiveMeshExFrom", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readProgressiveMeshExFrom", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readPartialProgressiveMeshExFrom", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readPartialProgressiveMeshExFrom", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readPartialProgressiveMeshExFrom", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("options", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodoptions__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("options", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodoptions__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setOptions", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodsetOptions;
		}
		if (SwigDerivedClassHasMethod("setGenerationAbortFlags", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodsetGenerationAbortFlags;
		}
		if (SwigDerivedClassHasMethod("generationAbortFlags", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgenerationAbortFlags;
		}
		if (SwigDerivedClassHasMethod("setProgressiveMesh", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetProgressiveMesh;
		}
		if (SwigDerivedClassHasMethod("progressiveMesh", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodprogressiveMesh;
		}
		if (SwigDerivedClassHasMethod("hasData", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodhasData;
		}
		if (SwigDerivedClassHasMethod("getObjectSize", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetObjectSize;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshEx_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProgressiveMeshEx));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodobtainShell(IntPtr pts, IntPtr faces)
	{
		return obtainShell(new OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager(pts, cMemoryOwn: false), new OdVectorOdInt32(faces, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodobtainVertexData(IntPtr data, uint flags)
	{
		return obtainVertexData(new OdGiProgressiveMeshVertexData(data, cMemoryOwn: false), flags);
	}

	private uint SwigDirectorMethodobtainFaceData(IntPtr data, uint flags)
	{
		return obtainFaceData(new OdGiProgressiveMeshFaceData(data, cMemoryOwn: false), flags);
	}

	private uint SwigDirectorMethodobtainEdgeData(IntPtr data, uint flags)
	{
		return obtainEdgeData(new OdGiProgressiveMeshEdgeData(data, cMemoryOwn: false), flags);
	}

	private uint SwigDirectorMethodnumLODs()
	{
		return numLODs();
	}

	private uint SwigDirectorMethodcurrentLOD()
	{
		return currentLOD();
	}

	private bool SwigDirectorMethodsetLOD(uint arg0)
	{
		return setLOD(arg0);
	}

	private uint SwigDirectorMethodnumFaces()
	{
		return numFaces();
	}

	private uint SwigDirectorMethodnumVertices()
	{
		return numVertices();
	}

	private IntPtr SwigDirectorMethodextents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(extents()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodwrite__SWIG_0(IntPtr pBuff, IntPtr pConverter, int version)
	{
		return write(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false), (OdGiProgressiveMesh_ProgressiveMeshStreamVersion)version);
	}

	private bool SwigDirectorMethodwrite__SWIG_1(IntPtr pBuff, IntPtr pConverter)
	{
		return write(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodwrite__SWIG_2(IntPtr pBuff)
	{
		return write(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisProgressiveMeshGenerated()
	{
		return isProgressiveMeshGenerated();
	}

	private void SwigDirectorMethodsetupInitialShell(int nPoints, IntPtr points, int faceListSize, int faces)
	{
		try
		{
			setupInitialShell(nPoints, (points == IntPtr.Zero) ? null : new OdGePoint3d(points, cMemoryOwn: false), faceListSize, faces);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodbuildProgressiveMesh__SWIG_0(IntPtr pVertexData, IntPtr pFaceData, EdgeData pEdgeData)
	{
		return buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false), (pFaceData == IntPtr.Zero) ? null : new OdGiFaceData(pFaceData, cMemoryOwn: false), pEdgeData);
	}

	private bool SwigDirectorMethodbuildProgressiveMesh__SWIG_1(IntPtr pVertexData, IntPtr pFaceData)
	{
		return buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false), (pFaceData == IntPtr.Zero) ? null : new OdGiFaceData(pFaceData, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodbuildProgressiveMesh__SWIG_2(IntPtr pVertexData)
	{
		return buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodbuildProgressiveMesh__SWIG_3()
	{
		return buildProgressiveMesh();
	}

	private bool SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_0(IntPtr pBuff, IntPtr pConverter, int version)
	{
		return readProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false), (OdGiProgressiveMesh_ProgressiveMeshStreamVersion)version);
	}

	private bool SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_1(IntPtr pBuff, IntPtr pConverter)
	{
		return readProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodreadProgressiveMeshExFrom__SWIG_2(IntPtr pBuff)
	{
		return readProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_0(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter, int version)
	{
		return readPartialProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false), (OdGiProgressiveMesh_ProgressiveMeshStreamVersion)version);
	}

	private bool SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_1(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter)
	{
		return readPartialProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodreadPartialProgressiveMeshExFrom__SWIG_2(IntPtr pBuff, IntPtr pDataExtractor)
	{
		return readPartialProgressiveMeshExFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodoptions__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshGeneratorOptions.getCPtr(options()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodoptions__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshGeneratorOptions.getCPtr(options()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetOptions(IntPtr arg0)
	{
		try
		{
			setOptions(new OdGiProgressiveMeshGeneratorOptions(arg0, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGenerationAbortFlags(byte flags)
	{
		try
		{
			setGenerationAbortFlags(flags);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private byte SwigDirectorMethodgenerationAbortFlags()
	{
		return generationAbortFlags();
	}

	private void SwigDirectorMethodsetProgressiveMesh(IntPtr pMesh)
	{
		try
		{
			setProgressiveMesh(Helpers.GetRXObject<OdGiProgressiveMesh>(pMesh, bOwn: true, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodprogressiveMesh()
	{
		return OdGiProgressiveMesh.getCPtr(progressiveMesh()).Handle;
	}

	private bool SwigDirectorMethodhasData()
	{
		return hasData();
	}

	private ulong SwigDirectorMethodgetObjectSize()
	{
		return getObjectSize();
	}
}

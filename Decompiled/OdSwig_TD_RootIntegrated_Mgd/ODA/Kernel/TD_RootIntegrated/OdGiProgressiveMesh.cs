using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMesh : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_1();

	public delegate void SwigDelegateOdGiProgressiveMesh_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiProgressiveMesh_3(IntPtr pts, IntPtr faces);

	public delegate uint SwigDelegateOdGiProgressiveMesh_4(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMesh_5(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMesh_6(IntPtr data, uint flags);

	public delegate uint SwigDelegateOdGiProgressiveMesh_7();

	public delegate uint SwigDelegateOdGiProgressiveMesh_8();

	public delegate bool SwigDelegateOdGiProgressiveMesh_9(uint arg0);

	public delegate uint SwigDelegateOdGiProgressiveMesh_10(int lod, IntPtr pView, IntPtr pModelToWorldTransform);

	public delegate uint SwigDelegateOdGiProgressiveMesh_11(int lod, IntPtr pView);

	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_12();

	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_13();

	public delegate void SwigDelegateOdGiProgressiveMesh_14(IntPtr options);

	public delegate void SwigDelegateOdGiProgressiveMesh_15(IntPtr pCallback);

	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_16();

	public delegate uint SwigDelegateOdGiProgressiveMesh_17();

	public delegate uint SwigDelegateOdGiProgressiveMesh_18();

	public delegate IntPtr SwigDelegateOdGiProgressiveMesh_19();

	public delegate bool SwigDelegateOdGiProgressiveMesh_20(IntPtr pBuff, IntPtr pConverter, int version);

	public delegate bool SwigDelegateOdGiProgressiveMesh_21(IntPtr pBuff, IntPtr pConverter);

	public delegate bool SwigDelegateOdGiProgressiveMesh_22(IntPtr pBuff);

	public delegate bool SwigDelegateOdGiProgressiveMesh_23();

	public delegate void SwigDelegateOdGiProgressiveMesh_24();

	public delegate ulong SwigDelegateOdGiProgressiveMesh_25();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiProgressiveMesh_0 swigDelegate0;

	private SwigDelegateOdGiProgressiveMesh_1 swigDelegate1;

	private SwigDelegateOdGiProgressiveMesh_2 swigDelegate2;

	private SwigDelegateOdGiProgressiveMesh_3 swigDelegate3;

	private SwigDelegateOdGiProgressiveMesh_4 swigDelegate4;

	private SwigDelegateOdGiProgressiveMesh_5 swigDelegate5;

	private SwigDelegateOdGiProgressiveMesh_6 swigDelegate6;

	private SwigDelegateOdGiProgressiveMesh_7 swigDelegate7;

	private SwigDelegateOdGiProgressiveMesh_8 swigDelegate8;

	private SwigDelegateOdGiProgressiveMesh_9 swigDelegate9;

	private SwigDelegateOdGiProgressiveMesh_10 swigDelegate10;

	private SwigDelegateOdGiProgressiveMesh_11 swigDelegate11;

	private SwigDelegateOdGiProgressiveMesh_12 swigDelegate12;

	private SwigDelegateOdGiProgressiveMesh_13 swigDelegate13;

	private SwigDelegateOdGiProgressiveMesh_14 swigDelegate14;

	private SwigDelegateOdGiProgressiveMesh_15 swigDelegate15;

	private SwigDelegateOdGiProgressiveMesh_16 swigDelegate16;

	private SwigDelegateOdGiProgressiveMesh_17 swigDelegate17;

	private SwigDelegateOdGiProgressiveMesh_18 swigDelegate18;

	private SwigDelegateOdGiProgressiveMesh_19 swigDelegate19;

	private SwigDelegateOdGiProgressiveMesh_20 swigDelegate20;

	private SwigDelegateOdGiProgressiveMesh_21 swigDelegate21;

	private SwigDelegateOdGiProgressiveMesh_22 swigDelegate22;

	private SwigDelegateOdGiProgressiveMesh_23 swigDelegate23;

	private SwigDelegateOdGiProgressiveMesh_24 swigDelegate24;

	private SwigDelegateOdGiProgressiveMesh_25 swigDelegate25;

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

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD),
		typeof(OdGiViewport),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD),
		typeof(OdGiViewport)
	};

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGiProgressiveMeshAutoLODSelectOptions) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGiProgressiveMeshAutoLODSelectCallback) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMesh(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMesh obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMesh(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiProgressiveMesh cast(OdRxObject pObj)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_isASwigExplicitOdGiProgressiveMesh(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_queryXSwigExplicitOdGiProgressiveMesh(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiProgressiveMesh createObject()
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool obtainShell(OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager pts, OdVectorOdInt32 faces)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_obtainShell(swigCPtr, OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager.getCPtr(pts), OdVectorOdInt32.getCPtr(faces));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainVertexData(OdGiProgressiveMeshVertexData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_obtainVertexData(swigCPtr, OdGiProgressiveMeshVertexData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainFaceData(OdGiProgressiveMeshFaceData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_obtainFaceData(swigCPtr, OdGiProgressiveMeshFaceData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint obtainEdgeData(OdGiProgressiveMeshEdgeData data, uint flags)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_obtainEdgeData(swigCPtr, OdGiProgressiveMeshEdgeData.getCPtr(data), flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numLODs()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_numLODs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint currentLOD()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_currentLOD(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setLOD(uint arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_setLOD(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint selectLOD(OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD lod, OdGiViewport pView, OdGeMatrix3d pModelToWorldTransform)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_selectLOD__SWIG_0(swigCPtr, (int)lod, OdGiViewport.getCPtr(pView), OdGeMatrix3d.getCPtr(pModelToWorldTransform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint selectLOD(OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD lod, OdGiViewport pView)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_selectLOD__SWIG_1(swigCPtr, (int)lod, OdGiViewport.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiProgressiveMeshAutoLODSelectOptions autoSelectLODOptions()
	{
		OdGiProgressiveMeshAutoLODSelectOptions result = new OdGiProgressiveMeshAutoLODSelectOptions(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_autoSelectLODOptions__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAutoSelectLODOptions(OdGiProgressiveMeshAutoLODSelectOptions options)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_setAutoSelectLODOptions(swigCPtr, OdGiProgressiveMeshAutoLODSelectOptions.getCPtr(options));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCustomLODAutoSelectCallback(OdGiProgressiveMeshAutoLODSelectCallback pCallback)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_setCustomLODAutoSelectCallback(swigCPtr, OdGiProgressiveMeshAutoLODSelectCallback.getCPtr(pCallback));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiProgressiveMeshAutoLODSelectCallback getCustomLODAutoSelectCallback()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_getCustomLODAutoSelectCallback(swigCPtr);
		OdGiProgressiveMeshAutoLODSelectCallback result = ((intPtr == IntPtr.Zero) ? null : new OdGiProgressiveMeshAutoLODSelectCallback(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numFaces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_numFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numVertices()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_numVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d extents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_extents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_write__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_write__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool write(OdStreamBuf pBuff)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_write__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isInPartialMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_isInPartialMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void endPartialMode()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_endPartialMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong getObjectSize()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_getObjectSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiProgressiveMesh()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMesh(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProgressiveMesh) != GetType();
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
		if (SwigDerivedClassHasMethod("selectLOD", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodselectLOD__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("selectLOD", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodselectLOD__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("autoSelectLODOptions", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodautoSelectLODOptions__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("autoSelectLODOptions", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodautoSelectLODOptions__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setAutoSelectLODOptions", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetAutoSelectLODOptions;
		}
		if (SwigDerivedClassHasMethod("setCustomLODAutoSelectCallback", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetCustomLODAutoSelectCallback;
		}
		if (SwigDerivedClassHasMethod("getCustomLODAutoSelectCallback", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetCustomLODAutoSelectCallback;
		}
		if (SwigDerivedClassHasMethod("numFaces", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodnumFaces;
		}
		if (SwigDerivedClassHasMethod("numVertices", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodnumVertices;
		}
		if (SwigDerivedClassHasMethod("extents", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodextents;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodwrite__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodwrite__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodwrite__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("isInPartialMode", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodisInPartialMode;
		}
		if (SwigDerivedClassHasMethod("endPartialMode", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodendPartialMode;
		}
		if (SwigDerivedClassHasMethod("getObjectSize", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetObjectSize;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMesh_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProgressiveMesh));
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

	private uint SwigDirectorMethodselectLOD__SWIG_0(int lod, IntPtr pView, IntPtr pModelToWorldTransform)
	{
		return selectLOD((OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD)lod, Helpers.GetRXObject<OdGiViewport>(pView, bOwn: false, bTryAddToTransaction: false), (pModelToWorldTransform == IntPtr.Zero) ? null : new OdGeMatrix3d(pModelToWorldTransform, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodselectLOD__SWIG_1(int lod, IntPtr pView)
	{
		return selectLOD((OdGiProgressiveMesh_ProgressiveMeshAutoSelectLOD)lod, Helpers.GetRXObject<OdGiViewport>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodautoSelectLODOptions__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshAutoLODSelectOptions.getCPtr(autoSelectLODOptions()).Handle;
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

	private IntPtr SwigDirectorMethodautoSelectLODOptions__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshAutoLODSelectOptions.getCPtr(autoSelectLODOptions()).Handle;
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

	private void SwigDirectorMethodsetAutoSelectLODOptions(IntPtr options)
	{
		try
		{
			setAutoSelectLODOptions(new OdGiProgressiveMeshAutoLODSelectOptions(options, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetCustomLODAutoSelectCallback(IntPtr pCallback)
	{
		try
		{
			setCustomLODAutoSelectCallback((pCallback == IntPtr.Zero) ? null : new OdGiProgressiveMeshAutoLODSelectCallback(pCallback, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetCustomLODAutoSelectCallback()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshAutoLODSelectCallback.getCPtr(getCustomLODAutoSelectCallback()).Handle;
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

	private bool SwigDirectorMethodisInPartialMode()
	{
		return isInPartialMode();
	}

	private void SwigDirectorMethodendPartialMode()
	{
		try
		{
			endPartialMode();
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

	private ulong SwigDirectorMethodgetObjectSize()
	{
		return getObjectSize();
	}
}

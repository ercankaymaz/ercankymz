using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPointRef : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbPointRef_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPointRef_1();

	public delegate void SwigDelegateOdDbPointRef_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPointRef_3(IntPtr pnt_wcs);

	public delegate int SwigDelegateOdDbPointRef_4(IntPtr ents, bool getLastPtRef);

	public delegate int SwigDelegateOdDbPointRef_5(IntPtr ents);

	public delegate bool SwigDelegateOdDbPointRef_6();

	public delegate bool SwigDelegateOdDbPointRef_7(IntPtr ids1, IntPtr ids2, bool isMainObj);

	public delegate bool SwigDelegateOdDbPointRef_8(IntPtr ids1, IntPtr ids2);

	public delegate int SwigDelegateOdDbPointRef_9();

	public delegate int SwigDelegateOdDbPointRef_10(IntPtr idMap);

	public delegate void SwigDelegateOdDbPointRef_11(IntPtr filer);

	public delegate void SwigDelegateOdDbPointRef_12(IntPtr filer);

	public delegate void SwigDelegateOdDbPointRef_13(IntPtr filer);

	public delegate int SwigDelegateOdDbPointRef_14(IntPtr filer);

	public delegate void SwigDelegateOdDbPointRef_15(bool inMirror);

	public delegate void SwigDelegateOdDbPointRef_16();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPointRef_0 swigDelegate0;

	private SwigDelegateOdDbPointRef_1 swigDelegate1;

	private SwigDelegateOdDbPointRef_2 swigDelegate2;

	private SwigDelegateOdDbPointRef_3 swigDelegate3;

	private SwigDelegateOdDbPointRef_4 swigDelegate4;

	private SwigDelegateOdDbPointRef_5 swigDelegate5;

	private SwigDelegateOdDbPointRef_6 swigDelegate6;

	private SwigDelegateOdDbPointRef_7 swigDelegate7;

	private SwigDelegateOdDbPointRef_8 swigDelegate8;

	private SwigDelegateOdDbPointRef_9 swigDelegate9;

	private SwigDelegateOdDbPointRef_10 swigDelegate10;

	private SwigDelegateOdDbPointRef_11 swigDelegate11;

	private SwigDelegateOdDbPointRef_12 swigDelegate12;

	private SwigDelegateOdDbPointRef_13 swigDelegate13;

	private SwigDelegateOdDbPointRef_14 swigDelegate14;

	private SwigDelegateOdDbPointRef_15 swigDelegate15;

	private SwigDelegateOdDbPointRef_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectIdArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbIdMapping).MakeByRefType() };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes16 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPointRef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPointRef obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPointRef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbPointRef cast(OdRxObject pObj)
	{
		OdDbPointRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPointRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_isASwigExplicitOdDbPointRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_queryXSwigExplicitOdDbPointRef(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbPointRef createObject()
	{
		OdDbPointRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPointRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult evalPoint(OdGePoint3d pnt_wcs)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_evalPoint(swigCPtr, OdGePoint3d.getCPtr(pnt_wcs));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getEntities(OdDbFullSubentPathArray ents, bool getLastPtRef)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_getEntities__SWIG_0(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents), getLastPtRef);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getEntities(OdDbFullSubentPathArray ents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_getEntities__SWIG_1(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isGeomErased()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_isGeomErased(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isXrefObj(OdDbObjectIdArray ids1, OdDbObjectIdArray ids2, bool isMainObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_isXrefObj__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2), isMainObj);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isXrefObj(OdDbObjectIdArray ids1, OdDbObjectIdArray ids2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_isXrefObj__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult updateXrefSubentPath()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_updateXrefSubentPath(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult updateSubentPath(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_updateSubentPath(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void dwgOutFields(OdDbDwgFiler filer)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(filer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dwgInFields(OdDbDwgFiler filer)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(filer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dxfOutFields(OdDbDxfFiler filer)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(filer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult dxfInFields(OdDbDxfFiler filer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(filer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void updateDueToMirror(bool inMirror)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_updateDueToMirror__SWIG_0(swigCPtr, inMirror);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateDueToMirror()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_updateDueToMirror__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool calcTransform(OdDbObjectIdArray ids, OdGeMatrix3d A_Ecs2Wcs)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_calcTransform(OdDbObjectIdArray.getCPtr(ids), OdGeMatrix3d.getCPtr(A_Ecs2Wcs));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d mswcsToPswcs(OdDbViewport pVPort)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_mswcsToPswcs(OdDbViewport.getCPtr(pVPort)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbPointRef()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPointRef(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbPointRef) != GetType();
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
		if (SwigDerivedClassHasMethod("evalPoint", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodevalPoint;
		}
		if (SwigDerivedClassHasMethod("getEntities", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetEntities__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getEntities", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetEntities__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isGeomErased", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisGeomErased;
		}
		if (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisXrefObj__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisXrefObj__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("updateXrefSubentPath", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupdateXrefSubentPath;
		}
		if (SwigDerivedClassHasMethod("updateSubentPath", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodupdateSubentPath;
		}
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethoddwgOutFields;
		}
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddwgInFields;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoddxfOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethoddxfInFields;
		}
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodupdateDueToMirror__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodupdateDueToMirror__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPointRef_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPointRef));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodevalPoint(IntPtr pnt_wcs)
	{
		return (int)evalPoint(new OdGePoint3d(pnt_wcs, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetEntities__SWIG_0(IntPtr ents, bool getLastPtRef)
	{
		return (int)getEntities(new OdDbFullSubentPathArray(ents, cMemoryOwn: false), getLastPtRef);
	}

	private int SwigDirectorMethodgetEntities__SWIG_1(IntPtr ents)
	{
		return (int)getEntities(new OdDbFullSubentPathArray(ents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisGeomErased()
	{
		return isGeomErased();
	}

	private bool SwigDirectorMethodisXrefObj__SWIG_0(IntPtr ids1, IntPtr ids2, bool isMainObj)
	{
		return isXrefObj(new OdDbObjectIdArray(ids1, cMemoryOwn: false), new OdDbObjectIdArray(ids2, cMemoryOwn: false), isMainObj);
	}

	private bool SwigDirectorMethodisXrefObj__SWIG_1(IntPtr ids1, IntPtr ids2)
	{
		return isXrefObj(new OdDbObjectIdArray(ids1, cMemoryOwn: false), new OdDbObjectIdArray(ids2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodupdateXrefSubentPath()
	{
		return (int)updateXrefSubentPath();
	}

	private int SwigDirectorMethodupdateSubentPath(IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)updateSubentPath(ref idMap2);
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethoddwgOutFields(IntPtr filer)
	{
		try
		{
			dwgOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(filer, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddwgInFields(IntPtr filer)
	{
		try
		{
			dwgInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(filer, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddxfOutFields(IntPtr filer)
	{
		try
		{
			dxfOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(filer, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethoddxfInFields(IntPtr filer)
	{
		return (int)dxfInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(filer, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodupdateDueToMirror__SWIG_0(bool inMirror)
	{
		try
		{
			updateDueToMirror(inMirror);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodupdateDueToMirror__SWIG_1()
	{
		try
		{
			updateDueToMirror();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

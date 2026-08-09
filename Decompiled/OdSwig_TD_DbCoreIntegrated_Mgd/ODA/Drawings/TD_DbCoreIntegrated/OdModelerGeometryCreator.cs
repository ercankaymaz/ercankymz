using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdModelerGeometryCreator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdModelerGeometryCreator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdModelerGeometryCreator_1();

	public delegate void SwigDelegateOdModelerGeometryCreator_2(IntPtr pSource);

	public delegate int SwigDelegateOdModelerGeometryCreator_3(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit, int convAcisColors);

	public delegate int SwigDelegateOdModelerGeometryCreator_4(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit);

	public delegate int SwigDelegateOdModelerGeometryCreator_5(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag);

	public delegate int SwigDelegateOdModelerGeometryCreator_6(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo);

	public delegate int SwigDelegateOdModelerGeometryCreator_7(IntPtr models, IntPtr pStreamBuf);

	public delegate int SwigDelegateOdModelerGeometryCreator_8(IntPtr models, IntPtr pStreamBuf, int typeVer, bool standardSaveFlag);

	public delegate int SwigDelegateOdModelerGeometryCreator_9(IntPtr models, IntPtr pStreamBuf, int typeVer);

	public delegate int SwigDelegateOdModelerGeometryCreator_10(IntPtr entities, IntPtr pStreamBuf, int typeVer, bool standardSaveFlag);

	public delegate int SwigDelegateOdModelerGeometryCreator_11(IntPtr entities, IntPtr pStreamBuf, int typeVer);

	public delegate int SwigDelegateOdModelerGeometryCreator_12(IntPtr curveSegments, IntPtr pRegions);

	public delegate int SwigDelegateOdModelerGeometryCreator_13(IntPtr brepBuilder, int brepType);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdModelerGeometryCreator_0 swigDelegate0;

	private SwigDelegateOdModelerGeometryCreator_1 swigDelegate1;

	private SwigDelegateOdModelerGeometryCreator_2 swigDelegate2;

	private SwigDelegateOdModelerGeometryCreator_3 swigDelegate3;

	private SwigDelegateOdModelerGeometryCreator_4 swigDelegate4;

	private SwigDelegateOdModelerGeometryCreator_5 swigDelegate5;

	private SwigDelegateOdModelerGeometryCreator_6 swigDelegate6;

	private SwigDelegateOdModelerGeometryCreator_7 swigDelegate7;

	private SwigDelegateOdModelerGeometryCreator_8 swigDelegate8;

	private SwigDelegateOdModelerGeometryCreator_9 swigDelegate9;

	private SwigDelegateOdModelerGeometryCreator_10 swigDelegate10;

	private SwigDelegateOdModelerGeometryCreator_11 swigDelegate11;

	private SwigDelegateOdModelerGeometryCreator_12 swigDelegate12;

	private SwigDelegateOdModelerGeometryCreator_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[6]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo),
		typeof(bool),
		typeof(bool),
		typeof(ColorConversionType)
	};

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(OdDbAuditInfo)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf)
	};

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdModelerGeometryPtrArray),
		typeof(OdStreamBuf),
		typeof(int)
	};

	private static Type[] swigMethodTypes10 = new Type[4]
	{
		typeof(OdDbEntityPtrArray),
		typeof(OdStreamBuf),
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes11 = new Type[3]
	{
		typeof(OdDbEntityPtrArray),
		typeof(OdStreamBuf),
		typeof(int)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdRxObjectPtrArray),
		typeof(OdModelerGeometryPtrArray)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdBrepBuilder),
		typeof(BrepType)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdModelerGeometryCreator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdModelerGeometryCreator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdModelerGeometryCreator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdModelerGeometryCreator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdModelerGeometryCreator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdModelerGeometryCreator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdModelerGeometryCreator cast(OdRxObject pObj)
	{
		OdModelerGeometryCreator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometryCreator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_isASwigExplicitOdModelerGeometryCreator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_queryXSwigExplicitOdModelerGeometryCreator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdModelerGeometryCreator createObject()
	{
		OdModelerGeometryCreator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometryCreator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult createModeler(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit, ColorConversionType convAcisColors)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createModeler__SWIG_0(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo), standardSaveFlag, bEnableACISAudit, (int)convAcisColors);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createModeler(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createModeler__SWIG_1(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo), standardSaveFlag, bEnableACISAudit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createModeler(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo, bool standardSaveFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createModeler__SWIG_2(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo), standardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createModeler(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, OdDbAuditInfo pAuditInfo)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createModeler__SWIG_3(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createModeler(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createModeler__SWIG_4(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSat(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, int typeVer, bool standardSaveFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createSat__SWIG_0(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), typeVer, standardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSat(OdModelerGeometryPtrArray models, OdStreamBuf pStreamBuf, int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createSat__SWIG_1(swigCPtr, OdModelerGeometryPtrArray.getCPtr(models), OdStreamBuf.getCPtr(pStreamBuf), typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSat(OdDbEntityPtrArray entities, OdStreamBuf pStreamBuf, int typeVer, bool standardSaveFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createSat__SWIG_2(swigCPtr, OdDbEntityPtrArray.getCPtr(entities), OdStreamBuf.getCPtr(pStreamBuf), typeVer, standardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSat(OdDbEntityPtrArray entities, OdStreamBuf pStreamBuf, int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createSat__SWIG_3(swigCPtr, OdDbEntityPtrArray.getCPtr(entities), OdStreamBuf.getCPtr(pStreamBuf), typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRegionFromCurves(OdRxObjectPtrArray curveSegments, OdModelerGeometryPtrArray pRegions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_createRegionFromCurves(swigCPtr, OdRxObjectPtrArray.getCPtr(curveSegments).Handle, OdModelerGeometryPtrArray.getCPtr(pRegions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult initBrepBuilder(OdBrepBuilder brepBuilder, BrepType brepType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_initBrepBuilder(swigCPtr, OdBrepBuilder.getCPtr(brepBuilder), (int)brepType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("createModeler", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateModeler__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createModeler", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateModeler__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createModeler", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateModeler__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createModeler", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateModeler__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("createModeler", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcreateModeler__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("createSat", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreateSat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createSat", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateSat__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createSat", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcreateSat__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createSat", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcreateSat__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("createRegionFromCurves", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcreateRegionFromCurves;
		}
		if (SwigDerivedClassHasMethod("initBrepBuilder", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodinitBrepBuilder;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometryCreator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdModelerGeometryCreator));
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

	private int SwigDirectorMethodcreateModeler__SWIG_0(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit, int convAcisColors)
	{
		return (int)createModeler(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false), standardSaveFlag, bEnableACISAudit, (ColorConversionType)convAcisColors);
	}

	private int SwigDirectorMethodcreateModeler__SWIG_1(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag, bool bEnableACISAudit)
	{
		return (int)createModeler(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false), standardSaveFlag, bEnableACISAudit);
	}

	private int SwigDirectorMethodcreateModeler__SWIG_2(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo, bool standardSaveFlag)
	{
		return (int)createModeler(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false), standardSaveFlag);
	}

	private int SwigDirectorMethodcreateModeler__SWIG_3(IntPtr models, IntPtr pStreamBuf, IntPtr pAuditInfo)
	{
		return (int)createModeler(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), (pAuditInfo == IntPtr.Zero) ? null : new OdDbAuditInfo(pAuditInfo, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcreateModeler__SWIG_4(IntPtr models, IntPtr pStreamBuf)
	{
		return (int)createModeler(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodcreateSat__SWIG_0(IntPtr models, IntPtr pStreamBuf, int typeVer, bool standardSaveFlag)
	{
		return (int)createSat(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), typeVer, standardSaveFlag);
	}

	private int SwigDirectorMethodcreateSat__SWIG_1(IntPtr models, IntPtr pStreamBuf, int typeVer)
	{
		return (int)createSat(new OdModelerGeometryPtrArray(models, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), typeVer);
	}

	private int SwigDirectorMethodcreateSat__SWIG_2(IntPtr entities, IntPtr pStreamBuf, int typeVer, bool standardSaveFlag)
	{
		return (int)createSat(new OdDbEntityPtrArray(entities, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), typeVer, standardSaveFlag);
	}

	private int SwigDirectorMethodcreateSat__SWIG_3(IntPtr entities, IntPtr pStreamBuf, int typeVer)
	{
		return (int)createSat(new OdDbEntityPtrArray(entities, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), typeVer);
	}

	private int SwigDirectorMethodcreateRegionFromCurves(IntPtr curveSegments, IntPtr pRegions)
	{
		return (int)createRegionFromCurves(new OdRxObjectPtrArray(curveSegments, cMemoryOwn: true), new OdModelerGeometryPtrArray(pRegions, cMemoryOwn: false));
	}

	private int SwigDirectorMethodinitBrepBuilder(IntPtr brepBuilder, int brepType)
	{
		return (int)initBrepBuilder(new OdBrepBuilder(brepBuilder, cMemoryOwn: false), (BrepType)brepType);
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGripOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbGripOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGripOverrule_1();

	public delegate void SwigDelegateOdDbGripOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbGripOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbGripOverrule_4(IntPtr pSubject, IntPtr gripPoints);

	public delegate int SwigDelegateOdDbGripOverrule_5(IntPtr pSubject, IntPtr gripsData, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbGripOverrule_6(IntPtr pSubject, IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbGripOverrule_7(IntPtr pSubject, IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbGripOverrule_8(IntPtr pSubject, IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbGripOverrule_9(IntPtr pSubject, IntPtr indices, IntPtr offset);

	public delegate void SwigDelegateOdDbGripOverrule_10(IntPtr pSubject, int status);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGripOverrule_0 swigDelegate0;

	private SwigDelegateOdDbGripOverrule_1 swigDelegate1;

	private SwigDelegateOdDbGripOverrule_2 swigDelegate2;

	private SwigDelegateOdDbGripOverrule_3 swigDelegate3;

	private SwigDelegateOdDbGripOverrule_4 swigDelegate4;

	private SwigDelegateOdDbGripOverrule_5 swigDelegate5;

	private SwigDelegateOdDbGripOverrule_6 swigDelegate6;

	private SwigDelegateOdDbGripOverrule_7 swigDelegate7;

	private SwigDelegateOdDbGripOverrule_8 swigDelegate8;

	private SwigDelegateOdDbGripOverrule_9 swigDelegate9;

	private SwigDelegateOdDbGripOverrule_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes5 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDb_GripStat)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGripOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGripOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGripOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbGripOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGripOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbGripOverrule cast(OdRxObject pObj)
	{
		OdDbGripOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGripOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_isASwigExplicitOdDbGripOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_queryXSwigExplicitOdDbGripOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbGripOverrule createObject()
	{
		OdDbGripOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGripOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getGripPoints(OdDbEntity pSubject, OdGePoint3dArray gripPoints)
	{
		int result = (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getGripPointsSwigExplicitOdDbGripOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGePoint3dArray.getCPtr(gripPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getGripPoints__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGePoint3dArray.getCPtr(gripPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPoints(OdDbEntity pSubject, OdDbGripDataPtrArray gripsData, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getGripPointsSwigExplicitOdDbGripOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbGripDataPtrArray.getCPtr(gripsData).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getGripPoints__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbGripDataPtrArray.getCPtr(gripsData).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdDbEntity pSubject, OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveGripPointsAtSwigExplicitOdDbGripOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveGripPointsAt__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdDbEntity pSubject, OdDbVoidPtrArray grips, OdGeVector3d offset, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveGripPointsAtSwigExplicitOdDbGripOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveGripPointsAt__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getStretchPoints(OdDbEntity pSubject, OdGePoint3dArray stretchPoints)
	{
		int result = (SwigDerivedClassHasMethod("getStretchPoints", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getStretchPointsSwigExplicitOdDbGripOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGePoint3dArray.getCPtr(stretchPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getStretchPoints(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGePoint3dArray.getCPtr(stretchPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveStretchPointsAt(OdDbEntity pSubject, OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("moveStretchPointsAt", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveStretchPointsAtSwigExplicitOdDbGripOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_moveStretchPointsAt(swigCPtr, OdDbEntity.getCPtr(pSubject), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void gripStatus(OdDbEntity pSubject, OdDb_GripStat status)
	{
		if (SwigDerivedClassHasMethod("gripStatus", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_gripStatusSwigExplicitOdDbGripOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)status);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_gripStatus(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)status);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("isApplicable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisApplicable;
		}
		if (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetGripPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetGripPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodmoveGripPointsAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoveGripPointsAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getStretchPoints", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("moveStretchPointsAt", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodmoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("gripStatus", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgripStatus;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGripOverrule));
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

	private bool SwigDirectorMethodisApplicable(IntPtr pOverruledSubject)
	{
		return isApplicable(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pOverruledSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetGripPoints__SWIG_0(IntPtr pSubject, IntPtr gripPoints)
	{
		return (int)getGripPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(gripPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetGripPoints__SWIG_1(IntPtr pSubject, IntPtr gripsData, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags)
	{
		return (int)getGripPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbGripDataPtrArray(gripsData, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodmoveGripPointsAt__SWIG_0(IntPtr pSubject, IntPtr indices, IntPtr offset)
	{
		return (int)moveGripPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private int SwigDirectorMethodmoveGripPointsAt__SWIG_1(IntPtr pSubject, IntPtr grips, IntPtr offset, int bitFlags)
	{
		return (int)moveGripPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbVoidPtrArray(grips, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodgetStretchPoints(IntPtr pSubject, IntPtr stretchPoints)
	{
		return (int)getStretchPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(stretchPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodmoveStretchPointsAt(IntPtr pSubject, IntPtr indices, IntPtr offset)
	{
		return (int)moveStretchPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgripStatus(IntPtr pSubject, int status)
	{
		try
		{
			gripStatus(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_GripStat)status);
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbOsnapOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbOsnapOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbOsnapOverrule_1();

	public delegate void SwigDelegateOdDbOsnapOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbOsnapOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbOsnapOverrule_4(IntPtr pSubject, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbOsnapOverrule_5(IntPtr pSubject, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat);

	public delegate bool SwigDelegateOdDbOsnapOverrule_6(IntPtr pSubject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbOsnapOverrule_0 swigDelegate0;

	private SwigDelegateOdDbOsnapOverrule_1 swigDelegate1;

	private SwigDelegateOdDbOsnapOverrule_2 swigDelegate2;

	private SwigDelegateOdDbOsnapOverrule_3 swigDelegate3;

	private SwigDelegateOdDbOsnapOverrule_4 swigDelegate4;

	private SwigDelegateOdDbOsnapOverrule_5 swigDelegate5;

	private SwigDelegateOdDbOsnapOverrule_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes5 = new Type[8]
	{
		typeof(OdDbEntity),
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbOsnapOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbOsnapOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbOsnapOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbOsnapOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbOsnapOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbOsnapOverrule cast(OdRxObject pObj)
	{
		OdDbOsnapOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbOsnapOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_isASwigExplicitOdDbOsnapOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_queryXSwigExplicitOdDbOsnapOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbOsnapOverrule createObject()
	{
		OdDbOsnapOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbOsnapOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getOsnapPoints(OdDbEntity pSubject, OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints)
	{
		int result = (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_getOsnapPointsSwigExplicitOdDbOsnapOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_getOsnapPoints__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOsnapPoints(OdDbEntity pSubject, OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints, OdGeMatrix3d insertionMat)
	{
		int result = (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_getOsnapPointsSwigExplicitOdDbOsnapOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insertionMat)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_getOsnapPoints__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insertionMat)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isContentSnappable(OdDbEntity pSubject)
	{
		bool result = (SwigDerivedClassHasMethod("isContentSnappable", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_isContentSnappableSwigExplicitOdDbOsnapOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_isContentSnappable(swigCPtr, OdDbEntity.getCPtr(pSubject)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetOsnapPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetOsnapPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isContentSnappable", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisContentSnappable;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbOsnapOverrule));
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

	private int SwigDirectorMethodgetOsnapPoints__SWIG_0(IntPtr pSubject, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints)
	{
		return (int)getOsnapPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetOsnapPoints__SWIG_1(IntPtr pSubject, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insertionMat)
	{
		return (int)getOsnapPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true), new OdGeMatrix3d(insertionMat, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisContentSnappable(IntPtr pSubject)
	{
		return isContentSnappable(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSelfGiDrawablePE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiSelfGiDrawablePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSelfGiDrawablePE_1();

	public delegate void SwigDelegateOdGiSelfGiDrawablePE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiSelfGiDrawablePE_3(IntPtr pRxObject, IntPtr pDestGeom, IntPtr pContext, int regenType, IntPtr origin, IntPtr u, IntPtr v, IntPtr screenRect, bool isExport);

	public delegate bool SwigDelegateOdGiSelfGiDrawablePE_4(IntPtr pRxObject, IntPtr pDestGeom, IntPtr pContext, int regenType, IntPtr origin, IntPtr u, IntPtr v, IntPtr screenRect);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSelfGiDrawablePE_0 swigDelegate0;

	private SwigDelegateOdGiSelfGiDrawablePE_1 swigDelegate1;

	private SwigDelegateOdGiSelfGiDrawablePE_2 swigDelegate2;

	private SwigDelegateOdGiSelfGiDrawablePE_3 swigDelegate3;

	private SwigDelegateOdGiSelfGiDrawablePE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[9]
	{
		typeof(OdRxObject),
		typeof(OdGiConveyorGeometry),
		typeof(OdGiConveyorContext),
		typeof(OdGiRegenType),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGsDCRect),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[8]
	{
		typeof(OdRxObject),
		typeof(OdGiConveyorGeometry),
		typeof(OdGiConveyorContext),
		typeof(OdGiRegenType),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGsDCRect)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSelfGiDrawablePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSelfGiDrawablePE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelfGiDrawablePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSelfGiDrawablePE cast(OdRxObject pObj)
	{
		OdGiSelfGiDrawablePE rXObject = Helpers.GetRXObject<OdGiSelfGiDrawablePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_isASwigExplicitOdGiSelfGiDrawablePE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_queryXSwigExplicitOdGiSelfGiDrawablePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiSelfGiDrawablePE createObject()
	{
		OdGiSelfGiDrawablePE rXObject = Helpers.GetRXObject<OdGiSelfGiDrawablePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool draw(OdRxObject pRxObject, OdGiConveyorGeometry pDestGeom, OdGiConveyorContext pContext, OdGiRegenType regenType, OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGsDCRect screenRect, bool isExport)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_draw__SWIG_0(swigCPtr, OdRxObject.getCPtr(pRxObject), pDestGeom.GetInterfaceCPtr(), pContext.GetInterfaceCPtr(), (int)regenType, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGsDCRect.getCPtr(screenRect), isExport);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool draw(OdRxObject pRxObject, OdGiConveyorGeometry pDestGeom, OdGiConveyorContext pContext, OdGiRegenType regenType, OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGsDCRect screenRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_draw__SWIG_1(swigCPtr, OdRxObject.getCPtr(pRxObject), pDestGeom.GetInterfaceCPtr(), pContext.GetInterfaceCPtr(), (int)regenType, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSelfGiDrawablePE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelfGiDrawablePE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSelfGiDrawablePE) != GetType();
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
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddraw__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddraw__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGiDrawablePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSelfGiDrawablePE));
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

	private bool SwigDirectorMethoddraw__SWIG_0(IntPtr pRxObject, IntPtr pDestGeom, IntPtr pContext, int regenType, IntPtr origin, IntPtr u, IntPtr v, IntPtr screenRect, bool isExport)
	{
		return draw(Helpers.GetRXObject<OdRxObject>(pRxObject, bOwn: false, bTryAddToTransaction: false), new OdGiConveyorGeometry_Internal(pDestGeom, cMemoryOwn: false), new OdGiConveyorContext_Internal(pContext, cMemoryOwn: false), (OdGiRegenType)regenType, new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), new OdGsDCRect(screenRect, cMemoryOwn: false), isExport);
	}

	private bool SwigDirectorMethoddraw__SWIG_1(IntPtr pRxObject, IntPtr pDestGeom, IntPtr pContext, int regenType, IntPtr origin, IntPtr u, IntPtr v, IntPtr screenRect)
	{
		return draw(Helpers.GetRXObject<OdRxObject>(pRxObject, bOwn: false, bTryAddToTransaction: false), new OdGiConveyorGeometry_Internal(pDestGeom, cMemoryOwn: false), new OdGiConveyorContext_Internal(pContext, cMemoryOwn: false), (OdGiRegenType)regenType, new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), new OdGsDCRect(screenRect, cMemoryOwn: false));
	}
}

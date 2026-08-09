using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPaperOrientationPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbPaperOrientationPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPaperOrientationPE_1();

	public delegate void SwigDelegateOdDbPaperOrientationPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbPaperOrientationPE_3(IntPtr pObject);

	public delegate int SwigDelegateOdDbPaperOrientationPE_4(IntPtr pObject, bool bPaperOrientation);

	public delegate int SwigDelegateOdDbPaperOrientationPE_5(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPaperOrientationPE_0 swigDelegate0;

	private SwigDelegateOdDbPaperOrientationPE_1 swigDelegate1;

	private SwigDelegateOdDbPaperOrientationPE_2 swigDelegate2;

	private SwigDelegateOdDbPaperOrientationPE_3 swigDelegate3;

	private SwigDelegateOdDbPaperOrientationPE_4 swigDelegate4;

	private SwigDelegateOdDbPaperOrientationPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbViewport)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPaperOrientationPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPaperOrientationPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPaperOrientationPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbPaperOrientationPE cast(OdRxObject pObj)
	{
		OdDbPaperOrientationPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPaperOrientationPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_isASwigExplicitOdDbPaperOrientationPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_queryXSwigExplicitOdDbPaperOrientationPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbPaperOrientationPE createObject()
	{
		OdDbPaperOrientationPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPaperOrientationPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool paperOrientation(OdDbObject pObject)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_paperOrientation(swigCPtr, OdDbObject.getCPtr(pObject));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setPaperOrientation(OdDbObject pObject, bool bPaperOrientation)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_setPaperOrientation(swigCPtr, OdDbObject.getCPtr(pObject), bPaperOrientation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult applyPaperOrientationTransform(OdDbObject arg0, OdDbViewport arg1)
	{
		int result = (SwigDerivedClassHasMethod("applyPaperOrientationTransform", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_applyPaperOrientationTransformSwigExplicitOdDbPaperOrientationPE(swigCPtr, OdDbObject.getCPtr(arg0), OdDbViewport.getCPtr(arg1)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_applyPaperOrientationTransform(swigCPtr, OdDbObject.getCPtr(arg0), OdDbViewport.getCPtr(arg1)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbPaperOrientationPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPaperOrientationPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbPaperOrientationPE) != GetType();
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
		if (SwigDerivedClassHasMethod("paperOrientation", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodpaperOrientation;
		}
		if (SwigDerivedClassHasMethod("setPaperOrientation", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetPaperOrientation;
		}
		if (SwigDerivedClassHasMethod("applyPaperOrientationTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodapplyPaperOrientationTransform;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPaperOrientationPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPaperOrientationPE));
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

	private bool SwigDirectorMethodpaperOrientation(IntPtr pObject)
	{
		return paperOrientation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetPaperOrientation(IntPtr pObject, bool bPaperOrientation)
	{
		return (int)setPaperOrientation(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), bPaperOrientation);
	}

	private int SwigDirectorMethodapplyPaperOrientationTransform(IntPtr arg0, IntPtr arg1)
	{
		return (int)applyPaperOrientationTransform(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbViewport>(arg1, bOwn: false, bTryAddToTransaction: false));
	}
}

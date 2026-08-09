using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSelfGdiDrawable : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiSelfGdiDrawable_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSelfGdiDrawable_1();

	public delegate void SwigDelegateOdGiSelfGdiDrawable_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiSelfGdiDrawable_3(IntPtr drawObj, IntPtr hdc, IntPtr screenRect);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSelfGdiDrawable_0 swigDelegate0;

	private SwigDelegateOdGiSelfGdiDrawable_1 swigDelegate1;

	private SwigDelegateOdGiSelfGdiDrawable_2 swigDelegate2;

	private SwigDelegateOdGiSelfGdiDrawable_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGiCommonDraw),
		typeof(IntPtr),
		typeof(OdGsDCRect)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSelfGdiDrawable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSelfGdiDrawable obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelfGdiDrawable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSelfGdiDrawable cast(OdRxObject pObj)
	{
		OdGiSelfGdiDrawable rXObject = Helpers.GetRXObject<OdGiSelfGdiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_isASwigExplicitOdGiSelfGdiDrawable(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_queryXSwigExplicitOdGiSelfGdiDrawable(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiSelfGdiDrawable createObject()
	{
		OdGiSelfGdiDrawable rXObject = Helpers.GetRXObject<OdGiSelfGdiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool draw(OdGiCommonDraw drawObj, IntPtr hdc, OdGsDCRect screenRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_draw(swigCPtr, OdGiCommonDraw.getCPtr(drawObj), hdc, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSelfGdiDrawable()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelfGdiDrawable(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSelfGdiDrawable) != GetType();
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
			swigDelegate3 = SwigDirectorMethoddraw;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelfGdiDrawable_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSelfGdiDrawable));
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

	private bool SwigDirectorMethoddraw(IntPtr drawObj, IntPtr hdc, IntPtr screenRect)
	{
		return draw(Helpers.GetRXObject<OdGiCommonDraw>(drawObj, bOwn: false, bTryAddToTransaction: false), hdc, new OdGsDCRect(screenRect, cMemoryOwn: false));
	}
}

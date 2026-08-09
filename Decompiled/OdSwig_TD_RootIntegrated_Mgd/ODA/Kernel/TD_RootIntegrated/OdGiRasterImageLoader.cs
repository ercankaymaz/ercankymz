using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageLoader : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiRasterImageLoader_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageLoader_1();

	public delegate void SwigDelegateOdGiRasterImageLoader_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiRasterImageLoader_3([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr giCtx, int hint);

	public delegate IntPtr SwigDelegateOdGiRasterImageLoader_4([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr giCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageLoader_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageLoader_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageLoader_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageLoader_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageLoader_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(OdGiContext),
		typeof(OdDbBaseHostAppServices_FindFileHint)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdGiContext)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRasterImageLoader(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageLoader obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageLoader(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRasterImageLoader cast(OdRxObject pObj)
	{
		OdGiRasterImageLoader rXObject = Helpers.GetRXObject<OdGiRasterImageLoader>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_isASwigExplicitOdGiRasterImageLoader(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_queryXSwigExplicitOdGiRasterImageLoader(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImageLoader()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageLoader(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageLoader) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdGiRasterImage loadRasterImage(string fileName, OdGiContext giCtx, OdDbBaseHostAppServices_FindFileHint hint)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_loadRasterImageSwigExplicitOdGiRasterImageLoader__SWIG_0(swigCPtr, fileName, OdGiContext.getCPtr(giCtx), (int)hint) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_loadRasterImage__SWIG_0(swigCPtr, fileName, OdGiContext.getCPtr(giCtx), (int)hint), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage loadRasterImage(string fileName, OdGiContext giCtx)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_loadRasterImageSwigExplicitOdGiRasterImageLoader__SWIG_1(swigCPtr, fileName, OdGiContext.getCPtr(giCtx)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_loadRasterImage__SWIG_1(swigCPtr, fileName, OdGiContext.getCPtr(giCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiRasterImageLoader createObject()
	{
		OdGiRasterImageLoader rXObject = Helpers.GetRXObject<OdGiRasterImageLoader>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodloadRasterImage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodloadRasterImage__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageLoader_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageLoader));
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

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr giCtx, int hint)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(fileName, Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), (OdDbBaseHostAppServices_FindFileHint)hint)).Handle;
	}

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr giCtx)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(fileName, Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false))).Handle;
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayoutPaperPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLayoutPaperPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLayoutPaperPE_1();

	public delegate void SwigDelegateOdDbLayoutPaperPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbLayoutPaperPE_3(IntPtr pThis, IntPtr pWd, IntPtr points);

	public delegate bool SwigDelegateOdDbLayoutPaperPE_4(IntPtr pThis, IntPtr pWd, IntPtr points);

	public delegate bool SwigDelegateOdDbLayoutPaperPE_5(IntPtr pThis, IntPtr pWd, IntPtr points);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLayoutPaperPE_0 swigDelegate0;

	private SwigDelegateOdDbLayoutPaperPE_1 swigDelegate1;

	private SwigDelegateOdDbLayoutPaperPE_2 swigDelegate2;

	private SwigDelegateOdDbLayoutPaperPE_3 swigDelegate3;

	private SwigDelegateOdDbLayoutPaperPE_4 swigDelegate4;

	private SwigDelegateOdDbLayoutPaperPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbLayout),
		typeof(OdGiWorldDraw),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdDbLayout),
		typeof(OdGiWorldDraw),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbLayout),
		typeof(OdGiWorldDraw),
		typeof(OdGePoint3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayoutPaperPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayoutPaperPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayoutPaperPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbLayoutPaperPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLayoutPaperPE(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		_ = typeof(OdDbLayoutPaperPE) != GetType();
		Type[] methodTypes = new Type[3]
		{
			typeof(OdDbLayout),
			typeof(OdGiWorldDraw),
			typeof(OdArray_OdGePoint3d_OdObjectsAllocator)
		};
		Type[] methodTypes2 = new Type[3]
		{
			typeof(OdDbLayout),
			typeof(OdGiWorldDraw),
			typeof(OdArray_OdGePoint3d_OdObjectsAllocator)
		};
		Type[] methodTypes3 = new Type[3]
		{
			typeof(OdDbLayout),
			typeof(OdGiWorldDraw),
			typeof(OdArray_OdGePoint3d_OdObjectsAllocator)
		};
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
		if (SwigDerivedClassHasMethod("DrawPaper", methodTypes))
		{
			swigDelegate3 = SwigDirectorMethoddrawPaper;
		}
		if (SwigDerivedClassHasMethod("DrawBorder", methodTypes2))
		{
			swigDelegate4 = SwigDirectorMethoddrawBorder;
		}
		if (SwigDerivedClassHasMethod("DrawMargins", methodTypes3))
		{
			swigDelegate5 = SwigDirectorMethoddrawMargins;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbLayoutPaperPE cast(OdRxObject pObj)
	{
		OdDbLayoutPaperPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutPaperPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_isASwigExplicitOdDbLayoutPaperPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_queryXSwigExplicitOdDbLayoutPaperPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLayoutPaperPE createObject()
	{
		OdDbLayoutPaperPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutPaperPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	internal bool drawPaper(OdDbLayout pThis, OdGiWorldDraw pWd, OdGePoint3d points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_drawPaper(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdGePoint3d.getCPtr(points));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	internal bool drawBorder(OdDbLayout pThis, OdGiWorldDraw pWd, OdGePoint3d points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_drawBorder(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdGePoint3d.getCPtr(points));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	internal bool drawMargins(OdDbLayout pThis, OdGiWorldDraw pWd, OdGePoint3d points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_drawMargins(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdGePoint3d.getCPtr(points));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool DrawBorder(OdDbLayout pThis, OdGiWorldDraw pWd, OdArray_OdGePoint3d_OdObjectsAllocator points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_DrawBorder(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdArray_OdGePoint3d_OdObjectsAllocator.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool DrawMargins(OdDbLayout pThis, OdGiWorldDraw pWd, OdArray_OdGePoint3d_OdObjectsAllocator points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_DrawMargins(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdArray_OdGePoint3d_OdObjectsAllocator.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool DrawPaper(OdDbLayout pThis, OdGiWorldDraw pWd, OdArray_OdGePoint3d_OdObjectsAllocator points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_DrawPaper(swigCPtr, OdDbLayout.getCPtr(pThis), OdGiWorldDraw.getCPtr(pWd), OdArray_OdGePoint3d_OdObjectsAllocator.getCPtr(points).Handle);
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
		if (SwigDerivedClassHasMethod("drawPaper", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawPaper;
		}
		if (SwigDerivedClassHasMethod("drawBorder", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddrawBorder;
		}
		if (SwigDerivedClassHasMethod("drawMargins", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddrawMargins;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutPaperPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLayoutPaperPE));
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

	private bool SwigDirectorMethoddrawPaper(IntPtr pThis, IntPtr pWd, IntPtr points)
	{
		return ((Func<bool>)delegate
		{
			try
			{
				return DrawPaper((OdDbLayout)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdDbLayout), pThis, own: false), (OdGiWorldDraw)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdGiWorldDraw), pWd, own: false), new OdArray_OdGePoint3d_OdObjectsAllocator(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalPointFixedArray(points, 4, bOwnPts: false)));
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethoddrawBorder(IntPtr pThis, IntPtr pWd, IntPtr points)
	{
		return ((Func<bool>)delegate
		{
			try
			{
				return DrawBorder((OdDbLayout)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdDbLayout), pThis, own: false), (OdGiWorldDraw)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdGiWorldDraw), pWd, own: false), new OdArray_OdGePoint3d_OdObjectsAllocator(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalPointFixedArray(points, 4, bOwnPts: false)));
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethoddrawMargins(IntPtr pThis, IntPtr pWd, IntPtr points)
	{
		return ((Func<bool>)delegate
		{
			try
			{
				return DrawMargins((OdDbLayout)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdDbLayout), pThis, own: false), (OdGiWorldDraw)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternalUniversal(typeof(OdGiWorldDraw), pWd, own: false), new OdArray_OdGePoint3d_OdObjectsAllocator(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalPointFixedArray(points, 4, bOwnPts: false)));
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}

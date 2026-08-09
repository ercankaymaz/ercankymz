using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewportDraw : OdGiCommonDraw
{
	public delegate IntPtr SwigDelegateOdGiViewportDraw_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiViewportDraw_1();

	public delegate void SwigDelegateOdGiViewportDraw_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiViewportDraw_3();

	public delegate bool SwigDelegateOdGiViewportDraw_4();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_5();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_6();

	public delegate bool SwigDelegateOdGiViewportDraw_7();

	public delegate double SwigDelegateOdGiViewportDraw_8(int deviationType, IntPtr pointOnCurve);

	public delegate uint SwigDelegateOdGiViewportDraw_9();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_10();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_11();

	public delegate bool SwigDelegateOdGiViewportDraw_12();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_13();

	public delegate IntPtr SwigDelegateOdGiViewportDraw_14();

	public delegate uint SwigDelegateOdGiViewportDraw_15();

	public delegate bool SwigDelegateOdGiViewportDraw_16(uint viewportId);

	public delegate IntPtr SwigDelegateOdGiViewportDraw_17();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiViewportDraw_0 swigDelegate0;

	private SwigDelegateOdGiViewportDraw_1 swigDelegate1;

	private SwigDelegateOdGiViewportDraw_2 swigDelegate2;

	private SwigDelegateOdGiViewportDraw_3 swigDelegate3;

	private SwigDelegateOdGiViewportDraw_4 swigDelegate4;

	private SwigDelegateOdGiViewportDraw_5 swigDelegate5;

	private SwigDelegateOdGiViewportDraw_6 swigDelegate6;

	private SwigDelegateOdGiViewportDraw_7 swigDelegate7;

	private SwigDelegateOdGiViewportDraw_8 swigDelegate8;

	private SwigDelegateOdGiViewportDraw_9 swigDelegate9;

	private SwigDelegateOdGiViewportDraw_10 swigDelegate10;

	private SwigDelegateOdGiViewportDraw_11 swigDelegate11;

	private SwigDelegateOdGiViewportDraw_12 swigDelegate12;

	private SwigDelegateOdGiViewportDraw_13 swigDelegate13;

	private SwigDelegateOdGiViewportDraw_14 swigDelegate14;

	private SwigDelegateOdGiViewportDraw_15 swigDelegate15;

	private SwigDelegateOdGiViewportDraw_16 swigDelegate16;

	private SwigDelegateOdGiViewportDraw_17 swigDelegate17;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes17 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewportDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewportDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewportDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiViewportDraw cast(OdRxObject pObj)
	{
		OdGiViewportDraw rXObject = Helpers.GetRXObject<OdGiViewportDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_isASwigExplicitOdGiViewportDraw(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_queryXSwigExplicitOdGiViewportDraw(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiViewportDraw createObject()
	{
		OdGiViewportDraw rXObject = Helpers.GetRXObject<OdGiViewportDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiViewport viewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_viewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiViewportGeometry geometry()
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_geometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint sequenceNumber()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_sequenceNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidId(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_isValidId(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_viewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiViewportDraw()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewportDraw(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiViewportDraw) != GetType();
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
		if (SwigDerivedClassHasMethod("regenType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodregenType;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("subEntityTraits", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsubEntityTraits;
		}
		if (SwigDerivedClassHasMethod("rawGeometry", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodrawGeometry;
		}
		if (SwigDerivedClassHasMethod("isDragging", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisDragging;
		}
		if (SwigDerivedClassHasMethod("deviation", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddeviation;
		}
		if (SwigDerivedClassHasMethod("numberOfIsolines", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodnumberOfIsolines;
		}
		if (SwigDerivedClassHasMethod("context", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcontext;
		}
		if (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcurrentGiPath;
		}
		if (SwigDerivedClassHasMethod("displayModelerSilhouettes", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddisplayModelerSilhouettes;
		}
		if (SwigDerivedClassHasMethod("viewport", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodviewport;
		}
		if (SwigDerivedClassHasMethod("geometry", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgeometry;
		}
		if (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsequenceNumber;
		}
		if (SwigDerivedClassHasMethod("isValidId", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisValidId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodviewportObjectId;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiViewportDraw));
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

	private int SwigDirectorMethodregenType()
	{
		return (int)regenType();
	}

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private IntPtr SwigDirectorMethodsubEntityTraits()
	{
		return OdGiSubEntityTraits.getCPtr(subEntityTraits()).Handle;
	}

	private IntPtr SwigDirectorMethodrawGeometry()
	{
		return OdGiGeometry.getCPtr(rawGeometry()).Handle;
	}

	private bool SwigDirectorMethodisDragging()
	{
		return isDragging();
	}

	private double SwigDirectorMethoddeviation(int deviationType, IntPtr pointOnCurve)
	{
		return deviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodnumberOfIsolines()
	{
		return numberOfIsolines();
	}

	private IntPtr SwigDirectorMethodcontext()
	{
		return OdGiContext.getCPtr(context()).Handle;
	}

	private IntPtr SwigDirectorMethodcurrentGiPath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiPathNode.getCPtr(currentGiPath()).Handle;
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

	private bool SwigDirectorMethoddisplayModelerSilhouettes()
	{
		return displayModelerSilhouettes();
	}

	private IntPtr SwigDirectorMethodviewport()
	{
		return OdGiViewport.getCPtr(viewport()).Handle;
	}

	private IntPtr SwigDirectorMethodgeometry()
	{
		return OdGiViewportGeometry.getCPtr(geometry()).Handle;
	}

	private uint SwigDirectorMethodsequenceNumber()
	{
		return sequenceNumber();
	}

	private bool SwigDirectorMethodisValidId(uint viewportId)
	{
		return isValidId(viewportId);
	}

	private IntPtr SwigDirectorMethodviewportObjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(viewportObjectId()).Handle;
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
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWorldDraw : OdGiCommonDraw
{
	public delegate IntPtr SwigDelegateOdGiWorldDraw_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiWorldDraw_1();

	public delegate void SwigDelegateOdGiWorldDraw_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiWorldDraw_3();

	public delegate bool SwigDelegateOdGiWorldDraw_4();

	public delegate IntPtr SwigDelegateOdGiWorldDraw_5();

	public delegate IntPtr SwigDelegateOdGiWorldDraw_6();

	public delegate bool SwigDelegateOdGiWorldDraw_7();

	public delegate double SwigDelegateOdGiWorldDraw_8(int deviationType, IntPtr pointOnCurve);

	public delegate uint SwigDelegateOdGiWorldDraw_9();

	public delegate IntPtr SwigDelegateOdGiWorldDraw_10();

	public delegate IntPtr SwigDelegateOdGiWorldDraw_11();

	public delegate bool SwigDelegateOdGiWorldDraw_12();

	public delegate IntPtr SwigDelegateOdGiWorldDraw_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiWorldDraw_0 swigDelegate0;

	private SwigDelegateOdGiWorldDraw_1 swigDelegate1;

	private SwigDelegateOdGiWorldDraw_2 swigDelegate2;

	private SwigDelegateOdGiWorldDraw_3 swigDelegate3;

	private SwigDelegateOdGiWorldDraw_4 swigDelegate4;

	private SwigDelegateOdGiWorldDraw_5 swigDelegate5;

	private SwigDelegateOdGiWorldDraw_6 swigDelegate6;

	private SwigDelegateOdGiWorldDraw_7 swigDelegate7;

	private SwigDelegateOdGiWorldDraw_8 swigDelegate8;

	private SwigDelegateOdGiWorldDraw_9 swigDelegate9;

	private SwigDelegateOdGiWorldDraw_10 swigDelegate10;

	private SwigDelegateOdGiWorldDraw_11 swigDelegate11;

	private SwigDelegateOdGiWorldDraw_12 swigDelegate12;

	private SwigDelegateOdGiWorldDraw_13 swigDelegate13;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWorldDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWorldDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiWorldDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiWorldDraw()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiWorldDraw(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGiWorldDraw cast(OdRxObject pObj)
	{
		OdGiWorldDraw rXObject = Helpers.GetRXObject<OdGiWorldDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_isASwigExplicitOdGiWorldDraw(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_queryXSwigExplicitOdGiWorldDraw(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiWorldDraw createObject()
	{
		OdGiWorldDraw rXObject = Helpers.GetRXObject<OdGiWorldDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiWorldGeometry geometry()
	{
		OdGiWorldGeometry rXObject = Helpers.GetRXObject<OdGiWorldGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_geometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("geometry", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgeometry;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiWorldDraw));
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

	private IntPtr SwigDirectorMethodgeometry()
	{
		return OdGiWorldGeometry.getCPtr(geometry()).Handle;
	}
}

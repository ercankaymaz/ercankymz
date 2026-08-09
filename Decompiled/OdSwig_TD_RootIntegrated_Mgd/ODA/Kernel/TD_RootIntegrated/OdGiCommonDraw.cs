using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiCommonDraw : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiCommonDraw_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiCommonDraw_1();

	public delegate void SwigDelegateOdGiCommonDraw_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiCommonDraw_3();

	public delegate bool SwigDelegateOdGiCommonDraw_4();

	public delegate IntPtr SwigDelegateOdGiCommonDraw_5();

	public delegate IntPtr SwigDelegateOdGiCommonDraw_6();

	public delegate bool SwigDelegateOdGiCommonDraw_7();

	public delegate double SwigDelegateOdGiCommonDraw_8(int deviationType, IntPtr pointOnCurve);

	public delegate uint SwigDelegateOdGiCommonDraw_9();

	public delegate IntPtr SwigDelegateOdGiCommonDraw_10();

	public delegate IntPtr SwigDelegateOdGiCommonDraw_11();

	public delegate bool SwigDelegateOdGiCommonDraw_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiCommonDraw_0 swigDelegate0;

	private SwigDelegateOdGiCommonDraw_1 swigDelegate1;

	private SwigDelegateOdGiCommonDraw_2 swigDelegate2;

	private SwigDelegateOdGiCommonDraw_3 swigDelegate3;

	private SwigDelegateOdGiCommonDraw_4 swigDelegate4;

	private SwigDelegateOdGiCommonDraw_5 swigDelegate5;

	private SwigDelegateOdGiCommonDraw_6 swigDelegate6;

	private SwigDelegateOdGiCommonDraw_7 swigDelegate7;

	private SwigDelegateOdGiCommonDraw_8 swigDelegate8;

	private SwigDelegateOdGiCommonDraw_9 swigDelegate9;

	private SwigDelegateOdGiCommonDraw_10 swigDelegate10;

	private SwigDelegateOdGiCommonDraw_11 swigDelegate11;

	private SwigDelegateOdGiCommonDraw_12 swigDelegate12;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiCommonDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiCommonDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiCommonDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiCommonDraw cast(OdRxObject pObj)
	{
		OdGiCommonDraw rXObject = Helpers.GetRXObject<OdGiCommonDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_isASwigExplicitOdGiCommonDraw(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_queryXSwigExplicitOdGiCommonDraw(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiCommonDraw createObject()
	{
		OdGiCommonDraw rXObject = Helpers.GetRXObject<OdGiCommonDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public virtual bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isDragging()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_isDragging(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiContext context()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_context(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiPathNode currentGiPath()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_currentGiPathSwigExplicitOdGiCommonDraw(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_currentGiPath(swigCPtr));
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool displayModelerSilhouettes()
	{
		bool result = (SwigDerivedClassHasMethod("displayModelerSilhouettes", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_displayModelerSilhouettesSwigExplicitOdGiCommonDraw(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_displayModelerSilhouettes(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiCommonDraw()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiCommonDraw(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiCommonDraw) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCommonDraw_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiCommonDraw));
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
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseUnitsFormatter : OdUnitsFormatter
{
	public delegate IntPtr SwigDelegateOdDbBaseUnitsFormatter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseUnitsFormatter_1();

	public delegate void SwigDelegateOdDbBaseUnitsFormatter_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseUnitsFormatter_3(IntPtr value);

	public delegate IntPtr SwigDelegateOdDbBaseUnitsFormatter_4([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseUnitsFormatter_5(double value);

	public delegate double SwigDelegateOdDbBaseUnitsFormatter_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseUnitsFormatter_7(double value);

	public delegate double SwigDelegateOdDbBaseUnitsFormatter_8([MarshalAs(UnmanagedType.LPWStr)] string string_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseUnitsFormatter_0 swigDelegate0;

	private SwigDelegateOdDbBaseUnitsFormatter_1 swigDelegate1;

	private SwigDelegateOdDbBaseUnitsFormatter_2 swigDelegate2;

	private SwigDelegateOdDbBaseUnitsFormatter_3 swigDelegate3;

	private SwigDelegateOdDbBaseUnitsFormatter_4 swigDelegate4;

	private SwigDelegateOdDbBaseUnitsFormatter_5 swigDelegate5;

	private SwigDelegateOdDbBaseUnitsFormatter_6 swigDelegate6;

	private SwigDelegateOdDbBaseUnitsFormatter_7 swigDelegate7;

	private SwigDelegateOdDbBaseUnitsFormatter_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseUnitsFormatter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseUnitsFormatter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseUnitsFormatter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbBaseUnitsFormatter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseUnitsFormatter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseUnitsFormatter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbBaseUnitsFormatter cast(OdRxObject pObj)
	{
		OdDbBaseUnitsFormatter rXObject = Helpers.GetRXObject<OdDbBaseUnitsFormatter>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_isASwigExplicitOdDbBaseUnitsFormatter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_queryXSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbBaseUnitsFormatter createObject()
	{
		OdDbBaseUnitsFormatter rXObject = Helpers.GetRXObject<OdDbBaseUnitsFormatter>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string formatCmColor(OdCmColorBase value)
	{
		string result = (SwigDerivedClassHasMethod("formatCmColor", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatCmColorSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, OdCmColorBase.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatCmColor(swigCPtr, OdCmColorBase.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdCmColorBase unformatCmColor(string string_)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(SwigDerivedClassHasMethod("unformatCmColor", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatCmColorSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, string_) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatCmColor(swigCPtr, string_), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatLinear(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatLinear", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatLinearSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, value) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatLinear(swigCPtr, value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatLinear(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatLinear", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatLinearSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, string_) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatLinear(swigCPtr, string_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatAngle(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatAngle", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatAngleSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, value) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_formatAngle(swigCPtr, value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatAngle(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatAngle", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatAngleSwigExplicitOdDbBaseUnitsFormatter(swigCPtr, string_) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_unformatAngle(swigCPtr, string_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("formatCmColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodformatCmColor;
		}
		if (SwigDerivedClassHasMethod("unformatCmColor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodunformatCmColor;
		}
		if (SwigDerivedClassHasMethod("formatLinear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodformatLinear;
		}
		if (SwigDerivedClassHasMethod("unformatLinear", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodunformatLinear;
		}
		if (SwigDerivedClassHasMethod("formatAngle", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodformatAngle;
		}
		if (SwigDerivedClassHasMethod("unformatAngle", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodunformatAngle;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseUnitsFormatter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseUnitsFormatter));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatCmColor(IntPtr value)
	{
		return formatCmColor(Helpers.GetObject<OdCmColorBase>(value, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodunformatCmColor([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return OdCmColorBase.getCPtr(unformatCmColor(string_)).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatLinear(double value)
	{
		return formatLinear(value);
	}

	private double SwigDirectorMethodunformatLinear([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return unformatLinear(string_);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatAngle(double value)
	{
		return formatAngle(value);
	}

	private double SwigDirectorMethodunformatAngle([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return unformatAngle(string_);
	}
}

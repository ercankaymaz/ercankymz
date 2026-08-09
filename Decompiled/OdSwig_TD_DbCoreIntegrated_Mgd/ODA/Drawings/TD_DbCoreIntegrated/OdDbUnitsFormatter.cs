using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUnitsFormatter : OdDbBaseUnitsFormatter
{
	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_1();

	public delegate void SwigDelegateOdDbUnitsFormatter_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatter_3(IntPtr value);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_4([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatter_5(double value);

	public delegate double SwigDelegateOdDbUnitsFormatter_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatter_7(double value);

	public delegate double SwigDelegateOdDbUnitsFormatter_8([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate double SwigDelegateOdDbUnitsFormatter_9(double wcsAngle);

	public delegate double SwigDelegateOdDbUnitsFormatter_10(double ucsAngle);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatter_11(IntPtr value);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_12([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_13(IntPtr wcsPt);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatter_14(IntPtr ucsPt);

	public delegate void SwigDelegateOdDbUnitsFormatter_15(IntPtr ucs2wcs);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUnitsFormatter_0 swigDelegate0;

	private SwigDelegateOdDbUnitsFormatter_1 swigDelegate1;

	private SwigDelegateOdDbUnitsFormatter_2 swigDelegate2;

	private SwigDelegateOdDbUnitsFormatter_3 swigDelegate3;

	private SwigDelegateOdDbUnitsFormatter_4 swigDelegate4;

	private SwigDelegateOdDbUnitsFormatter_5 swigDelegate5;

	private SwigDelegateOdDbUnitsFormatter_6 swigDelegate6;

	private SwigDelegateOdDbUnitsFormatter_7 swigDelegate7;

	private SwigDelegateOdDbUnitsFormatter_8 swigDelegate8;

	private SwigDelegateOdDbUnitsFormatter_9 swigDelegate9;

	private SwigDelegateOdDbUnitsFormatter_10 swigDelegate10;

	private SwigDelegateOdDbUnitsFormatter_11 swigDelegate11;

	private SwigDelegateOdDbUnitsFormatter_12 swigDelegate12;

	private SwigDelegateOdDbUnitsFormatter_13 swigDelegate13;

	private SwigDelegateOdDbUnitsFormatter_14 swigDelegate14;

	private SwigDelegateOdDbUnitsFormatter_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGeMatrix3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUnitsFormatter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUnitsFormatter obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbUnitsFormatter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbUnitsFormatter cast(OdRxObject pObj)
	{
		OdDbUnitsFormatter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_isASwigExplicitOdDbUnitsFormatter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_queryXSwigExplicitOdDbUnitsFormatter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbUnitsFormatter createObject()
	{
		OdDbUnitsFormatter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static string formatColor(OdCmColor value)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_formatColor(OdCmColor.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCmColor unformatColor(string string_)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_unformatColor(string_), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double toUserAngle(double wcsAngle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_toUserAngle(swigCPtr, wcsAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fromUserAngle(double ucsAngle)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_fromUserAngle(swigCPtr, ucsAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string formatPoint(OdGePoint3d value)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_formatPoint(swigCPtr, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d unformatPoint(string string_)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_unformatPoint(swigCPtr, string_), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d toUCS(OdGePoint3d wcsPt)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_toUCS(swigCPtr, OdGePoint3d.getCPtr(wcsPt)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d fromUCS(OdGePoint3d ucsPt)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_fromUCS(swigCPtr, OdGePoint3d.getCPtr(ucsPt)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void UCS2WCS(OdGeMatrix3d ucs2wcs)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_UCS2WCS(swigCPtr, OdGeMatrix3d.getCPtr(ucs2wcs));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbUnitsFormatter()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbUnitsFormatter(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUnitsFormatter) != GetType();
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
		if (SwigDerivedClassHasMethod("toUserAngle", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodtoUserAngle;
		}
		if (SwigDerivedClassHasMethod("fromUserAngle", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodfromUserAngle;
		}
		if (SwigDerivedClassHasMethod("formatPoint", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodformatPoint;
		}
		if (SwigDerivedClassHasMethod("unformatPoint", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodunformatPoint;
		}
		if (SwigDerivedClassHasMethod("toUCS", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodtoUCS;
		}
		if (SwigDerivedClassHasMethod("fromUCS", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodfromUCS;
		}
		if (SwigDerivedClassHasMethod("UCS2WCS", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodUCS2WCS;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUnitsFormatter));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatCmColor(IntPtr value)
	{
		return formatCmColor(ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(value, bOwn: false, bTryAddToTransaction: false));
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

	private double SwigDirectorMethodtoUserAngle(double wcsAngle)
	{
		return toUserAngle(wcsAngle);
	}

	private double SwigDirectorMethodfromUserAngle(double ucsAngle)
	{
		return fromUserAngle(ucsAngle);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatPoint(IntPtr value)
	{
		return formatPoint(new OdGePoint3d(value, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodunformatPoint([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(unformatPoint(string_)).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
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

	private IntPtr SwigDirectorMethodtoUCS(IntPtr wcsPt)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(toUCS(new OdGePoint3d(wcsPt, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
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

	private IntPtr SwigDirectorMethodfromUCS(IntPtr ucsPt)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(fromUCS(new OdGePoint3d(ucsPt, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
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

	private void SwigDirectorMethodUCS2WCS(IntPtr ucs2wcs)
	{
		try
		{
			UCS2WCS(new OdGeMatrix3d(ucs2wcs, cMemoryOwn: false));
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
}

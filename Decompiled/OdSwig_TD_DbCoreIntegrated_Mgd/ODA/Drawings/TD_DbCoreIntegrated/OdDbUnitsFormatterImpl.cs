using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUnitsFormatterImpl : OdDbUnitsFormatter
{
	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_1();

	public delegate void SwigDelegateOdDbUnitsFormatterImpl_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatterImpl_3(IntPtr value);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_4([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatterImpl_5(double value);

	public delegate double SwigDelegateOdDbUnitsFormatterImpl_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatterImpl_7(double value);

	public delegate double SwigDelegateOdDbUnitsFormatterImpl_8([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate double SwigDelegateOdDbUnitsFormatterImpl_9(double wcsAngle);

	public delegate double SwigDelegateOdDbUnitsFormatterImpl_10(double ucsAngle);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnitsFormatterImpl_11(IntPtr value);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_12([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_13(IntPtr wcsPt);

	public delegate IntPtr SwigDelegateOdDbUnitsFormatterImpl_14(IntPtr ucsPt);

	public delegate void SwigDelegateOdDbUnitsFormatterImpl_15(IntPtr ucs2wcs);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUnitsFormatterImpl_0 swigDelegate0;

	private SwigDelegateOdDbUnitsFormatterImpl_1 swigDelegate1;

	private SwigDelegateOdDbUnitsFormatterImpl_2 swigDelegate2;

	private SwigDelegateOdDbUnitsFormatterImpl_3 swigDelegate3;

	private SwigDelegateOdDbUnitsFormatterImpl_4 swigDelegate4;

	private SwigDelegateOdDbUnitsFormatterImpl_5 swigDelegate5;

	private SwigDelegateOdDbUnitsFormatterImpl_6 swigDelegate6;

	private SwigDelegateOdDbUnitsFormatterImpl_7 swigDelegate7;

	private SwigDelegateOdDbUnitsFormatterImpl_8 swigDelegate8;

	private SwigDelegateOdDbUnitsFormatterImpl_9 swigDelegate9;

	private SwigDelegateOdDbUnitsFormatterImpl_10 swigDelegate10;

	private SwigDelegateOdDbUnitsFormatterImpl_11 swigDelegate11;

	private SwigDelegateOdDbUnitsFormatterImpl_12 swigDelegate12;

	private SwigDelegateOdDbUnitsFormatterImpl_13 swigDelegate13;

	private SwigDelegateOdDbUnitsFormatterImpl_14 swigDelegate14;

	private SwigDelegateOdDbUnitsFormatterImpl_15 swigDelegate15;

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
	public OdDbUnitsFormatterImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUnitsFormatterImpl obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbUnitsFormatterImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbUnitsFormatterImpl()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbUnitsFormatterImpl(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUnitsFormatterImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbUnitsFormatterImpl cast(OdRxObject pObj)
	{
		OdDbUnitsFormatterImpl rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatterImpl>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_isASwigExplicitOdDbUnitsFormatterImpl(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_queryXSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbUnitsFormatterImpl createObject()
	{
		OdDbUnitsFormatterImpl rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatterImpl>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string formatCmColor(OdCmColorBase value)
	{
		string result = (SwigDerivedClassHasMethod("formatCmColor", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatCmColorSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdCmColorBase.getCPtr(value)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatCmColor(swigCPtr, OdCmColorBase.getCPtr(value)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdCmColorBase unformatCmColor(string string_)
	{
		OdCmColorBase result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(SwigDerivedClassHasMethod("unformatCmColor", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatCmColorSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, string_) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatCmColor(swigCPtr, string_), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatLinear(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatLinear", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatLinearSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, value) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatLinear(swigCPtr, value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatLinear(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatLinear", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatLinearSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, string_) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatLinear(swigCPtr, string_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatAngle(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatAngle", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatAngleSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, value) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatAngle(swigCPtr, value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatAngle(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatAngle", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatAngleSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, string_) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatAngle(swigCPtr, string_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double toUserAngle(double wcsAngle)
	{
		double result = (SwigDerivedClassHasMethod("toUserAngle", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_toUserAngleSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, wcsAngle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_toUserAngle(swigCPtr, wcsAngle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double fromUserAngle(double ucsAngle)
	{
		double result = (SwigDerivedClassHasMethod("fromUserAngle", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_fromUserAngleSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, ucsAngle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_fromUserAngle(swigCPtr, ucsAngle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatPoint(OdGePoint3d value)
	{
		string result = (SwigDerivedClassHasMethod("formatPoint", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatPointSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdGePoint3d.getCPtr(value)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_formatPoint(swigCPtr, OdGePoint3d.getCPtr(value)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint3d unformatPoint(string string_)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("unformatPoint", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatPointSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, string_) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_unformatPoint(swigCPtr, string_), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint3d toUCS(OdGePoint3d wcsPt)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("toUCS", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_toUCSSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdGePoint3d.getCPtr(wcsPt)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_toUCS(swigCPtr, OdGePoint3d.getCPtr(wcsPt)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint3d fromUCS(OdGePoint3d ucsPt)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("fromUCS", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_fromUCSSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdGePoint3d.getCPtr(ucsPt)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_fromUCS(swigCPtr, OdGePoint3d.getCPtr(ucsPt)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void UCS2WCS(OdGeMatrix3d ucs2wcs)
	{
		if (SwigDerivedClassHasMethod("UCS2WCS", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_UCS2WCSSwigExplicitOdDbUnitsFormatterImpl(swigCPtr, OdGeMatrix3d.getCPtr(ucs2wcs));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_UCS2WCS(swigCPtr, OdGeMatrix3d.getCPtr(ucs2wcs));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDatabase(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_setDatabase(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_getRealClassName(ptr);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatterImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUnitsFormatterImpl));
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

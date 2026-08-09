using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcUnitsFormatterImpl : OdPrcUnitsFormatter
{
	public delegate IntPtr SwigDelegateOdPrcUnitsFormatterImpl_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcUnitsFormatterImpl_1();

	public delegate void SwigDelegateOdPrcUnitsFormatterImpl_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcUnitsFormatterImpl_3(IntPtr value);

	public delegate IntPtr SwigDelegateOdPrcUnitsFormatterImpl_4([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcUnitsFormatterImpl_5(double value);

	public delegate double SwigDelegateOdPrcUnitsFormatterImpl_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcUnitsFormatterImpl_7(double value);

	public delegate double SwigDelegateOdPrcUnitsFormatterImpl_8([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPrcUnitsFormatterImpl_9(IntPtr value);

	public delegate IntPtr SwigDelegateOdPrcUnitsFormatterImpl_10([MarshalAs(UnmanagedType.LPWStr)] string string_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcUnitsFormatterImpl_0 swigDelegate0;

	private SwigDelegateOdPrcUnitsFormatterImpl_1 swigDelegate1;

	private SwigDelegateOdPrcUnitsFormatterImpl_2 swigDelegate2;

	private SwigDelegateOdPrcUnitsFormatterImpl_3 swigDelegate3;

	private SwigDelegateOdPrcUnitsFormatterImpl_4 swigDelegate4;

	private SwigDelegateOdPrcUnitsFormatterImpl_5 swigDelegate5;

	private SwigDelegateOdPrcUnitsFormatterImpl_6 swigDelegate6;

	private SwigDelegateOdPrcUnitsFormatterImpl_7 swigDelegate7;

	private SwigDelegateOdPrcUnitsFormatterImpl_8 swigDelegate8;

	private SwigDelegateOdPrcUnitsFormatterImpl_9 swigDelegate9;

	private SwigDelegateOdPrcUnitsFormatterImpl_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcUnitsFormatterImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcUnitsFormatterImpl obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcUnitsFormatterImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcUnitsFormatterImpl cast(OdRxObject pObj)
	{
		OdPrcUnitsFormatterImpl rXObject = Helpers.GetRXObject<OdPrcUnitsFormatterImpl>(OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_isASwigExplicitOdPrcUnitsFormatterImpl(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_queryXSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override string formatLinear(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatLinear", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatLinearSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, value) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatLinear(swigCPtr, value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatLinear(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatLinear", swigMethodTypes6) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatLinearSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, string_) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatLinear(swigCPtr, string_));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatAngle(double value)
	{
		string result = (SwigDerivedClassHasMethod("formatAngle", swigMethodTypes7) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatAngleSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, value) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatAngle(swigCPtr, value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double unformatAngle(string string_)
	{
		double result = (SwigDerivedClassHasMethod("unformatAngle", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatAngleSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, string_) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatAngle(swigCPtr, string_));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string formatPoint(OdGePoint3d value)
	{
		string result = (SwigDerivedClassHasMethod("formatPoint", swigMethodTypes9) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatPointSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, OdGePoint3d.getCPtr(value)) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatPoint(swigCPtr, OdGePoint3d.getCPtr(value)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint3d unformatPoint(string string_)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("unformatPoint", swigMethodTypes10) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatPointSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, string_) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatPoint(swigCPtr, string_), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDatabase(OdPrcFile db)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_setDatabase(swigCPtr, OdPrcFile.getCPtr(db));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string formatCmColor(OdCmColorBase value)
	{
		string result = (SwigDerivedClassHasMethod("formatCmColor", swigMethodTypes3) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatCmColorSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, OdCmColorBase.getCPtr(value)) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_formatCmColor(swigCPtr, OdCmColorBase.getCPtr(value)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdCmColorBase unformatCmColor(string string_)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(SwigDerivedClassHasMethod("unformatCmColor", swigMethodTypes4) ? OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatCmColorSwigExplicitOdPrcUnitsFormatterImpl(swigCPtr, string_) : OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_unformatCmColor(swigCPtr, string_), bOwn: true, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcUnitsFormatterImpl createObject()
	{
		OdPrcUnitsFormatterImpl rXObject = Helpers.GetRXObject<OdPrcUnitsFormatterImpl>(OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcUnitsFormatterImpl()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUnitsFormatterImpl(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcUnitsFormatterImpl) != GetType();
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
		if (SwigDerivedClassHasMethod("formatPoint", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodformatPoint;
		}
		if (SwigDerivedClassHasMethod("unformatPoint", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodunformatPoint;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcUnitsFormatterImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcUnitsFormatterImpl));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}

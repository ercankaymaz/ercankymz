using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPsPlotStyle : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPsPlotStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPsPlotStyle_1();

	public delegate void SwigDelegateOdPsPlotStyle_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPsPlotStyle_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPsPlotStyle_4();

	public delegate void SwigDelegateOdPsPlotStyle_5(IntPtr data);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPsPlotStyle_6();

	public delegate void SwigDelegateOdPsPlotStyle_7(IntPtr data);

	public delegate void SwigDelegateOdPsPlotStyle_8([MarshalAs(UnmanagedType.LPWStr)] string desc);

	public delegate void SwigDelegateOdPsPlotStyle_9([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate void SwigDelegateOdPsPlotStyle_10([MarshalAs(UnmanagedType.LPWStr)] string name);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPsPlotStyle_0 swigDelegate0;

	private SwigDelegateOdPsPlotStyle_1 swigDelegate1;

	private SwigDelegateOdPsPlotStyle_2 swigDelegate2;

	private SwigDelegateOdPsPlotStyle_3 swigDelegate3;

	private SwigDelegateOdPsPlotStyle_4 swigDelegate4;

	private SwigDelegateOdPsPlotStyle_5 swigDelegate5;

	private SwigDelegateOdPsPlotStyle_6 swigDelegate6;

	private SwigDelegateOdPsPlotStyle_7 swigDelegate7;

	private SwigDelegateOdPsPlotStyle_8 swigDelegate8;

	private SwigDelegateOdPsPlotStyle_9 swigDelegate9;

	private SwigDelegateOdPsPlotStyle_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdPsPlotStyleData) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdPsPlotStyleData) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPsPlotStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPsPlotStyle obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPsPlotStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdPsPlotStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPsPlotStyle(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdPsPlotStyle cast(OdRxObject pObj)
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_isASwigExplicitOdPsPlotStyle(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_queryXSwigExplicitOdPsPlotStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPsPlotStyle createObject()
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string name()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_name(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string description()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_description(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getData(OdPsPlotStyleData data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_getData(swigCPtr, OdPsPlotStyleData.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string localizedName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_localizedName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setData(OdPsPlotStyleData data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_setData(swigCPtr, OdPsPlotStyleData.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDescription(string desc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_setDescription(swigCPtr, desc);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setName(string name)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_setName(swigCPtr, name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLocalizedName(string name)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_setLocalizedName(swigCPtr, name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("getData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetData;
		}
		if (SwigDerivedClassHasMethod("localizedName", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodlocalizedName;
		}
		if (SwigDerivedClassHasMethod("setData", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetData;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("setLocalizedName", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetLocalizedName;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPsPlotStyle));
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
	private string SwigDirectorMethodname()
	{
		return name();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private void SwigDirectorMethodgetData(IntPtr data)
	{
		try
		{
			getData(new OdPsPlotStyleData(data, cMemoryOwn: false));
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
	private string SwigDirectorMethodlocalizedName()
	{
		return localizedName();
	}

	private void SwigDirectorMethodsetData(IntPtr data)
	{
		try
		{
			setData(new OdPsPlotStyleData(data, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDescription([MarshalAs(UnmanagedType.LPWStr)] string desc)
	{
		try
		{
			setDescription(desc);
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

	private void SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setName(name);
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

	private void SwigDirectorMethodsetLocalizedName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setLocalizedName(name);
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
}

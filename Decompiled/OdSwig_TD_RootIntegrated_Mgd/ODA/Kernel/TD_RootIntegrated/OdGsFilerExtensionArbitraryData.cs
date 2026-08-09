using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionArbitraryData : OdGsFilerExtension
{
	public delegate int SwigDelegateOdGsFilerExtensionArbitraryData_0();

	public delegate void SwigDelegateOdGsFilerExtensionArbitraryData_1([MarshalAs(UnmanagedType.LPWStr)] string pName, IntPtr pObject);

	public delegate IntPtr SwigDelegateOdGsFilerExtensionArbitraryData_2([MarshalAs(UnmanagedType.LPWStr)] string pName);

	public delegate bool SwigDelegateOdGsFilerExtensionArbitraryData_3([MarshalAs(UnmanagedType.LPWStr)] string pName);

	public delegate void SwigDelegateOdGsFilerExtensionArbitraryData_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFilerExtensionArbitraryData_0 swigDelegate0;

	private SwigDelegateOdGsFilerExtensionArbitraryData_1 swigDelegate1;

	private SwigDelegateOdGsFilerExtensionArbitraryData_2 swigDelegate2;

	private SwigDelegateOdGsFilerExtensionArbitraryData_3 swigDelegate3;

	private SwigDelegateOdGsFilerExtensionArbitraryData_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionArbitraryData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionArbitraryData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionArbitraryData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_typeSwigExplicitOdGsFilerExtensionArbitraryData(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionArbitraryData cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionArbitraryData result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionArbitraryData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setArbitraryData(string pName, OdRxObject pObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_setArbitraryData(swigCPtr, pName, OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getArbitraryData(string pName)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_getArbitraryData(swigCPtr, pName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasArbitraryData(string pName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_hasArbitraryData(swigCPtr, pName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearArbitraryData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_clearArbitraryData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerExtensionArbitraryData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionArbitraryData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerExtensionArbitraryData) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("setArbitraryData", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetArbitraryData;
		}
		if (SwigDerivedClassHasMethod("getArbitraryData", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetArbitraryData;
		}
		if (SwigDerivedClassHasMethod("hasArbitraryData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodhasArbitraryData;
		}
		if (SwigDerivedClassHasMethod("clearArbitraryData", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodclearArbitraryData;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionArbitraryData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerExtensionArbitraryData));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodsetArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName, IntPtr pObject)
	{
		try
		{
			setArbitraryData(pName, Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName)
	{
		return OdRxObject.getCPtr(getArbitraryData(pName)).Handle;
	}

	private bool SwigDirectorMethodhasArbitraryData([MarshalAs(UnmanagedType.LPWStr)] string pName)
	{
		return hasArbitraryData(pName);
	}

	private void SwigDirectorMethodclearArbitraryData()
	{
		try
		{
			clearArbitraryData();
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

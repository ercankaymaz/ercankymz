using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxClass : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxClass_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxClass_1();

	public delegate void SwigDelegateOdRxClass_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxClass_3();

	public delegate bool SwigDelegateOdRxClass_4(IntPtr pClass);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxClass_0 swigDelegate0;

	private SwigDelegateOdRxClass_1 swigDelegate1;

	private SwigDelegateOdRxClass_2 swigDelegate2;

	private SwigDelegateOdRxClass_3 swigDelegate3;

	private SwigDelegateOdRxClass_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxClass) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxClass(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxClass obj)
	{
		if (!(obj == null))
		{
			return obj.swigCPtr;
		}
		return new HandleRef(null, IntPtr.Zero);
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxClass(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdRxClass()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxClass(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdRxClass cast(OdRxObject pObj)
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_isASwigExplicitOdRxClass(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_queryXSwigExplicitOdRxClass(swigCPtr, getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_queryX(swigCPtr, getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void rxInit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_rxInit__SWIG_0();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void rxInit(TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegate appNameChangeFunc)
	{
		TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegateNative appNameChangeFuncPtrDelegateNative = null;
		if (appNameChangeFunc != null)
		{
			appNameChangeFuncPtrDelegateNative = delegate(IntPtr classObj, IntPtr newAppName, int saveVer)
			{
				string newAppName2 = OdString2StringConvHelper.OdStringToString(newAppName);
				string text = newAppName2;
				try
				{
					appNameChangeFunc(OdMarshalHelper.PtrToObject<OdRxClass>(classObj), ref newAppName2, saveVer);
				}
				finally
				{
					if (text != newAppName2)
					{
						OdString2StringConvHelper.AssignStringToOdString(newAppName, newAppName2);
					}
				}
			};
		}
		IntPtr jarg = ((appNameChangeFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(appNameChangeFuncPtrDelegateNative));
		DelegateHolder.Add(appNameChangeFuncPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_rxInit__SWIG_1(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void rxUninit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_rxUninit();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject addX(OdRxClass pProtocolClass, OdRxObject pProtocolObject)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_addX(swigCPtr, getCPtr(pProtocolClass), OdRxObject.getCPtr(pProtocolObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject getX(OdRxClass pProtocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_getX(swigCPtr, getCPtr(pProtocolClass)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject delX(OdRxClass pProtocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_delX(swigCPtr, getCPtr(pProtocolClass)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject create()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("create", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_createSwigExplicitOdRxClass(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_create(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public string appName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_appName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegate appNameCallbackPtr()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_appNameCallbackPtr(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(OdRxClass classObj, ref string newAppName, int saveVer)
			{
				TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegateNative obj = Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegateNative)) as TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegateNative;
				IntPtr intPtr = OdString2StringConvHelper.StringToOdString(newAppName);
				obj(OdMarshalHelper.ObjectToPtr<OdRxClass>(classObj), intPtr, saveVer);
				newAppName = OdString2StringConvHelper.OdStringToString(intPtr);
			};
		}
		return result;
	}

	public string dxfName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_dxfName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string name()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_name(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public DwgVersion getClassVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_getClassVersion__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion getClassVersion()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_getClassVersion__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public uint proxyFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_proxyFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDerivedFrom(OdRxClass pClass)
	{
		bool result = (SwigDerivedClassHasMethod("isDerivedFrom", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_isDerivedFromSwigExplicitOdRxClass(swigCPtr, getCPtr(pClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_isDerivedFrom(swigCPtr, getCPtr(pClass)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxClass myParent()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_myParent(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxModule module()
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_module(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint customFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_customFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxMemberCollection members()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_members(swigCPtr);
		OdRxMemberCollection result = ((intPtr == IntPtr.Zero) ? null : new OdRxMemberCollection(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxAttributeCollection attributes()
	{
		OdRxAttributeCollection result = new OdRxAttributeCollection(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_attributes__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass createObject()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool Equals(object obj)
	{
		OdRxClass odRxClass = obj as OdRxClass;
		if (odRxClass == null)
		{
			return false;
		}
		return isEqualTo(odRxClass);
	}

	public static bool operator ==(OdRxClass a, OdRxClass b)
	{
		if ((object)a == b)
		{
			return true;
		}
		return a.Equals(b);
	}

	public static bool operator !=(OdRxClass a, OdRxClass b)
	{
		return !(a == b);
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
		if (SwigDerivedClassHasMethod("create", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreate;
		}
		if (SwigDerivedClassHasMethod("isDerivedFrom", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisDerivedFrom;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxClass_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxClass));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return getCPtr(isA()).Handle;
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

	private IntPtr SwigDirectorMethodcreate()
	{
		return OdRxObject.getCPtr(create()).Handle;
	}

	private bool SwigDirectorMethodisDerivedFrom(IntPtr pClass)
	{
		return isDerivedFrom(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false));
	}
}

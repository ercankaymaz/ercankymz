using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDynamicLinker : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDynamicLinker(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDynamicLinker obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDynamicLinker(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxDynamicLinker cast(OdRxObject pObj)
	{
		OdRxDynamicLinker rXObject = Helpers.GetRXObject<OdRxDynamicLinker>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDynamicLinker createObject()
	{
		OdRxDynamicLinker rXObject = Helpers.GetRXObject<OdRxDynamicLinker>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void addReactor(OdRxDLinkerReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_addReactor(swigCPtr, OdRxDLinkerReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeReactor(OdRxDLinkerReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_removeReactor(swigCPtr, OdRxDLinkerReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxModule loadModule(string moduleFileName, bool silent)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadModule__SWIG_0(swigCPtr, moduleFileName, silent), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadModule(string moduleFileName)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadModule__SWIG_1(swigCPtr, moduleFileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool unloadModule(string moduleFileName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_unloadModule(swigCPtr, moduleFileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool unloadUnreferenced()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_unloadUnreferenced(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxModule loadApp(string applicationName, bool silent)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadApp__SWIG_0(swigCPtr, applicationName, silent), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadApp(string applicationName)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadApp__SWIG_1(swigCPtr, applicationName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadApp(string applicationName, OdaApp_LoadReasons loadReason, bool silent)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadApp__SWIG_2(swigCPtr, applicationName, (int)loadReason, silent), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadApp(string applicationName, OdaApp_LoadReasons loadReason)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadApp__SWIG_3(swigCPtr, applicationName, (int)loadReason), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxSystemServices sysServices()
	{
		OdRxSystemServices rXObject = Helpers.GetRXObject<OdRxSystemServices>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_sysServices(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxDictionary sysRegistry()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_sysRegistry(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadModuleObj(OdRxModule pModuleObj, bool bSilent)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadModuleObj__SWIG_0(swigCPtr, OdRxModule.getCPtr(pModuleObj), bSilent), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxModule loadModuleObj(OdRxModule pModuleObj)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_loadModuleObj__SWIG_1(swigCPtr, OdRxModule.getCPtr(pModuleObj)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int getModuleCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_getModuleCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxModule getModule(int index, ref string key)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(key);
		IntPtr intPtr = jarg;
		try
		{
			OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_getModule__SWIG_0(swigCPtr, index, ref jarg), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg != intPtr)
			{
				key = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdRxModule getModule(string key)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_getModule__SWIG_1(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDynamicLinker_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

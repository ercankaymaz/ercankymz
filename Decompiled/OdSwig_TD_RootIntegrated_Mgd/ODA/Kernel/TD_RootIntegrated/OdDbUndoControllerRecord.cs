using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbUndoControllerRecord : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbUndoControllerRecord_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUndoControllerRecord_1();

	public delegate void SwigDelegateOdDbUndoControllerRecord_2(IntPtr pSource);

	public delegate uint SwigDelegateOdDbUndoControllerRecord_3();

	public delegate ulong SwigDelegateOdDbUndoControllerRecord_4();

	public delegate IntPtr SwigDelegateOdDbUndoControllerRecord_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUndoControllerRecord_0 swigDelegate0;

	private SwigDelegateOdDbUndoControllerRecord_1 swigDelegate1;

	private SwigDelegateOdDbUndoControllerRecord_2 swigDelegate2;

	private SwigDelegateOdDbUndoControllerRecord_3 swigDelegate3;

	private SwigDelegateOdDbUndoControllerRecord_4 swigDelegate4;

	private SwigDelegateOdDbUndoControllerRecord_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUndoControllerRecord(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUndoControllerRecord obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbUndoControllerRecord(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbUndoControllerRecord()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbUndoControllerRecord(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUndoControllerRecord) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbUndoControllerRecord cast(OdRxObject pObj)
	{
		OdDbUndoControllerRecord rXObject = Helpers.GetRXObject<OdDbUndoControllerRecord>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_isASwigExplicitOdDbUndoControllerRecord(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_queryXSwigExplicitOdDbUndoControllerRecord(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbUndoControllerRecord createObject()
	{
		OdDbUndoControllerRecord rXObject = Helpers.GetRXObject<OdDbUndoControllerRecord>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint options()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_options(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong size()
	{
		ulong result = (SwigDerivedClassHasMethod("size", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_sizeSwigExplicitOdDbUndoControllerRecord(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_size(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdStreamBuf getData()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("getData", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_getDataSwigExplicitOdDbUndoControllerRecord(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_getData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("options", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodoptions;
		}
		if (SwigDerivedClassHasMethod("size", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsize;
		}
		if (SwigDerivedClassHasMethod("getData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetData;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoControllerRecord_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUndoControllerRecord));
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

	private uint SwigDirectorMethodoptions()
	{
		return options();
	}

	private ulong SwigDirectorMethodsize()
	{
		return size();
	}

	private IntPtr SwigDirectorMethodgetData()
	{
		return OdStreamBuf.getCPtr(getData()).Handle;
	}
}

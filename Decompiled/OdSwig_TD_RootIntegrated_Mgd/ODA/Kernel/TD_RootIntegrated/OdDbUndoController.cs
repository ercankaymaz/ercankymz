using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbUndoController : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbUndoController_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUndoController_1();

	public delegate void SwigDelegateOdDbUndoController_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbUndoController_3(IntPtr pStream, ulong nSize, uint opt);

	public delegate void SwigDelegateOdDbUndoController_4(IntPtr pStream, ulong nSize);

	public delegate bool SwigDelegateOdDbUndoController_5();

	public delegate uint SwigDelegateOdDbUndoController_6(IntPtr pStream);

	public delegate IntPtr SwigDelegateOdDbUndoController_7();

	public delegate void SwigDelegateOdDbUndoController_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUndoController_0 swigDelegate0;

	private SwigDelegateOdDbUndoController_1 swigDelegate1;

	private SwigDelegateOdDbUndoController_2 swigDelegate2;

	private SwigDelegateOdDbUndoController_3 swigDelegate3;

	private SwigDelegateOdDbUndoController_4 swigDelegate4;

	private SwigDelegateOdDbUndoController_5 swigDelegate5;

	private SwigDelegateOdDbUndoController_6 swigDelegate6;

	private SwigDelegateOdDbUndoController_7 swigDelegate7;

	private SwigDelegateOdDbUndoController_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(ulong),
		typeof(uint)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUndoController(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUndoController obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbUndoController(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbUndoController cast(OdRxObject pObj)
	{
		OdDbUndoController rXObject = Helpers.GetRXObject<OdDbUndoController>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_isASwigExplicitOdDbUndoController(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_queryXSwigExplicitOdDbUndoController(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbUndoController createObject()
	{
		OdDbUndoController rXObject = Helpers.GetRXObject<OdDbUndoController>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void pushData(OdStreamBuf pStream, ulong nSize, uint opt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_pushData__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStream), nSize, opt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushData(OdStreamBuf pStream, ulong nSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_pushData__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStream), nSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint popData(OdStreamBuf pStream)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_popData(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxIterator newRecordStackIterator()
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_newRecordStackIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void clearData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_clearData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbUndoController()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbUndoController(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUndoController) != GetType();
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
		if (SwigDerivedClassHasMethod("pushData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodpushData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushData", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodpushData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hasData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodhasData;
		}
		if (SwigDerivedClassHasMethod("popData", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodpopData;
		}
		if (SwigDerivedClassHasMethod("newRecordStackIterator", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodnewRecordStackIterator;
		}
		if (SwigDerivedClassHasMethod("clearData", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodclearData;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUndoController_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUndoController));
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

	private void SwigDirectorMethodpushData__SWIG_0(IntPtr pStream, ulong nSize, uint opt)
	{
		try
		{
			pushData(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), nSize, opt);
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

	private void SwigDirectorMethodpushData__SWIG_1(IntPtr pStream, ulong nSize)
	{
		try
		{
			pushData(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), nSize);
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

	private bool SwigDirectorMethodhasData()
	{
		return hasData();
	}

	private uint SwigDirectorMethodpopData(IntPtr pStream)
	{
		return popData(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodnewRecordStackIterator()
	{
		return OdRxIterator.getCPtr(newRecordStackIterator()).Handle;
	}

	private void SwigDirectorMethodclearData()
	{
		try
		{
			clearData();
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

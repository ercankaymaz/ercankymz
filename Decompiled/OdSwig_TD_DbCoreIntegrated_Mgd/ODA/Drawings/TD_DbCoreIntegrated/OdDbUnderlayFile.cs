using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUnderlayFile : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbUnderlayFile_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUnderlayFile_1();

	public delegate void SwigDelegateOdDbUnderlayFile_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbUnderlayFile_3();

	public delegate IntPtr SwigDelegateOdDbUnderlayFile_4(int i);

	public delegate IntPtr SwigDelegateOdDbUnderlayFile_5([MarshalAs(UnmanagedType.LPWStr)] string name);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUnderlayFile_0 swigDelegate0;

	private SwigDelegateOdDbUnderlayFile_1 swigDelegate1;

	private SwigDelegateOdDbUnderlayFile_2 swigDelegate2;

	private SwigDelegateOdDbUnderlayFile_3 swigDelegate3;

	private SwigDelegateOdDbUnderlayFile_4 swigDelegate4;

	private SwigDelegateOdDbUnderlayFile_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUnderlayFile(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUnderlayFile obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbUnderlayFile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbUnderlayFile cast(OdRxObject pObj)
	{
		OdDbUnderlayFile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayFile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_isASwigExplicitOdDbUnderlayFile(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_queryXSwigExplicitOdDbUnderlayFile(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbUnderlayFile createObject()
	{
		OdDbUnderlayFile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayFile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int getItemCount()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_getItemCount(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbUnderlayItem getItem(int i)
	{
		OdDbUnderlayItem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayItem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_getItem__SWIG_0(swigCPtr, i), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbUnderlayItem getItem(string name)
	{
		OdDbUnderlayItem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayItem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_getItem__SWIG_1(swigCPtr, name), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbUnderlayFile()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbUnderlayFile(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUnderlayFile) != GetType();
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
		if (SwigDerivedClassHasMethod("getItemCount", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetItemCount;
		}
		if (SwigDerivedClassHasMethod("getItem", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetItem__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getItem", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetItem__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayFile_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUnderlayFile));
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

	private int SwigDirectorMethodgetItemCount()
	{
		return getItemCount();
	}

	private IntPtr SwigDirectorMethodgetItem__SWIG_0(int i)
	{
		return OdDbUnderlayItem.getCPtr(getItem(i)).Handle;
	}

	private IntPtr SwigDirectorMethodgetItem__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return OdDbUnderlayItem.getCPtr(getItem(name)).Handle;
	}
}

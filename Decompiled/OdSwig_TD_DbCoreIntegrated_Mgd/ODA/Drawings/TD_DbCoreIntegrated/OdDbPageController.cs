using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPageController : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbPageController_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdDbPageController_1();

	public delegate void SwigDelegateOdDbPageController_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPageController_3();

	public delegate IntPtr SwigDelegateOdDbPageController_4(long key);

	public delegate bool SwigDelegateOdDbPageController_5(long key, IntPtr pStreamBuf);

	public delegate void SwigDelegateOdDbPageController_6(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbPageController_7();

	public delegate int SwigDelegateOdDbPageController_8(IntPtr objectId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPageController_0 swigDelegate0;

	private SwigDelegateOdDbPageController_1 swigDelegate1;

	private SwigDelegateOdDbPageController_2 swigDelegate2;

	private SwigDelegateOdDbPageController_3 swigDelegate3;

	private SwigDelegateOdDbPageController_4 swigDelegate4;

	private SwigDelegateOdDbPageController_5 swigDelegate5;

	private SwigDelegateOdDbPageController_6 swigDelegate6;

	private SwigDelegateOdDbPageController_7 swigDelegate7;

	private SwigDelegateOdDbPageController_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(long) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(long).MakeByRefType(),
		typeof(OdStreamBuf)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObjectId) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPageController(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPageController obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPageController(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbPageController()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPageController(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public virtual int pagingType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_pagingType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdStreamBuf read(long key)
	{
		OdStreamBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_read(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool write(out long key, OdStreamBuf pStreamBuf)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_write(swigCPtr, out key, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDatabase(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_setDatabase(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult subPage(OdDbObjectId objectId)
	{
		int result = (SwigDerivedClassHasMethod("subPage", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_subPageSwigExplicitOdDbPageController(swigCPtr, OdDbObjectId.getCPtr(objectId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_subPage(swigCPtr, OdDbObjectId.getCPtr(objectId)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("pagingType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodpagingType;
		}
		if (SwigDerivedClassHasMethod("read", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodread;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodwrite;
		}
		if (SwigDerivedClassHasMethod("setDatabase", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetDatabase;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("subPage", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsubPage;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPageController_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPageController));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private int SwigDirectorMethodpagingType()
	{
		return pagingType();
	}

	private IntPtr SwigDirectorMethodread(long key)
	{
		return OdStreamBuf.getCPtr(read(key)).Handle;
	}

	private bool SwigDirectorMethodwrite(long key, IntPtr pStreamBuf)
	{
		return write(out key, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetDatabase(IntPtr pDb)
	{
		try
		{
			setDatabase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private int SwigDirectorMethodsubPage(IntPtr objectId)
	{
		return (int)subPage(new OdDbObjectId(objectId, cMemoryOwn: false));
	}
}

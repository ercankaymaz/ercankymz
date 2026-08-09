using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbHyperlinkCollection : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbHyperlinkCollection_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbHyperlinkCollection_1();

	public delegate void SwigDelegateOdDbHyperlinkCollection_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbHyperlinkCollection_3([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation);

	public delegate void SwigDelegateOdDbHyperlinkCollection_4([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate void SwigDelegateOdDbHyperlinkCollection_5([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation);

	public delegate void SwigDelegateOdDbHyperlinkCollection_6([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate void SwigDelegateOdDbHyperlinkCollection_7(int hyperlinkIndex, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation);

	public delegate void SwigDelegateOdDbHyperlinkCollection_8(int hyperlinkIndex, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description);

	public delegate void SwigDelegateOdDbHyperlinkCollection_9();

	public delegate void SwigDelegateOdDbHyperlinkCollection_10();

	public delegate void SwigDelegateOdDbHyperlinkCollection_11(int hyperlinkIndex);

	public delegate int SwigDelegateOdDbHyperlinkCollection_12();

	public delegate IntPtr SwigDelegateOdDbHyperlinkCollection_13(int hyperlinkIndex);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbHyperlinkCollection_0 swigDelegate0;

	private SwigDelegateOdDbHyperlinkCollection_1 swigDelegate1;

	private SwigDelegateOdDbHyperlinkCollection_2 swigDelegate2;

	private SwigDelegateOdDbHyperlinkCollection_3 swigDelegate3;

	private SwigDelegateOdDbHyperlinkCollection_4 swigDelegate4;

	private SwigDelegateOdDbHyperlinkCollection_5 swigDelegate5;

	private SwigDelegateOdDbHyperlinkCollection_6 swigDelegate6;

	private SwigDelegateOdDbHyperlinkCollection_7 swigDelegate7;

	private SwigDelegateOdDbHyperlinkCollection_8 swigDelegate8;

	private SwigDelegateOdDbHyperlinkCollection_9 swigDelegate9;

	private SwigDelegateOdDbHyperlinkCollection_10 swigDelegate10;

	private SwigDelegateOdDbHyperlinkCollection_11 swigDelegate11;

	private SwigDelegateOdDbHyperlinkCollection_12 swigDelegate12;

	private SwigDelegateOdDbHyperlinkCollection_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(int),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(int),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(int) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHyperlinkCollection(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHyperlinkCollection obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbHyperlinkCollection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbHyperlinkCollection cast(OdRxObject pObj)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_isASwigExplicitOdDbHyperlinkCollection(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_queryXSwigExplicitOdDbHyperlinkCollection(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbHyperlinkCollection createObject()
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbHyperlinkCollection()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHyperlinkCollection(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbHyperlinkCollection) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void addHead(string name, string description, string subLocation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addHead__SWIG_0(swigCPtr, name, description, subLocation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addHead(string name, string description)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addHead__SWIG_1(swigCPtr, name, description);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addTail(string name, string description, string subLocation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addTail__SWIG_0(swigCPtr, name, description, subLocation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addTail(string name, string description)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addTail__SWIG_1(swigCPtr, name, description);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addAt(int hyperlinkIndex, string name, string description, string subLocation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addAt__SWIG_0(swigCPtr, hyperlinkIndex, name, description, subLocation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addAt(int hyperlinkIndex, string name, string description)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_addAt__SWIG_1(swigCPtr, hyperlinkIndex, name, description);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeHead()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_removeHead(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeTail()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_removeTail(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeAt(int hyperlinkIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_removeAt(swigCPtr, hyperlinkIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int count()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_count(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbHyperlink item(int hyperlinkIndex)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_item(swigCPtr, hyperlinkIndex);
		OdDbHyperlink result = ((intPtr == IntPtr.Zero) ? null : new OdDbHyperlink(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("addHead", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddHead__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addHead", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodaddHead__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addTail", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodaddTail__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addTail", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodaddTail__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addAt", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodaddAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addAt", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaddAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("removeHead", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodremoveHead;
		}
		if (SwigDerivedClassHasMethod("removeTail", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodremoveTail;
		}
		if (SwigDerivedClassHasMethod("removeAt", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodremoveAt;
		}
		if (SwigDerivedClassHasMethod("count", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcount;
		}
		if (SwigDerivedClassHasMethod("item", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoditem;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlinkCollection_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHyperlinkCollection));
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

	private void SwigDirectorMethodaddHead__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation)
	{
		try
		{
			addHead(name, description, subLocation);
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

	private void SwigDirectorMethodaddHead__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description)
	{
		try
		{
			addHead(name, description);
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

	private void SwigDirectorMethodaddTail__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation)
	{
		try
		{
			addTail(name, description, subLocation);
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

	private void SwigDirectorMethodaddTail__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description)
	{
		try
		{
			addTail(name, description);
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

	private void SwigDirectorMethodaddAt__SWIG_0(int hyperlinkIndex, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description, [MarshalAs(UnmanagedType.LPWStr)] string subLocation)
	{
		try
		{
			addAt(hyperlinkIndex, name, description, subLocation);
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

	private void SwigDirectorMethodaddAt__SWIG_1(int hyperlinkIndex, [MarshalAs(UnmanagedType.LPWStr)] string name, [MarshalAs(UnmanagedType.LPWStr)] string description)
	{
		try
		{
			addAt(hyperlinkIndex, name, description);
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

	private void SwigDirectorMethodremoveHead()
	{
		try
		{
			removeHead();
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

	private void SwigDirectorMethodremoveTail()
	{
		try
		{
			removeTail();
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

	private void SwigDirectorMethodremoveAt(int hyperlinkIndex)
	{
		try
		{
			removeAt(hyperlinkIndex);
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

	private int SwigDirectorMethodcount()
	{
		return count();
	}

	private IntPtr SwigDirectorMethoditem(int hyperlinkIndex)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbHyperlink.getCPtr(item(hyperlinkIndex)).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}

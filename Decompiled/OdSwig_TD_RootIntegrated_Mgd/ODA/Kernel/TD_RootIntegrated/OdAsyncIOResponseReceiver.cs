using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAsyncIOResponseReceiver : OdRxObject
{
	public delegate IntPtr SwigDelegateOdAsyncIOResponseReceiver_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdAsyncIOResponseReceiver_1();

	public delegate void SwigDelegateOdAsyncIOResponseReceiver_2(IntPtr pSource);

	public delegate void SwigDelegateOdAsyncIOResponseReceiver_3(ulong requestDescriptor, ulong fileDescriptor, int status);

	public delegate void SwigDelegateOdAsyncIOResponseReceiver_4(ulong requestDescriptor, IntPtr pData, uint actualDataSize, int status);

	public delegate void SwigDelegateOdAsyncIOResponseReceiver_5(ulong requestDescriptor, int status);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdAsyncIOResponseReceiver_0 swigDelegate0;

	private SwigDelegateOdAsyncIOResponseReceiver_1 swigDelegate1;

	private SwigDelegateOdAsyncIOResponseReceiver_2 swigDelegate2;

	private SwigDelegateOdAsyncIOResponseReceiver_3 swigDelegate3;

	private SwigDelegateOdAsyncIOResponseReceiver_4 swigDelegate4;

	private SwigDelegateOdAsyncIOResponseReceiver_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(ulong),
		typeof(ulong),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(ulong),
		typeof(byte[]),
		typeof(uint),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(ulong),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAsyncIOResponseReceiver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAsyncIOResponseReceiver obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAsyncIOResponseReceiver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdAsyncIOResponseReceiver cast(OdRxObject pObj)
	{
		OdAsyncIOResponseReceiver rXObject = Helpers.GetRXObject<OdAsyncIOResponseReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_isASwigExplicitOdAsyncIOResponseReceiver(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_queryXSwigExplicitOdAsyncIOResponseReceiver(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAsyncIOResponseReceiver createObject()
	{
		OdAsyncIOResponseReceiver rXObject = Helpers.GetRXObject<OdAsyncIOResponseReceiver>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void receiveOpenRequestResponse(ulong requestDescriptor, ulong fileDescriptor, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_receiveOpenRequestResponse(swigCPtr, requestDescriptor, fileDescriptor, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveReadRequestResponse(ulong requestDescriptor, byte[] pData, uint actualDataSize, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_receiveReadRequestResponse(swigCPtr, requestDescriptor, Helpers.MarshalbyteFixedArray(pData), actualDataSize, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveWriteRequestResponse(ulong requestDescriptor, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_receiveWriteRequestResponse(swigCPtr, requestDescriptor, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("receiveOpenRequestResponse", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodreceiveOpenRequestResponse;
		}
		if (SwigDerivedClassHasMethod("receiveReadRequestResponse", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodreceiveReadRequestResponse;
		}
		if (SwigDerivedClassHasMethod("receiveWriteRequestResponse", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodreceiveWriteRequestResponse;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOResponseReceiver_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAsyncIOResponseReceiver));
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

	private void SwigDirectorMethodreceiveOpenRequestResponse(ulong requestDescriptor, ulong fileDescriptor, int status)
	{
		try
		{
			receiveOpenRequestResponse(requestDescriptor, fileDescriptor, (OdAsyncIO_OdAsyncIOResult)status);
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

	private void SwigDirectorMethodreceiveReadRequestResponse(ulong requestDescriptor, IntPtr pData, uint actualDataSize, int status)
	{
		try
		{
			receiveReadRequestResponse(requestDescriptor, Helpers.UnMarshalbyteFixedArray(pData), actualDataSize, (OdAsyncIO_OdAsyncIOResult)status);
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

	private void SwigDirectorMethodreceiveWriteRequestResponse(ulong requestDescriptor, int status)
	{
		try
		{
			receiveWriteRequestResponse(requestDescriptor, (OdAsyncIO_OdAsyncIOResult)status);
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAsyncIOService : OdRxObject
{
	public delegate IntPtr SwigDelegateOdAsyncIOService_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdAsyncIOService_1();

	public delegate void SwigDelegateOdAsyncIOService_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdAsyncIOService_3();

	public delegate ulong SwigDelegateOdAsyncIOService_4(IntPtr pReceiver);

	public delegate void SwigDelegateOdAsyncIOService_5(ulong receiverDescriptor);

	public delegate void SwigDelegateOdAsyncIOService_6(ulong receiverDescriptor, ulong requestDescriptor, ulong fileDescriptor, int status);

	public delegate void SwigDelegateOdAsyncIOService_7(ulong receiverDescriptor, ulong requestDescriptor, IntPtr pData, uint actualDataSize, int status);

	public delegate void SwigDelegateOdAsyncIOService_8(ulong receiverDescriptor, ulong requestDescriptor, int status);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdAsyncIOService_0 swigDelegate0;

	private SwigDelegateOdAsyncIOService_1 swigDelegate1;

	private SwigDelegateOdAsyncIOService_2 swigDelegate2;

	private SwigDelegateOdAsyncIOService_3 swigDelegate3;

	private SwigDelegateOdAsyncIOService_4 swigDelegate4;

	private SwigDelegateOdAsyncIOService_5 swigDelegate5;

	private SwigDelegateOdAsyncIOService_6 swigDelegate6;

	private SwigDelegateOdAsyncIOService_7 swigDelegate7;

	private SwigDelegateOdAsyncIOService_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdAsyncIOResponseReceiver) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(ulong),
		typeof(ulong),
		typeof(ulong),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	private static Type[] swigMethodTypes7 = new Type[5]
	{
		typeof(ulong),
		typeof(ulong),
		typeof(byte[]),
		typeof(uint),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(ulong),
		typeof(ulong),
		typeof(OdAsyncIO_OdAsyncIOResult)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAsyncIOService(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAsyncIOService obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAsyncIOService(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdAsyncIOService cast(OdRxObject pObj)
	{
		OdAsyncIOService rXObject = Helpers.GetRXObject<OdAsyncIOService>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_isASwigExplicitOdAsyncIOService(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_queryXSwigExplicitOdAsyncIOService(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAsyncIOService createObject()
	{
		OdAsyncIOService rXObject = Helpers.GetRXObject<OdAsyncIOService>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdAsyncIORequestHandler getRequestHandler()
	{
		OdAsyncIORequestHandler rXObject = Helpers.GetRXObject<OdAsyncIORequestHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_getRequestHandler(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ulong registerResponseReceiver(OdAsyncIOResponseReceiver pReceiver)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_registerResponseReceiver(swigCPtr, OdAsyncIOResponseReceiver.getCPtr(pReceiver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void unregisterResponseReceiver(ulong receiverDescriptor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_unregisterResponseReceiver(swigCPtr, receiverDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveOpenRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, ulong fileDescriptor, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_receiveOpenRequestResponse(swigCPtr, receiverDescriptor, requestDescriptor, fileDescriptor, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveReadRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, byte[] pData, uint actualDataSize, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_receiveReadRequestResponse(swigCPtr, receiverDescriptor, requestDescriptor, Helpers.MarshalbyteFixedArray(pData), actualDataSize, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveWriteRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, OdAsyncIO_OdAsyncIOResult status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_receiveWriteRequestResponse(swigCPtr, receiverDescriptor, requestDescriptor, (int)status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getRequestHandler", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetRequestHandler;
		}
		if (SwigDerivedClassHasMethod("registerResponseReceiver", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodregisterResponseReceiver;
		}
		if (SwigDerivedClassHasMethod("unregisterResponseReceiver", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodunregisterResponseReceiver;
		}
		if (SwigDerivedClassHasMethod("receiveOpenRequestResponse", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodreceiveOpenRequestResponse;
		}
		if (SwigDerivedClassHasMethod("receiveReadRequestResponse", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodreceiveReadRequestResponse;
		}
		if (SwigDerivedClassHasMethod("receiveWriteRequestResponse", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreceiveWriteRequestResponse;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIOService_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAsyncIOService));
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

	private IntPtr SwigDirectorMethodgetRequestHandler()
	{
		return OdAsyncIORequestHandler.getCPtr(getRequestHandler()).Handle;
	}

	private ulong SwigDirectorMethodregisterResponseReceiver(IntPtr pReceiver)
	{
		return registerResponseReceiver(Helpers.GetRXObject<OdAsyncIOResponseReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodunregisterResponseReceiver(ulong receiverDescriptor)
	{
		try
		{
			unregisterResponseReceiver(receiverDescriptor);
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

	private void SwigDirectorMethodreceiveOpenRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, ulong fileDescriptor, int status)
	{
		try
		{
			receiveOpenRequestResponse(receiverDescriptor, requestDescriptor, fileDescriptor, (OdAsyncIO_OdAsyncIOResult)status);
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

	private void SwigDirectorMethodreceiveReadRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, IntPtr pData, uint actualDataSize, int status)
	{
		try
		{
			receiveReadRequestResponse(receiverDescriptor, requestDescriptor, Helpers.UnMarshalbyteFixedArray(pData), actualDataSize, (OdAsyncIO_OdAsyncIOResult)status);
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

	private void SwigDirectorMethodreceiveWriteRequestResponse(ulong receiverDescriptor, ulong requestDescriptor, int status)
	{
		try
		{
			receiveWriteRequestResponse(receiverDescriptor, requestDescriptor, (OdAsyncIO_OdAsyncIOResult)status);
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

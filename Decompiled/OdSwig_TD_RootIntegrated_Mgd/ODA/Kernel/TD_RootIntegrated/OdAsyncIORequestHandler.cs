using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAsyncIORequestHandler : OdRxObject
{
	public delegate IntPtr SwigDelegateOdAsyncIORequestHandler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdAsyncIORequestHandler_1();

	public delegate void SwigDelegateOdAsyncIORequestHandler_2(IntPtr pSource);

	public delegate ulong SwigDelegateOdAsyncIORequestHandler_3();

	public delegate void SwigDelegateOdAsyncIORequestHandler_4(IntPtr request);

	public delegate void SwigDelegateOdAsyncIORequestHandler_5(ulong fileDescriptor);

	public delegate void SwigDelegateOdAsyncIORequestHandler_6(IntPtr request);

	public delegate void SwigDelegateOdAsyncIORequestHandler_7(IntPtr request);

	public delegate int SwigDelegateOdAsyncIORequestHandler_8(ulong requestDescriptor, ulong pOpenedFileDescriptor);

	public delegate int SwigDelegateOdAsyncIORequestHandler_9(ulong requestDescriptor);

	public delegate void SwigDelegateOdAsyncIORequestHandler_10(ulong requestDescriptor);

	public delegate void SwigDelegateOdAsyncIORequestHandler_11(ulong requestDescriptor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdAsyncIORequestHandler_0 swigDelegate0;

	private SwigDelegateOdAsyncIORequestHandler_1 swigDelegate1;

	private SwigDelegateOdAsyncIORequestHandler_2 swigDelegate2;

	private SwigDelegateOdAsyncIORequestHandler_3 swigDelegate3;

	private SwigDelegateOdAsyncIORequestHandler_4 swigDelegate4;

	private SwigDelegateOdAsyncIORequestHandler_5 swigDelegate5;

	private SwigDelegateOdAsyncIORequestHandler_6 swigDelegate6;

	private SwigDelegateOdAsyncIORequestHandler_7 swigDelegate7;

	private SwigDelegateOdAsyncIORequestHandler_8 swigDelegate8;

	private SwigDelegateOdAsyncIORequestHandler_9 swigDelegate9;

	private SwigDelegateOdAsyncIORequestHandler_10 swigDelegate10;

	private SwigDelegateOdAsyncIORequestHandler_11 swigDelegate11;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdAsyncOpenFileRequest) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdAsyncIORequest) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdAsyncIORequest) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(ulong),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(ulong) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAsyncIORequestHandler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAsyncIORequestHandler obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAsyncIORequestHandler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdAsyncIORequestHandler cast(OdRxObject pObj)
	{
		OdAsyncIORequestHandler rXObject = Helpers.GetRXObject<OdAsyncIORequestHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_isASwigExplicitOdAsyncIORequestHandler(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_queryXSwigExplicitOdAsyncIORequestHandler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAsyncIORequestHandler createObject()
	{
		OdAsyncIORequestHandler rXObject = Helpers.GetRXObject<OdAsyncIORequestHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ulong newRequestDescriptor()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_newRequestDescriptor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void openFile(OdAsyncOpenFileRequest request)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_openFile(swigCPtr, OdAsyncOpenFileRequest.getCPtr(request));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void closeFile(ulong fileDescriptor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_closeFile(swigCPtr, fileDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void read(OdAsyncIORequest request)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_read(swigCPtr, OdAsyncIORequest.getCPtr(request));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void write(OdAsyncIORequest request)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_write(swigCPtr, OdAsyncIORequest.getCPtr(request));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdAsyncIO_OdAsyncIOResult returnResult(ulong requestDescriptor, ulong pOpenedFileDescriptor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_returnResult__SWIG_0(swigCPtr, requestDescriptor, pOpenedFileDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdAsyncIO_OdAsyncIOResult)result;
	}

	public virtual OdAsyncIO_OdAsyncIOResult returnResult(ulong requestDescriptor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_returnResult__SWIG_1(swigCPtr, requestDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdAsyncIO_OdAsyncIOResult)result;
	}

	public virtual void cancel(ulong requestDescriptor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_cancel(swigCPtr, requestDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void responseParsed(ulong requestDescriptor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_responseParsed(swigCPtr, requestDescriptor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("newRequestDescriptor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodnewRequestDescriptor;
		}
		if (SwigDerivedClassHasMethod("openFile", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodopenFile;
		}
		if (SwigDerivedClassHasMethod("closeFile", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcloseFile;
		}
		if (SwigDerivedClassHasMethod("read", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodread;
		}
		if (SwigDerivedClassHasMethod("write", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodwrite;
		}
		if (SwigDerivedClassHasMethod("returnResult", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreturnResult__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("returnResult", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodreturnResult__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("cancel", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcancel;
		}
		if (SwigDerivedClassHasMethod("responseParsed", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodresponseParsed;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncIORequestHandler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAsyncIORequestHandler));
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

	private ulong SwigDirectorMethodnewRequestDescriptor()
	{
		return newRequestDescriptor();
	}

	private void SwigDirectorMethodopenFile(IntPtr request)
	{
		try
		{
			openFile(new OdAsyncOpenFileRequest(request, cMemoryOwn: false));
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

	private void SwigDirectorMethodcloseFile(ulong fileDescriptor)
	{
		try
		{
			closeFile(fileDescriptor);
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

	private void SwigDirectorMethodread(IntPtr request)
	{
		try
		{
			read(new OdAsyncIORequest(request, cMemoryOwn: false));
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

	private void SwigDirectorMethodwrite(IntPtr request)
	{
		try
		{
			write(new OdAsyncIORequest(request, cMemoryOwn: false));
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

	private int SwigDirectorMethodreturnResult__SWIG_0(ulong requestDescriptor, ulong pOpenedFileDescriptor)
	{
		return (int)returnResult(requestDescriptor, pOpenedFileDescriptor);
	}

	private int SwigDirectorMethodreturnResult__SWIG_1(ulong requestDescriptor)
	{
		return (int)returnResult(requestDescriptor);
	}

	private void SwigDirectorMethodcancel(ulong requestDescriptor)
	{
		try
		{
			cancel(requestDescriptor);
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

	private void SwigDirectorMethodresponseParsed(ulong requestDescriptor)
	{
		try
		{
			responseParsed(requestDescriptor);
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

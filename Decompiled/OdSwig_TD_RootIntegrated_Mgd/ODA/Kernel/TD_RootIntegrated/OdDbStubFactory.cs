using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbStubFactory : IDisposable
{
	public delegate IntPtr SwigDelegateOdDbStubFactory_0(IntPtr pDb, IntPtr h);

	public delegate void SwigDelegateOdDbStubFactory_1(IntPtr pStub);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbStubFactory_0 swigDelegate0;

	private SwigDelegateOdDbStubFactory_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbHandle)
	};

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdDbStub) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbStubFactory(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbStubFactory obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbStubFactory()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbStubFactory(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdDbStub createStub(OdRxObject pDb, OdDbHandle h)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbStubFactory_createStub(swigCPtr, OdRxObject.getCPtr(pDb), OdDbHandle.getCPtr(h));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void freeStub(OdDbStub pStub)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbStubFactory_freeStub(swigCPtr, OdDbStub.getCPtr(pStub));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbStubFactory_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubFactory()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbStubFactory(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbStubFactory) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("createStub", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodcreateStub;
		}
		if (SwigDerivedClassHasMethod("freeStub", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodfreeStub;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbStubFactory_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbStubFactory));
	}

	private IntPtr SwigDirectorMethodcreateStub(IntPtr pDb, IntPtr h)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(createStub(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), new OdDbHandle(h, cMemoryOwn: false))).Handle;
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

	private void SwigDirectorMethodfreeStub(IntPtr pStub)
	{
		try
		{
			freeStub((pStub == IntPtr.Zero) ? null : new OdDbStub(pStub, cMemoryOwn: false));
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

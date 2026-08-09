using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAppInfoRecordIterator : IDisposable
{
	public delegate void SwigDelegateOdDbAppInfoRecordIterator_0();

	public delegate void SwigDelegateOdDbAppInfoRecordIterator_1();

	public delegate bool SwigDelegateOdDbAppInfoRecordIterator_2();

	public delegate IntPtr SwigDelegateOdDbAppInfoRecordIterator_3();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbAppInfoRecordIterator_0 swigDelegate0;

	private SwigDelegateOdDbAppInfoRecordIterator_1 swigDelegate1;

	private SwigDelegateOdDbAppInfoRecordIterator_2 swigDelegate2;

	private SwigDelegateOdDbAppInfoRecordIterator_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAppInfoRecordIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAppInfoRecordIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbAppInfoRecordIterator()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAppInfoRecordIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void start()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_start(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_step(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_done(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbAppInfoRecord getRecord()
	{
		OdDbAppInfoRecord result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbAppInfoRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_getRecord(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAppInfoRecordIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAppInfoRecordIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAppInfoRecordIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodstep;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getRecord", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetRecord;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAppInfoRecordIterator));
	}

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private void SwigDirectorMethodstep()
	{
		try
		{
			step();
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private IntPtr SwigDirectorMethodgetRecord()
	{
		return OdDbAppInfoRecord.getCPtr(getRecord()).Handle;
	}
}

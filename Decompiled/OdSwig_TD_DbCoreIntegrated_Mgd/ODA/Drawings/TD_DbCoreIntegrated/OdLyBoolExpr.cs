using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdLyBoolExpr : IDisposable
{
	public delegate IntPtr SwigDelegateOdLyBoolExpr_0();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdLyBoolExpr_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLyBoolExpr(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLyBoolExpr obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdLyBoolExpr()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdLyBoolExpr(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdArray_OdLyAndExpr__p_OdObjectsAllocator getAndExprs()
	{
		OdArray_OdLyAndExpr__p_OdObjectsAllocator result = new OdArray_OdLyAndExpr__p_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyBoolExpr_getAndExprs(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdLyBoolExpr()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdLyBoolExpr(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdLyBoolExpr) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getAndExprs", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetAndExprs;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyBoolExpr_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdLyBoolExpr));
	}

	private IntPtr SwigDirectorMethodgetAndExprs()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdArray_OdLyAndExpr__p_OdObjectsAllocator.getCPtr(getAndExprs()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}

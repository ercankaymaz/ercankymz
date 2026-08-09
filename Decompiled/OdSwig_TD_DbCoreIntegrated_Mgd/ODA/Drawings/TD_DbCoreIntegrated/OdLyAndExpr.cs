using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdLyAndExpr : IDisposable
{
	public delegate IntPtr SwigDelegateOdLyAndExpr_0();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdLyAndExpr_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLyAndExpr(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLyAndExpr obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdLyAndExpr()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdLyAndExpr(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdArray_OdLyRelExpr__p_OdObjectsAllocator getRelExprs()
	{
		OdArray_OdLyRelExpr__p_OdObjectsAllocator result = new OdArray_OdLyRelExpr__p_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyAndExpr_getRelExprs(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdLyAndExpr()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdLyAndExpr(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdLyAndExpr) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getRelExprs", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetRelExprs;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyAndExpr_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdLyAndExpr));
	}

	private IntPtr SwigDirectorMethodgetRelExprs()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdArray_OdLyRelExpr__p_OdObjectsAllocator.getCPtr(getRelExprs()).Handle;
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

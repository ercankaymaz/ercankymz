using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshObjectIdConverter : IDisposable
{
	public delegate long SwigDelegateOdGiProgressiveMeshObjectIdConverter_0(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshObjectIdConverter_1(long arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiProgressiveMeshObjectIdConverter_0 swigDelegate0;

	private SwigDelegateOdGiProgressiveMeshObjectIdConverter_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(long) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshObjectIdConverter(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshObjectIdConverter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiProgressiveMeshObjectIdConverter()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshObjectIdConverter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual long dbStubToInt(OdDbStub arg0)
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshObjectIdConverter_dbStubToInt(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub intToDbStub(long arg0)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshObjectIdConverter_intToDbStub(swigCPtr, arg0);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiProgressiveMeshObjectIdConverter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshObjectIdConverter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProgressiveMeshObjectIdConverter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("dbStubToInt", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethoddbStubToInt;
		}
		if (SwigDerivedClassHasMethod("intToDbStub", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodintToDbStub;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshObjectIdConverter_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProgressiveMeshObjectIdConverter));
	}

	private long SwigDirectorMethoddbStubToInt(IntPtr arg0)
	{
		return dbStubToInt((arg0 == IntPtr.Zero) ? null : new OdDbStub(arg0, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodintToDbStub(long arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(intToDbStub(arg0)).Handle;
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

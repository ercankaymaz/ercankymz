using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiConveyorOutput_Internal : OdGiConveyorOutput, IDisposable
{
	public delegate void SwigDelegateOdGiConveyorOutput_Internal_0(IntPtr destGeometry);

	public delegate IntPtr SwigDelegateOdGiConveyorOutput_Internal_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiConveyorOutput_Internal_0 swigDelegate0;

	private SwigDelegateOdGiConveyorOutput_Internal_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGiConveyorGeometry) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiConveyorOutput_Internal(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiConveyorOutput_Internal obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiConveyorOutput_Internal()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiConveyorOutput_Internal(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorOutput.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorOutput_Internal_OdGiConveyorOutput_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual void setDestGeometry(OdGiConveyorGeometry destGeometry)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorOutput_Internal_setDestGeometry(swigCPtr, destGeometry.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorGeometry destGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorOutput_Internal_destGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiConveyorOutput_Internal()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiConveyorOutput_Internal(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiConveyorOutput_Internal) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setDestGeometry", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetDestGeometry;
		}
		if (SwigDerivedClassHasMethod("destGeometry", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethoddestGeometry;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorOutput_Internal_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiConveyorOutput_Internal));
	}

	private void SwigDirectorMethodsetDestGeometry(IntPtr destGeometry)
	{
		try
		{
			setDestGeometry(new OdGiConveyorGeometry_Internal(destGeometry, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethoddestGeometry()
	{
		return destGeometry().GetInterfaceCPtr().Handle;
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiConveyorEntryPoint : OdGiConveyorOutput, IDisposable
{
	public delegate void SwigDelegateOdGiConveyorEntryPoint_0(IntPtr destGeometry);

	public delegate IntPtr SwigDelegateOdGiConveyorEntryPoint_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiConveyorEntryPoint_0 swigDelegate0;

	private SwigDelegateOdGiConveyorEntryPoint_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGiConveyorGeometry) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiConveyorEntryPoint(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiConveyorEntryPoint obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiConveyorEntryPoint()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiConveyorEntryPoint(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorOutput.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_OdGiConveyorOutput_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public OdGiConveyorEntryPoint()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiConveyorEntryPoint__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiConveyorEntryPoint) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiConveyorEntryPoint(OdGiConveyorGeometry geom)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiConveyorEntryPoint__SWIG_1(geom.GetInterfaceCPtr()), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiConveyorEntryPoint) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiConveyorGeometry geometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_geometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDestGeometry(OdGiConveyorGeometry destGeometry)
	{
		if (SwigDerivedClassHasMethod("setDestGeometry", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_setDestGeometrySwigExplicitOdGiConveyorEntryPoint(swigCPtr, destGeometry.GetInterfaceCPtr());
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_setDestGeometry(swigCPtr, destGeometry.GetInterfaceCPtr());
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorGeometry destGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(SwigDerivedClassHasMethod("destGeometry", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_destGeometrySwigExplicitOdGiConveyorEntryPoint(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_destGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorEntryPoint_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiConveyorEntryPoint));
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

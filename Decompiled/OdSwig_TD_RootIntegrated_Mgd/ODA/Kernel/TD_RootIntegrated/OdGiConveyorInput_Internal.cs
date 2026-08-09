using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiConveyorInput_Internal : OdGiConveyorInput, IDisposable
{
	public delegate void SwigDelegateOdGiConveyorInput_Internal_0(IntPtr sourceNode);

	public delegate void SwigDelegateOdGiConveyorInput_Internal_1(IntPtr sourceNode);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiConveyorInput_Internal_0 swigDelegate0;

	private SwigDelegateOdGiConveyorInput_Internal_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGiConveyorOutput) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGiConveyorOutput) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiConveyorInput_Internal(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiConveyorInput_Internal obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiConveyorInput_Internal()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiConveyorInput_Internal(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorInput.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorInput_Internal_OdGiConveyorInput_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual void addSourceNode(OdGiConveyorOutput sourceNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorInput_Internal_addSourceNode(swigCPtr, sourceNode.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeSourceNode(OdGiConveyorOutput sourceNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorInput_Internal_removeSourceNode(swigCPtr, sourceNode.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiConveyorInput_Internal()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiConveyorInput_Internal(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiConveyorInput_Internal) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("addSourceNode", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodaddSourceNode;
		}
		if (SwigDerivedClassHasMethod("removeSourceNode", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodremoveSourceNode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorInput_Internal_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiConveyorInput_Internal));
	}

	private void SwigDirectorMethodaddSourceNode(IntPtr sourceNode)
	{
		try
		{
			addSourceNode(new OdGiConveyorOutput_Internal(sourceNode, cMemoryOwn: false));
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

	private void SwigDirectorMethodremoveSourceNode(IntPtr sourceNode)
	{
		try
		{
			removeSourceNode(new OdGiConveyorOutput_Internal(sourceNode, cMemoryOwn: false));
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

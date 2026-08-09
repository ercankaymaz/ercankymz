using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiEntityImpl : OdSiEntity, IDisposable
{
	public delegate bool SwigDelegateOdSiEntityImpl_0(IntPtr extents);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSiEntityImpl_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGeExtents3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiEntityImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiEntityImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSiEntityImpl()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiEntityImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiEntity.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdSiEntityImpl_OdSiEntity_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual bool Extents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiEntityImpl_Extents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiEntityImpl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiEntityImpl(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiEntityImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("Extents", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodExtents;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSiEntityImpl_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiEntityImpl));
	}

	private bool SwigDirectorMethodExtents(IntPtr extents)
	{
		return Extents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}
}

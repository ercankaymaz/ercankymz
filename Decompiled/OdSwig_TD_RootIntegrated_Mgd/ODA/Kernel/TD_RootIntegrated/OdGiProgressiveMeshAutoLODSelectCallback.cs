using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshAutoLODSelectCallback : IDisposable
{
	public delegate uint SwigDelegateOdGiProgressiveMeshAutoLODSelectCallback_0(IntPtr pPM, IntPtr pView, IntPtr pModelToWorldTransform);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiProgressiveMeshAutoLODSelectCallback_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(OdGiProgressiveMesh),
		typeof(OdGiViewport),
		typeof(OdGeMatrix3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshAutoLODSelectCallback(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshAutoLODSelectCallback obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiProgressiveMeshAutoLODSelectCallback()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshAutoLODSelectCallback(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual uint selectLOD(OdGiProgressiveMesh pPM, OdGiViewport pView, OdGeMatrix3d pModelToWorldTransform)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshAutoLODSelectCallback_selectLOD(swigCPtr, OdGiProgressiveMesh.getCPtr(pPM), OdGiViewport.getCPtr(pView), OdGeMatrix3d.getCPtr(pModelToWorldTransform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiProgressiveMeshAutoLODSelectCallback()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshAutoLODSelectCallback(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProgressiveMeshAutoLODSelectCallback) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("selectLOD", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodselectLOD;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshAutoLODSelectCallback_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProgressiveMeshAutoLODSelectCallback));
	}

	private uint SwigDirectorMethodselectLOD(IntPtr pPM, IntPtr pView, IntPtr pModelToWorldTransform)
	{
		return selectLOD(Helpers.GetRXObject<OdGiProgressiveMesh>(pPM, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewport>(pView, bOwn: false, bTryAddToTransaction: false), (pModelToWorldTransform == IntPtr.Zero) ? null : new OdGeMatrix3d(pModelToWorldTransform, cMemoryOwn: false));
	}
}

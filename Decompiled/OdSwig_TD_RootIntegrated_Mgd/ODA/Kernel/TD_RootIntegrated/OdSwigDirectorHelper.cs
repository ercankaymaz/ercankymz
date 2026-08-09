using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSwigDirectorHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSwigDirectorHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSwigDirectorHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSwigDirectorHelper()
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
					throw new MethodAccessException("C++ destructor does not have public access");
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static void director_callUpdateFunction(IntPtr pRawPtrFunc, IntPtr pNewObjPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSwigDirectorHelper_director_callUpdateFunction(pRawPtrFunc, pNewObjPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void director_freeData(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSwigDirectorHelper_director_freeData(data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void director_UnpackData(IntPtr pPackageData, out IntPtr pOriginalObject, out IntPtr pFunction)
	{
		IntPtr[] array = new IntPtr[2];
		Marshal.Copy(pPackageData, array, 0, 2);
		pOriginalObject = array[0];
		pFunction = array[1];
	}
}

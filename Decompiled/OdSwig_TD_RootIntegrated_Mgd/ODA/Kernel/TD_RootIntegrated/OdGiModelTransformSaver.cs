using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiModelTransformSaver : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiModelTransformSaver(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiModelTransformSaver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiModelTransformSaver()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiModelTransformSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static IntPtr SwigConstructOdGiModelTransformSaver(ref OdGiGeometry geom, OdGeMatrix3d xMat)
	{
		IntPtr jarg = ((geom == null) ? IntPtr.Zero : OdGiGeometry.getCPtr(geom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiModelTransformSaver(ref jarg, OdGeMatrix3d.getCPtr(xMat));
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				geom = null;
			}
			if (jarg != intPtr)
			{
				geom = Helpers.GetRXObject<OdGiGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiModelTransformSaver(ref OdGiGeometry geom, OdGeMatrix3d xMat)
		: this(SwigConstructOdGiModelTransformSaver(ref geom, xMat), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiModelTransformSaverOpt : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiModelTransformSaverOpt(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiModelTransformSaverOpt obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiModelTransformSaverOpt()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiModelTransformSaverOpt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static IntPtr SwigConstructOdGiModelTransformSaverOpt(ref OdGiGeometry geom, OdGeMatrix3d xMat)
	{
		IntPtr jarg = ((geom == null) ? IntPtr.Zero : OdGiGeometry.getCPtr(geom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiModelTransformSaverOpt(ref jarg, OdGeMatrix3d.getCPtr(xMat));
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

	public OdGiModelTransformSaverOpt(ref OdGiGeometry geom, OdGeMatrix3d xMat)
		: this(SwigConstructOdGiModelTransformSaverOpt(ref geom, xMat), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

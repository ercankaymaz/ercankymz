using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.PointCloud.RcsFileServices;

public class OdRcsPointDataReceiver : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRcsPointDataReceiver(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRcsPointDataReceiver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRcsPointDataReceiver()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdRcsPointDataReceiver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void setNumberOfPoints(uint arg0)
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsPointDataReceiver_setNumberOfPoints(swigCPtr, arg0);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPoint(uint index, float x, float y, float z, byte r, byte g, byte b, ushort normalIndex, byte intensity)
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsPointDataReceiver_setPoint(swigCPtr, index, x, y, z, r, g, b, normalIndex, intensity);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

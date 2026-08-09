using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBlob : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBlob(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBlob obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBlob()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBlob(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool rdBool()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdBool(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrBool(bool arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrBool(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public sbyte rdInt8()
	{
		sbyte result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdInt8(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrInt8(sbyte arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrInt8(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short rdInt16()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdInt16(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrInt16(short arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrInt16(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int rdInt32()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdInt32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrInt32(int arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrInt32(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public long rdInt64()
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrInt64(long arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrInt64(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double rdDouble()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdDouble(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrDouble(double arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrDouble(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d rdPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdPoint3d(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrPoint3d(OdGePoint3d arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrPoint3d(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d rdVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdVector3d(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrVector3d(OdGeVector3d arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrVector3d(swigCPtr, OdGeVector3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr rdAddress()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdAddress(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrAddress(IntPtr arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrAddress(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rdBytes(IntPtr buf, uint len)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdBytes(swigCPtr, buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrBytes(IntPtr buf, uint len)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrBytes(swigCPtr, buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rdPoints2d(OdGePoint2d points, uint num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdPoints2d(swigCPtr, OdGePoint2d.getCPtr(points), num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoints2d(OdGePoint2d[] points, uint num)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dPair(points);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrPoints2d(swigCPtr, intPtr, num);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public void rdPoints3d(OdGePoint3d points, uint num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdPoints3d(swigCPtr, OdGePoint3d.getCPtr(points), num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrPoints3d(OdGePoint3d points, uint num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrPoints3d(swigCPtr, OdGePoint3d.getCPtr(points), num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void wrDoubles(double[] doubles)
	{
		IntPtr intPtr = Helpers.MarshaldoubleFixedArray(doubles);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrDoubles(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void rdDoubles(double[] doubles)
	{
		IntPtr intPtr = Helpers.MarshaldoubleFixedArray(doubles);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdDoubles(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void rdObjectIds(OdDbStub pRes, uint num)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdObjectIds(swigCPtr, OdDbStub.getCPtr(pRes).Handle, num);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub rdObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_rdObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrObjectId(OdDbStub id)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBlob_wrObjectId(swigCPtr, OdDbStub.getCPtr(id));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdBlob_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

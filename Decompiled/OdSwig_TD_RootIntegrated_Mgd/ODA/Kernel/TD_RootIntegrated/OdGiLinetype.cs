using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLinetype : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLinetype(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLinetype obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiLinetype()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLinetype(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiLinetype()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLinetype(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isContinuous()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_isContinuous(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByBlock()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_isByBlock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByBlock(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setByBlock(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isByLayer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_isByLayer(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByLayer(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setByLayer(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double patternLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_patternLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternLength(double patternLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setPatternLength(swigCPtr, patternLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numDashes()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_numDashes(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumDashes(int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setNumDashes(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dashAt(int index, OdGiLinetypeDash dash)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_dashAt__SWIG_0(swigCPtr, index, OdGiLinetypeDash.getCPtr(dash));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiLinetypeDash dashAt(int index)
	{
		OdGiLinetypeDash result = new OdGiLinetypeDash(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_dashAt__SWIG_1(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDashAt(int index, double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setDashAt__SWIG_0(swigCPtr, index, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDashAt(int index, OdGiLinetypeDash dash)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setDashAt__SWIG_1(swigCPtr, index, OdGiLinetypeDash.getCPtr(dash));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dashes(OdGiLinetypeDashArray dashes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_dashes(swigCPtr, OdGiLinetypeDashArray.getCPtr(dashes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDashes(OdGiLinetypeDashArray dashes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetype_setDashes(swigCPtr, OdGiLinetypeDashArray.getCPtr(dashes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

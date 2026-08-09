using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdEdgeHLREdgeVisitor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdgeHLREdgeVisitor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdgeHLREdgeVisitor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdEdgeHLREdgeVisitor()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdEdgeHLREdgeVisitor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void edge(int bodyIndex, int edgeTag, OdEdgeTypeFlags_Enum edgeType, OdGeCurve3d edge, OdLineSegIntervalArray segmenParameters, OdBoolArray visibilities)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdgeHLREdgeVisitor_edge(swigCPtr, bodyIndex, edgeTag, (int)edgeType, OdGeCurve3d.getCPtr(edge), OdLineSegIntervalArray.getCPtr(segmenParameters), OdBoolArray.getCPtr(visibilities).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

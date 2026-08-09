using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFaceEdgeDataTraitsSaver : OdGiFaceDataTraitsSaver
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFaceEdgeDataTraitsSaver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceEdgeDataTraitsSaver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFaceEdgeDataTraitsSaver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFaceEdgeDataTraitsSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiFaceEdgeDataTraitsSaver(OdGiFaceData pFaceData, EdgeData pEdgeData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceEdgeDataTraitsSaver(OdGiFaceData.getCPtr(pFaceData), pEdgeData, OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceEdgeDataTraitsSaver_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
